using FrameworkCommon;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using Assert = FrameworkCommon.Assert;
using TestContext = FrameworkCommon.TestContext;

namespace FrameworkDesktop
{
    public class TestBase
    {
        #region Test Run Variable Defaults

        public const int defaultTimeoutInSeconds = 60;

        #endregion Test Run Variable Defaults

        #region Test Properties

        /// <summary>
        /// Get the WebDriver from the current Test's Context.
        /// </summary>
        protected static IWebDriver driver
        {
            get
            {
                return (IWebDriver)TestContext.Get("driver");
            }
        }

        /// <summary>
        /// Get the Base URL from the current Test's Context.
        /// </summary>
        protected static string baseUrl
        {
            get
            {
                return TestContext.Get("baseUrl").ToString();
            }
        }

        #endregion Test Properties

        [SetUp]
        public void Setup()
        {
            // Save a reference to the current Test's log in its TestContext
            TestContext.Set("log", "");

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
            sb.AppendLine(logPadding.Padding + "TestBase.Setup()");
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Create a WebDrvier session
                Session.Create();

                // Set WebDriver's window to full screen
                AppBase.Maximize();

                // Delete all cookies
                AppBase.DeleteAllCookies();

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
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "TestBase.TearDown()");
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Check if the Test that is ending was a failure
                if (NUnit.Framework.TestContext.CurrentContext.Result.Outcome != NUnit.Framework.Interfaces.ResultState.Success)
                {
                    // Take screenshot of the failure state
                    AppBase.TakeScreenshot();
                }
                // Quit this driver, closing every associated window.
                AppBase.Quit();
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
                Log.Finally("");

                // Print log to console (for Visual Studio and Bamboo)
                string log = TestContext.Get("log").ToString();
                if (log.Length > 0)
                {
                    Console.WriteLine(log);
                }
            }
        }
    }
}
