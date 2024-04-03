using OpenQA.Selenium;
using OrangeHRMTests.Common.WebElements;
using OrangeHRMTests.Data;
using OrangeHRMTests.Data.Constants;

namespace OrangeHRMTests.PageObjects.Pages
{
    public class PIMPage : BasePage
    {
        private const string FullUserName = "//*[contains(@class, 'input-group')]//*[text()='Employee Full Name']//ancestor::div//following-sibling::div//input[@name='{0}']";

        private MyWebElement SaveCustomFieldButton = new MyWebElement(By.XPath("//*[contains(@class, 'custom-fields')]//*[contains(@type, 'submit')]"));
        private MyWebElement PersonalDetailsHeader = new MyWebElement(By.XPath("//*[contains(@class, 'container')]//*[contains(@class, 'main-title')][text()='Personal Details']"));
        private MyWebElement AddedCustomFieldName = new MyWebElement(By.XPath("//*[text()='Custom Fields']//following-sibling::form[1]//label"));
        private MyWebElement QualificationsButton = new MyWebElement(By.XPath("//*[contains(@class, 'edit-employee-navigation')]//*[text()='Qualifications']"));
        private MyWebElement AddSkillsButton = new MyWebElement(By.XPath("//*[contains(@class, 'edit-employee-content')]//*[text()='Skills']//following-sibling::button"));
        private MyWebElement SkillsTableTrashButton = new MyWebElement(By.XPath("//*[text()='Skills']//ancestor::div[2]//following-sibling::div[2]//*[contains(@class, 'bi-trash')]"));
        private MyWebElement EmployeeInformationText = new MyWebElement(By.XPath("//*[contains(@class, 'table-filter')]//*[contains(@class, 'table-filter-title')]"));

        public void EnterUserName(string field, string value) => new MyWebElement(By.XPath(string.Format(FullUserName, field))).SendKeys(value);

        public void ClickUserName(string field) => new MyWebElement(By.XPath(string.Format(FullUserName, field))).Click();

        public void ClickQualificationsButton() => QualificationsButton.Click();

        public void ClickAddSkillsButton() => AddSkillsButton.Click();

        public void ClickSkillsTableTrashButton () => SkillsTableTrashButton.Click();

        public void ClearFullUserName()
        {
            ClickUserName(InputFieldsNames.FirstNameInputFieldName);
            EnterUserName(InputFieldsNames.FirstNameInputFieldName, Keys.Control + "a" + Keys.Delete);
            ClickUserName(InputFieldsNames.MiddleNameInputFieldName);
            EnterUserName(InputFieldsNames.MiddleNameInputFieldName, Keys.Control + "a" + Keys.Delete);
            ClickUserName(InputFieldsNames.LastNameInputFieldName);
            EnterUserName(InputFieldsNames.LastNameInputFieldName, Keys.Control + "a" + Keys.Delete);
        }

        public void EnterFullUserName(string firstName, string middleName, string lastName)
        {
            EnterUserName(InputFieldsNames.FirstNameInputFieldName, firstName);
            EnterUserName(InputFieldsNames.MiddleNameInputFieldName, middleName);
            EnterUserName(InputFieldsNames.LastNameInputFieldName, lastName);
        }

        public void ClickSaveCustomFieldButton() => SaveCustomFieldButton.Click();

        public string GetPersonalDetailsHeaderTextElement() => PersonalDetailsHeader.Text;

        public string GetAddedCustomFieldNameTextElement() => AddedCustomFieldName.Text;

        public string GetEmployeeInformationText() => EmployeeInformationText.Text;
    }
}
