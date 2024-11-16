using OpenQA.Selenium;
using SpecFlow.Actions.Selenium;

namespace ApertureUI.PageObjects
{
    public class CartPage
    {
        private readonly IBrowserInteractions _browserInteractions;

        public CartPage(IBrowserInteractions browserInteractions)
        {
            _browserInteractions = browserInteractions;
        }

        private IWebElement CheckoutButton => _browserInteractions.WaitAndReturnElement(By.Id("checkout"));

        public bool HasProduct(string product)
        {
            _browserInteractions.WaitAndReturnElement(By.Id("remove-" + product));
            return true;
        }

        public void ClickCheckout()
        {
            CheckoutButton.ClickWithRetry();
        }


    }
}
