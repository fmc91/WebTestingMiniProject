using System;
using TechTalk.SpecFlow;
using SauceDemoFramework;
using NUnit.Framework;
using System.Linq;

namespace SauceDemoTest
{
    [Binding]
    public class CheckoutSteps
    {
        private SauceDemoWebsite _website;

        private CheckoutStepOnePage _checkoutStepOnePage;

        private CheckoutStepTwoPage _checkoutStepTwoPage;

        public CheckoutSteps(SauceDemoWebsite website)
        {
            _website = website;

            _checkoutStepOnePage = _website.CheckoutStepOnePage;
            _checkoutStepTwoPage = _website.CheckoutStepTwoPage;
        }

        [Given(@"I am on the checkout step one page")]
        public void GivenIAmOnTheCheckoutStepOnePage()
        {
            _checkoutStepOnePage.Visit();
        }

        [Given(@"I enter the first name ""(.*)""")]
        public void GivenIEnterTheFirstName(string firstName)
        {
            _checkoutStepOnePage.EnterFirstName(firstName);
        }


        [Given(@"I enter the last name ""(.*)""")]
        public void GivenIEnterTheLastName(string lastName)
        {
            _checkoutStepOnePage.EnterLastName(lastName);
        }

        [Given(@"I enter the postal code ""(.*)""")]
        public void GivenIEnterThePostalCode(string postalCode)
        {
            _checkoutStepOnePage.EnterPostalCode(postalCode);
        }

        [Given(@"I am on the checkout step two page")]
        [When(@"I am on the checkout step two page")]
        public void WhenIAmOnTheCheckoutStepTwoPage()
        {
            _checkoutStepTwoPage.Visit();
        }

        [When(@"I click continue")]
        public void WhenIClickContinue()
        {
            _checkoutStepOnePage.ClickContinue();
        }
        
        [Then(@"I see the error message ""(.*)""")]
        public void ThenISeeTheErrorMessage(string error)
        {
            Assert.That(_checkoutStepOnePage.ErrorText, Does.Contain(error));
        }

        [Then(@"I am on the checkout step two page")]
        public void ThenIAmOnTheCheckoutStepTwoPage()
        {
            string expectedUrl = "https://www.saucedemo.com/checkout-step-two.html";

            Assert.That(_website.CurrentUrl, Is.EqualTo(expectedUrl));
        }

        [Then(@"the following items are displayed")]
        public void ThenTheFollowingItemsAreDisplayed(Table table)
        {
            foreach(TableRow row in table.Rows)
            {
                Assert.That(_checkoutStepTwoPage.GetItemNames(), Does.Contain(row[0]));
            }
        }

        [Then(@"the subtotal is correct")]
        public void ThenTheSubtotalIsCorrect()
        {
            float expectedSubtotal = _checkoutStepTwoPage.GetItemPrices().Sum(x => Single.Parse(x));

            Assert.That(_checkoutStepTwoPage.SubtotalText, Does.Contain(expectedSubtotal.ToString()));
        }

        [When(@"I click finish")]
        public void WhenIClickFinish()
        {
            _checkoutStepTwoPage.ClickFinish();
        }

        [When(@"I click cancel"), Scope(Tag = "checkout-step-one")]
        public void WhenIClickCancelStepOne()
        {
            _checkoutStepOnePage.ClickCancel();
        }

        [When(@"I click cancel"), Scope(Tag = "checkout-step-two")]
        public void WhenIClickCancelStepTwo()
        {
            _checkoutStepTwoPage.ClickCancel();
        }


        [Then(@"I am on the checkout complete page")]
        public void ThenIAmOnTheCheckoutCompletePage()
        {
            string expectedUrl = "https://www.saucedemo.com/checkout-complete.html";

            Assert.That(_website.CurrentUrl, Is.EqualTo(expectedUrl));
        }

        [AfterScenario]
        public void ExitSite()
        {
            _website.Exit();
        }
    }
}
