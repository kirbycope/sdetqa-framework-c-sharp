using FrameworkCommon;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Specialized;
using System.Configuration;

namespace FrameworkDesktop
{
    public class Session
    {
        /// <summary>
        /// Intantiates a WebDriver (creating a session) using the current App.config.
        /// </summary>
        public static IWebDriver Create()
        {
            #region Properties

            // Define the current App.config (from the App.config)
            string appConfig = ConfigurationManager.AppSettings["appConfig"];
            // Declare a string for the Base URL
            string baseUrl = ConfigurationManager.AppSettings["baseUrl"];
            // Define the Browser (from the App.config)
            string browser = ConfigurationManager.AppSettings["browser"];
            // Define the Grid Hub URI (from the App.config)
            Uri hubUri = new Uri(ConfigurationManager.AppSettings["hubUri"]);
            // Define the Screenshot folder (from the App.config)
            string screenshotFolder = ConfigurationManager.AppSettings["screenshotFolder"];

            #endregion Properties

            // Declare a return value
            IWebDriver returnValue = null;

            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "App Config", appConfig },
                { "Base URL", baseUrl },
                { "Browser", browser },
                { "Hub URI", hubUri },
                { "Screenshot Folder", screenshotFolder }
            });

            // Perform the action
            try
            {
                // Set WebDriver based on "brower" value in the current App.config
                if (browser.Equals("ie"))
                {
                    // Create an options object to specify command line arguments for the IE web driver
                    InternetExplorerOptions options = new InternetExplorerOptions();
                    // Start with a clean session(clears the cache)
                    options.EnsureCleanSession = true;
                    // Use Remote IE
                    try
                    {
                        // Create a remote session using the Grid Hub URI (from the App.config)
                        returnValue = new RemoteWebDriver(hubUri, options);
                    }
                    // Use local IE
                    catch
                    {
                        // Write result to log
                        Log.WriteLine("    [WARNING] Unable to create a remote session, so creating a local one.");
                        // Create a local session
                        returnValue = new InternetExplorerDriver(options);
                    }
                }
                else if (browser.Equals("chrome"))
                {
                    // Create an options object to specify command line arguments for the Chrome web driver
                    ChromeOptions options = new ChromeOptions();
                    // Disable extensions so the stupid popup goes away
                    options.AddArgument(@"--disable-extensions");
                    // Use Remote Chrome
                    try
                    {
                        // Create a remote session using the Grid Hub URI (from the App.config)
                        returnValue = new RemoteWebDriver(hubUri, options);
                    }
                    // Use Local Chrome
                    catch
                    {
                        // Write result to log
                        Log.WriteLine("    [WARNING] Unable to create a remote session, so creating a local one.");
                        // Create a local session
                        returnValue = new ChromeDriver(options);
                    }
                }
                else if (browser.Equals("edge"))
                {
                    // Create an options object to specify command line arguments for the Edge web driver
                    EdgeOptions options = new EdgeOptions();
                    // Use Remote Edge
                    try
                    {
                        // Create a remote session using the Grid Hub URI (from the App.config)
                        returnValue = new RemoteWebDriver(hubUri, options);
                    }
                    // Use Local Edge
                    catch
                    {
                        // Write result to log
                        Log.WriteLine("    [WARNING] Unable to create a remote session, so creating a local one.");
                        // Create a local session
                        returnValue = new EdgeDriver(options);
                    }
                }
                else if (browser.Equals("firefox"))
                {
                    // Create an options object to specify command line arguments for the Firefox web driver
                    FirefoxOptions options = new FirefoxOptions();
                    // Use Remote Firefox
                    try
                    {
                        // Create a remote session using the Grid Hub URI (from the App.config)
                        returnValue = new RemoteWebDriver(hubUri, options);
                    }
                    // Use Local Firefox
                    catch
                    {
                        // Write result to log
                        Log.WriteLine("    [WARNING] Unable to create a remote session, so creating a local one.");
                        try
                        {
                            // Create a local session
                            returnValue = new FirefoxDriver(options);
                        }
                        catch
                        {
                            // Write result to log
                            Log.WriteLine("    [WARNING] Unable to create a local session using the default location.");
                            // Load Firefox From Specific Location
                            options.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe";
                            Log.WriteLine("    [INFO] Browser Executable Location: " + options.BrowserExecutableLocation);
                            // Create a local session
                            returnValue = new FirefoxDriver(options);
                        }
                    }
                }
                else if (browser.Equals("safari"))
                {
                    // Create an options object to specify command line arguments for the Safari web driver
                    SafariOptions options = new SafariOptions();
                    // Create a remote session using the Grid Hub URI (from the App.config)
                    returnValue = new RemoteWebDriver(hubUri, options);
                }
                else
                {
                    throw new NotImplementedException(browser + " not handled in Session.Create() method.");
                }

                // Save a reference to the current Test's driver in its TestContext
                TestContext.Set("driver", returnValue);
                // Save a reference to the current Test's base url in its TestContext
                TestContext.Set("baseUrl", baseUrl);
                // Save a reference to the current Test's screenshot folder in its TestContext
                TestContext.Set("screenshotFolder", screenshotFolder);

                // Logging - After action
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
            // Return the return value
            return returnValue;
        }
    }
}
