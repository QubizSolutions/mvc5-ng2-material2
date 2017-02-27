[assembly: WebActivator.PostApplicationStartMethod(typeof(Tesseract.Web.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace Tesseract.Web.App_Start
{
    using System.Web.Http;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using DA;
    using DA.Repositories;
    using Infrastructure;
    using Services.Services;

    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
           
            InitializeContainer(container);
            
            container.Verify();
            
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
            container.Register<IConfig, Config>(Lifestyle.Singleton);

            container.Register<AuthorsDBContext>(() =>
                new AuthorsDBContext(container.GetInstance<IConfig>().ConnectionString), Lifestyle.Singleton);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Singleton);
            container.Register<IAuthorRepository, AuthorRepository>(Lifestyle.Singleton);
            container.Register<IArticleRepository, ArticleRepository>(Lifestyle.Singleton);
            container.Register<IUnitOfWorkFactory, UnitOfWorkFactory>(Lifestyle.Singleton);

            container.Register<IAuthorService, AuthorService>(Lifestyle.Singleton);
            container.Register<IArticleService, ArticleService>(Lifestyle.Singleton);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
        }
    }
}