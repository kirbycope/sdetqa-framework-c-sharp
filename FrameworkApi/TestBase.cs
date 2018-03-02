using FrameworkCommon;
using Newtonsoft.Json.Linq;
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
            string baseAddress = ConfigurationManager.AppSettings["baseAddress"];

            // Get the Test's custom Attributes
            IEnumerable<CustomAttributeData> customAttributeDatas = new StackTrace().GetFrame(1).GetMethod().CustomAttributes;
            // Parse the collection
            CustomAttributeData descriptionAttribute = null;
            CustomAttributeData automatesAttribute = null;
            CustomAttributeData automatedByAttribute = null;
            foreach (CustomAttributeData customAttributeData in customAttributeDatas)
            {
                // Convert the object to JSON for easy parsing
                JObject jObject = JObject.FromObject(customAttributeData);
                // Check each CustomAttributeData for a value containing "NUnit.Framework.DescriptionAttribute"
                foreach (var kvp in jObject)
                {
                    // Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
                    if (kvp.Value.ToString().Contains("NUnit.Framework.DescriptionAttribute"))
                    {
                        descriptionAttribute = customAttributeData;
                    }
                    else if (kvp.Value.ToString().Contains(".Automates"))
                    {
                        automatesAttribute = customAttributeData;
                    }
                    else if (kvp.Value.ToString().Contains(".AutomatedBy"))
                    {
                        automatedByAttribute = customAttributeData;
                    }
                    // Stop parsing if we have found what we were looking for
                    if ((descriptionAttribute != null) && (automatesAttribute != null))
                    {
                        break;
                    }
                }
            }
            // Log the current Test's [Description("")]
            try { Log.WriteLine("[INFO] Test Description: " + descriptionAttribute.ConstructorArguments[0].Value.ToString()); }
            catch { /* do nothing */ }
            // Log the current Test's [Automates("")]
            try { Log.WriteLine("[INFO] Test Automates: " + automatesAttribute.ConstructorArguments[0].Value.ToString()); }
            catch { /* do nothing */ }
            // Log the current Test's [AutomatedBy("")]
            try { Log.WriteLine("[INFO] Test AutomatedBy: " + automatedByAttribute.ConstructorArguments[0].Value.ToString()); }
            catch { /* do nothing */ }
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
            // Print log to console (for Visual Studio and Bamboo)
            string log = TestContext.Get("log").ToString();
            if (log.Length > 0)
            {
                Console.WriteLine(log);
            }
        }
    }
}
