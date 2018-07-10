using FrameworkCommon;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Specialized;
using System.Configuration;
using Assert = FrameworkCommon.Assert;

namespace FrameworkMobile
{
    public class Session
    {
        public static AppiumDriver<AppiumWebElement> driver;

        /// <summary>
        /// Intantiates a WebDriver (creating a session) using the current App.config.
        /// </summary>
        public static AppiumDriver<AppiumWebElement> Create()
        {
            #region Properties  (from the App.config)

            // Get settings from the App.config
            string app = ConfigurationManager.AppSettings["app"];
            string appConfig = ConfigurationManager.AppSettings["appConfig"] ?? "App.config";
            string automationName = ConfigurationManager.AppSettings["automationName"];
            string deviceName = ConfigurationManager.AppSettings["deviceName"] ?? "n/a";
            Uri hubUri = new Uri(ConfigurationManager.AppSettings["hubUri"]);
            string platformName = ConfigurationManager.AppSettings["platformName"];

            #endregion Properties  (from the App.config)

            // Declare a return value
            AppiumDriver<AppiumWebElement> returnValue = null;

            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "Automation Name", automationName },
                { "Platform Name", platformName },
                { "Device Name", automationName },
                { "App", app}
            });

            // Perform the action
            try
            {
                // Define the common "Desired Capabilities"
                DesiredCapabilities capabilities = new DesiredCapabilities();
                if (automationName.Length > 0) { capabilities.SetCapability("automationName", automationName); }
                if (platformName.Length > 0) { capabilities.SetCapability("platformName", platformName); }
                if (deviceName.Length > 0) { capabilities.SetCapability("deviceName", deviceName); }
                if (app.Length > 0) { capabilities.SetCapability("app", app); }
                capabilities.SetCapability("noReset", true);
                // Initialize the driver
                if (platformName == "Andorid")
                {
                    returnValue = new AndroidDriver<AppiumWebElement>(hubUri, capabilities, TimeSpan.FromMinutes(TestBase.sessionTimeoutInMinutes));
                }
                else if (platformName == "iOS")
                {
                    returnValue = new IOSDriver<AppiumWebElement>(hubUri, capabilities, TimeSpan.FromMinutes(TestBase.sessionTimeoutInMinutes));
                }
                else
                {
                    throw new NotImplementedException("Platform '" + platformName + "' not setup in Session.Create();");
                }
                // Set the global driver variable
                driver = returnValue;
                // Logging - After action success
                Log.Success("Created a new session.");
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
            // Return the return value
            return returnValue;
        }
    }
}
