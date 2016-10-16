﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryModels
{
    public class PicturesModelRepository
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Technics { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public string AuthorName { get; set; }
        public string PicturePath { get; set; }
        public bool IsSold { get; set; }
    }
}