using FrameworkCommon;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Remote;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Text;
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
            #region Properties

            // Get settings from the App.config
            string app = ConfigurationManager.AppSettings["app"];
            string appConfig = ConfigurationManager.AppSettings["appConfig"];
            string automationName = ConfigurationManager.AppSettings["automationName"];
            string deviceName = ConfigurationManager.AppSettings["deviceName"];
            Uri hubUri = new Uri(ConfigurationManager.AppSettings["hubUri"]);
            string platformName = ConfigurationManager.AppSettings["platformName"];

            #endregion Properties

            // Declare a return value
            AppiumDriver<AppiumWebElement> returnValue = null;
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "Session.Create()");
            sb.AppendLine(logPadding.InfoPadding + "[INFO] Automation Name: " + automationName);
            sb.AppendLine(logPadding.InfoPadding + "[INFO] Platform Name: " + platformName);
            sb.AppendLine(logPadding.InfoPadding + "[INFO] Device Name: " + deviceName);
            sb.AppendLine(logPadding.InfoPadding + "[INFO] App: " + app);
            Log.Write(sb.ToString());
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
                Log.Success(logPadding.Padding);
                Log.WriteLine(logPadding.InfoPadding + "[INFO] Created a new session.");
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
            // Return the return value
            return returnValue;
        }
    }
}
