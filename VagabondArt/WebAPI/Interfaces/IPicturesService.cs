﻿using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IPicturesService
    {
        IEnumerable<Picture> GetAllPictures(EnumLanguages language);
        Picture GetByIdPicture(int id, EnumLanguages language);
        void SavePicturePhoto(NewPicture picture);
    }
}
