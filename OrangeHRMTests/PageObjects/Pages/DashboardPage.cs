using OpenQA.Selenium;
using OrangeHRMTests.Common.WebElements;

namespace OrangeHRMTests.PageObjects.Pages
{
    public class DashboardPage : BasePage
    {
        public const string HeaderByName = "//*[contains(@class, 'dashboard-widget')]//*[contains(@class, 'widget-name')]/p[text()='{0}']";

        private MyWebElement GearwheelButton = new MyWebElement(By.XPath("//*[contains(@class, 'gear')]"));
        private MyWebElement ConfigurationsTextElement = new MyWebElement(By.XPath("//*[contains(@class, 'dialog-modal')]//*[contains(@class, 'card-title')]"));
        private MyWebElement CrossButton = new MyWebElement(By.XPath("//*[contains(@class, 'dialog-modal')]/button[contains(@class, 'dialog-close-button')]"));
        private MyWebElement CancelButton = new MyWebElement(By.XPath("//*[contains(@class, 'dialog-modal')]//button[contains(@type, 'button')]"));

        public string GetTextResultByName(string field) => new MyWebElement(By.XPath(string.Format(HeaderByName, field))).Text;

        public void ClickWheelButton() => GearwheelButton.Click();

        public void ClickCrossButton() => CrossButton.Click();

        public void ClickCancelButton() => CancelButton.Click();

        public string GetConfigTextResult() => ConfigurationsTextElement.GetAttribute("innerText");
    }
}
