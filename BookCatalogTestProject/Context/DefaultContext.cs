using BookCatalogTestProject.Infrastructure;
using BookCatalogTestProject.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BookCatalogTestProject.Context
{
    public class DefaultContext : HttpContextBase, IRequestContext
    {
        private const string CONNECTION_KEY = "DefaultConnection";

        public IServiceProviderFactory Factory { get; set; }
        public IDataContext DataContext { get; private set; }

        public DefaultContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings[CONNECTION_KEY].ToString();
            this.DataContext = this.Factory.GetService<IDataContext>(connectionString);
        }
    }
}