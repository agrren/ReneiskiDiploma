using OpenQA.Selenium;
using OrangeHRMTests.Common.Extensions.ExtensionMethods;
using OrangeHRMTests.Common.WebElements;
using OrangeHRMTests.PageObjects.Modules;

namespace OrangeHRMTests.PageObjects.Pages
{
    public class AdminPage : BasePage
    {
        public MyWebElement SystemUserTableHeaderElement = new MyWebElement(By.XPath("//*[contains(@class, 'table-filter')]//*[contains(@class, 'filter-title')]"));
        private MyWebElement DropdownElement = new MyWebElement(By.XPath("//ul[@class='oxd-dropdown-menu']//*[contains(@role, 'menuitem')]"));
        private MyWebElement EditNationalityNameTextBoxElement = new MyWebElement(By.XPath("//*[contains(@class, 'input-field')]//*[contains(text(), 'Name')]//ancestor::div[1]//following-sibling::div[1]//input"));

        public void ClickUserManagementDropdownButton() => TopbarMenu.ClickTopbarMenuButtonByName("User Management ");

        public void ClickJobDropdownButton() => TopbarMenu.ClickTopbarMenuButtonByName("Job ");

        public void ClickUsersDropdownButton() => TopbarMenu.ClickTopbarMenuButtonByName("Users");

        public void ClickJobTitlesDropdownButton() => TopbarMenu.ClickTopbarMenuButtonByName("Job Titles");

        public void ClickNationalitiesButton() => TopbarMenu.ClickTopbarMenuButtonByName("Nationalities");

        public void ClickUserRoleDropdownArrowButton() => ClickDropDownListArrowButtonByName("User Role");

        public void ClickStatusDropdownArrowButton() => ClickDropDownListArrowButtonByName("Status");

        public void ClearNationalityName()
        {
            MyWebElement.Waiter();
            EnterValueInInputTextField("Name", Keys.Control + "a" + Keys.Delete);
        }

        public void EnterNationalityName() => EnterValueInInputTextField("Name", "111");

        public void EnterNationalityNameBack(string value) => EditNationalityNameTextBoxElement.SendKeys(value);

        public void EnterJobTitleName() => EnterValueInInputTextField("Job Title", "111");

        public void EnterUserNameTextBoxElement() => EnterValueInInputTextField("Username", "111admin");

        public void EnterPasswordTextBoxElement() => EnterValueInInputTextField("Password", "qwerty123");

        public void EnterConfirmPasswordTextBoxElement() => EnterValueInInputTextField("Confirm Password", "qwerty123");

        public string GetSystemUserTableHeaderTextResult() => SystemUserTableHeaderElement.Text;

        public string GetUsersDropdownElementText() => DropdownElement.Text;

        public string GetJobTitleDropdownElementText() => DropdownElement.Text;

        public string GetEmployeeNameTableTextElement() => ReturnValueOfTextFieldByName("Employee Name");

        public string GetJobTitleNameTextResult() => ReturnValueOfTextFieldByName("Job Titles");

        public string GetJobTitlesText() => MainTitleText.Text;

        public string GetNationalitiesText() => MainTitleText.Text;

        public string GetEditNationalitiyText() => MainTitleText.Text;

        public void ChooseUserRole() => DropdownExtension.ClickDropdownList("Admin");

        public void ChooseUserStatus() => DropdownExtension.ClickDropdownList("Enabled");
    }
}
