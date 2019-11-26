using BookCatalogTestProject.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.Infrastructure.Business
{
    public interface IBusinessContext : IDisposable
    {
        IDataContext DataContext { get; }

        IServiceProviderFactory Factory { get; }
    }
}
