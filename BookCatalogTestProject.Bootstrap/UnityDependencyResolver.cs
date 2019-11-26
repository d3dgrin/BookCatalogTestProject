using BookCatalogTestProject.BLL;
using BookCatalogTestProject.DAL.Context;
using BookCatalogTestProject.DAL.Repositories;
using BookCatalogTestProject.Infrastructure;
using BookCatalogTestProject.Infrastructure.Business;
using BookCatalogTestProject.Infrastructure.Data;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.Bootstrap
{
    public class UnityDependencyResolver
    {
        protected static IUnityContainer container;

        public static void RegisterTypes(IUnityContainer _container)
        {
            container = _container;

            container.RegisterType<IDataContext, DapperContext>();
            container.RegisterInstance<IEntityService>(new ValueConverter());

            container.RegisterType<IBookRepository, BookRepository>();

            container.RegisterType<IBookDM, BookDM>();
        }
    }
}
