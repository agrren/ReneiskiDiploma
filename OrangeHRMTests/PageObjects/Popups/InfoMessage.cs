using OpenQA.Selenium;
using OrangeHRMTests.Common.WebElements;

namespace OrangeHRMTests.PageObjects.Popups
{
    public class InfoMessage : BasePage
    {
        private MyWebElement InfoMessageText = new MyWebElement(By.XPath("//p[@class='oxd-text oxd-text--p oxd-text--toast-message oxd-toast-content-text']"));

        public string ReturnInfoMessageTextResult() => InfoMessageText.Text;
    }
}
