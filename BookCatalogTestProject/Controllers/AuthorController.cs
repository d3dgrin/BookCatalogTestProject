using BookCatalogTestProject.Infrastructure.Business;
using BookCatalogTestProject.Serialization;
using BookCatalogTestProject.ViewModel.Author;
using BookCatalogTestProject.ViewModel.Datatable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookCatalogTestProject.Controllers
{
    public class AuthorController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetAuthors(BaseDataTableFilterVM filter)
        {
            using (var domain = Factory.GetService<IAuthorDM>(RequestContext))
            {
                var result = domain.GetAuthors();

                return new JsonNetResult()
                {
                    Data = new
                    {
                        data = result,
                        draw = filter.Draw,
                        recordsTotal = 11,
                        recordsFiltered = 11
                    },
                    Formatting = Newtonsoft.Json.Formatting.Indented
                };

                //return Success(result);
            }
        }

        public JsonResult CreateAuthor(AuthorVM model)
        {
            using (var domain = Factory.GetService<IAuthorDM>(RequestContext))
            {
                var result = domain.CreateAuthor(model);

                return Success(result);
            }
        }

        public JsonResult UpdateAuthor(AuthorVM model)
        {
            using (var domain = Factory.GetService<IAuthorDM>(RequestContext))
            {
                domain.UpdateAuthor(model);

                return Success();
            }
        }

        public JsonResult DeleteAuthor(int id)
        {
            using (var domain = Factory.GetService<IAuthorDM>(RequestContext))
            {
                domain.DeleteAuthor(id);

                return Success();
            }
        }
    }
}