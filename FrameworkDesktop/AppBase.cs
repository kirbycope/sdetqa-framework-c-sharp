using FrameworkCommon;
using FrameworkCommon.Toolbox;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace FrameworkDesktop
{
    public class AppBase
    {
        #region App Properties

        /// <summary>
        /// Defines the interface through which the user controls the application.
        /// </summary>
        protected static IWebDriver driver
        {
            get
            {
                return (IWebDriver)TestContext.Get("driver");
            }
        }

        #endregion App Properties

        #region OpenQA.Selenium.IJavaScriptExecutor Replacement Methods

        /// <summary>
        /// Executes JavaScript asynchronously in the context of the currently selected frame or window.
        /// </summary>
        /// <param name="script">The JavaScript code to execute.</param>
        /// <param name="seleniumWebElement">(Optional) The arguments to the script.</param>
        /// <returns></returns>
        public static object ExecuteAsyncScript(string script, IWebElement seleniumWebElement = null)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Declare an empty object to hold the return value
            object returnValue = null;
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.ExecuteAsyncScript(script, seleniumWebElement?)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Script: " + script);
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                if (seleniumWebElement != null)
                {
                    // Execute the script, using the given IWebElement as a parameter
                    returnValue = ((IJavaScriptExecutor)driver).ExecuteAsyncScript(script, seleniumWebElement);
                }
                else
                {
                    // Execute the script
                    returnValue = ((IJavaScriptExecutor)driver).ExecuteAsyncScript(script);
                }
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
            // Return the return value
            return returnValue;
        }

        /// <summary>
        /// Executes JavaScript in the context of the currently selected frame or window.
        /// </summary>
        /// <param name="script">The JavaScript code to execute.</param>
        /// <param name="seleniumWebElement">(Optional) The arguments to the script.</param>
        /// <returns></returns>
        public static object ExecuteScript(string script, IWebElement seleniumWebElement = null)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Declare an empty object to hold the return value
            object returnValue = null;
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.ExecuteScript(script, seleniumWebElement?)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Script: " + script);
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                if (seleniumWebElement != null)
                {
                    // Execute the script, using the given SeleniumWebElement as a parameter
                    returnValue = ((IJavaScriptExecutor)driver).ExecuteScript(script, seleniumWebElement);
                }
                else
                {
                    // Execute the script
                    returnValue = ((IJavaScriptExecutor)driver).ExecuteScript(script);
                }
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
            // Return the return value
            return returnValue;
        }

        #endregion OpenQA.Selenium.IJavaScriptExecutor Replacement Methods

        #region OpenQA.Selenium.ISearchContext Replacement Methods

        /// <summary>
        /// Finds the first OpenQA.Selenium.IWebElement using the given method.
        /// </summary>
        /// <param name="by">Provides a mechanism by which to find elements within a document.</param>
        /// <returns>An initialized WebElement object.</returns>
        public static WebElement FindElement(By by)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Declare an empty object to hold the return value
            WebElement returnValue = null;
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.FindElement(by)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Element To Find Finds By: " + by);
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Find the first element using the given By
                returnValue = new WebElement
                (
                    by,
                    driver.FindElement(by)
                );
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
            // Return the return value
            return returnValue;
        }

        /// <summary>
        /// Finds all OpenQA.Selenium.IWebElement within the current context using the given mechanism.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>A List of initialized WebElement objects.</returns>
        public static IList<WebElement> FindElements(By by)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Declare an empty object to hold the return value
            IList<WebElement> returnValue = new List<WebElement>();
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.FindElements(by)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Element(s) To Find Finds By: " + by);
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Find the element(s) using the given By
                var elements = driver.FindElements(by);
                // Convert each IWebElement to a WebElement
                foreach (var element in elements)
                {
                    WebElement webElement = new WebElement
                    (
                        element,
                        ""
                    );
                    returnValue.Add(webElement);
                }
                // Logging - After action success
                Log.Success(logPadding.Padding);
                Log.WriteLine(logPadding.InfoPadding + "[INFO] # of Elements Found: " + elements.Count);
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

        #endregion OpenQA.Selenium.ISearchContext Replacement Methods

        #region OpenQA.Selenium.IWebDriver Replacement Methods

        /// <summary>
        /// Close the current window, quitting the browser if it is the last window currently open.
        /// </summary>
        public static void Close()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.Close()");
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Close the current window, quitting the browser if it is the last window currently open
                driver.Close();
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

        #region Manage()

        /// <summary>
        /// Deletes all cookies from the page.
        /// </summary>
        public static void DeleteAllCookies()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.DeleteAllCookies()");
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Delete all cookies from the page
                driver.Manage().Cookies.DeleteAllCookies();
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

        /// <summary>
        /// Sets the current window to full screen if it is not already in that state.
        /// </summary>
        public static void FullScreen()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.FullScreen()");
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Set the current window to full screen if it is not already in that state
                driver.Manage().Window.FullScreen();
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

        /// <summary>
        /// Maximizes the current window if it is not already maximized.
        /// </summary>
        public static void Maximize()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.Maximize()");
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Maximize the current window if it is not already maximized
                driver.Manage().Window.Maximize();
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

        /// <summary>
        /// Minimizes the current window if it is not already maximized.
        /// </summary>
        public static void Minimize()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.Minimize()");
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Minimize the current window if it is not already maximized
                driver.Manage().Window.Minimize();
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

        #endregion Manage()

        #region Navigate()

        /// <summary>
        /// Move back a single entry in the browser's history.
        /// </summary>
        public static void Back()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.Back()");
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Navigate back
                driver.Navigate().Back();
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

        /// <summary>
        /// Move a single "item" forward in the browser's history.
        /// </summary>
        public static void Forward()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.Forward()");
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Move a single "item" forward in the browser's history
                driver.Navigate().Forward();
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

        /// <summary>
        /// Load a new web page in the current browser window.
        /// </summary>
        /// <param name="url">The URL to load. It is best to use a fully qualified URL.</param>
        /// <param name="useBaseUrl">(Optional, Default = true) Prepend the URL with the Base URL.</param>
        public static void GoToUrl(string url, bool useBaseUrl = true)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.GoToUrl(url, useBaseUrl?)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Given URL: " + url);
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Use Base URL: " + useBaseUrl);
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Get the base URL from the test's Context
                string baseUrl = (string)TestContext.Get("baseUrl");
                if ( (useBaseUrl == true) && (baseUrl.Length > 0) )
                {
                    // If the given URL does not start with a "/"
                    if (url.StartsWith("/") == false)
                    {
                        // Prepand the URL with a "/"
                        url = "/" + url;
                    }
                    // Logging - Before action
                    sb.AppendLine(logPadding.InfoPadding + "[INFO] Base URL: " + baseUrl);
                    // If the base URL ends with a "/"
                    if (baseUrl.EndsWith("/") == true)
                    {
                        // Remove the trailing "/"
                        baseUrl = baseUrl.Substring(0, (baseUrl.Length - 1));
                    }
                    // Concatenate the base URL and the given URL
                    url = baseUrl + url;
                }
                // Logging - Before action
                Log.WriteLine(logPadding.InfoPadding + "[INFO] URL to Use: " + url);
                // Navigate to the URL
                driver.Navigate().GoToUrl(url);
                // Logging - After action success
                Log.Success(logPadding.Padding);
                Log.WriteLine(logPadding.InfoPadding + "[INFO] Current URL: " + driver.Url);
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

        /// <summary>
        /// Load a new web page in the current browser window.
        /// </summary>
        /// <param name="uri">The URI to load.</param>
        public static void GoToUrl(Uri uri)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.NavigateTo(uri)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] URI: " + uri);
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Load a new web page in the current browser window
                driver.Navigate().GoToUrl(uri);
                // Logging - After action success
                Log.Success(logPadding.Padding);
                Log.WriteLine(logPadding.InfoPadding + "[INFO] Current URL: " + driver.Url);
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

        /// <summary>
        /// Refreshes the current page.
        /// </summary>
        public static void Refresh()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.Refresh()");
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Refresh the current page
                driver.Navigate().Refresh();
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

        #endregion Navigate()

        /// <summary>
        /// Quits this driver, closing every associated window.
        /// </summary>
        public static void Quit()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.Quit()");
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Close the driver
                driver.Quit();
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

        #endregion OpenQA.Selenium.IWebDriver Replacement Methods

        #region Custom App Methods

        /// Injects a link on the current page and then clicks on that link (which opens a new tab).
        /// </summary>
        public static void OpenUrlInNewTab(string url)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.OpenUrlInNewTab(url)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] URL: " + url);
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Inject the link
                string script = "var d=document,a=d.createElement('a');a.target='_blank';a.href='" + url + "';a.innerHTML='.';d.body.appendChild(a);return a;";
                IWebElement returnedElement = (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript(script);
                // Save the reference to the injected element
                WebElement element = new WebElement(returnedElement);
                // Click the link
                element.ClickViaJavaScript();
                // Switch to the new tab
                driver.SwitchTo().Window(driver.WindowHandles.Last());
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

        /// <summary>
        /// Scrolls down the given number of pixels using JavaScript.
        /// </summary>
        /// <param name="pixels">(Optional) The number of pixels to scroll.</param>
        public static void ScrollDown(int pixels = 250)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.ScrollDown(pixels?)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Pixels To Scroll: " + pixels);
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Scroll to the end of the page
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0," + pixels + ")");
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

        /// <summary>
        /// Scrolls to the given element.
        /// </summary>
        public static void ScrollElementToTop(WebElement webElement)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.ScrollToElement()");
            if (webElement.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] WebElement's Description: " + webElement.description); }
            if (webElement.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] WebElement's FindsBy: " + webElement.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Scroll the element into view (true = alignToTop)
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", webElement.element);
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

        /// <summary>
        /// Scrolls to the bottom of the page.
        /// </summary>
        public static void ScrollToBottomOfPage()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.ScrollToBottomOfPage()");
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Scroll to the end of the page
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0,document.body.scrollHeight);");
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

        /// <summary>
        /// Scrolls to the top of the page.
        /// </summary>
        public static void ScrollToTopOfPage()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.ScrollToTopOfPage()");
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Scroll to the top of the page
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0,0);");
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

        /// <summary>
        /// Scrolls up the given number of pixels using JavaScript.
        /// </summary>
        /// <param name="pixels">(Optional) The number of pixels to scroll.</param>
        public static void ScrollUp(int pixels = 250)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.ScrollUp()");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Pixels To Scroll: " + pixels);
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Scroll to the end of the page
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0,-250)");
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

        /// <summary>
        /// Sends a sequence of keystrokes to the browser.
        /// </summary>
        /// <param name="keysToSend">The keystrokes to send to the browser.</param>
        public static void SendKeys(string keysToSend)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.SendKeys(keysToSend)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Keys To Send: " + keysToSend);
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Send the keys
                Actions action = new Actions(driver);
                action.SendKeys(keysToSend).Build().Perform();
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

        /// <summary>
        /// Takes a screenshot of the given WebDriver's current page.
        /// </summary>
        /// <returns>The string of the file path for the screenshot taken.</returns>
        public static string TakeScreenshot()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Declare an empty object to hold the return value
            string returnValue = null;
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.TakeScreenshot()");
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Get the screenshot folder, set in TestBase.Setup() using App.config value
                string screenshotFolder = TestContext.Get("screenshotFolder").ToString();
                // Create directory (if it does not exist)
                string date = DateUtils.GetCurrentDate();
                string directory = screenshotFolder + date;
                if (screenshotFolder.Contains("/"))
                {
                    directory = directory + "/";
                }
                else
                {
                    directory = directory + "\\";
                }
                // Create a sub-directory using today's date
                Directory.CreateDirectory(directory);
                // Build a file name (*NOTE: The folder must already exist and allow writes to it)
                string time = DateUtils.GetCurrentTime();
                returnValue = directory + time + ".jpg";
                // Take a screenshot
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(returnValue, ScreenshotImageFormat.Jpeg);
                // Logging - After action success
                Log.Success(logPadding.Padding);
                Log.WriteLine(logPadding.InfoPadding + "[INFO] File Name: " + returnValue);
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
            // Return the filename of the screenshot
            return returnValue;
        }

        /// <summary>
        /// [JS] Waits (until the timeout) for the JS string to return true.
        /// </summary>
        /// <param name="script">The script to run.</param>
        public static void WaitForJavaScriptToReturnTrue(string script)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.WaitForJavaScriptToReturnTrue(script)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Script: " + script);
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Determine the maximum number of iterations (used for timeout)
                int timeoutIndexMax = (TestBase.defaultTimeoutInSeconds * 1000) / 250;
                // Iterate until true or timeout
                for (int i = 0; i < timeoutIndexMax; i++)
                {
                    // Run the script and store the result
                    bool result = (bool)((IJavaScriptExecutor)driver).ExecuteScript(script);
                    // Handle the script's result
                    if (result)
                    {
                        // Write result to log
                        Log.Success(logPadding.Padding);
                        break;
                    }
                    else
                    {
                        // Handle "timeout"
                        if (i == (timeoutIndexMax - 1))
                        {
                            sb.AppendLine(logPadding.InfoPadding + "[ERROR] Timed out waiting for script to return true.");
                            Log.WriteLine(sb.ToString());
                            Assert.Fail(sb.ToString());
                        }
                        else
                        {
                            // Sleep for 250ms
                            System.Threading.Thread.Sleep(250);
                        }
                    }
                }
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

        /// <summary>
        /// Waits (until the timeout) for the current URL to contain the given string.
        /// </summary>
        /// <param name="driver">The IWebDriver under test</param>
        /// <param name="text">The string to look for</param>
        public static void WaitForUrlToContain(string text)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.WaitForUrlToContain(text)");
            sb.AppendLine(logPadding.InfoPadding + "[INFO] Text to look for: " + text);
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Setup the wait
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TestBase.defaultTimeoutInSeconds));
                // Wait until condition is met
                wait.Until<Func<IWebDriver, bool>>(
                    d => {
                        return (driver) => { return driver.Url.ToLowerInvariant().Contains(text.ToLowerInvariant()); };
                    }
                );
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

        #endregion Custom App Methods
    }
}
