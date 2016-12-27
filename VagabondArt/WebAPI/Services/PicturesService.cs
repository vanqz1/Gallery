using Repository.RepositoryInterfaces;
using Repository.RepositoryModels;
using System.Collections.Generic;
using System.Web;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class PicturesService : IPicturesService
    {
        private readonly IPicturesRepository m_PicturesRepository;

        public PicturesService(IPicturesRepository picturesRepository)
        {
            m_PicturesRepository = picturesRepository;
        }

        public IEnumerable<Picture> GetAllPictures(EnumLanguages language)
        {
            var numLanguage = (int)language;

            var pictures = m_PicturesRepository.GetAllPictures(numLanguage);

            foreach (var picture in pictures)
            {
                yield return new Picture
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
        }

        public Picture GetByIdPicture(int id, EnumLanguages language)
        {
            var numLanguage = (int)language;

            var picture = m_PicturesRepository.GetByIdPicture(id, numLanguage);

            if (picture == null) return null;

            return new Picture
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


        public void SavePicturePhoto(NewPicture picture)
        {
            var fileName = picture.PicturePhoto.FileName;
            
            var TempFileName = "C:/Users/vanqz/Desktop/Project/Gallery/VagabondArt/WebAPI/Pictures/" + fileName;

            picture.PicturePhoto.SaveAs(TempFileName);

            var newPicture = new NewPictureRepositoryModel
            {
                TitleBg = picture.TitleBg,
                TitleEn = picture.TitleEn,
                TechnicsBg = picture.TechnicsBg,
                TechnicsEn = picture.TechnicsEn,
                IsSold = picture.IsSold,
                Price = picture.Price,
                Size = picture.Size,
                Path = TempFileName,
                Author = 1
            };

            m_PicturesRepository.AddNewPicture(newPicture);
        }
    }
}