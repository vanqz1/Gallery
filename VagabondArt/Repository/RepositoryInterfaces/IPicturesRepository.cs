using Repository.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryInterfaces
{
    public interface IPicturesRepository
    {
        List<PicturesModelRepository> GetAllPictures(int languageNum);
        PicturesModelRepository GetByIdPicture(int id, int languageNum);
    }
}
