﻿using BookCatalogTestProject.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.Infrastructure
{
    public interface IRequestContext : IDisposable
    {
        IDataContext DataContext { get; }
        IServiceProviderFactory Factory { get; }
    }
}
