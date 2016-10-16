using DataSource.Model;
using System.Collections.Generic;

namespace DataSource.DataSourceInterfaces
{
    public interface IPicturesDataSource
    { 
        IEnumerable<Picture> GetAllPictures(int languageNum);
        Picture GetByIdPicture(int id, int languageNum);
    }
}
