using OpenQA.Selenium;
using OrangeHRMTests.Common.Drivers;
using OrangeHRMTests.Common.WebElements;
using OrangeHRMTests.Data;

namespace OrangeHRMTests.PageObjects
{
    public class LoginPage : BasePage
    {
        private MyWebElement UserNameField = new MyWebElement(By.XPath("//*[contains(@class, 'form-row')]//*[contains(@name, 'username')]"));
        private MyWebElement PassWordField = new MyWebElement(By.XPath("//*[contains(@class, 'form-row')]//*[contains(@name, 'password')]"));
        private MyWebElement InvalidMessageTextElement = new MyWebElement(By.XPath("//*[contains(@class, 'login-error')]//*[contains(@class, 'alert-content-text')]"));
        private MyWebElement ForgotPasswordButton = new MyWebElement(By.XPath("//*[contains(@class, 'login-forgot')]/p"));
        private MyWebElement ResetPasswordMessageTextElement = new MyWebElement(By.XPath("//*[contains(@class, 'forgot-password-title')]"));

        public string GetCurrentPageUrl() => WebDriverFactory.Driver.Url;

        public void EnterValidUsername() => UserNameField.SendKeys(TestSettings.Username);

        public void EnterValidPassword() => PassWordField.SendKeys(TestSettings.Password);

        public void ClickLoginButton() => BasePage.ClickSaveButton();

        public void ClickForgotPassword() => ForgotPasswordButton.Click();

        public void ClickResetPasswordButton() => BasePage.ClickSaveButton();

        public void EnterInvalidUsername() => UserNameField.SendKeys(TestSettings.UnvalidUsername);

        public void EnterInvalidPassword() => PassWordField.SendKeys(TestSettings.UnvalidPassword);

        public void EnterUserNameTextBoxElement() => BasePage.EnterValueInInputTextField("Username", "111admin");

        public string ReturnInvalidMessageTextResult() => InvalidMessageTextElement.Text;

        public string ReturnResetPasswordMessageTextResult() => ResetPasswordMessageTextElement.Text;

        public void LogInToOrangeCRM()
        {
            EnterValidUsername();
            EnterValidPassword();
            ClickLoginButton();
        }
    }
}
