namespace OrangeHRMTests.Common.WebElements
{
    public class OrangeDropDown : MyWebElement
    {
        private const string DropDownListArrowButtonByName = "//*[contains(@class, 'wrapper')]/*[contains(text(), '{0}')]//ancestor::div[contains(@class, 'wrapper')]//following-sibling::div[1]//i";
        private static string OrangeDropDownList = "//*[contains(@class, 'select-wrapper')]/div[2]//*[contains(text(), '{0}')]";

        public OrangeDropDown(string dropDownName) : base(OpenQA.Selenium.By.XPath($"{string.Format(DropDownListArrowButtonByName, dropDownName)}"))
        {
        }

        public void OpenDropDown() => Click();

        public void SelectDropDownValue(string dropDownValue)
        {
            OpenDropDown();
            new MyWebElement(OpenQA.Selenium.By.XPath(string.Format(OrangeDropDownList, dropDownValue))).Click();
        }
    }
}
