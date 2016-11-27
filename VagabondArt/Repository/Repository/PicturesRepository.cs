using Repository.RepositoryInterfaces;
using System.Collections.Generic;
using Repository.RepositoryModels;
using DataSource.DataSourceInterfaces;
using AutoMapper;

namespace Repository.Repository
{
    public class PicturesRepository : IPicturesRepository
    {
        private readonly IPicturesDataSource m_PicturesDataSource;
        private readonly IMapper m_Mapper;

        public PicturesRepository(IPicturesDataSource picturesDataSource, IMapper mapper)
        {
            m_PicturesDataSource = picturesDataSource;
            m_Mapper = mapper;
        }

        public IEnumerable<PicturesModelRepository> GetAllPictures(int languageNum)
        {
            var pictures = m_PicturesDataSource.GetAllPictures(languageNum);

            foreach (var picture in pictures)
            {
                yield return m_Mapper.Map<PicturesModelRepository>(picture);
            }
            
        }

        public PicturesModelRepository GetByIdPicture(int id, int languageNum)
        {
            var dataSourcePicture = m_PicturesDataSource.GetByIdPicture(id, languageNum);

            if (dataSourcePicture == null) return null;

            return m_Mapper.Map<PicturesModelRepository>(dataSourcePicture);
        }
    }
}
