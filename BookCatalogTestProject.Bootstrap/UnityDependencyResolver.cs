using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace BookCatalogTestProject.Bootstrap
{
    public class UnityDependencyResolver
    {
        protected static IUnityContainer container;

        public static void RegisterTypes(IUnityContainer _container)
        {
            container = _container;
        }
    }
}
