
using DataSource;
using DataSource.DataSource;
using DataSource.DataSourceInterfaces;
using Repository.Repository;
using Repository.RepositoryInterfaces;
using SimpleInjector;
using System.Web;

[assembly: PreApplicationStartMethod(typeof(Repository.ConfigurationInjection.Startup), "Start")]

namespace Repository.ConfigurationInjection
{
    public class Startup
    {
        public static void Start()
        {
            var container = new Container();

            // Register your types, for instance using the scoped lifestyle:
            container.Register<IPicturesDataSource, PicturesDataSource>();

            container.Verify();
           
        }
    }
}
