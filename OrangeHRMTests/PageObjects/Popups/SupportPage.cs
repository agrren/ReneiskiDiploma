using OpenQA.Selenium;
using OrangeHRMTests.Common.WebElements;

namespace OrangeHRMTests.PageObjects.Popups
{
    public class SupportPage : BasePage
    {
        private MyWebElement SupportButton = new MyWebElement(By.XPath("//a[@href='/web/index.php/help/support']"));
        private MyWebElement SupportTitleTextElement = new MyWebElement(By.XPath("//h6[@class='oxd-text oxd-text--h6 orangehrm-main-title']"));

        public void ClickSupport() => SupportButton.Click();

        public string ReturnSupportTitleTextResult() => SupportTitleTextElement.Text;
    }
}
