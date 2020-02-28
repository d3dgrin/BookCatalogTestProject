using BookCatalogTestProject.ViewModel;
using BookCatalogTestProject.ViewModel.Book;
using BookCatalogTestProject.ViewModel.Datatable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.Infrastructure.Business
{
    public interface IBookDM : IDisposable
    {
        IEnumerable<BookVM> GetBooks(BaseDataTableFilterVM filter, out int totalFiltered);
        BookVM GetBook(int id);
        void CreateBook(CreateBookVM model);
        void UpdateBook(CreateBookVM model);
        void DeleteBook(int id);
    }
}
