using BookCatalogTestProject.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.Infrastructure.Business
{
    public class BusinessContextBase : IBusinessContext
    {
        private readonly IDataContext dataContext = default(IDataContext);
        protected readonly IRequestContext context = default(IRequestContext);
        protected readonly IEntityService entService = default(IEntityService);

        public BusinessContextBase(IRequestContext requestContext)
        {
            if (requestContext != null)
            {
                this.dataContext = requestContext.DataContext;
            }

            this.context = requestContext;
            this.entService = this.context.Factory.GetService<IEntityService>();
        }

        public IDataContext DataContext { get { return this.dataContext; } }

        public IServiceProviderFactory Factory { get { return this.context.Factory; } }

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
