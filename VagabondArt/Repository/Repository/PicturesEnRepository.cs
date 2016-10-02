using DataSource.DataSource;
using Repository.RepositoryInterfaces;
using System.Collections.Generic;

namespace Repository.Repository
{
    public class PicturesEnRepository : IPicturesEnRepository
    {
        private readonly PicturesEnDataSource m_PicturesEnModel;

        public PicturesEnRepository()
        {
            m_PicturesEnModel = new PicturesEnDataSource();
        }
        
        public PicturesEnModelRepository GetByIdPictureEn(int id)
        {
            var picture = m_PicturesEnModel.GetByIdPictureEN(id);

            if (picture == null) return null;

            return new PicturesEnModelRepository
            {
                Id = picture.Id,
                Title = picture.Title,
                Technics = picture.Technics,
                AuthorName = picture.AuthorsEN.Name,
                Size = picture.Size,
                Price = picture.Price,
                IsSold = picture.IsSold,
                PicturePath = picture.PicturePath

            };
        }

        public List<PicturesEnModelRepository> GetAllPicturesEn()
        {
            var pictures = m_PicturesEnModel.GetAllPicturesEN();
            var listOfPictures = new List<PicturesEnModelRepository>();

            foreach (var picture in pictures)
            {
                listOfPictures.Add(new PicturesEnModelRepository {
                    Id = picture.Id,
                    Title = picture.Title,
                    Technics = picture.Technics,
                    AuthorName = picture.AuthorsEN.Name,
                    Size = picture.Size,
                    Price = picture.Price,
                    IsSold = picture.IsSold,
                    PicturePath = picture.PicturePath
                });
            }
            return listOfPictures;
        }
    }
}
