using OpenQA.Selenium;
using OrangeHRMTests.Common.WebElements;

namespace OrangeHRMTests.PageObjects.Modules
{
    public class Table
    {
        private const string XPathToTableCell = "(//*[contains(@class, 'table-card')]//div[@role='row'])[1]//div[@role='cell'][count(//div[text()='{0}']//preceding-sibling::div)+1]";

        private MyWebElement DeleteSelectedButton = new MyWebElement(By.XPath("//*[contains(@class, 'padding')]//*[contains(@type, 'button')][contains(@class, 'danger')]"));
        private MyWebElement PencilEditButton = new MyWebElement(By.XPath("(//*[contains(@class, 'table-card')]//*[contains(@role, 'row')])[1]//*[contains(@role, 'cell')][count(//div[text()='Actions']//preceding-sibling::div)+1]//i[contains(@class, 'bi-pencil-fill')]"));
        private MyWebElement TrashButton = new MyWebElement(By.XPath("(//*[contains(@class, 'table-card')]//*[contains(@role, 'row')])[1]//*[contains(@role, 'cell')][count(//div[text()='Actions']//preceding-sibling::div)+1]//i[contains(@class, 'bi-trash')]"));
        private MyWebElement TableCheckboxElement = new MyWebElement(By.XPath("(//*[contains(@class, 'table-card')]//*[contains(@role, 'row')])[1]//*[contains(@role, 'cell')]//i[contains(@class, 'checkbox-input-icon')]"));

        public string GetCellText(string value) => new MyWebElement(By.XPath(string.Format(XPathToTableCell, value))).Text;

        public void ClickTableCellByName(string value) => new MyWebElement(By.XPath(string.Format(XPathToTableCell, value))).Click();

        public string GetValueOfTextFieldByName(string field) => new MyWebElement(By.XPath(string.Format(XPathToTableCell, field))).Text;

        public void ClickDeleteSelectedButton() => DeleteSelectedButton.Click();

        public void ClickPencilEditButton() => PencilEditButton.Click();

        public void ClickTrashButton() => TrashButton.Click();

        public void CheckTableCheckBoxElement() => TableCheckboxElement.Click();
    }
}
