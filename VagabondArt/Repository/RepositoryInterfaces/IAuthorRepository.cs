using Repository.RepositoryModels;

namespace Repository.RepositoryInterfaces
{
    public interface IAuthorRepository
    {
        AuthorRepositoryModel GetAuthorByName(string nameEn, string nameBg);
        void AddNewAuthor(string nameEn, string nameBg);
    }
}
