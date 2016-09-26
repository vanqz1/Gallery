using Repository.RepositoryInterfaces;
using System.Collections.Generic;

namespace Repository.Repository
{
    public class PicturesBgServices : IPicturesBgRepository
    {
        private readonly PicturesBgRepository m_PicturesBgModel;

        public PicturesBgServices()
        {
            m_PicturesBgModel = new PicturesBgRepository();
        }

        public PicturesBgServices(PicturesBgRepository picturesBgModel)
        {
            m_PicturesBgModel = picturesBgModel;
        }

        public PicturesBgModelRepository GetByIdPictureBg(int id)
        {
            var picture = m_PicturesBgModel.GetByIdPictureBg(id);

            if (picture == null) return null;

            return new PicturesBgModelRepository
            {
                Id = picture.Id,
                Title = picture.Title,
                Technics = picture.Technics,
                AuthorName = picture.AuthorName,
                Size = picture.Size,
                Price = picture.Price,
                IsSold = picture.IsSold,
                PicturePath = picture.PicturePath

            };
        }

        public List<PicturesBgModelRepository> GetAllPicturesBg()
        {
            var pictures = m_PicturesBgModel.GetAllPicturesBg();
            var listOfPictures = new List<PicturesBgModelRepository>();

            foreach (var picture in pictures)
            {
                listOfPictures.Add(new PicturesBgModelRepository {
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

            return listOfPictures;

        }
    }
}
