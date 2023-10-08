using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace E2ETests.ModelPages
{
    public class LoginPage
    {
        private readonly WebDriverWait _webDriverWait;
        private readonly IWebDriver _webDriver;
        private readonly By _loginInput = By.Id("login");
        private readonly By _passwordInput = By.Id("password");
        private readonly By _alertMessage = By.CssSelector("#alert-message .mud-alert-message");
        private readonly By _buttonSubmit = By.TagName("button");

        public LoginPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(20));
        }

        public void LoginProcess(string userName, string password)
        {
            EnterLoginValue(userName);
            EnterPasswordValue(password);
            ClickButtonLogin();
        }
        
        public string GetErrorMessage()
        {
            return _webDriver.FindElement(_alertMessage).Text;
        }
        
        public bool CheckRedirect(string urlExpected)
        {
            return _webDriverWait.Until(ExpectedConditions.UrlToBe(urlExpected));
        }
        
        private void EnterLoginValue(string fieldValue)
        {
            var field = _webDriverWait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(_loginInput));
            field.SendKeys(fieldValue);
        }
        
        private void EnterPasswordValue(string fieldValue)
        {
            var field = _webDriverWait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(_passwordInput));
            field.SendKeys(fieldValue);
        }

        private void ClickButtonLogin()
        {
            var btn = _webDriverWait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(_buttonSubmit));
            btn.Click();
        }
    }
}
