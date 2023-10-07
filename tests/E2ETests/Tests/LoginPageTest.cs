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
    public class LoginPageTest
    {
        private IWebDriver _webdriver;

        [TestInitialize]
        public void SetUp()
        {
            _webdriver = new ChromeDriver();
            _webdriver.Navigate().GoToUrl("https://localhost:7060/");
        }

        [TestMethod]
        public void FailLogin()
        {
            var loginPage = new LoginPage(_webdriver);
            loginPage.EnterLoginValue("string@supermail.com");
            loginPage.EnterPasswordValue("string");
            loginPage.ClickButtonLogin();

            string errorMessage = loginPage.GetErrorMessage();
            string expectedMessage = "Connexion impossible, merci de vérifier vos identifiants";
            
            Assert.AreEqual(errorMessage, expectedMessage);
        }

        [TestCleanup]
        public void CleanUp()
        {
            Thread.Sleep(2000);
            _webdriver.Quit();
        }
    }
}
