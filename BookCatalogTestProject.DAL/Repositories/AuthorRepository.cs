using BookCatalogTestProject.DAL.Entity;
using BookCatalogTestProject.DAL.Entity.Book;
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

        public IEnumerable<AuthorEM> GetAuthors()
        {
            string query = @"SELECT [Id], [Name], [Surname] FROM [Author]";

            using (IDbConnection db = new SqlConnection(base.CurrentContext.DbConnection))
            {
                var entitiesModel = db.Query<AuthorEM>(query);

                return entitiesModel;
            }
        }

        public AuthorEM GetAuthor(int id)
        {
            string query = @"SELECT [Id], [Name], [Surname] FROM [Author] WHERE [Id] = @id";
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

            sqlParams.Add("@Id", model.Id, DbType.String);
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
