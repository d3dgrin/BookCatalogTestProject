using BookCatalogTestProject.Infrastructure.Business;
using BookCatalogTestProject.ViewModel.Author;
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

        public JsonResult GetAuthors()
        {
            using (var domain = Factory.GetService<IAuthorDM>(RequestContext))
            {
                var result = domain.GetAuthors();

                return Success(result);
            }
        }

        public JsonResult CreateAuthor(AuthorVM model)
        {
            using (var domain = Factory.GetService<IAuthorDM>(RequestContext))
            {
                domain.CreateAuthor(model);

                return Success();
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