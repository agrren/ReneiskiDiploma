using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OrangeHRMTests.Common.Drivers;
using OrangeHRMTests.Common.WebElements;
using OrangeHRMTests.Data;
using OrangeHRMTests.PageObjects;

namespace OrangeHRMTests.Tests
{
    public class BaseTest
    {
        //private MyWebElement CreatedEmployeeListFirstPosition = new MyWebElement(By.XPath("//div[@role='listbox']/div[1]/span"));
        private MyWebElement EmployeeNameHintedTextBoxElement = new MyWebElement(By.XPath("//label[@class='oxd-label'][text()='Employee Name']//ancestor::div[1]" +
            "//following-sibling::div[1]//input"));

        public BaseTest()
        {
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            WebDriverFactory.InitializeDriver();
            GenericPages.BaseTest.GoToLoginPage();
            GenericPages.LoginPage.LogInToOrangeCRM();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            WebDriverFactory.QuitDriver();
        }

        public void CreateEmployee()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToPIMPage();
            BasePage.ClickAddButton();
            GenericPages.PIMPage.EnterFullUserName();
            BasePage.ClickSaveButton();
            ClassicAssert.AreEqual("Successfully Saved", GenericPages.InfoMessage.ReturnInfoMessageTextResult());
            BasePage.ClickSaveButton();
            GenericPages.PIMPage.ClickEmployeeListButton();
        }

        public void CreateUser()
        {
            GenericPages.AdminPage.ClickUserRoleDropdownArrowButton();
            GenericPages.AdminPage.ChooseUserRole();
            GenericPages.AdminPage.ClickStatusDropdownArrowButton();
            GenericPages.AdminPage.ChooseUserStatus();
            GenericPages.PIMPage.EnterCreatedEmployeeNameTextBoxElement();
            GenericPages.PIMPage.ClickDropdownListFirstPosition();
            GenericPages.AdminPage.EnterUserNameTextBoxElement();
            GenericPages.AdminPage.EnterPasswordTextBoxElement();
            GenericPages.AdminPage.EnterConfirmPasswordTextBoxElement();
            BasePage.ClickSaveButton();
        }

        public void DeleteCreatedEmployee()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToPIMPage();
            BasePage.EnterEmployeeName();
            GenericPages.PIMPage.ClickDropdownListFirstPosition();
            BasePage.ClickSearchButton();
            BasePage.ClickTrashButton();
            BasePage.ClickConfirmDeletionButton();
        }

        public void GoToLoginPage() => WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.PageUrl);
    }
}