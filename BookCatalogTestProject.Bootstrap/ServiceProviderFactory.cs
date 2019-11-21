using BookCatalogTestProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace BookCatalogTestProject.Bootstrap
{
    public class ServiceProviderFactory : IServiceProviderFactory, IDisposable
    {
        private readonly IUnityContainer container = new UnityContainer();
        private readonly IRequestContext requestContext = default(IRequestContext);

        public ServiceProviderFactory(IUnityContainer container, IRequestContext requestContext)
        {
            this.container = container;
            this.requestContext = requestContext;
        }

        public object GetService(Type serviceType)
        {
            return this.container.Resolve(serviceType);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
