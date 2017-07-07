using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using log4net.Config;

namespace ExcepitonFilterAttribute
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            XmlConfigurator.Configure(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + @"\AppConfig\log4net.config"));
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
