using NUnit.Framework.Legacy;
using NUnit.Framework;
using OrangeHRMTests.Data.Constants;
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

            GenericPages.BasePage.TopBarMenu.ClickArrowButton();
            GenericPages.BasePage.TopBarMenu.ClickUserDropdownItemByName(TopBarUserDropDownButtons.LogoutButton);
        }

        [Test]
        public void B_InValidLoginTest()
        {
            GenericPages.LoginPage.InputUserName(TestSettings.UnvalidUsername);
            GenericPages.LoginPage.InputPassword(TestSettings.UnvalidPassword);
            GenericPages.LoginPage.ClickLoginButton();

            ClassicAssert.AreEqual("Invalid credentials", GenericPages.LoginPage.GetInvalidMessageTextResult());
        }
    }
}
