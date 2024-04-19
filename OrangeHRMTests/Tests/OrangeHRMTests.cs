using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OrangeHRMTests.Data.Constants;
using OrangeHRMTests.PageObjects;

namespace OrangeHRMTests.Tests
{
    [TestFixture]
    [AllureNUnit]
    public class OrangeHRMTests : BaseOrangeHrmTest
    {

        [Test]
        public void A_AdminPageSearchFunctionality()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.AdminButtonName);

            var userName = GenericPages.AdminPage.Table.GetCellText(TableColumnsNames.UserNameTableColumnName);
            var userRole = GenericPages.AdminPage.Table.GetCellText(TableColumnsNames.UserRoleTableColumnName);
            var employeeName = GenericPages.AdminPage.Table.GetCellText(TableColumnsNames.EmployeeNameTableColumnName);
            var userStatus = GenericPages.AdminPage.Table.GetCellText(TableColumnsNames.StatusTableColumnName);

            ClassicAssert.AreEqual(AdminPageHeadersTextValues.AdminUserManagementHeaderTextValue, GenericPages.AdminPage.TopBarMenu.GetAdminPageHeaderTextResult());
            ClassicAssert.AreEqual(AdminPageHeadersTextValues.SystemUsersHeaderTextValue, GenericPages.AdminPage.GetSystemUserTableHeaderTextResult());

            GenericPages.AdminPage.EnterValueInInputTextField(InputFieldsNames.UserNameInputFieldName, GenericPages.AdminPage.Table.GetCellText(TableColumnsNames.UserNameTableColumnName));
            GenericPages.AdminPage.ChooseValueFromDropDownByName(DropDownFieldsNames.UserRoleDropDownFieldName, GenericPages.AdminPage.Table.GetCellText(TableColumnsNames.UserRoleTableColumnName));
            GenericPages.AdminPage.EnterValueInInputTextField(InputFieldsNames.EmployeeNameInputFieldName, GenericPages.AdminPage.Table.GetCellText(TableColumnsNames.EmployeeNameTableColumnName));
            GenericPages.AdminPage.ChooseValueFromDropDownByName(DropDownFieldsNames.StatusDropDownFieldName, GenericPages.AdminPage.Table.GetCellText(TableColumnsNames.StatusTableColumnName));
            GenericPages.AdminPage.ClickSearchButton();

