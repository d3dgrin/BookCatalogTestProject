using BookCatalogTestProject.Infrastructure.Business;
using BookCatalogTestProject.Serialization;
using BookCatalogTestProject.ViewModel.Book;
using BookCatalogTestProject.ViewModel.Datatable;
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

        [HttpPost]
        public ActionResult GetBooks(BaseDataTableFilterVM filter)
        {
            using (var domain = Factory.GetService<IBookDM>(RequestContext))
            {
                var result = domain.GetBooks(filter, out int totalFiltered);

                return new JsonNetResult()
                {
                    Data = new
                    {
                        data = result,
                        draw = filter.Draw,
                        recordsTotal = totalFiltered,
                        recordsFiltered = totalFiltered
                    },
                    Formatting = Newtonsoft.Json.Formatting.Indented
                };
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