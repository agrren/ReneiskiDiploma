using OpenQA.Selenium;
using OrangeHRMTests.Common.Drivers;
using OrangeHRMTests.Common.WebElements;
using OrangeHRMTests.Data;

namespace OrangeHRMTests.PageObjects.Pages
{
    public class LoginPage : BasePage
    {
        private MyWebElement UserNameField = new MyWebElement(By.XPath("//*[contains(@class, 'form-row')]//*[contains(@name, 'username')]"));
        private MyWebElement PassWordField = new MyWebElement(By.XPath("//*[contains(@class, 'form-row')]//*[contains(@name, 'password')]"));
        private MyWebElement InvalidMessageTextElement = new MyWebElement(By.XPath("//*[contains(@class, 'login-error')]//*[contains(@class, 'alert-content-text')]"));
        private MyWebElement ForgotPasswordButton = new MyWebElement(By.XPath("//*[contains(@class, 'login-forgot')]/p"));

        public string GetCurrentPageUrl() => WebDriverFactory.Driver.Url;

        public void InputUserName(string value) => UserNameField.SendKeys(value);

        public void InputPassword(string value) => PassWordField.SendKeys(value);

        public void ClickLoginButton() => ClickSaveButton();

        public void ClickForgotPassword() => ForgotPasswordButton.Click();

        public string GetInvalidMessageTextResult() => InvalidMessageTextElement.Text;

        public void LogInToOrangeCRM()
        {
            InputUserName(TestSettings.Username);
            InputPassword(TestSettings.Password);
            ClickLoginButton();
        }
    }
}
