using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.IO;
using System.Text.Json;

namespace NETAutomationFramework.Config
{
    public sealed class TestSettings
    {
        public static string BaseUrl { get; private set; }
        public static string Browser { get; private set; }
        public static string Username { get; private set; }
        public static string Password { get; private set; }

        private static readonly Lazy<TestSettings> _instance = new(() => new TestSettings());
        public static TestSettings Instance => _instance.Value;

        static TestSettings()
        {
            var json = File.ReadAllText("testsettings.json");
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;
            BaseUrl = root.GetProperty("BaseUrl").GetString() ?? "http://default-url.com";
            Browser = root.GetProperty("Browser").GetString() ?? "Chrome";
            Username = root.GetProperty("Username").GetString() ?? "default-username";
            Password = root.GetProperty("Password").GetString() ?? "default-password";
        }
    }
}
