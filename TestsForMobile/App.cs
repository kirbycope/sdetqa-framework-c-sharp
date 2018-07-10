using FrameworkCommon;
using FrameworkMobile;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Diagnostics;
using System.Text;
using TestsForMobile.POMs;

namespace TestsForMobile
{
    public class App : AppBase
    {
        #region Android Only Methods (hardware buttons)

        /// <summary>
        /// Navigate back on the device.
        /// </summary>
        public static void Back()
        {
            // Log Before Action
            Log.BeforeAction();

            // Perform the action
            try
            {
                // Press the [BACK] button
                ((AndroidDriver<AppiumWebElement>)Driver).PressKeyCode(AndroidKeyCode.Back);
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
        /// Presses the enter key in the app.
        /// </summary>
        public static void PressEnter()
        {
            // Log Before Action
            Log.BeforeAction();

            // Perform the action
            try
            {
                // Press the [ENTER] button
                ((AndroidDriver<AppiumWebElement>)Driver).PressKeyCode(AndroidKeyCode.Enter);
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
        /// Presses the volume down button on the device.
        /// </summary>
        public static void PressVolumeDown()
        {
            // Log Before Action
            Log.BeforeAction();

            // Perform the action
            try
            {
                // Press the [Volume Down] button
                ((AndroidDriver<AppiumWebElement>)Driver).PressKeyCode(AndroidKeyCode.Keycode_VOLUME_DOWN);
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
        /// Presses the volume up button on the device.
        /// </summary>
        public static void PressVolumeUp()
        {
            // Log Before Action
            Log.BeforeAction();

            // Perform the action
            try
            {
                // Press the [Volume Up] button
                ((AndroidDriver<AppiumWebElement>)Driver).PressKeyCode(AndroidKeyCode.Keycode_VOLUME_UP);
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

        #endregion Android Only Methods (hardware buttons)

        /// <summary>
        /// 'Home' page.
        /// </summary>
        public static HomePage HomePage
        {
            get
            {
                return new HomePage();
            }
        }
    }
}
