using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SauceDemoFramework
{
    public enum Browser { Chrome, Firefox }

    internal static class DriverFactory
    {
        internal static IWebDriver Create(Browser browser)
        {
            return Create(browser, 10, 10);
        }

        internal static IWebDriver Create(Browser browser, int pageLoad, int implicitWait)
        {
            IWebDriver driver = browser switch
            {
                Browser.Chrome => CreateChrome(),
                Browser.Firefox => CreateFirefox(),
                _ => throw new ArgumentException()
            };

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoad);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWait);

            return driver;
        }

        private static IWebDriver CreateChrome()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--incognito");

            return new ChromeDriver(options);
        }

        private static IWebDriver CreateFirefox()
        {
            FirefoxProfile profile = new FirefoxProfile();
            profile.SetPreference("browser.privatebrowsing.autostart", true);
            
            FirefoxOptions options = new FirefoxOptions();
            options.Profile = profile;

            return new FirefoxDriver(options);
        }
    }
}
