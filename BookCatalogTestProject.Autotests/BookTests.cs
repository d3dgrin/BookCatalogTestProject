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

            page.Open();

            page.OpenCreatingModal();

            page.PopulateCreatingModal(expectedTitle, expectedDate, expectedRating, expectedPagesCount);

            page.SubmitCreatingModal();

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

            page.Open();

            page.OpenEditingModal();

            page.PopulateEditingModal(expectedTitle, expectedDate, expectedRating, expectedPagesCount);

            page.SubmitEditingModal();

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
