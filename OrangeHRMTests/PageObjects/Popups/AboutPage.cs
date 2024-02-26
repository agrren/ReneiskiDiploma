using OpenQA.Selenium;
using OrangeHRMTests.Common.WebElements;
using OrangeHRMTests.PageObjects.Modules;

namespace OrangeHRMTests.PageObjects.Popups
{
    public class AboutPage : BasePage
    {
        private MyWebElement CloseAboutButton = new MyWebElement(By.XPath("//*[contains(@class, 'dialog-container')]//button[contains(@class, 'dialog-close-button')]"));
        private MyWebElement AboutNameTextElement = new MyWebElement(By.XPath("//*[contains(@class, 'dialog-container')]//*[contains(@class, 'main-title')]"));
        private MyWebElement AboutVersionTextElement = new MyWebElement(By.XPath("//*[contains(@class, 'dialog-container')]//*[contains(@class, 'about-title')][text()='Version: ']//ancestor::div[1]//following-sibling::div[1]/p"));

        public void ClickAboutButton() => TopbarMenu.ClickUserDropdownItemByName("About");

        public void ClickCloseAboutButton() => CloseAboutButton.Click();

        public string ReturnAboutNameTextResult() => AboutNameTextElement.GetAttribute("innerText");

        public string ReturnAboutVersionTextResult() => AboutVersionTextElement.GetAttribute("innerText");
    }
}
