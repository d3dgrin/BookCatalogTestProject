using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.DAL.Entity.Book
{
    public class CreateBookEM
    {
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public int Rating { get; set; }
        public int PagesCount { get; set; }

        public List<int> AuthorIds { get; set; }
    }
}
