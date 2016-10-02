using Repository.RepositoryInterfaces;
using System.Collections.Generic;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class PicturesEnServices : IPicturesEnServices
    {
        private readonly IPicturesEnRepository m_PicturesEnModel;
        
        public PicturesEnServices(IPicturesEnRepository picturesEnModel)
        {
            m_PicturesEnModel = picturesEnModel;
        }
        public PicturesEn GetByIdPictureEn(int id)
        {
            var picture = m_PicturesEnModel.GetByIdPictureEn(id);

            if (picture == null) return null;

            return new PicturesEn
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

        public List<PicturesEn> GetAllPicturesEn()
        {
            var pictures = m_PicturesEnModel.GetAllPicturesEn();
            var listOfPictures = new List<PicturesEn>();

            foreach (var picture in pictures)
            {
                listOfPictures.Add(new PicturesEn {
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
