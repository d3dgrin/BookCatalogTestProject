using BookCatalogTestProject.ViewModel.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.Infrastructure.Business
{
    public interface IAuthorDM : IDisposable
    {
        IEnumerable<AuthorVM> GetAuthors();
        AuthorVM GetAuthor(int id);
        void CreateAuthor(AuthorVM model);
        void UpdateAuthor(AuthorVM model);
        void DeleteAuthor(int id);
    }
}
