using Repository.Repository;
using System.Collections.Generic;

namespace Repository.RepositoryInterfaces
{
    public interface IPicturesBgRepository
    {
        List<PicturesBgModelRepository> GetAllPicturesBg();
        PicturesBgModelRepository GetByIdPictureBg(int id);
    }
}
