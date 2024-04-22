using OpenQA.Selenium;
using OrangeHRMTests.Common.WebElements;

namespace OrangeHRMTests.PageObjects.Pages
{
    public class ResetPasswordPage : BasePage
    {
        private MyWebElement ResetPasswordMessageTextElement = new MyWebElement(By.XPath("//*[contains(@class, 'forgot-password-title')]"));

        public void ClickResetPasswordButton() => ClickSaveButton();

        public string GetResetPasswordMessageTextResult() => ResetPasswordMessageTextElement.Text;
    }
}
