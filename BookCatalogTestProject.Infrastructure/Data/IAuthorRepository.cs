using BookCatalogTestProject.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.Infrastructure.Data
{
    public interface IAuthorRepository : IRepository<AuthorEM, int>
    {
        IEnumerable<AuthorEM> GetAuthors();
        AuthorEM GetAuthor(int id);
        void CreateAuthor(AuthorEM model);
        void DeleteAuthor(int id);
    }
}
