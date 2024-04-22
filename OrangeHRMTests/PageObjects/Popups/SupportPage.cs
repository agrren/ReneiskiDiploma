using OpenQA.Selenium;
using OrangeHRMTests.Common.WebElements;

namespace OrangeHRMTests.PageObjects.Popups
{
    public class SupportPage : BasePage
    {
        private MyWebElement SupportTitleTextElement = new MyWebElement(By.XPath("//*[contains(@class, 'card-container')]//*[contains(@class, 'main-title')]"));

        public string ReturnSupportTitleTextResult() => SupportTitleTextElement.Text;
    }
}
