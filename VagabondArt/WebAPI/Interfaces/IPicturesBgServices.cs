using Repository.Repository;
using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IPicturesBgServices
    {
        List<PicturesBg> GetAllPicturesBg();
        PicturesBg GetByIdPictureBg(int id);
    }
}
