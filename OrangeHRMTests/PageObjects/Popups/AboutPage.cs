﻿using OpenQA.Selenium;
using OrangeHRMTests.Common.WebElements;

namespace OrangeHRMTests.PageObjects.Popups
{
    public class AboutPage : BasePage
    {
        private MyWebElement CloseAboutButton = new MyWebElement(By.XPath("//*[contains(@class, 'dialog-container')]//button[contains(@class, 'dialog-close-button')]"));
        private MyWebElement AboutNameTextElement = new MyWebElement(By.XPath("//*[contains(@class, 'dialog-container')]//*[contains(@class, 'main-title')]"));
        private MyWebElement AboutVersionTextElement = new MyWebElement(By.XPath("//*[contains(@class, 'dialog-container')]//*[contains(@class, 'about-title')][text()='Version: ']//ancestor::div[1]//following-sibling::div[1]/p"));

        public void ClickCloseAboutButton() => CloseAboutButton.Click();

        public string GetAboutNameTextResult() => AboutNameTextElement.Text;

        public string GetAboutVersionTextResult() => AboutVersionTextElement.Text;
    }
}
