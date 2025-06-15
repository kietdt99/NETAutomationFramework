using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using NETAutomationFramework.Config;

namespace NETAutomationFramework.Pages
{
    public class RegisterPage : BasePage
    {
        private readonly IWebDriver _driver;

        #region Page Objects
        private readonly By _usernameField = By.Id("register-username");
        private readonly By _passwordField = By.Id("register-password");
        private readonly By _confirmPasswordField = By.Id("register-confirm-password");
        private readonly By _registerButton = By.Id("registerBtn");
        private readonly By _errorMessage = By.CssSelector(".error-message");
        #endregion

        public RegisterPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            OpenPage(TestSettings.BaseUrl + "/register");
        }

        protected override void OpenPage(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        #region Page Actions
        public void Register(string username, string password, string confirmPassword)
        {
            _driver.FindElement(_usernameField).SendKeys(username);
            _driver.FindElement(_passwordField).SendKeys(password);
            _driver.FindElement(_confirmPasswordField).SendKeys(confirmPassword);
            _driver.FindElement(_registerButton).Click();
        }

        public string GetErrorMessage()
        {
            try
            {
                return _driver.FindElement(_errorMessage).Text;
            }
            catch (NoSuchElementException)
            {
                return string.Empty;
            }
        }
        #endregion
    }
}
