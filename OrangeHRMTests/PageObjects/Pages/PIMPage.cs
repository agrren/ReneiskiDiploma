using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OrangeHRMTests.Common.Extensions.ExtensionMethods;
using OrangeHRMTests.Common.WebElements;
using OrangeHRMTests.PageObjects.Modules;

namespace OrangeHRMTests.PageObjects.Pages
{
    public class PIMPage : BasePage
    {
        private MyWebElement SaveCustomFieldButton = new MyWebElement(By.XPath("//*[contains(@class, 'custom-fields')]//*[contains(@type, 'submit')]"));
        private MyWebElement DropdownListFirstPosition = new MyWebElement(By.XPath("//*[contains(@role, 'listbox')]//span"));
        private MyWebElement PersonalDetailsHeader = new MyWebElement(By.XPath("//*[contains(@class, 'container')]//*[contains(@class, 'main-title')][text()='Personal Details']"));
        private MyWebElement AddedCustomFieldName = new MyWebElement(By.XPath("//*[text()='Custom Fields']//following-sibling::form[1]//label"));
        private MyWebElement QualificationsButton = new MyWebElement(By.XPath("//*[contains(@class, 'edit-employee-navigation')]//*[text()='Qualifications']"));
        private MyWebElement AddSkillsButton = new MyWebElement(By.XPath("//*[contains(@class, 'edit-employee-content')]//*[text()='Skills']//following-sibling::button"));
        private MyWebElement SkillsTableTrashButton = new MyWebElement(By.XPath("//*[text()='Skills']//ancestor::div[2]//following-sibling::div[2]//*[contains(@class, 'bi-trash')]"));
        public MyWebElement ImployeeInformationText = new MyWebElement(By.XPath("//*[contains(@class, 'table-filter')]//*[contains(@class, 'table-filter-title')]"));

        public string FullUserName = "//*[contains(@class, 'input-group')]//*[text()='Employee Full Name']//ancestor::div//following-sibling::div//input[@name='{0}']";

        public string GetFirstAndMiddleNameTextResult() => GetCellText("First (& Middle) Name");

        public string GetLastNameTextResult() => GetCellText("Last Name");

        public void EnterUserName(string field, string value) => new MyWebElement(By.XPath(string.Format(FullUserName, field))).SendKeys(value);

        public void ChoseScreen()
        {
            ClickDropDownListArrowButtonByName("Screen");
            DropdownExtension.ClickDropdownList("Personal Details");
        }

        public void ChoseType()
        {
            ClickDropDownListArrowButtonByName("Type");
            DropdownExtension.ClickDropdownList("Text or Number");
        }

        public void ClickEmployeeListButton() => TopbarMenu.ClickTopbarMenuButtonByName("Employee List");

        public void ClickConfugurationButton() => TopbarMenu.ClickTopbarMenuButtonByName("Configuration ");

        public void ClickCustomFieldsButton() => TopbarMenu.ClickTopbarMenuButtonByName("Custom Fields");

        public void ClickDropdownListFirstPosition() => DropdownListFirstPosition.Click();

        public void ClickUserName(string field) => new MyWebElement(By.XPath(string.Format(FullUserName, field))).Click();

        public void ClickEmployeeLastName() => ClickTableCellByName("Last Name");

        public void ClickQualificationsButton() => QualificationsButton.Click();

        public void ClickAddSkillsButton() => AddSkillsButton.Click();

        public void ClickSkillsTableTrashButton () => SkillsTableTrashButton.Click();

        public void ClearFullUserName()
        {
            ClickUserName("firstName");
            EnterUserName("firstName", Keys.Control + "a" + Keys.Delete);
            ClickUserName("middleName");
            EnterUserName("middleName", Keys.Control + "a" + Keys.Delete);
            ClickUserName("lastName");
            EnterUserName("lastName", Keys.Control + "a" + Keys.Delete);
        }

        public void EnterFullUserName()
        {
            EnterUserName("firstName", "111");
            EnterUserName("middleName", "222");
            EnterUserName("lastName", "333");
        }

        public void EnterCreatedEmployeeNameTextBoxElement() => EnterValueInInputTextField("Employee Name", "111 222");

        public void EnterUnvalidEmployeeNameTextBoxElement() => EnterValueInInputTextField("Employee Name", "123456");

        public void EnterFieldNameTextBoxElement() => EnterValueInInputTextField("Field Name", "111");

        public void EnterCreatedCustomFieldValueTextBoxElement() => EnterValueInInputTextField("111", "111");

        public void ClickSaveCustomFieldButton() => SaveCustomFieldButton.Click();

        public void ClearEmployeeNameTextBoxElement() => EnterValueInInputTextField("Employee Name", Keys.Control + "a" + Keys.Delete);

        public string GetPersonalDetailsHeaderTextElement() => PersonalDetailsHeader.Text;

        public string GetAddedCustomFieldNameTextElement() => AddedCustomFieldName.Text;

        public string GetImployeeInformationText() => ImployeeInformationText.Text;

        public string GetCustomFieldsText() => MainTitleText.Text;

        public string GetNoRecordsFoundText() => PopUpMessageTextElement.Text;

        public void ClearCreatedCustomFieldTextBoxElement() => EnterValueInInputTextField("111", Keys.Control + "a" + Keys.Delete);
    }
}
