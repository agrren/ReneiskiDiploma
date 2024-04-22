using OpenQA.Selenium;
using OrangeHRMTests.Common.WebElements;

namespace OrangeHRMTests.PageObjects.Pages
{
    public class DashboardPage : BasePage
    {
        private const string DialogModalClassName = "dialog-modal";
        private const string HeaderByName = "//*[contains(@class, 'dashboard-widget')]//*[contains(@class, 'widget-name')]/p[text()='{0}']";
        private const string ConfigurationsTextElement = "//*[contains(@class, '{0}')]//*[contains(@class, 'card-title')]";
        private const string CrossButton = "//*[contains(@class, '{0}')]/button[contains(@class, 'dialog-close-button')]";
        private const string CancelButton = "//*[contains(@class, '{0}')]//button[contains(@type, 'button')]";

        private MyWebElement GearwheelButton = new MyWebElement(By.XPath("//*[contains(@class, 'gear')]"));

        public string GetTextResultByName(string field) => new MyWebElement(By.XPath(string.Format(HeaderByName, field))).Text;

        public void ClickWheelButton() => GearwheelButton.Click();

        public void ClickCrossButton() => new MyWebElement(By.XPath(string.Format(CrossButton, DialogModalClassName))).Click();

        public void ClickCancelButton() => new MyWebElement(By.XPath(string.Format(CancelButton, DialogModalClassName))).Click();

        public string GetConfigTextResult() => new MyWebElement(By.XPath(string.Format(ConfigurationsTextElement, DialogModalClassName))).GetAttribute("innerText");
    }
}
