using System;
using System.Linq;
using OpenQA.Selenium;

namespace SauceDemoFramework
{
    public class CheckoutStepOnePage : PageBase
    {
        public CheckoutStepOnePage(IWebDriver driver, Config config) : base(driver, config.CheckoutStepOneUrl) { }

        public string ErrorText
        {
            get => _driver.FindElements(By.TagName("h3"))
                       .Where(x => x.GetAttribute("data-test") == "error")
                       .First()
                       .Text;
        }

        public void EnterFirstName(string firstName)
        {
            _driver.FindElement(By.Id("first-name")).SendKeys(firstName);
        }

        public void EnterLastName(string lastName)
        {
            _driver.FindElement(By.Id("last-name")).SendKeys(lastName);
        }

        public void EnterPostalCode(string postalCode)
        {
            _driver.FindElement(By.Id("postal-code")).SendKeys(postalCode);
        }

        public void ClickContinue()
        {
            _driver.FindElement(By.ClassName("cart_button")).Click();
        }

        public void ClickCancel()
        {
            _driver.FindElement(By.ClassName("cart_cancel_link")).Click();
        }
    }
}
