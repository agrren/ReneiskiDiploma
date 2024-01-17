using OpenQA.Selenium;
using OrangeHRMTests.Common.Drivers;
using OrangeHRMTests.Common.WebElements;
using OrangeHRMTests.Data;
using OrangeHRMTests.PageObjects.Elements;
using OrangeHRMTests.PageObjects.Modules;

namespace OrangeHRMTests.PageObjects
{
    public class BasePage : WebDriverFactory
    {
        private MyWebElement CreatedEmployeeListFirstPosition = new MyWebElement(By.XPath("//div[@role='listbox']/div[1]/span"));
        private MyWebElement EmployeeNameHintedTextBoxElement = new MyWebElement(By.XPath("//label[@class='oxd-label'][text()='Employee Name']//ancestor::div[1]" +
            "//following-sibling::div[1]//input"));

        public void CreateEmployee()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToPIMPage();
            Buttons.ClickAddButton();
            GenericPages.PIMPage.EnterFullUserName();
            GenericPages.PIMPage.ClickSaveOneButton();
            GenericPages.PIMPage.ClickSaveTwoButton();
            GenericPages.PIMPage.ClickEmployeeListButton();
        }

        public void CreateUser()
        {
            GenericPages.AdminPage.ClickUserRoleDropdownArrowButton();
            GenericPages.AdminPage.ChooseUserRole();
            GenericPages.AdminPage.ClickStatusDropdownArrowButton();
            GenericPages.AdminPage.ChooseUserStatus();
            GenericPages.PIMPage.EnterCreatedEmployeeNameTextBoxElement();
            GenericPages.PIMPage.ClickCreatedEmployeeFirstPosition();
            GenericPages.AdminPage.EnterUserNameTextBoxElement();
            GenericPages.AdminPage.EnterPasswordTextBoxElement();
            GenericPages.AdminPage.EnterConfirmPasswordTextBoxElement();
            Buttons.ClickSaveButton();
        }

        public void DeleteCreatedEmployee()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToPIMPage();
            EmployeeNameHintedTextBoxElement.SendKeys("111 222");
            CreatedEmployeeListFirstPosition.Click();
            Buttons.ClickSearchButton();
            Tables.ClickTrashButton();
            Buttons.ClickConfirmDeletionButton();
        }

        public LeftMenuNavigationPanel LeftMenuNavigationPanel => new LeftMenuNavigationPanel();

        public void GoToLoginPage() => WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.PageUrl);
    }
}
