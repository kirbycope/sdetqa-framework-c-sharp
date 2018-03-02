using FrameworkCommon;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using Assert = FrameworkCommon.Assert;
using TestContext = FrameworkCommon.TestContext;

namespace FrameworkMobile
{
    public class TestBase
    {
        #region Test Run Variable Defaults

        public const int defaultTimeoutInSeconds = 30;
        public const int sessionTimeoutInMinutes = 5;

        #endregion Test Run Variable Defaults

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
            //sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Create a variable to serve as a flag for if a new session needs to be created or not
                bool createNewSession = false;
                // Create a variable to hold the Test's WebDriver
                AppiumDriver<AppiumWebElement> driver = null;
                // Is the global WebDriver varaiable set?
                if ((Session.driver != null))
                {
                    // Is there session info?
                    Dictionary<string, object> sessionInfo = null;
                    try { sessionInfo = Session.driver.SessionDetails; }
                    catch { /* do nothing */ }
                    if (sessionInfo != null)
                    {
                        // Use the existing session
                        Log.WriteLine(logPadding.InfoPadding + "[INFO] Using the existing session.");
                        driver = Session.driver;
                    }
                    else
                    {
                        // Set the flag to create a new session to true
                        createNewSession = true;
                    }
                }
                // Should we create a new session?
                if (createNewSession == true)
                {
                    // Wait 60 seconds to kill the current session (in SauceLab's TestObject)
                    if (ConfigurationManager.AppSettings["appConfig"].ToString().Contains("SauceLabs"))
                    {
                        Sleep.Milliseconds(60000, "Waiting 60 seconds to kill the current session (in SauceLab's TestObject).");
                    }
                    // Create a new session
                    Log.WriteLine(logPadding.InfoPadding + "[INFO] Creating a new session.");
                    driver = Session.Create();
                }
                // Save a reference to the current Test's driver in its TestContext
                TestContext.Set("driver", driver);

                // Reset the app
                AppBase.ResetApp();

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
            //sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Check if the Test that is ending was a failure
                if (NUnit.Framework.TestContext.CurrentContext.Result.Outcome != NUnit.Framework.Interfaces.ResultState.Success)
                {
                    // Take screenshot of the failure state
                    //AppBase.GetScreenshot();
                    // Logging - After action success
                    //Log.Success(logPadding.Padding);
                }
            }
            catch (Exception e)
            {
                // Logging - After action exception
                sb = Log.Exception(sb, e);
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
