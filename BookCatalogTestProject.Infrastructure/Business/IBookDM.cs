using BookCatalogTestProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.Infrastructure.Business
{
    public interface IBookDM : IDisposable
    {
        IEnumerable<BookVM> GetBooks();
        BookVM GetBook(int id);
    }
}
