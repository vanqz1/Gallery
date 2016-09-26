using DataSource;
using System.Collections.Generic;

namespace Repository.Repository
{
    public class PicturesBgRepository
    {
        private readonly PicturesBgDataSource m_PicturesBgModel;

        public PicturesBgRepository()
        {
            m_PicturesBgModel = new PicturesBgDataSource();
        }

        public PicturesBgRepository(PicturesBgDataSource picturesBgModel)
        {
            m_PicturesBgModel = picturesBgModel;
        }

        public PicturesBgModelRepository GetByIdPictureBg(int id)
        {
            var picture = m_PicturesBgModel.GetByIdPictureBG(id);

            if (picture == null) return null;

            return new PicturesBgModelRepository
            {
                Id = picture.Id,
                Title = picture.Title,
                Technics = picture.Technics,
                AuthorName = picture.AuthorsBG.Name,
                Size = picture.Size,
                Price = picture.Price

            };
        }

        public List<PicturesBgModelRepository> GetAllPicturesBg()
        {
            var pictures = m_PicturesBgModel.GetAllPicturesBG();
            var listOfPictures = new List<PicturesBgModelRepository>();

            foreach (var picture in pictures)
            {
                listOfPictures.Add(new PicturesBgModelRepository {
                    Id = picture.Id,
                    Title = picture.Title,
                    Technics = picture.Technics,
                    AuthorName = picture.AuthorsBG.Name,
                    Size = picture.Size,
                    Price = picture.Price
                });
            }

            return listOfPictures;

        }
    }
}
