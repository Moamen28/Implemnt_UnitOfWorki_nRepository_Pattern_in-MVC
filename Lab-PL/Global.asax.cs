using Lab_PL.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Lab_PL
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //           AreaRegistration.RegisterAllAreas();
            IOCconfigration.IOCconfigure();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}