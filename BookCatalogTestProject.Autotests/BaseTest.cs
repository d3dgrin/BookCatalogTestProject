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
        public IWebDriver Browser { get; }

        public BaseTest()
        {
            Browser = new ChromeDriver();
        }

        public void Dispose()
        {
            Browser.Quit();
            Browser.Dispose();
        }
    }
}
