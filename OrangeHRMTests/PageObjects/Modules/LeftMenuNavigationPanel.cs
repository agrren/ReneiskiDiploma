using OpenQA.Selenium;
using OrangeHRMTests.Common.Drivers;
using OrangeHRMTests.Common.WebElements;
using System;

namespace OrangeHRMTests.PageObjects.Modules
{
    public class LeftMenuNavigationPanel
    {
        private MyWebElement SearchInputField = new MyWebElement(By.XPath("//input[@placeholder='Search']"));
        private MyWebElement SearchResultElement = new MyWebElement(By.XPath("//span[@class='oxd-text oxd-text--span oxd-main-menu-item--name']"));

        public string LeftMenuItem = "//a[@href='/web/index.php/{0}']";

        public void GoToLeftMenuItem(string value) => new MyWebElement(By.XPath(string.Format(LeftMenuItem, value))).Click();

        public void GoToAdminPage() => GoToLeftMenuItem("admin/viewAdminModule");

        public void GoToDashboardPage() => GoToLeftMenuItem("dashboard/index");

        public void GoToPIMPage() => GoToLeftMenuItem("pim/viewPimModule");

        public void GoToPerformancePage() => GoToLeftMenuItem("performance/viewPerformanceModule");

        public void GoToRecruitmentPage() => GoToLeftMenuItem("recruitment/viewRecruitmentModule");

        public void GoToLeavePage() => GoToLeftMenuItem("leave/viewLeaveModule");

        public void EnterValueToSearchInputField(string value) => SearchInputField.SendKeys(value);

        public void PressEnter() => WebDriverFactory.Actions.SendKeys(Keys.Enter);

        public void ClearSearchInputField() => SearchInputField.SendKeys(Keys.Control + "a" + Keys.Delete);

        public string ReturnSearchResultText() => SearchResultElement.Text;
    }
}
