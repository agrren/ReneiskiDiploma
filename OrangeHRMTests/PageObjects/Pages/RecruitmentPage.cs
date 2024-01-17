using OpenQA.Selenium;
using OrangeHRMTests.Common.Extensions.ExtensionMethods;
using OrangeHRMTests.Common.WebElements;
using OrangeHRMTests.PageObjects.Elements;

namespace OrangeHRMTests.PageObjects.Pages
{
    public class RecruitmentPage : BasePage
    {
        private MyWebElement HiringManagerListFirstPosition = new MyWebElement(By.XPath("//div[@role='listbox']/div[1]/span"));
        private MyWebElement VacanciesText = new MyWebElement(By.XPath("//h5[@class='oxd-text oxd-text--h5 oxd-table-filter-title'][text()='Vacancies']"));

        public string DropDownListJobTitle = "//div[@class='oxd-select-wrapper']/div[2]//*[contains(text(),'{0}')]";
        public string FullCandidateName = "//label[text()='Full Name']//ancestor::div[1]//following-sibling::div[1]//input[@name='{0}']";

        public void ClickVacanciesButton() => TopbarMenu.ClickTopbarMenuButtonByName("Vacancies");

        public string VacanciesTextResult() => VacanciesText.Text;

        public void ClickCandidatesButton() => TopbarMenu.ClickTopbarMenuButtonByName("Candidates");

        public void ClickJobTitleDropdownArrowButton() => Buttons.ClickRequieredDropDownListArrowButtonByName("Job Title");

        public void ClickCandidateNameFirstPosition() => HiringManagerListFirstPosition.Click();

        public void ClickHiringManagerListFirstPosition() => HiringManagerListFirstPosition.Click();

        public void EnterVacancyName() => Fields.EnterValueInInputTextField("Vacancy Name", "111");

        public void EnterHiringManager() => Fields.EnterValueInInputTextField("Hiring Manager", "a");

        public void EnterEmail() => Fields.EnterValueInInputTextField("Email", "111@gmail.com");

        public void EnterCandidateName() => Fields.EnterValueInInputTextField("Candidate Name", "111");

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
