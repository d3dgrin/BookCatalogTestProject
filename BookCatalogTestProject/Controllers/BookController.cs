using BookCatalogTestProject.Infrastructure.Business;
using BookCatalogTestProject.ViewModel.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookCatalogTestProject.Controllers
{
    public class BookController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetBooks()
        {
            using (var bookDm = Factory.GetService<IBookDM>(RequestContext))
            {
                var books = bookDm.GetBooks();

                return Success(books);
            }
        }

        public JsonResult CreateBook(CreateBookVM model)
        {
            using (var bookDm = Factory.GetService<IBookDM>(RequestContext))
            {
                bookDm.CreateBook(model);

                return Success();
            }
        }

        public JsonResult DeleteBook(int id)
        {
            using (var bookDm = Factory.GetService<IBookDM>(RequestContext))
            {
                bookDm.DeleteBook(id);

                return Success();
            }
        }
    }
}