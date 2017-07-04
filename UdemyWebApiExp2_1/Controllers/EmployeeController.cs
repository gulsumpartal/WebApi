using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
using UdemyWebApiExp2_1.Models;

namespace UdemyWebApiExp2_1.Controllers
{
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        static List<Employee> employees = new List<Employee>()
        {
            new Employee() {Id = 1,Name = "Person 1"},
            new Employee() {Id = 2,Name = "Person 2"},
            new Employee() {Id= 3 ,Name = "Person 3"}
        };

        [Route("GetAll")]
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return employees;
        }

        [Route("GetById")]
        [HttpPost]
        public Employee GetEmployeeById([FromBody] int id)
        {
            return employees.FirstOrDefault(p => p.Id == id);
        }
       
        [Route("TaksById")]
        [HttpPost]
        public List<string> GetTasksById( int id)
        {
            switch (id){
                case 1:
                    return new List<string> { "Task 1" };
                case 2:
                    return new List<string> { "Task 2" };
            }
            return null;
        }

        //routeprefix ezilme yöntemi
        [Route("~/api/tasks")]
        [HttpGet]
        public List<string> GetTaks()
        {
            List<string> taskList = new List<string> { "Task 1" , "Task 2" , "Task 3" , "Task 4" , "Task 5" , "Task 6" };
            return taskList;
        }
    }
}
