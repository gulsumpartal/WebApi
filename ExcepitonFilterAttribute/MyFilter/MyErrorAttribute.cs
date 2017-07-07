using System.Web.Http.Filters;
using ExcepitonFilterAttribute.Helper;

namespace ExcepitonFilterAttribute.MyFilter
{
    //attribute classından miras almalıdır.
    public class MyErrorAttribute :ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            //Log - use log4net

            /**
             * 1-log4net install (nuget manager )
             * 2-create web config file (log4net.config) (içeriği direk kopyala)
             * 3-Web confing (configSections added)
             * 4-Create service folder -> create LogService class
             * 5-create helper folder-> create Utility class -> create ReportError mehtod 
             * 6-Global.asax içerisine ayarlanma yapılmalı
             * **/
             //< configSections >    < section name = "log4net" type = "log4net.Config.Log4NetConfigurationSectionHandler,log4net" />  </ configSections >
             Utility.ReportError(actionExecutedContext.Exception);
            //response 
        }
    }
} 