using System.IO;
using System.Text.Json;

namespace NETAutomationFramework.Utilities
{
    public static class TestSettings
    {
        public static string BaseUrl { get; private set; }
        public static string Browser { get; private set; }
        public static string Username { get; private set; }
        public static string Password { get; private set; }

        static TestSettings()
        {
            var json = File.ReadAllText("testsettings.json");
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;
            BaseUrl = root.GetProperty("BaseUrl").GetString();
            Browser = root.GetProperty("Browser").GetString();
            Username = root.GetProperty("Username").GetString();
            Password = root.GetProperty("Password").GetString();
        }
    }
}
