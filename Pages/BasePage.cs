using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NETAutomationFramework.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected abstract void OpenPage(string url);
    }
}