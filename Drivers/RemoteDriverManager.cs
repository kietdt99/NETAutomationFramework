namespace NETAutomationFramework.Drivers
{
    public static class RemoteDriverManager
    {
        public static IWebDriver CreateRemoteDriver(Uri gridUri, DriverType driverType)
        {
            var options = DriverOptionsFactory.CreateOptions(driverType.ToString());
            return new RemoteWebDriver(gridUri, options);
        }
    }
}