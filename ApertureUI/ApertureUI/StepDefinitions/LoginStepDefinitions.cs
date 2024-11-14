using ApertureUI.PageObjects;
using TechTalk.SpecFlow.Infrastructure;

namespace ApertureUI.StepDefinitions
{
    [Binding]
    sealed class LoginStepDefinitions
    {
        private readonly LoginPage _loginPage;
        private readonly ISpecFlowOutputHelper _specflowOutputHelper;

        public LoginStepDefinitions(LoginPage loginPage, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _loginPage = loginPage;
            _specflowOutputHelper = specFlowOutputHelper;
        }

        [Given(@"the username is ""([^""]*)""")]
        public void GivenTheUsernameIs(string username)
        {
            _loginPage.EnterUsername(username);
        }

        [Given(@"the password is ""([^""]*)""")]
        public void GivenThePasswordIs(string password)
        {
            _loginPage.EnterPassword(password);
        }

        [When(@"the login button is pressed")]
        public void WhenTheLoginButtonIsPressed()
        {
            _loginPage.ClickLogin();
        }

        [Then(@"the user is logged in")]
        public void ThenTheUserIsLoggedIn()
        {
            _loginPage.IsLoggedIn().Should().Be(true);
        }

        [Then(@"the user is not logged in")]
        public void ThenTheUserIsNotLoggedIn()
        {
            _loginPage.IsLoggedIn().Should().Be(false);
        }


    }
}
