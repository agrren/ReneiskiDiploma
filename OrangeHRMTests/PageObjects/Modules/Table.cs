using OpenQA.Selenium;
using OrangeHRMTests.Common.WebElements;

namespace OrangeHRMTests.PageObjects.Modules
{
    public class Table
    {
        public const string XPathToTableCell = "(//*[contains(@class, 'table-card')]//div[@role='row'])[1]//div[@role='cell'][count(//div[text()='{0}']//preceding-sibling::div)+1]";

        private static MyWebElement DeleteSelectedButton = new MyWebElement(By.XPath("//*[contains(@class, 'padding')]//*[contains(@type, 'button')][contains(@class, 'danger')]"));
        private static MyWebElement PencilEditButton = new MyWebElement(By.XPath("(//*[contains(@class, 'table-card')]//*[contains(@role, 'row')])[1]//*[contains(@role, 'cell')][count(//div[text()='Actions']//preceding-sibling::div)+1]//i[contains(@class, 'bi-pencil-fill')]"));
        private static MyWebElement TrashButton = new MyWebElement(By.XPath("(//*[contains(@class, 'table-card')]//*[contains(@role, 'row')])[1]//*[contains(@role, 'cell')][count(//div[text()='Actions']//preceding-sibling::div)+1]//i[contains(@class, 'bi-trash')]"));
        private static MyWebElement TableCheckboxElement = new MyWebElement(By.XPath("(//*[contains(@class, 'table-card')]//*[contains(@role, 'row')])[1]//*[contains(@role, 'cell')]//i[contains(@class, 'checkbox-input-icon')]"));

        public static string GetCellText(string value) => new MyWebElement(By.XPath(string.Format(XPathToTableCell, value))).Text;

        public static void ClickTableCellByName(string value) => new MyWebElement(By.XPath(string.Format(XPathToTableCell, value))).Click();

        public static string GetValueOfTextFieldByName(string field) => new MyWebElement(By.XPath(string.Format(XPathToTableCell, field))).Text;

        public static void ClickDeleteSelectedButton() => DeleteSelectedButton.Click();

        public static void ClickPencilEditButton() => PencilEditButton.Click();

        public static void ClickTrashButton() => TrashButton.Click();

        public static void CheckTableCheckBoxElement() => TableCheckboxElement.Click();
    }
}
