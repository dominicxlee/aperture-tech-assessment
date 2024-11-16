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
        private IWebElement Cart => _browserInteractions.WaitAndReturnElement(By.CssSelector("[data-test='shopping-cart-badge']"));


        public void AddProductToCart(string productName)
        {
            IWebElement addToCartBtn = _browserInteractions.WaitAndReturnElement(By.Id("add-to-cart-" + productName));
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

        public string GetCartCount()
        {
            return Cart.Text.Trim();
        }

    }
}
    