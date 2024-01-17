using OpenQA.Selenium;
using OrangeHRMTests.Common.WebElements;

namespace OrangeHRMTests.PageObjects.Popups
{
    public class AboutPage : BasePage
    {
        private MyWebElement AboutButton = new MyWebElement(By.XPath("//a[@href='#']"));
        private MyWebElement CloseAboutButton = new MyWebElement(By.XPath("//button[@class='oxd-dialog-close-button oxd-dialog-close-button-position']"));
        private MyWebElement AboutNameTextElement = new MyWebElement(By.XPath("//h6[@class='oxd-text oxd-text--h6 orangehrm-main-title']"));
        private MyWebElement AboutVersionTextElement = new MyWebElement(By.XPath("//div[@class='oxd-grid-2 orangehrm-about']/div[4]/p"));

        public void ClickAboutButton() => AboutButton.Click();

        public void ClickCloseAboutButton() => CloseAboutButton.Click();

        public string ReturnAboutNameTextResult() => AboutNameTextElement.GetAttribute("innerText");

        public string ReturnAboutVersionTextResult() => AboutVersionTextElement.GetAttribute("innerText");
    }
}
