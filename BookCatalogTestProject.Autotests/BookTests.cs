using System;
using BookCatalogTestProject.Autotests.Helpers;
using BookCatalogTestProject.Autotests.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace BookCatalogTestProject.Autotests
{
    [TestClass]
    public class BookTests : BaseTest
    {
        [TestMethod]
        public void BookCreating()
        {
            string expectedTitle = "Test Title";
            string expectedDate = "10/10/2020";
            string expectedRating = "10";
            string expectedPagesCount = "100";

            BookPage page = new BookPage(Browser);

            page.OpenBookPage();

            page.OpenCreatingBookModal();

            page.PopulateCreatingBookModal(expectedTitle, expectedDate, expectedRating, expectedPagesCount);

            page.SubmitCreatingBookModal();

            string actulaTitle = page.FindLastRecordTitle();
            string actulaDate = page.FindLastRecordDate();
            string actulaRating = page.FindLastRecordRating();
            string actulaPagesCount = page.FindLastRecordPagesCount();

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

            BookPage page = new BookPage(Browser);

            page.OpenBookPage();

            page.OpenEditingBookModal();

            page.PopulateEditingBookModal(expectedTitle, expectedDate, expectedRating, expectedPagesCount);

            page.SubmitEditingBookModal();

            string actulaTitle = page.FindLastRecordTitle();
            string actulaDate = page.FindLastRecordDate();
            string actulaRating = page.FindLastRecordRating();
            string actulaPagesCount = page.FindLastRecordPagesCount();

            Assert.AreEqual(expectedTitle, actulaTitle);
            Assert.AreEqual(expectedDate, actulaDate);
            Assert.AreEqual(expectedRating, actulaRating);
            Assert.AreEqual(expectedPagesCount, actulaPagesCount);
        }
    }
}
