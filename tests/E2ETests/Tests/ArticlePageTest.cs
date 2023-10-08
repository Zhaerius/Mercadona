using E2ETests.ModelPages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace E2ETests.Tests;

[TestClass]
public class ArticlePageTest
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
    public void CheckPermission_WithUserAccount_UserPannelOnly()
    {
        var loginPage = new LoginPage(_webDriver);
        loginPage.LoginProcess("user@mercadona.com", "@UtilisateurApp0911!");
            
        bool isRedirect = loginPage.CheckRedirect(_baseUrl + "article");
        Assert.IsTrue(isRedirect);

        var articlePage = new ArticlePage(_webDriver);
        var idLastChild = articlePage.GetAttributeLastChildMenu();
        
        Assert.AreEqual("pannel-user", idLastChild);
    }
    
    [TestCleanup]
    public void CleanUp()
    {
        _webDriver.Quit();
    }
    
}