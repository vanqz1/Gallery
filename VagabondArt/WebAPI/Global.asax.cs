using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Repository.RepositoryInterfaces;
using System.Web.Http;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using WebAPI.Services;
using Repository.Repository;
using WebAPI.Interfaces;

namespace WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
       
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            // Register your types, for instance using the scoped lifestyle:

            container.Register<IPicturesRepository, PicturesRepository>(Lifestyle.Scoped);
            container.Register<IPicturesService, PicturesService>(Lifestyle.Scoped);

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

            // Format data which has been sent to JS format
            var formatters = GlobalConfiguration.Configuration.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
