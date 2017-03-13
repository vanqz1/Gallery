using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http;
using Services.Interfaces;
using Microsoft.Practices.Unity;
using Services.Services;
using Service.Services;
using Services.App_Start;
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
            container.RegisterType<IAuthenticationService, AuthenticationService>();
            container.RegisterType<IAdminService, AdminService>();


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
