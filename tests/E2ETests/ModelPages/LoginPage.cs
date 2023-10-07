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
    internal class LoginPage
    {
        private readonly WebDriverWait _webDriverWait;
        private By _loginInput = By.Id("login");
        private By _passwordInput = By.Id("password");

        public LoginPage(WebDriverWait webDriverWait)
        {
            _webDriverWait = webDriverWait;
        }

        public void EnterFieldValue(string fieldValue)
        {
            var field = _webDriverWait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(_loginInput));
            field.SendKeys(fieldValue);
        }

    }
}
