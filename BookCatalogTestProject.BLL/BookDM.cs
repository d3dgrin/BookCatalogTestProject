using BookCatalogTestProject.DAL.Entity;
using BookCatalogTestProject.DAL.Entity.Book;
using BookCatalogTestProject.Infrastructure;
using BookCatalogTestProject.Infrastructure.Business;
using BookCatalogTestProject.Infrastructure.Data;
using BookCatalogTestProject.ViewModel;
using BookCatalogTestProject.ViewModel.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.BLL
{
    public class BookDM : BusinessContextBase, IBookDM
    {
        public BookDM(IRequestContext requestContext) : base(requestContext)
        {

        }

        public IEnumerable<BookVM> GetBooks()
        {
            using (var repo = Factory.GetService<IBookRepository>(DataContext))
            {
                var booksEM = repo.GetBooks();
                var booksVM = entService.ConvertTo<IEnumerable<BookEM>, IEnumerable<BookVM>>(booksEM);
                return booksVM;
            }
        }

        public BookVM GetBook(int id)
        {
            using (var repo = Factory.GetService<IBookRepository>(DataContext))
            {
                var bookEM = repo.GetBook(id);
                var bookVM = entService.ConvertTo<BookEM, BookVM>(bookEM);
                return bookVM;
            }
        }

        public void CreateBook(CreateBookVM model)
        {
            using (var repo = Factory.GetService<IBookRepository>(DataContext))
            {
                var createBookEM = entService.ConvertTo<CreateBookVM, CreateBookEM>(model);
                repo.CreateBook(createBookEM);
            }
        }

        public void DeleteBook(int id)
        {
            using (var repo = Factory.GetService<IBookRepository>(DataContext))
            {
                repo.DeleteBook(id);
            }
        }
    }
}
