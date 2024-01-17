using OpenQA.Selenium;
using OrangeHRMTests.Common.WebElements;

namespace OrangeHRMTests.Common.Extensions.ExtensionMethods
{
    public static class DropdownExtension
    {
        public static string DropDownList = "//div[@class='oxd-select-wrapper']/div[2]//*[contains(text(),'{0}')]";

        public static void ClickDropdownList (string value)
        {
            var element = new MyWebElement(By.XPath(string.Format(DropDownList, value)));
            element.Click();
        }
    }
}
