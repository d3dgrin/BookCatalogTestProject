using BookCatalogTestProject.Infrastructure.Data;
using BookCatalogTestProject.DAL.Entity;
using Dommel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.DAL.Repositories
{
    public class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class
    {
        public IDataContext CurrentContext
        {
            get;
            private set;
        }

        protected RepositoryBase(IDataContext context)
        {
            this.CurrentContext = context;
        }

        public IEnumerable<TEntity> GetAll()
        {
            using (IDbConnection db = new SqlConnection(this.CurrentContext.DbConnection))
            {
                return db.GetAll<TEntity>();
            }
        }

        public TEntity Get(TKey id)
        {
            using (IDbConnection db = new SqlConnection(this.CurrentContext.DbConnection))
            {
                return db.Get<TEntity>(id);
            }
        }

        public long Create(TEntity entity)
        {
            using (IDbConnection db = new SqlConnection(this.CurrentContext.DbConnection))
            {
                var result = db.Insert<TEntity>(entity);
                return result != null ? long.Parse(result.ToString()) : default(long);
            }
        }

        public void Update(TEntity entity)
        {
            using (IDbConnection db = new SqlConnection(this.CurrentContext.DbConnection))
            {
                db.Update<TEntity>(entity);
            }
        }

        public void Delete(TKey id)
        {
            using (IDbConnection db = new SqlConnection(this.CurrentContext.DbConnection))
            {
                var entity = db.Get<TEntity>(id);
                db.Delete<TEntity>(entity);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
