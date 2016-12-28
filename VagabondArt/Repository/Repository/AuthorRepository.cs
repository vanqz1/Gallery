using Repository.RepositoryInterfaces;
using Repository.RepositoryModels;
using DataSource.DataSourceInterfaces;

namespace Repository.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IAuthorDataSource m_AuthorDataSource;

        public AuthorRepository(IAuthorDataSource authorDataSource)
        {
            m_AuthorDataSource = authorDataSource;
        }

        public AuthorRepositoryModel GetAuthorByName(string nameEn, string nameBg)
        {
            var author = m_AuthorDataSource.GetAuthorByName(nameEn, nameBg);

            if (author != null)
            {
                return new AuthorRepositoryModel
                {
                    Id = author.Id,
                    NameBg = author.NameBg,
                    NameEn = author.NameEn
                };
            }

            return null;
        }

        public void AddNewAuthor(string nameEn, string nameBg)
        {
            m_AuthorDataSource.AddNewAuthor(nameEn, nameBg);
        }
    }
}
