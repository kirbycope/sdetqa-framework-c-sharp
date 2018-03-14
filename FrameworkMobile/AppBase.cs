using FrameworkCommon;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using Assert = FrameworkCommon.Assert;
using TestContext = FrameworkCommon.TestContext;

namespace FrameworkMobile
{
    public class AppBase
    {
        #region App Properties

        /// <summary>
        /// Defines the interface through which the user controls the application.
        /// </summary>
        public static AppiumDriver<AppiumWebElement> driver
        {
            get
            {
                return (AppiumDriver<AppiumWebElement>)TestContext.Get("driver");
            }
        }

        #endregion App Properties

        #region OpenQA.Selenium.Appium.AppiumDriver Replacement Methods

        /// <summary>
        /// Closes the current app.
        /// </summary>
        public static void CloseApp()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.CloseApp()");
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Close the current app
                driver.CloseApp();
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
        /// Finds an element using the given By expression.
        /// </summary>
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
            return returnValue;
        }

        /// <summary>
        /// Finds all elements using the given By expression.
        /// </summary>
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
            return returnValue;
        }

        /// <summary>
        /// Gets a OpenQA.Selenium.Screenshot object representing the image of the page on the screen.
        /// </summary>
        public static Screenshot GetScreenshot()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Declare an empty object to hold the return value
            Screenshot screenshot = null;
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.GetScreenshot()");
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Perform the action
                screenshot = driver.GetScreenshot();
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
            return screenshot;
        }

        /// <summary>
        /// Hides keyboard if present.
        /// </summary>
        public static void HideKeyboard()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.HideKeyboard()");
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Hide the Keyboard
                driver.HideKeyboard();
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
        /// Launches the current app.
        /// </summary>
        public static void LaunchApp()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.LaunchApp()");
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Launch the current app
                driver.LaunchApp();
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
        /// Resets the current app.
        /// </summary>
        public static void ResetApp()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.ResetApp()");
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Reset the current app
                driver.ResetApp();
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
        /// Performs a swipe gesture using the given coordinates.
        /// </summary>
        /// <param name="startX">The starting X coordinate.</param>
        /// <param name="startY">The starting Y coordinate.</param>
        /// <param name="endX">The ending X coordinate.</param>
        /// <param name="endY">The ending Y coordinate.</param>
        /// <param name="duration">The time (in miliseconds) to take performing the action.</param>
        /// <param name="swipes">The number of times to perform the action.</param>
        public static void Swipe(int startX, int startY, int endX, int endY, int duration = 1000, int swipes = 1)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.Swipe(startX, startY, endX, endY, duration?, swipes?)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] startX: " + startX);
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] startY: " + startY);
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] endX: " + endX);
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] endY: " + endY);
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Duration: " + duration);
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Swipes: " + swipes);
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                for (int i = 0; i < swipes; i++)
                {
                    // Swipe using the given values
                    driver.Swipe(startX, startY, endX, endY, duration);
                    // Wait a moment
                    System.Threading.Thread.Sleep(500);
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
        }

        /// <summary>
        /// Taps the screen at the given coordinates.
        /// </summary>
        public static void Tap(int x, int y, int duration = 250)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.Tap(x, y)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] X: " + x);
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Y: " + y);
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Tap the given coordinates with one finger for 250ms
                driver.Tap(1, x, y, duration);
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

        #endregion OpenQA.Selenium.Appium.AppiumDriver Replacement Methods

        #region Custom App Methods

        /// <summary>
        /// Performs a swipe from startX, startY to endX, endY.
        /// </summary>
        /// <param name="startX">The starting X coordinate.</param>
        /// <param name="startY">The starting Y coordinate.</param>
        /// <param name="endX">The ending X coordinate.</param>
        /// <param name="endY">The ending Y coordinate.</param>
        /// <param name="duration">The time (in miliseconds) to take performing the action.</param>
        public static void DragCoordinates(int startX, int startY, int endX, int endY, int duration = 500)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.DragCoordinates(startX, startY, endX, endY, duration?)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] startX: " + startX);
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] startY: " + startY);
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] endX: " + endX);
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] endY: " + endY);
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Duration: " + duration);
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Perform the action
                driver.Swipe(startX, startY, endX, endY, duration);
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
        /// Scrolls the given element to the top of the window.
        /// </summary>
        /// <param name="webElement">The WebElement (element) to scroll.</param>
        /// <param name="duration">The time (in miliseconds) to take performing the action.</param>
        public static void ScrollElementToTop(WebElement webElement)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.ScrollElementToTop(webElement)");
            if (webElement.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] WebElement's Description: " + webElement.description); }
            if (webElement.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] WebElement's FindsBy: " + webElement.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Get the window's size
                Size windowSize = driver.Manage().Window.Size;
                // Find the center X coordinate of the window
                int windowCenterX = windowSize.Width / 2;
                // Find the center Y coordinate of the window
                int windowCenterY = windowSize.Height / 2;
                // Get the start time
                DateTime startTime = DateTime.Now;
                // While the WebElement is not displayed...
                while (webElement.Displayed == false)
                {
                    // Check for timeout
                    if (DateTime.Now > startTime.AddSeconds(TestBase.defaultTimeoutInSeconds))
                    {
                        sb.AppendLine(logPadding.InfoPadding + "[Error] Timed out");
                        Assert.Fail(sb.ToString());
                    }
                    else
                    {
                        // Swipe up a little
                        Swipe(windowCenterX, windowCenterY, windowCenterX, (windowCenterY - 200), 250, 1);
                    }
                }
                // Get the current location of the WebElement
                Point location = webElement.Location;
                // Account for the height of a stick header
                int stickyHeaderHeight = 550;
                // Calculate duration using the number of pixels to move
                int duration = (location.Y - stickyHeaderHeight);
                // Swipe the WebElement (near to) the top, moving 1px/ms
                Swipe(location.X, location.Y, location.X, stickyHeaderHeight, duration);
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
        /// Scroll until an element that matches the toMarked is shown on the screen.
        /// </summary>
        public static void ScrollTo(WebElement webElement)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.ScrollTo(webElement)");
            if (webElement.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] WebElement's Description: " + webElement.description); }
            if (webElement.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] WebElement's FindsBy: " + webElement.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Record the start time
                DateTime startTime = DateTime.Now;
                // While the element is not displayed and the time-out has not been reached
                while ((webElement.Displayed == false) && (startTime.AddSeconds(TestBase.defaultTimeoutInSeconds) > DateTime.Now))
                {
                    SwipeMiddleToTop();
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
        }

        /// <summary>
        /// Scrolls to the first element containing the given text.
        /// </summary>
        public static void ScrollTo(string text)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.ScrollTo(text)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Text: " + text);
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Find the element with the matching Text
                AppiumWebElement element = FindElement(By.XPath("//*[text()[contains(.,'" + text + "')]]")).element;
                // Scroll the element to the top of the view
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
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
        /// Changes the device (iOS) or current activity (Android) orientation to landscape mode.
        /// </summary>
        public static void SetOrientationLandscape()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.SetOrientationLandscape()");
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Set the screen orientation to Landscape
                driver.Orientation = ScreenOrientation.Landscape;
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
        /// Changes the device (iOS) or current activity (Android) orientation to portrait mode.
        /// </summary>
        public static void SetOrientationPortrait()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.SetOrientationPortrait()");
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Set the screen orientation to Portrait
                driver.Orientation = ScreenOrientation.Portrait;
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
        /// Performs a left to right swipe gesture.
        /// </summary>
        /// <param name="swipes">The number of times to perform the action.</param>
        public static void SwipeLeftToRight(int swipes = 1)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.SwipeLeftToRight(swipes?)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Swipes: " + swipes);
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                for (int i = 0; i < swipes; i++)
                {
                    // Get the window's size
                    Size windowSize = driver.Manage().Window.Size;
                    // Find the center Y coordinate of the window
                    int windowCenterY = windowSize.Height / 2;
                    // Swipe from the left to the right at the middle of the window
                    driver.Swipe(1, windowCenterY, windowSize.Width, windowCenterY, 1000);
                    // Wait a moment
                    System.Threading.Thread.Sleep(500);
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
        }

        /// <summary>
        /// Performs a left to right swipe gesture using the given element's Y coordinate.
        /// </summary>
        /// <param name="webElement"></param>
        public static void SwipeLeftToRight(WebElement webElement, int swipes = 1)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.SwipeLeftToRight(webElement, swipes?)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Swipes: " + swipes);
            if (webElement.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] WebElement's Description: " + webElement.description); }
            if (webElement.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] WebElement's FindsBy: " + webElement.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                for (int i = 0; i < swipes; i++)
                {
                    // startX = The left most edge of the screen
                    int startX = 1;
                    // startY = The center Y coordinate of the given element
                    int startY = webElement.Location.Y + (webElement.Size.Height / 2);
                    // endX = The right most edge of the screen
                    int endX = driver.Manage().Window.Size.Width;
                    // endY = The center Y coordinate of the given element
                    int endY = startY;
                    // Swipe from the left to the right at the middle of the given element
                    driver.Swipe(startX, startY, endX, endY, 1000);
                    // Wait a moment
                    System.Threading.Thread.Sleep(500);
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
        }

        /// <summary>
        /// Scrolls up by performing a swipe gesture from the middle of the screen to the bottom
        /// </summary>
        public static void SwipeMiddleToBottom(int swipes = 1)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.SwipeMiddleToBottom(swipes?)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Swipes: " + swipes);
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                for (int i = 0; i < swipes; i++)
                {
                    System.Threading.Thread.Sleep(1000);
                    // Get the window's size
                    Size windowSize = driver.Manage().Window.Size;
                    // Find the center X coordinate of the window
                    int windowCenterX = windowSize.Width / 2;
                    // Find the center Y coordinate of the window
                    int windowCenterY = windowSize.Height / 2;
                    // Find the bottom Y coordinate of the window
                    int windowBottomY = windowSize.Height - 100;
                    // Swipe from the middle to the bottom of the window
                    driver.Swipe(windowCenterX, windowCenterY, 0, windowBottomY, 1000);
                    // Wait a moment
                    System.Threading.Thread.Sleep(500);
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
        }

        /// <summary>
        /// Scrolls down by performing a swipe gesture from the middle of the screen to the top
        /// </summary>
        public static void SwipeMiddleToTop(int swipes = 1)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.SwipeMiddleToTop(swipes?)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Swipes: " + swipes);
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                for (int i = 0; i < swipes; i++)
                {
                    System.Threading.Thread.Sleep(1000);
                    // Get the window's size
                    Size windowSize = driver.Manage().Window.Size;
                    // Find the center X coordinate of the window
                    int windowCenterX = windowSize.Width / 2;
                    // Find the center Y coordinate of the window
                    int windowCenterY = windowSize.Height / 2;
                    // Swipe from the middle to the top of the window
                    driver.Swipe(windowCenterX, windowCenterY, windowCenterX, 1, 1000);
                    // Wait a moment
                    System.Threading.Thread.Sleep(500);
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
        }

        /// <summary>
        /// Performs a left to right swipe gesture.
        /// </summary>
        public static void SwipeRightToLeft(int swipes = 1)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.SwipeRightToLeft(swipes?)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Swipes: " + swipes);
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                for (int i = 0; i < swipes; i++)
                {
                    // Get the window's size
                    Size windowSize = driver.Manage().Window.Size;
                    // Find the center Y coordinate of the window
                    int windowCenterY = windowSize.Height / 2;
                    // Swipe from the right to the left at the middle of the window
                    driver.Swipe(windowSize.Width - 10, windowCenterY, 10, windowCenterY, 1000);
                    // Wait a moment
                    System.Threading.Thread.Sleep(500);
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
        }

        /// <summary>
        /// Performs a right to left swipe gesture using the given element's Y coordinate.
        /// </summary>
        public static void SwipeRightToLeft(WebElement webElement, int swipes = 1)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.SwipeRightToLeft(webElement, swipes?)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Swipes: " + swipes);
            if (webElement.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] WebElement's Description: " + webElement.description); }
            if (webElement.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] WebElement's FindsBy: " + webElement.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                for (int i = 0; i < swipes; i++)
                {
                    // startX = The right most edge of the screen
                    int startX = driver.Manage().Window.Size.Width;
                    // startY = The center Y coordinate of the given element
                    int startY = webElement.Location.Y + (webElement.Size.Height / 2);
                    // endX = The left most edge of the screen
                    int endX = 1;
                    // endY = The center of the given element
                    int endY = startY;
                    // Swipe from the right to the left at Y-coordinate of the given element
                    driver.Swipe(startX - 10, startY, endX + 10, endY, 1000);
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
        }

        /// <summary>
        /// Get the center coordinates of the current view
        /// </summary>
        public static void TapCenterOfScreen()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.TapCenterOfScreen()");
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Get the window's size
                Size windowSize = driver.Manage().Window.Size;
                // Find the center X coordinate of the window
                int windowCenterX = windowSize.Width / 2;
                // Find the center Y coordinate of the window
                int windowCenterY = windowSize.Height / 2;
                Tap(windowCenterX, windowCenterY);
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
        /// Waits for the given element to be displayed.
        /// </summary>
        /// /// <param name="by">The mechanism to locate the element.</param>
        /// <param name="timeOutInSeconds">(Optional) The seconds to wait for the condition.</param>
        public static void WaitForElementToBeDisplayed(By by, int timeOutInSeconds = TestBase.defaultTimeoutInSeconds)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.WaitForElementToBeDisplayed(by, timeout?)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] By: " + by);
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Timeout (In Seconds): " + timeOutInSeconds);
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Perform the action
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until<Func<IWebDriver, IWebElement>>(
                    d => {
                        return (driver) =>
                        {
                            try
                            {
                                return ElementIfVisible(driver.FindElement(by));
                            }
                            catch (StaleElementReferenceException)
                            {
                                return null;
                            }
                        };
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

        /// <summary>
        /// Waits for the given element to be displayed.
        /// </summary>
        /// <param name="appiumWebElement">The element to target.</param>
        /// <param name="timeOutInSeconds">(Optional) The seconds to wait for the condition.</param>
        public static void WaitForElementToBeDisplayed(AppiumWebElement appiumWebElement, int timeOutInSeconds = TestBase.defaultTimeoutInSeconds)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.WaitForElementToBeDisplayed(appiumWebElement, timeout?)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Timeout (In Seconds): " + timeOutInSeconds);
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Max Iterations = The time in miliseconds divided by the sleep time (in the loop below)
                int maxIterations = (timeOutInSeconds * 1000) / 250;
                for (int i = 0; i < maxIterations; i++)
                {
                    try
                    {
                        bool displayed = appiumWebElement.Displayed;
                        if (displayed)
                        {
                            break;
                        }
                    }
                    catch
                    {
                        /* do nothing */
                    }
                    if (i == (maxIterations - 1))
                    {
                        sb.AppendLine(logPadding.InfoPadding + "[Error] Timed out");
                        Assert.Fail(sb.ToString());
                    }
                    System.Threading.Thread.Sleep(250);
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
        }

        /// <summary>
        /// Waits for the given element to be not displayed.
        /// </summary>
        /// <param name="by">The mechanism to locate the element.</param>
        /// <param name="timeOutInSeconds">(Optional) The seconds to wait for the condition.</param>
        public static void WaitForElementToBeNotDisplayed(By by, int timeOutInSeconds = TestBase.defaultTimeoutInSeconds)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.WaitForElementToBeDisplayed(by, timeout?)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] By: " + by);
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Timeout (In Seconds): " + timeOutInSeconds);
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Perform the wait
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until<Func<IWebDriver, bool>>(
                    d => {
                        return (driver) =>
                        {
                            try
                            {
                                var element = driver.FindElement(by);
                                return !element.Displayed;
                            }
                            catch (NoSuchElementException)
                            {
                                // Returns true because the element is not present in DOM. The
                                // try block checks if the element is present but is invisible.
                                return true;
                            }
                            catch (StaleElementReferenceException)
                            {
                                // Returns true because stale element reference implies that element
                                // is no longer visible.
                                return true;
                            }
                        };
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

        /// <summary>
        /// Waits for the given element to be not displayed.
        /// </summary>
        /// <param name="appiumWebElement">The element to target.</param>
        /// <param name="timeOutInSeconds">(Optional) The seconds to wait for the condition.</param>
        public static void WaitForElementToBeNotDisplayed(AppiumWebElement appiumWebElement, int timeOutInSeconds = TestBase.defaultTimeoutInSeconds)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.WaitForElementToBeDisplayed(appiumWebElement, timeout?)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Timeout (In Seconds): " + timeOutInSeconds);
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Max Iterations = The time in miliseconds divided by the sleep time (in the loop below)
                int maxIterations = (timeOutInSeconds * 1000) / 250;
                for (int i = 0; i < maxIterations; i++)
                {
                    try
                    {
                        bool displayed = appiumWebElement.Displayed;
                        if (displayed == false)
                        {
                            break;
                        }
                    }
                    catch
                    {
                        /* do nothing */
                    }
                    if (i == (maxIterations - 1))
                    {
                        sb.AppendLine(logPadding.InfoPadding + "[Error] Timed out");
                        Assert.Fail(sb.ToString());
                    }
                    System.Threading.Thread.Sleep(250);
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
        }

        #endregion Custom App Methods

        // https://github.com/DotNetSeleniumTools/DotNetSeleniumExtras/blob/master/src/WaitHelpers/ExpectedConditions.cs
        private static IWebElement ElementIfVisible(IWebElement element)
        {
            return element.Displayed ? element : null;
        }
    }
}
