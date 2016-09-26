using DataSource.DataSourceInterfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataSource
{
    public class PicturesBgDataSource : IPicturesBgDataSource
    {
        public void AddNewPictureBG(PicturesBG picture)
        {
            using (var contex = new VagabondEntities())
            {
                contex.PicturesBGs.Add(picture);
                contex.SaveChanges();
            }
        }

        public List<PicturesBG> GetAllPicturesBG()
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
                        AuthorsBG = picture.AuthorsBG
                    });
                }
                return listOfPictures;
            }
        }
        
        public PicturesBG GetByIdPictureBG(int id)
        {
            PicturesBG picture = new PicturesBG();
            using (var contex = new VagabondEntities())
            {
                picture = contex.PicturesBGs.FirstOrDefault(s => s.Id == id);

                if (picture == null) return null;

                return new PicturesBG {
                    Id = picture.Id,
                    Title = picture.Title,
                    Technics = picture.Technics,
                    Author = picture.Author,
                    Size = picture.Size,
                    Price = picture.Price,
                    AuthorsBG = picture.AuthorsBG
                };
            }  
        }
    }
}
