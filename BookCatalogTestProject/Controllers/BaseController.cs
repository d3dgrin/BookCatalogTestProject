using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookCatalogTestProject.Controllers
{
    public class BaseController : Controller
    {
        private const string CONNECTION_KEY = "DefaultConnection";
        public string ConnectionString { get; }

        public BaseController()
        {
            this.ConnectionString = ConfigurationManager.ConnectionStrings[CONNECTION_KEY].ToString();
        }
    }
}