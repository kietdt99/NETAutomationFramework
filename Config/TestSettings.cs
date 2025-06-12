using System.Text.Json;

namespace NETAutomationFramework.Config
{
    public class TestSettings
    {
        private static TestSettings? _instance;
        private static readonly object _lock = new();

        public string BaseUrl { get; private set; } = string.Empty;
        public string Browser { get; private set; } = string.Empty;
        public string Username { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;

        private TestSettings() { }

        public static TestSettings Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        _instance ??= new TestSettings();
                    }
                }
                return _instance;
            }
        }

        public static void LoadConfig(string configPath = "testsettings.json")
        {
            if (!File.Exists(configPath))
            {
                throw new FileNotFoundException($"Configuration file not found at {configPath}");
            }

            string jsonString = File.ReadAllText(configPath);
            var config = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString)
                ?? throw new InvalidOperationException("Failed to parse configuration file");

            lock (_lock)
            {
                _instance = new TestSettings
                {
                    BaseUrl = GetRequiredSetting(config, "BaseUrl"),
                    Browser = GetRequiredSetting(config, "Browser"),
                    Username = GetRequiredSetting(config, "Username"),
                    Password = GetRequiredSetting(config, "Password")
                };
            }
        }        private static string GetRequiredSetting(Dictionary<string, string> config, string key)
        {
            return config.TryGetValue(key, out string? value) && !string.IsNullOrEmpty(value)
                ? value
                : throw new InvalidOperationException($"Required setting '{key}' not found or empty in config");
        }
    }
}
