using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace NETAutomationFramework.Drivers
{
    public static class DriverOptionsFactory
    {
        public static DriverOptions CreateOptions(string browser)
        {
            return browser.ToLower() switch
            {
                "chrome" => new ChromeOptions(),
                "firefox" => new FirefoxOptions(),
                "edge" => new EdgeOptions(),
                _ => throw new ArgumentException($"Browser {browser} is not supported.")
            };
        }
    }
}
