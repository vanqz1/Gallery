using DataSource.DataSourceInterfaces;
using System.Collections.Generic;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class PicturesService : IPicturesService
    {
        private readonly IPicturesDataSource m_PicturesRepository;

        public PicturesService(IPicturesDataSource picturesRepository)
        {
            m_PicturesRepository = picturesRepository;
        }

        public List<Picture> GetAllPictures(EnumLanguages language)
        {
            var numLanguage = (int)language;

            var pictures = m_PicturesRepository.GetAllPictures(numLanguage);
            var listOfPictures = new List<Picture>();

            foreach (var picture in pictures)
            {
                listOfPictures.Add(new Picture
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
            return listOfPictures;
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
    }
}