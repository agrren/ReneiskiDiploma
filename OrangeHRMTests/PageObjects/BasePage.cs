using OpenQA.Selenium;
using OrangeHRMTests.Common.WebElements;
using OrangeHRMTests.PageObjects.Modules;

namespace OrangeHRMTests.PageObjects
{
    public class BasePage
    {
        private const string DropDownListArrowButtonByName = "//*[contains(@class, 'wrapper')]/*[contains(text(), '{0}')]//ancestor::div[contains(@class, 'wrapper')]//following-sibling::div[1]//i";
        private const string XPathInputTextFieldByName = "//*[contains(@class, 'input-field')]//*[contains(text(), '{0}')]//ancestor::div[1]//following-sibling::div[1]//input";

        private MyWebElement AddButton = new MyWebElement(By.XPath("//*[contains(@class, 'orangehrm-header-container')]//button"));
        private MyWebElement SaveButton = new MyWebElement(By.XPath("//button[@type='submit']"));
        private MyWebElement ConfirmDeletionButton = new MyWebElement(By.XPath("//*[contains(@class, 'orangehrm-modal')]//*[contains(@class, 'trash')]"));
        private MyWebElement SearchButton = new MyWebElement(By.XPath("//*[contains(@class, 'form')]//*[contains(@type, 'submit')]"));
        private MyWebElement MainTitleText = new MyWebElement(By.XPath("//*[contains(@class, 'container')]//*[contains(@class, 'main-title')]"));
        private MyWebElement PopUpMessageTextElement = new MyWebElement(By.XPath("//*[contains(@class, 'toast-container')]//p[contains(@class, 'toast-message')]"));
        private MyWebElement DropdownListFirstPosition = new MyWebElement(By.XPath("//*[contains(@role, 'listbox')]//span"));

        public LeftMenuNavigationPanel LeftMenuNavigationPanel => new LeftMenuNavigationPanel();
        public TopBarMenu TopBarMenu => new TopBarMenu();
        public Table Table => new Table();

        public void ClickDropDownListArrowButtonByName(string value) => new MyWebElement(By.XPath(string.Format(DropDownListArrowButtonByName, value))).Click();

        public void ClickAddButton() => AddButton.Click();

        public void ClickSaveButton() => SaveButton.Click();

        public void ClickSearchButton() => SearchButton.Click();

        public void ClickConfirmDeletionButton() => ConfirmDeletionButton.Click();

        public void ClickDropdownListFirstPosition() => DropdownListFirstPosition.Click();

        public void ChooseValueFromDropDownByName(string name, string value) => new OrangeDropDown(name).SelectDropDownValue(value);

        public void EnterValueInInputTextField(string field, string value) => new MyWebElement(By.XPath(string.Format(XPathInputTextFieldByName, field))).SendKeys(value);

        public string GetMainTitleText() => MainTitleText.Text;

        public string GetPopUpMessageTextElement() => PopUpMessageTextElement.Text;
    }
}
