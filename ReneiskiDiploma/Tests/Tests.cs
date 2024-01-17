using NUnit.Framework;
using OrangeHRMTests.Common.Extensions.ExtensionMethods;
using OrangeHRMTests.Data.Constants;
using OrangeHRMTests.PageObjects;
using OrangeHRMTests.PageObjects.Elements;

namespace OrangeHRMTests.Tests
{
    public class DemoQATests : BaseTest
    {
        [Test]
        public void A_AboutModalTest()
        {
            GenericPages.DashboardPage.ClickArrowButton();
            GenericPages.AboutPage.ClickAboutButton();

            Assert.AreEqual("About", GenericPages.AboutPage.ReturnAboutNameTextResult());
            Assert.AreEqual("OrangeHRM OS 5.5", GenericPages.AboutPage.ReturnAboutVersionTextResult());

            GenericPages.AboutPage.ClickCloseAboutButton();
        }

        [Test]
        public void B_SupportPageTest()
        {
            GenericPages.DashboardPage.ClickArrowButton();
            GenericPages.SupportPage.ClickSupport();

            Assert.AreEqual("Getting Started with OrangeHRM", GenericPages.SupportPage.ReturnSupportTitleTextResult());
        }

        [Test]
        public void C_DashboardPageTest()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToDashboardPage();

            Assert.AreEqual("Time at Work", GenericPages.DashboardPage.ReturnTimeAtWorkTextResult());
            Assert.AreEqual("My Actions", GenericPages.DashboardPage.ReturnMyActionTextResult());
            Assert.AreEqual("Quick Launch", GenericPages.DashboardPage.ReturnQuckLaunchTextResult());
            Assert.AreEqual("Buzz Latest Posts", GenericPages.DashboardPage.ReturnBuzzLatestPostTextResult());
            Assert.AreEqual("Employees on Leave Today", GenericPages.DashboardPage.ReturnOnLeaveTextResult());
            Assert.AreEqual("Employee Distribution by Sub Unit", GenericPages.DashboardPage.ReturnBySubUnitTextResult());
            Assert.AreEqual("Employee Distribution by Location", GenericPages.DashboardPage.ReturnByLocationTextResult());

            GenericPages.DashboardPage.ClickWheelButton();

            Assert.AreEqual("Configurations", GenericPages.DashboardPage.ReturnConfigTextResult());

            GenericPages.DashboardPage.ClickCrossButton();
            GenericPages.DashboardPage.ClickWheelButton();

            Assert.AreEqual("Configurations", GenericPages.DashboardPage.ReturnConfigTextResult());

            GenericPages.DashboardPage.ClickCancelButton();
        }

        [Test]
        public void D_AdminPageTest()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToAdminPage();

            var username = Tables.GetCellText("Username");
            var userRole = Tables.GetCellText("User Role");
            var employeename = Tables.GetCellText("Employee Name");
            var userStatus = Tables.GetCellText("Status");

            Assert.AreEqual("Admin", GenericPages.AdminPage.ReturnAdminPageHeaderPartOneTextResult());
            Assert.AreEqual("User Management", GenericPages.AdminPage.ReturnAdminPageHeaderPartTwoTextResult());
            Assert.AreEqual("System Users", GenericPages.AdminPage.ReturnSystemUserTableHeaderTextResult());

            GenericPages.AdminUserManagement.EnterUserName();
            GenericPages.AdminUserManagement.ClickUserRoleDropdownArrow();
            GenericPages.AdminUserManagement.ChooseUserRole();
            GenericPages.AdminUserManagement.EnterEmployeeName();
            GenericPages.AdminUserManagement.ClickUserStatusDropdownArrow();
            GenericPages.AdminUserManagement.ChooseUserStatus();
            Buttons.ClickSearchButton();

