using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.Autotests.Helpers
{
    public static class AuthorConstants
    {
        public const string AUTHOR_ADD_BTN = "//*[@id='authors_grid']/div[1]/button";
        public const string AUTHOR_SAVE_BTN = "//*[@id='editAuthorModalForm']/div[2]/div[3]/button[2]";

        public const string AUTHORS_LAST_RECORD_NAME = "(//*[@id='authors_tbody']/tr)[last()]/td[2]/span";
        public const string AUTHORS_LAST_RECORD_SURNAME = "(//*[@id='authors_tbody']/tr)[last()]/td[3]/span";
        public const string AUTHORS_LAST_RECORD_EDIT_BTN = "(//*[@id='authors_tbody']/tr)[last()]/td[4]/button[1]";

        public const string AUTHOR_ADD_NAME_INPUT_ID = "EditAuthorName";
        public const string AUTHOR_ADD_SURNAME_INPUT_ID = "EditAuthorSurname";

        public const string AUTHOR_EDIT_NAME_INPUT_ID = "EditAuthorName";
        public const string AUTHOR_EDIT_SURNAME_INPUT_ID = "EditAuthorSurname";
    }
}
