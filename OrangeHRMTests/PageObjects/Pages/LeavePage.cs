using OpenQA.Selenium;
using OrangeHRMTests.Common.Extensions.ExtensionMethods;
using OrangeHRMTests.Common.WebElements;
using OrangeHRMTests.PageObjects.Modules;

namespace OrangeHRMTests.PageObjects.Pages
{
    public class LeavePage : BasePage
    {
        private MyWebElement FromDateCalendarValueButton = new MyWebElement(By.XPath("//*[text()='From Date']//ancestor::div[1]//following-sibling::div[1]" +
            "//div[@class='oxd-calendar-dates-grid']//*[text()='27']"));
        private MyWebElement ToDateCalendarValueButton = new MyWebElement(By.XPath("//*[text()='To Date']//ancestor::div[1]//following-sibling::div[1]" +
            "//div[@class='oxd-calendar-dates-grid']//*[text()='28']"));
        private MyWebElement ConfirmButton = new MyWebElement(By.XPath("//*[contains(@class, 'dialog-sheet')]//button[text()=' Confirm ']"));

        public string DropDownListMultiselect = "//*[contains(@class, 'multiselect-wrapper')]//*[contains(text(),'{0}')]";

        public void ClickDropdownList(string value) => new MyWebElement(By.XPath(string.Format(DropDownListMultiselect, value))).Click();

        public void ClickAssignLeaveButton() => TopbarMenu.ClickTopbarMenuButtonByName("Assign Leave");

        public void ClickEntitlementsButton() => TopbarMenu.ClickTopbarMenuButtonByName("Entitlements ");

        public void ClickAddEntitlementsButton() => TopbarMenu.ClickTopbarMenuButtonByName("Add Entitlements");

        public void ClickFromDateCalendarButton() => ClickDropDownListArrowButtonByName("From Date");

        public void ClickFromDateCalendarValueButton() => FromDateCalendarValueButton.Click();

        public void ClickToDateCalendarButton() => ClickDropDownListArrowButtonByName("To Date");

        public void ClickToDateCalendarValueButton() => ToDateCalendarValueButton.Click();

        public void ClickLeaveListButton() => TopbarMenu.ClickTopbarMenuButtonByName("Leave List");

        public void ClickLeaveTypeArrowButton() => ClickDropDownListArrowButtonByName("Leave Type");

        public void ClickNotRequiredLeaveTypeArrowButton() => ClickDropDownListArrowButtonByName("Leave Type");

        public void ClickShowLeaveWithStatusTypeArrowButton() => ClickDropDownListArrowButtonByName("Show Leave with Status");

        public void ClickConfirmButton() => ConfirmButton.ClickWithoutWaiter();

        public void EnterEmployeeName() => EnterValueInInputTextField("Employee Name", "111");

        public string GetAddLeaveEntitlementText() => MainTitleText.Text;

        public string GetAssignLeaveText() => MainTitleText.Text;

        public void EnterEntitlement() => EnterValueInInputTextField("Entitlement", "10");

        public void ChooseLeaveType() => DropdownExtension.ClickDropdownList("CAN - Vacation");

        public void ChooseShowLeaveWithStatusType() => ClickDropdownList("Scheduled");
    }
}
