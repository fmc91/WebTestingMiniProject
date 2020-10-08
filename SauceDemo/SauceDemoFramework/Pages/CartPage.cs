using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace SauceDemoFramework
{
    public class CartPage : PageBase
    {
        //private static readonly string _url;

        public CartPage(IWebDriver driver, Config config) : base(driver, config.CartPageUrl) { }

        public IEnumerable<string> GetItemNames()
        {
            return _driver.FindElements(By.ClassName("inventory_item_name")).Select(x => x.Text);
        }

        public void ClickRemoveOnItemWithName(string itemName)
        {
            _driver.FindElements(By.ClassName("cart_item"))
                .Where(x => x.FindElement(By.ClassName("inventory_item_name")).Text.Contains(itemName))
                .First()
                .FindElement(By.ClassName("cart_button"))
                .Click();
        }

        public void ClickCheckout()
        {
            _driver.FindElement(By.ClassName("checkout_button")).Click();
        }
    }
}
