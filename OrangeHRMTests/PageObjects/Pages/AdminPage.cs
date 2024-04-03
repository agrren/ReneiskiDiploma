using OpenQA.Selenium;
using OrangeHRMTests.Common.WebElements;
using OrangeHRMTests.Data.Constants;

namespace OrangeHRMTests.PageObjects.Pages
{
    public class AdminPage : BasePage
    {
        private MyWebElement SystemUserTableHeaderElement = new MyWebElement(By.XPath("//*[contains(@class, 'table-filter')]//*[contains(@class, 'filter-title')]"));
        private MyWebElement DropdownElement = new MyWebElement(By.XPath("//ul[@class='oxd-dropdown-menu']//*[contains(@role, 'menuitem')]"));
        private MyWebElement EditNationalityNameTextBoxElement = new MyWebElement(By.XPath("//*[contains(@class, 'input-field')]//*[contains(text(), 'Name')]//ancestor::div[1]//following-sibling::div[1]//input"));

        public void ClearNationalityName()
        {
            MyWebElement.WaitForInvisibilityOfElement();
            EnterValueInInputTextField(InputFieldsNames.NameInputFieldName, Keys.Control + "a" + Keys.Delete);
        }

        public void EnterNationalityNameBack(string value) => EditNationalityNameTextBoxElement.SendKeys(value);

        public string GetSystemUserTableHeaderTextResult() => SystemUserTableHeaderElement.Text;

        public string GetOpenedDropDownFirstOption() => DropdownElement.Text;
    }
}
