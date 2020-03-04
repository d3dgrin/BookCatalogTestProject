using BookCatalogTestProject.Context;
using BookCatalogTestProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BookCatalogTestProject.Controllers
{
    public class BaseController : Controller
    {
        private readonly object _mutex = new object();
        private IServiceProviderFactory _modelFactory = default(IServiceProviderFactory);
        private DefaultContext _context = default(DefaultContext);

        public BaseController()
        {
            
        }

        public IRequestContext RequestContext
        {
            get
            {
                lock (this._mutex)
                {
                    if (this._context == null)
                    {
                        this._context = new DefaultContext();
                    }
                }

                return this._context;
            }
        }

        protected IServiceProviderFactory Factory
        {
            get
            {
                lock (this._mutex)
                {
                    if (this._modelFactory == null)
                    {
                        this._modelFactory = this.RequestContext.Factory;
                    }

                    return this._modelFactory;
                }
            }
        }

        protected JsonResult JsonResponse(object model = null, bool isSuccess = true)
        {
            return new JsonResult()
            {
                ContentEncoding = Encoding.UTF8,
                ContentType = "application/json",
                Data = new { IsSuccess = isSuccess, Model = model },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}