using System;
using BookCatalogTestProject.Autotests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;

namespace BookCatalogTestProject.Autotests
{
    [TestClass]
    public class AuthorTests : BaseTest
    {
        private readonly string _url = "Author/Index";

        [TestMethod]
        public void AuthorCreating()
        {
            string expectedName = "Test Name";
            string expectedSurname = "Test Surname";

            this.NavigateTo(_url);

            this.FindElement(ExpectedConditions.ElementIsVisible(By.XPath(AuthorConstants.AUTHOR_ADD_BTN))).Click();
            this.FindAndSendKeys(expectedName, ExpectedConditions.ElementIsVisible(By.Id(AuthorConstants.AUTHOR_ADD_NAME_INPUT_ID)));
            this.FindAndSendKeys(expectedSurname, ExpectedConditions.ElementIsVisible(By.Id(AuthorConstants.AUTHOR_ADD_SURNAME_INPUT_ID)));
            this.FindElement(ExpectedConditions.ElementIsVisible(By.XPath(AuthorConstants.AUTHOR_SAVE_BTN))).Click();

            string actulaName = this.FindElement(By.XPath(AuthorConstants.AUTHORS_LAST_RECORD_NAME)).Text;
            string actulaSurname = this.FindElement(By.XPath(AuthorConstants.AUTHORS_LAST_RECORD_SURNAME)).Text;

            Assert.AreEqual(expectedName, actulaName);
            Assert.AreEqual(expectedSurname, actulaSurname);
        }

        [TestMethod]
        public void AuthorEditing()
        {
            string expectedName = "New Test Name";
            string expectedSurname = "New Test Surname";

            this.NavigateTo(_url);

            this.FindElement(ExpectedConditions.ElementIsVisible(By.XPath(AuthorConstants.AUTHORS_LAST_RECORD_EDIT_BTN))).Click();
            this.FindAndSendKeys(expectedName, ExpectedConditions.ElementIsVisible(By.Id(AuthorConstants.AUTHOR_EDIT_NAME_INPUT_ID)));
            this.FindAndSendKeys(expectedSurname, ExpectedConditions.ElementIsVisible(By.Id(AuthorConstants.AUTHOR_EDIT_SURNAME_INPUT_ID)));
            this.FindElement(ExpectedConditions.ElementIsVisible(By.XPath(AuthorConstants.AUTHOR_SAVE_BTN))).Click();

            string actulaName = this.FindElement(By.XPath(AuthorConstants.AUTHORS_LAST_RECORD_NAME)).Text;
            string actulaSurname = this.FindElement(By.XPath(AuthorConstants.AUTHORS_LAST_RECORD_SURNAME)).Text;

            Assert.AreEqual(expectedName, actulaName);
            Assert.AreEqual(expectedSurname, actulaSurname);
        }
    }
}
