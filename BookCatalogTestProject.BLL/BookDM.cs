using BookCatalogTestProject.DAL.Entity;
using BookCatalogTestProject.Infrastructure;
using BookCatalogTestProject.Infrastructure.Business;
using BookCatalogTestProject.Infrastructure.Data;
using BookCatalogTestProject.ViewModel;
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
    }
}
