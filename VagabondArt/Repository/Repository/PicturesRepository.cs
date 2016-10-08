using Repository.RepositoryInterfaces;
using System.Collections.Generic;
using Repository.RepositoryModels;
using DataSource.DataSourceInterfaces;
using DataSource.DataSource;

namespace Repository.Repository
{
    public class PicturesRepository : IPicturesRepository
    {
        private readonly IPicturesDataSource m_PicturesDataSource;

        public PicturesRepository()
        {
            m_PicturesDataSource = new PicturesDataSource();
        }

        public List<PicturesModelRepository> GetAllPictures(int languageNum)
        {
            List<PicturesModelRepository> allPictures = new List<PicturesModelRepository>();

            var pictures = m_PicturesDataSource.GetAllPictures(languageNum);

            foreach (var picture in pictures)
            {
                allPictures.Add(new PicturesModelRepository
                {
                    Id = picture.Id,
                    Title = picture.Title,
                    Technics = picture.Technics,
                    AuthorName = picture.AuthorName,
                    Size = picture.Size,
                    Price = picture.Price,
                    IsSold = picture.IsSold,
                    PicturePath = picture.PicturePath
                });
            }

            return allPictures;
        }

        public PicturesModelRepository GetByIdPicture(int id, int languageNum)
        {
            var dataSourcePicture = m_PicturesDataSource.GetByIdPicture(id, languageNum);

            if (dataSourcePicture == null) return null;

            return new PicturesModelRepository
            {
                Id = dataSourcePicture.Id,
                Title = dataSourcePicture.Title,
                Technics = dataSourcePicture.Technics,
                AuthorName = dataSourcePicture.AuthorName,
                Size = dataSourcePicture.Size,
                Price = dataSourcePicture.Price,
                IsSold = dataSourcePicture.IsSold,
                PicturePath = dataSourcePicture.PicturePath
            };
        }
    }
}
