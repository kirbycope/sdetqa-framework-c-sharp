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

        /// <summary>
        /// Create a TestBase for your specific project (see TestBaseStarAppIos, for example) and call this method.
        /// The Setup annotation was removed to prevent it being called when there is a project specific Setup (see above).
        /// </summary>
        public static void Setup()
        {
            // Log Before Action
            Log.BeforeAction();

            // Perform the action
            try
            {
                // Create a variable to serve as a flag for if a new session needs to be created or not
                bool createNewSession = false;
                // Create a variable to hold the Test's WebDriver
                AppiumDriver<AppiumWebElement> driver = null;
                // Is the global WebDriver varaiable set?
                if (Session.driver != null)
                {
                    // Create a variable to hold the Session Info
                    Dictionary<string, object> sessionInfo = null;
                    // Try to get the Session Info (which only works if there is a valid session) from the global variable
                    // Note: We need to use the same Appium session (driver) for all test or we could lose the device in the cloud.
                    try { sessionInfo = Session.driver.SessionDetails; }
                    catch { /* do nothing */ }
                    // Check the Session Info variable has some content
                    if (sessionInfo != null)
                    {
                        // Use the existing session
                        Log.WriteLine("    [INFO] Using the existing session.");
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
                    // Wait 60 seconds to timeout any existing sessions (in SauceLab's TestObject)
                    if (ConfigurationManager.AppSettings["appConfig"].ToString().Contains("SauceLabs"))
                    {
                        Sleep.Milliseconds(60000, "Waiting 60 seconds to kill the current session (in SauceLab's TestObject).");
                    }
                    // Create a new session
                    Log.WriteLine("    [INFO] Creating a new session.");
                    driver = Session.Create();
                }
                // Save a reference to the current Test's driver (session) in its TestContext
                TestContext.Set("driver", driver);

                // Reset the app
                AppBase.ResetApp();

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
        public static void TearDown()
        {
            // Print log to console (from TestContext)
            string log = TestContext.Get("log").ToString();
            if (log.Length > 0)
            {
                Console.WriteLine(log);
            }
        }
    }
}
