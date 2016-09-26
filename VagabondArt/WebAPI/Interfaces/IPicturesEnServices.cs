using System.Collections.Generic;
using WebAPI.Models;

namespace Repository.RepositoryInterfaces
{
    public interface IPicturesEnServices
    {
        List<PicturesEn> GetAllPicturesEn();
        PicturesEn GetByIdPictureEn(int id);
    }
}
