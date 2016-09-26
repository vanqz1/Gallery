
using System.Collections.Generic;

namespace DataSource.DataSourceInterfaces
{
    public interface IPicturesBgDataSource
    {
        void AddNewPictureBG(PicturesBG picture);
        List<PicturesBG> GetAllPicturesBG();
        PicturesBG GetByIdPictureBG(int id);

    }
}
