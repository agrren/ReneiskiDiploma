using OrangeHRMTests.PageObjects.Pages;
using OrangeHRMTests.PageObjects.Popups;

namespace OrangeHRMTests.PageObjects
{
    public static class GenericPages
    {
        public static BasePage BasePage => GetPage<BasePage>();
        public static LoginPage LoginPage => GetPage<LoginPage>();
        public static DashboardPage DashboardPage => GetPage<DashboardPage>();
        public static AboutPage AboutPage => GetPage<AboutPage>();
        public static SupportPage SupportPage => GetPage<SupportPage>();
        public static AdminPage AdminPage => GetPage<AdminPage>();
        public static AdminUserManagement AdminUserManagement => GetPage<AdminUserManagement>();
        public static PIMPage PIMPage => GetPage<PIMPage>();
        public static PerformancePage PerformancePage => GetPage<PerformancePage>();
        public static RecruitmentPage RecruitmentPage => GetPage<RecruitmentPage>();
        public static InfoMessage InfoMessage => GetPage<InfoMessage>();

        public static LeavePage LeavePage => GetPage<LeavePage>();

        private static T GetPage<T>() where T : new() => new T();
    }
}
