using System;
using System.Collections.Generic;
using DataSource.DataSourceInterfaces;
using DataSource.Model;
using System.Linq;

namespace DataSource.DataSource
{
    public class PicturesDataSource : IPicturesDataSource
    {
        public List<Picture> GetAllPictures(int languageNum)
        {
            Languages language = (Languages)languageNum;

            List<Picture> pictures = new List<Picture>();
            switch (language)
            {
                case Languages.Bulgarian:

                    foreach(var picture in GetAllPicturesBg())
                    {
                        pictures.Add(new Picture
                        {
                            Id = picture.Id,
                            Title = picture.Title,
                            Technics = picture.Technics,
                            AuthorName = picture.AuthorsBG.Name,
                            Size = picture.Size,
                            Price = picture.Price,
                            IsSold = picture.IsSold,
                            PicturePath = picture.PicturePath
                        });
                    }
                    break;
                case Languages.English:

                    foreach (var picture in GetAllPicturesEn())
                    {
                        pictures.Add(new Picture
                        {
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
                    break;
            }

            return pictures;
        }

        public Picture GetByIdPicture(int id, int languageNum)
        {
            Languages language = (Languages)languageNum;

            var thePicture = new Picture();

            switch (language)
            {
                case Languages.Bulgarian:

                    var pictureBg = GetByIdPictureBg(id);

                    if (pictureBg == null) return null;

                    thePicture = new Picture
                    {
                        Id = pictureBg.Id,
                        Title = pictureBg.Title,
                        Technics = pictureBg.Technics,
                        AuthorName = pictureBg.AuthorsBG.Name,
                        Size = pictureBg.Size,
                        Price = pictureBg.Price,
                        IsSold = pictureBg.IsSold,
                        PicturePath = pictureBg.PicturePath

                    };
                    break;
                case Languages.English:

                    var pictureEn = GetByIdPictureEn(id);

                    if (pictureEn == null) return null;

                    thePicture = new Picture
                    {
                        Id = pictureEn.Id,
                        Title = pictureEn.Title,
                        Technics = pictureEn.Technics,
                        AuthorName = pictureEn.AuthorsEN.Name,
                        Size = pictureEn.Size,
                        Price = pictureEn.Price,
                        IsSold = pictureEn.IsSold,
                        PicturePath = pictureEn.PicturePath

                    };
                    break;
            }
            return thePicture;
        }

        private List<PicturesBG> GetAllPicturesBg()
        {
            var pictures = new List<PicturesBG>();
            var listOfPictures = new List<PicturesBG>();

            using (var contex = new VagabondEntities())
            {
                pictures = contex.PicturesBGs.ToList();

                foreach (var picture in pictures)
                {
                    listOfPictures.Add(new PicturesBG
                    {
                        Id = picture.Id,
                        Title = picture.Title,
                        Technics = picture.Technics,
                        Author = picture.Author,
                        Size = picture.Size,
                        Price = picture.Price,
                        AuthorsBG = picture.AuthorsBG,
                        IsSold = picture.IsSold,
                        PicturePath = picture.PicturePath
                    });
                }
                return listOfPictures;
            }
        }

        private PicturesBG GetByIdPictureBg(int id)
        {
            PicturesBG picture = new PicturesBG();
            using (var contex = new VagabondEntities())
            {
                picture = contex.PicturesBGs.FirstOrDefault(s => s.Id == id);

                if (picture == null) return null;

                return new PicturesBG
                {
                    Id = picture.Id,
                    Title = picture.Title,
                    Technics = picture.Technics,
                    Author = picture.Author,
                    Size = picture.Size,
                    Price = picture.Price,
                    AuthorsBG = picture.AuthorsBG,
                    IsSold = picture.IsSold,
                    PicturePath = picture.PicturePath
                };
            }
        }

        private List<PicturesEN> GetAllPicturesEn()
        {
            var pictures = new List<PicturesEN>();
            var listOfPictures = new List<PicturesEN>();

            using (var contex = new VagabondEntities())
            {
                pictures = contex.PicturesENs.ToList();

                foreach (var picture in pictures)
                {
                    listOfPictures.Add(new PicturesEN
                    {
                        Id = picture.Id,
                        Title = picture.Title,
                        Technics = picture.Technics,
                        Author = picture.Author,
                        Size = picture.Size,
                        Price = picture.Price,
                        AuthorsEN = picture.AuthorsEN,
                        IsSold = picture.IsSold,
                        PicturePath = picture.PicturePath
                    });
                }
                return listOfPictures;
            }
        }

        private PicturesEN GetByIdPictureEn(int id)
        {
            PicturesEN picture = new PicturesEN();
            using (var contex = new VagabondEntities())
            {
                picture = contex.PicturesENs.FirstOrDefault(s => s.Id == id);
                if (picture == null) return null;
                return new PicturesEN
                {
                    Id = picture.Id,
                    Title = picture.Title,
                    Technics = picture.Technics,
                    Author = picture.Author,
                    Size = picture.Size,
                    Price = picture.Price,
                    AuthorsEN = picture.AuthorsEN,
                    IsSold = picture.IsSold,
                    PicturePath = picture.PicturePath
                };
            }
        }
    }
}
