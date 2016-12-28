using DataSource.DataSourceInterfaces;
using DataSource.Model;
using System.Linq;

namespace DataSource.DataSource
{
    public class AuthorDataSource : IAuthorDataSource
    {
        public AuthorModel GetAuthorByName(string nameEn, string nameBg)
        {
            using (var contex = new VagabondEntities())
            {
                var author = contex.Authors.FirstOrDefault(s => s.NameBg == nameBg && s.NameEn == s.NameEn);

                if (author != null)
                {
                    return new AuthorModel
                    {
                        Id = author.Id,
                        NameBg = author.NameBg,
                        NameEn = author.NameEn
                    };
                }
            }

            return null;
        }

        public void AddNewAuthor(string nameEn, string nameBg)
        {
            using (var contex = new VagabondEntities())
            {
                var author = contex.Authors.Add(new Author {
                    NameBg = nameBg,
                    NameEn = nameEn
                });

                contex.SaveChanges();

            }
        }
    }
}
