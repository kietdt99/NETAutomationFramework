namespace NETAutomationFramework.Utilities
{
    public static class ElementUtils
    {
        private const int DefaultTimeoutSeconds = 10;

        /// <summary>
        /// Clears the input field and sends the specified text.
        /// </summary>
        public static void SetText(IWebDriver driver, By by, string text)
        {
            var element = WaitForElementVisible(driver, by);
            element.Clear();
            element.SendKeys(text);
        }

        /// <summary>
        /// Gets the text content of an element after waiting for it to be visible.
        /// </summary>
        public static string GetText(IWebDriver driver, By by, int timeoutSeconds = DefaultTimeoutSeconds)
            => WaitForElementVisible(driver, by, timeoutSeconds).Text;

        /// <summary>
        /// Waits for an element to be clickable and then clicks it.
        /// </summary>
        public static void Click(IWebDriver driver, By by, int timeoutSeconds = DefaultTimeoutSeconds)
            => WaitForElementClickable(driver, by, timeoutSeconds).Click();

        #region Wait Methods
        /// <summary>
        /// Waits for an element to be clickable and returns it.
        /// </summary>
        public static IWebElement WaitForElementClickable(IWebDriver driver, By by, int timeoutSeconds = DefaultTimeoutSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }

        /// <summary>
        /// Waits for an element to be visible on the page.
        /// </summary>
        public static IWebElement WaitForElementVisible(IWebDriver driver, By by, int timeoutSeconds = DefaultTimeoutSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        }

        /// <summary>
        /// Waits for an element to exist in the DOM (regardless of visibility).
        /// </summary>
        public static IWebElement WaitForElementExists(IWebDriver driver, By by, int timeoutSeconds = DefaultTimeoutSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            return wait.Until(drv => drv.FindElement(by));
        }

        /// <summary>
        /// Waits for an element to disappear from the page.
        /// </summary>
        public static bool WaitForElementInvisible(IWebDriver driver, By by, int timeoutSeconds = DefaultTimeoutSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(by));
        }

        /// <summary>
        /// Waits for the page title to match the expected value.
        /// </summary>
        public static bool WaitForTitleIs(IWebDriver driver, string expectedTitle, int timeoutSeconds = DefaultTimeoutSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            return wait.Until(drv => drv.Title == expectedTitle);
        }
        #endregion
    }
}
