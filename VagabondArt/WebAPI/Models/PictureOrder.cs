using System.Collections.Generic;

namespace WebAPI.Models
{
    public class PictureOrder
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int[] Products { get; set; }
        public string Comment { get; set; }
    }
}