using BookCatalogTestProject.ViewModel.Author;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.ViewModel.Book
{
    public class CreateBookVM
    {
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime PublicationDate { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public int PagesCount { get; set; }

        public List<int> AuthorIds { get; set; }
    }
}
