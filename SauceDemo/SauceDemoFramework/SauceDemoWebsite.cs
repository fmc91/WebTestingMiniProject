using System;
using OpenQA.Selenium;

namespace SauceDemoFramework
{
    public class SauceDemoWebsite
    {
        private IWebDriver _driver;

        public HomePage HomePage { get; }

        public InventoryPage InventoryPage { get; }

        public CartPage CartPage { get; }

        public CheckoutStepOnePage CheckoutStepOnePage { get; }

        public CheckoutStepTwoPage CheckoutStepTwoPage { get; }

        public SauceDemoWebsite(Browser browser)
        {
            _driver = DriverFactory.Create(browser);

            HomePage = new HomePage(_driver, Config.GetConfig());
            InventoryPage = new InventoryPage(_driver, Config.GetConfig());
            CartPage = new CartPage(_driver, Config.GetConfig());
            CheckoutStepOnePage = new CheckoutStepOnePage(_driver, Config.GetConfig());
            CheckoutStepTwoPage = new CheckoutStepTwoPage(_driver, Config.GetConfig());
        }

        public string CurrentUrl
        {
            get => _driver.Url;
        }

        public void Exit()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
