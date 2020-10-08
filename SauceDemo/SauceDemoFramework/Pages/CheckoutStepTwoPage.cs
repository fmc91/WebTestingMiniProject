using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace SauceDemoFramework
{
    public class CheckoutStepTwoPage : PageBase
    {
        public CheckoutStepTwoPage(IWebDriver driver, Config config) : base(driver, config.CheckoutStepTwoUrl) { }

        public string SubtotalText => _driver.FindElement(By.ClassName("summary_subtotal_label")).Text;

        public string TaxText => _driver.FindElement(By.ClassName("summary_tax_label")).Text;

        public string TotalText => _driver.FindElement(By.ClassName("summary_total_label")).Text;

        public IEnumerable<string> GetItemNames()
        {
            return _driver.FindElements(By.ClassName("cart_item"))
                       .Select(x => x.FindElement(By.ClassName("inventory_item_name")).Text);
        }

        public IEnumerable<string> GetItemPrices()
        {
            return _driver.FindElements(By.ClassName("cart_item"))
                       .Select(x => x.FindElement(By.ClassName("inventory_item_price")).Text.Remove(0,1));
        }

        public void ClickFinish()
        {
            _driver.FindElement(By.ClassName("cart_button")).Click();
        }

        public void ClickCancel()
        {
            _driver.FindElement(By.ClassName("cart_cancel_link")).Click();
        }
    }
}
