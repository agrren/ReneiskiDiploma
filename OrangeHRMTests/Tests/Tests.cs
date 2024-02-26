using NUnit.Framework;
using NUnit.Framework.Legacy;
using OrangeHRMTests.Common.Extensions.ExtensionMethods;
using OrangeHRMTests.PageObjects;
using OrangeHRMTests.PageObjects.Modules;

namespace OrangeHRMTests.Tests
{
    public class DemoQATests : BaseTest
    {
        [Test]
        public void A_AboutModalTest()
        {
            TopbarMenu.ClickArrowButton();
            GenericPages.AboutPage.ClickAboutButton();

            Assert.That("About",Is.EqualTo(GenericPages.AboutPage.ReturnAboutNameTextResult()));
            Assert.That("OrangeHRM OS 5.6", Is.EqualTo(GenericPages.AboutPage.ReturnAboutVersionTextResult()));

            GenericPages.AboutPage.ClickCloseAboutButton();
        }

        [Test]
        public void B_SupportPageTest()
        {
            TopbarMenu.ClickArrowButton();
            GenericPages.SupportPage.ClickSupport();

            ClassicAssert.AreEqual("Getting Started with OrangeHRM", GenericPages.SupportPage.ReturnSupportTitleTextResult());
        }

        [Test]
        public void C_DashboardPageTest()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToDashboardPage();

            ClassicAssert.AreEqual("Time at Work", GenericPages.DashboardPage.GetTimeAtWorkTextResult());
            ClassicAssert.AreEqual("My Actions", GenericPages.DashboardPage.GetMyActionTextResult());
            ClassicAssert.AreEqual("Quick Launch", GenericPages.DashboardPage.GetQuckLaunchTextResult());
            ClassicAssert.AreEqual("Buzz Latest Posts", GenericPages.DashboardPage.GetBuzzLatestPostTextResult());
            ClassicAssert.AreEqual("Employees on Leave Today", GenericPages.DashboardPage.GetOnLeaveTextResult());
            ClassicAssert.AreEqual("Employee Distribution by Sub Unit", GenericPages.DashboardPage.GetBySubUnitTextResult());
            ClassicAssert.AreEqual("Employee Distribution by Location", GenericPages.DashboardPage.GetByLocationTextResult());

            GenericPages.DashboardPage.ClickWheelButton();

            ClassicAssert.AreEqual("Configurations", GenericPages.DashboardPage.GetConfigTextResult());

            GenericPages.DashboardPage.ClickCrossButton();
            GenericPages.DashboardPage.ClickWheelButton();

            ClassicAssert.AreEqual("Configurations", GenericPages.DashboardPage.GetConfigTextResult());

            GenericPages.DashboardPage.ClickCancelButton();
        }

        [Test]
        public void D_AdminPageTest()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToAdminPage();

            var username = BasePage.GetCellText("Username");
            var userRole = BasePage.GetCellText("User Role");
            var employeename = BasePage.GetCellText("Employee Name");
            var userStatus = BasePage.GetCellText("Status");

            ClassicAssert.AreEqual("Admin / User Management", TopbarMenu.GetAdminPageHeaderTextResult());
            ClassicAssert.AreEqual("System Users", GenericPages.AdminPage.GetSystemUserTableHeaderTextResult());

            GenericPages.AdminUserManagementPage.EnterUserName();
            GenericPages.AdminUserManagementPage.ClickUserRoleDropdownArrow();
            GenericPages.AdminUserManagementPage.ChooseUserRole();
            GenericPages.AdminUserManagementPage.EnterEmployeeName();
            GenericPages.AdminUserManagementPage.ClickUserStatusDropdownArrow();
            GenericPages.AdminUserManagementPage.ChooseUserStatus();
            BasePage.ClickSearchButton();

