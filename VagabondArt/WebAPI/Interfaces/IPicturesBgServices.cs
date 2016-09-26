using Repository.Repository;
using System.Collections.Generic;
using WebAPI.Models;

namespace Repository.RepositoryInterfaces
{
    public interface IPicturesBg
    {
        List<PicturesBg> GetAllPicturesBg();
        PicturesBg GetByIdPictureBg(int id);
    }
}
