using ApertureUI.PageObjects;
using TechTalk.SpecFlow;

namespace ApertureUI.Features.Hooks
{
    [Binding]
    public sealed class Hooks
    {

        [BeforeScenario]
        public void BeforeScenario(LoginPage loginPage)
        {
            loginPage.GoTo();
        }

        [BeforeScenario("RequiresLogin")]
        public void PerformLogin(LoginPage loginPage)
        {
            loginPage.GoTo();
            loginPage.EnterUsername("standard_user");
            loginPage.EnterPassword("secret_sauce");
            loginPage.ClickLogin();
        }


    }
}