using OpenQA.Selenium;
using OrangeHRMTests.Common.WebElements;

namespace OrangeHRMTests.PageObjects.Elements
{
    public static class Buttons
    {
        private static MyWebElement AddButton = new MyWebElement(By.XPath("//button[@class='oxd-button oxd-button--medium oxd-button--secondary'][text()=' Add ']"));
        private static MyWebElement SaveButton = new MyWebElement(By.XPath("//button[@type='submit']"));
        private static MyWebElement ConfirmDeletionButton = new MyWebElement(By.XPath("//button[@class='oxd-button oxd-button--medium oxd-button--label-danger orangehrm-button-margin']"));
        private static MyWebElement SearchButton = new MyWebElement(By.XPath("//button[@type='submit'][text()=' Search ']"));
        private static MyWebElement DeleteSelectedButton = new MyWebElement(By.XPath("//button[@type='button'][text()=' Delete Selected ']"));

        public static string DropDownListArrowButtonByName = "//label[@class='oxd-label'][text()='{0}']//ancestor::div[1]//following-sibling::div[1]//i";
        public static string RequieredDropDownListArrowButtonByName = "//label[@class='oxd-label oxd-input-field-required'][text()='{0}']//ancestor::div[1]//following-sibling::div[1]//i";

        public static void ClickDropDownListArrowButtonByName(string value)
        {
            var element = new MyWebElement(By.XPath(string.Format(DropDownListArrowButtonByName, value)));
            element.Click();
        }

        public static void ClickRequieredDropDownListArrowButtonByName(string value)
        {
            var element = new MyWebElement(By.XPath(string.Format(RequieredDropDownListArrowButtonByName, value)));
            element.Click();
        }

        public static void ClickAddButton() => AddButton.Click();

        public static void ClickSaveButton() => SaveButton.Click();

        public static void ClickSearchButton() => SearchButton.Click();

        public static void ClickConfirmDeletionButton() => ConfirmDeletionButton.Click();

        public static void ClickDeleteSelectedButton() => DeleteSelectedButton.Click();
    }
}
