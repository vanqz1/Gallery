using System.Collections.Generic;
using Services.Models;

namespace Services.Interfaces
{
    public interface IPicturesService
    {
        IEnumerable<Picture> GetAllPictures(EnumLanguages language);
        Picture GetByIdPicture(int id, EnumLanguages language);
        void AddNewPicture(NewPicture picture);
    }
}
