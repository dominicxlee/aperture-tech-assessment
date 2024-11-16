using System;
using ApertureUI.PageObjects;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ApertureUI.StepDefinitions
{
    [Binding]
    public class ConfirmOrderStepDefinitions
    {
        private readonly InventoryPage _inventoryPage;
        private readonly CartPage _cartPage;
        private readonly CheckoutPage _checkoutPage;
        private readonly SummaryPage _summaryPage;

        public ConfirmOrderStepDefinitions(InventoryPage inventoryPage, CartPage cartPage, CheckoutPage checkoutPage, SummaryPage summaryPage)
        {
            _inventoryPage = inventoryPage;
            _cartPage = cartPage;
            _checkoutPage = checkoutPage;
            _summaryPage = summaryPage;
        }


        [Given(@"the user has added the following products to the cart:")]
        public void GivenTheUserHasAddedTheFollowingProductsToTheCart(Table table)
        {
            foreach (var row in table.Rows)
            {
                var productName = row["Product Name"];
                _inventoryPage.AddProductToCart(productName);
            }
        }

        [When(@"the user views the cart")]
        public void WhenTheUserViewsTheCart()
        {
            _inventoryPage.GoToCart();
        }

        [When(@"proceeds to checkout")]
        public void WhenProceedsToCheckout()
        {
            _cartPage.ClickCheckout();
        }

        [When(@"fills out the checkout form with the following details:")]
        public void WhenFillsOutTheCheckoutFormWithTheFollowingDetails(Table table)
        {
            var formDetails = table.CreateSet<CheckoutForm>().First();
            _checkoutPage.EnterFirstName(formDetails.FirstName);
            _checkoutPage.EnterLastName(formDetails.LastName);
            _checkoutPage.EnterPostCode(formDetails.PostalCode);
        }

        [When(@"confirms the order")]
        public void WhenConfirmsTheOrder()
        {
            _checkoutPage.ClickContinue();
        }

        [Then(@"the order summary page is displayed")]
        public void ThenTheOrderSummaryPageIsDisplayed()
        {
            _summaryPage.IsSummaryPage().Should().BeTrue();
        }

        [Then(@"the following products are listed in the summary:")]
        public void ThenTheFollowingProductsAreListedInTheSummary(Table table)
        {
            foreach (var row in table.Rows)
            {
                var productName = row["Product Name"];
                _summaryPage.HasProduct(productName).Should().BeTrue();
            }
        }
    }


    public class CheckoutForm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PostalCode { get; set; }
    }

}
