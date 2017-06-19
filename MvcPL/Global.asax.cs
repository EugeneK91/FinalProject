using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Logger;
using MvcPL.App_Start;
using MvcPL.Initializer;
using ORM;

namespace MvcPL
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private ILogger Logger { get; } = CustomLogger.GetCurrentClassLogger;
        protected void Application_Start()
        {
            Database.SetInitializer<EntityContext>(new AudioCardFileDbInitializer());
            AreaRegistration.RegisterAllAreas();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        private void Application_Error(object sender, EventArgs e)
        {
            Logger.Error(Server.GetLastError().ToString());
            Response.Clear();
            Server.ClearError();
            Response.RedirectToRoute("Error");
        }
    }
}
