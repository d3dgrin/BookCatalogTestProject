using AutoMapper;
using BookCatalogTestProject.BLL;
using BookCatalogTestProject.DAL.Entity;
using BookCatalogTestProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.Bootstrap
{
    public static class ApplicationMapper
    {
        public static void Init()
        {
            Mapper.Initialize((mapper) =>
            {
                mapper.CreateMap<BookVM, BookEM>().ReverseMap();
            });
        }
    }
}
