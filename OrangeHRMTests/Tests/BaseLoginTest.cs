using NUnit.Framework;
using OrangeHRMTests.Common.Drivers;

namespace OrangeHRMTests.Tests
{
    public class BaseLoginTest : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            WebDriverFactory.InitializeDriver();
            GoToLoginPage();
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                TakeScreenshot();
            }

            WebDriverFactory.QuitDriver();
        }
    }
}
