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
                var result = domain.GetAuthors(filter, out int totalFiltered);

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

        public JsonResult GetAuthorsWithoutFilter()
        {
            using (var domain = Factory.GetService<IAuthorDM>(RequestContext))
            {
                var result = domain.GetAuthorsWithoutFilter();

                return JsonResponse(result);
            }
        }

        public JsonResult CreateAuthor(AuthorVM model)
        {
            if (ModelState.IsValid)
            {
                using (var domain = Factory.GetService<IAuthorDM>(RequestContext))
                {
                    var result = domain.CreateAuthor(model);

                    return JsonResponse(result);
                }
            }
            return JsonResponse(isSuccess: false);
        }

        public JsonResult UpdateAuthor(AuthorVM model)
        {
            if (ModelState.IsValid)
            {
                using (var domain = Factory.GetService<IAuthorDM>(RequestContext))
                {
                    domain.UpdateAuthor(model);

                    return JsonResponse();
                }
            }
            return JsonResponse(isSuccess: false);
        }

        public JsonResult DeleteAuthor(int id)
        {
            using (var domain = Factory.GetService<IAuthorDM>(RequestContext))
            {
                domain.DeleteAuthor(id);

                return JsonResponse();
            }
        }
    }
}