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


    }
}