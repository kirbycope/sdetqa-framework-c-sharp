using FrameworkCommon.Attributes;
using NUnit.Framework;

namespace TestsForMobile.Tests
{
    public class HomePage
    {
        [Test]
        [Automates("QA-123")]
        [AutomatedBy("TA-456")]
        [Category("Regression")]
        [Description("This is an example of a 'Test' in a 'Test Fixture'.")]
        public void Mobile_HomePage_ExampleTest()
        {
            // Arrange
            App.HomePage.Open();
            // Act
            App.HomePage.webElement.Tap();
            // Assert
            Assert.IsTrue(true);
        }
    }
}
