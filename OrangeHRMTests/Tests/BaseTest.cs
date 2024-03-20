using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OrangeHRMTests.Common.Drivers;
using OrangeHRMTests.Common.WebElements;
using OrangeHRMTests.Data;
using OrangeHRMTests.Data.Constants;
using OrangeHRMTests.Helpers;
using OrangeHRMTests.PageObjects;
using OrangeHRMTests.PageObjects.Modules;

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
            GoToLoginPage();
            GenericPages.LoginPage.LogInToOrangeCRM();
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
        public void OneTimeTearDown()
        {
            WebDriverFactory.QuitDriver();
        }

        public void CreateEmployee()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.PIMButtonName);
            GenericPages.PIMPage.ClickAddButton();
            GenericPages.PIMPage.EnterFullUserName();
            GenericPages.PIMPage.ClickSaveButton();
            ClassicAssert.AreEqual(InfoMessageTextValues.SuccessfullySavedMessageText, GenericPages.InfoMessage.GetInfoMessageTextResult());
            GenericPages.PIMPage.ClickSaveButton();
            GenericPages.BasePage.TopBarMenu.ClickTopbarMenuButtonByName(PIMPageTopBarMenuButtonsNames.EmployeeListTopBarMenuButtonName);
        }

        public void CreateUser()
        {
            const string NewUserName = "111admin";
            const string NewPassword = "qwerty123";
            const string NewUserRole = "Admin";
            const string NewUserStatus = "Enabled";
            const string NewEmployeeName = "111 222";

            GenericPages.AdminPage.ClickDropDownListArrowButtonByName(DropDownFieldsNames.UserRoleDropDownFieldName);
            MyWebElement.SelectValueFromOrangeDropdownList(NewUserRole);
            GenericPages.AdminPage.ClickDropDownListArrowButtonByName(DropDownFieldsNames.StatusDropDownFieldName);
            MyWebElement.SelectValueFromOrangeDropdownList(NewUserStatus);
            GenericPages.PIMPage.EnterValueInInputTextField(InputFieldsNames.EmployeeNameInputFieldName, NewEmployeeName);
            GenericPages.PIMPage.ClickDropdownListFirstPosition();
            GenericPages.AdminPage.EnterValueInInputTextField(InputFieldsNames.UserNameInputFieldName, NewUserName);
            GenericPages.AdminPage.EnterValueInInputTextField(InputFieldsNames.PasswordInputFieldName, NewPassword);
            GenericPages.AdminPage.EnterValueInInputTextField(InputFieldsNames.ConfirmPasswordInputFieldName, NewPassword);
            GenericPages.AdminPage.ClickSaveButton();
        }

        public void DeleteCreatedEmployee()
        {
            const string CreatedEmployeeName = "111 222";

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.PIMButtonName);
            GenericPages.PIMPage.EnterValueInInputTextField(InputFieldsNames.EmployeeNameInputFieldName, CreatedEmployeeName); ;
            GenericPages.PIMPage.ClickDropdownListFirstPosition();
            GenericPages.PIMPage.ClickSearchButton();
            Table.ClickTrashButton();
            GenericPages.PIMPage.ClickConfirmDeletionButton();
        }

        public void GoToLoginPage() => WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.PageUrl);

        private void TakeScreenshot()
        {
            var screenshotPath = ScreenshotHelper.TakeScreenshot(WebDriverFactory.Driver, TestContext.CurrentContext.Test.Name);
            TestContext.AddTestAttachment(screenshotPath);
        }
    }
}