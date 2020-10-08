using System;
using TechTalk.SpecFlow;
using SauceDemoFramework;
using NUnit.Framework;

namespace SauceDemoTest
{
    [Binding]
    public class LoginSteps
    {
        private SauceDemoWebsite _website;

        private HomePage _homePage;

        public LoginSteps(SauceDemoWebsite website)
        {
            _website = website;

            _homePage = _website.HomePage;
        }

        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            _homePage.Visit();
        }
        
        [Given(@"I enter the username ""(.*)""")]
        public void GivenIEnterTheUsername(string username)
        {
            if (_homePage == null || !_homePage.ValidState)
                throw new InvalidOperationException("Precondition not met - first navigate to the home page");

            _homePage.EnterUsername(username);
        }
        
        [Given(@"I enter the password ""(.*)""")]
        public void GivenIEnterThePassword(string password)
        {
            if (_homePage == null || !_homePage.ValidState)
                throw new InvalidOperationException("Precondition not met - first navigate to the home page");

            _homePage.EnterPassword(password);
        }
        
        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            if (_homePage == null || !_homePage.ValidState)
                throw new InvalidOperationException("Precondition not met - first navigate to the home page");

            _homePage.ClickLoginButton();
        }
        
        [Then(@"I should see the error message ""(.*)""")]
        public void ThenIShouldSeeTheErrorMessage(string message)
        {
            Assert.That(_homePage.ErrorMessageText, Does.Contain(message));
        }

        [Then(@"I am on the inventory page")]
        public void ThenIAmOnTheInventoryPage()
        {
            Assert.That(_website.CurrentUrl, Is.EqualTo("https://www.saucedemo.com/inventory.html"));
        }

        [AfterScenario]
        public void ExitSite()
        {
            _website.Exit();
        }
    }
}
