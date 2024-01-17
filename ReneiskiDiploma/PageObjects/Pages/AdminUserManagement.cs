using OpenQA.Selenium;
using OrangeHRMTests.Common.Extensions.ExtensionMethods;
using OrangeHRMTests.PageObjects.Elements;

namespace OrangeHRMTests.PageObjects.Pages
{
    public class AdminUserManagement : BasePage
    {
        public void EnterUserName() => Fields.EnterValueInInputTextField("Username", Tables.GetCellText("Username"));

        public void ClickUserRoleDropdownArrow() => Buttons.ClickDropDownListArrowButtonByName("User Role");

        public void ClickUserStatusDropdownArrow() => Buttons.ClickDropDownListArrowButtonByName("Status");

        public void EnterEmployeeName() => Fields.EnterValueInInputTextField("Employee Name", Tables.GetCellText("Employee Name"));

        public void ChooseUserRole() => DropdownExtension.ClickDropdownList(Elements.Tables.GetCellText("User Role"));

        public void ChooseUserStatus() => DropdownExtension.ClickDropdownList(Elements.Tables.GetCellText("Status"));
    }
}
