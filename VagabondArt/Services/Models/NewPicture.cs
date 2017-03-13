using System.Web;

namespace Services.Models
{
    public class NewPicture
    {
        public string TitleBg { get; set; }
        
        public string TitleEn { get; set; }
        
        public string TechnicsBg { get; set; }
        
        public string TechnicsEn { get; set; }
        
        public string Size { get; set; }
        
        public decimal Price { get; set; }
        
        public string AuthorNameBg { get; set; }
        
        public string AuthorNameEn { get; set; }
        
        public HttpPostedFile PicturePhoto { get; set; }
        
        public bool IsSold { get; set; }
    }
}