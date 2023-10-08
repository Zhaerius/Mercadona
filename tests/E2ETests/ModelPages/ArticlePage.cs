using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace E2ETests.ModelPages
{
    public class ArticlePage
    {
        private readonly WebDriverWait _webDriverWait;
        private readonly By _navGroup = By.CssSelector("#nav-menu .mud-nav-group");

        public ArticlePage(IWebDriver webDriver)
        {
            _webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(20));
        }

        public string GetAttributeLastChildMenu()
        {
            var elements = _webDriverWait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(_navGroup));
            return elements.Last().GetAttribute("id");           
        }
    }

}
