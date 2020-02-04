using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.DAL.Entity
{
    public class AuthorEM
    {
        public AuthorEM()
        {
        }

        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
