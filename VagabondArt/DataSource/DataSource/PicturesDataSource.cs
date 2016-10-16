using System.Collections.Generic;
using DataSource.DataSourceInterfaces;
using DataSource.Model;
using System.Linq;

namespace DataSource.DataSource
{
    public class PicturesDataSource : IPicturesDataSource
    {
        public IEnumerable<Picture> GetAllPictures(int languageNum)
        {
            Languages language = (Languages)languageNum;
            
            switch (language)
            {
                case Languages.Bulgarian:

                    foreach(var picture in GetAllPicturesBg())
                    {
                        yield return new Picture
                        {
                            Id = picture.Id,
                            Title = picture.Title,
                            Technics = picture.Technics,
                            AuthorName = picture.AuthorsBG.Name,
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
                        yield return new Picture
                        {
                            Id = picture.Id,
                            Title = picture.Title,
                            Technics = picture.Technics,
                            AuthorName = picture.AuthorsEN.Name,
                            Size = picture.Size,
                            Price = picture.Price,
                            IsSold = picture.IsSold,
                            PicturePath = picture.PicturePath
                        };
                    }
                    break;
            }
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

        private IEnumerable<PicturesBG> GetAllPicturesBg()
        {
            using (var contex = new VagabondEntities())
            {
                var pictures = contex.PicturesBGs.ToList();

                foreach (var picture in pictures)
                {
                    yield return new PicturesBG
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
        }

        private PicturesBG GetByIdPictureBg(int id)
        {
            using (var contex = new VagabondEntities())
            {
                var picture = contex.PicturesBGs.FirstOrDefault(s => s.Id == id);

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

        private IEnumerable<PicturesEN> GetAllPicturesEn()
        {
            using (var contex = new VagabondEntities())
            {
                var pictures = contex.PicturesENs.ToList();

                foreach (var picture in pictures)
                {
                    yield return new PicturesEN
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
