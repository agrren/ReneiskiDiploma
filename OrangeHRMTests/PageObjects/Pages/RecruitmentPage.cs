using OpenQA.Selenium;
using OrangeHRMTests.Common.Extensions.ExtensionMethods;
using OrangeHRMTests.Common.WebElements;
using OrangeHRMTests.PageObjects.Modules;

namespace OrangeHRMTests.PageObjects.Pages
{
    public class RecruitmentPage : BasePage
    {
        private MyWebElement EditVacanciesText = new MyWebElement(By.XPath("//*[contains(@class, 'container')]//*[contains(@class, 'main-title')][text()='Edit Vacancy']"));

        public string DropDownListJobTitle = "//div[@class='oxd-select-wrapper']/div[2]//*[contains(text(),'{0}')]";
        public string FullCandidateName = "//label[text()='Full Name']//ancestor::div[1]//following-sibling::div[1]//input[@name='{0}']";

        public void ClickVacanciesButton() => TopbarMenu.ClickTopbarMenuButtonByName("Vacancies");

        public string GetVacanciesTextResult() => GenericPages.PIMPage.ImployeeInformationText.Text;

        public string GetEditVacanciesTextResult() => EditVacanciesText.Text;

        public void ClickCandidatesButton() => TopbarMenu.ClickTopbarMenuButtonByName("Candidates");

        public void ClickJobTitleDropdownArrowButton() => ClickDropDownListArrowButtonByName("Job Title");

        public void EnterVacancyName() => EnterValueInInputTextField("Vacancy Name", "111");

        public void EnterHiringManager() => EnterValueInInputTextField("Hiring Manager", "a");

        public void EnterEmail() => EnterValueInInputTextField("Email", "111@gmail.com");

        public void EnterCandidateName() => EnterValueInInputTextField("Candidate Name", "111");

        public void EnterCandidateName(string field, string value) => new MyWebElement(By.XPath(string.Format(FullCandidateName, field))).SendKeys(value);

        public void EnterFullCandidateName()
        {
            EnterCandidateName("firstName", "111");
            EnterCandidateName("middleName", "222");
            EnterCandidateName("lastName", "333");
        }

        public void ChooseJobTitle() => DropdownExtension.ClickDropdownList("IT Manager");
    }
}
