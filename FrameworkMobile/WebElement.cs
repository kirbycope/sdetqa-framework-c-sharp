using FrameworkCommon;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using Assert = FrameworkCommon.Assert;
using TestContext = FrameworkCommon.TestContext;

namespace FrameworkMobile
{
    public class WebElement
    {
        #region WebElement Object Properties

        public AppiumWebElement _element;

        /// <summary>
        /// Provides a mechanism by which to find elements within a document.
        /// </summary>
        public By by;

        /// <summary>
        ///  A description of the element.
        /// </summary>
        public string description;

        /// <summary>
        /// Defines the interface through which the user controls elements on the page.
        /// </summary>
        public AppiumWebElement element
        {
            get
            {
                if (_element == null)
                {
                    _element = AppBase.driver.FindElement(this.by);
                }
                return _element;
            }
            set
            {
                _element = element;
            }
        }

        #endregion WebElement Object Properties

        #region WebElement Object Constructor(s)

        /// <summary>
        /// Creates a WebElement using a an OpenQA.Selenium.By.
        /// </summary>
        /// <param name="driver">The driver controlling this element's page.</param>
        /// <param name="by">Provides a mechanism by which to find elements within a document.</param>
        /// <param name="description">(Optional) A description of the element.</param>
        public WebElement(By by, string description = "")
        {
            this.by = by;
            this.description = description;
        }

        /// <summary>
        /// Creates a WebElement using an OpenQA.Selenium.Appium.AppiumWebElement.
        /// </summary>
        /// <param name="driver">The driver controlling this element's page.</param>
        /// <param name="element">Defines the interface through which the user controls elements on the page.</param>
        /// <param name="description">(Optional) A description of the element.</param>
        public WebElement(AppiumWebElement element, string description = "")
        {
            this._element = element;
            this.description = description;
        }

        /// <summary>
        /// Creates a WebElement using both an OpenQA.Selenium.By and an OpenQA.Selenium.IWebElement.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="by">Provides a mechanism by which to find elements within a document.</param>
        /// <param name="element">Defines the interface through which the user controls elements on the page.</param>
        /// <param name="description">(Optional) A description of the element.</param>
        public WebElement(By by, AppiumWebElement element, string description = "")
        {
            this.by = by;
            this._element = element;
            this.description = description;
        }

        #endregion WebElement Object Constructor(s)

        #region AppiumWebElement Properties (Overrides for OpenQA.Selenium.Appium.AppiumWebElement)

