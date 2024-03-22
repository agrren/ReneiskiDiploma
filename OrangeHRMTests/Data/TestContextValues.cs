using NUnit.Framework;

namespace OrangeHRMTests.Data
{
    public class TestContextValues
    {
        public static string ExecutableClassName => TestContext.CurrentContext.Test.ClassName;
    }
}