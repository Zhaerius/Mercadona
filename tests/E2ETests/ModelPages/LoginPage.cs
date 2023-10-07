using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2ETests.ModelPages
{
    public class LoginPage
    {
        private readonly WebDriverWait _webDriverWait;
        private readonly IWebDriver _webDriver;
        private By _loginInput = By.Id("login");
        private By _passwordInput = By.Id("password");
        private By _alertMessage = By.CssSelector("#alert-message .mud-alert-message");
        private By _buttonSubmit = By.TagName("button");

        public LoginPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(20));
        }

        public void EnterLoginValue(string fieldValue)
        {
            var field = _webDriverWait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(_loginInput));
            field.SendKeys(fieldValue);
        }
        
        public void EnterPasswordValue(string fieldValue)
        {
            var field = _webDriverWait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(_passwordInput));
            field.SendKeys(fieldValue);
        }

        public void ClickButtonLogin()
        {
            var btn = _webDriverWait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(_buttonSubmit));
            btn.Click();
        }

        public string? GetErrorMessage()
        {
            return _webDriver.FindElement(_alertMessage).Text;
        }

    }
}
