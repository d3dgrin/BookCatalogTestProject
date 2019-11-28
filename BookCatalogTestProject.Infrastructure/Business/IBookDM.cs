﻿using BookCatalogTestProject.ViewModel;
using BookCatalogTestProject.ViewModel.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.Infrastructure.Business
{
    public interface IBookDM : IDisposable
    {
        IEnumerable<BookVM> GetBooks();
        BookVM GetBook(int id);
        void CreateBook(CreateBookVM model);
        void DeleteBook(int id);
    }
}
