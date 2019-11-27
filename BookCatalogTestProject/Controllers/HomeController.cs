using BookCatalogTestProject.Infrastructure.Business;
using BookCatalogTestProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookCatalogTestProject.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //using (var bookDm = Factory.GetService<IBookDM>(RequestContext))
            //{
            //    var books = bookDm.GetBooks();

            //    return View(books);
            //}

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult GetBooks()
        {
            var books = new List<BookVM>()
            {
                new BookVM() {Id = 1, Title = "Title 1", Rating = 8},
                new BookVM() {Id = 2, Title = "Title 2", Rating = 5},
                new BookVM() {Id = 3, Title = "Title 3", Rating = 9},
            };

            return Json(books, JsonRequestBehavior.AllowGet);
        }
    }
}