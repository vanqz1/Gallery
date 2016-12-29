using System.Collections.Generic;
using DataSource.DataSourceInterfaces;
using DataSource.Model;
using System.Linq;
using System;

namespace DataSource.DataSource
{
    public class PicturesDataSource : IPicturesDataSource
    {
        public IEnumerable<PictureModel> GetAllPictures(int languageNum)
        {
            Languages language = (Languages)languageNum;
            
            switch (language)
            {
                case Languages.Bulgarian:

                    foreach(var picture in GetAllPicturesBg())
                    {
                        yield return new PictureModel
                        {
                            Id = picture.Id,
                            Title = picture.TitleBg,
                            Technics = picture.TechnicsBg,
                            AuthorName = picture.PicturesAuthor.NameBg,
                            Size = picture.Size,
                            Price = picture.Price,
                            IsSold = picture.IsSold,
                            PicturePath = picture.PicturePath
                        };
                    }
                    break;
                case Languages.English:

                    foreach (var picture in GetAllPicturesEn())
                    {
                        yield return new PictureModel
                        {
                            Id = picture.Id,
                            Title = picture.TitleEn,
                            Technics = picture.TechnicsEn,
                            AuthorName = picture.PicturesAuthor.NameEn,
                            Size = picture.Size,
                            Price = picture.Price,
                            IsSold = picture.IsSold,
                            PicturePath = picture.PicturePath
                        };
                    }
                    break;
            }
        }

        public PictureModel GetByIdPicture(int id, int languageNum)
        {
            Languages language = (Languages)languageNum;

            var thePicture = new PictureModel();

            switch (language)
            {
                case Languages.Bulgarian:

                    var pictureBg = GetByIdPictureBg(id);
                    if (pictureBg == null) return null;

                    thePicture = new PictureModel
                    {
                        Id = pictureBg.Id,
                        Title = pictureBg.TitleBg,
                        Technics = pictureBg.TechnicsBg,
                        AuthorName = pictureBg.PicturesAuthor.NameBg,
                        Size = pictureBg.Size,
                        Price = pictureBg.Price,
                        IsSold = pictureBg.IsSold,
                        PicturePath = pictureBg.PicturePath

                    };
                    break;
                case Languages.English:

                    var pictureEn = GetByIdPictureEn(id);
                    if (pictureEn == null) return null;

                    thePicture = new PictureModel
                    {
                        Id = pictureEn.Id,
                        Title = pictureEn.TitleEn,
                        Technics = pictureEn.TechnicsEn,
                        AuthorName = pictureEn.PicturesAuthor.NameEn,
                        Size = pictureEn.Size,
                        Price = Math.Round(pictureEn.Price * (decimal)0.51129,2),
                        IsSold = pictureEn.IsSold,
                        PicturePath = pictureEn.PicturePath

                    };
                    break;
            }
            return thePicture;
        }

        private IEnumerable<Picture> GetAllPicturesBg()
        {
            using (var contex = new VagabondEntities())
            {
                var pictures = contex.Pictures.ToList();

                foreach (var picture in pictures)
                {
                    yield return new Picture
                    {
                        Id = picture.Id,
                        TitleBg = picture.TitleBg,
                        TechnicsBg = picture.TechnicsBg,
                        Author = picture.Author,
                        Size = picture.Size,
                        Price = picture.Price,
                        PicturesAuthor = picture.PicturesAuthor,
                        IsSold = picture.IsSold,
                        PicturePath = picture.PicturePath
                    };
                }
            }
        }

        private Picture GetByIdPictureBg(int id)
        {
            using (var contex = new VagabondEntities())
            {
                var picture = contex.Pictures.FirstOrDefault(s => s.Id == id);

                if (picture == null) return null;

                return new Picture
                {
                    Id = picture.Id,
                    TitleBg = picture.TitleBg,
                    TechnicsBg = picture.TechnicsBg,
                    Author = picture.Author,
                    Size = picture.Size,
                    Price = picture.Price,
                    PicturesAuthor = picture.PicturesAuthor,
                    IsSold = picture.IsSold,
                    PicturePath = picture.PicturePath
                };
            }
        }

        public void AddNewPicture(NewPictureModel picture)
        {
            using (var contex = new VagabondEntities())
            {
                contex.Pictures.Add(new Picture
                {
                    TitleBg = picture.TitleBg,
                    TitleEn = picture.TitleEn,
                    TechnicsBg = picture.TechnicsBg,
                    TechnicsEn = picture.TechnicsEn,
                    IsSold = picture.IsSold,
                    Price = picture.Price,
                    Size = picture.Size,
                    PicturePath = picture.Path,
                    Author = picture.Author

                });

                contex.SaveChanges();
            }
        }

        private IEnumerable<Picture> GetAllPicturesEn()
        {
            using (var contex = new VagabondEntities())
            {
                var pictures = contex.Pictures.ToList();

                foreach (var picture in pictures)
                {
                    yield return new Picture
                    {
                        Id = picture.Id,
                        TitleEn = picture.TitleEn,
                        TechnicsEn = picture.TechnicsEn,
                        Author = picture.Author,
                        Size = picture.Size,
                        Price = picture.Price,
                        PicturesAuthor = picture.PicturesAuthor,
                        IsSold = picture.IsSold,
                        PicturePath = picture.PicturePath
                    };
                }
            }
        }

        private Picture GetByIdPictureEn(int id)
        {
            var picture = new Picture();
            using (var contex = new VagabondEntities())
            {
                picture = contex.Pictures.FirstOrDefault(s => s.Id == id);
                if (picture == null) return null;
                return new Picture
                {
                    Id = picture.Id,
                    TitleEn = picture.TitleEn,
                    TechnicsEn = picture.TechnicsEn,
                    Author = picture.Author,
                    Size = picture.Size,
                    Price = picture.Price,
                    PicturesAuthor = picture.PicturesAuthor,
                    IsSold = picture.IsSold,
                    PicturePath = picture.PicturePath
                };
            }
        }
    }
}
