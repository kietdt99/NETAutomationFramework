using System;
using Xunit;
using NETAutomationFramework.Drivers;
using NETAutomationFramework.Pages;
using NETAutomationFramework.Config;
using NETAutomationFramework.Utilities;

namespace NETAutomationFramework.TestCases.AuthService
{
    public class LoginTests : IDisposable
    {
        public LoginTests()
        {
            // Setup can be done here or in hooks
        }        [Fact]
        public void Login_WithValidCredentials_ShouldSucceed()
        {
            TestSettings.LoadConfig();
            var driver = WebDriverManager.Driver;
            var settings = TestSettings.Instance;
            driver.Navigate().GoToUrl(settings.BaseUrl);
            var loginPage = new LoginPage(driver);
            var homePage = loginPage.LoginAndGoToHome(settings.Username, settings.Password);
            Assert.NotNull(homePage.GetWelcomeMessage());
        }

        public void Dispose()
        {
            WebDriverManager.Cleanup();
        }
    }
}