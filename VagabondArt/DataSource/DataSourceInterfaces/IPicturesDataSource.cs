using DataSource.Model;
using System.Collections.Generic;

namespace DataSource.DataSourceInterfaces
{
    public interface IPicturesDataSource
    { 
        List<Picture> GetAllPictures(int languageNum);
        Picture GetByIdPicture(int id, int languageNum);
    }
}
