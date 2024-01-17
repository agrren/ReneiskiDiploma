using Microsoft.Extensions.Configuration;
using OrangeHRMTests.Data.Enums;

namespace OrangeHRMTests.Data
{
    public class TestSettings
    {
        public static Browsers Browser { get; set; }
        public static string username { get; set; }
        public static string password { get; set; }
        public static string wusername { get; set; }
        public static string wpassword { get; set; }
        public static string PageUrl { get; set; }

        static IConfiguration TestConfiguration { get; } = new ConfigurationBuilder().AddJsonFile("testsettings.json").Build();

        static TestSettings()
        {
            Enum.TryParse(TestConfiguration["Common:Browser"], out Browsers browser);
            Browser = browser;
            username = TestConfiguration["LogIn:username"];
            password = TestConfiguration["LogIn:password"];
            wusername = TestConfiguration["LogIn:wusername"];
            wpassword = TestConfiguration["LogIn:wpassword"];
            PageUrl = TestConfiguration["Common:Urls:Page"];
        }
    }
}