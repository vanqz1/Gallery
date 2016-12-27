using System.ComponentModel.DataAnnotations;
using System.Web;

namespace WebAPI.Models
{
    public class NewPicture
    {
        [Required(ErrorMessage = "Bg title of the picture is required")]
        public string TitleBg { get; set; }

        [Required(ErrorMessage = "En title of the picture is required")]
        public string TitleEn { get; set; }

        [Required(ErrorMessage = "Bg technic of the picture is required")]
        public string TechnicsBg { get; set; }

        [Required(ErrorMessage = "En technic of the picture is required")]
        public string TechnicsEn { get; set; }

        [Required(ErrorMessage = "Size of the picture is required")]
        public string Size { get; set; }

        [Required(ErrorMessage = "Price the of the picture is required")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Bg name of the author is required")]
        public string AuthorNameBg { get; set; }

        [Required(ErrorMessage = "En name of author is required")]
        public string AuthorNameEn { get; set; }

        [Required(ErrorMessage = "Photo of the picture is requered")]
        public HttpPostedFile PicturePhoto { get; set; }

        [Required(ErrorMessage = "Is sold field is requered")]
        public bool IsSold { get; set; }
    }
}