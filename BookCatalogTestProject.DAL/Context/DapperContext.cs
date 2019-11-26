using BookCatalogTestProject.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.DAL.Context
{
    public class DapperContext : IDataContext
    {
        public string DbConnection { get; protected set; }

        public DapperContext(string connectionString)
        {
            this.DbConnection = connectionString;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
