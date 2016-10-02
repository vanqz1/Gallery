using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IPicturesEnServices
    {
        List<PicturesEn> GetAllPicturesEn();
        PicturesEn GetByIdPictureEn(int id);
    }
}
