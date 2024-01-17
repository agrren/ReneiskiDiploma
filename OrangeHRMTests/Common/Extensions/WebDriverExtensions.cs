using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OrangeHRMTests.Common.Drivers;

namespace OrangeHRMTests.Common.Extensions
{
    public static class WebDriverExtensions
    {
        public static WebDriverWait GetWebDriverWait(this IWebDriver driver, int timeoutSeconds = 15, TimeSpan? pollingInterval = null, params Type[] exceptionTypes)
        {
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            if (pollingInterval != null)
            {
                webDriverWait.PollingInterval = (TimeSpan)pollingInterval;
            }

            webDriverWait.IgnoreExceptionTypes(exceptionTypes);

            return webDriverWait;
        }

        public static IWebElement GetWebElementWhenExist(this IWebDriver driver, By by) => driver.GetWebDriverWait().Until(drv => drv.FindElement(by));

        public static void SwitchToTheLastWindow() => WebDriverFactory.Driver.SwitchTo().Window(WebDriverFactory.Driver.WindowHandles.ToList().Last());

        public static void SwitchToTheFirstWindow() => WebDriverFactory.Driver.SwitchTo().Window(WebDriverFactory.Driver.WindowHandles.ToList().First());
    }
}