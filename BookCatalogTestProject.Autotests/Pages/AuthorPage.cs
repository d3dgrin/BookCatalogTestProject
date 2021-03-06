﻿using BookCatalogTestProject.Autotests.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.Autotests.Pages
{
    public class AuthorPage : BasePage
    {
        private readonly string _url = "Author/Index";

        public AuthorPage(IWebDriver driver) : base(driver)
        {
        }

        public void Open()
        {
            this.NavigateTo(_url);
        }

        public void OpenCreatingModal() => this.FindElement(ExpectedConditions.ElementIsVisible(By.XPath(AuthorConstants.AUTHOR_ADD_BTN))).Click();
        public void OpenEditingModal() => this.FindElement(ExpectedConditions.ElementIsVisible(By.XPath(AuthorConstants.AUTHORS_LAST_RECORD_EDIT_BTN))).Click();

        public void PopulateCreatingModal(string name, string surname)
        {
            this.FindAndSendKeys(name, ExpectedConditions.ElementIsVisible(By.Id(AuthorConstants.AUTHOR_ADD_NAME_INPUT_ID)));
            this.FindAndSendKeys(surname, ExpectedConditions.ElementIsVisible(By.Id(AuthorConstants.AUTHOR_ADD_SURNAME_INPUT_ID)));
        }

        public void PopulateEditingModal(string name, string surname)
        {
            this.FindAndSendKeys(name, ExpectedConditions.ElementIsVisible(By.Id(AuthorConstants.AUTHOR_EDIT_NAME_INPUT_ID)));
            this.FindAndSendKeys(surname, ExpectedConditions.ElementIsVisible(By.Id(AuthorConstants.AUTHOR_EDIT_SURNAME_INPUT_ID)));
        }

        public void SubmitCreatingModal() => this.FindElement(ExpectedConditions.ElementIsVisible(By.XPath(AuthorConstants.AUTHOR_SAVE_BTN))).Click();
        public void SubmitEditingModal() => this.FindElement(ExpectedConditions.ElementIsVisible(By.XPath(AuthorConstants.AUTHOR_SAVE_BTN))).Click();
        public string FindLastRecordName() => this.FindElement(By.XPath(AuthorConstants.AUTHORS_LAST_RECORD_NAME)).Text;
        public string FindLastRecordSurname() => this.FindElement(By.XPath(AuthorConstants.AUTHORS_LAST_RECORD_SURNAME)).Text;
    }
}