            ClassicAssert.AreEqual(userName, GenericPages.AdminPage.Table.GetCellText(TableColumnsNames.UserNameTableColumnName));
            ClassicAssert.AreEqual(userRole, GenericPages.AdminPage.Table.GetCellText(TableColumnsNames.UserRoleTableColumnName));
            ClassicAssert.AreEqual(employeeName, GenericPages.AdminPage.Table.GetCellText(TableColumnsNames.EmployeeNameTableColumnName));
            ClassicAssert.AreEqual(userStatus, GenericPages.AdminPage.Table.GetCellText(TableColumnsNames.StatusTableColumnName));
        }

        [Test]
        public void B_PIMPageAddEmployeeFunctionality()
        {
            var newFirstName = dataFaker.Person.FirstName;
            var newMiddleName = dataFaker.Person.FirstName;
            var newLastName = dataFaker.Person.LastName;

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.PIMButtonName);

            GenericPages.PIMPage.ClickAddButton();
            GenericPages.PIMPage.EnterFullUserName(newFirstName, newMiddleName, newLastName);
            GenericPages.PIMPage.ClickSaveButton();

            ClassicAssert.AreEqual(InfoMessageTextValues.SuccessfullySavedMessageText, GenericPages.InfoMessage.GetInfoMessageTextResult());

            GenericPages.PIMPage.ClickSaveButton();
            GenericPages.PIMPage.TopBarMenu.ClickTopbarMenuButtonByName(PIMPageTopBarMenuButtonsNames.EmployeeListTopBarMenuButtonName);
            GenericPages.PIMPage.EnterValueInInputTextField(InputFieldsNames.EmployeeNameInputFieldName, newFirstName + " " + newMiddleName);
            GenericPages.PIMPage.ClickSearchButton();

            ClassicAssert.AreEqual(string.Join(" ", newFirstName, newMiddleName), GenericPages.PIMPage.Table.GetCellText(TableColumnsNames.FirstMiddleNameTableColumnName));
            ClassicAssert.AreEqual(newLastName, GenericPages.PIMPage.Table.GetCellText(TableColumnsNames.LastNameTableColumnName));

            DeleteCreatedEmployee(newFirstName);
        }

        [Test]
        public void C_LeftMenuNavigationPanelSearchFunctionality()
        {
            const string ValueForSearch = "PIM";

            GenericPages.BasePage.LeftMenuNavigationPanel.EnterValueToSearchInputField(ValueForSearch);
            GenericPages.BasePage.LeftMenuNavigationPanel.PressEnter();

            ClassicAssert.AreEqual(ValueForSearch, GenericPages.BasePage.LeftMenuNavigationPanel.ReturnSearchResultText());

            GenericPages.BasePage.LeftMenuNavigationPanel.ClearSearchInputField();
        }

        [Test]
        public void D_PerformanceManagementAddKPIFunctionality()
        {
            var newKPI = dataFaker.Random.AlphaNumeric(7);
            var newMinimumRating = Convert.ToString(dataFaker.Random.Number(5));
            var newJobTitle = dataFaker.Random.AlphaNumeric(5);

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.AdminButtonName);

            GenericPages.AdminPage.TopBarMenu.ClickTopbarMenuButtonByName(AdminPageTopBarMenuButtonsNames.JobTopBarMenuButtonName);
            GenericPages.AdminPage.TopBarMenu.ClickTopbarMenuButtonByName(AdminPageTopBarMenuButtonsNames.JobTitlesTopBarMenuButtonName);
            GenericPages.AdminPage.ClickAddButton();
            GenericPages.AdminPage.EnterValueInInputTextField(InputFieldsNames.JobTitleInputFieldName, newJobTitle);
            GenericPages.AdminPage.ClickSaveButton();

            ClassicAssert.AreEqual(InfoMessageTextValues.SuccessfullySavedMessageText, GenericPages.AdminPage.GetPopUpMessageTextElement());

            GenericPages.AdminPage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.PerformanceButtonName);

            GenericPages.PerformancePage.TopBarMenu.ClickTopbarMenuButtonByName(PerformancePageTopBarMenuButtonsNames.ConfigureTopBarMenuButtonName);
            GenericPages.PerformancePage.TopBarMenu.ClickTopbarMenuButtonByName(PerformancePageTopBarMenuButtonsNames.KPIsTopBarMenuButtonName);
            GenericPages.PerformancePage.ClickAddButton();
            GenericPages.PerformancePage.EnterValueInInputTextField(InputFieldsNames.KeyPerformanceIndicatorInputFieldName, newKPI);
            GenericPages.PerformancePage.ChooseValueFromDropDownByName(DropDownFieldsNames.JobTitleDropDownFieldName, newJobTitle);
            GenericPages.PerformancePage.EnterValueInInputTextField(InputFieldsNames.MinimumRatingInputFieldName, newMinimumRating);
            GenericPages.PerformancePage.ClickSaveButton();

            GenericPages.PerformancePage.ChooseValueFromDropDownByName(DropDownFieldsNames.JobTitleDropDownFieldName, newJobTitle);
            GenericPages.PerformancePage.ClickSearchButton();

            ClassicAssert.AreEqual(newKPI, GenericPages.PerformancePage.Table.GetCellText(TableColumnsNames.KeyPerformanceIndicatorTableColumnName));
            ClassicAssert.AreEqual(newJobTitle, GenericPages.PerformancePage.Table.GetCellText(TableColumnsNames.JobTitleTableColumnName));
            ClassicAssert.AreEqual(newMinimumRating, GenericPages.PerformancePage.Table.GetCellText(TableColumnsNames.MinRateTableColumnName));

            GenericPages.PerformancePage.Table.ClickTrashButton();
            GenericPages.PerformancePage.ClickConfirmDeletionButton();
        }

        [Test]
        public void E_AdminPageEditNationalityFunctionality()
        {
            var newNationalityName = dataFaker.Random.AlphaNumeric(7);

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.AdminButtonName);

            GenericPages.AdminPage.TopBarMenu.ClickTopbarMenuButtonByName(AdminPageTopBarMenuButtonsNames.NationalitiesTopBarMenuButtonName);

            ClassicAssert.AreEqual(AdminPageHeadersTextValues.NationalitiesHeaderTextValue, GenericPages.AdminPage.GetMainTitleText());

            var nationality = GenericPages.BasePage.Table.GetCellText(TableColumnsNames.NationalityTableColumnName);
            GenericPages.AdminPage.Table.ClickPencilEditButton();

            ClassicAssert.AreEqual(AdminPageHeadersTextValues.EditNationalityHeaderTextValue, GenericPages.AdminPage.GetMainTitleText());

            GenericPages.AdminPage.ClearNationalityName();
            GenericPages.AdminPage.EnterValueInInputTextField(InputFieldsNames.NameInputFieldName, newNationalityName);
            GenericPages.AdminPage.ClickSaveButton();

            ClassicAssert.AreEqual(InfoMessageTextValues.SuccessfullyUpdatedMessageText, GenericPages.AdminPage.GetPopUpMessageTextElement());

            ClassicAssert.AreEqual(newNationalityName, GenericPages.AdminPage.Table.GetCellText(TableColumnsNames.NationalityTableColumnName));

            GenericPages.AdminPage.Table.ClickPencilEditButton();

            ClassicAssert.AreEqual(AdminPageHeadersTextValues.EditNationalityHeaderTextValue, GenericPages.AdminPage.GetMainTitleText());

            GenericPages.AdminPage.ClearNationalityName();
            GenericPages.AdminPage.EnterNationalityNameBack(nationality);
            GenericPages.AdminPage.ClickSaveButton();

            ClassicAssert.AreEqual(InfoMessageTextValues.SuccessfullyUpdatedMessageText, GenericPages.AdminPage.GetPopUpMessageTextElement());

            ClassicAssert.AreEqual(nationality, GenericPages.AdminPage.Table.GetCellText(TableColumnsNames.NationalityTableColumnName));
        }

        [Test]
        public void F_RecruitmentPageAddVacancyFunctionality()
        {
            const string NewHiringManagerName = "a";
            const string JobTitleITManager = "IT Manager";
            var newVacancyName = dataFaker.Random.AlphaNumeric(7);

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.RecruitmentButtonName);

            GenericPages.RecruitmentPage.TopBarMenu.ClickTopbarMenuButtonByName(RecruitmentPageTopBarMenuButtonsNames.VacanciesTopBarMenuButtonName);

            ClassicAssert.AreEqual(RecruitmentPageHeadersTextValues.VacanciesHeaderTextValue, GenericPages.RecruitmentPage.GetVacanciesTextResult());

            GenericPages.RecruitmentPage.ClickAddButton();
            GenericPages.RecruitmentPage.EnterValueInInputTextField(InputFieldsNames.VacancyNameInputFieldName, newVacancyName);
            GenericPages.RecruitmentPage.ChooseValueFromDropDownByName(DropDownFieldsNames.JobTitleDropDownFieldName, JobTitleITManager);
            GenericPages.RecruitmentPage.EnterValueInInputTextField(InputFieldsNames.HiringManagerInputFieldName, NewHiringManagerName);
            GenericPages.RecruitmentPage.ClickDropdownListFirstPosition();
            GenericPages.RecruitmentPage.ClickSaveButton();

            ClassicAssert.AreEqual(RecruitmentPageHeadersTextValues.EditVacancyHeaderTextValue, GenericPages.RecruitmentPage.GetEditVacanciesTextResult());

            GenericPages.RecruitmentPage.TopBarMenu.ClickTopbarMenuButtonByName(RecruitmentPageTopBarMenuButtonsNames.VacanciesTopBarMenuButtonName);

            GenericPages.RecruitmentPage.ChooseValueFromDropDownByName(DropDownFieldsNames.VacancyDropDownFieldName, newVacancyName);
            GenericPages.RecruitmentPage.ClickSearchButton();

            ClassicAssert.AreEqual(RecruitmentPageHeadersTextValues.VacanciesHeaderTextValue, GenericPages.RecruitmentPage.GetVacanciesTextResult());
            ClassicAssert.AreEqual(newVacancyName, GenericPages.RecruitmentPage.Table.GetCellText(TableColumnsNames.VacancyTableColumnName));
            ClassicAssert.AreEqual(JobTitleITManager, GenericPages.RecruitmentPage.Table.GetCellText(TableColumnsNames.JobTitleTableColumnName));
            ClassicAssert.AreEqual(RecruitmentPageHeadersTextValues.ActiveHeaderTextValue, GenericPages.RecruitmentPage.Table.GetCellText(TableColumnsNames.StatusTableColumnName));

            GenericPages.RecruitmentPage.Table.ClickTrashButton();
            GenericPages.RecruitmentPage.ClickConfirmDeletionButton();
        }

        [Test]
        public void G_LeavePageAssignLeaveFunctionality()
        {
            const string NewEntitlement = "10";
            const string ShowLeaveWithStatusDropDownFieldValue = "Show Leave with Status";
            const string CANVacationDropDownFieldValue = "CAN - Vacation";
            const string ScheduledDropDownFieldValue = "Scheduled";
            const string FromDateVacationValue = "29";
            const string ToDateVacationValue = "30";
            var newFirstName = dataFaker.Person.FirstName;
            var newMiddleName = dataFaker.Person.FirstName;
            var newLastName = dataFaker.Person.LastName;

            CreateEmployee(newFirstName, newMiddleName, newLastName);

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.LeaveButtonName);

            GenericPages.LeavePage.TopBarMenu.ClickTopbarMenuButtonByName(LeavePageTopBarMenuButtonsNames.EntitlementsTopBarMenuButtonName);
            GenericPages.LeavePage.TopBarMenu.ClickTopbarMenuButtonByName(LeavePageTopBarMenuButtonsNames.AddEntitlementsTopBarMenuButtonName);

            ClassicAssert.AreEqual(LeavePageHeadersTextValues.AddLeaveEntitlementHeaderTextValue, GenericPages.LeavePage.GetMainTitleText());

            GenericPages.LeavePage.EnterValueInInputTextField(InputFieldsNames.EmployeeNameInputFieldName, newFirstName);
            GenericPages.LeavePage.ClickDropdownListFirstPosition();
            GenericPages.LeavePage.ChooseValueFromDropDownByName(DropDownFieldsNames.LeaveTypeDropDownFieldName, CANVacationDropDownFieldValue);
            GenericPages.LeavePage.EnterValueInInputTextField(InputFieldsNames.EntitlementInputFieldName, NewEntitlement);
            GenericPages.LeavePage.ClickSaveButton();
            GenericPages.LeavePage.ClickConfirmButton();

            GenericPages.LeavePage.TopBarMenu.ClickTopbarMenuButtonByName(LeavePageTopBarMenuButtonsNames.AssignLeaveTopBarMenuButtonName);

            ClassicAssert.AreEqual(LeavePageTopBarMenuButtonsNames.AssignLeaveTopBarMenuButtonName, GenericPages.LeavePage.GetMainTitleText());

            GenericPages.LeavePage.EnterValueInInputTextField(InputFieldsNames.EmployeeNameInputFieldName, newFirstName);
            GenericPages.LeavePage.ClickDropdownListFirstPosition();
            GenericPages.LeavePage.ChooseValueFromDropDownByName(DropDownFieldsNames.LeaveTypeDropDownFieldName, CANVacationDropDownFieldValue);

            GenericPages.LeavePage.ClickDropDownListArrowButtonByName(DropDownFieldsNames.FromDateDropDownFieldName);
            GenericPages.LeavePage.ClickFromDateCalendarValueButton(FromDateVacationValue);
            GenericPages.LeavePage.ClickDropDownListArrowButtonByName(DropDownFieldsNames.ToDateDropDownFieldName);
            GenericPages.LeavePage.ClickToDateCalendarValueButton(ToDateVacationValue);
            GenericPages.LeavePage.ClickSaveButton();

            ClassicAssert.AreEqual(InfoMessageTextValues.SuccessfullySavedMessageText, GenericPages.LeavePage.GetPopUpMessageTextElement());

            GenericPages.BasePage.TopBarMenu.ClickTopbarMenuButtonByName(LeavePageTopBarMenuButtonsNames.LeaveListTopBarMenuButtonName);
            GenericPages.LeavePage.ClickDropDownListArrowButtonByName(ShowLeaveWithStatusDropDownFieldValue);
            GenericPages.LeavePage.ClickDropdownList(ScheduledDropDownFieldValue);
            GenericPages.LeavePage.ChooseValueFromDropDownByName(DropDownFieldsNames.LeaveTypeDropDownFieldName, CANVacationDropDownFieldValue);
            GenericPages.LeavePage.EnterValueInInputTextField(InputFieldsNames.EmployeeNameInputFieldName, newFirstName);
            GenericPages.LeavePage.ClickDropdownListFirstPosition();
            GenericPages.LeavePage.ClickSearchButton();

            ClassicAssert.AreEqual(string.Join(" ", newFirstName, newMiddleName, newLastName), GenericPages.LeavePage.Table.GetCellText(TableColumnsNames.EmployeeNameTableColumnName));

            DeleteCreatedEmployee(newFirstName);
        }

        [Test]
        public void H_AdminPageAddJobTitleFunctionality()
        {
            var newJobTitleName = Convert.ToString(dataFaker.Random.Number(3));

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.AdminButtonName);

            GenericPages.AdminPage.TopBarMenu.ClickTopbarMenuButtonByName(AdminPageTopBarMenuButtonsNames.JobTopBarMenuButtonName);
            GenericPages.AdminPage.TopBarMenu.ClickTopbarMenuButtonByName(AdminPageTopBarMenuButtonsNames.JobTitlesTopBarMenuButtonName);

            ClassicAssert.AreEqual(AdminPageTopBarMenuButtonsNames.JobTitlesTopBarMenuButtonName, GenericPages.AdminPage.GetMainTitleText());

            GenericPages.AdminPage.ClickAddButton();
            GenericPages.AdminPage.EnterValueInInputTextField(InputFieldsNames.JobTitleInputFieldName, newJobTitleName);
            GenericPages.AdminPage.ClickSaveButton();

            ClassicAssert.AreEqual(newJobTitleName, GenericPages.AdminPage.Table.GetCellText(TableColumnsNames.JobTitlesTableColumnName));

            GenericPages.AdminPage.Table.ClickTrashButton();
            GenericPages.AdminPage.ClickConfirmDeletionButton();
        }

        [Test]
        public void I_PIMPageSearchEmployeeFunctionality()
        {
            const string UnvalidEmployeeName = "123456";
            var newFirstName = dataFaker.Person.FirstName;
            var newMiddleName = dataFaker.Person.FirstName;
            var newLastName = dataFaker.Person.LastName;

            CreateEmployee(newFirstName, newMiddleName, newLastName);

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.PIMButtonName);

            GenericPages.PIMPage.EnterValueInInputTextField(InputFieldsNames.EmployeeNameInputFieldName, newFirstName);
            GenericPages.PIMPage.ClickDropdownListFirstPosition();
            GenericPages.PIMPage.ClickSearchButton();

            ClassicAssert.AreEqual(string.Join(" ", newFirstName, newMiddleName), GenericPages.BasePage.Table.GetCellText("First (& Middle) Name"));

            GenericPages.PIMPage.EnterValueInInputTextField(InputFieldsNames.EmployeeNameInputFieldName, Keys.Control + "a" + Keys.Delete);
            GenericPages.PIMPage.EnterValueInInputTextField(InputFieldsNames.EmployeeNameInputFieldName, UnvalidEmployeeName);

            ClassicAssert.AreEqual(PIMPageHeadersTextValues.EmployeeInformationHeaderTextValue, GenericPages.PIMPage.GetEmployeeInformationText());

            GenericPages.PIMPage.ClickSearchButton();

            ClassicAssert.AreEqual(InfoMessageTextValues.NoRecordsFoundMessageText, GenericPages.PIMPage.GetPopUpMessageTextElement());

            DeleteCreatedEmployee(newFirstName);
        }

        [Test]
        public void J_PIMPageEditEmployeeDetailsFunctionality()
        {
            var newFirstName = dataFaker.Person.FirstName;
            var newMiddleName = dataFaker.Person.FirstName;
            var newLastName = dataFaker.Person.LastName;

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.PIMButtonName);

            GenericPages.PIMPage.TopBarMenu.ClickTopbarMenuButtonByName(PIMPageTopBarMenuButtonsNames.EmployeeListTopBarMenuButtonName);
            GenericPages.PIMPage.Table.ClickPencilEditButton();

            ClassicAssert.AreEqual(PIMPageHeadersTextValues.PersonalDetailsHeaderTextValue, GenericPages.PIMPage.GetPersonalDetailsHeaderTextElement());

            GenericPages.PIMPage.ClearFullUserName();
            GenericPages.PIMPage.EnterFullUserName(newFirstName, newMiddleName, newLastName);
            GenericPages.PIMPage.ClickSaveButton();
            GenericPages.PIMPage.TopBarMenu.ClickTopbarMenuButtonByName(PIMPageTopBarMenuButtonsNames.EmployeeListTopBarMenuButtonName);

            ClassicAssert.AreEqual(PIMPageHeadersTextValues.EmployeeInformationHeaderTextValue, GenericPages.PIMPage.GetEmployeeInformationText());

            GenericPages.PIMPage.EnterValueInInputTextField(InputFieldsNames.EmployeeNameInputFieldName, newFirstName);
            GenericPages.PIMPage.ClickDropdownListFirstPosition();
            GenericPages.PIMPage.ClickSearchButton();

            ClassicAssert.AreEqual(string.Join(" ", newFirstName, newMiddleName), GenericPages.PIMPage.Table.GetCellText("First (& Middle) Name"));
            ClassicAssert.AreEqual(newLastName, GenericPages.PIMPage.Table.GetCellText(TableColumnsNames.LastNameTableColumnName));

            DeleteCreatedEmployee(newFirstName);
        }

        [Test]
        public void K_AdminPageSearchUserFunctionality()
        {
            var newFirstName = dataFaker.Person.FirstName;
            var newMiddleName = dataFaker.Person.FirstName;
            var newLastName = dataFaker.Person.LastName;
            var newUserName = dataFaker.Person.FirstName;
            var newPassword = dataFaker.Internet.Password(12);
            var newEmployeeName = string.Join(" ", newFirstName, newMiddleName);

            CreateEmployee(newFirstName, newMiddleName, newLastName);

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.AdminButtonName);

            GenericPages.AdminPage.TopBarMenu.ClickTopbarMenuButtonByName(AdminPageTopBarMenuButtonsNames.UserManagementTopBarMenuButtonName);
            GenericPages.AdminPage.TopBarMenu.ClickTopbarMenuButtonByName(AdminPageTopBarMenuButtonsNames.UsersTopBarMenuButtonName);
            GenericPages.AdminPage.ClickAddButton();
            CreateUser(newUserName, newPassword, newEmployeeName);

            ClassicAssert.AreEqual(InfoMessageTextValues.SuccessfullySavedMessageText, GenericPages.InfoMessage.GetInfoMessageTextResult());

            GenericPages.AdminPage.EnterValueInInputTextField(InputFieldsNames.UserNameInputFieldName, newUserName);
            GenericPages.AdminPage.ClickSearchButton();
            GenericPages.AdminPage.Table.GetValueOfTextFieldByName(TableColumnsNames.EmployeeNameTableColumnName);

            ClassicAssert.AreEqual(string.Join(" ", newFirstName, newLastName), GenericPages.AdminPage.Table.GetValueOfTextFieldByName(TableColumnsNames.EmployeeNameTableColumnName));

            GenericPages.AdminPage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.PIMButtonName);
            GenericPages.PIMPage.EnterValueInInputTextField(InputFieldsNames.EmployeeNameInputFieldName, newEmployeeName);
            GenericPages.PIMPage.ClickDropdownListFirstPosition();
            GenericPages.PIMPage.ClickSearchButton();
            GenericPages.PIMPage.Table.ClickTableCellByName(TableColumnsNames.LastNameTableColumnName);

            ClassicAssert.AreEqual(PIMPageHeadersTextValues.PersonalDetailsHeaderTextValue, GenericPages.PIMPage.GetPersonalDetailsHeaderTextElement());

            DeleteCreatedEmployee(newEmployeeName);
        }

        [Test]
        public void L_RecruitmentPageAddValidateCandidateFunctionality()
        {
            var newFirstName = dataFaker.Person.FirstName;
            var newMiddleName = dataFaker.Person.FirstName;
            var newLastName = dataFaker.Person.LastName;
            var newEmail = dataFaker.Person.Email;

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.RecruitmentButtonName);

            GenericPages.RecruitmentPage.TopBarMenu.ClickTopbarMenuButtonByName(RecruitmentPageTopBarMenuButtonsNames.CandidatesTopBarMenuButtonName);
            GenericPages.RecruitmentPage.ClickAddButton();

            GenericPages.RecruitmentPage.EnterFullCandidateName(newFirstName, newMiddleName, newLastName);
            GenericPages.RecruitmentPage.EnterValueInInputTextField(InputFieldsNames.EmailInputFieldName, newEmail);
            GenericPages.RecruitmentPage.ClickSaveButton();
            GenericPages.RecruitmentPage.TopBarMenu.ClickTopbarMenuButtonByName(RecruitmentPageTopBarMenuButtonsNames.CandidatesTopBarMenuButtonName);
            GenericPages.RecruitmentPage.EnterValueInInputTextField(InputFieldsNames.CandidateNameInputFieldName, newFirstName);
            GenericPages.RecruitmentPage.ClickDropdownListFirstPosition();
            GenericPages.RecruitmentPage.ClickSearchButton();

            ClassicAssert.AreEqual(string.Join(" ", newFirstName, newMiddleName, newLastName), GenericPages.BasePage.Table.GetCellText("Candidate"));

            GenericPages.RecruitmentPage.Table.CheckTableCheckBoxElement();
            GenericPages.RecruitmentPage.Table.ClickDeleteSelectedButton();
            GenericPages.RecruitmentPage.ClickConfirmDeletionButton();

            ClassicAssert.AreEqual(InfoMessageTextValues.SuccessfullyDeletedMessageText, GenericPages.RecruitmentPage.GetPopUpMessageTextElement());
        }

        [Test]
        public void M_ResetPasswordFunctionality()
        {

            var newFirstName = dataFaker.Person.FirstName;
            var newMiddleName = dataFaker.Person.FirstName;
            var newLastName = dataFaker.Person.LastName;
            var newUserName = dataFaker.Person.FirstName;
            var newPassword = dataFaker.Internet.Password(12);
            var newEmployeeName = newFirstName + " " + newMiddleName;

            CreateEmployee(newFirstName, newMiddleName, newLastName);

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.AdminButtonName);

            GenericPages.AdminPage.TopBarMenu.ClickTopbarMenuButtonByName(AdminPageTopBarMenuButtonsNames.UserManagementTopBarMenuButtonName);
            GenericPages.AdminPage.TopBarMenu.ClickTopbarMenuButtonByName(AdminPageTopBarMenuButtonsNames.UsersTopBarMenuButtonName);
            GenericPages.AdminPage.ClickAddButton();
            CreateUser(newUserName, newPassword, newEmployeeName);

            ClassicAssert.AreEqual(InfoMessageTextValues.SuccessfullySavedMessageText, GenericPages.InfoMessage.GetInfoMessageTextResult());

            GenericPages.AdminPage.TopBarMenu.ClickArrowButton();
            GenericPages.AdminPage.TopBarMenu.ClickUserDropdownItemByName(TopBarUserDropDownButtons.LogoutButton);
            GenericPages.LoginPage.ClickForgotPassword();
            GenericPages.LoginPage.EnterValueInInputTextField(InputFieldsNames.UserNameInputFieldName, newUserName);
            GenericPages.ResetPasswordPage.ClickResetPasswordButton();

            ClassicAssert.AreEqual("Reset Password link sent successfully", GenericPages.ResetPasswordPage.GetResetPasswordMessageTextResult());

            GenericPages.BaseTest.GoToLoginPage();
            GenericPages.LoginPage.LogInToOrangeCRM();
            DeleteCreatedEmployee(newFirstName);
        }

        [Test]
        public void N_AdminPageAddValidateJobTitle()
        {
            var newJobTitleName = Convert.ToString(dataFaker.Random.Number(7));

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.AdminButtonName);

            GenericPages.AdminPage.TopBarMenu.ClickTopbarMenuButtonByName(AdminPageTopBarMenuButtonsNames.JobTopBarMenuButtonName);
            GenericPages.AdminPage.TopBarMenu.ClickTopbarMenuButtonByName(AdminPageTopBarMenuButtonsNames.JobTitlesTopBarMenuButtonName);

            ClassicAssert.AreEqual(AdminPageTopBarMenuButtonsNames.JobTitlesTopBarMenuButtonName, GenericPages.AdminPage.GetMainTitleText());

            GenericPages.AdminPage.ClickAddButton();
            GenericPages.AdminPage.EnterValueInInputTextField(InputFieldsNames.JobTitleInputFieldName, newJobTitleName);
            GenericPages.AdminPage.ClickSaveButton();

            ClassicAssert.AreEqual(newJobTitleName, GenericPages.AdminPage.Table.GetValueOfTextFieldByName(TableColumnsNames.JobTitlesTableColumnName));

            GenericPages.AdminPage.Table.CheckTableCheckBoxElement();
            GenericPages.AdminPage.Table.ClickDeleteSelectedButton();
            GenericPages.AdminPage.ClickConfirmDeletionButton();
        }

        [Test]
        public void O_AddCustomFieldToEmployeeProfileFunctionality()
        {
            const string NewScreenDropDownValue = "Personal Details";
            const string NewTypeDropDownValue = "Text or Number";
            var newFieldName = Convert.ToString(dataFaker.Random.Number(7));
            var newFieldValue = dataFaker.Random.AlphaNumeric(7);

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.PIMButtonName);

            GenericPages.PIMPage.TopBarMenu.ClickTopbarMenuButtonByName(PIMPageTopBarMenuButtonsNames.ConfigurationTopBarMenuButtonName);
            GenericPages.PIMPage.TopBarMenu.ClickTopbarMenuButtonByName(PIMPageTopBarMenuButtonsNames.CustomFieldsTopBarMenuButtonName);

            ClassicAssert.AreEqual(PIMPageHeadersTextValues.CustomFieldsHeaderTextValue, GenericPages.PIMPage.GetMainTitleText());

            GenericPages.PIMPage.ClickAddButton();
            GenericPages.PIMPage.EnterValueInInputTextField(InputFieldsNames.FieldNameInputFieldName, newFieldName);
            GenericPages.PIMPage.ChooseValueFromDropDownByName(DropDownFieldsNames.ScreenDropDownFieldName, NewScreenDropDownValue);
            GenericPages.PIMPage.ChooseValueFromDropDownByName(DropDownFieldsNames.TypeDropDownFieldName, NewTypeDropDownValue);
            GenericPages.PIMPage.ClickSaveButton();
            GenericPages.PIMPage.TopBarMenu.ClickTopbarMenuButtonByName(PIMPageTopBarMenuButtonsNames.EmployeeListTopBarMenuButtonName);

            ClassicAssert.AreEqual(PIMPageHeadersTextValues.EmployeeInformationHeaderTextValue, GenericPages.PIMPage.GetEmployeeInformationText());

            GenericPages.PIMPage.Table.ClickPencilEditButton();

            ClassicAssert.AreEqual(newFieldName, GenericPages.PIMPage.GetAddedCustomFieldNameTextElement());

            GenericPages.PIMPage.EnterValueInInputTextField(newFieldName, newFieldValue);
            GenericPages.PIMPage.ClickSaveCustomFieldButton();

            ClassicAssert.AreEqual(newFieldName, GenericPages.PIMPage.GetAddedCustomFieldNameTextElement());

            GenericPages.PIMPage.EnterValueInInputTextField(newFieldName, Keys.Control + "a" + Keys.Delete);
            GenericPages.PIMPage.ClickSaveCustomFieldButton();

            ClassicAssert.AreEqual(newFieldName, GenericPages.PIMPage.GetAddedCustomFieldNameTextElement());

            GenericPages.PIMPage.TopBarMenu.ClickTopbarMenuButtonByName(PIMPageTopBarMenuButtonsNames.ConfigurationTopBarMenuButtonName);
            GenericPages.PIMPage.TopBarMenu.ClickTopbarMenuButtonByName(PIMPageTopBarMenuButtonsNames.CustomFieldsTopBarMenuButtonName);
            GenericPages.PIMPage.Table.ClickTrashButton();
            GenericPages.PIMPage.ClickConfirmDeletionButton();
        }

        [Test]
        public void P_ValidateAssignSkillToEmployeeProfile()
        {
            const string NewSkillValue = "SQL";

            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.PIMButtonName);

            GenericPages.PIMPage.TopBarMenu.ClickTopbarMenuButtonByName(PIMPageTopBarMenuButtonsNames.EmployeeListTopBarMenuButtonName);

            ClassicAssert.AreEqual(PIMPageHeadersTextValues.EmployeeInformationHeaderTextValue, GenericPages.PIMPage.GetEmployeeInformationText());

            GenericPages.PIMPage.Table.ClickPencilEditButton();
            GenericPages.PIMPage.ClickQualificationsButton();
            GenericPages.PIMPage.ClickAddSkillsButton();
            GenericPages.PIMPage.ChooseValueFromDropDownByName(DropDownFieldsNames.SkillDropDownFieldName, NewSkillValue);
            GenericPages.PIMPage.ClickSaveButton();

            ClassicAssert.AreEqual(NewSkillValue, GenericPages.PIMPage.Table.GetValueOfTextFieldByName(TableColumnsNames.SkillTableColumnName));

            GenericPages.PIMPage.ClickSkillsTableTrashButton();
            GenericPages.PIMPage.ClickConfirmDeletionButton();
        }

        private void CreateEmployee(string newFirstName, string newMiddleName, string newLastName)
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.PIMButtonName);
            GenericPages.PIMPage.ClickAddButton();
            GenericPages.PIMPage.EnterFullUserName(newFirstName, newMiddleName, newLastName);
            GenericPages.PIMPage.ClickSaveButton();
            ClassicAssert.AreEqual(InfoMessageTextValues.SuccessfullySavedMessageText, GenericPages.InfoMessage.GetInfoMessageTextResult());
            GenericPages.PIMPage.ClickSaveButton();
            GenericPages.PIMPage.TopBarMenu.ClickTopbarMenuButtonByName(PIMPageTopBarMenuButtonsNames.EmployeeListTopBarMenuButtonName);
        }

        private void CreateUser(string newUserName, string newPassword, string newEmployeeName)
        {
            const string NewUserRole = "Admin";
            const string NewUserStatus = "Enabled";

            GenericPages.AdminPage.ChooseValueFromDropDownByName(DropDownFieldsNames.UserRoleDropDownFieldName, NewUserRole);
            GenericPages.AdminPage.ChooseValueFromDropDownByName(DropDownFieldsNames.StatusDropDownFieldName, NewUserStatus);
            GenericPages.AdminPage.EnterValueInInputTextField(InputFieldsNames.EmployeeNameInputFieldName, newEmployeeName);
            GenericPages.AdminPage.ClickDropdownListFirstPosition();
            GenericPages.AdminPage.EnterValueInInputTextField(InputFieldsNames.UserNameInputFieldName, newUserName);
            GenericPages.AdminPage.EnterValueInInputTextField(InputFieldsNames.PasswordInputFieldName, newPassword);
            GenericPages.AdminPage.EnterValueInInputTextField(InputFieldsNames.ConfirmPasswordInputFieldName, newPassword);
            GenericPages.AdminPage.ClickSaveButton();
        }

        private void DeleteCreatedEmployee(string newFirstName)
        {
            GenericPages.AdminPage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.PIMButtonName);
            GenericPages.PIMPage.EnterValueInInputTextField(InputFieldsNames.EmployeeNameInputFieldName, newFirstName); ;
            GenericPages.PIMPage.ClickDropdownListFirstPosition();
            GenericPages.PIMPage.ClickSearchButton();
            GenericPages.PIMPage.Table.ClickTrashButton();
            GenericPages.PIMPage.ClickConfirmDeletionButton();
        }
    }
}