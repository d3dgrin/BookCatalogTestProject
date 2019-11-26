using BookCatalogTestProject.Infrastructure;
using BookCatalogTestProject.Infrastructure.Business;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.Bootstrap
{
    public class ServiceProviderFactory : IServiceProviderFactory, IDisposable
    {
        private readonly IUnityContainer container = new UnityContainer();
        private readonly IRequestContext requestContext = default(IRequestContext);
        private static readonly Type TypedTrigger = typeof(IBusinessContext);

        public ServiceProviderFactory(IUnityContainer container, IRequestContext requestContext)
        {
            this.container = container;
            this.requestContext = requestContext;
        }

        public object GetService(Type serviceType)
        {
            return this.container.Resolve(serviceType);
        }

        public TService GetService<TService>(params object[] constructParams)
        {
            return this.container.Resolve<TService>(new ServiceProviderParametersResolver(this.requestContext, constructParams, this.isSelectedType(typeof(TService))));
        }

        private bool isSelectedType(Type serviceType)
        {
            if (serviceType == null)
            {
                return false;
            }

            if (TypedTrigger.IsAssignableFrom(serviceType))
            {
                return true;
            }

            return false;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
