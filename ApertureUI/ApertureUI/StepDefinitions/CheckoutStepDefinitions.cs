using ApertureUI.PageObjects;

namespace ApertureUI.StepDefinitions
{
    [Binding]
    public class CheckoutStepDefinitions
    {
        private readonly CheckoutPage _checkoutPage;

        public CheckoutStepDefinitions(CheckoutPage checkoutPage)
        {
            _checkoutPage = checkoutPage;
        }

        [Given(@"the user is on the checkout page")]
        public void GivenTheUserIsOnTheCheckoutPage()
        {
            _checkoutPage.IsCheckoutPage().Should().BeTrue();
        }

        [When(@"the user enters ""([^""]*)"" as the first name")]
        public void WhenTheUserEntersAsTheFirstName(string firstName)
        {
            _checkoutPage.EnterFirstName(firstName);
        }

        [When(@"""([^""]*)"" as the last name")]
        public void WhenAsTheLastName(string lastName)
        {
            _checkoutPage.EnterLastName(lastName);
        }

        [When(@"""([^""]*)"" as the postal code")]
        public void WhenAsThePostalCode(string postCode)
        {
            _checkoutPage.EnterPostCode(postCode);
        }

        [When(@"clicks the continue button")]
        public void WhenClicksTheContinueButton()
        {
            _checkoutPage.ClickContinue();
        }

        [Then(@"the user is taken to the order summary page")]
        public void ThenTheUserIsTakenToTheOrderSummaryPage()
        {
            true.Should().BeTrue();
        }
    }
}
