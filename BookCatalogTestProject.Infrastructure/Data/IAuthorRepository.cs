using BookCatalogTestProject.DAL.Entity;
using BookCatalogTestProject.DAL.Entity.Datatable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.Infrastructure.Data
{
    public interface IAuthorRepository : IRepository<AuthorEM, int>
    {
        IEnumerable<AuthorEM> GetAuthors(BaseDataTableFilterEM filter, out int totalFiltered);
        AuthorEM GetAuthor(int id);
        AuthorEM CreateAuthor(AuthorEM model);
        void UpdateAuthor(AuthorEM model);
        void DeleteAuthor(int id);
    }
}
