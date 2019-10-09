using BookCatalogTestProject.Data.Entity;
using BookCatalogTestProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        public void Create(BookEM item)
        {
            throw new NotImplementedException();
        }

        public void Delete(BookEM item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookEM> Get()
        {
            return new List<BookEM>();
        }

        public BookEM Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(BookEM item)
        {
            throw new NotImplementedException();
        }
    }
}
