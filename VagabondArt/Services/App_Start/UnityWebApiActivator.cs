using Microsoft.Practices.Unity.WebApi;
using System.Web;
using System.Web.Http;

[assembly: PreApplicationStartMethod(typeof(Services.App_Start.UnityWebActivator), "Start")]

namespace Services.App_Start
{
    /// <summary>Provides the bootstrapping for integrating Unity with ASP.NET MVC.</summary>
    public static class UnityWebActivator
        {
            /// <summary>Integrates Unity when the application starts.</summary>
            public static void Start()
            {
                var container = UnityConfig.GetConfiguredContainer();

                GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            }

            /// <summary>Disposes the Unity container when the application is shut down.</summary>
            public static void Shutdown()
            {
                var container = UnityConfig.GetConfiguredContainer();
                container.Dispose();
            }
        }
    }

