using OpenQA.Selenium;
using OrangeHRMTests.Common.WebElements;

namespace OrangeHRMTests.PageObjects.Popups
{
    public class AboutPage : BasePage
    {
        private MyWebElement AboutNameTextElement = new MyWebElement(By.XPath("//*[contains(@class, 'dialog-container')]//*[contains(@class, 'main-title')]"));
        private MyWebElement AboutVersionTextElement = new MyWebElement(By.XPath("//*[contains(@class, 'dialog-container')]//*[contains(@class, 'about-title')][text()[normalize-space() = 'Version:']]//ancestor::div[1]//following-sibling::div[1]/p"));

        public string GetAboutNameTextResult() => AboutNameTextElement.Text;

        public string GetAboutVersionTextResult() => AboutVersionTextElement.Text;
    }
}
