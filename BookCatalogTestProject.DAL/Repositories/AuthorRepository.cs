using BookCatalogTestProject.DAL.Entity;
using BookCatalogTestProject.DAL.Entity.Book;
using BookCatalogTestProject.DAL.Entity.Datatable;
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
    public class AuthorRepository : RepositoryBase<AuthorEM, int>, IAuthorRepository
    {
        public AuthorRepository(IDataContext context) : base(context)
        {
        }

        public IEnumerable<AuthorEM> GetAuthors(BaseDataTableFilterEM filter, out int totalFiltered)
        {
            string spName = "USPGetAuthors";

            var order = filter.Order.First();
            var column = filter.Columns[order.Column];

            DynamicParameters sqlParams = new DynamicParameters();

            sqlParams.Add("OrderBy", column.Name);
            sqlParams.Add("Direction", order.Dir);
            sqlParams.Add("Start", filter.Start);
            sqlParams.Add("Length", filter.Length);
            sqlParams.Add("TotalFiltered", DbType.Int32, direction: ParameterDirection.Output);

            using (IDbConnection db = new SqlConnection(base.CurrentContext.DbConnection))
            {
                var result = db.Query<AuthorEM>(spName, sqlParams, null, true, null, CommandType.StoredProcedure);
                totalFiltered = sqlParams.Get<int?>("@TotalFiltered") ?? 0;
                return result;
            }
        }

        public IEnumerable<AuthorEM> GetAuthorsWithoutFilter()
        {
            string query = @"SELECT [AuthorId], [Name], [Surname] FROM [Author]";
            var sqlParams = new DynamicParameters();

            using (IDbConnection db = new SqlConnection(base.CurrentContext.DbConnection))
            {
                var entityModel = db.Query<AuthorEM>(query, sqlParams);

                return entityModel;
            }
        }

        public AuthorEM GetAuthor(int id)
        {
            string query = @"SELECT [AuthorId], [Name], [Surname] FROM [Author] WHERE [AuthorId] = @id";
            var sqlParams = new DynamicParameters();
            sqlParams.Add("@id", id, DbType.Int32);

            using (IDbConnection db = new SqlConnection(base.CurrentContext.DbConnection))
            {
                var entityModel = db.Query<AuthorEM>(query, sqlParams).FirstOrDefault();

                return entityModel;
            }
        }

        public AuthorEM CreateAuthor(AuthorEM model)
        {
            string spName = "USPCreateAuthor";

            DynamicParameters sqlParams = new DynamicParameters();

            sqlParams.Add("@Name", model.Name, DbType.String);
            sqlParams.Add("@Surname", model.Surname, DbType.String);

            using (IDbConnection db = new SqlConnection(base.CurrentContext.DbConnection))
            {
                return db.Query<AuthorEM>(spName, sqlParams, null, true, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public void UpdateAuthor(AuthorEM model)
        {
            string spName = "USPUpdateAuthor";

            DynamicParameters sqlParams = new DynamicParameters();

            sqlParams.Add("@Id", model.AuthorId, DbType.String);
            sqlParams.Add("@Name", model.Name, DbType.String);
            sqlParams.Add("@Surname", model.Surname, DbType.String);

            using (IDbConnection db = new SqlConnection(base.CurrentContext.DbConnection))
            {
                db.Query(spName, sqlParams, null, true, null, CommandType.StoredProcedure);
            }
        }

        public void DeleteAuthor(int id)
        {
            string spName = "USPDeleteAuthor";

            DynamicParameters sqlParams = new DynamicParameters();

            sqlParams.Add("@Id", id, DbType.Int32);

            using (IDbConnection db = new SqlConnection(base.CurrentContext.DbConnection))
            {
                db.Query(spName, sqlParams, null, true, null, CommandType.StoredProcedure);
            }
        }
    }
}
