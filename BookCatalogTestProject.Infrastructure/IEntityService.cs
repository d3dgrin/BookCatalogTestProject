using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.Infrastructure
{
    public interface IEntityService
    {
        TOut ConvertTo<TOut>(object value, TOut defaultValue);

        void AssignTo<TIn, TOut>(TIn source, TOut destination);

        TOut ConvertTo<TIn, TOut>(TIn source);

        void AssignTo<TIn, TOut>(TIn source, TOut destination, IDictionary<string, object> items);
    }
}
