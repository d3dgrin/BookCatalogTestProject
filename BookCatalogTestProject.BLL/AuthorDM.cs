using BookCatalogTestProject.DAL.Entity;
using BookCatalogTestProject.DAL.Entity.Datatable;
using BookCatalogTestProject.Infrastructure;
using BookCatalogTestProject.Infrastructure.Business;
using BookCatalogTestProject.Infrastructure.Data;
using BookCatalogTestProject.ViewModel.Author;
using BookCatalogTestProject.ViewModel.Datatable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.BLL
{
    public class AuthorDM : BusinessContextBase, IAuthorDM
    {
        public AuthorDM(IRequestContext requestContext) : base(requestContext)
        {

        }

        public IEnumerable<AuthorVM> GetAuthors(BaseDataTableFilterVM filter, out int totalFiltered)
        {
            using (var repo = Factory.GetService<IAuthorRepository>(DataContext))
            {
                var filterEM = entService.ConvertTo<BaseDataTableFilterVM, BaseDataTableFilterEM>(filter);

                var listEM = repo.GetAuthors(filterEM, out totalFiltered);

                var listVM = entService.ConvertTo<IEnumerable<AuthorEM>, IEnumerable<AuthorVM>>(listEM);

                return listVM;
            }
        }

        public IEnumerable<AuthorVM> GetAuthorsWithoutFilter()
        {
            using (var repo = Factory.GetService<IAuthorRepository>(DataContext))
            {
                var listEM = repo.GetAuthorsWithoutFilter();

                var listVM = entService.ConvertTo<IEnumerable<AuthorEM>, IEnumerable<AuthorVM>>(listEM);

                return listVM;
            }
        }

        public AuthorVM GetAuthor(int id)
        {
            using (var repo = Factory.GetService<IAuthorRepository>(DataContext))
            {
                var entityModel = repo.GetAuthor(id);
                var viewModel = entService.ConvertTo<AuthorEM, AuthorVM>(entityModel);
                return viewModel;
            }
        }

        public AuthorVM CreateAuthor(AuthorVM model)
        {
            using (var repo = Factory.GetService<IAuthorRepository>(DataContext))
            {
                var entityModel = entService.ConvertTo<AuthorVM, AuthorEM>(model);
                var result = repo.CreateAuthor(entityModel);
                return entService.ConvertTo<AuthorEM, AuthorVM>(result);
            }
        }

        public void UpdateAuthor(AuthorVM model)
        {
            using (var repo = Factory.GetService<IAuthorRepository>(DataContext))
            {
                var entityModel = entService.ConvertTo<AuthorVM, AuthorEM>(model);
                repo.UpdateAuthor(entityModel);
            }
        }

        public void DeleteAuthor(int id)
        {
            using (var repo = Factory.GetService<IAuthorRepository>(DataContext))
            {
                repo.DeleteAuthor(id);
            }
        }
    }
}
