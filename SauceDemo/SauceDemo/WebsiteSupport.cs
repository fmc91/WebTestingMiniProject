using System;
using TechTalk.SpecFlow;
using BoDi;
using SauceDemoFramework;

namespace SauceDemoTest
{
    [Binding]
    public class WebsiteSupport
    {
        private readonly IObjectContainer _objectContainer;

        public WebsiteSupport(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeWebsite()
        {
            SauceDemoWebsite website = new SauceDemoWebsite(Browser.Chrome);

            _objectContainer.RegisterInstanceAs(website);
        }
    }
}
