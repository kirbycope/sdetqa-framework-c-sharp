using FrameworkCommon.Attributes;
using FrameworkDesktop;
using NUnit.Framework;

namespace TestsForDesktop.Tests
{
    public class HomePage : TestBase
    {
        [Test]
        [Automates("QA-123")]
        [AutomatedBy("TA-456")]
        [Category("Regression")]
        [Description("This is an example of a 'Test' in a 'Test Fixture'.")]
        public void Desktop_HomePage_ExampleTest()
        {
            // Arrange
            App.HomePage.Open();
            // Act
            App.HomePage.buttonSdet.Click();
            // Assert
            Assert.IsTrue(driver.Url.Contains("/sdet"));
        }
    }
}
