using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IAuthorService
    {
        Author GetAuthorByName(string nameEn, string nameBg);
        void AddNewAuthor(string nameEn, string nameBg);
    }
}