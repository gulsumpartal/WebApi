using ModelValidation.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ModelValidation.Filter;

namespace ModelValidation.Controllers
{
    [MyModelValidation]
    public class UserController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage AddUser([FromBody] User user)
        {
                return Request.CreateResponse(HttpStatusCode.Created, "User created.");
            
        }
    }
}
