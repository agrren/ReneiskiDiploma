using OpenQA.Selenium;
using OrangeHRMTests.Common.Extensions.ExtensionMethods;
using OrangeHRMTests.Common.WebElements;
using OrangeHRMTests.PageObjects.Elements;

namespace OrangeHRMTests.PageObjects.Pages
{
    public class AdminPage : BasePage
    {
        private MyWebElement AdminPageHeaderElementPartOne = new MyWebElement(By.XPath("//h6[@class='oxd-text oxd-text--h6 oxd-topbar-header-breadcrumb-module']"));
        private MyWebElement AdminPageHeaderElementPartTwo = new MyWebElement(By.XPath("//h6[@class='oxd-text oxd-text--h6 oxd-topbar-header-breadcrumb-level']"));
        private MyWebElement SystemUserTableHeaderElement = new MyWebElement(By.XPath("//h5[@class='oxd-text oxd-text--h5 oxd-table-filter-title']"));
        private MyWebElement UsersDropdownElement = new MyWebElement(By.XPath("//ul[@class='oxd-dropdown-menu']"));
        private MyWebElement JobTitleDropdownElement = new MyWebElement(By.XPath("//ul[@class='oxd-dropdown-menu']//*[contains(text(),'Job Titles')]"));
        private MyWebElement EditNationalityNameTextBoxElement = new MyWebElement(By.XPath("//div[@class='oxd-input-group oxd-input-field-bottom-space']//input"));
        private MyWebElement JobTitlesText = new MyWebElement(By.XPath("//h6[@class='oxd-text oxd-text--h6 orangehrm-main-title'][text()='Job Titles']"));
        private MyWebElement NationalitiesText = new MyWebElement(By.XPath("//h6[@class='oxd-text oxd-text--h6 orangehrm-main-title'][text()='Nationalities']"));
        private MyWebElement EditNationalityText = new MyWebElement(By.XPath("//h6[@class='oxd-text oxd-text--h6 orangehrm-main-title'][text()='Edit Nationality']"));

        public void ClickUserManagementDropdownButton() => TopbarMenu.ClickTopbarMenuButtonByName("User Management ");

        public void ClickJobDropdownButton() => TopbarMenu.ClickTopbarMenuButtonByName("Job ");

        public void ClickUsersDropdownButton() => TopbarMenu.ClickTopbarMenuButtonByName("Users");

        public void ClickJobTitlesDropdownButton() => TopbarMenu.ClickTopbarMenuButtonByName("Job Titles");

        public void ClickNationalitiesButton() => TopbarMenu.ClickTopbarMenuButtonByName("Nationalities");

        public void ClickUserRoleDropdownArrowButton() => Buttons.ClickRequieredDropDownListArrowButtonByName("User Role");

        public void ClickStatusDropdownArrowButton() => Buttons.ClickRequieredDropDownListArrowButtonByName("Status");

        public void ClearNationalityName() 
        {
            MyWebElement.Waiter();
            Fields.EnterValueInInputTextField("Name", Keys.Control + "a" + Keys.Delete);
        }

        public void EnterNationalityName() => Fields.EnterValueInInputTextField("Name", "111");

        public void EnterNationalityNameBack(string value) => EditNationalityNameTextBoxElement.SendKeys(value);

        public void EnterJobTitleName() => Fields.EnterValueInInputTextField("Job Title", "111");

        public void EnterUserNameTextBoxElement() => Fields.EnterValueInInputTextField("Username", "111admin");

        public void EnterPasswordTextBoxElement() => Fields.EnterValueInInputTextField("Password", "qwerty123");

        public void EnterConfirmPasswordTextBoxElement() => Fields.EnterValueInInputTextField("Confirm Password", "qwerty123");

        public string ReturnAdminPageHeaderPartOneTextResult() => AdminPageHeaderElementPartOne.Text;

        public string ReturnAdminPageHeaderPartTwoTextResult() => AdminPageHeaderElementPartTwo.Text;

        public string ReturnSystemUserTableHeaderTextResult() => SystemUserTableHeaderElement.Text;

        public string ReturnUsersDropdownElementText() => UsersDropdownElement.Text;

        public string ReturnJobTitleDropdownElementText() => JobTitleDropdownElement.Text;

        public string ReturnEmployeeNameTableTextElement() => Tables.ReturnValueOfTextFieldByName("Employee Name");

        public string ReturnJobTitleNameTextResult() => Tables.ReturnValueOfTextFieldByName("Job Titles");

        public string ReturnJobTitlesText() => JobTitlesText.Text;

        public string ReturnNationalitiesText() => NationalitiesText.Text;

        public string ReturnEditNationalitiyText() => EditNationalityText.Text;

        public void ChooseUserRole() => DropdownExtension.ClickDropdownList("Admin");

        public void ChooseUserStatus() => DropdownExtension.ClickDropdownList("Enabled");
    }
}
