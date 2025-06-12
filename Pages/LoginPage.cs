namespace NETAutomationFramework.Pages
{
    public class LoginPage : BasePage
    {
        private readonly IWebDriver _driver;

        #region Page Objects
        private readonly By _usernameField = By.Id("username");
        private readonly By _passwordField = By.Id("password");
        private readonly By _loginButton = By.Id("loginBtn");
        private readonly By _errorMessage = By.CssSelector(".error-message");
        #endregion

        public LoginPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            OpenPage(TestSettings.Instance.BaseUrl + "/login");
        }

        protected override void OpenPage(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        #region Page Actions
        public void Login(string username, string password)
        {
            ElementUtils.SetText(_driver, _usernameField, username);
            ElementUtils.SetText(_driver, _passwordField, password);
            ElementUtils.Click(_driver, _loginButton);
        }

        public HomePage LoginAndGoToHome(string username, string password)
        {
            Login(username, password);
            return new HomePage(_driver);
        }

        public string GetErrorMessage()
        {
            try
            {
                return ElementUtils.GetText(_driver, _errorMessage);
            }
            catch (NoSuchElementException)
            {
                return string.Empty;
            }
        }
        #endregion
    }
}