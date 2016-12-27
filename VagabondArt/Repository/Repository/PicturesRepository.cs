using Repository.RepositoryInterfaces;
using System.Collections.Generic;
using Repository.RepositoryModels;
using DataSource.DataSourceInterfaces;
using DataSource.Model;

namespace Repository.Repository
{
    public class PicturesRepository : IPicturesRepository
    {
        private readonly IPicturesDataSource m_PicturesDataSource;

        public PicturesRepository(IPicturesDataSource picturesDataSource)
        {
            m_PicturesDataSource = picturesDataSource;
        }

        public IEnumerable<PicturesModelRepository> GetAllPictures(int languageNum)
        {
            var pictures = m_PicturesDataSource.GetAllPictures(languageNum);

            foreach (var picture in pictures)
            {
                yield return new PicturesModelRepository {
                    Title = picture.Title,
                    Technics = picture.Technics,
                    AuthorName = picture.AuthorName,
                    Id = picture.Id,
                    IsSold = picture.IsSold,
                    PicturePath = picture.PicturePath,
                    Price = picture.Price,
                    Size = picture.Size
                };
            }
            
        }

        public PicturesModelRepository GetByIdPicture(int id, int languageNum)
        {
            var picture = m_PicturesDataSource.GetByIdPicture(id, languageNum);

            if (picture == null) return null;

            return new PicturesModelRepository
            {
                Title = picture.Title,
                Technics = picture.Technics,
                AuthorName = picture.AuthorName,
                Id = picture.Id,
                IsSold = picture.IsSold,
                PicturePath = picture.PicturePath,
                Price = picture.Price,
                Size = picture.Size
            };
        }

        public void AddNewPicture(NewPictureRepositoryModel picture)
        {
            var newPicture = new NewPictureModel
            {
                TitleBg = picture.TitleBg,
                TitleEn = picture.TitleEn,
                TechnicsBg = picture.TechnicsBg,
                TechnicsEn = picture.TechnicsEn,
                IsSold = picture.IsSold,
                Price = picture.Price,
                Size = picture.Size,
                Path = picture.Path,
                Author = picture.Author
            };

            m_PicturesDataSource.AddNewPicture(newPicture);
        }
    }
}
