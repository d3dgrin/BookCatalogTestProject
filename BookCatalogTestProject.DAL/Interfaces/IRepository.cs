using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.DAL.Interfaces
{
    public interface IRepository<TEntity, Key> : IDisposable
        where TEntity: class
    {
        string DbConnection { get; }

        IEnumerable<TEntity> GetAll();

        TEntity Get(Key id);

        Key Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(Key id);
    }
}
