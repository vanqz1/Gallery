using Repository.Repository;
using Repository.RepositoryInterfaces;
using System.Collections.Generic;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class PicturesBgServices : IPicturesBgServices
    {
        private readonly IPicturesBgRepository m_PicturesBgModel;
        
        public PicturesBgServices(IPicturesBgRepository picturesBgModel)
        {
            m_PicturesBgModel = picturesBgModel;
        }

        public PicturesBg GetByIdPictureBg(int id)
        {
            var picture = m_PicturesBgModel.GetByIdPictureBg(id);

            if (picture == null) return null;

            return new PicturesBg
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

        public List<PicturesBg> GetAllPicturesBg()
        {
            var pictures = m_PicturesBgModel.GetAllPicturesBg();
            var listOfPictures = new List<PicturesBg>();

            foreach (var picture in pictures)
            {
                listOfPictures.Add(new PicturesBg
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
    }
}
