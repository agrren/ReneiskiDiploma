using OpenQA.Selenium;
using OrangeHRMTests.Common.WebElements;
using OrangeHRMTests.Data.Constants;

namespace OrangeHRMTests.PageObjects.Pages
{
    public class RecruitmentPage : BasePage
    {
        private const string FullCandidateName = "//label[text()='Full Name']//ancestor::div[1]//following-sibling::div[1]//input[@name='{0}']";

        private MyWebElement EditVacanciesText = new MyWebElement(By.XPath("//*[contains(@class, 'container')]//*[contains(@class, 'main-title')][text()='Edit Vacancy']"));
        private MyWebElement ImployeeInformationText = new MyWebElement(By.XPath("//*[contains(@class, 'table-filter')]//*[contains(@class, 'table-filter-title')]"));

        public string GetVacanciesTextResult() => ImployeeInformationText.Text;

        public string GetEditVacanciesTextResult() => EditVacanciesText.Text;

        public void EnterCandidateName(string field, string value) => new MyWebElement(By.XPath(string.Format(FullCandidateName, field))).SendKeys(value);

        public void EnterFullCandidateName(string newFirstName, string newMiddleName, string newLastName)
        {
            EnterCandidateName(InputFieldsNames.FirstNameInputFieldName, newFirstName);
            EnterCandidateName(InputFieldsNames.MiddleNameInputFieldName, newMiddleName);
            EnterCandidateName(InputFieldsNames.LastNameInputFieldName, newLastName);
        }
    }
}
