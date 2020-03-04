using BookCatalogTestProject.DAL.Entity;
using BookCatalogTestProject.DAL.Entity.Book;
using BookCatalogTestProject.DAL.Entity.Datatable;
using BookCatalogTestProject.Infrastructure;
using BookCatalogTestProject.Infrastructure.Business;
using BookCatalogTestProject.Infrastructure.Data;
using BookCatalogTestProject.ViewModel;
using BookCatalogTestProject.ViewModel.Book;
using BookCatalogTestProject.ViewModel.Datatable;
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

        public IEnumerable<BookVM> GetBooks(BaseDataTableFilterVM filter, out int totalFiltered)
        {
            using (var repo = Factory.GetService<IBookRepository>(DataContext))
            {
                var filterEM = entService.ConvertTo<BaseDataTableFilterVM, BaseDataTableFilterEM>(filter);

                var listEM = repo.GetBooks(filterEM, out totalFiltered);

                foreach (var item in listEM)
                {
                    item.SelectedAuthors = item.Authors.Select(a => a.AuthorId).ToList();
                }

                var listVM = entService.ConvertTo<IEnumerable<BookEM>, IEnumerable<BookVM>>(listEM);

                return listVM;
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

        public void UpdateBook(CreateBookVM model)
        {
            using (var repo = Factory.GetService<IBookRepository>(DataContext))
            {
                var createBookEM = entService.ConvertTo<CreateBookVM, CreateBookEM>(model);
                repo.UpdateBook(createBookEM);
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
