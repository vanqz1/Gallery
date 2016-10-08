using AutoMapper;
using DataSource.DataSource;
using Repository.Repository;
using System.Web;

[assembly: PreApplicationStartMethod(typeof(Repository.App_Start.AutoMapperCongig), "Start")]

namespace Repository.App_Start
{
    public  static class AutoMapperCongig
    {
        private static MapperConfiguration _mapperConfiguration { get; set; }

        public static void Start()
        {
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PicturesDataSource, PicturesRepository>(); ;
            });
        }
    }
}