        /// <summary>
        /// Gets the coordinates identifying the location of this element using various frames of reference.
        /// </summary>
        public ICoordinates Coordinates
        {
            get
            {
                // Figure out the padding (if any) to prepend to the log line
                LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
                // Declare a return value
                ICoordinates returnValue = null;
                // Logging - Before action
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(logPadding.Padding + "WebElement.Coordinates");
                if (this.description.Length > 0) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
                if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Find By: " + this.by); }
                sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
                Log.Write(sb.ToString());
                // Perform the action
                try
                {
                    // Get the coordinates identifying the location of this element using various frames of reference
                    returnValue = this.element.Coordinates;
                    // Logging - After action success
                    Log.Success(logPadding.Padding);
                    Log.WriteLine(logPadding.InfoPadding + "[INFO] Coordinates " + returnValue);
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

        /// <summary>
        /// Returns true if element is present and have some dimensions greater than 0
        /// </summary>
        public bool Displayed
        {
            get
            {
                // Figure out the padding (if any) to prepend to the log line
                LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
                // Declare a return value
                bool returnValue = false;
                // Logging - Before action
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(logPadding.Padding + "WebElement.Displayed");
                if (this.description.Length > 0) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
                if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Find By: " + this.by); }
                sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
                Log.Write(sb.ToString());
                // Perform the action
                try
                {
                    // Get a value indicating whether or not this element is displayed
                    returnValue = this.element.Displayed;
                    // Logging - After action success
                    Log.Success(logPadding.Padding);
                }
                catch (Exception e)
                {
                    // Logging - After action exception
                    sb = Log.Exception(sb, e);
                }
                // Logging - After action
                Log.WriteLine(logPadding.InfoPadding + "[INFO] Displayed: " + returnValue);
                Log.Finally(logPadding.Padding);
                // Return the return value
                return returnValue;
            }
        }

        /// <summary>
        /// Whether the element is enabled or not.
        /// </summary>
        public bool Enabled
        {
            get
            {
                // Figure out the padding (if any) to prepend to the log line
                LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
                // Declare a return value
                bool returnValue = false;
                // Logging - Before action
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(logPadding.Padding + "WebElement.Enabled");
                if (this.description.Length > 0) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
                if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Find By: " + this.by); }
                sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
                Log.Write(sb.ToString());
                // Perform the action
                try
                {
                    // Get a value indicating whether or not this element is enabled
                    returnValue = this.element.Enabled;
                    // Logging - After action success
                    Log.Success(logPadding.Padding);
                    Log.WriteLine(logPadding.InfoPadding + "[INFO] Enabled: " + returnValue);
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

        /// <summary>
        /// The identifier of the view element. For Android: The id of the element. For iOS: The accessibilityIdentifier of the element.
        /// </summary>
        public string Id
        {
            get
            {
                // Figure out the padding (if any) to prepend to the log line
                LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
                // Declare a return value
                string returnValue = "";
                // Logging - Before action
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(logPadding.Padding + "WebElement.Id");
                if (this.description.Length > 0) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
                if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Find By: " + this.by); }
                sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
                Log.Write(sb.ToString());
                // Perform the action
                try
                {
                    // Get the ID of this element
                    returnValue = this.element.Id;
                    // Logging - After action success
                    Log.Success(logPadding.Padding);
                    Log.WriteLine(logPadding.InfoPadding + "[INFO] ID: " + returnValue);
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

        /// <summary>
        /// Gets a System.Drawing.Point object containing the coordinates of the upper-left 
        /// corner of this element relative to the upper-left corner of the page.
        /// </summary>
        public Point Location
        {
            get
            {
                // Figure out the padding (if any) to prepend to the log line
                LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
                // Declare a return value
                Point returnValue = new Point();
                // Logging - Before action
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(logPadding.Padding + "WebElement.Location");
                if (this.description.Length > 0) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
                if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Find By: " + this.by); }
                sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
                Log.Write(sb.ToString());
                // Perform the action
                try
                {
                    // Get a System.Drawing.Point object containing the coordinates of the upper-left corner of this element relative to the upper-left corner of the page
                    returnValue = this.element.Location;
                    // Logging - After action success
                    Log.Success(logPadding.Padding);
                    Log.WriteLine(logPadding.InfoPadding + "[INFO] Location " + returnValue);
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

        /// <summary>
        /// Gets a value indicating whether or not this element is selected.
        /// </summary>
        public bool Selected
        {
            get
            {
                // Figure out the padding (if any) to prepend to the log line
                LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
                // Declare a return value
                bool returnValue = false;
                // Logging - Before action
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(logPadding.Padding + "WebElement.Selected");
                if (this.description.Length > 0) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
                if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Find By: " + this.by); }
                sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
                Log.Write(sb.ToString());
                // Perform the action
                try
                {
                    // Get a value indicating whether or not this element is selected
                    returnValue = this.element.Selected;
                    // Logging - After action success
                    Log.Success(logPadding.Padding);
                    Log.WriteLine(logPadding.InfoPadding + "[INFO] Selected: " + returnValue);
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

        /// <summary>
        /// The Size (Height, Width) of this element.
        /// </summary>
        public Size Size
        {
            get
            {
                // Figure out the padding (if any) to prepend to the log line
                LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
                // Declare a return value
                Size returnValue = new Size();
                // Logging - Before action
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(logPadding.Padding + "WebElement.Size");
                if (this.description.Length > 0) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
                if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Find By: " + this.by); }
                sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
                Log.Write(sb.ToString());
                // Perform the action
                try
                {
                    // Get a OpenQA.Selenium.Remote.RemoteWebElement.Size object containing the height and width of this element
                    returnValue = this.element.Size;
                    // Logging - After action success
                    Log.Success(logPadding.Padding);
                    Log.WriteLine(logPadding.InfoPadding + "[INFO] Size " + returnValue);
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

        /// <summary>
        /// Gets the tag name of this element.
        /// </summary>
        public string TagName
        {
            get
            {
                // Figure out the padding (if any) to prepend to the log line
                LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
                // Declare a return value
                string returnValue = "";
                // Logging - Before action
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(logPadding.Padding + "WebElement.TagName");
                if (this.description.Length > 0) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
                if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Find By: " + this.by); }
                sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
                Log.Write(sb.ToString());
                // Perform the action
                try
                {
                    // Get the tag name of this element
                    returnValue = this.element.TagName;
                    // Logging - After action success
                    Log.Success(logPadding.Padding);
                    Log.WriteLine(logPadding.InfoPadding + "[INFO] Tag Name " + returnValue);
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

        /// <summary>
        /// The text of the view element.
        /// </summary>
        public string Text
        {
            get
            {
                // Figure out the padding (if any) to prepend to the log line
                LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
                // Declare a return value
                string returnValue = "";
                // Logging - Before action
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(logPadding.Padding + "WebElement.Text");
                if (this.description.Length > 0) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
                if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Find By: " + this.by); }
                sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
                Log.Write(sb.ToString());
                // Perform the action
                try
                {
                    // Get the innerText of this element, without any leading or trailing whitespace, and with other whitespace collapsed
                    returnValue = this.element.Text;
                    // Logging - After action success
                    Log.Success(logPadding.Padding);
                    Log.WriteLine(logPadding.InfoPadding + "[INFO] Text " + returnValue);
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

        #endregion AppiumWebElement Properties

        #region  AppiumWebElement Methods (Overrides for OpenQA.Selenium.Appium.AppiumWebElement)

        /// <summary>
        /// Clears the content of this element.
        /// </summary>
        public void Clear()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "WebElement.Clear()");
            if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
            if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Clear the content of this element.
                this.element.Clear();
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
        /// Finds the first IWebElement using the given method.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>The first matching WebElement on the current context.</returns>
        public WebElement FindElement(By by)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Declare an empty object to hold the return value
            WebElement returnValue = null;
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "WebElement.FindElement(by)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Element To Find Finds By: " + by);
            if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
            if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Find the first element using the given By
                returnValue = new WebElement
                (
                    by,
                    this.element.FindElement(by)
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
        /// Finds all IWebElements within the current context using the given mechanism.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>A ReadOnlyCollection of all WebElements matching the current criteria, or an empty list if nothing matches.</returns>
        public IList<WebElement> FindElements(By by)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Declare an empty object to hold the return value
            IList<WebElement> returnValue = new List<WebElement>();
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "WebElement.FindElements(by)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Element(s) To Find Finds By: " + by);
            if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
            if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Find the element(s) using the given By
                var elements = this.element.FindElements(by);
                // Convert each IWebElement to a WebElement
                foreach (var element in elements)
                {
                    WebElement webElement = new WebElement
                    (
                        element
                    );
                    // Add the converted element to the list
                    returnValue.Add(webElement);
                }
                // Logging - After action success
                Log.Success(logPadding.Padding);
                Log.WriteLine(logPadding.InfoPadding + "[INFO] Elements Found: " + returnValue.Count);
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
        /// Gets the value of the specified attribute for this element.
        /// </summary>
        /// <param name="attributeName">The name of the attribute.</param>
        /// <returns>The attribute's current value. Returns a null if the value is not set.</returns>
        public string GetAttribute(string attributeName)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Declare an empty object to hold the return value
            string returnValue = null;
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "WebElement.GetAttribute(attributeName)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Attribute Name: " + attributeName);
            if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
            if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Get the value of the given attribute name
                returnValue = this.element.GetAttribute(attributeName);
                // Logging - After action success
                Log.Success(logPadding.Padding);
                Log.WriteLine(logPadding.InfoPadding + "[INFO] Attribute Value: " + returnValue);
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
        /// Gets the value of a CSS property of this element.
        /// </summary>
        /// <param name="propertyName">The name of the CSS property to get the value of.</param>
        /// <returns>The value of the specified CSS property.</returns>
        public string GetCssValue(string propertyName)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Declare an empty object to hold the return value
            string returnValue = null;
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "WebElement.GetCssValue(propertyName)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Property Name: " + propertyName);
            if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
            if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.WriteLine(sb.ToString());
            // Perform the action
            try
            {
                // Get the value of the given CSS property
                returnValue = this.element.GetCssValue(propertyName);
                // Logging - After action success
                Log.Success(logPadding.Padding);
                Log.WriteLine(logPadding.InfoPadding + "[INFO] CSS Property Value: " + returnValue);
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
        /// Gets the value of a JavaScript property of this element.
        /// </summary>
        /// <param name="propertyName">The name JavaScript the JavaScript property to get the value of.</param>
        /// <returns>The JavaScript property's current value. Returns a null if the value is not set or the property does not exist.</returns>
        public string GetProperty(string propertyName)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Declare an empty object to hold the return value
            string returnValue = null;
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "WebElement.GetProperty(propertyName)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Property Name: " + propertyName);
            if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
            if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Get the value of a JavaScript property of this element.
                returnValue = this.element.GetProperty(propertyName);
                // Logging - After action success
                Log.Success(logPadding.Padding);
                Log.WriteLine(logPadding.InfoPadding + "[INFO] Property Value: " + returnValue);
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
        /// Simulates typing text into the element.
        /// </summary>
        /// <param name="text">The text to type into the element.</param>
        public void SendKeys(string text)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "WebElement.SendKeys(text)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Keys to Send: " + text);
            if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
            if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Simulate typing text into the element
                this.element.SendKeys(text);
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
        /// Submits this element to the web server.
        /// </summary>
        public void Submit()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "WebElement.Submit()");
            if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
            if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Submit this form
                this.element.Submit();
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
        /// Performs a tap/touch gesture on the matched element.
        /// If multiple elements are matched, the first one will be used.
        /// </summary>
        public void Tap()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "WebElement.Tap()");
            if (this.description.Length > 0) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
            if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Find By: " + this.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Tap the center of the given element
                this.element.Tap(1, 250);
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

        #endregion AppiumWebElement Methods (Overrides for OpenQA.Selenium.Appium.AppiumWebElement)

        #region Custom AppiumWebElement Properties

        /// <summary>
        /// The label of the view element. For Android: The contentDescription of the element.
        /// For iOS: The accessibilityLabel of the element.
        /// </summary>
        public string Label
        {
            get
            {
                // Figure out the padding (if any) to prepend to the log line
                LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
                // Declare a return value
                string returnValue = "";
                // Logging - Before action
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(logPadding.Padding + "WebElement.Label");
                if (this.description.Length > 0) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
                if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Find By: " + this.by); }
                sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
                Log.Write(sb.ToString());
                // Perform the action
                try
                {
                    if (this.by != null)
                    {
                        returnValue = AppBase.driver.FindElement(this.by).GetAttribute("content-desc");
                    }
                    else
                    {
                        returnValue = this.element.GetAttribute("content-desc");
                    }
                    // Logging - After action success
                    Log.Success(logPadding.Padding);
                    Log.WriteLine(logPadding.InfoPadding + "[INFO] Label: " + returnValue);
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

        /// <summary>
        /// The Parent element of this element.
        /// </summary>
        public WebElement Parent
        {
            get
            {
                // Figure out the padding (if any) to prepend to the log line
                LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
                // Declare a return value
                WebElement returnValue = null;
                // Logging - Before action
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(logPadding.Padding + "WebElement.Parent");
                string description = "Parent element of: ";
                if (this.description.Length > 0) { description = description + this.description; }
                else if (this.by != null) { description = description + this.by.ToString(); }
                sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
                Log.Write(sb.ToString());
                // Perform the action
                try
                {
                    returnValue = new WebElement
                    (
                        AppBase.driver.FindElement(this.by).FindElement(By.XPath("//..")),
                        description
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
        }

        /// <summary>
        /// The Sibling element of this element.
        /// </summary>
        public WebElement Sibling
        {
            get
            {
                // Figure out the padding (if any) to prepend to the log line
                LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
                // Declare a return value
                WebElement returnValue = null;
                // Logging - Before action
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(logPadding.Padding + "WebElement.Sibling");
                string description = "Sibling element of: ";
                if (this.description.Length > 0) { description = description + this.description; }
                else if (this.by != null) { description = description + this.by.ToString(); }
                sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
                Log.Write(sb.ToString());
                // Perform the action
                try
                {
                    returnValue = new WebElement
                    (
                        AppBase.driver.FindElement(this.by).FindElement(By.XPath("//following-sibling::*")),
                        description
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
        }

        #endregion Custom AppiumWebElement Properties

        #region Custom AppiumWebElement Methods

        /// <summary>
        /// Wait function that will repeatly query the app until a matching element is found.
        /// Throws a System.TimeoutException if no element is found within the time limit.
        /// </summary>
        public void WaitForElement()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "WebElement.WaitForElement()");
            if (this.description.Length > 0) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
            if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Find By: " + this.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                if (this.by != null)
                {
                    AppBase.WaitForElementToBeDisplayed(this.by);
                }
                else
                {
                    AppBase.WaitForElementToBeDisplayed(this.element);
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
        /// Wait function that will repeatly query the app until a matching element is not found.
        /// Throws a System.TimeoutException if no element is found within the time limit.
        /// </summary>
        public void WaitForElementNotDisplayed()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "WebElement.WaitForElementNotDisplayed()");
            if (this.description.Length > 0) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
            if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Find By: " + this.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                if (this.by != null)
                {
                    AppBase.WaitForElementToBeNotDisplayed(this.by);
                }
                else
                {
                    AppBase.WaitForElementToBeNotDisplayed(this.element);
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

        #endregion Custom AppiumWebElement Methods
    }
}
