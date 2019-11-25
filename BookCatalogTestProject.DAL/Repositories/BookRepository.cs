using BookCatalogTestProject.DAL.Entity;
using BookCatalogTestProject.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.DAL.Repositories
{
    public class BookRepository : RepositoryBase<BookEM, int>, IBookRepository
    {
        public BookRepository(IDataContext context) : base(context)
        {

        }
    }
}
