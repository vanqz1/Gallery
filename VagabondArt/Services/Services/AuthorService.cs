using Repository.RepositoryInterfaces;
using Services.Interfaces;
using Services.Models;

namespace Services.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository m_AuthorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            m_AuthorRepository = authorRepository;
        }

        public Author GetAuthorByName(string nameEn,string nameBg)
        {
            var author = m_AuthorRepository.GetAuthorByName(nameEn, nameBg);

            if (author != null)
            {
                return new Author
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
            m_AuthorRepository.AddNewAuthor(nameEn, nameBg);
        }
    }
}