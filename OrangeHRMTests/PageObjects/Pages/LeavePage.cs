using OpenQA.Selenium;
using OrangeHRMTests.Common.WebElements;
using OrangeHRMTests.PageObjects.Modules;

namespace OrangeHRMTests.PageObjects.Pages
{
    public class LeavePage : BasePage
    {
        public const string DropDownListMultiselect = "//*[contains(@class, 'multiselect-wrapper')]//*[contains(text(),'{0}')]";

        private MyWebElement FromDateCalendarValueButton = new MyWebElement(By.XPath("//*[text()='From Date']//ancestor::div[1]//following-sibling::div[1]" +
            "//div[@class='oxd-calendar-dates-grid']//*[text()='27']"));
        private MyWebElement ToDateCalendarValueButton = new MyWebElement(By.XPath("//*[text()='To Date']//ancestor::div[1]//following-sibling::div[1]" +
            "//div[@class='oxd-calendar-dates-grid']//*[text()='28']"));
        private MyWebElement ConfirmButton = new MyWebElement(By.XPath("//*[contains(@class, 'dialog-sheet')]//button[text()=' Confirm ']"));

        public void ClickDropdownList(string value) => new MyWebElement(By.XPath(string.Format(DropDownListMultiselect, value))).Click();

        public void ClickFromDateCalendarValueButton() => FromDateCalendarValueButton.Click();

        public void ClickToDateCalendarValueButton() => ToDateCalendarValueButton.Click();

        public void ClickConfirmButton() => ConfirmButton.ClickWithoutWaiter();
    }
}
