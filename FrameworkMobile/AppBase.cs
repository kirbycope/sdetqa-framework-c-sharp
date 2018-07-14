using FrameworkCommon;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Drawing;
using System.Text;
using TestContext = FrameworkCommon.TestContext;

namespace FrameworkMobile
{
    public class AppBase
    {
        #region App Properties

        /// <summary>
        /// Defines the interface through which the user controls the application.
        /// </summary>
        public static AppiumDriver<AppiumWebElement> Driver
        {
            get
            {
                AppiumDriver<AppiumWebElement> d = null;
                try
                {
                    // Get the WebDriver/Session from the Test's TestContext
                    d = (AppiumDriver<AppiumWebElement>)TestContext.Get("driver");
                }
                catch
                {
                    // Get the WebDriver/Session from the global variable
                    d = Session.driver;
                }
                return d;
            }
        }

        #endregion App Properties

        #region OpenQA.Selenium.Appium.AppiumDriver Replacement Methods

        /// <summary>
        /// Closes the current app.
        /// </summary>
        public static void CloseApp()
        {
            // Log Before Action
            Log.BeforeAction();

            // Perform the action
            try
            {
                // Close the current app
                Driver.CloseApp();
                // Logging - After action success
                Log.Success();
            }
            catch (Exception e)
            {
                // Logging - After action exception
                Log.Failure(e.Message);
                // Fail current test
                //Assert.Fail(e.Message); // Do not fail a test if the only issue is cloing the app
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Finds an element using the given By expression.
        /// </summary>
        public static WebElement FindElement(By by)
        {
            // Declare an empty object to hold the return value
            WebElement returnValue = null;

            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "FindBy", by }
            });

            // Perform the action
            try
            {
                // Find the first element using the given By
                returnValue = new WebElement
                (
                    by,
                    Driver.FindElement(by)
                );
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
            return returnValue;
        }

