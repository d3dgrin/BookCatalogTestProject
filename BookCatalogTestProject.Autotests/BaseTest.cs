using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.Autotests
{
    public class BaseTest : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _driverWait;

        private string _baseUrl = "https://localhost:44303";

        public BaseTest()
        {
            _driver = new ChromeDriver();
            _driverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));
        }

        public void NavigateTo(string part = "")
        {
            _driver.Navigate().GoToUrl(string.Concat(_baseUrl, "/", part));
        }

        public IWebElement FindElement(By by)
        {
            _driver.FindElement(by);
            return _driver.FindElement(by);
        }

        public IWebElement FindElement(Func<IWebDriver, IWebElement> del)
        {
            return _driverWait.Until(del);
        }

        public void FindAndSendKeys(string text, Func<IWebDriver, IWebElement> del)
        {
            _driverWait.Until(del).Clear();
            _driverWait.Until(del).SendKeys(text);
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
