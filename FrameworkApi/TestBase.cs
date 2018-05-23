using FrameworkCommon;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using System.Text;
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
            // Save a reference to the current Test's log in its TestContext
            TestContext.Set("log", "");

            // Get the Base Address
            string baseAddress = ConfigurationManager.AppSettings["baseAddress"] ?? "";

            // Get the Test's custom Attributes
            IEnumerable<CustomAttributeData> customAttributeDatas = new StackTrace().GetFrame(1).GetMethod().CustomAttributes;
            // Log the custom Attributes
            Log.CustomAttributes(customAttributeDatas);
            // Write an end-line
            Log.WriteLine();
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "TestBase.SetUp()");
            sb.AppendLine(logPadding.InfoPadding + "[INFO] Base Address: " + baseAddress);
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
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
                Log.Success(logPadding.Padding);
            }
            catch (Exception e)
            {
                // Logging - After action exception
                sb = Log.Exception(sb, e);
                // Fail current Test
                Assert.Fail(sb.ToString());
            }
            finally
            {
                // Logging - After action
                Log.Finally(logPadding.Padding);
            }
        }

        [TearDown]
        public void TearDown()
        {
            // Print this Test's log (from "TestContext") to the system console
            string log = TestContext.Get("log").ToString();
            if (log.Length > 0)
            {
                Console.WriteLine(log);
            }
        }
    }
}
