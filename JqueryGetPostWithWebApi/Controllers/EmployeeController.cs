using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JqueryGetPostWithWebApi.Controllers
{
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        EmployeeDBEntities db = new EmployeeDBEntities();

        [Route("GetAll")]
        [HttpGet]
        public IEnumerable<Employee> GetAllEmployee()
        {
            return db.Employees.ToList();
        }

        //NOT WEb api varsayılan olarak basit request dataları url üzerinden , komplex dataları ise request body üzerinden alır,
        [Route("GetAllWithQueryString")]
        [HttpGet]
        public HttpResponseMessage GetAllEmployeeWithQueryString([FromUri] string gender = "all",
            [FromUri] int? top = 0)
        {
            IQueryable<Employee> query = db.Employees;
            gender = gender.ToLower();
            switch (gender)
            {
                case "all":
                    break;
                case "male":
                case "female":
                    query = query.Where(p => p.Gender.ToLower() == gender);
                    break;
                default:
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                        $"{gender} is not valid gender. Please use all,male or female.");
            }
            if (top > 0)
            {
                query.Take(top.Value);
            }

            return Request.CreateResponse(HttpStatusCode.OK, query.ToList());
        }

        [Route("GetById")]
        [HttpPost]
        public HttpResponseMessage GetEmployeeById([FromBody] int id)
        {
            var data = db.Employees.FirstOrDefault(p => p.Id == id);
            if (data == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Id si {id} olan çalışan bulunamadı.");
            else
                return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("Add")]
        [HttpPost]
        public HttpResponseMessage AddEmployee([FromBody] Employee employee)
        {
            try
            {
                db.Employees.Add(employee);
                if (db.SaveChanges() > 0)
                    return Request.CreateResponse(HttpStatusCode.Created, employee);
                else
                    return Request.CreateErrorResponse(HttpStatusCode.ServiceUnavailable, "Data added");
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.ServiceUnavailable, ex);
            }

        }

        [Route("Update")]
        [HttpPut]
        public HttpResponseMessage UpdateEmployee([FromBody] Employee employee)
        {
            try
            {
                var emp = db.Employees.FirstOrDefault(p => p.Id == employee.Id);
                if (emp == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound,
                        $"Employee Id :  {employee.Id} not found.");
                else
                {
                    emp.Name = employee.Name;
                    emp.SurName = employee.SurName;
                    emp.Gender = employee.Gender;
                    emp.Salary = employee.Salary;

                    if (db.SaveChanges() > 0)
                        return Request.CreateResponse(HttpStatusCode.OK, "Update operation is successful");
                    else
                        return Request.CreateErrorResponse(HttpStatusCode.ServiceUnavailable,
                            "Data could not be updated.");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.ServiceUnavailable, ex);
            }
        }

        [Route("Delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteEmployee([FromBody] int id)
        {
            try
            {
                var emp = db.Employees.FirstOrDefault(p => p.Id == id);
                if (emp == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound,
                        $"Employee Id : {id} not found");
                else
                {

                    db.Employees.Remove(emp);
                    if (db.SaveChanges() > 0)
                        return Request.CreateResponse(HttpStatusCode.OK, "Delete operation is successful");
                    else
                        return Request.CreateErrorResponse(HttpStatusCode.ServiceUnavailable,
                            "Data could not be deleted.");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.ServiceUnavailable, ex);
            }
        }
    }
}
