using DataSource;
using DataSource.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class PicturesEnRepository
    {
        private readonly PicturesEnDataSource m_PicturesEnModel;

        public PicturesEnRepository()
        {
            m_PicturesEnModel = new PicturesEnDataSource();
        }

        public PicturesEnRepository(PicturesEnDataSource picturesEnModel)
        {
            m_PicturesEnModel = picturesEnModel;
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
                Price = picture.Price

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
                    Price = picture.Price
                });
            }

            return listOfPictures;

        }
    }
}
