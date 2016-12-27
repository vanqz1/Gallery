using DataSource.Model;
using System.Collections.Generic;

namespace DataSource.DataSourceInterfaces
{
    public interface IPicturesDataSource
    { 
        IEnumerable<PictureModel> GetAllPictures(int languageNum);
        PictureModel GetByIdPicture(int id, int languageNum);
        void AddNewPicture(NewPictureModel picture);
    }
}
