using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.Infrastructure.Data
{
    public interface IRepository<TEntity, Key> : IDisposable
        where TEntity : class
    {
        IDataContext CurrentContext { get; }

        IEnumerable<TEntity> GetAll();

        TEntity Get(Key id);

        long Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(Key id);
    }
}
