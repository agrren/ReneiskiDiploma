using NUnit.Framework.Legacy;
using NUnit.Framework;
using OrangeHRMTests.Data.Constants;
using OrangeHRMTests.PageObjects;
using NUnit.Allure.Core;

namespace OrangeHRMTests.Tests
{
    [TestFixture]
    [AllureNUnit]
    public class UITests : BaseTest
    {
        [Test]
        public void A_VerifyAboutPopupPropertiesValues()
        {
            GenericPages.DashboardPage.TopBarMenu.ClickArrowButton();
            GenericPages.DashboardPage.TopBarMenu.ClickUserDropdownItemByName(TopBarUserDropDownButtons.AboutButton);

            ClassicAssert.AreEqual(AboutPageTextValues.AboutHeaderTextValue, GenericPages.AboutPage.GetAboutNameTextResult());
            ClassicAssert.AreEqual(AboutPageTextValues.OrangeHRMOSVersionText, GenericPages.AboutPage.GetAboutVersionTextResult());
        }

        [Test]
        public void B_VerifySupportPopupHeaderValue()
        {
            GenericPages.DashboardPage.TopBarMenu.ClickArrowButton();
            GenericPages.DashboardPage.TopBarMenu.ClickUserDropdownItemByName(TopBarUserDropDownButtons.SupportButton);

            ClassicAssert.AreEqual(SupportPageTextValues.SupportPageHeaderTextValue, GenericPages.SupportPage.ReturnSupportTitleTextResult());
        }

        [Test]
        public void C_VerifyDashboardPageModulesNamesValues()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.DashboardButtonName);

            ClassicAssert.AreEqual(DashboardPageSectionHeadersNames.TimeAtWorkHeaderName, GenericPages.DashboardPage.GetTextResultByName(DashboardPageSectionHeadersNames.TimeAtWorkHeaderName));
            ClassicAssert.AreEqual(DashboardPageSectionHeadersNames.MyActionsHeaderName, GenericPages.DashboardPage.GetTextResultByName(DashboardPageSectionHeadersNames.MyActionsHeaderName));
            ClassicAssert.AreEqual(DashboardPageSectionHeadersNames.QuickLaunchHeaderName, GenericPages.DashboardPage.GetTextResultByName(DashboardPageSectionHeadersNames.QuickLaunchHeaderName));
            ClassicAssert.AreEqual(DashboardPageSectionHeadersNames.BuzzLatestPostsHeaderName, GenericPages.DashboardPage.GetTextResultByName(DashboardPageSectionHeadersNames.BuzzLatestPostsHeaderName));
            ClassicAssert.AreEqual(DashboardPageSectionHeadersNames.EmployeesOnLeaveTodayHeaderName, GenericPages.DashboardPage.GetTextResultByName(DashboardPageSectionHeadersNames.EmployeesOnLeaveTodayHeaderName));
            ClassicAssert.AreEqual(DashboardPageSectionHeadersNames.EmployeeDistributionBySubUnitHeaderName, GenericPages.DashboardPage.GetTextResultByName(DashboardPageSectionHeadersNames.EmployeeDistributionBySubUnitHeaderName));
            ClassicAssert.AreEqual(DashboardPageSectionHeadersNames.EmployeeDistributionByLocationHeaderName, GenericPages.DashboardPage.GetTextResultByName(DashboardPageSectionHeadersNames.EmployeeDistributionByLocationHeaderName));

            GenericPages.DashboardPage.ClickWheelButton();

            ClassicAssert.AreEqual(DashboardPageSectionHeadersNames.ConfigurationsHeaderTextValue, GenericPages.DashboardPage.GetConfigTextResult());

            GenericPages.DashboardPage.ClickCrossButton();
            GenericPages.DashboardPage.ClickWheelButton();

            ClassicAssert.AreEqual(DashboardPageSectionHeadersNames.ConfigurationsHeaderTextValue, GenericPages.DashboardPage.GetConfigTextResult());

            GenericPages.DashboardPage.ClickCancelButton();
        }

        [Test]
        public void D_AdminPageTopBarMenuDropdownValues()
        {
            GenericPages.BasePage.LeftMenuNavigationPanel.GoToLeftMenuItem(LeftMenuNavigationPanelButtonsNames.AdminButtonName);

            GenericPages.AdminPage.TopBarMenu.ClickTopbarMenuButtonByName(AdminPageTopBarMenuButtonsNames.UserManagementTopBarMenuButtonName);

            ClassicAssert.AreEqual(AdminPageTopBarMenuButtonsNames.UsersTopBarMenuButtonName, GenericPages.AdminPage.GetOpenedDropDownFirstOption());

            GenericPages.AdminPage.TopBarMenu.ClickTopbarMenuButtonByName(AdminPageTopBarMenuButtonsNames.JobTopBarMenuButtonName);

            ClassicAssert.AreEqual(AdminPageTopBarMenuButtonsNames.JobTitlesTopBarMenuButtonName, GenericPages.AdminPage.GetOpenedDropDownFirstOption());
        }
    }
}
