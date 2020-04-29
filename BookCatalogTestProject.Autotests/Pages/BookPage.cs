using BookCatalogTestProject.Autotests.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.Autotests.Pages
{
    public class BookPage : BasePage
    {
        private readonly string _url = "Book/Index";

        public BookPage(IWebDriver driver) : base(driver)
        {
        }

        public void OpenBookPage()
        {
            this.NavigateTo(_url);
        }

        public void OpenCreatingBookModal() => this.FindElement(ExpectedConditions.ElementIsVisible(By.XPath(BookConstants.BOOK_ADD_BTN))).Click();
        public void OpenEditingBookModal() => this.FindElement(ExpectedConditions.ElementIsVisible(By.XPath(BookConstants.BOOK_LAST_RECORD_EDIT_BTN))).Click();

        public void PopulateCreatingBookModal(string title, string date, string rating, string pagesCount)
        {
            this.FindAndSendKeys(title, ExpectedConditions.ElementIsVisible(By.Id(BookConstants.BOOK_ADD_TITLE_INPUT_ID)));
            this.FindAndSendKeys(date, ExpectedConditions.ElementIsVisible(By.Id(BookConstants.BOOK_ADD_PUBLICATIONDATE_INPUT_ID)));
            this.FindAndSendKeys(rating, ExpectedConditions.ElementIsVisible(By.Id(BookConstants.BOOK_ADD_RATING_INPUT_ID)));
            this.FindAndSendKeys(pagesCount, ExpectedConditions.ElementIsVisible(By.Id(BookConstants.BOOK_ADD_PAGESCOUNT_INPUT_ID)));
            this.FindElement(ExpectedConditions.ElementIsVisible(By.XPath(BookConstants.BOOK_ADD_AUTHORS_INPUT_UL))).Click();
            this.FindElement(ExpectedConditions.ElementIsVisible(By.XPath(BookConstants.BOOK_ADD_AUTHORS_INPUT_DROPDOWN))).Click();
        }

        public void PopulateEditingBookModal(string title, string date, string rating, string pagesCount)
        {
            this.FindAndSendKeys(title, ExpectedConditions.ElementIsVisible(By.Id(BookConstants.BOOK_ADD_TITLE_INPUT_ID)));
            this.FindAndSendKeys(date, ExpectedConditions.ElementIsVisible(By.Id(BookConstants.BOOK_ADD_PUBLICATIONDATE_INPUT_ID)));
            this.FindAndSendKeys(rating, ExpectedConditions.ElementIsVisible(By.Id(BookConstants.BOOK_ADD_RATING_INPUT_ID)));
            this.FindAndSendKeys(pagesCount, ExpectedConditions.ElementIsVisible(By.Id(BookConstants.BOOK_ADD_PAGESCOUNT_INPUT_ID)));
        }

        public void SubmitCreatingBookModal() => this.FindElement(ExpectedConditions.ElementIsVisible(By.XPath(BookConstants.BOOK_SAVE_BTN))).Click();
        public void SubmitEditingBookModal() => this.FindElement(ExpectedConditions.ElementIsVisible(By.XPath(BookConstants.BOOK_SAVE_BTN))).Click();
        public string FindLastRecordTitle() => this.FindElement(By.XPath(BookConstants.BOOK_LAST_RECORD_TITLE)).Text;
        public string FindLastRecordDate() => this.FindElement(By.XPath(BookConstants.BOOK_LAST_RECORD_PUBLICATIONDATE)).Text;
        public string FindLastRecordRating() => this.FindElement(By.XPath(BookConstants.BOOK_LAST_RECORD_RATING)).Text;
        public string FindLastRecordPagesCount() => this.FindElement(By.XPath(BookConstants.BOOK_LAST_RECORD_PAGESCOUNT)).Text;
    }
}
