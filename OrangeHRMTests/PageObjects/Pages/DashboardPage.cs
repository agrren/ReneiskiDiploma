using OpenQA.Selenium;
using OrangeHRMTests.Common.WebElements;

namespace OrangeHRMTests.PageObjects.Pages
{
    public class DashboardPage : BasePage
    {
        private MyWebElement GearwheelButton = new MyWebElement(By.XPath("//*[contains(@class, 'gear')]"));
        private MyWebElement ConfigurationsTextElement = new MyWebElement(By.XPath("//*[contains(@class, 'dialog-modal')]//*[contains(@class, 'card-title')]"));
        private MyWebElement CrossButton = new MyWebElement(By.XPath("//*[contains(@class, 'dialog-modal')]/button[contains(@class, 'dialog-close-button')]"));
        private MyWebElement CancelButton = new MyWebElement(By.XPath("//*[contains(@class, 'dialog-modal')]//button[contains(@type, 'button')]"));

        public string HeaderByName = "//*[contains(@class, 'dashboard-widget')]//*[contains(@class, 'widget-name')]/p[text()='{0}']";

        public string GetTextResultByName(string field) => new MyWebElement(By.XPath(string.Format(HeaderByName, field))).Text;

        public void ClickWheelButton() => GearwheelButton.Click();

        public void ClickCrossButton() => CrossButton.Click();

        public void ClickCancelButton() => CancelButton.Click();

        public string GetTimeAtWorkTextResult() => GetTextResultByName("Time at Work");

        public string GetMyActionTextResult() => GetTextResultByName("My Actions");

        public string GetQuckLaunchTextResult() => GetTextResultByName("Quick Launch");

        public string GetBuzzLatestPostTextResult() => GetTextResultByName("Buzz Latest Posts");

        public string GetOnLeaveTextResult() => GetTextResultByName("Employees on Leave Today");

        public string GetBySubUnitTextResult() => GetTextResultByName("Employee Distribution by Sub Unit");

        public string GetByLocationTextResult() => GetTextResultByName("Employee Distribution by Location");

        public string GetConfigTextResult() => ConfigurationsTextElement.GetAttribute("innerText");
    }
}
