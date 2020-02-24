using AutoMapper;
using BookCatalogTestProject.BLL;
using BookCatalogTestProject.DAL.Entity;
using BookCatalogTestProject.DAL.Entity.Book;
using BookCatalogTestProject.DAL.Entity.Datatable;
using BookCatalogTestProject.ViewModel;
using BookCatalogTestProject.ViewModel.Author;
using BookCatalogTestProject.ViewModel.Book;
using BookCatalogTestProject.ViewModel.Datatable;
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
                mapper.CreateMap<CreateBookVM, CreateBookEM>().ReverseMap();

                mapper.CreateMap<AuthorVM, AuthorEM>().ReverseMap();

                mapper.CreateMap<BaseDataTableFilterVM, BaseDataTableFilterEM>()
                .ForMember(dest => dest.SearchExpression, opt => opt.MapFrom(src => src.Search.Value))
                .AfterMap((source, dest) =>
                {
                    var orderColumn = source.Order.FirstOrDefault();
                    var column = source.Columns.ElementAt(orderColumn != null ? orderColumn.Column : 0);
                    dest.IsAscOrder = orderColumn?.Dir == "asc";
                    dest.OrderColumnName = column?.Name;
                });

                mapper.CreateMap<DataTableOrderVM, DataTableOrderEM>();
                mapper.CreateMap<DataTableColumnVM, DataTableColumnEM>();
            });
        }
    }
}
