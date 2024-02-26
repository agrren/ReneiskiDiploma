using OpenQA.Selenium;
using OrangeHRMTests.Common.WebElements;

namespace OrangeHRMTests.PageObjects.Modules
{
    public static class TopbarMenu
    {
        private static MyWebElement ArrowButton = new MyWebElement(By.XPath("//*[contains(@class, 'userdropdown-tab')]//i"));
        private static MyWebElement AdminPageHeader = new MyWebElement(By.XPath("//div[@class='oxd-topbar-header-title']"));

        private static string TopbarMenuButtonByName = "//nav[contains(@role, 'navigation')]//*[contains(text(), '{0}')]";
        private static string UserDropdownItemByName = "//*[contains(@class, 'dropdown-menu')]//*[contains(text(),'{0}')]";

        public static void ClickTopbarMenuButtonByName(string value) => new MyWebElement(By.XPath(string.Format(TopbarMenuButtonByName, value))).Click();

        public static void ClickUserDropdownItemByName(string value) => new MyWebElement(By.XPath(string.Format(UserDropdownItemByName, value))).Click();

        public static void ClickArrowButton() => ArrowButton.Click();

        public static void ClickLogout() => ClickUserDropdownItemByName("Logout");

        public static string GetAdminPageHeaderTextResult() => AdminPageHeader.Text.Replace("\r\n", " / ");
    }
}
