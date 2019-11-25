using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.Infrastructure.Data
{
    public interface IDataContext : IDisposable
    {
        string DbConnection { get; }
    }
}
