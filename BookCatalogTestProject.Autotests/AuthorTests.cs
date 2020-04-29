using System;
using BookCatalogTestProject.Autotests.Helpers;
using BookCatalogTestProject.Autotests.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;

namespace BookCatalogTestProject.Autotests
{
    [TestClass]
    public class AuthorTests : BaseTest
    {
        [TestMethod]
        public void AuthorCreating()
        {
            string expectedName = "Test Name";
            string expectedSurname = "Test Surname";

            AuthorPage page = new AuthorPage(Browser);

            page.OpenAuthorPage();

            page.OpenCreatingAuthorModal();

            page.PopulateCreatingAuthorModal(expectedName, expectedSurname);

            page.SubmitCreatingAuthorModal();

            string actulaName = page.FindLastRecordName();
            string actulaSurname = page.FindLastRecordSurname();

            Assert.AreEqual(expectedName, actulaName);
            Assert.AreEqual(expectedSurname, actulaSurname);
        }

        [TestMethod]
        public void AuthorEditing()
        {
            string expectedName = "New Test Name";
            string expectedSurname = "New Test Surname";

            AuthorPage page = new AuthorPage(Browser);

            page.OpenAuthorPage();

            page.OpenEditingAuthorModal();

            page.PopulateEditingAuthorModal(expectedName, expectedSurname);

            page.SubmitEditingAuthorModal();

            string actulaName = page.FindLastRecordName();
            string actulaSurname = page.FindLastRecordSurname();

            Assert.AreEqual(expectedName, actulaName);
            Assert.AreEqual(expectedSurname, actulaSurname);
        }
    }
}
