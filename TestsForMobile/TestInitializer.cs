using FrameworkMobile;
using NUnit.Framework;

namespace TestsForMobile
{
    [SetUpFixture]
    public class TestInitializer
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            Session.Create();
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            AppBase.CloseApp();
        }
    }
}
