using Repository.RepositoryInterfaces;

namespace Repository.Repository
{
    public class PicturesBgModelRepository : IPictures
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Technics { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public string AuthorName { get; set; }
    }
}
