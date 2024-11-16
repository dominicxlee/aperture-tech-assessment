using ApertureUI.PageObjects;

namespace ApertureUI.StepDefinitions
{
    [Binding]
    sealed class InventoryStepDefinitions
    {
        private readonly InventoryPage _inventoryPage;

        public InventoryStepDefinitions(InventoryPage inventoryPage)
        {
            _inventoryPage = inventoryPage;
        }

        [Given(@"the user is logged in")]
        public void GivenTheUserIsLoggedIn()
        {
            _inventoryPage.IsInventoryPage().Should().BeTrue();
        }

        [Then(@"a list of products is displayed")]
        public void ThenAListOfProductsIsDisplayed()
        {
            _inventoryPage.HasProducts().Should().BeTrue();
        }


    }
}
