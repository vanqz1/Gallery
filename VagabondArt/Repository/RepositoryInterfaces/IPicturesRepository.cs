using Repository.RepositoryModels;
using System.Collections.Generic;

namespace Repository.RepositoryInterfaces
{
    public interface IPicturesRepository
    {
        IEnumerable<PicturesModelRepository> GetAllPictures(int languageNum);
        PicturesModelRepository GetByIdPicture(int id, int languageNum);
        void AddNewPicture(NewPictureRepositoryModel picture);
    }
}
