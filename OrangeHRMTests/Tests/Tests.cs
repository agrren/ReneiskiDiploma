using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OrangeHRMTests.Common.WebElements;
using OrangeHRMTests.Data;
using OrangeHRMTests.Data.Constants;
using OrangeHRMTests.PageObjects;
using OrangeHRMTests.PageObjects.Modules;

namespace OrangeHRMTests.Tests
{
    [TestFixture]
    [AllureNUnit]
    public class DemoQATests : BaseTest
    {
        [Test]
        public void A_AboutModalTest()
        {
            GenericPages.BasePage.TopBarMenu.ClickArrowButton();
            GenericPages.BasePage.TopBarMenu.ClickUserDropdownItemByName(TopBarUserDropDownButtons.AboutButton);

            ClassicAssert.AreEqual("Abou", GenericPages.AboutPage.GetAboutNameTextResult());
            ClassicAssert.AreEqual(AboutPageTextValues.OrangeHRMOSVersionText, GenericPages.AboutPage.GetAboutVersionTextResult());

            GenericPages.AboutPage.ClickCloseAboutButton();
        }

        [Test]
        public void B_SupportPageTest()
        {
            GenericPages.BasePage.TopBarMenu.ClickArrowButton();
            GenericPages.BasePage.TopBarMenu.ClickUserDropdownItemByName(TopBarUserDropDownButtons.SupportButton);

            ClassicAssert.AreEqual("Getting Started with OrangeHRM", GenericPages.SupportPage.ReturnSupportTitleTextResult());
        }

        [Test]
        public void C_DashboardPageTest()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.DashboardButtonName);

            ClassicAssert.AreEqual("Time at Work", GenericPages.DashboardPage.GetTextResultByName(DashboardPageSectionHeadersNames.TimeAtWorkHeaderName));
            ClassicAssert.AreEqual("My Actions", GenericPages.DashboardPage.GetTextResultByName(DashboardPageSectionHeadersNames.MyActionsHeaderName));
            ClassicAssert.AreEqual("Quick Launch", GenericPages.DashboardPage.GetTextResultByName(DashboardPageSectionHeadersNames.QuickLaunchHeaderName));
            ClassicAssert.AreEqual("Buzz Latest Posts", GenericPages.DashboardPage.GetTextResultByName(DashboardPageSectionHeadersNames.BuzzLatestPostsHeaderName));
            ClassicAssert.AreEqual("Employees on Leave Today", GenericPages.DashboardPage.GetTextResultByName(DashboardPageSectionHeadersNames.EmployeesOnLeaveTodayHeaderName));
            ClassicAssert.AreEqual("Employee Distribution by Sub Unit", GenericPages.DashboardPage.GetTextResultByName(DashboardPageSectionHeadersNames.EmployeeDistributionBySubUnitHeaderName));
            ClassicAssert.AreEqual("Employee Distribution by Location", GenericPages.DashboardPage.GetTextResultByName(DashboardPageSectionHeadersNames.EmployeeDistributionByLocationHeaderName));

            GenericPages.DashboardPage.ClickWheelButton();

            ClassicAssert.AreEqual(DashboardPageSectionHeadersNames.ConfigurationsHeaderTextValue, GenericPages.DashboardPage.GetConfigTextResult());

            GenericPages.DashboardPage.ClickCrossButton();
            GenericPages.DashboardPage.ClickWheelButton();

            ClassicAssert.AreEqual(DashboardPageSectionHeadersNames.ConfigurationsHeaderTextValue, GenericPages.DashboardPage.GetConfigTextResult());

