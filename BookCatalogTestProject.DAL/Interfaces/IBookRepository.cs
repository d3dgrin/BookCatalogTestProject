using BookCatalogTestProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.DAL.Interfaces
{
    public interface IBookRepository : IRepository<BookEM, int>
    {
    }
}
