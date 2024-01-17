using OpenQA.Selenium;
using OrangeHRMTests.Common.Drivers;
using OrangeHRMTests.Common.WebElements;

namespace OrangeHRMTests.PageObjects.Modules
{
    public class LeftMenuNavigationPanel
    {
        private MyWebElement AdminMenuItem = new MyWebElement(By.XPath("//a[@href='/web/index.php/admin/viewAdminModule']"));
        private MyWebElement DashboardMenuItem = new MyWebElement(By.XPath("//a[@href='/web/index.php/dashboard/index']"));
        private MyWebElement PIMMenuItem = new MyWebElement(By.XPath("//a[@href='/web/index.php/pim/viewPimModule']"));
        private MyWebElement SearchInputField = new MyWebElement(By.XPath("//input[@placeholder='Search']"));
        private MyWebElement SearchResultElement = new MyWebElement(By.XPath("//span[@class='oxd-text oxd-text--span oxd-main-menu-item--name']"));
        private MyWebElement PerformanceMenuItem = new MyWebElement(By.XPath("//a[@href='/web/index.php/performance/viewPerformanceModule']"));
        private MyWebElement RecruitmentMenuItem = new MyWebElement(By.XPath("//a[@href='/web/index.php/recruitment/viewRecruitmentModule']"));
        private MyWebElement LeaveMenuItem = new MyWebElement(By.XPath("//a[@href='/web/index.php/leave/viewLeaveModule']"));

        public void GoToAdminPage() => AdminMenuItem.Click();

        public void GoToDashboardPage() => DashboardMenuItem.Click();

        public void GoToPIMPage() => PIMMenuItem.Click();

        public void GoToPerformancePage() => PerformanceMenuItem.Click();

        public void GoToRecruitmentPage() => RecruitmentMenuItem.Click();

        public void GoToLeavePage() => LeaveMenuItem.Click();

        public void EnterValueToSearchInputField(string value) => SearchInputField.SendKeys(value);

        public void PressEnter() => WebDriverFactory.Actions.SendKeys(Keys.Enter);

        public void ClearSearchInputField() => SearchInputField.SendKeys(Keys.Control + "a" + Keys.Delete);

        public string ReturnSearchResultText() => SearchResultElement.Text;
    }
}
