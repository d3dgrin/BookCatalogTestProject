using BookCatalogTestProject.ViewModel.Author;
using BookCatalogTestProject.ViewModel.Datatable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.Infrastructure.Business
{
    public interface IAuthorDM : IDisposable
    {
        IEnumerable<AuthorVM> GetAuthors(BaseDataTableFilterVM filter, out int totalFiltered);
        AuthorVM GetAuthor(int id);
        AuthorVM CreateAuthor(AuthorVM model);
        void UpdateAuthor(AuthorVM model);
        void DeleteAuthor(int id);
    }
}
