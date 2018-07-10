using FrameworkCommon;
using NUnit.Framework;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Net.Http;
using Assert = FrameworkCommon.Assert;
using TestContext = FrameworkCommon.TestContext;

namespace FrameworkApi
{
    public class TestBase
    {
        #region Test Properties
        
        /// <summary>
        /// Provides a base class for sending HTTP requests and receiving HTTP responses from a resource identified by a URI.
        /// </summary>
        protected HttpClient httpClient
        {
            get
            {
                return (HttpClient)TestContext.Get("httpClient");
            }
        }

        #endregion Test Properties

        [SetUp]
        public void SetUp()
        {
            // Get the Base Address
            string baseAddress = ConfigurationManager.AppSettings["baseAddress"] ?? "";

            // Save a reference to the current Test's log in its TestContext
            TestContext.Set("log", "");

            // Log the test attributes of the current [Test]
            Log.StandardAttributes();

            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "baseAddress", baseAddress }
            });

            // Perform the action
            try
            {
                // Create a new instance of the httpclient
                HttpClient httpClient = new HttpClient();
                if (baseAddress.Length > 0)
                {
                    httpClient.BaseAddress = new Uri(baseAddress);
                }
                // Save that to the test context
                TestContext.Set("httpClient", httpClient);
                // Logging - After action success
                Log.Success();
            }
            catch (Exception e)
            {
                // Logging - After action exception
                Log.Failure(e.Message);
                // Fail current test
                Assert.Fail(e.Message);
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        [TearDown]
        public void TearDown()
        {
            // Log Before Action
            Log.BeforeAction();

            // Print this Test's log (from "TestContext") to the system console
            string log = TestContext.Get("log").ToString();
            if (log.Length > 0)
            {
                Console.WriteLine(log);
            }
        }
    }
}
