using System;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;

namespace SauceDemoFramework
{
    public class InventoryPage : PageBase
    {
        //private static readonly string _url;

        public InventoryPage(IWebDriver driver, Config config) : base(driver, config.InventoryPageUrl) { }

        private ReadOnlyCollection<IWebElement> InventoryItems => _driver.FindElements(By.ClassName("inventory_item"));

        public int ProductCount => InventoryItems.Count;

        public string ShoppingCartBadgeText => _driver.FindElement(By.ClassName("shopping_cart_badge")).Text;

        public void ClickOnLinkForItemWithId(int itemId)
        {
            string tagId = $"item_{itemId}_title_link";

            _driver.FindElement(By.Id(tagId)).Click();
        }

        public void ClickInventoryButton(int itemIndex)
        {
            InventoryItems[itemIndex].FindElement(By.ClassName("btn_inventory")).Click();
        }

        public void ClickInventoryButton(string itemName)
        {
            InventoryItems
                .Where(x => x.FindElement(By.ClassName("inventory_item_name")).Text == itemName)
                .First()
                .FindElement(By.ClassName("btn_inventory"))
                .Click();
        }

        public void ClickShoppingCartLink()
        {
            _driver.FindElement(By.ClassName("shopping_cart_link")).Click();
        }

        public string GetInventoryButtonText(int itemIndex)
        {
            return InventoryItems[itemIndex].FindElement(By.ClassName("btn_inventory")).Text;
        }
    }
}
