using System.Security.Policy;
using OpenQA.Selenium;
using SpecFlow.Actions.Selenium;

namespace ApertureUI.PageObjects
{
    public class LoginPage
    {

        private readonly IBrowserInteractions _browserInteractions;

        public LoginPage(IBrowserInteractions browserInteractions)
        {
            _browserInteractions = browserInteractions;
        }

        private static string PageUrl => "https://www.saucedemo.com/";
        private static string LoggedInUrl => "https://www.saucedemo.com/inventory.html";
        private IWebElement UsernameInput => _browserInteractions.WaitAndReturnElement(By.Id("user-name"));
        private IWebElement PasswordInput => _browserInteractions.WaitAndReturnElement(By.Id("password"));
        private IWebElement LoginButton => _browserInteractions.WaitAndReturnElement(By.Id("login-button"));


        public void GoTo()
        {
            _browserInteractions.GoToUrl(PageUrl);
        }

        public void EnterUsername(string username)
        {
            UsernameInput.SendKeysWithClear(username);
        }

        public void EnterPassword(string password)
        {
            PasswordInput.SendKeysWithClear(password);
        }

        public void ClickLogin()
        {
            LoginButton.ClickWithRetry();
        }

        public bool IsLoggedIn()
        {
            try
            {
                string url = _browserInteractions.WaitUntil(
                            () => _browserInteractions.GetUrl(), 
                            result => LoggedInUrl.Equals(result));
                return true;
            } catch
            {
                return false;
            }
        }


    }
}
