using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SpecFlow.Actions.Selenium;

namespace ApertureUI.PageObjects
{
    public class CheckoutPage
    {
        private readonly IBrowserInteractions _browserInteractions;

        public CheckoutPage(IBrowserInteractions browserInteractions)
        {
            _browserInteractions = browserInteractions;
        }

        private static string PageUrl => "https://www.saucedemo.com/checkout-step-one.html";
        private IWebElement FirstnameInput => _browserInteractions.WaitAndReturnElement(By.Id("first-name"));
        private IWebElement LastnameInput => _browserInteractions.WaitAndReturnElement(By.Id("last-name"));
        private IWebElement PostCodeInput => _browserInteractions.WaitAndReturnElement(By.Id("postal-code"));
        private IWebElement ContinueButton => _browserInteractions.WaitAndReturnElement(By.Id("continue"));

        public bool IsCheckoutPage()
        {
            return _browserInteractions.GetUrl().Equals(PageUrl);
        }

        public void EnterFirstName(string firstName)
        {
            FirstnameInput.SendKeysWithClear(firstName);
        }

        public void EnterLastName(string lastName)
        {
            LastnameInput.SendKeysWithClear(lastName);
        }

        public void EnterPostCode(string postCode)
        {
            PostCodeInput.SendKeysWithClear(postCode);
        }

        public void ClickContinue()
        {
            ContinueButton.ClickWithRetry();
        }

    }
}
