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

        public ActionResult Index2()
        {
            return View();
        }

        public JsonResult GetBooks()
        {
            using (var domain = Factory.GetService<IBookDM>(RequestContext))
            {
                var result = domain.GetBooks();

                return Success(result);
            }
        }

        public JsonResult CreateBook(CreateBookVM model)
        {
            using (var domain = Factory.GetService<IBookDM>(RequestContext))
            {
                domain.CreateBook(model);

                return Success();
            }
        }

        public JsonResult UpdateBook(CreateBookVM model)
        {
            using (var domain = Factory.GetService<IBookDM>(RequestContext))
            {
                domain.UpdateBook(model);

                return Success();
            }
        }

        public JsonResult DeleteBook(int id)
        {
            using (var domain = Factory.GetService<IBookDM>(RequestContext))
            {
                domain.DeleteBook(id);

                return Success();
            }
        }
    }
}