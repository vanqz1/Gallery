using System.Collections.Generic;

namespace DataSource.DataSourceInterfaces
{
    public interface IPicturesEnDataSource
    {
        void AddNewPictureEN(PicturesEN picture);
        List<PicturesEN> GetAllPicturesEN();
        PicturesEN GetByIdPictureEN(int id);
    }
}
