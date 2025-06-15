using NETAutomationFramework.Config;
using NETAutomationFramework.Drivers;
using NETAutomationFramework.Pages;

namespace NETAutomationFramework.TestCases.AuthService
{
    public class LoginTests : IDisposable
    {
        public LoginTests()
        {
            // Setup can be done here or in hooks
        }
        [Fact]
        public void Login_WithValidCredentials_ShouldSucceed()
        {
            var driver = WebDriverManager.Driver;
            driver.Navigate().GoToUrl(TestSettings.BaseUrl);
            var loginPage = new LoginPage(driver);
            var homePage = loginPage.LoginAndGoToHome(TestSettings.Username, TestSettings.Password);
            Assert.NotNull(homePage.GetWelcomeMessage());
        }

        public void Dispose()
        {
            WebDriverManager.Cleanup();
        }
    }
}