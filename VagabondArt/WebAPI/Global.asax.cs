using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Repository.RepositoryInterfaces;
using System.Web.Http;
using WebAPI.Services;
using Repository.Repository;
using WebAPI.Interfaces;
using Microsoft.Practices.Unity;
using Repository.App_Start;
using Repository.RepositoryModels;
using WebAPI.Models;
using AutoMapper;

namespace WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<PicturesModelRepository, Picture>();
            });

            //Dependency Unity
            var container = UnityConfig.GetConfiguredContainer();
            UnityConfig.RegisterTypes(container);

            container.RegisterType<IPicturesService, PicturesService>();


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
