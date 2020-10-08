using System;
using System.Diagnostics;
using OpenQA.Selenium;

namespace SauceDemoFramework
{
    public abstract class PageBase
    {
        protected readonly IWebDriver _driver;

        public string PageUrl { get; private set; }

        public PageBase(IWebDriver driver, string pageUrl)
        {
            _driver = driver;
            PageUrl = pageUrl;
        }

        public void Visit()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }

        public bool ValidState
        {
            get => _driver.Url == PageUrl;
        }
    }
}
