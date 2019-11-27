using BookCatalogTestProject.DAL.Entity;
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
    }
}
