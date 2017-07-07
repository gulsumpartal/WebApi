using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExcepitonFilterAttribute.MyFilter;

namespace ExcepitonFilterAttribute.Controllers
{
    [MyError]
    public class EmployeeController : ApiController
    {
        private EmployeeDBEntities db = new EmployeeDBEntities();

        public IQueryable<Employees> Gets()
        {
            throw new Exception("Manuel fırlatıaln hatadır.");
           
        }
        
    }
}