            GenericPages.DashboardPage.ClickCancelButton();
        }

        [Test]
        public void D_AdminPageTest()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.AdminButtonName);

            var username = Table.GetCellText(TableColumnsNames.UserNameTableColumnName);
            var userRole = Table.GetCellText(TableColumnsNames.UserRoleTableColumnName);
            var employeename = Table.GetCellText(TableColumnsNames.EmployeeNameTableColumnName);
            var userStatus = Table.GetCellText(TableColumnsNames.StatusTableColumnName);

            ClassicAssert.AreEqual(AdminPageHeadersTextValues.AdminUserManagementHeaderTextValue, GenericPages.BasePage.TopBarMenu.GetAdminPageHeaderTextResult());
            ClassicAssert.AreEqual(AdminPageHeadersTextValues.SystemUsersHeaderTextValue, GenericPages.AdminPage.GetSystemUserTableHeaderTextResult());

            GenericPages.AdminPage.EnterValueInInputTextField(InputFieldsNames.UserNameInputFieldName, Table.GetCellText(TableColumnsNames.UserNameTableColumnName));
            GenericPages.AdminPage.ClickDropDownListArrowButtonByName(DropDownFieldsNames.UserRoleDropDownFieldName);
            MyWebElement.SelectValueFromOrangeDropdownList(Table.GetCellText(TableColumnsNames.UserRoleTableColumnName));
            GenericPages.AdminPage.EnterValueInInputTextField(InputFieldsNames.EmployeeNameInputFieldName, Table.GetCellText(TableColumnsNames.EmployeeNameTableColumnName));
            GenericPages.AdminPage.ClickDropDownListArrowButtonByName(DropDownFieldsNames.StatusDropDownFieldName);
            MyWebElement.SelectValueFromOrangeDropdownList(Table.GetCellText(TableColumnsNames.StatusTableColumnName));
            GenericPages.AdminPage.ClickSearchButton();

            ClassicAssert.AreEqual(username, Table.GetCellText(TableColumnsNames.UserNameTableColumnName));
            ClassicAssert.AreEqual(userRole, Table.GetCellText(TableColumnsNames.UserRoleTableColumnName));
            ClassicAssert.AreEqual(employeename, Table.GetCellText(TableColumnsNames.EmployeeNameTableColumnName));
            ClassicAssert.AreEqual(userStatus, Table.GetCellText(TableColumnsNames.StatusTableColumnName));
        }

        [Test]
        public void E_PIMPageAddEmployeeTest()
        {
            const string NewLastName = "333";

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.PIMButtonName);

            GenericPages.PIMPage.ClickAddButton();
            GenericPages.PIMPage.EnterFullUserName();
            GenericPages.BasePage.ClickSaveButton();
            ClassicAssert.AreEqual(InfoMessageTextValues.SuccessfullySavedMessageText, GenericPages.InfoMessage.GetInfoMessageTextResult());
            GenericPages.PIMPage.ClickSaveButton();
            GenericPages.BasePage.TopBarMenu.ClickTopbarMenuButtonByName(PIMPageTopBarMenuButtonsNames.EmployeeListTopBarMenuButtonName);

            ClassicAssert.AreEqual("111 222", Table.GetCellText(TableColumnsNames.FirstMiddleNameTableColumnName));
            ClassicAssert.AreEqual(NewLastName, Table.GetCellText(TableColumnsNames.LastNameTableColumnName));

            GenericPages.BaseTest.DeleteCreatedEmployee();
        }

        [Test]
        public void F_SearchFunctionalityTest()
        {
            const string ValueForSearch = "PIM";

            GenericPages.BasePage.LeftMenuNavigationPanel.EnterValueToSearchInputField(ValueForSearch);
            GenericPages.BasePage.LeftMenuNavigationPanel.PressEnter();

            ClassicAssert.AreEqual(ValueForSearch, GenericPages.BasePage.LeftMenuNavigationPanel.ReturnSearchResultText());

            GenericPages.BasePage.LeftMenuNavigationPanel.ClearSearchInputField();
        }

        [Test]
        public void G_PerformanceManagementTest()
        {
            const string NewKPI = "111";
            const string NewMinimumRating = "1";
            const string NewJobTitle = "IT Manager";

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.PerformanceButtonName);

            GenericPages.BasePage.TopBarMenu.ClickTopbarMenuButtonByName(PerformancePageTopBarMenuButtonsNames.ConfigureTopBarMenuButtonName);
            GenericPages.BasePage.TopBarMenu.ClickTopbarMenuButtonByName(PerformancePageTopBarMenuButtonsNames.KPIsTopBarMenuButtonName);
            GenericPages.PerformancePage.ClickAddButton();
            GenericPages.PerformancePage.EnterValueInInputTextField(InputFieldsNames.KeyPerformanceIndicatorInputFieldName, NewKPI);
            GenericPages.PerformancePage.ClickDropDownListArrowButtonByName(DropDownFieldsNames.JobTitleDropDownFieldName);
            MyWebElement.SelectValueFromOrangeDropdownList(NewJobTitle);
            GenericPages.PerformancePage.EnterValueInInputTextField(InputFieldsNames.MinimumRatingInputFieldName, NewMinimumRating);
            GenericPages.PerformancePage.ClickSaveButton();

            ClassicAssert.AreEqual(NewKPI, Table.GetCellText(TableColumnsNames.KeyPerformanceIndicatorTableColumnName));
            ClassicAssert.AreEqual(NewJobTitle, Table.GetCellText(TableColumnsNames.JobTitleTableColumnName));
            ClassicAssert.AreEqual(NewMinimumRating, Table.GetCellText(TableColumnsNames.MinRateTableColumnName));

            Table.ClickTrashButton();
            GenericPages.PerformancePage.ClickConfirmDeletionButton();

            ClassicAssert.AreNotEqual(NewKPI, Table.GetCellText(TableColumnsNames.KeyPerformanceIndicatorTableColumnName));
            ClassicAssert.AreNotEqual(NewJobTitle, Table.GetCellText(TableColumnsNames.JobTitleTableColumnName));
            ClassicAssert.AreNotEqual(NewMinimumRating, Table.GetCellText(TableColumnsNames.MinRateTableColumnName));
        }

        [Test]
        public void H_AdminFunctionalityTest()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.AdminButtonName);

            GenericPages.BasePage.TopBarMenu.ClickTopbarMenuButtonByName(AdminPageTopBarMenuButtonsNames.UserManagementTopBarMenuButtonName);

            ClassicAssert.AreEqual(AdminPageTopBarMenuButtonsNames.UsersTopBarMenuButtonName, GenericPages.AdminPage.GetUsersDropdownElementText());

            GenericPages.BasePage.TopBarMenu.ClickTopbarMenuButtonByName(AdminPageTopBarMenuButtonsNames.JobTopBarMenuButtonName);

            ClassicAssert.AreEqual(AdminPageTopBarMenuButtonsNames.JobTitlesTopBarMenuButtonName, GenericPages.AdminPage.GetJobTitleDropdownElementText());
        }

        [Test]
        public void I_EditNationalityTest()
        {
            const string NewNationalityName = "111";

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.AdminButtonName);

            GenericPages.BasePage.TopBarMenu.ClickTopbarMenuButtonByName(AdminPageTopBarMenuButtonsNames.NationalitiesTopBarMenuButtonName);

            ClassicAssert.AreEqual(AdminPageHeadersTextValues.NationalitiesHeaderTextValue, GenericPages.AdminPage.GetNationalitiesText());

            var nationality = Table.GetCellText(TableColumnsNames.NationalityTableColumnName);
            Table.ClickPencilEditButton();

            ClassicAssert.AreEqual(AdminPageHeadersTextValues.EditNationalityHeaderTextValue, GenericPages.AdminPage.GetEditNationalitiyText());

            GenericPages.AdminPage.ClearNationalityName();
            GenericPages.AdminPage.EnterValueInInputTextField(InputFieldsNames.NameInputFieldName, NewNationalityName);
            GenericPages.AdminPage.ClickSaveButton();

            ClassicAssert.AreEqual(NewNationalityName, Table.GetCellText(TableColumnsNames.NationalityTableColumnName));

            Table.ClickPencilEditButton();

            ClassicAssert.AreEqual(AdminPageHeadersTextValues.EditNationalityHeaderTextValue, GenericPages.AdminPage.GetEditNationalitiyText());

            GenericPages.AdminPage.ClearNationalityName();
            GenericPages.AdminPage.EnterNationalityNameBack(nationality);
            GenericPages.AdminPage.ClickSaveButton();

            ClassicAssert.AreEqual(nationality, Table.GetCellText(TableColumnsNames.NationalityTableColumnName));
        }

        [Test]
        public void J_RecruitmentManagementFunctionalityTest()
        {
            const string NewVacancyName = "111";
            const string NewHiringManagerName = "a";
            const string JobTitleITManager = "IT Manager";

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.RecruitmentButtonName);

            GenericPages.BasePage.TopBarMenu.ClickTopbarMenuButtonByName(RecruitmentPageTopBarMenuButtonsNames.VacanciesTopBarMenuButtonName);

            ClassicAssert.AreEqual(RecruitmentPageHeadersTextValues.VacanciesHeaderTextValue, GenericPages.RecruitmentPage.GetVacanciesTextResult());

            GenericPages.BasePage.ClickAddButton();
            GenericPages.RecruitmentPage.EnterValueInInputTextField(InputFieldsNames.VacancyNameInputFieldName, NewVacancyName);
            GenericPages.RecruitmentPage.ClickDropDownListArrowButtonByName(DropDownFieldsNames.JobTitleDropDownFieldName);
            MyWebElement.SelectValueFromOrangeDropdownList(JobTitleITManager);
            GenericPages.RecruitmentPage.EnterValueInInputTextField(InputFieldsNames.HiringManagerInputFieldName, NewHiringManagerName);
            GenericPages.PIMPage.ClickDropdownListFirstPosition();
            GenericPages.RecruitmentPage.ClickSaveButton();

            ClassicAssert.AreEqual(RecruitmentPageHeadersTextValues.EditVacancyHeaderTextValue, GenericPages.RecruitmentPage.GetEditVacanciesTextResult());

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.RecruitmentButtonName);
            GenericPages.BasePage.TopBarMenu.ClickTopbarMenuButtonByName(RecruitmentPageTopBarMenuButtonsNames.VacanciesTopBarMenuButtonName);

            ClassicAssert.AreEqual(RecruitmentPageHeadersTextValues.VacanciesHeaderTextValue, GenericPages.RecruitmentPage.GetVacanciesTextResult());
            ClassicAssert.AreEqual(NewVacancyName, Table.GetCellText(TableColumnsNames.VacancyTableColumnName));
            ClassicAssert.AreEqual(JobTitleITManager, Table.GetCellText(TableColumnsNames.JobTitleTableColumnName));
            ClassicAssert.AreEqual("Active", Table.GetCellText(TableColumnsNames.StatusTableColumnName));

            Table.ClickTrashButton();
            GenericPages.RecruitmentPage.ClickConfirmDeletionButton();

            ClassicAssert.AreNotEqual(NewVacancyName, Table.GetCellText(TableColumnsNames.VacancyTableColumnName));
        }

        [Test]
        public void K_AssignLeaveTest()
        {
            const string NewEmployeeName = "111";
            const string NewEntitlement = "10";
            const string ShowLeaveWithStatusDropDownFieldValue = "Show Leave with Status";
            const string CANVacationDropDownFieldValue = "CAN - Vacation";
            const string ScheduledDropDownFieldValue = "Scheduled";

            GenericPages.BaseTest.CreateEmployee();

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.LeaveButtonName);

            GenericPages.BasePage.TopBarMenu.ClickTopbarMenuButtonByName(LeavePageTopBarMenuButtonsNames.EntitlementsTopBarMenuButtonName);
            GenericPages.BasePage.TopBarMenu.ClickTopbarMenuButtonByName(LeavePageTopBarMenuButtonsNames.AddEntitlementsTopBarMenuButtonName);

            ClassicAssert.AreEqual("Add Leave Entitlement", GenericPages.LeavePage.GetMainTitleText());

            GenericPages.LeavePage.EnterValueInInputTextField(InputFieldsNames.EmployeeNameInputFieldName, NewEmployeeName);
            GenericPages.PIMPage.ClickDropdownListFirstPosition();
            GenericPages.LeavePage.ClickDropDownListArrowButtonByName(DropDownFieldsNames.LeaveTypeDropDownFieldName);
            MyWebElement.SelectValueFromOrangeDropdownList(CANVacationDropDownFieldValue);
            GenericPages.LeavePage.EnterValueInInputTextField(InputFieldsNames.EntitlementInputFieldName, NewEntitlement);
            GenericPages.LeavePage.ClickSaveButton();
            GenericPages.LeavePage.ClickConfirmButton();

            GenericPages.BasePage.TopBarMenu.ClickTopbarMenuButtonByName(LeavePageTopBarMenuButtonsNames.AssignLeaveTopBarMenuButtonName);

            ClassicAssert.AreEqual(LeavePageTopBarMenuButtonsNames.AssignLeaveTopBarMenuButtonName, GenericPages.LeavePage.GetMainTitleText());

            GenericPages.LeavePage.EnterValueInInputTextField(InputFieldsNames.EmployeeNameInputFieldName, NewEmployeeName);
            GenericPages.PIMPage.ClickDropdownListFirstPosition();
            GenericPages.LeavePage.ClickDropDownListArrowButtonByName(DropDownFieldsNames.LeaveTypeDropDownFieldName);
            MyWebElement.SelectValueFromOrangeDropdownList(CANVacationDropDownFieldValue);

            GenericPages.LeavePage.ClickDropDownListArrowButtonByName(DropDownFieldsNames.FromDateDropDownFieldName);
            GenericPages.LeavePage.ClickFromDateCalendarValueButton();
            GenericPages.LeavePage.ClickDropDownListArrowButtonByName(DropDownFieldsNames.ToDateDropDownFieldName);
            GenericPages.LeavePage.ClickToDateCalendarValueButton();
            GenericPages.LeavePage.ClickSaveButton();
            //Implementation of wait while element appears - was discussed
            string GetSuccessfullySavedMessageTextResult() => GenericPages.BasePage.GetPopUpMessageTextElement();

            ClassicAssert.AreEqual(InfoMessageTextValues.SuccessfullySavedMessageText, GetSuccessfullySavedMessageTextResult());

            GenericPages.BasePage.TopBarMenu.ClickTopbarMenuButtonByName(LeavePageTopBarMenuButtonsNames.LeaveListTopBarMenuButtonName);
            GenericPages.LeavePage.ClickDropDownListArrowButtonByName(ShowLeaveWithStatusDropDownFieldValue);
            GenericPages.LeavePage.ClickDropdownList(ScheduledDropDownFieldValue);
            GenericPages.LeavePage.ClickDropDownListArrowButtonByName(DropDownFieldsNames.LeaveTypeDropDownFieldName);
            MyWebElement.SelectValueFromOrangeDropdownList(CANVacationDropDownFieldValue);
            GenericPages.LeavePage.EnterValueInInputTextField(InputFieldsNames.EmployeeNameInputFieldName, NewEmployeeName);
            GenericPages.PIMPage.ClickDropdownListFirstPosition();
            GenericPages.LeavePage.ClickSearchButton();

            ClassicAssert.AreEqual("111 222 333", Table.GetCellText(TableColumnsNames.EmployeeNameTableColumnName));

            GenericPages.BaseTest.DeleteCreatedEmployee();
        }

        [Test]
        public void L_AddJobTitleTest()
        {
            const string NewJobTitleName = "111";

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.AdminButtonName);

            GenericPages.BasePage.TopBarMenu.ClickTopbarMenuButtonByName(AdminPageTopBarMenuButtonsNames.JobTopBarMenuButtonName);
            GenericPages.BasePage.TopBarMenu.ClickTopbarMenuButtonByName(AdminPageTopBarMenuButtonsNames.JobTitlesTopBarMenuButtonName);

            ClassicAssert.AreEqual(AdminPageTopBarMenuButtonsNames.JobTitlesTopBarMenuButtonName, GenericPages.AdminPage.GetJobTitlesText());

            GenericPages.AdminPage.ClickAddButton();
            GenericPages.AdminPage.EnterValueInInputTextField(InputFieldsNames.JobTitleInputFieldName, NewJobTitleName);
            GenericPages.AdminPage.ClickSaveButton();

            ClassicAssert.AreEqual(NewJobTitleName, Table.GetCellText(TableColumnsNames.JobTitlesTableColumnName));

            Table.ClickTrashButton();
            GenericPages.AdminPage.ClickConfirmDeletionButton();

            ClassicAssert.AreNotEqual(NewJobTitleName, Table.GetCellText(TableColumnsNames.JobTitlesTableColumnName));
        }

        [Test]
        public void M_SearchEmployeeTest()
        {
            const string NewEmployeeName = "111 222";
            const string UnvalidEmployeeName = "123456";

            GenericPages.BaseTest.CreateEmployee();

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.PIMButtonName);

            GenericPages.PIMPage.EnterValueInInputTextField(InputFieldsNames.EmployeeNameInputFieldName, NewEmployeeName);
            GenericPages.PIMPage.ClickDropdownListFirstPosition();
            GenericPages.PIMPage.ClickSearchButton();

            ClassicAssert.AreEqual(NewEmployeeName, Table.GetCellText("First (& Middle) Name"));

            GenericPages.PIMPage.EnterValueInInputTextField(InputFieldsNames.EmployeeNameInputFieldName, Keys.Control + "a" + Keys.Delete);
            GenericPages.PIMPage.EnterValueInInputTextField(InputFieldsNames.EmployeeNameInputFieldName, UnvalidEmployeeName);

            ClassicAssert.AreEqual(PIMPageHeadersTextValues.EmployeeInformationHeaderTextValue, GenericPages.PIMPage.GetImployeeInformationText());

            GenericPages.PIMPage.ClickSearchButton();

            ClassicAssert.AreEqual(InfoMessageTextValues.NoRecordsFoundMessageText, GenericPages.PIMPage.GetPopUpMessageTextElement());

            GenericPages.BaseTest.DeleteCreatedEmployee();
        }

        [Test]
        public void N_EditEmployeeDetailsTest()
        {
            const string NewEmployeeName = "111 222";

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.PIMButtonName);

            GenericPages.BasePage.TopBarMenu.ClickTopbarMenuButtonByName(PIMPageTopBarMenuButtonsNames.EmployeeListTopBarMenuButtonName);
            Table.ClickPencilEditButton();

            ClassicAssert.AreEqual(PIMPageHeadersTextValues.PersonalDetailsHeaderTextValue, GenericPages.PIMPage.GetPersonalDetailsHeaderTextElement());

            GenericPages.PIMPage.ClearFullUserName();
            GenericPages.PIMPage.EnterFullUserName();
            GenericPages.PIMPage.ClickSaveButton();
            GenericPages.BasePage.TopBarMenu.ClickTopbarMenuButtonByName(PIMPageTopBarMenuButtonsNames.EmployeeListTopBarMenuButtonName);

            ClassicAssert.AreEqual(PIMPageHeadersTextValues.EmployeeInformationHeaderTextValue, GenericPages.PIMPage.GetImployeeInformationText());

            GenericPages.PIMPage.EnterValueInInputTextField(InputFieldsNames.EmployeeNameInputFieldName, NewEmployeeName);
            GenericPages.PIMPage.ClickDropdownListFirstPosition();
            GenericPages.PIMPage.ClickSearchButton();

            ClassicAssert.AreEqual(NewEmployeeName, Table.GetCellText("First (& Middle) Name"));
            ClassicAssert.AreEqual("333", Table.GetCellText(TableColumnsNames.LastNameTableColumnName));

            GenericPages.BaseTest.DeleteCreatedEmployee();
        }

        [Test]
        public void O_SearchAdminTest()
        {
            const string NewUserName = "111admin";
            const string NewEmployeeName = "111 222";

            GenericPages.BaseTest.CreateEmployee();

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.AdminButtonName);

            GenericPages.BasePage.TopBarMenu.ClickTopbarMenuButtonByName(AdminPageTopBarMenuButtonsNames.UserManagementTopBarMenuButtonName);
            GenericPages.BasePage.TopBarMenu.ClickTopbarMenuButtonByName(AdminPageTopBarMenuButtonsNames.UsersTopBarMenuButtonName);
            GenericPages.AdminPage.ClickAddButton();
            GenericPages.BaseTest.CreateUser();

            ClassicAssert.AreEqual(InfoMessageTextValues.SuccessfullySavedMessageText, GenericPages.InfoMessage.GetInfoMessageTextResult());

            GenericPages.AdminPage.EnterValueInInputTextField(InputFieldsNames.UserNameInputFieldName, NewUserName);
            GenericPages.AdminPage.ClickSearchButton();
            Table.GetValueOfTextFieldByName(TableColumnsNames.EmployeeNameTableColumnName);

            ClassicAssert.AreEqual("111 333", Table.GetValueOfTextFieldByName(TableColumnsNames.EmployeeNameTableColumnName));

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.PIMButtonName);
            GenericPages.PIMPage.EnterValueInInputTextField(InputFieldsNames.EmployeeNameInputFieldName, NewEmployeeName);
            GenericPages.PIMPage.ClickDropdownListFirstPosition();
            GenericPages.PIMPage.ClickSearchButton();
            Table.ClickTableCellByName(TableColumnsNames.LastNameTableColumnName);

            ClassicAssert.AreEqual(PIMPageHeadersTextValues.PersonalDetailsHeaderTextValue, GenericPages.PIMPage.GetPersonalDetailsHeaderTextElement());

            GenericPages.BaseTest.DeleteCreatedEmployee();
        }

        [Test]
        public void P_ValidateCandidateManagementTest()
        {
            const string NewEmail = "111@gmail.com";
            const string NewCandidateName = "111";

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.RecruitmentButtonName);

            GenericPages.BasePage.TopBarMenu.ClickTopbarMenuButtonByName(RecruitmentPageTopBarMenuButtonsNames.CandidatesTopBarMenuButtonName);
            GenericPages.RecruitmentPage.ClickAddButton();

            GenericPages.RecruitmentPage.EnterFullCandidateName();
            GenericPages.RecruitmentPage.EnterValueInInputTextField(InputFieldsNames.EmailInputFieldName, NewEmail);
            GenericPages.RecruitmentPage.ClickSaveButton();
            GenericPages.BasePage.TopBarMenu.ClickTopbarMenuButtonByName(RecruitmentPageTopBarMenuButtonsNames.CandidatesTopBarMenuButtonName);
            GenericPages.RecruitmentPage.EnterValueInInputTextField(InputFieldsNames.CandidateNameInputFieldName, NewCandidateName);

            GenericPages.PIMPage.ClickDropdownListFirstPosition();
            GenericPages.RecruitmentPage.ClickSearchButton();

            ClassicAssert.AreEqual("111 222 333", Table.GetCellText("Candidate"));

            Table.CheckTableCheckBoxElement();
            Table.ClickDeleteSelectedButton();
            GenericPages.RecruitmentPage.ClickConfirmDeletionButton();

            ClassicAssert.AreEqual(InfoMessageTextValues.SuccessfullyDeletedMessageText, GenericPages.BasePage.GetPopUpMessageTextElement());
        }

        [Test]
        public void R_ResetPasswordTest()
        {
            const string NewUserName = "111admin";

            GenericPages.BaseTest.CreateEmployee();

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.AdminButtonName);

            GenericPages.BasePage.TopBarMenu.ClickTopbarMenuButtonByName(AdminPageTopBarMenuButtonsNames.UserManagementTopBarMenuButtonName);
            GenericPages.BasePage.TopBarMenu.ClickTopbarMenuButtonByName(AdminPageTopBarMenuButtonsNames.UsersTopBarMenuButtonName);
            GenericPages.AdminPage.ClickAddButton();
            GenericPages.BaseTest.CreateUser();

            ClassicAssert.AreEqual(InfoMessageTextValues.SuccessfullySavedMessageText, GenericPages.InfoMessage.GetInfoMessageTextResult());

            GenericPages.BasePage.TopBarMenu.ClickArrowButton();
            GenericPages.BasePage.TopBarMenu.ClickUserDropdownItemByName(TopBarUserDropDownButtons.LogoutButton);
            GenericPages.LoginPage.ClickForgotPassword();
            GenericPages.LoginPage.EnterValueInInputTextField(InputFieldsNames.UserNameInputFieldName, NewUserName);
            GenericPages.LoginPage.ClickResetPasswordButton();

            ClassicAssert.AreEqual("Reset Password link sent successfully", GenericPages.LoginPage.GetResetPasswordMessageTextResult());

            GenericPages.BaseTest.GoToLoginPage();
            GenericPages.LoginPage.LogInToOrangeCRM();
            GenericPages.BaseTest.DeleteCreatedEmployee();
        }

        [Test]
        public void S_ValidateJobTitlesTest()
        {
            const string NewJobTitleName = "111";

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.AdminButtonName);

            GenericPages.BasePage.TopBarMenu.ClickTopbarMenuButtonByName(AdminPageTopBarMenuButtonsNames.JobTopBarMenuButtonName);
            GenericPages.BasePage.TopBarMenu.ClickTopbarMenuButtonByName(AdminPageTopBarMenuButtonsNames.JobTitlesTopBarMenuButtonName);

            ClassicAssert.AreEqual(AdminPageTopBarMenuButtonsNames.JobTitlesTopBarMenuButtonName, GenericPages.AdminPage.GetJobTitlesText());

            GenericPages.AdminPage.ClickAddButton();
            GenericPages.AdminPage.EnterValueInInputTextField(InputFieldsNames.JobTitleInputFieldName, NewJobTitleName);
            GenericPages.AdminPage.ClickSaveButton();

            ClassicAssert.AreEqual(NewJobTitleName, Table.GetValueOfTextFieldByName(TableColumnsNames.JobTitlesTableColumnName));

            Table.CheckTableCheckBoxElement();
            Table.ClickDeleteSelectedButton();
            GenericPages.AdminPage.ClickConfirmDeletionButton();

            ClassicAssert.AreNotEqual(NewJobTitleName, Table.GetValueOfTextFieldByName(TableColumnsNames.JobTitlesTableColumnName));
        }

        [Test]
        public void T_AddCustomFieldToEmployeeProfileTest()
        {
            const string NewFieldName = "111";
            const string NewFieldValue = "123";

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.PIMButtonName);

            GenericPages.BasePage.TopBarMenu.ClickTopbarMenuButtonByName(PIMPageTopBarMenuButtonsNames.ConfigurationTopBarMenuButtonName);
            GenericPages.BasePage.TopBarMenu.ClickTopbarMenuButtonByName(PIMPageTopBarMenuButtonsNames.CustomFieldsTopBarMenuButtonName);

            ClassicAssert.AreEqual("Custom Fields", GenericPages.BasePage.GetMainTitleText());

            GenericPages.PIMPage.ClickAddButton();
            GenericPages.PIMPage.EnterValueInInputTextField(InputFieldsNames.FieldNameInputFieldName, NewFieldName);
            GenericPages.PIMPage.ChoseScreen();
            GenericPages.PIMPage.ChoseType();
            GenericPages.PIMPage.ClickSaveButton();
            GenericPages.BasePage.TopBarMenu.ClickTopbarMenuButtonByName(PIMPageTopBarMenuButtonsNames.EmployeeListTopBarMenuButtonName);

            ClassicAssert.AreEqual(PIMPageHeadersTextValues.EmployeeInformationHeaderTextValue, GenericPages.PIMPage.GetImployeeInformationText());

            Table.ClickPencilEditButton();

            ClassicAssert.AreEqual(NewFieldName, GenericPages.PIMPage.GetAddedCustomFieldNameTextElement());

            GenericPages.PIMPage.EnterValueInInputTextField(NewFieldName, NewFieldValue);
            GenericPages.PIMPage.ClickSaveCustomFieldButton();

            ClassicAssert.AreEqual(NewFieldName, GenericPages.PIMPage.GetAddedCustomFieldNameTextElement());

            GenericPages.PIMPage.EnterValueInInputTextField(NewFieldName, Keys.Control + "a" + Keys.Delete);
            GenericPages.PIMPage.ClickSaveCustomFieldButton();

            ClassicAssert.AreEqual(NewFieldName, GenericPages.PIMPage.GetAddedCustomFieldNameTextElement());

            GenericPages.BasePage.TopBarMenu.ClickTopbarMenuButtonByName(PIMPageTopBarMenuButtonsNames.ConfigurationTopBarMenuButtonName);
            GenericPages.BasePage.TopBarMenu.ClickTopbarMenuButtonByName(PIMPageTopBarMenuButtonsNames.CustomFieldsTopBarMenuButtonName);
            Table.ClickTrashButton();
            GenericPages.PIMPage.ClickConfirmDeletionButton();
        }

        [Test]
        public void U_ValidateAssignSkillToEmployeeProfileTest()
        {
            const string NewSkillValue = "SQL";

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.PIMButtonName);

            GenericPages.BasePage.TopBarMenu.ClickTopbarMenuButtonByName(PIMPageTopBarMenuButtonsNames.EmployeeListTopBarMenuButtonName);

            ClassicAssert.AreEqual(PIMPageHeadersTextValues.EmployeeInformationHeaderTextValue, GenericPages.PIMPage.GetImployeeInformationText());

            Table.ClickPencilEditButton();
            GenericPages.PIMPage.ClickQualificationsButton();
            GenericPages.PIMPage.ClickAddSkillsButton();
            GenericPages.PIMPage.ClickDropDownListArrowButtonByName(DropDownFieldsNames.SkillDropDownFieldName);
            MyWebElement.SelectValueFromOrangeDropdownList(NewSkillValue);
            GenericPages.PIMPage.ClickSaveButton();

            ClassicAssert.AreEqual(NewSkillValue, Table.GetValueOfTextFieldByName(TableColumnsNames.SkillTableColumnName));

            GenericPages.PIMPage.ClickSkillsTableTrashButton();
            GenericPages.PIMPage.ClickConfirmDeletionButton();

            GenericPages.BasePage.TopBarMenu.ClickArrowButton();
            GenericPages.BasePage.TopBarMenu.ClickUserDropdownItemByName(TopBarUserDropDownButtons.LogoutButton);
        }

        [Test]
        public void W_ValidLoginTest()
        {
            //TopbarMenu.ClickArrowButton();
            //TopBarMenu.ClickUserDropdownItemByName(TopBarUserDropDownButtons.LogoutButton);
            GenericPages.LoginPage.InputUserName(TestSettings.Username);
            GenericPages.LoginPage.InputPassword(TestSettings.Password);
            GenericPages.LoginPage.ClickLoginButton();

            ClassicAssert.AreEqual(Data.TestSettings.DashboardPageUrl, GenericPages.LoginPage.GetCurrentPageUrl());

            GenericPages.BasePage.TopBarMenu.ClickArrowButton();
            GenericPages.BasePage.TopBarMenu.ClickUserDropdownItemByName(TopBarUserDropDownButtons.LogoutButton);
        }

        [Test]
        public void X_InValidLoginTest()
        {
            //TopbarMenu.ClickArrowButton();
            //TopBarMenu.ClickUserDropdownItemByName(TopBarUserDropDownButtons.LogoutButton);
            GenericPages.LoginPage.InputUserName(TestSettings.UnvalidUsername);
            GenericPages.LoginPage.InputPassword(TestSettings.UnvalidPassword);
            GenericPages.LoginPage.ClickLoginButton();

            ClassicAssert.AreEqual("Invalid credentials", GenericPages.LoginPage.GetInvalidMessageTextResult());
        }
    }
}