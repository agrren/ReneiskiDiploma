using OpenQA.Selenium;
using OrangeHRMTests.Common.WebElements;
using OrangeHRMTests.PageObjects.Modules;

namespace OrangeHRMTests.PageObjects
{
    public class BasePage
    {
        public LeftMenuNavigationPanel LeftMenuNavigationPanel => new LeftMenuNavigationPanel();

        private static MyWebElement AddButton = new MyWebElement(By.XPath("//*[contains(@class, 'orangehrm-header-container')]//button"));
        private static MyWebElement SaveButton = new MyWebElement(By.XPath("//button[@type='submit']"));
        private static MyWebElement ConfirmDeletionButton = new MyWebElement(By.XPath("//*[contains(@class, 'orangehrm-modal')]//*[contains(@class, 'trash')]"));
        private static MyWebElement SearchButton = new MyWebElement(By.XPath("//*[contains(@class, 'form')]//*[contains(@type, 'submit')]"));
        private static MyWebElement DeleteSelectedButton = new MyWebElement(By.XPath("//*[contains(@class, 'padding')]//*[contains(@type, 'button')][contains(@class, 'danger')]"));
        private static MyWebElement PencilEditButton = new MyWebElement(By.XPath("(//div[@class='oxd-table-card']//div[@role='row'])[1]//div[@role='cell'][count(//div[text()='Actions']//preceding-sibling::div)+1]//i[@class='oxd-icon bi-pencil-fill']"));
        private static MyWebElement TrashButton = new MyWebElement(By.XPath("(//div[@class='oxd-table-card']//div[@role='row'])[1]//div[@role='cell'][count(//div[text()='Actions']//preceding-sibling::div)+1]//i[@class='oxd-icon bi-trash']"));
        private static MyWebElement TableCheckboxElement = new MyWebElement(By.XPath("(//div[@class='oxd-table-card']//div[@role='row'])[1]//div[@role='cell']//i[@class='oxd-icon bi-check oxd-checkbox-input-icon']"));
        public static MyWebElement MainTitleText = new MyWebElement(By.XPath("//*[contains(@class, 'container')]//*[contains(@class, 'main-title')]"));
        public static MyWebElement PopUpMessageTextElement = new MyWebElement(By.XPath("//*[contains(@class, 'toast-container')]//p[contains(@class, 'toast-message')]"));

        public static string DropDownListArrowButtonByName = "//*[contains(@class, 'wrapper')]/*[contains(text(), '{0}')]//ancestor::div[contains(@class, 'wrapper')]//following-sibling::div[1]//i";
        public static string XPathInputTextFieldByName = "//*[contains(@class, 'input-field')]//*[contains(text(), '{0}')]//ancestor::div[1]//following-sibling::div[1]//input";
        public static string XPathToTableCell = "(//*[contains(@class, 'table-card')]//div[@role='row'])[1]//div[@role='cell'][count(//div[text()='{0}']//preceding-sibling::div)+1]";

        public static void ClickDropDownListArrowButtonByName(string value)
        {
            var element = new MyWebElement(By.XPath(string.Format(DropDownListArrowButtonByName, value)));
            element.Click();
        }

        public static void ClickAddButton() => AddButton.Click();

        public static void ClickSaveButton() => SaveButton.Click();

        public static void ClickSearchButton() => SearchButton.Click();

        public static void ClickConfirmDeletionButton() => ConfirmDeletionButton.Click();

        public static void ClickDeleteSelectedButton() => DeleteSelectedButton.Click();

        public static void EnterValueInInputTextField(string field, string value) => new MyWebElement(By.XPath(string.Format(XPathInputTextFieldByName, field))).SendKeys(value);

        public static void EnterEmployeeName() => EnterValueInInputTextField("Employee Name", "111 222");

        public static string GetCellText(string value) => new MyWebElement(By.XPath(string.Format(XPathToTableCell, value))).Text;

        public static void ClickPencilEditButton() => PencilEditButton.Click();

        public static void ClickTrashButton() => TrashButton.Click();

        public static void CheckTableCheckBoxElement() => TableCheckboxElement.Click();

        public static void ClickTableCellByName(string value) => new MyWebElement(By.XPath(string.Format(XPathToTableCell, value))).Click();

        public static string ReturnValueOfTextFieldByName(string field) => new MyWebElement(By.XPath(string.Format(XPathToTableCell, field))).Text;
    }
}