            Assert.AreEqual(username, Tables.GetCellText("Username"));
            Assert.AreEqual(userRole, Tables.GetCellText("User Role"));
            Assert.AreEqual(employeename, Tables.GetCellText("Employee Name"));
            Assert.AreEqual(userStatus, Tables.GetCellText("Status"));
        }

        [Test]
        public void E_PIMPageAddEmployeeTest()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToPIMPage();

            Buttons.ClickAddButton();
            GenericPages.PIMPage.EnterFullUserName();
            GenericPages.PIMPage.ClickSaveOneButton();
            GenericPages.PIMPage.ClickSaveTwoButton();
            GenericPages.PIMPage.ClickEmployeeListButton();

            Assert.AreEqual("111 222", GenericPages.PIMPage.ReturnFirstAndMiddleNameTextResult());
            Assert.AreEqual("333", GenericPages.PIMPage.ReturnLastNameTextResult());

            GenericPages.BasePage.DeleteCreatedEmployee();
        }

        [Test]
        public void F_SearchFunctionalityTest()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.EnterValueToSearchInputField("PIM");
            GenericPages.BasePage.LeftMenuNavigationPanel.PressEnter();

            Assert.AreEqual("PIM", GenericPages.BasePage.LeftMenuNavigationPanel.ReturnSearchResultText());

            GenericPages.BasePage.LeftMenuNavigationPanel.ClearSearchInputField();
        }

        [Test]
        public void G_PerformanceManagementTest()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToPerformancePage();

            GenericPages.PerformancePage.ClickConfigureButton();
            GenericPages.PerformancePage.ClickKPIsButton();
            Buttons.ClickAddButton();
            GenericPages.PerformancePage.EnterKeyPerformanceIndicator();
            GenericPages.PerformancePage.ClickJobTitleDropdownArrowButton();
            GenericPages.PerformancePage.ChooseJobTitle();
            GenericPages.PerformancePage.EnterKeyMinimumRating();
            Buttons.ClickSaveButton();

            Assert.AreEqual("111", Tables.GetCellText("Key Performance Indicator"));
            Assert.AreEqual("IT Manager", Tables.GetCellText("Job Title"));
            Assert.AreEqual("1", Tables.GetCellText("Min Rate"));

            Tables.ClickTrashButton();
            Buttons.ClickConfirmDeletionButton();

            Assert.AreNotEqual("111", Tables.GetCellText("Key Performance Indicator"));
            Assert.AreNotEqual("IT Manager", Tables.GetCellText("Job Title"));
            Assert.AreNotEqual("1", Tables.GetCellText("Min Rate"));
        }

        [Test]
        public void H_AdminFunctionalityTest()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToAdminPage();

            GenericPages.AdminPage.ClickUserManagementDropdownButton();

            Assert.AreEqual("Users", GenericPages.AdminPage.ReturnUsersDropdownElementText());

            GenericPages.AdminPage.ClickJobDropdownButton();

            Assert.AreEqual("Job Titles", GenericPages.AdminPage.ReturnJobTitleDropdownElementText());
        }

        [Test]
        public void I_EditNationalityTest()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToAdminPage();

            GenericPages.AdminPage.ClickNationalitiesButton();

            Assert.AreEqual("Nationalities", GenericPages.AdminPage.ReturnNationalitiesText());

            var nationality = Tables.GetCellText("Nationality");
            Tables.ClickPencilEditButton();

            Assert.AreEqual("Edit Nationality", GenericPages.AdminPage.ReturnEditNationalitiyText());

            GenericPages.AdminPage.ClearNationalityName();
            GenericPages.AdminPage.EnterNationalityName();
            Buttons.ClickSaveButton();

            Assert.AreEqual("111", Tables.GetCellText("Nationality"));

            Tables.ClickPencilEditButton();

            Assert.AreEqual("Edit Nationality", GenericPages.AdminPage.ReturnEditNationalitiyText());

            GenericPages.AdminPage.ClearNationalityName();
            GenericPages.AdminPage.EnterNationalityNameBack(nationality);
            Buttons.ClickSaveButton();

            Assert.AreEqual(nationality, Tables.GetCellText("Nationality"));
        }

        [Test]
        public void J_RecruitmentManagementFunctionalityTest()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToRecruitmentPage();

            GenericPages.RecruitmentPage.ClickVacanciesButton();

            Assert.AreEqual("Vacancies", GenericPages.RecruitmentPage.VacanciesTextResult());

            Buttons.ClickAddButton();
            GenericPages.RecruitmentPage.EnterVacancyName();
            GenericPages.RecruitmentPage.ClickJobTitleDropdownArrowButton();
            GenericPages.RecruitmentPage.ChooseJobTitle();
            GenericPages.RecruitmentPage.EnterHiringManager();
            GenericPages.RecruitmentPage.ClickHiringManagerListFirstPosition();
            Buttons.ClickSaveButton();
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToRecruitmentPage();
            GenericPages.RecruitmentPage.ClickVacanciesButton();

            Assert.AreEqual("Vacancies", GenericPages.RecruitmentPage.VacanciesTextResult());
            Assert.AreEqual("111", Tables.GetCellText("Vacancy"));
            Assert.AreEqual("IT Manager", Tables.GetCellText("Job Title"));
            Assert.AreEqual("Active", Tables.GetCellText("Status"));

            Tables.ClickTrashButton();
            Buttons.ClickConfirmDeletionButton();

            Assert.AreNotEqual("111", Tables.GetCellText("Vacancy"));
        }

        [Test]
        public void K_AssignLeaveTest()
        {
            GenericPages.BasePage.CreateEmployee();

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeavePage();

            GenericPages.LeavePage.ClickEntitlementsButton();
            GenericPages.LeavePage.ClickAddEntitlementsButton();

            Assert.AreEqual("Add Leave Entitlement", GenericPages.LeavePage.ReturnAddLeaveEntitlementText());

            GenericPages.LeavePage.EnterEmployeeName();
            GenericPages.LeavePage.ClickCreatedEmployeeFirstPosition();
            GenericPages.LeavePage.ClickLeaveTypeArrowButton();
            GenericPages.LeavePage.ChooseLeaveType();
            GenericPages.LeavePage.EnterEntitlement();
            Buttons.ClickSaveButton();
            GenericPages.LeavePage.ClickConfirmButton();

            GenericPages.LeavePage.ClickAssignLeaveButton();

            Assert.AreEqual("Assign Leave", GenericPages.LeavePage.ReturnAssignLeaveText());

            GenericPages.LeavePage.EnterEmployeeName();
            GenericPages.LeavePage.ClickCreatedEmployeeFirstPosition();
            GenericPages.LeavePage.ClickLeaveTypeArrowButton();
            GenericPages.LeavePage.ChooseLeaveType();
            //Implementation of wait while element appears - was discussed
            string ReturnLeaveBalanceTextResult() => GenericPages.LeavePage.LeaveBalanceTextElement.Text;

            Assert.AreEqual("10.00 Day(s)", ReturnLeaveBalanceTextResult());

            GenericPages.LeavePage.ClickFromDateCalendarButton();
            GenericPages.LeavePage.ClickFromDateCalendarValueButton();
            GenericPages.LeavePage.ClickToDateCalendarButton();
            GenericPages.LeavePage.ClickToDateCalendarValueButton();
            Buttons.ClickSaveButton();
            //Implementation of wait while element appears - was discussed
            string ReturnSuccessfullySavedMessageTextResult() => GenericPages.LeavePage.SuccessfullySavedMessageTextElement.Text;

            Assert.AreEqual("Successfully Saved", ReturnSuccessfullySavedMessageTextResult());

            GenericPages.LeavePage.ClickLeaveListButton();
            GenericPages.LeavePage.ClickShowLeaveWithStatusTypeArrowButton();
            GenericPages.LeavePage.ChooseShowLeaveWithStatusType();
            GenericPages.LeavePage.ClickNotRequiredLeaveTypeArrowButton();
            GenericPages.LeavePage.ChooseLeaveType();
            GenericPages.LeavePage.EnterEmployeeName();
            GenericPages.LeavePage.ClickCreatedEmployeeFirstPosition();
            Buttons.ClickSearchButton();

            Assert.AreEqual("111 222 333", Tables.GetCellText("Employee Name"));

            GenericPages.BasePage.DeleteCreatedEmployee();
        }

        [Test]
        public void L_AddJobTitleTest()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToAdminPage();

            GenericPages.AdminPage.ClickJobDropdownButton();
            GenericPages.AdminPage.ClickJobTitlesDropdownButton();

            Assert.AreEqual("Job Titles", GenericPages.AdminPage.ReturnJobTitlesText());

            Buttons.ClickAddButton();
            GenericPages.AdminPage.EnterJobTitleName();
            Buttons.ClickSaveButton();

            Assert.AreEqual("111", Tables.GetCellText("Job Titles"));

            Tables.ClickTrashButton();
            Buttons.ClickConfirmDeletionButton();

            Assert.AreNotEqual("111", Tables.GetCellText("Job Titles"));
        }

        [Test]
        public void M_SearchEmployeeTest()
        {
            GenericPages.BasePage.CreateEmployee();

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToPIMPage();

            GenericPages.PIMPage.EnterCreatedEmployeeNameTextBoxElement();
            GenericPages.PIMPage.ClickCreatedEmployeeFirstPosition();
            Buttons.ClickSearchButton();

            Assert.AreEqual("111 222", Tables.GetCellText("First (& Middle) Name"));

            GenericPages.PIMPage.ClearEmployeeNameTextBoxElement();
            GenericPages.PIMPage.EnterUnvalidEmployeeNameTextBoxElement();

            Assert.AreEqual("Employee Information", GenericPages.PIMPage.ReturnImployeeInformationText());

            Buttons.ClickSearchButton();

            Assert.AreEqual("No Records Found", GenericPages.PIMPage.ReturnNoRecordsFoundText());

            GenericPages.BasePage.DeleteCreatedEmployee();
        }

        [Test]
        public void N_EditEmployeeDetailsTest()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToPIMPage();

            GenericPages.PIMPage.ClickEmployeeListButton();
            Tables.ClickPencilEditButton();

            Assert.AreEqual("Personal Details", GenericPages.PIMPage.ReturnPersonalDetailsHeaderTextElement());

            GenericPages.PIMPage.ClearFullUserName();
            GenericPages.PIMPage.EnterFullUserName();
            GenericPages.PIMPage.ClickSaveOneButton();
            GenericPages.PIMPage.ClickSaveTwoButton();
            GenericPages.PIMPage.ClickEmployeeListButton();

            Assert.AreEqual("Employee Information", GenericPages.PIMPage.ReturnImployeeInformationText());

            GenericPages.PIMPage.EnterCreatedEmployeeNameTextBoxElement();
            GenericPages.PIMPage.ClickCreatedEmployeeFirstPosition();
            Buttons.ClickSearchButton();

            Assert.AreEqual("111 222", Tables.GetCellText("First (& Middle) Name"));
            Assert.AreEqual("333", Tables.GetCellText("Last Name"));

            GenericPages.BasePage.DeleteCreatedEmployee();
        }

        [Test]
        public void O_SearchAdminTest()
        {
            GenericPages.BasePage.CreateEmployee();

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToAdminPage();

            GenericPages.AdminPage.ClickUserManagementDropdownButton();
            GenericPages.AdminPage.ClickUsersDropdownButton();
            Buttons.ClickAddButton();
            GenericPages.BasePage.CreateUser();

            Assert.AreEqual("Successfully Saved", GenericPages.InfoMessage.ReturnInfoMessageTextResult());

            GenericPages.AdminPage.EnterUserNameTextBoxElement();
            Buttons.ClickSearchButton();
            GenericPages.AdminPage.ReturnEmployeeNameTableTextElement();

            Assert.AreEqual("111 333", GenericPages.AdminPage.ReturnEmployeeNameTableTextElement());

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToPIMPage();
            GenericPages.PIMPage.EnterCreatedEmployeeNameTextBoxElement();
            GenericPages.PIMPage.ClickCreatedEmployeeFirstPosition();
            Buttons.ClickSearchButton();
            GenericPages.PIMPage.ClickEmployeeLastName();

            Assert.AreEqual("Personal Details", GenericPages.PIMPage.ReturnPersonalDetailsHeaderTextElement());

            GenericPages.BasePage.DeleteCreatedEmployee();
        }

        [Test]
        public void P_ValidateCandidateManagementTest()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToRecruitmentPage();

            GenericPages.RecruitmentPage.ClickCandidatesButton();
            Buttons.ClickAddButton();

            GenericPages.RecruitmentPage.EnterFullCandidateName();
            GenericPages.RecruitmentPage.EnterEmail();
            Buttons.ClickSaveButton();
            GenericPages.RecruitmentPage.ClickCandidatesButton();
            GenericPages.RecruitmentPage.EnterCandidateName();

            GenericPages.RecruitmentPage.ClickCandidateNameFirstPosition();
            Buttons.ClickSearchButton();

            Assert.AreEqual("111 222 333", Tables.GetCellText("Candidate"));

            Tables.CheckTableCheckBoxElement();
            Buttons.ClickDeleteSelectedButton();
            Buttons.ClickConfirmDeletionButton();

            Assert.AreEqual("No Records Found", GenericPages.PIMPage.ReturnNoRecordsFoundText());
        }

        [Test]
        public void R_ResetPasswordTest()
        {
            GenericPages.BasePage.CreateEmployee();

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToAdminPage();

            GenericPages.AdminPage.ClickUserManagementDropdownButton();
            GenericPages.AdminPage.ClickUsersDropdownButton();
            Buttons.ClickAddButton();
            GenericPages.BasePage.CreateUser();

            Assert.AreEqual("Successfully Saved", GenericPages.InfoMessage.ReturnInfoMessageTextResult());

            GenericPages.DashboardPage.ClickArrowButton();
            GenericPages.LoginPage.ClickLogout();
            GenericPages.LoginPage.ClickForgotPassword();
            GenericPages.LoginPage.EnterUserNameTextBoxElement();
            GenericPages.LoginPage.ClickResetPasswordButton();

            Assert.AreEqual("Reset Password link sent successfully", GenericPages.LoginPage.ReturnResetPasswordMessageTextResult());

            GenericPages.BasePage.GoToLoginPage();
            GenericPages.LoginPage.LogInToOrangeCRM();
            GenericPages.BasePage.DeleteCreatedEmployee();
        }

        [Test]
        public void S_ValidateJobTitlesTest()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToAdminPage();

            GenericPages.AdminPage.ClickJobDropdownButton();
            GenericPages.AdminPage.ClickJobTitlesDropdownButton();

            Assert.AreEqual("Job Titles", GenericPages.AdminPage.ReturnJobTitlesText());

            Buttons.ClickAddButton();
            GenericPages.AdminPage.EnterJobTitleName();
            Buttons.ClickSaveButton();

            Assert.AreEqual("111", GenericPages.AdminPage.ReturnJobTitleNameTextResult());

            Tables.CheckTableCheckBoxElement();
            Buttons.ClickDeleteSelectedButton();
            Buttons.ClickConfirmDeletionButton();

            Assert.AreNotEqual("111", GenericPages.AdminPage.ReturnJobTitleNameTextResult());
        }

        [Test]
        public void T_AddCustomFieldToEmployeeProfileTest()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToPIMPage();

            GenericPages.PIMPage.ClickConfugurationButton();
            GenericPages.PIMPage.ClickCustomFieldsButton();

            Assert.AreEqual("Custom Fields", GenericPages.PIMPage.ReturnCustomFieldsText());

            Buttons.ClickAddButton();
            GenericPages.PIMPage.EnterFieldNameTextBoxElement();
            GenericPages.PIMPage.ChoseScreen();
            GenericPages.PIMPage.ChoseType();
            Buttons.ClickSaveButton();
            GenericPages.PIMPage.ClickEmployeeListButton();

            Assert.AreEqual("Employee Information", GenericPages.PIMPage.ReturnImployeeInformationText());

            Tables.ClickPencilEditButton();

            Assert.AreEqual("111", GenericPages.PIMPage.ReturnAddedCustomFieldNameTextElement());

            GenericPages.PIMPage.EnterCreatedCustomFieldValueTextBoxElement();
            GenericPages.PIMPage.ClickSaveTwoButton();

            Assert.AreEqual("111", GenericPages.PIMPage.ReturnAddedCustomFieldNameTextElement());

            GenericPages.PIMPage.ClearCreatedCustomFieldTextBoxElement();
            GenericPages.PIMPage.ClickSaveTwoButton();

            Assert.AreEqual("111", GenericPages.PIMPage.ReturnAddedCustomFieldNameTextElement());

            GenericPages.PIMPage.ClickConfugurationButton();
            GenericPages.PIMPage.ClickCustomFieldsButton();
            Tables.ClickTrashButton();
            Buttons.ClickConfirmDeletionButton();
        }

        [Test]
        public void U_ValidateAssignSkillToEmployeeProfileTest()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToPIMPage();

            GenericPages.PIMPage.ClickEmployeeListButton();

            Assert.AreEqual("Employee Information", GenericPages.PIMPage.ReturnImployeeInformationText());

            Tables.ClickPencilEditButton();
            GenericPages.PIMPage.ClickQualificationsButton();
            GenericPages.PIMPage.ClickAddSkillsButton();
            Buttons.ClickRequieredDropDownListArrowButtonByName("Skill");
            DropdownExtension.ClickDropdownList("C#");
            Buttons.ClickSaveButton();

            Assert.AreEqual("C#", Tables.ReturnValueOfTextFieldByName("Skill"));

            GenericPages.PIMPage.ClickSkillsTableTrashButton();
            Buttons.ClickConfirmDeletionButton();

            GenericPages.DashboardPage.ClickArrowButton();
            GenericPages.LoginPage.ClickLogout();
        }

        [Test]
        public void W_ValidLoginTest()
        {
            GenericPages.LoginPage.EnterValidUsername();
            GenericPages.LoginPage.EnterValidPassword();
            GenericPages.LoginPage.ClickLoginButton();

            Assert.AreEqual(DashboardPageConstants.DashboardPageUrl, GenericPages.LoginPage.GetCurrentPageUrl());

            GenericPages.DashboardPage.ClickArrowButton();
            GenericPages.LoginPage.ClickLogout();
        }

        [Test]
        public void X_InValidLoginTest()
        {
            GenericPages.LoginPage.EnterInvalidUsername();
            GenericPages.LoginPage.EnterInvalidPassword();
            GenericPages.LoginPage.ClickLoginButton();

            Assert.AreEqual("Invalid credentials", GenericPages.LoginPage.ReturnInvalidMessageTextResult());
        }
    }
}