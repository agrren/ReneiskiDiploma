using OpenQA.Selenium;
using OrangeHRMTests.Common.Extensions.ExtensionMethods;
using OrangeHRMTests.Common.WebElements;
using OrangeHRMTests.PageObjects.Elements;

namespace OrangeHRMTests.PageObjects.Pages
{
    public class LeavePage : BasePage
    {
        private MyWebElement CreatedEmployeeListFirstPosition = new MyWebElement(By.XPath("//div[@role='listbox']/div[1]/span"));
        private MyWebElement FromDateCalendarValueButton = new MyWebElement(By.XPath("//*[text()='From Date']//ancestor::div[1]//following-sibling::div[1]" +
            "//div[@class='oxd-calendar-dates-grid']//*[text()='26']"));
        private MyWebElement ToDateCalendarValueButton = new MyWebElement(By.XPath("//*[text()='To Date']//ancestor::div[1]//following-sibling::div[1]" +
            "//div[@class='oxd-calendar-dates-grid']//*[text()='27']"));
        private MyWebElement ConfirmButton = new MyWebElement(By.XPath("//button[@type='button'][text()=' Confirm ']"));
        public MyWebElement LeaveBalanceTextElement = new MyWebElement(By.XPath("//i[@class='oxd-icon bi-question-circle oxd-icon-button__icon --help']//ancestor::div[1]" +
            "//following-sibling::div[1]/p[text()='10.00 Day(s)']"));
        public MyWebElement SuccessfullySavedMessageTextElement = new MyWebElement(By.XPath("//p[@class='oxd-text oxd-text--p oxd-text--toast-message oxd-toast-content-text']" +
            "[text()='Successfully Saved']"));
        private MyWebElement AddLeaveEntitlementText = new MyWebElement(By.XPath("//p[@class='oxd-text oxd-text--p orangehrm-main-title'][text()='Add Leave Entitlement']"));
        private MyWebElement AssignLeaveText = new MyWebElement(By.XPath("//h6[@class='oxd-text oxd-text--h6 orangehrm-main-title'][text()='Assign Leave']"));

        public string DropDownListMultiselect = "//div[@class='oxd-multiselect-wrapper']/div[2]//*[contains(text(),'{0}')]";

        public void ClickDropdownList(string value) => new MyWebElement(By.XPath(string.Format(DropDownListMultiselect, value))).Click();

        public void ClickAssignLeaveButton() => TopbarMenu.ClickTopbarMenuButtonByName("Assign Leave");

        public void ClickEntitlementsButton() => TopbarMenu.ClickTopbarMenuButtonByName("Entitlements ");

        public void ClickAddEntitlementsButton() => TopbarMenu.ClickTopbarMenuButtonByName("Add Entitlements");

        public void ClickFromDateCalendarButton() => Buttons.ClickRequieredDropDownListArrowButtonByName("From Date");

        public void ClickFromDateCalendarValueButton() => FromDateCalendarValueButton.Click();

        public void ClickToDateCalendarButton() => Buttons.ClickRequieredDropDownListArrowButtonByName("To Date");

        public void ClickToDateCalendarValueButton() => ToDateCalendarValueButton.Click();

        public void ClickLeaveListButton() => TopbarMenu.ClickTopbarMenuButtonByName("Leave List");

        public void ClickLeaveTypeArrowButton() => Buttons.ClickRequieredDropDownListArrowButtonByName("Leave Type");

        public void ClickNotRequiredLeaveTypeArrowButton() => Buttons.ClickDropDownListArrowButtonByName("Leave Type");

        public void ClickShowLeaveWithStatusTypeArrowButton() => Buttons.ClickRequieredDropDownListArrowButtonByName("Show Leave with Status");

        public void ClickConfirmButton() => ConfirmButton.ClickWithoutWaiter();

        public void EnterEmployeeName() => Fields.EnterValueInInputTextField("Employee Name", "111");

        public string ReturnAddLeaveEntitlementText() => AddLeaveEntitlementText.Text;

        public string ReturnAssignLeaveText() => AssignLeaveText.Text;

        public void EnterEntitlement() => Fields.EnterValueInInputTextField("Entitlement", "10");

        public void ClickCreatedEmployeeFirstPosition() => CreatedEmployeeListFirstPosition.Click();

        public void ChooseLeaveType() => DropdownExtension.ClickDropdownList("CAN - Vacation");

        public void ChooseShowLeaveWithStatusType() => ClickDropdownList("Scheduled");
    }
}
