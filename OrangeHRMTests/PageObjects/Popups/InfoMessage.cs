using OpenQA.Selenium;
using OrangeHRMTests.Common.WebElements;

namespace OrangeHRMTests.PageObjects.Popups
{
    public class InfoMessage : BasePage
    {
        private MyWebElement InfoMessageText = new MyWebElement(By.XPath("//*[contains(@class, 'toast-container')]//*[contains(@class, 'toast-message')]"));

        public string GetInfoMessageTextResult() => InfoMessageText.Text;
    }
}
