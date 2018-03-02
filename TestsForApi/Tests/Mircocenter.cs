using FrameworkApi;
using FrameworkCommon.Attributes;
using NUnit.Framework;
using System.Net.Http;
using Assert = FrameworkCommon.Assert;

namespace TestsForApi.Tests
{
    public class Mircocenter : TestBase
    {
        [Test]
        [Automates("QA-123")]
        [AutomatedBy("TA-456")]
        [Category("Regression")]
        [Description("This is an example of a 'Test' in a 'Test Fixture'.")]
        public void API_Microcenter_ExampleTest()
        {
            // Arrange: Define the endpoint to be tested
            string requestUri = "/microcenter/product/11601";
            // Act: Make the request
            HttpResponseMessage response = App.MakeRequest(HttpMethod.Get, requestUri);
            // Assert: The request returns a sucessfull response
            Assert.IsTrue(response.IsSuccessStatusCode, "Reponse was not a success status code!");
        }
    }
}
