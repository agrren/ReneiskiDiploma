using NUnit.Framework;
using OrangeHRMTests.Common.Drivers;
using OrangeHRMTests.PageObjects;

namespace OrangeHRMTests.Tests
{
    public class BaseTest
    {
        public BaseTest()
        {
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            WebDriverFactory.InitializeDriver();
            GenericPages.BasePage.GoToLoginPage();
            GenericPages.LoginPage.LogInToOrangeCRM();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            WebDriverFactory.QuitDriver();
        }
    }
}