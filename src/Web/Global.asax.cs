using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

#if !DEBUG
            System.Data.Entity.Database.SetInitializer<Tesseract.DA.AuthorsDBContext>(new System.Data.Entity.MigrateDatabaseToLatestVersion<Tesseract.DA.AuthorsDBContext, Tesseract.DA.Migrations.Configuration>());

            Tesseract.DA.AuthorsDBContext tomContext = new Tesseract.DA.AuthorsDBContext();
            tomContext.Database.Initialize(true);

            System.Data.Entity.Database.SetInitializer<Tesseract.DA.AuthorsDBContext>(null);
#endif
        }
    }
}