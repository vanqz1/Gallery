namespace DataSource.Model
{
    public class PictureModel
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
