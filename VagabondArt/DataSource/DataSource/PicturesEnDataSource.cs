using DataSource.DataSourceInterfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataSource.DataSource
{
    public class PicturesEnDataSource : IPicturesEnDataSource
    {
        public void AddNewPictureEN(PicturesEN picture)
        {
            using (var contex = new VagabondEntities())
            {
                contex.PicturesENs.Add(picture);
                contex.SaveChanges();
            }
        }

        public List<PicturesEN> GetAllPicturesEN()
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

        public PicturesEN GetByIdPictureEN(int id)
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
