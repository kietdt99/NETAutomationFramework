using OpenQA.Selenium;
using NETAutomationFramework.Utilities;

namespace NETAutomationFramework.Pages
{
    public class HomePage : BasePage
    {
        private readonly By _welcomeMessage = By.Id("welcome-message");
        private readonly By _logoutButton = By.Id("logout-btn");

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        protected override void OpenPage(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public string GetWelcomeMessage()
        {
            return ElementUtils.GetText(Driver, _welcomeMessage);
        }

        public void Logout()
        {
            ElementUtils.Click(Driver, _logoutButton);
        }
    }
}
