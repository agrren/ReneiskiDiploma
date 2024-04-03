﻿using Bogus;
using NUnit.Framework;
using OrangeHRMTests.Common.Drivers;
using OrangeHRMTests.Data;
using OrangeHRMTests.Data.Constants;
using OrangeHRMTests.Helpers;
using OrangeHRMTests.PageObjects;

namespace OrangeHRMTests.Tests
{
    public class BaseTest
    {
        public static Faker dataFaker => new Faker();

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            WebDriverFactory.InitializeDriver();
            GoToLoginPage();
            GenericPages.LoginPage.LogInToOrangeCRM();
        }

        [SetUp]
        public void SetUp()
        {
            WebDriverFactory.Driver.Navigate().Refresh();
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.DashboardButtonName);
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                TakeScreenshot();
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() => WebDriverFactory.QuitDriver();

        public void GoToLoginPage() => WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.PageUrl);

        private void TakeScreenshot()
        {
            var screenshotPath = ScreenshotHelper.TakeScreenshot(WebDriverFactory.Driver, TestContext.CurrentContext.Test.Name);
            TestContext.AddTestAttachment(screenshotPath);
        }
    }
}