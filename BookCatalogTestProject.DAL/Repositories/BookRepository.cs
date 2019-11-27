using BookCatalogTestProject.DAL.Entity;
using BookCatalogTestProject.Infrastructure.Data;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.DAL.Repositories
{
    public class BookRepository : RepositoryBase<BookEM, int>, IBookRepository
    {
        public BookRepository(IDataContext context) : base(context)
        {
            
        }

        public IEnumerable<BookEM> GetBooks()
        {
            string query = @"SELECT [Id]
                                  ,[Title]
                                  ,[PublicationDate]
                                  ,[Rating]
                                  ,[PagesCount]
                              FROM [Book]";

            using (IDbConnection db = new SqlConnection(base.CurrentContext.DbConnection))
            {
                var booksEM = db.Query<BookEM>(query);

                return booksEM;
            }
        }
    }
}
