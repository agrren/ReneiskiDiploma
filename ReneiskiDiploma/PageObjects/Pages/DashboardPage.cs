using OpenQA.Selenium;
using OrangeHRMTests.Common.WebElements;

namespace OrangeHRMTests.PageObjects.Pages
{
    public class DashboardPage : BasePage
    {
        private MyWebElement ArrowButton = new MyWebElement(By.XPath("//i[@class='oxd-icon bi-caret-down-fill oxd-userdropdown-icon']"));
        private MyWebElement WheelButton = new MyWebElement(By.XPath("//i[@class='oxd-icon bi-gear-fill orangehrm-leave-card-icon']"));
        private MyWebElement ConfigurationsTextElement = new MyWebElement(By.XPath("//p[@class='oxd-text oxd-text--p oxd-text--card-title']"));
        private MyWebElement CrossButton = new MyWebElement(By.XPath("//button[@class='oxd-dialog-close-button oxd-dialog-close-button-position']"));
        private MyWebElement CancelButton = new MyWebElement(By.XPath("//button[@class='oxd-button oxd-button--medium oxd-button--ghost']"));

        public string HeaderByName = "//p[@class='oxd-text oxd-text--p'][text()='{0}']";

        public string ReturnTextResultByName(string field) => new MyWebElement(By.XPath(string.Format(HeaderByName, field))).Text;

        public void ClickArrowButton() => ArrowButton.Click();

        public void ClickWheelButton() => WheelButton.Click();

        public void ClickCrossButton() => CrossButton.Click();

        public void ClickCancelButton() => CancelButton.Click();

        public string ReturnTimeAtWorkTextResult() => ReturnTextResultByName("Time at Work");

        public string ReturnMyActionTextResult() => ReturnTextResultByName("My Actions");

        public string ReturnQuckLaunchTextResult() => ReturnTextResultByName("Quick Launch");

        public string ReturnBuzzLatestPostTextResult() => ReturnTextResultByName("Buzz Latest Posts");

        public string ReturnOnLeaveTextResult() => ReturnTextResultByName("Employees on Leave Today");

        public string ReturnBySubUnitTextResult() => ReturnTextResultByName("Employee Distribution by Sub Unit");

        public string ReturnByLocationTextResult() => ReturnTextResultByName("Employee Distribution by Location");

        public string ReturnConfigTextResult() => ConfigurationsTextElement.GetAttribute("innerText");
    }
}
