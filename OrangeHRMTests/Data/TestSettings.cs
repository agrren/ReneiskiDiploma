using Microsoft.Extensions.Configuration;
using OrangeHRMTests.Data.Enums;

namespace OrangeHRMTests.Data
{
    public class TestSettings
    {
        public static Browsers Browser { get; set; }
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static string UnvalidUsername { get; set; }
        public static string UnvalidPassword { get; set; }
        public static string PageUrl { get; set; }
        public static string DashboardPageUrl { get; set; }

        static IConfiguration TestConfiguration { get; } = new ConfigurationBuilder().AddJsonFile("testsettings.json").Build();

        static TestSettings()
        {
            Enum.TryParse(TestConfiguration["Common:Browser"], out Browsers browser);
            Browser = browser;
            Username = TestConfiguration["LogIn:username"];
            Password = TestConfiguration["LogIn:password"];
            UnvalidUsername = TestConfiguration["LogIn:wusername"];
            UnvalidPassword = TestConfiguration["LogIn:wpassword"];
            PageUrl = TestConfiguration["Common:Urls:Page"];
            DashboardPageUrl = TestConfiguration["Common:Urls:DashboardPageUrl"];
        }
    }
}