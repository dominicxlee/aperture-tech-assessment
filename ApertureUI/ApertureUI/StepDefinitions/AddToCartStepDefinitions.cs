using System;
using ApertureUI.PageObjects;
using TechTalk.SpecFlow;

namespace ApertureUI.StepDefinitions
{
    [Binding]
    sealed class AddToCartStepDefinitions
    {
        private readonly InventoryPage _inventoryPage;

        public AddToCartStepDefinitions(InventoryPage inventoryPage)
        {
            _inventoryPage = inventoryPage;
        }

        [Given(@"the user is on the inventory page")]
        public void GivenTheUserIsOnTheInventoryPage()
        {
            _inventoryPage.IsInventoryPage().Should().BeTrue();
        }

        [When(@"the user adds ""([^""]*)"" to the cart")]
        public void WhenTheUserAddsToTheCart(string product)
        {
            _inventoryPage.AddProductToCart(product);
        }

        [Then(@"the cart icon shows ""([^""]*)""")]
        public void ThenTheCartIconShows(string numProducts)
        {
            _inventoryPage.GetCartCount().Should().Be(numProducts);
        }
    }
}
