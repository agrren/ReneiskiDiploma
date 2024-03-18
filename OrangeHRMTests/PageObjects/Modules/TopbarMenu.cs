using OpenQA.Selenium;
using OrangeHRMTests.Common.WebElements;

namespace OrangeHRMTests.PageObjects.Modules
{
    public class TopBarMenu
    {
        private const string TopbarMenuButtonByName = "//nav[contains(@role, 'navigation')]//*[contains(text(), '{0}')]";
        private const string UserDropdownItemByName = "//*[contains(@class, 'dropdown-menu')]//*[contains(text(),'{0}')]";

        private MyWebElement ArrowButton = new MyWebElement(By.XPath("//*[contains(@class, 'userdropdown-tab')]//i"));
        private MyWebElement AdminPageHeader = new MyWebElement(By.XPath("//*[contains(@class, 'topbar-header-title')]"));

        public void ClickTopbarMenuButtonByName(string value) => new MyWebElement(By.XPath(string.Format(TopbarMenuButtonByName, value))).Click();

        public void ClickUserDropdownItemByName(string value) => new MyWebElement(By.XPath(string.Format(UserDropdownItemByName, value))).Click();

        public void ClickArrowButton() => ArrowButton.Click();

        public string GetAdminPageHeaderTextResult() => AdminPageHeader.Text.Replace("\r\n", " / ");
    }
}
