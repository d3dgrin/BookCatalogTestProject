using BookCatalogTestProject.Data.Repositories;
using BookCatalogTestProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace BookCatalogTestProject.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IBookRepository, BookRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}