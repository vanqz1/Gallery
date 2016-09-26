using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryInterfaces
{
    public interface IPictures
    {
        int Id { get; set; }
        string Title { get; set; }
        string Technics { get; set; }
        string Size { get; set; }
        decimal Price { get; set; }
        string AuthorName { get; set; }
    }
}
