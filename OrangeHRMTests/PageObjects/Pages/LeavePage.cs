using OpenQA.Selenium;
using OrangeHRMTests.Common.WebElements;

namespace OrangeHRMTests.PageObjects.Pages
{
    public class LeavePage : BasePage
    {
        private const string DropDownListMultiselect = "//*[contains(@class, 'multiselect-wrapper')]//*[contains(text(),'{0}')]";
        private const string FromDateCalendarValueButton = "//*[text()='From Date']//ancestor::div[1]//following-sibling::div[1]" +
            "//div[@class='oxd-calendar-dates-grid']//*[text()='{0}']";
        private const string ToDateCalendarValueButton = "//*[text()='To Date']//ancestor::div[1]//following-sibling::div[1]" +
            "//div[@class='oxd-calendar-dates-grid']//*[text()='{0}']";
        private MyWebElement ConfirmButton = new MyWebElement(By.XPath("//*[contains(@class, 'dialog-sheet')]//button[text()[normalize-space() = 'Confirm']]"));

        public void ClickDropdownList(string value) => new MyWebElement(By.XPath(string.Format(DropDownListMultiselect, value))).Click();

        public void ClickFromDateCalendarValueButton(string value) => new MyWebElement(By.XPath(string.Format(FromDateCalendarValueButton, value))).Click();

        public void ClickToDateCalendarValueButton(string value) => new MyWebElement(By.XPath(string.Format(ToDateCalendarValueButton, value))).Click();

        public void ClickConfirmButton() => ConfirmButton.ClickWithoutWaiter();
    }
}
