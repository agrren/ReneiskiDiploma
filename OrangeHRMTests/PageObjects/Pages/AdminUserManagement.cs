using OpenQA.Selenium;
using OrangeHRMTests.Common.Extensions.ExtensionMethods;

namespace OrangeHRMTests.PageObjects.Pages
{
    public class AdminUserManagementPage : BasePage
    {
        public void EnterUserName() => EnterValueInInputTextField("Username", GetCellText("Username"));

        public void ClickUserRoleDropdownArrow() => ClickDropDownListArrowButtonByName("User Role");

        public void ClickUserStatusDropdownArrow() => ClickDropDownListArrowButtonByName("Status");

        public void EnterEmployeeName() => EnterValueInInputTextField("Employee Name", GetCellText("Employee Name"));

        public void ChooseUserRole() => DropdownExtension.ClickDropdownList(GetCellText("User Role"));

        public void ChooseUserStatus() => DropdownExtension.ClickDropdownList(GetCellText("Status"));
    }
}
