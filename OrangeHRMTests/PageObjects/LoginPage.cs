using OpenQA.Selenium;
using OrangeHRMTests.Common.WebElements;
using OrangeHRMTests.Data;
using OrangeHRMTests.PageObjects.Elements;

namespace OrangeHRMTests.PageObjects
{
    public class LoginPage : BasePage
    {
        private MyWebElement UserNameField = new MyWebElement(By.XPath("//*[@name='username']"));
        private MyWebElement PassWordField = new MyWebElement(By.XPath("//*[@name='password']"));
        private MyWebElement InvalidMessageTextElement = new MyWebElement(By.XPath("//p[@class='oxd-text oxd-text--p oxd-alert-content-text']"));
        private MyWebElement LogoutButton = new MyWebElement(By.XPath("//a[@href='/web/index.php/auth/logout']"));
        private MyWebElement ForgotPasswordButton = new MyWebElement(By.XPath("//*[text()='Forgot your password? ']"));
        private MyWebElement ResetPasswordMessageTextElement = new MyWebElement(By.XPath("//h6[@class='oxd-text oxd-text--h6 orangehrm-forgot-password-title']"));

        public string GetCurrentPageUrl() => Driver.Url;

        public void EnterValidUsername() => UserNameField.SendKeys(TestSettings.username);

        public void EnterValidPassword() => PassWordField.SendKeys(TestSettings.password);

        public void ClickLoginButton() => Buttons.ClickSaveButton();

        public void ClickLogout() => LogoutButton.Click();

        public void ClickForgotPassword() => ForgotPasswordButton.Click();

        public void ClickResetPasswordButton() => Buttons.ClickSaveButton();

        public void EnterInvalidUsername() => UserNameField.SendKeys(TestSettings.wusername);

        public void EnterInvalidPassword() => PassWordField.SendKeys(TestSettings.wpassword);

        public void EnterUserNameTextBoxElement() => Fields.EnterValueInInputTextField("Username", "111admin");

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
