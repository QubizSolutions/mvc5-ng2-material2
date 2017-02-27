using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Tesseract.DA;
using Tesseract.DA.Repositories;
using Tesseract.Infrastructure;
using Tesseract.Services.Services;
using Tesseract.Web;
using Tesseract.Web.App_Start;

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

            SimpleInjectorWebApiInitializer.Initialize();

#if !DEBUG
            System.Data.Entity.Database.SetInitializer<Tesseract.DA.AuthorsDBContext>(new System.Data.Entity.MigrateDatabaseToLatestVersion<Tesseract.DA.AuthorsDBContext, Tesseract.DA.Migrations.Configuration>());
            
            Tesseract.DA.AuthorsDBContext tomContext = new AuthorsDBContext(ConfigurationManager.ConnectionStrings["AuthorContext"].ConnectionString);
            tomContext.Database.Initialize(true);

            System.Data.Entity.Database.SetInitializer<Tesseract.DA.AuthorsDBContext>(null);
#endif
        }
    }
}