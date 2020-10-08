using System;
using System.Linq;
using OpenQA.Selenium;

namespace SauceDemoFramework
{
    public class HomePage : PageBase
    {
        //private static readonly string _url;

        public HomePage(IWebDriver driver, Config config) : base(driver, config.HomePageUrl) { }

        private IWebElement UsernameField => _driver.FindElement(By.Id("user-name"));

        private IWebElement PasswordField => _driver.FindElement(By.Id("password"));

        private IWebElement LoginButton => _driver.FindElement(By.Id("login-button"));

        private IWebElement ErrorMessage =>
            _driver.FindElements(By.TagName("h3"))
                .Where(x => x.GetAttribute("data-test") == "error")
                .FirstOrDefault();

        public string ErrorMessageText => ErrorMessage.Text;

        public void EnterUsername(string username)
        {
            UsernameField.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            PasswordField.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }
    }
}
