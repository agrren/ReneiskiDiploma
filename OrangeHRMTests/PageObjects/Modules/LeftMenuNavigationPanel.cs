using OpenQA.Selenium;
using OrangeHRMTests.Common.Drivers;
using OrangeHRMTests.Common.WebElements;

namespace OrangeHRMTests.PageObjects.Modules
{
    public class LeftMenuNavigationPanel
    {
        private MyWebElement SearchInputField = new MyWebElement(By.XPath("//*[contains(@placeholder, 'Search')]"));
        private MyWebElement SearchResultElement = new MyWebElement(By.XPath("//*[contains(@class, 'main-menu-item--name')]"));

        private const string LeftMenuItem = "//*[contains(@class, 'main-menu-item')]/*[text()='{0}']";

        public void GoToLeftMenuItem(string value) => new MyWebElement(By.XPath(string.Format(LeftMenuItem, value))).Click();

        public void EnterValueToSearchInputField(string value) => SearchInputField.SendKeys(value);

        public void PressEnter() => WebDriverFactory.Actions.SendKeys(Keys.Enter);

        public void ClearSearchInputField() => SearchInputField.SendKeys(Keys.Control + "a" + Keys.Delete);

        public string ReturnSearchResultText() => SearchResultElement.Text;
    }
}
