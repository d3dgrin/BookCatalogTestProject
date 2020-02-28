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
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //public JsonResult GetBooks()
        //{
        //    using (var bookDm = Factory.GetService<IBookDM>(RequestContext))
        //    {
        //        var books = bookDm.GetBooks();

        //        return Json(new { data = books }, JsonRequestBehavior.AllowGet);
        //    }
        //}
    }
}