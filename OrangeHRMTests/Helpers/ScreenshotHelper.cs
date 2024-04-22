using Allure.Net.Commons;
using NUnit.Framework;
using OpenQA.Selenium;

namespace OrangeHRMTests.Helpers
{
    public static class ScreenshotHelper
    {
        public static string TakeScreenshot(IWebDriver driver, string screenshotName)
        {
            var name = screenshotName.Length <= 46 ? screenshotName : screenshotName.Substring(0, 46);
            var fileNameBase = $"{name}_{DateTime.Now:yyyyMMdd_HHmmss}.png";

            var screenshotsDirectory = $"{AppDomain.CurrentDomain.BaseDirectory}\\DriverErrorsScreenshots";

            if (!Directory.Exists(screenshotsDirectory))
            {
                Directory.CreateDirectory(screenshotsDirectory);
            }

            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            var screenshotFilePath = Path.Combine(screenshotsDirectory, fileNameBase);

            screenshot.SaveAsFile(screenshotFilePath);

            TestContext.AddTestAttachment(screenshotFilePath);

            AllureApi.AddAttachment(TestContext.CurrentContext.Test.Name, "image/png", screenshotFilePath);

            return screenshotFilePath;
        }
    }
}
