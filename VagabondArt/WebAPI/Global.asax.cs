using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Repository.RepositoryInterfaces;
using System.Web.Http;
using WebAPI.Services;
using Repository.Repository;
using WebAPI.Interfaces;
using Microsoft.Practices.Unity;
using Repository.App_Start;

namespace WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Dependency Unity
            var container = UnityConfig.GetConfiguredContainer();
            UnityConfig.RegisterTypes(container);

            container.RegisterType<IPicturesService, PicturesService>();
            container.RegisterType<IAuthorService, AuthorService>();
            container.RegisterType<IPicturesRepository, PicturesRepository>();
            container.RegisterType<IAuthorRepository, AuthorRepository>();

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
