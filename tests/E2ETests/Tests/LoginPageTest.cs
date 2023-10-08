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
        private string _baseUrl = "https://localhost:7060/";

        [TestInitialize]
        public void SetUp()
        {
            _webdriver = new ChromeDriver();
            _webdriver.Navigate().GoToUrl(_baseUrl);
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

        [TestMethod]
        public void SuccessLogin()
        {
            var loginPage = new LoginPage(_webdriver);
            loginPage.EnterLoginValue("administrateur@mercadona.com");
            loginPage.EnterPasswordValue("kkk"); //todo var env
            loginPage.ClickButtonLogin();

            var isRedirect = loginPage.CheckRedirect(_baseUrl + "article");

            Assert.IsTrue(isRedirect);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _webdriver.Quit();
        }
    }
}
