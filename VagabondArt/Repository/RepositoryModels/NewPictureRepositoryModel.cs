
namespace Repository.RepositoryModels
{
    public class NewPictureRepositoryModel
    {
            public string TitleBg { get; set; }
            public string TitleEn { get; set; }
            public string TechnicsBg { get; set; }
            public string TechnicsEn { get; set; }
            public string Size { get; set; }
            public decimal Price { get; set; }
            public string AuthorNameBg { get; set; }
            public string AuthorNameEn { get; set; }
            public int Author { get; set; }
            public string Path { get; set; }
            public bool IsSold { get; set; }
    }
}