            ClassicAssert.AreEqual(username, BasePage.GetCellText("Username"));
            ClassicAssert.AreEqual(userRole, BasePage.GetCellText("User Role"));
            ClassicAssert.AreEqual(employeename, BasePage.GetCellText("Employee Name"));
            ClassicAssert.AreEqual(userStatus, BasePage.GetCellText("Status"));
        }

        [Test]
        public void E_PIMPageAddEmployeeTest()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToPIMPage();

            BasePage.ClickAddButton();
            GenericPages.PIMPage.EnterFullUserName();
            BasePage.ClickSaveButton();
            ClassicAssert.AreEqual("Successfully Saved", GenericPages.InfoMessage.ReturnInfoMessageTextResult());
            BasePage.ClickSaveButton();
            GenericPages.PIMPage.ClickEmployeeListButton();

            ClassicAssert.AreEqual("111 222", GenericPages.PIMPage.GetFirstAndMiddleNameTextResult());
            ClassicAssert.AreEqual("333", GenericPages.PIMPage.GetLastNameTextResult());

            GenericPages.BaseTest.DeleteCreatedEmployee();
        }

        [Test]
        public void F_SearchFunctionalityTest()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.EnterValueToSearchInputField("PIM");
            GenericPages.BasePage.LeftMenuNavigationPanel.PressEnter();

            ClassicAssert.AreEqual("PIM", GenericPages.BasePage.LeftMenuNavigationPanel.ReturnSearchResultText());

            GenericPages.BasePage.LeftMenuNavigationPanel.ClearSearchInputField();
        }

        [Test]
        public void G_PerformanceManagementTest()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToPerformancePage();

            GenericPages.PerformancePage.ClickConfigureButton();
            GenericPages.PerformancePage.ClickKPIsButton();
            BasePage.ClickAddButton();
            GenericPages.PerformancePage.EnterKeyPerformanceIndicator();
            GenericPages.PerformancePage.ClickJobTitleDropdownArrowButton();
            GenericPages.PerformancePage.ChooseJobTitle();
            GenericPages.PerformancePage.EnterKeyMinimumRating();
            BasePage.ClickSaveButton();

            ClassicAssert.AreEqual("111", BasePage.GetCellText("Key Performance Indicator"));
            ClassicAssert.AreEqual("IT Manager", BasePage.GetCellText("Job Title"));
            ClassicAssert.AreEqual("1", BasePage.GetCellText("Min Rate"));

            BasePage.ClickTrashButton();
            BasePage.ClickConfirmDeletionButton();

            ClassicAssert.AreNotEqual("111", BasePage.GetCellText("Key Performance Indicator"));
            ClassicAssert.AreNotEqual("IT Manager", BasePage.GetCellText("Job Title"));
            ClassicAssert.AreNotEqual("1", BasePage.GetCellText("Min Rate"));
        }

        [Test]
        public void H_AdminFunctionalityTest()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToAdminPage();

            GenericPages.AdminPage.ClickUserManagementDropdownButton();

            ClassicAssert.AreEqual("Users", GenericPages.AdminPage.GetUsersDropdownElementText());

            GenericPages.AdminPage.ClickJobDropdownButton();

            ClassicAssert.AreEqual("Job Titles", GenericPages.AdminPage.GetJobTitleDropdownElementText());
        }

        [Test]
        public void I_EditNationalityTest()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToAdminPage();

            GenericPages.AdminPage.ClickNationalitiesButton();

            ClassicAssert.AreEqual("Nationalities", GenericPages.AdminPage.GetNationalitiesText());

            var nationality = BasePage.GetCellText("Nationality");
            BasePage.ClickPencilEditButton();

            ClassicAssert.AreEqual("Edit Nationality", GenericPages.AdminPage.GetEditNationalitiyText());

            GenericPages.AdminPage.ClearNationalityName();
            GenericPages.AdminPage.EnterNationalityName();
            BasePage.ClickSaveButton();

            ClassicAssert.AreEqual("111", BasePage.GetCellText("Nationality"));

            BasePage.ClickPencilEditButton();

            ClassicAssert.AreEqual("Edit Nationality", GenericPages.AdminPage.GetEditNationalitiyText());

            GenericPages.AdminPage.ClearNationalityName();
            GenericPages.AdminPage.EnterNationalityNameBack(nationality);
            BasePage.ClickSaveButton();

            ClassicAssert.AreEqual(nationality, BasePage.GetCellText("Nationality"));
        }

        [Test]
        public void J_RecruitmentManagementFunctionalityTest()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToRecruitmentPage();

            GenericPages.RecruitmentPage.ClickVacanciesButton();

            ClassicAssert.AreEqual("Vacancies", GenericPages.RecruitmentPage.GetVacanciesTextResult());

            BasePage.ClickAddButton();
            GenericPages.RecruitmentPage.EnterVacancyName();
            GenericPages.RecruitmentPage.ClickJobTitleDropdownArrowButton();
            GenericPages.RecruitmentPage.ChooseJobTitle();
            GenericPages.RecruitmentPage.EnterHiringManager();
            GenericPages.PIMPage.ClickDropdownListFirstPosition();
            BasePage.ClickSaveButton();

            ClassicAssert.AreEqual("Edit Vacancy", GenericPages.RecruitmentPage.GetEditVacanciesTextResult());

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToRecruitmentPage();
            GenericPages.RecruitmentPage.ClickVacanciesButton();

            ClassicAssert.AreEqual("Vacancies", GenericPages.RecruitmentPage.GetVacanciesTextResult());
            ClassicAssert.AreEqual("111", BasePage.GetCellText("Vacancy"));
            ClassicAssert.AreEqual("IT Manager", BasePage.GetCellText("Job Title"));
            ClassicAssert.AreEqual("Active", BasePage.GetCellText("Status"));

            BasePage.ClickTrashButton();
            BasePage.ClickConfirmDeletionButton();

            ClassicAssert.AreNotEqual("111", BasePage.GetCellText("Vacancy"));
        }

        [Test]
        public void K_AssignLeaveTest()
        {
            GenericPages.BaseTest.CreateEmployee();

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeavePage();

            GenericPages.LeavePage.ClickEntitlementsButton();
            GenericPages.LeavePage.ClickAddEntitlementsButton();

            ClassicAssert.AreEqual("Add Leave Entitlement", GenericPages.LeavePage.GetAddLeaveEntitlementText());

            GenericPages.LeavePage.EnterEmployeeName();
            GenericPages.PIMPage.ClickDropdownListFirstPosition();
            GenericPages.LeavePage.ClickLeaveTypeArrowButton();
            GenericPages.LeavePage.ChooseLeaveType();
            GenericPages.LeavePage.EnterEntitlement();
            BasePage.ClickSaveButton();
            GenericPages.LeavePage.ClickConfirmButton();

            GenericPages.LeavePage.ClickAssignLeaveButton();

            ClassicAssert.AreEqual("Assign Leave", GenericPages.LeavePage.GetAssignLeaveText());

            GenericPages.LeavePage.EnterEmployeeName();
            GenericPages.PIMPage.ClickDropdownListFirstPosition();
            GenericPages.LeavePage.ClickLeaveTypeArrowButton();
            GenericPages.LeavePage.ChooseLeaveType();

            GenericPages.LeavePage.ClickFromDateCalendarButton();
            GenericPages.LeavePage.ClickFromDateCalendarValueButton();
            GenericPages.LeavePage.ClickToDateCalendarButton();
            GenericPages.LeavePage.ClickToDateCalendarValueButton();
            BasePage.ClickSaveButton();
            //Implementation of wait while element appears - was discussed
            string GetSuccessfullySavedMessageTextResult() => BasePage.PopUpMessageTextElement.Text;

            ClassicAssert.AreEqual("Successfully Saved", GetSuccessfullySavedMessageTextResult());

            GenericPages.LeavePage.ClickLeaveListButton();
            GenericPages.LeavePage.ClickShowLeaveWithStatusTypeArrowButton();
            GenericPages.LeavePage.ChooseShowLeaveWithStatusType();
            GenericPages.LeavePage.ClickNotRequiredLeaveTypeArrowButton();
            GenericPages.LeavePage.ChooseLeaveType();
            GenericPages.LeavePage.EnterEmployeeName();
            GenericPages.PIMPage.ClickDropdownListFirstPosition();
            BasePage.ClickSearchButton();

            ClassicAssert.AreEqual("111 222 333", BasePage.GetCellText("Employee Name"));

            GenericPages.BaseTest.DeleteCreatedEmployee();
        }

        [Test]
        public void L_AddJobTitleTest()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToAdminPage();

            GenericPages.AdminPage.ClickJobDropdownButton();
            GenericPages.AdminPage.ClickJobTitlesDropdownButton();

            ClassicAssert.AreEqual("Job Titles", GenericPages.AdminPage.GetJobTitlesText());

            BasePage.ClickAddButton();
            GenericPages.AdminPage.EnterJobTitleName();
            BasePage.ClickSaveButton();

            ClassicAssert.AreEqual("111", BasePage.GetCellText("Job Titles"));

            BasePage.ClickTrashButton();
            BasePage.ClickConfirmDeletionButton();

            ClassicAssert.AreNotEqual("111", BasePage.GetCellText("Job Titles"));
        }

        [Test]
        public void M_SearchEmployeeTest()
        {
            GenericPages.BaseTest.CreateEmployee();

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToPIMPage();

            GenericPages.PIMPage.EnterCreatedEmployeeNameTextBoxElement();
            GenericPages.PIMPage.ClickDropdownListFirstPosition();
            BasePage.ClickSearchButton();

            ClassicAssert.AreEqual("111 222", BasePage.GetCellText("First (& Middle) Name"));

            GenericPages.PIMPage.ClearEmployeeNameTextBoxElement();
            GenericPages.PIMPage.EnterUnvalidEmployeeNameTextBoxElement();

            ClassicAssert.AreEqual("Employee Information", GenericPages.PIMPage.GetImployeeInformationText());

            BasePage.ClickSearchButton();

            ClassicAssert.AreEqual("No Records Found", GenericPages.PIMPage.GetNoRecordsFoundText());

            GenericPages.BaseTest.DeleteCreatedEmployee();
        }

        [Test]
        public void N_EditEmployeeDetailsTest()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToPIMPage();

            GenericPages.PIMPage.ClickEmployeeListButton();
            BasePage.ClickPencilEditButton();

            ClassicAssert.AreEqual("Personal Details", GenericPages.PIMPage.GetPersonalDetailsHeaderTextElement());

            GenericPages.PIMPage.ClearFullUserName();
            GenericPages.PIMPage.EnterFullUserName();
            BasePage.ClickSaveButton();
            GenericPages.PIMPage.ClickEmployeeListButton();

            ClassicAssert.AreEqual("Employee Information", GenericPages.PIMPage.GetImployeeInformationText());

            GenericPages.PIMPage.EnterCreatedEmployeeNameTextBoxElement();
            GenericPages.PIMPage.ClickDropdownListFirstPosition();
            BasePage.ClickSearchButton();

            ClassicAssert.AreEqual("111 222", BasePage.GetCellText("First (& Middle) Name"));
            ClassicAssert.AreEqual("333", BasePage.GetCellText("Last Name"));

            GenericPages.BaseTest.DeleteCreatedEmployee();
        }

        [Test]
        public void O_SearchAdminTest()
        {
            GenericPages.BaseTest.CreateEmployee();

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToAdminPage();

            GenericPages.AdminPage.ClickUserManagementDropdownButton();
            GenericPages.AdminPage.ClickUsersDropdownButton();
            BasePage.ClickAddButton();
            GenericPages.BaseTest.CreateUser();

            ClassicAssert.AreEqual("Successfully Saved", GenericPages.InfoMessage.ReturnInfoMessageTextResult());

            GenericPages.AdminPage.EnterUserNameTextBoxElement();
            BasePage.ClickSearchButton();
            GenericPages.AdminPage.GetEmployeeNameTableTextElement();

            ClassicAssert.AreEqual("111 333", GenericPages.AdminPage.GetEmployeeNameTableTextElement());

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToPIMPage();
            GenericPages.PIMPage.EnterCreatedEmployeeNameTextBoxElement();
            GenericPages.PIMPage.ClickDropdownListFirstPosition();
            BasePage.ClickSearchButton();
            GenericPages.PIMPage.ClickEmployeeLastName();

            ClassicAssert.AreEqual("Personal Details", GenericPages.PIMPage.GetPersonalDetailsHeaderTextElement());

            GenericPages.BaseTest.DeleteCreatedEmployee();
        }

        [Test]
        public void P_ValidateCandidateManagementTest()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToRecruitmentPage();

            GenericPages.RecruitmentPage.ClickCandidatesButton();
            BasePage.ClickAddButton();

            GenericPages.RecruitmentPage.EnterFullCandidateName();
            GenericPages.RecruitmentPage.EnterEmail();
            BasePage.ClickSaveButton();
            GenericPages.RecruitmentPage.ClickCandidatesButton();
            GenericPages.RecruitmentPage.EnterCandidateName();

            GenericPages.PIMPage.ClickDropdownListFirstPosition();
            BasePage.ClickSearchButton();

            ClassicAssert.AreEqual("111 222 333", BasePage.GetCellText("Candidate"));

            BasePage.CheckTableCheckBoxElement();
            BasePage.ClickDeleteSelectedButton();
            BasePage.ClickConfirmDeletionButton();

            ClassicAssert.AreEqual("Successfully Deleted", GenericPages.PIMPage.GetNoRecordsFoundText());
        }

        [Test]
        public void R_ResetPasswordTest()
        {
            GenericPages.BaseTest.CreateEmployee();

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToAdminPage();

            GenericPages.AdminPage.ClickUserManagementDropdownButton();
            GenericPages.AdminPage.ClickUsersDropdownButton();
            BasePage.ClickAddButton();
            GenericPages.BaseTest.CreateUser();

            ClassicAssert.AreEqual("Successfully Saved", GenericPages.InfoMessage.ReturnInfoMessageTextResult());

            TopbarMenu.ClickArrowButton();
            TopbarMenu.ClickLogout();
            GenericPages.LoginPage.ClickForgotPassword();
            GenericPages.LoginPage.EnterUserNameTextBoxElement();
            GenericPages.LoginPage.ClickResetPasswordButton();

            ClassicAssert.AreEqual("Reset Password link sent successfully", GenericPages.LoginPage.ReturnResetPasswordMessageTextResult());

            GenericPages.BaseTest.GoToLoginPage();
            GenericPages.LoginPage.LogInToOrangeCRM();
            GenericPages.BaseTest.DeleteCreatedEmployee();
        }

        [Test]
        public void S_ValidateJobTitlesTest()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToAdminPage();

            GenericPages.AdminPage.ClickJobDropdownButton();
            GenericPages.AdminPage.ClickJobTitlesDropdownButton();

            ClassicAssert.AreEqual("Job Titles", GenericPages.AdminPage.GetJobTitlesText());

            BasePage.ClickAddButton();
            GenericPages.AdminPage.EnterJobTitleName();
            BasePage.ClickSaveButton();

            ClassicAssert.AreEqual("111", GenericPages.AdminPage.GetJobTitleNameTextResult());

            BasePage.CheckTableCheckBoxElement();
            BasePage.ClickDeleteSelectedButton();
            BasePage.ClickConfirmDeletionButton();

            ClassicAssert.AreNotEqual("111", GenericPages.AdminPage.GetJobTitleNameTextResult());
        }

        [Test]
        public void T_AddCustomFieldToEmployeeProfileTest()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToPIMPage();

            GenericPages.PIMPage.ClickConfugurationButton();
            GenericPages.PIMPage.ClickCustomFieldsButton();

            ClassicAssert.AreEqual("Custom Fields", GenericPages.PIMPage.GetCustomFieldsText());

            BasePage.ClickAddButton();
            GenericPages.PIMPage.EnterFieldNameTextBoxElement();
            GenericPages.PIMPage.ChoseScreen();
            GenericPages.PIMPage.ChoseType();
            BasePage.ClickSaveButton();
            GenericPages.PIMPage.ClickEmployeeListButton();

            ClassicAssert.AreEqual("Employee Information", GenericPages.PIMPage.GetImployeeInformationText());

            BasePage.ClickPencilEditButton();

            ClassicAssert.AreEqual("111", GenericPages.PIMPage.GetAddedCustomFieldNameTextElement());

            GenericPages.PIMPage.EnterCreatedCustomFieldValueTextBoxElement();
            GenericPages.PIMPage.ClickSaveCustomFieldButton();

            ClassicAssert.AreEqual("111", GenericPages.PIMPage.GetAddedCustomFieldNameTextElement());

            GenericPages.PIMPage.ClearCreatedCustomFieldTextBoxElement();
            GenericPages.PIMPage.ClickSaveCustomFieldButton();

            ClassicAssert.AreEqual("111", GenericPages.PIMPage.GetAddedCustomFieldNameTextElement());

            GenericPages.PIMPage.ClickConfugurationButton();
            GenericPages.PIMPage.ClickCustomFieldsButton();
            BasePage.ClickTrashButton();
            BasePage.ClickConfirmDeletionButton();
        }

        [Test]
        public void U_ValidateAssignSkillToEmployeeProfileTest()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToPIMPage();

            GenericPages.PIMPage.ClickEmployeeListButton();

            ClassicAssert.AreEqual("Employee Information", GenericPages.PIMPage.GetImployeeInformationText());

            BasePage.ClickPencilEditButton();
            GenericPages.PIMPage.ClickQualificationsButton();
            GenericPages.PIMPage.ClickAddSkillsButton();
            BasePage.ClickDropDownListArrowButtonByName("Skill");
            DropdownExtension.ClickDropdownList("SQL");
            BasePage.ClickSaveButton();

            ClassicAssert.AreEqual("SQL", BasePage.ReturnValueOfTextFieldByName("Skill"));

            GenericPages.PIMPage.ClickSkillsTableTrashButton();
            BasePage.ClickConfirmDeletionButton();

            TopbarMenu.ClickArrowButton();
            TopbarMenu.ClickLogout();
        }

        [Test]
        public void W_ValidLoginTest()
        {
            //TopbarMenu.ClickArrowButton();
            //TopbarMenu.ClickLogout();
            GenericPages.LoginPage.EnterValidUsername();
            GenericPages.LoginPage.EnterValidPassword();
            GenericPages.LoginPage.ClickLoginButton();

            ClassicAssert.AreEqual(Data.TestSettings.DashboardPageUrl, GenericPages.LoginPage.GetCurrentPageUrl());

            TopbarMenu.ClickArrowButton();
            TopbarMenu.ClickLogout();
        }

        [Test]
        public void X_InValidLoginTest()
        {
            //TopbarMenu.ClickArrowButton();
            //TopbarMenu.ClickLogout();
            GenericPages.LoginPage.EnterInvalidUsername();
            GenericPages.LoginPage.EnterInvalidPassword();
            GenericPages.LoginPage.ClickLoginButton();

            ClassicAssert.AreEqual("Invalid credentials", GenericPages.LoginPage.ReturnInvalidMessageTextResult());
        }
    }
}