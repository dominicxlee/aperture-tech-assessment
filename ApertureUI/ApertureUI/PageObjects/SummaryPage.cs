using OpenQA.Selenium;
using SpecFlow.Actions.Selenium;

namespace ApertureUI.PageObjects
{
    public class SummaryPage
    {
        private readonly IBrowserInteractions _browserInteractions;

        public SummaryPage(IBrowserInteractions browserInteractions)
        {
            _browserInteractions = browserInteractions;
        }

        private static string PageUrl => "https://www.saucedemo.com/checkout-step-two.html";
        private IWebElement SubTotalText => _browserInteractions.WaitAndReturnElement(By.CssSelector("[data-test='subtotal-label']"));

        public bool IsSummaryPage()
        {
            return _browserInteractions.GetUrl().Equals(PageUrl);
        }

        public bool HasProduct(string product)
        {
            IEnumerable<IWebElement> products = _browserInteractions.WaitAndReturnElements(By.CssSelector("[data-test='inventory-item-name']"));
            foreach (var item in products)
            {
                if (item.Text.ToLower().Replace(" ", "-").Equals(product))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckSubTotal(string subTotal)
        {
            return SubTotalText.Text.Contains(subTotal);
        }


    }
}
