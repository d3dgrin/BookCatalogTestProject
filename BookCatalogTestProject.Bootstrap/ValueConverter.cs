using AutoMapper;
using BookCatalogTestProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.Bootstrap
{
    public class ValueConverter : IEntityService
    {
        public TOut ConvertTo<TOut>(object value, TOut defaultValue)
        {
            try
            {
                return Mapper.Map<TOut>(value);
            }
            catch (Exception ex)
            {
                var mapError = ex.Message;
                return defaultValue;
            }
        }

        public void AssignTo<TIn, TOut>(TIn source, TOut destination)
        {
            Mapper.Map<TIn, TOut>(source, destination);
        }

        public TOut ConvertTo<TIn, TOut>(TIn source)
        {
            return Mapper.Map<TOut>(source);
        }

        public void AssignTo<TIn, TOut>(TIn source, TOut destination, IDictionary<string, object> items)
        {
            Mapper.Map(source, destination, opt =>
            {
                foreach (var i in items)
                {
                    opt.Items.Add(i.Key, i.Value);
                }
            });
        }
    }
}
