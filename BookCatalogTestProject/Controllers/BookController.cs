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
    }
}