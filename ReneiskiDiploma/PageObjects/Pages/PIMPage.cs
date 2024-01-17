using OpenQA.Selenium;
using OrangeHRMTests.Common.Extensions.ExtensionMethods;
using OrangeHRMTests.Common.WebElements;
using OrangeHRMTests.PageObjects.Elements;

namespace OrangeHRMTests.PageObjects.Pages
{
    public class PIMPage : BasePage
    {
        private MyWebElement SaveOneButton = new MyWebElement(By.XPath("//button[@type='submit']"));
        private MyWebElement SaveTwoButton = new MyWebElement(By.XPath("//form[@class='oxd-form']/div[5]/button"));
        private MyWebElement CreatedEmployeeListFirstPosition = new MyWebElement(By.XPath("//div[@role='listbox']/div[1]/span"));
        private MyWebElement PersonalDetailsHeader = new MyWebElement(By.XPath("//h6[@class='oxd-text oxd-text--h6 orangehrm-main-title']"));
        private MyWebElement AddedCustomFieldName = new MyWebElement(By.XPath("//h6[text()='Custom Fields']//following-sibling::form[1]//label[@class='oxd-label']"));
        private MyWebElement QualificationsButton = new MyWebElement(By.XPath("//*[text()='Qualifications']"));
        private MyWebElement AddSkillsButton = new MyWebElement(By.XPath("//*[text()='Skills']//following-sibling::button"));
        private MyWebElement SkillsTableTrashButton = new MyWebElement(By.XPath("//*[text()='Skills']//ancestor::div[2]//following-sibling::div[2]" +
            "//i[@class='oxd-icon bi-trash']"));
        private MyWebElement ImployeeInformationText = new MyWebElement(By.XPath("//h5[@class='oxd-text oxd-text--h5 oxd-table-filter-title']" +
            "[text()='Employee Information']"));
        private MyWebElement CustomFieldsText = new MyWebElement(By.XPath("//h6[@class='oxd-text oxd-text--h6 orangehrm-main-title'][text()='Custom Fields']"));
        private MyWebElement NoRecordsFoundText = new MyWebElement(By.XPath("//span[@class='oxd-text oxd-text--span'][text()='No Records Found']"));

        public string FullUserName = "//label[text()='Employee Full Name']//ancestor::div[1]//following-sibling::div[1]//input[@name='{0}']";

        public string ReturnFirstAndMiddleNameTextResult() => Tables.GetCellText("First (& Middle) Name");

        public string ReturnLastNameTextResult() => Tables.GetCellText("Last Name");

        public void EnterUserName(string field, string value) => new MyWebElement(By.XPath(string.Format(FullUserName, field))).SendKeys(value);

        public void ChoseScreen()
        {
            Buttons.ClickRequieredDropDownListArrowButtonByName("Screen");
            DropdownExtension.ClickDropdownList("Personal Details");
        }

        public void ChoseType()
        {
            Buttons.ClickRequieredDropDownListArrowButtonByName("Type");
            DropdownExtension.ClickDropdownList("Text or Number");
        }

        public void ClickEmployeeListButton() => TopbarMenu.ClickTopbarMenuButtonByName("Employee List");

        public void ClickConfugurationButton() => TopbarMenu.ClickTopbarMenuButtonByName("Configuration ");

        public void ClickCustomFieldsButton() => TopbarMenu.ClickTopbarMenuButtonByName("Custom Fields");

        public void ClickCreatedEmployeeFirstPosition() => CreatedEmployeeListFirstPosition.Click();

        public void ClickUserName(string field) => new MyWebElement(By.XPath(string.Format(FullUserName, field))).Click();

        public void ClickEmployeeLastName() => Tables.ClickTableCellByName("Last Name");

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

        public void EnterCreatedEmployeeNameTextBoxElement() => Fields.EnterValueInInputTextField("Employee Name", "111 222");

        public void EnterUnvalidEmployeeNameTextBoxElement() => Fields.EnterValueInInputTextField("Employee Name", "123456");

        public void EnterFieldNameTextBoxElement() => Fields.EnterValueInInputTextField("Field Name", "111");

        public void EnterCreatedCustomFieldValueTextBoxElement() => Fields.EnterValueInInputTextField("111", "111");

        public void ClickSaveOneButton() => SaveOneButton.Click();

        public void ClickSaveTwoButton() => SaveTwoButton.Click();

        public void ClearEmployeeNameTextBoxElement() => Fields.EnterValueInInputTextField("Employee Name", Keys.Control + "a" + Keys.Delete);

        public string ReturnPersonalDetailsHeaderTextElement() => PersonalDetailsHeader.Text;

        public string ReturnAddedCustomFieldNameTextElement() => AddedCustomFieldName.Text;

        public string ReturnImployeeInformationText() => ImployeeInformationText.Text;

        public string ReturnCustomFieldsText() => CustomFieldsText.Text;

        public string ReturnNoRecordsFoundText() => NoRecordsFoundText.Text;

        public void ClearCreatedCustomFieldTextBoxElement() => Fields.EnterValueInInputTextField("111", Keys.Control + "a" + Keys.Delete);
    }
}
