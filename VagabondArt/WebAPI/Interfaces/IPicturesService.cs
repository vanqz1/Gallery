using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IPicturesService
    {
        List<Picture> GetAllPictures(EnumLanguages language);
        Picture GetByIdPicture(int id, EnumLanguages language);
    }
}
