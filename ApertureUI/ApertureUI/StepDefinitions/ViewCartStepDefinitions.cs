using System;
using ApertureUI.PageObjects;
using TechTalk.SpecFlow;

namespace ApertureUI.StepDefinitions
{
    [Binding]
    sealed class ViewCartStepDefinitions
    {
        private readonly InventoryPage _inventoryPage;
        private readonly CartPage _cartPage;

        public ViewCartStepDefinitions(InventoryPage inventoryPage, CartPage cartPage)
        {
            _inventoryPage = inventoryPage;
            _cartPage = cartPage;
        }

        [Given(@"the user has added ""([^""]*)"" to the cart")]
        public void GivenTheUserHasAddedToTheCart(string product)
        {
            _inventoryPage.AddProductToCart(product);
        }

        [When(@"the user clicks the cart icon")]
        public void WhenTheUserClicksTheCartIcon()
        {
            _inventoryPage.GoToCart();
        }

        [Then(@"the cart page displays ""([^""]*)""")]
        public void ThenTheCartPageDisplays(string product)
        {
            _cartPage.HasProduct(product).Should().BeTrue();
        }
    }
}
