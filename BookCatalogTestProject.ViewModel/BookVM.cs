﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.ViewModel
{
    public class BookVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public int Rating { get; set; }
        public int PagesCount { get; set; }
    }
}
