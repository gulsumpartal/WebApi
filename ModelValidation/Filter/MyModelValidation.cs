using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;

namespace ModelValidation.Filter
{
    public class MyModelValidation : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ModelState.IsValid)
            {
                base.OnActionExecuting(actionContext);
            }
            else
            {
                var errorList = actionContext.ModelState.Values.SelectMany(p => p.Errors).Select(x => x.ErrorMessage).ToList();
                var message = string.Join(Environment.NewLine, errorList);
                actionContext.Response= actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, message);
            }
        }
    }
}