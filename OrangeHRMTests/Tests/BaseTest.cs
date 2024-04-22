using Bogus;
using NUnit.Framework;
using OrangeHRMTests.Common.Drivers;
using OrangeHRMTests.Data;
using OrangeHRMTests.Helpers;

namespace OrangeHRMTests.Tests
{
    public class BaseTest
    {
        public static Faker dataFaker => new Faker();

        public void GoToLoginPage()
        {
            WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.PageUrl);
        }

        public void TakeScreenshot()
        {
            var screenshotPath = ScreenshotHelper.TakeScreenshot(WebDriverFactory.Driver, TestContext.CurrentContext.Test.Name);
            TestContext.AddTestAttachment(screenshotPath);
        }
    }
}