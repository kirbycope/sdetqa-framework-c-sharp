using FrameworkCommon;
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
            // Log the custom Attributes
            Log.CustomAttributes(customAttributeDatas);
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
                    // Wait 60 seconds to kill the current session (the default TimeOut for Appium)
                    Sleep.Milliseconds(60000, "Waiting 60 seconds to kill the current session.");
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

                // Print this Test's log (from "TestContext") to the system console
                string log = TestContext.Get("log").ToString();
                if (log.Length > 0)
                {
                    Console.WriteLine(log);
                }
            }
        }
    }
}
