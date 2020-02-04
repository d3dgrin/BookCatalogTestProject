using BookCatalogTestProject.DAL.Entity;
using BookCatalogTestProject.DAL.Entity.Book;
using BookCatalogTestProject.DAL.Entity.Enums;
using BookCatalogTestProject.DAL.Extensions;
using BookCatalogTestProject.Infrastructure.Data;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.DAL.Repositories
{
    public class BookRepository : RepositoryBase<BookEM, int>, IBookRepository
    {
        public BookRepository(IDataContext context) : base(context)
        {
            
        }

        public IEnumerable<BookEM> GetBooks()
        {
            string spName = "USPGetBooks";

            using (IDbConnection db = new SqlConnection(base.CurrentContext.DbConnection))
            {
                var books = db.Query<BookEM, AuthorEM, BookEM>(spName, (book, author) =>
                {
                    if (author != null) book.Authors.Add(author);
                    else book.Authors = new List<AuthorEM>();
                    return book;
                }, null, null, true, splitOn: "AuthorId", null, CommandType.StoredProcedure);

                var result = books.GroupBy(b => b.BookId).Select(g =>
                {
                    var groupedPost = g.First();
                    if (groupedPost.Authors.Any()) groupedPost.Authors = g.Select(a => a.Authors.Single()).ToList();
                    return groupedPost;
                }).ToList();

                return result;
            }
        }

        public BookEM GetBook(int id)
        {
            string query = @"SELECT [Id]
                                  ,[Title]
                                  ,[PublicationDate]
                                  ,[Rating]
                                  ,[PagesCount]
                              FROM [Book]
                                WHERE [Id] = @id";
            var sqlParams = new DynamicParameters();
            sqlParams.Add("@id", id, DbType.Int32);

            using (IDbConnection db = new SqlConnection(base.CurrentContext.DbConnection))
            {
                var bookEM = db.Query<BookEM>(query, sqlParams).FirstOrDefault();

                return bookEM;
            }
        }

        public void CreateBook(CreateBookEM model)
        {
            string spName = "USPCreateBook";

            DynamicParameters sqlParams = new DynamicParameters();

            sqlParams.Add("@Title", model.Title, DbType.String);
            sqlParams.Add("@PublicationDate", model.PublicationDate, DbType.DateTime);
            sqlParams.Add("@Rating", model.Rating, DbType.Int32);
            sqlParams.Add("@PagesCount", model.PagesCount, DbType.Int32);
            sqlParams.Add("@AuthorIds", model.AuthorIds.AsDataTableParam().AsTableValuedParameter(DataBaseCustomType.IntArrayType));

            using (IDbConnection db = new SqlConnection(base.CurrentContext.DbConnection))
            {
                db.Query(spName, sqlParams, null, true, null, CommandType.StoredProcedure);
            }
        }

        public void UpdateBook(CreateBookEM model)
        {
            string spName = "USPUpdateBook";

            DynamicParameters sqlParams = new DynamicParameters();

            sqlParams.Add("@Id", model.Id, DbType.Int32);
            sqlParams.Add("@Title", model.Title, DbType.String);
            sqlParams.Add("@PublicationDate", model.PublicationDate, DbType.DateTime);
            sqlParams.Add("@Rating", model.Rating, DbType.Int32);
            sqlParams.Add("@PagesCount", model.PagesCount, DbType.Int32);
            sqlParams.Add("@AuthorIds", model.AuthorIds.AsDataTableParam().AsTableValuedParameter(DataBaseCustomType.IntArrayType));

            using (IDbConnection db = new SqlConnection(base.CurrentContext.DbConnection))
            {
                db.Query(spName, sqlParams, null, true, null, CommandType.StoredProcedure);
            }
        }

        public void DeleteBook(int id)
        {
            string query = @"DELETE FROM [Book] WHERE [Id] = @id";

            var sqlParams = new DynamicParameters();
            sqlParams.Add("@id", id, DbType.Int32);

            using (IDbConnection db = new SqlConnection(base.CurrentContext.DbConnection))
            {
                db.Query(query, sqlParams);
            }
        }
    }
}
