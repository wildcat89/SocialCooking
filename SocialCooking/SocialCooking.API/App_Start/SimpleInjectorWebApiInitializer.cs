using System.Linq;

[assembly: WebActivator.PostApplicationStartMethod(typeof(SocialCooking.API.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace SocialCooking.API.App_Start
{
    using System.Web.Http;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    
    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize(HttpConfiguration config)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            InitializeContainer(container);

            container.RegisterWebApiControllers(config);

            container.Verify();

            config.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
            //var repositoryAssembly = typeof(SCDishRepository).Assembly;

            //var registrations =
            //    from type in repositoryAssembly.GetExportedTypes()
            //    where type.Namespace == "SocialCooking.Domain.Concrete"
            //    where type.GetInterfaces().Any()
            //    select new { Service = type.GetInterfaces().SingleOrDefault(), Implementation = type };

            //foreach (var reg in registrations)
            //{
            //    container.Register(reg.Service, reg.Implementation, Lifestyle.Transient);
            //}
            //container.Register<IDishIngredientRepository, SCDishIngredientRepository>();
            // For instance:
            // container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);
        }
    }
}