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
