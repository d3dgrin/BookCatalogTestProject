using Dapper.Contrib.Extensions;
using System;

namespace BookCatalogTestProject.DAL.Entity
{
    [Table("Book")]
    public class BookEM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public int Rating { get; set; }
        public int PagesCount { get; set; }
    }
}
