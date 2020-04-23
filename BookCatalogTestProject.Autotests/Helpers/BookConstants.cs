using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.Autotests.Helpers
{
    public static class BookConstants
    {
        public const string BOOK_ADD_BTN = "//*[@id='books_grid']/div[1]/button";
        public const string BOOK_SAVE_BTN = "//*[@id='bookModalForm']/div[2]/div[6]/button[2]";

        public const string BOOK_LAST_RECORD_TITLE = "(//*[@id='books_tbody']/tr)[last()]/td[2]/span";
        public const string BOOK_LAST_RECORD_PUBLICATIONDATE = "(//*[@id='books_tbody']/tr)[last()]/td[3]/span";
        public const string BOOK_LAST_RECORD_RATING = "(//*[@id='books_tbody']/tr)[last()]/td[4]/span";
        public const string BOOK_LAST_RECORD_PAGESCOUNT = "(//*[@id='books_tbody']/tr)[last()]/td[5]/span";

        public const string BOOK_LAST_RECORD_EDIT_BTN = "(//*[@id='books_tbody']/tr)[last()]/td[7]/button[1]";

        public const string BOOK_ADD_TITLE_INPUT_ID = "bookTitle";
        public const string BOOK_ADD_PUBLICATIONDATE_INPUT_ID = "bookPublicationDate";
        public const string BOOK_ADD_RATING_INPUT_ID = "bookRating";
        public const string BOOK_ADD_PAGESCOUNT_INPUT_ID = "bookPagesCount";
        public const string BOOK_ADD_AUTHORS_INPUT_UL = "//*[@id='bookModalForm']/div[2]/div[5]/span/span[1]/span/ul";
        public const string BOOK_ADD_AUTHORS_INPUT_DROPDOWN = "//*[@id='select2-bookAuthors-results']/li[1]";

        public const string BOOK_EDIT_TITLE_INPUT_ID = "bookTitle";
        public const string BOOK_EDIT_PUBLICATIONDATE_INPUT_ID = "bookPublicationDate";
        public const string BOOK_EDIT_RATING_INPUT_ID = "bookRating";
        public const string BOOK_EDIT_PAGESCOUNT_INPUT_ID = "bookPagesCount";
    }
}
