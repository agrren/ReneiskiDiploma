using OpenQA.Selenium;
using OrangeHRMTests.Common.WebElements;

namespace OrangeHRMTests.PageObjects.Elements
{
    public static class Fields
    {
        public static string XPathInputTextFieldByName = "//label[text()='{0}']//ancestor::div[1]//following-sibling::div[1]//input";

        public static void EnterValueInInputTextField (string field, string value) => new MyWebElement(By.XPath(string.Format(XPathInputTextFieldByName, field))).SendKeys(value);
    }
}
