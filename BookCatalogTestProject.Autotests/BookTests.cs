using System;
using BookCatalogTestProject.Autotests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace BookCatalogTestProject.Autotests
{
    [TestClass]
    public class BookTests : BaseTest
    {
        private readonly string _url = "Book/Index";

        [TestMethod]
        public void BookCreating()
        {
            string expectedTitle = "Test Title";
            string expectedDate = "10/10/2020";
            string expectedRating = "10";
            string expectedPagesCount = "100";

            this.NavigateTo(_url);

            this.FindElement(ExpectedConditions.ElementIsVisible(By.XPath(BookConstants.BOOK_ADD_BTN))).Click();

            this.FindAndSendKeys(expectedTitle, ExpectedConditions.ElementIsVisible(By.Id(BookConstants.BOOK_ADD_TITLE_INPUT_ID)));
            this.FindAndSendKeys(expectedDate, ExpectedConditions.ElementIsVisible(By.Id(BookConstants.BOOK_ADD_PUBLICATIONDATE_INPUT_ID)));
            this.FindAndSendKeys(expectedRating, ExpectedConditions.ElementIsVisible(By.Id(BookConstants.BOOK_ADD_RATING_INPUT_ID)));
            this.FindAndSendKeys(expectedPagesCount, ExpectedConditions.ElementIsVisible(By.Id(BookConstants.BOOK_ADD_PAGESCOUNT_INPUT_ID)));

            this.FindElement(ExpectedConditions.ElementIsVisible(By.XPath(BookConstants.BOOK_ADD_AUTHORS_INPUT_UL))).Click();
            this.FindElement(ExpectedConditions.ElementIsVisible(By.XPath(BookConstants.BOOK_ADD_AUTHORS_INPUT_DROPDOWN))).Click();

            this.FindElement(ExpectedConditions.ElementIsVisible(By.XPath(BookConstants.BOOK_SAVE_BTN))).Click();

            string actulaTitle = this.FindElement(By.XPath(BookConstants.BOOK_LAST_RECORD_TITLE)).Text;
            string actulaDate = this.FindElement(By.XPath(BookConstants.BOOK_LAST_RECORD_PUBLICATIONDATE)).Text;
            string actulaRating = this.FindElement(By.XPath(BookConstants.BOOK_LAST_RECORD_RATING)).Text;
            string actulaPagesCount = this.FindElement(By.XPath(BookConstants.BOOK_LAST_RECORD_PAGESCOUNT)).Text;

            Assert.AreEqual(expectedTitle, actulaTitle);
            Assert.AreEqual(expectedDate, actulaDate);
            Assert.AreEqual(expectedRating, actulaRating);
            Assert.AreEqual(expectedPagesCount, actulaPagesCount);
        }

        [TestMethod]
        public void BookEditing()
        {
            string expectedTitle = "New Test Title";
            string expectedDate = "10/20/2020";
            string expectedRating = "5";
            string expectedPagesCount = "50";

            this.NavigateTo(_url);

            this.FindElement(ExpectedConditions.ElementIsVisible(By.XPath(BookConstants.BOOK_LAST_RECORD_EDIT_BTN))).Click();

            this.FindAndSendKeys(expectedTitle, ExpectedConditions.ElementIsVisible(By.Id(BookConstants.BOOK_ADD_TITLE_INPUT_ID)));
            this.FindAndSendKeys(expectedDate, ExpectedConditions.ElementIsVisible(By.Id(BookConstants.BOOK_ADD_PUBLICATIONDATE_INPUT_ID)));
            this.FindAndSendKeys(expectedRating, ExpectedConditions.ElementIsVisible(By.Id(BookConstants.BOOK_ADD_RATING_INPUT_ID)));
            this.FindAndSendKeys(expectedPagesCount, ExpectedConditions.ElementIsVisible(By.Id(BookConstants.BOOK_ADD_PAGESCOUNT_INPUT_ID)));

            this.FindElement(ExpectedConditions.ElementIsVisible(By.XPath(BookConstants.BOOK_SAVE_BTN))).Click();

            string actulaTitle = this.FindElement(By.XPath(BookConstants.BOOK_LAST_RECORD_TITLE)).Text;
            string actulaDate = this.FindElement(By.XPath(BookConstants.BOOK_LAST_RECORD_PUBLICATIONDATE)).Text;
            string actulaRating = this.FindElement(By.XPath(BookConstants.BOOK_LAST_RECORD_RATING)).Text;
            string actulaPagesCount = this.FindElement(By.XPath(BookConstants.BOOK_LAST_RECORD_PAGESCOUNT)).Text;

            Assert.AreEqual(expectedTitle, actulaTitle);
            Assert.AreEqual(expectedDate, actulaDate);
            Assert.AreEqual(expectedRating, actulaRating);
            Assert.AreEqual(expectedPagesCount, actulaPagesCount);
        }
    }
}
