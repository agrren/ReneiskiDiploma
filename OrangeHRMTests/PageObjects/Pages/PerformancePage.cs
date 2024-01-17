using OrangeHRMTests.Common.Extensions.ExtensionMethods;
using OrangeHRMTests.PageObjects.Elements;

namespace OrangeHRMTests.PageObjects.Pages
{
    public class PerformancePage : BasePage
    {
        public void ClickConfigureButton() => TopbarMenu.ClickTopbarMenuButtonByName("Configure ");

        public void ClickKPIsButton() => TopbarMenu.ClickTopbarMenuButtonByName("KPIs");

        public void EnterKeyPerformanceIndicator() => Fields.EnterValueInInputTextField("Key Performance Indicator", "111");

        public void EnterKeyMinimumRating() => Fields.EnterValueInInputTextField("Minimum Rating", "1");

        public void ClickJobTitleDropdownArrowButton() => Buttons.ClickRequieredDropDownListArrowButtonByName("Job Title");

        public void ChooseJobTitle() => DropdownExtension.ClickDropdownList("IT Manager");
    }
}
