using OpenQA.Selenium;
using OrangeHRMTests.Common.WebElements;
using OrangeHRMTests.PageObjects.Modules;

namespace OrangeHRMTests.PageObjects.Popups
{
    public class SupportPage : BasePage
    {
        private MyWebElement SupportTitleTextElement = new MyWebElement(By.XPath("//*[contains(@class, 'card-container')]//*[contains(@class, 'main-title')]"));

        public void ClickSupport() => TopbarMenu.ClickUserDropdownItemByName("Support");

        public string ReturnSupportTitleTextResult() => SupportTitleTextElement.Text;
    }
}
