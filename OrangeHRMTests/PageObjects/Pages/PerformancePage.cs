using OrangeHRMTests.Common.Extensions.ExtensionMethods;
using OrangeHRMTests.PageObjects.Modules;

namespace OrangeHRMTests.PageObjects.Pages
{
    public class PerformancePage : BasePage
    {
        public void ClickConfigureButton() => TopbarMenu.ClickTopbarMenuButtonByName("Configure ");

        public void ClickKPIsButton() => TopbarMenu.ClickTopbarMenuButtonByName("KPIs");

        public void EnterKeyPerformanceIndicator() => EnterValueInInputTextField("Key Performance Indicator", "111");

        public void EnterKeyMinimumRating() => EnterValueInInputTextField("Minimum Rating", "1");

        public void ClickJobTitleDropdownArrowButton() => ClickDropDownListArrowButtonByName("Job Title");

        public void ChooseJobTitle() => DropdownExtension.ClickDropdownList("IT Manager");
    }
}
