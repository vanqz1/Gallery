using System;
using Services.Services;
using Services.Interfaces;
using Microsoft.Practices.Unity;
using Service.Services;
using Repository.RepositoryInterfaces;
using Repository.Repository;

namespace Services.App_Start
{
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IPicturesService, PicturesService>();
            container.RegisterType<IAuthorService, AuthorService>();
            container.RegisterType<IPicturesRepository, PicturesRepository>();
            container.RegisterType<IAuthorRepository, AuthorRepository>();
            container.RegisterType<IAuthenticationService, AuthenticationService>();
            container.RegisterType<IAdminRepository, AdminRepository>();
            container.RegisterType<ITokenRepository, TokenRepository>();

            Repository.App_Start.UnityConfig.RegisterTypes(container);

        }
    }
}
