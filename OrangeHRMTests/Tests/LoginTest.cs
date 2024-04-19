using NUnit.Framework.Legacy;
using NUnit.Framework;
using OrangeHRMTests.Data;
using OrangeHRMTests.PageObjects;
using NUnit.Allure.Core;

namespace OrangeHRMTests.Tests
{
    [TestFixture]
    [AllureNUnit]
    public class LoginTest : BaseLoginTest
    {
        [Test]
        public void A_ValidLoginTest()
        {
            GenericPages.LoginPage.InputUserName(TestSettings.Username);
            GenericPages.LoginPage.InputPassword(TestSettings.Password);
            GenericPages.LoginPage.ClickLoginButton();

            ClassicAssert.AreEqual(Data.TestSettings.DashboardPageUrl, GenericPages.LoginPage.GetCurrentPageUrl());
        }

        [Test]
        public void B_InValidLoginTest()
        {
            GenericPages.LoginPage.InputUserName(TestSettings.InValidUsername);
            GenericPages.LoginPage.InputPassword(TestSettings.InValidPassword);
            GenericPages.LoginPage.ClickLoginButton();

            ClassicAssert.AreEqual("Invalid credentials", GenericPages.LoginPage.GetInvalidMessageTextResult());
        }
    }
}
