using BookCatalogTestProject.DAL.Entity;
using BookCatalogTestProject.DAL.Entity.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.Infrastructure.Data
{
    public interface IBookRepository : IRepository<BookEM, int>
    {
        IEnumerable<BookEM> GetBooks();
        BookEM GetBook(int id);
        void CreateBook(CreateBookEM model);
        void UpdateBook(CreateBookEM model);
        void DeleteBook(int id);
    }
}
