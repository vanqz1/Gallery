using Repository.RepositoryInterfaces;
using Repository.RepositoryModels;
using System;
using System.Collections.Generic;
using Services.Interfaces;
using Services.Models;

namespace Services.Services
{
    public class PicturesService : IPicturesService
    {
        private readonly IPicturesRepository m_PicturesRepository;
        private readonly IAuthorRepository m_AuthorRepository;

        public PicturesService(IPicturesRepository picturesRepository,
                               IAuthorRepository authorRepository)
        {
            m_PicturesRepository = picturesRepository;
            m_AuthorRepository = authorRepository;
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


        public void AddNewPicture(NewPicture picture)
        {
            var fileName = Guid.NewGuid() + picture.PicturePhoto.FileName;

            var TempFileName = "C:/Users/vanqz/Desktop/Project/Gallery/VagabondArt/WebAPI/Pictures/" + fileName ;

            picture.PicturePhoto.SaveAs(TempFileName);

            var author = m_AuthorRepository.GetAuthorByName(picture.AuthorNameEn, picture.AuthorNameBg);
            var authorId = author != null ? author.Id : 0;

            if (author == null)
            {
                m_AuthorRepository.AddNewAuthor(picture.AuthorNameEn, picture.AuthorNameBg);
                authorId = m_AuthorRepository.GetAuthorByName(picture.AuthorNameEn, picture.AuthorNameBg).Id;
            }

            var newPicture = new NewPictureRepositoryModel
            {
                TitleBg = picture.TitleBg,
                TitleEn = picture.TitleEn,
                TechnicsBg = picture.TechnicsBg,
                TechnicsEn = picture.TechnicsEn,
                IsSold = picture.IsSold,
                Price = picture.Price,
                Size = picture.Size,
                Path = fileName,
                Author = authorId
            };

            m_PicturesRepository.AddNewPicture(newPicture);
        }
    }
}