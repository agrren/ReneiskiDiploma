using NUnit.Framework;
using OrangeHRMTests.Common.Drivers;
using OrangeHRMTests.PageObjects;
using OrangeHRMTests.Data.Constants;

namespace OrangeHRMTests.Tests
{
    public class BaseOrangeHrmTest : BaseTest
    {
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
    }
}
