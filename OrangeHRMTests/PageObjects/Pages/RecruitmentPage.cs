using OpenQA.Selenium;
using OrangeHRMTests.Common.WebElements;
using OrangeHRMTests.Data.Constants;

namespace OrangeHRMTests.PageObjects.Pages
{
    public class RecruitmentPage : BasePage
    {
        public const string DropDownListJobTitle = "//div[@class='oxd-select-wrapper']/div[2]//*[contains(text(),'{0}')]";
        public const string FullCandidateName = "//label[text()='Full Name']//ancestor::div[1]//following-sibling::div[1]//input[@name='{0}']";

        private MyWebElement EditVacanciesText = new MyWebElement(By.XPath("//*[contains(@class, 'container')]//*[contains(@class, 'main-title')][text()='Edit Vacancy']"));
        private MyWebElement ImployeeInformationText = new MyWebElement(By.XPath("//*[contains(@class, 'table-filter')]//*[contains(@class, 'table-filter-title')]"));

        public string GetVacanciesTextResult() => ImployeeInformationText.Text;

        public string GetEditVacanciesTextResult() => EditVacanciesText.Text;

        public void EnterCandidateName(string field, string value) => new MyWebElement(By.XPath(string.Format(FullCandidateName, field))).SendKeys(value);

        public void EnterFullCandidateName()
        {
            const string FirstName = "111";
            const string MiddleName = "222";
            const string LastName = "333";

            EnterCandidateName(InputFieldsNames.FirstNameInputFieldName, FirstName);
            EnterCandidateName(InputFieldsNames.MiddleNameInputFieldName, MiddleName);
            EnterCandidateName(InputFieldsNames.LastNameInputFieldName, LastName);
        }
    }
}