        /// <summary>
        /// Finds all elements using the given By expression.
        /// </summary>
        public static IList<WebElement> FindElements(By by)
        {
            // Declare an empty object to hold the return value
            IList<WebElement> returnValue = new List<WebElement>();

            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "FindBy", by }
            });

            // Perform the action
            try
            {
                // Find the element(s) using the given By
                var elements = Driver.FindElements(by);
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
            return returnValue;
        }

        /// <summary>
        /// Gets a OpenQA.Selenium.Screenshot object representing the image of the page on the screen.
        /// </summary>
        public static Screenshot GetScreenshot()
        {
            // Declare an empty object to hold the return value
            Screenshot screenshot = null;

            // Log Before Action
            Log.BeforeAction();

            // Perform the action
            try
            {
                // Perform the action
                screenshot = Driver.GetScreenshot();
                // Logging - After action success
                Log.Success();
            }
            catch (Exception e)
            {
                // Logging - After action exception
                Log.Failure(e.Message);
                // Fail current test
                // Assert.Fail(e.Message); // Do not fail the test if the only issue is taking a screenshot
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
            return screenshot;
        }

        /// <summary>
        /// Hides keyboard if present.
        /// </summary>
        public static void HideKeyboard()
        {
            // Log Before Action
            Log.BeforeAction();

            // Perform the action
            try
            {
                // Hide the Keyboard
                Driver.HideKeyboard();
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

        /// <summary>
        /// Launches the current app.
        /// </summary>
        public static void LaunchApp()
        {
            // Log Before Action
            Log.BeforeAction();

            // Perform the action
            try
            {
                // Launch the current app
                Driver.LaunchApp();
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

        /// <summary>
        /// Resets the current app.
        /// </summary>
        public static void ResetApp()
        {
            // Log Before Action
            Log.BeforeAction();

            // Perform the action
            try
            {
                // Reset the current app
                Driver.ResetApp();
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

        /// <summary>
        /// Convenience method for swiping across the screen.
        /// </summary>
        /// <param name="startX">Starting X-coordinate.</param>
        /// <param name="startY">Starting Y-coordinate.</param>
        /// <param name="endX">Ending X-coordinate.</param>
        /// <param name="endY">Ending Y-coordinate.</param>
        /// <param name="duration">Amount of time in milliseconds for the entire swipe action to take.</param>
        /// <param name="swipes">The number of times to perform the swipe.</param>
        public static void Swipe(int startX, int startY, int endX, int endY, int duration = 2160, int swipes = 1)
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "Start X", startX },
                { "Start Y", startY },
                { "End X", endX },
                { "End Y", endY },
                { "Duration", duration },
                { "Swipes", swipes }
            });

            // Perform the action
            try
            {
                for (int i = 0; i < swipes; i++)
                {
                    // Swipe using the given parameter values
                    Driver.Swipe(startX, startY, endX, endY, duration);
                }
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

        /// <summary>
        /// Taps the screen at the given coordinates.
        /// </summary>
        public static void Tap(int x, int y, int duration = 250)
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "X", x },
                { "Y", y },
                { "Duration", duration }
            });

            // Perform the action
            try
            {
                // Tap the given coordinates with one finger for 250ms
                Driver.Tap(1, x, y, duration);
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

        #endregion OpenQA.Selenium.Appium.AppiumDriver Replacement Methods

        #region Custom App Methods

        /// <summary>
        /// Check that all given elements are present and have some dimensions greater than 0
        /// </summary>
        public static string CheckAllElementsArePresent(List<WebElement> elementList)
        {
            // Initialize the error counter
            int errorCount = 0;
            // Initialize the error string builder
            StringBuilder sb = new StringBuilder();
            // Loop over each element in the list
            foreach (WebElement element in elementList)
            {
                // Find the element(s)
                IList<WebElement> result = AppBase.FindElements(element.by);
                // Handle the result
                if (result.Count == 0)
                {
                    sb.AppendLine("[ERROR] Could not find element");
                    if (element.by != null) { sb.AppendLine("    [DEBUG] Element Description: " + element.description); }
                    if (element.by != null) { sb.AppendLine("    [DEBUG] Element Finds By: " + element.by); }
                    errorCount++;
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Scrolls the given element to the top of the window.
        /// </summary>
        /// <param name="webElement">The WebElement (element) to scroll.</param>
        /// <param name="duration">The time (in miliseconds) to take performing the action.</param>
        public static void ScrollElementToTop(WebElement webElement)
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", webElement.description },
                { "webElement.by", webElement.by }
            });

            // Perform the action
            try
            {
                // Get the window's size
                Size windowSize = Driver.Manage().Window.Size;
                // Get the start time
                DateTime startTime = DateTime.Now;
                // Create a flag for if the element is "In View", meaning it's Y-coordinate is within the window height
                bool inView = IsInView(windowSize, webElement);
                // While the WebElement is not displayed...
                while (inView == false)
                {
                    // Check for timeout
                    if (DateTime.Now > startTime.AddSeconds(TestBase.defaultTimeoutInSeconds))
                    {
                        throw new TimeoutException("Could not find the element, in view, after " + TestBase.defaultTimeoutInSeconds + " seconds.");
                    }
                    else
                    {
                        // Swipe up a little (200px)
                        SwipeUp(200);
                    }
                    // Update the "In View" flag
                    inView = IsInView(windowSize, webElement);
                }
                // Get the current location of the WebElement
                Point location = webElement.Location;
                // Declare a vairable to hold the target location
                int targetY = 1;
                // Handle the difference in OS
                if (ConfigurationManager.AppSettings["platformName"] == "Android")
                {
                    // Get the height of the navigation bar (Add 1 so that we scroll the element right under)
                    targetY = GetOffsetForAndroid() + 1;
                }
                else if (ConfigurationManager.AppSettings["platformName"] == "iOS")
                {
                    // Get the height of the navigation bar (Add 1 so that we scroll the element right under)
                    targetY = GetOffsetForIos() + 1;
                }
                // Scroll closer to top if the Y-coordinate is not above the sticky header
                if (location.Y > targetY)
                {
                    // Swipe the WebElement the top (accounting for the NavBar)
                    SwipeWithoutInertia(location.X, location.Y, location.X, targetY);
                }
                // Logging - After action success
                Log.Success();
            }
            catch (Exception e)
            {
                // Logging - After action exception
                Log.Failure(e.Message);
                // Fail current test
                Assert.Fail(e.Message
                    + Environment.NewLine
                    + "webElement.description : " + webElement.description
                    + Environment.NewLine
                    + "webElement.by" + webElement.by
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Scrolls until the element is Displayed or times out.
        /// </summary>
        public static void ScrollTo(WebElement webElement)
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", webElement.description },
                { "webElement.by", webElement.by }
            });

            // Perform the action
            try
            {
                // Record the start time
                DateTime startTime = DateTime.Now;
                // While the element is not displayed and the time-out has not been reached
                while ((webElement.Displayed == false) && (startTime.AddSeconds(TestBase.defaultTimeoutInSeconds) > DateTime.Now))
                {
                    SwipeUp(200);
                }
                // Logging - After action success
                Log.Success();
            }
            catch (Exception e)
            {
                // Logging - After action exception
                Log.Failure(e.Message);
                // Fail current test
                Assert.Fail(e.Message
                    + Environment.NewLine
                    + "webElement.description : " + webElement.description
                    + Environment.NewLine
                    + "webElement.by" + webElement.by
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Sends a sequence of keystrokes to the Driver.
        /// </summary>
        /// <param name="keysToSend">The keystrokes to send to the Driver.</param>
        public static void SendKeys(string keysToSend)
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "Keys To Send", keysToSend }
            });

            // Perform the action
            try
            {
                // Send the keys
                Actions action = new Actions(Driver);
                action.SendKeys(keysToSend).Build().Perform();
                // Logging - After action success
                Log.Success();
            }
            catch (Exception e)
            {
                // Logging - After action exception
                Log.Failure(e.Message);
                // Fail current test
                // Fail current test
                Assert.Fail(e.Message
                    + Environment.NewLine
                    + "Keys To Send : " + keysToSend
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Changes the device (iOS) or current activity (Android) orientation to landscape mode.
        /// </summary>
        public static void SetOrientationLandscape()
        {
            // Log Before Action
            Log.BeforeAction();

            // Perform the action
            try
            {
                // Set the screen orientation to Landscape
                Driver.Orientation = ScreenOrientation.Landscape;
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

        /// <summary>
        /// Changes the device (iOS) or current activity (Android) orientation to portrait mode.
        /// </summary>
        public static void SetOrientationPortrait()
        {
            // Log Before Action
            Log.BeforeAction();

            // Perform the action
            try
            {
                // Set the screen orientation to Portrait
                Driver.Orientation = ScreenOrientation.Portrait;
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

        public enum Direction
        {
            Down,
            Left,
            Right,
            Up
        }

        /// <summary>
        /// Swipes from the middle to the screen to the given edge of the screen.
        /// </summary>
        /// <param name="direction">The direction to swipe to from the center of the screen.</param>
        /// <param name="swipes">(Optional) The number of swipes to perform.</param>
        public static void SwipeFromMiddle(Direction direction, int swipes = 1)
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "Direction", direction },
                { "Swipes", swipes }
            });

            // Perform the action
            try
            {
                // Get the window's size
                Size windowSize = Driver.Manage().Window.Size;
                // Find the center X coordinate of the window
                int startX = windowSize.Width / 2;
                // Find the center Y coordinate of the window
                int startY = windowSize.Height / 2;
                // Declare variables to hold the end X/Y coordinates
                int endX = 0;
                int endY = 0;
                // Set the end X/Y coordinates accordingly
                if (direction == Direction.Down)
                {
                    endX = startX;
                    endY = windowSize.Height - 1;
                }
                else if (direction == Direction.Left)
                {
                    endX = 1;
                    endY = startY;
                }
                else if (direction == Direction.Right)
                {
                    endX = windowSize.Width - 1;
                    endY = startY;
                }
                else if (direction == Direction.Up)
                {
                    endX = startX;
                    endY = 1;
                }
                // Perform the swipe the given number of times
                for (int i = 0; i < swipes; i++)
                {
                    // Swipe using the calculated values
                    Driver.Swipe(startX, startY, endX, endY, 1000);
                    // Wait a moment
                    System.Threading.Thread.Sleep(500);
                }
                // Logging - After action success
                Log.Success();
            }
            catch (Exception e)
            {
                // Logging - After action exception
                Log.Failure(e.Message);
                // Fail current test
                Assert.Fail(e.Message
                    + Environment.NewLine
                    + "Direction : " + direction
                    + Environment.NewLine
                    + "Swipes : " + swipes
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        public enum EdgeDirection
        {
            LeftToRight,
            RightToLeft
        }

        /// <summary>
        /// Swipes (at the middle of the screen) from one edge of the screen to the other.
        /// </summary>
        /// <param name="edgeDirection">The direction to swipe.</param>
        /// <param name="swipes">(Optional) The number of swipes to perform.</param>
        public static void SwipeEdgeToEdge(EdgeDirection edgeDirection, int swipes = 1)
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "Edge Direction", edgeDirection },
                { "Swipes", swipes }
            });

            // Perform the action
            try
            {
                // Get the window's size
                Size windowSize = Driver.Manage().Window.Size;
                // Find the center X coordinate of the window
                int centerX = windowSize.Width / 2;
                // Find the center Y coordinate of the window
                int centerY = windowSize.Height / 2;
                // Declare variables to hold the X/Y coordinates
                int startX = 0;
                int startY = 0;
                int endX = 0;
                int endY = 0;
                // Set the X/Y coordinates accordingly
                if (edgeDirection == EdgeDirection.LeftToRight)
                {
                    startX = 1;
                    startY = centerY;
                    endX = windowSize.Width - 1;
                    endY = centerY;
                }
                else if (edgeDirection == EdgeDirection.RightToLeft)
                {
                    startX = windowSize.Width - 1;
                    startY = centerY;
                    endX = 1;
                    endY = centerY;
                }
                // Perform the swipe the given number of times
                for (int i = 0; i < swipes; i++)
                {
                    // Swipe using the calculated values
                    Driver.Swipe(startX, startY, endX, endY, 1000);
                    // Wait a moment
                    System.Threading.Thread.Sleep(500);
                }
                // Logging - After action success
                Log.Success();
            }
            catch (Exception e)
            {
                // Logging - After action exception
                Log.Failure(e.Message);
                // Fail current test
                Assert.Fail(e.Message
                    + Environment.NewLine
                    + "Edge Direction : " + edgeDirection
                    + Environment.NewLine
                    + "Swipes : " + swipes
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Swipes (at the middle of the element) from one edge of the screen to the other.
        /// </summary>
        /// <param name="webElement">The element whose Y-coordinate to use.</param>
        /// <param name="edgeDirection">The direction to swipe.</param>
        /// <param name="swipes">(Optional) The number of swipes to perform.</param>
        public static void SwipeEdgeToEdge(WebElement webElement, EdgeDirection edgeDirection, int swipes = 1)
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", webElement.description },
                { "webElement.by", webElement.by },
                { "Edge Direction", edgeDirection },
                { "Swipes", swipes }
            });

            // Perform the action
            try
            {
                // Get the window's size
                Size windowSize = Driver.Manage().Window.Size;
                // Get the WebElement's location
                int centerY = webElement.Location.Y;
                // Declare variables to hold the X/Y coordinates
                int startX = 0;
                int startY = 0;
                int endX = 0;
                int endY = 0;
                // Set the X/Y coordinates accordingly
                if (edgeDirection == EdgeDirection.LeftToRight)
                {
                    startX = 1;
                    startY = centerY;
                    endX = windowSize.Width - 1;
                    endY = centerY;
                }
                else if (edgeDirection == EdgeDirection.RightToLeft)
                {
                    startX = windowSize.Width - 1;
                    startY = centerY;
                    endX = 1;
                    endY = centerY;
                }
                // Perform the swipe the given number of times
                for (int i = 0; i < swipes; i++)
                {
                    // Swipe using the calculated values
                    Driver.Swipe(startX, startY, endX, endY, 1000);
                    // Wait a moment
                    System.Threading.Thread.Sleep(500);
                }
                // Logging - After action success
                Log.Success();
            }
            catch (Exception e)
            {
                // Logging - After action exception
                Log.Failure(e.Message);
                // Fail current test
                Assert.Fail(e.Message
                    + Environment.NewLine
                    + "webElement.description : " + webElement.description
                    + Environment.NewLine
                    + "webElement.by" + webElement.by
                    + Environment.NewLine
                    + "Edge Direction : " + edgeDirection
                    + Environment.NewLine
                    + "Swipes : " + swipes
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Swipes "up" the given number of pixels.
        /// </summary>
        /// <param name="pixels">The number of pixels to swipe "Up".</param>
        /// <param name="duration">The time (in miliseconds) to take performing the action.</param>
        /// <param name="swipes">The number of times to perform the action.</param>
        public static void SwipeUp(int pixels, int duration = 1000, int swipes = 1)
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "Pixels", pixels },
                { "Duration", duration },
                { "Swipes", swipes }
            });

            // Perform the action
            try
            {
                // Get the window's size
                Size windowSize = Driver.Manage().Window.Size;
                // Find the center X coordinate of the window
                int windowCenterX = windowSize.Width / 2;
                // Find the center Y coordinate of the window
                int windowCenterY = windowSize.Height / 2;
                // Account for the OS platform
                if (ConfigurationManager.AppSettings["platformName"] == "iOS")
                {
                    pixels = pixels * -1;
                }
                // Perform the swipe the given number of times
                for (int i = 0; i < swipes; i++)
                {
                    // Perform the action
                    TouchAction touchAction = new TouchAction(Driver);
                    touchAction.Press(windowCenterX, windowCenterY).Wait(duration).MoveTo(windowCenterX, pixels).Release().Perform();

                    // Wait a moment
                    System.Threading.Thread.Sleep(500);
                }
                // Logging - After action success
                Log.Success();
            }
            catch (Exception e)
            {
                // Logging - After action exception
                Log.Failure(e.Message);
                // Fail current test
                Assert.Fail(e.Message
                    + Environment.NewLine
                    + "Pixels : " + pixels
                    + Environment.NewLine
                    + "Duration : " + duration
                    + Environment.NewLine
                    + "Swipes : " + swipes
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
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
        public static void SwipeWithoutInertia(int startX, int startY, int endX, int endY, int duration = 2160, int swipes = 1)
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "Start X", startX },
                { "Start Y", startY },
                { "End X", endX },
                { "End Y", endY },
                { "Duration", duration },
                { "Swipes", swipes }
            });

            // Perform the action
            try
            {
                // Get the Platform Name
                string platformName = ConfigurationManager.AppSettings["platformName"];
                // Perform the swipe the given number of times
                for (int i = 0; i < swipes; i++)
                {
                    // Handle the difference in OS
                    if (platformName == "Android")
                    {
                        Driver.Swipe(startX, startY, endX, endY, duration);
                    }
                    else if (platformName == "iOS")
                    {
                        // Define and perform the Touch Action
                        TouchAction touchAction = new TouchAction(Driver);
                        touchAction
                            .Press(startX, startY)
                            .Wait(duration)
                            .MoveTo(endX, endY)
                            .Wait(duration)
                            .Release()
                            .Perform();
                    }
                    // Wait a moment
                    System.Threading.Thread.Sleep(500);
                }
                // Logging - After action success
                Log.Success();
            }
            catch (Exception e)
            {
                // Logging - After action exception
                Log.Failure(e.Message);
                // Fail current test
                Assert.Fail(e.Message
                    + Environment.NewLine
                    + "StartX : " + startX
                    + Environment.NewLine
                    + "StartY : " + startY
                    + Environment.NewLine
                    + "EndX : " + endX
                    + Environment.NewLine
                    + "EndX : " + endX
                    + Environment.NewLine
                    + "Duration" + duration
                    + Environment.NewLine
                    + "Swipes" + swipes
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Get the center coordinates of the current view
        /// </summary>
        public static void TapCenterOfScreen()
        {
            // Log Before Action
            Log.BeforeAction();

            // Perform the action
            try
            {
                // Get the window's size
                Size windowSize = Driver.Manage().Window.Size;
                // Find the center X coordinate of the window
                int windowCenterX = windowSize.Width / 2;
                // Find the center Y coordinate of the window
                int windowCenterY = windowSize.Height / 2;
                Tap(windowCenterX, windowCenterY);
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

        /// <summary>
        /// Waits for the given element to be displayed.
        /// </summary>
        /// /// <param name="by">The mechanism to locate the element.</param>
        /// <param name="timeOutInSeconds">(Optional) The seconds to wait for the condition.</param>
        public static void WaitForElementToBeDisplayed(By by, int timeOutInSeconds = TestBase.defaultTimeoutInSeconds)
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "FindBy", by },
                { "Timeout", timeOutInSeconds}
            });

            // Perform the action
            try
            {
                // Define a variable to hold the result
                bool displayed = false;
                // Get the start time
                DateTime startTime = DateTime.Now;
                // While we haven't timed out
                while (startTime.AddSeconds(timeOutInSeconds) > DateTime.Now)
                {
                    try
                    {
                        AppiumWebElement appiumWebElement = Driver.FindElement(by);
                        Point location = appiumWebElement.Location;
                        Size size = appiumWebElement.Size;
                        if (location.X > -1 && location.Y > -1 && size.IsEmpty == false)
                        {
                            displayed = true;
                            break;
                        }
                    }
                    catch
                    {
                        /* do nothing */
                    }
                    finally
                    {
                        System.Threading.Thread.Sleep(250);
                    }
                }
                if (displayed == false)
                {
                    throw new TimeoutException("Timed out before the element was displayed.");
                }
                // Logging - After action success
                Log.Success();
            }
            catch (Exception e)
            {
                // Logging - After action exception
                Log.Failure(e.Message);
                // Fail current test
                Assert.Fail(e.Message
                    + Environment.NewLine
                    + "FindBy : " + by
                    + Environment.NewLine
                    + "Timeout in Seconds: " + timeOutInSeconds
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Waits for the given element to be displayed.
        /// </summary>
        /// <param name="appiumWebElement">The element to target.</param>
        /// <param name="timeOutInSeconds">(Optional) The seconds to wait for the condition.</param>
        public static void WaitForElementToBeDisplayed(AppiumWebElement appiumWebElement, int timeOutInSeconds = TestBase.defaultTimeoutInSeconds)
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "Timeout (in seconds)", timeOutInSeconds }
            });

            // Perform the action
            try
            {
                // Define a variable to hold the result
                bool displayed = false;
                // Get the start time
                DateTime startTime = DateTime.Now;
                // While we haven't timed out
                while (startTime.AddSeconds(timeOutInSeconds) > DateTime.Now)
                {
                    try
                    {
                        Point location = appiumWebElement.Location;
                        Size size = appiumWebElement.Size;
                        if (location.X > -1 && location.Y > -1 && size.IsEmpty == false)
                        {
                            displayed = true;
                            break;
                        }
                    }
                    catch
                    {
                        /* do nothing */
                    }
                    finally
                    {
                        System.Threading.Thread.Sleep(250);
                    }
                }
                if (displayed == false)
                {
                    throw new TimeoutException("Timed out before the element was displayed.");
                }
                // Logging - After action success
                Log.Success();
            }
            catch (Exception e)
            {
                // Logging - After action exception
                Log.Failure(e.Message);
                // Fail current test
                Assert.Fail(e.Message
                    + Environment.NewLine
                    + "Timeout in Seconds: " + timeOutInSeconds
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Waits for the given element to be not displayed.
        /// </summary>
        /// <param name="by">The mechanism to locate the element.</param>
        /// <param name="timeOutInSeconds">(Optional) The seconds to wait for the condition.</param>
        public static void WaitForElementToBeNotDisplayed(By by, int timeOutInSeconds = TestBase.defaultTimeoutInSeconds)
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "By", by },
                { "Timeout (in seconds)", timeOutInSeconds }
            });

            // Perform the action
            try
            {
                // Define a variable to hold the result
                bool displayed = true;
                // Get the start time
                DateTime startTime = DateTime.Now;
                // While we haven't timed out
                while (startTime.AddSeconds(timeOutInSeconds) > DateTime.Now)
                {
                    try
                    {
                        AppiumWebElement appiumWebElement = Driver.FindElement(by);
                        if (appiumWebElement.Displayed == false)
                        {
                            displayed = false;
                            break;
                        }
                    }
                    catch
                    {
                        break;
                    }
                    finally
                    {
                        System.Threading.Thread.Sleep(250);
                    }
                }
                if (displayed == true)
                {
                    throw new TimeoutException("Timed out before the element was not displayed.");
                }
                // Logging - After action success
                Log.Success();
            }
            catch (Exception e)
            {
                // Logging - After action exception
                Log.Failure(e.Message);
                // Fail current test
                Assert.Fail(e.Message
                    + Environment.NewLine
                    + "FindBy : " + by
                    + Environment.NewLine
                    + "Timeout in Seconds: " + timeOutInSeconds
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Waits for the given element to be not displayed.
        /// </summary>
        /// <param name="appiumWebElement">The element to target.</param>
        /// <param name="timeOutInSeconds">(Optional) The seconds to wait for the condition.</param>
        public static void WaitForElementToBeNotDisplayed(AppiumWebElement appiumWebElement, int timeOutInSeconds = TestBase.defaultTimeoutInSeconds)
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "Timeout (in seconds)", timeOutInSeconds }
            });

            // Perform the action
            try
            {
                // Define a variable to hold the result
                bool displayed = true;
                // Get the start time
                DateTime startTime = DateTime.Now;
                // While we haven't timed out
                while (startTime.AddSeconds(timeOutInSeconds) > DateTime.Now)
                {
                    try
                    {
                        if (appiumWebElement.Displayed == false)
                        {
                            displayed = false;
                            break;
                        }
                    }
                    catch
                    {
                        break;
                    }
                    finally
                    {
                        System.Threading.Thread.Sleep(250);
                    }
                }
                if (displayed == true)
                {
                    throw new TimeoutException("Timed out before the element was not displayed.");
                }
                // Logging - After action success
                Log.Success();
            }
            catch (Exception e)
            {
                // Logging - After action exception
                Log.Failure(e.Message);
                // Fail current test
                Assert.Fail(e.Message
                    + Environment.NewLine
                    + "Timeout in Seconds: " + timeOutInSeconds
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        #endregion Custom App Methods

        #region Private Methods

        /// <summary>
        /// Get the height of the OS toolbar and App toolbar.
        /// </summary>
        /// <returns>The Y-coordinate offset.</returns>
        private static int GetOffsetForAndroid()
        {
            WebElement starzToolBar = new WebElement(By.Id("tool_bar"), "Starz app toolbar");
            return starzToolBar.Location.Y + starzToolBar.Size.Height;
        }

        /// <summary>
        /// Get the height of the OS toolbar and App toolbar.
        /// </summary>
        /// <returns>The Y-coordinate offset.</returns>
        private static int GetOffsetForIos()
        {
            WebElement starzToolBar = new WebElement(By.XPath("//XCUIElementTypeNavigationBar"), "Starz app toolbar");
            return starzToolBar.Location.Y + starzToolBar.Size.Height;
        }

        /// <summary>
        /// Determines if the given WebElement's Y-coordinate is within the Window Height.
        /// </summary>
        /// <param name="webElement">The WebElement whose Location we are looking for.</param>
        /// <returns>If the WebElement is "In View"</returns>
        private static bool IsInView(Size windowSize, WebElement webElement)
        {
            // Create a variable to hold the return value
            bool inView = false;
            // Ensure the element is not null
            if (webElement != null)
            {
                try
                {
                    // Try to get the location
                    Point location = webElement.element.Location;
                    if (location != null)
                    {
                        // Try to get the location's Y-coordinate
                        int yLocation = webElement.Location.Y;
                        // Compare the element's Y-coordinate to the screen size
                        if (yLocation < windowSize.Height)
                        {
                            inView = true;
                        }
                    }
                }
                catch { /* do nothing */ }
            }
            return inView;
        }

        #endregion Private Methods
    }
}
