using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SpecFlow.Actions.Selenium;

namespace ApertureUI.PageObjects
{
    internal class InventoryPage
    {
        private readonly IBrowserInteractions _browserInteractions;

        public InventoryPage(IBrowserInteractions browserInteractions)
        {
            _browserInteractions = browserInteractions;
        }

        private static string InventoryPageUrl => "https://www.saucedemo.com/inventory.html";


        public void AddProductToCart(string productName)
        {
            // "add-to-cart-sauce-labs-bolt-t-shirt"
            IWebElement addToCartBtn = _browserInteractions.WaitAndReturnElement(By.Id(productName));
            addToCartBtn.ClickWithRetry();
        }

        public bool HasProducts()
        {
             return _browserInteractions.WaitAndReturnElements(By.ClassName("inventory_item")).Count() > 0;
        }

        public bool IsInventoryPage()
        {
            return _browserInteractions.GetUrl().Equals(InventoryPageUrl);
        }

    }
}
