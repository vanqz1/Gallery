using DataSource.Model;

namespace DataSource.DataSourceInterfaces
{
    public interface IAuthorDataSource
    {
        AuthorModel GetAuthorByName(string nameEn, string nameBg);
        void AddNewAuthor(string nameEn, string nameBg);
    }
}
