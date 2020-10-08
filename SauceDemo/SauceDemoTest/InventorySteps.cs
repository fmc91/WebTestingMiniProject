using System;
using TechTalk.SpecFlow;
using SauceDemoFramework;
using NUnit.Framework;

namespace SauceDemoTest
{
    [Binding]
    public class InventorySteps
    {
        private SauceDemoWebsite _website;

        private InventoryPage _inventoryPage;

        private CartPage _cartPage;

        public InventorySteps(SauceDemoWebsite website)
        {
            _website = website;

            _inventoryPage = _website.InventoryPage;
            _cartPage = _website.CartPage;
        }

        [Given(@"I am on the inventory page")]
        public void GivenIAmOnTheInventoryPage()
        {
            _inventoryPage.Visit();
        }
        
        [When(@"I click on a link for item with id (.*)")]
        public void WhenIClickOnALinkForItemWithId(int id)
        {
            _inventoryPage.ClickOnLinkForItemWithId(id);
        }
        
        [Then(@"I am taken to a page showing me the details of the item with id (.*)")]
        public void ThenIAmTakenToAPageShowingMeTheDetailsOfTheItemWithId(int id)
        {
            string expectedUrl = "https://www.saucedemo.com/inventory-item.html?id=" + id.ToString();

            Assert.That(_website.CurrentUrl, Is.EqualTo(expectedUrl));
        }

        [When(@"I add (.*) items to my cart")]
        public void WhenIAddItemsToMyCart(int n)
        {
            if (n > _inventoryPage.ProductCount)
                throw new InvalidOperationException("Number of products to add is greater than the number available");

            for (int i = 0; i < n; ++i)
                _inventoryPage.ClickInventoryButton(i);
        }

        [When(@"I add item (.*) to my cart")]
        public void WhenIAddItemToMyCart(int n)
        {
            _inventoryPage.ClickInventoryButton(n - 1);
        }

        [When(@"I remove item (.*) from my cart")]
        public void WhenIRemoveItemFromMyCart(int n)
        {
            _inventoryPage.ClickInventoryButton(n - 1);
        }


        [Then(@"the shopping cart displays (.*)")]
        public void ThenTheShoppingCartDisplays(string n)
        {
            Assert.That(_inventoryPage.ShoppingCartBadgeText, Is.EqualTo(n));
        }

        [Then(@"the inventory button for item (.*) displays ""(.*)""")]
        public void ThenTheInventoryButtonForItemDisplays(int n, string text)
        {
            Assert.That(_inventoryPage.GetInventoryButtonText(n - 1), Is.EqualTo(text));
        }

        [Given(@"I add the item called (.*) to my cart")]
        public void GivenIAddTheItemCalledToMyCart(string itemName)
        {
            _inventoryPage.ClickInventoryButton(itemName);
        }

        [Given(@"I have added the following items to my cart")]
        public void GivenIHaveAddedTheFollowingItemsToMyCart(Table table)
        {
            _inventoryPage.Visit();

            foreach (TableRow row in table.Rows)
            {
                _inventoryPage.ClickInventoryButton(row[0]);
            }
        }

        [When(@"I click on the shopping cart")]
        public void WhenIClickOnTheShoppingCart()
        {
            _inventoryPage.ClickShoppingCartLink();
        }

        [Then(@"I am on the cart page")]
        public void ThenIAmOnTheCartPage()
        {
            string expectedUrl = "https://www.saucedemo.com/cart.html";

            Assert.That(_website.CurrentUrl, Is.EqualTo(expectedUrl));
        }

        [Then(@"the item called (.*) is in my cart")]
        public void ThenTheItemCalledIsInMyCart(string itemName)
        {
            Assert.That(_cartPage.GetItemNames(), Does.Contain(itemName));
        }

        [Given(@"I have added the item called (.*) to my cart")]
        public void GivenIHaveAddedTheItemCalledToMyCart(string itemName)
        {
            _inventoryPage.Visit();
            _inventoryPage.ClickInventoryButton(itemName);
        }

        [Given(@"I am on the cart page")]
        public void GivenIAmOnTheCartPage()
        {
            _cartPage.Visit();
        }

        [When(@"I remove the item called (.*) from my cart")]
        public void WhenIRemoveTheItemCalledFromMyCart(string itemName)
        {
            _cartPage.ClickRemoveOnItemWithName(itemName);
        }

        [Then(@"The item called (.*) is not in my cart")]
        public void ThenTheItemCalledIsNotInMyCart(string itemName)
        {
            Assert.That(_cartPage.GetItemNames(), Does.Not.Contain(itemName));
        }

        [When(@"I click checkout")]
        public void WhenIClickCheckout()
        {
            _cartPage.ClickCheckout();
        }

        [Then(@"I am on the checkout step one page")]
        public void ThenIAmOnTheCheckoutStepOnePage()
        {
            string expectedUrl = "https://www.saucedemo.com/checkout-step-one.html";

            Assert.That(_website.CurrentUrl, Is.EqualTo(expectedUrl));
        }


        [AfterScenario]
        public void ExitSite()
        {
            _website.Exit();
        }
    }
}
