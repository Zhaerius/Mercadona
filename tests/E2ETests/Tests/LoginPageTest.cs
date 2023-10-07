using E2ETests.ModelPages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2ETests.Tests
{
    [TestClass]
    internal class LoginPageTest
    {
        private IWebDriver _webdriver;
        private WebDriverWait _webDriverWait;

        [TestInitialize]
        public void SetUp()
        {
            _webdriver = new ChromeDriver();
            _webDriverWait = new WebDriverWait(_webdriver, TimeSpan.FromSeconds(20));
            _webdriver.Navigate().GoToUrl("https://localhost:7060/");
        }

        [TestMethod]
        public void HomeLoginTest()
        {
            var loginPage = new LoginPage(_webDriverWait);
            loginPage.EnterFieldValue("gaetan.demazeux@outlook.com");
        }

        [TestCleanup]
        public void CleanUp()
        {
            Thread.Sleep(3000);
            _webdriver.Quit();
        }
    }
}
