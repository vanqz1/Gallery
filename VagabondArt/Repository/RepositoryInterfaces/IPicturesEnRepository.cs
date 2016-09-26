using Repository.Repository;
using System.Collections.Generic;

namespace Repository.RepositoryInterfaces
{
    public interface IPicturesEnRepository
    {
        List<PicturesEnModelRepository> GetAllPicturesEn();
        PicturesEnModelRepository GetByIdPictureEn(int id);
    }
}
