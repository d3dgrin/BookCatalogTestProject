using BookCatalogTestProject.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.DAL.Repositories
{
    public abstract class RepostioryBase<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class
    {
        public string DbConnection
        {
            get;
            private set;
        }

        protected RepostioryBase(string dbConnection)
        {
            this.DbConnection = dbConnection;
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity Get(TKey id)
        {
            throw new NotImplementedException();
        }

        public TKey Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TKey id)
        {
            throw new NotImplementedException();
        }

        public abstract void Dispose();
    }
}
