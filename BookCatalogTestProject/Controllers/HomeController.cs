using BookCatalogTestProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookCatalogTestProject.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository bookRepository;

        public HomeController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public ActionResult Index()
        {
            var result = bookRepository.Get();

            return View();
        }

        public ActionResult About()
        {
            int[] mas = new int[2];
            mas[6] = 4;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}