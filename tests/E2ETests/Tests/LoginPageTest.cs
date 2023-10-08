using E2ETests.ModelPages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace E2ETests.Tests
{
    [TestClass]
    public class LoginPageTest
    {
        private IWebDriver _webDriver = null!;
        private readonly string _baseUrl = "https://localhost:7060/";

        [TestInitialize]
        public void SetUp()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Navigate().GoToUrl(_baseUrl);
        }

        [TestMethod]
        public void FailLogin()
        {
            var loginPage = new LoginPage(_webDriver);
            loginPage.LoginProcess("string@supermail.com", "string");

            string errorMessage = loginPage.GetErrorMessage();
            string expectedMessage = "Connexion impossible, merci de vérifier vos identifiants";
            
            Assert.AreEqual(errorMessage, expectedMessage);
        }

        [TestMethod]
        public void SuccessLogin()
        {
            var loginPage = new LoginPage(_webDriver);
            loginPage.LoginProcess("test@mercadona.com", "@TesteurApp0911!");

            bool isRedirect = loginPage.CheckRedirect(_baseUrl + "article");

            Assert.IsTrue(isRedirect);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _webDriver.Quit();
        }
    }
}
