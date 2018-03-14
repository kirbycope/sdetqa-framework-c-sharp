using FrameworkCommon;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using Assert = FrameworkCommon.Assert;
using TestContext = FrameworkCommon.TestContext;

namespace FrameworkDesktop
{
    public class WebElement
    {
        #region WebElement Object Properties

        private IWebElement _element;

        /// <summary>
        /// Provides a mechanism by which to find elements within a document.
        /// </summary>
        public By by;

        /// <summary>
        ///  A description of the element.
        /// </summary>
        public string description;

        /// <summary>
        /// Defines the interface through which the user controls the browser.
        /// </summary>
        public IWebDriver driver
        {
            get
            {
                return (IWebDriver)TestContext.Get("driver");
            }
        }

        /// <summary>
        /// Defines the interface through which the user controls elements on the page.
        /// </summary>
        public IWebElement element
        {
            get
            {
                if (_element == null)
                {
                    _element = this.driver.FindElement(this.by);
                }
                return _element;
            }
            set
            {
                _element = element;
            }
        }

        #endregion WebElement Object Properties

        #region WebElement Object constructor(s)

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
        /// Creates a WebElement using an OpenQA.Selenium.IWebElement.
        /// </summary>
        /// <param name="driver">The driver controlling this element's page.</param>
        /// <param name="element">Defines the interface through which the user controls elements on the page.</param>
        /// <param name="description">(Optional) A description of the element.</param>
        public WebElement(IWebElement element, string description = "")
        {
            this.description = description;
            this._element = element;
        }

        /// <summary>
        /// Creates a WebElement using both an OpenQA.Selenium.By and an OpenQA.Selenium.IWebElement.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="by">Provides a mechanism by which to find elements within a document.</param>
        /// <param name="element">Defines the interface through which the user controls elements on the page.</param>
        /// <param name="description">(Optional) A description of the element.</param>
        public WebElement(By by, IWebElement element, string description = "")
        {
            this.by = by;
            this.description = description;
            this._element = element;
        }

        #endregion WebElement Object constructor(s)

        #region SeleniumWebElement Properties (Overrides for OpenQA.Selenium.IWebElement properties)

        /// <summary>
        /// Gets a value indicating whether or not this element is displayed.
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
                if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
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
        /// Gets a value indicating whether or not this element is enabled.
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
                if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
                if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
                sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
                Log.Write(sb.ToString());
                // Perform the action
                try
                {
                    // Gets a value indicating whether or not this element is enabled
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
        /// Gets a Point object containing the coordinates of the upper-left corner of this element relative to the upper-left corner of the page.
        /// </summary>
        /// <param name="message">(Optional) The message to display if an exception is thrown.</param>
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
                if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
                if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
                sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
                Log.Write(sb.ToString());
                // Perform the action
                try
                {
                    // Get a System.Drawing.Point object containing the coordinates of the upper-left corner of this element relative to the upper-left corner of the page
                    returnValue = this.element.Location;
                    // Logging - After action success
                    Log.Success(logPadding.Padding);
                    Log.WriteLine(logPadding.InfoPadding + "[INFO] Location: " + returnValue);
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
                sb.AppendLine(logPadding.Padding + "WebElement.IsSelected()");
                if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
                if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
                sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
                Log.Write(sb.ToString());
                // Perform the action
                try
                {
                    // Get a value indicating whether or not this element is enabled
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
        /// Gets a Size object containing the height and width of this element.
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
                if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
                if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
                sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
                Log.Write(sb.ToString());
                // Perform the action
                try
                {
                    // Get a OpenQA.Selenium.IWebElement.Size object containing the height and width of this element
                    returnValue = this.element.Size;
                    // Logging - After action success
                    Log.Success(logPadding.Padding);
                    Log.WriteLine(logPadding.InfoPadding + "[INFO] Size: " + returnValue);
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
                if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
                if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
                sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
                Log.Write(sb.ToString());
                // Perform the action
                try
                {
                    // Get the tag name of this element
                    returnValue = this.element.TagName;
                    // Logging - After action success
                    Log.Success(logPadding.Padding);
                    Log.WriteLine(logPadding.InfoPadding + "[INFO] Tag Name: " + returnValue);
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
        /// Gets the innerText of this element, without any leading or trailing whitespace, and with other whitespace collapsed.
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
                if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
                if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
                sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
                Log.Write(sb.ToString());
                // Perform the action
                try
                {
                    // Gets the innerText of this element, without any leading or trailing whitespace, and with other whitespace collapsed.
                    returnValue = this.element.Text;
                    // Logging - After action success
                    Log.Success(logPadding.Padding);
                    Log.WriteLine(logPadding.InfoPadding + "[INFO] Text: " + returnValue);
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

        #endregion SeleniumWebElement Properties (Overrides for OpenQA.Selenium.IWebElement properties)

        #region SeleniumWebElement Methods (Overrides for OpenQA.Selenium.IWebElement methods)

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
        /// Clicks this element.
        /// </summary>
        public void Click()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "WebElement.Click()");
            if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
            if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Wait for the element to be clickable
                WaitForElementToBeClickable();
                // Click this element.
                this.element.Click();
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
                Log.WriteLine(logPadding.InfoPadding + "[INFO] # of Elements Found: " + returnValue.Count);
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

        #endregion SeleniumWebElement Methods (Overrides for OpenQA.Selenium.IWebElement methods)

        #region Custom SeleniumWebElement Methods

        /// <summary>
        /// Presses down the ALT key and clicks on this element.
        /// </summary>
        public void AltClick()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "WebElement.AltClick()");
            if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
            if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // [Alt]+Click this element
                Actions action = new Actions(this.driver);
                action.KeyDown(Keys.LeftAlt).Click(element).Build().Perform();
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
        /// Clicks this element via JavaScript.
        /// </summary>
        public void ClickViaJavaScript()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "WebElement.ClickViaJavaScript()");
            if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
            if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Execute JavaScript in the context of the currently selected frame or window
                AppBase.ExecuteScript("arguments[0].click()", this.element);
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
        /// Clicks this element using the offsets.
        /// </summary>
        /// <param name="xOffset">If positive, then clicks to the right.</param>
        /// <param name="yOffset">If positive, then clicks to the bottom.</param>
        public void ClickWithOffset(int xOffset, int yOffset)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "SeleniumUtils.ClickWithOffset(xOffset, yOffset)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] X-Offset: " + xOffset);
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Y-Offset: " + yOffset);
            if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
            if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Get element's current position
                int elementPositionX = element.Location.X;
                int elementPositionY = element.Location.Y;
                // Perform click (using the offsets)
                Actions action = new Actions(this.driver);
                action.MoveToElement(this.element, xOffset, yOffset).Click().Build().Perform();
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
        /// Presses down the CTRL key and clicks on this element.
        /// </summary>
        public void CtrlClick()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "WebElement.CtrlClick()");
            if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
            if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // [Ctrl]+Click this element
                Actions action = new Actions(this.driver);
                action.KeyDown(Keys.LeftControl).Click(element).Build().Perform();
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
        /// Drags this element to the given element.
        /// </summary>
        /// <param name="targetElement">The element to drag this element to.</param>
        public void DragTo(WebElement targetElement)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "WebElement.DragTo()");
            if (targetElement.description != "") { sb.AppendLine(logPadding.InfoPadding + "[PARAM] Element (To Drag To) Description: " + targetElement.description); }
            if (targetElement.by != null) { sb.AppendLine(logPadding.InfoPadding + "[PARAM] Element (To Drag To) Finds By: " + targetElement.by); }
            if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
            if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Build and then perform the action
                Actions action = new Actions(driver);
                action
                    .ClickAndHold(this.element)
                    .MoveToElement(targetElement.element)
                    .Release(this.element)
                    .Build()
                    .Perform();
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
        /// Hovers over this element.
        /// </summary>
        public void Hover()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "WebElement.Hover()");
            if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
            if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Perform "hover" action
                Actions action = new Actions(this.driver);
                action.MoveToElement(element).Perform();
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
        /// Hovers over this element and then clicks it.
        /// </summary>
        public void HoverAndClick()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "WebElement.HoverAndClick()");
            if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
            if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Move the mouse to the element and click
                Actions action = new Actions(this.driver);
                action.MoveToElement(element).Click().Perform();
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
        /// Right-clicks this element.
        /// </summary>
        public void RightClick()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "WebElement.RightClick()");
            if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
            if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Perform "right-click" action
                Actions action = new Actions(this.driver).ContextClick(this.element);
                action.Build().Perform();
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
        /// Right-clicks this element via JavaScript.
        /// </summary>
        public void RightClickViaJavaScript()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "WebElement.RightClickViaJavaScript()");
            if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
            if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Define the script
                string script = "$( arguments[0] ).trigger({ type: 'mousedown', which: 3})";
                // Execute JavaScript in the context of the currently selected frame or window
                AppBase.ExecuteScript(script);
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
        /// The Element.scrollIntoView() method scrolls the element on which it's called into the visible area of the browser window.
        /// </summary>
        public void ScrollIntoView()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "WebElement.ScrollIntoView()");
            if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
            if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Execute the JavaScript command to scroll the element into view
                AppBase.ExecuteScript("arguments[0].scrollIntoView(true);", this.element);
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
        /// Sets this element's given attribute to the given value.
        /// </summary>
        /// <param name="attributeName">The attribute to set.</param>
        /// <param name="attributeValue">The value to set.</param>
        public void SetAttribute(string attributeName, string attributeValue)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "WebElement.SetAttribute(attributeName, attributeValue)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Attribute Name: " + attributeName);
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Attribute Value: " + attributeValue);
            if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
            if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Execute the JavaScript command to scroll the element into view
                ((IJavaScriptExecutor)this.driver).ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2]);", this.element, attributeName, attributeValue);
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
        /// Presses down the SHIFT key and clicks on this element.
        /// </summary>
        public void ShiftClick()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "WebElement.ShiftClick()");
            if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
            if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // [Shift]+Click this element
                Actions action = new Actions(this.driver);
                action.KeyDown(Keys.LeftShift).Click(element).Build().Perform();
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
        /// Waits for the element to exist.
        /// </summary>
        public void WaitForElement()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "WebElement.WaitForElement()");
            if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
            if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Wait for this element to exist
                WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(TestBase.defaultTimeoutInSeconds));
                wait.Until<Func<IWebDriver, IWebElement>>(
                    d => {
                        return (driver) => { return driver.FindElement(by); };
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
        /// Waits for the element's given attribute to equal the given value.
        /// </summary>
        /// <param name="attributeName">The attribute to check.</param>
        /// <param name="attributeValue">The value to expect.</param>
        public void WaitForElementAttribute(string attributeName, string attributeValue)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "WebElement.WaitForElementAttribute(attributeName, attributeValue)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Attribute Name: " + attributeName);
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Attribute Value: " + attributeValue);
            if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
            if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
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
                    // Try to check the value
                    try
                    {
                        if (this.element.GetAttribute(attributeName) == attributeValue)
                        {
                            // Logging - After action success
                            Log.Success(logPadding.Padding);
                            break;
                        }
                    }
                    catch
                    {
                        /* Do nothing */
                    }
                    if (i == (timeoutIndexMax - 1))
                    {
                        // Logging - After timeout
                        sb.AppendLine(logPadding.InfoPadding + "[ERROR] Timed out waiting for element attribute ('" + attributeName + "') to equal '" + attributeValue + "'");
                        Log.WriteLine(sb.ToString());
                        Assert.Fail(sb.ToString());
                    }
                    // Sleep for 250ms
                    System.Threading.Thread.Sleep(250);
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
        ///  Wait for this element is visible and enabled such that you can click it.
        /// </summary>
        public void WaitForElementToBeClickable()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "WebElement.WaitForElementToBeClickable()");
            if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
            if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Wait for this element to be clickable
                if (this.by != null)
                {
                    WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(TestBase.defaultTimeoutInSeconds));
                    wait.Until<Func<IWebDriver, IWebElement>>(
                    d => {
                        return (driver) =>
                        {
                            var element = ElementIfVisible(driver.FindElement(by));
                            try
                            {
                                if (element != null && element.Enabled)
                                {
                                    return element;
                                }
                                else
                                {
                                    return null;
                                }
                            }
                            catch (StaleElementReferenceException)
                            {
                                return null;
                            }
                        };
                    }
                );
                }
                else
                {
                    // Since this element doesn't have a FindsBy, we'll just wait for a hard-coded duration
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
        /// Waits for the given element's Text to equal the given value.
        /// </summary>
        /// <param name="text">The text to wait for.</param>
        public void WaitForElementTextToEqual(string text)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "WaitForElementTextToEqual(text)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Text: " + text);
            if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
            if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
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
                    // Try to check the value
                    try
                    {
                        if (this.element.Text == text)
                        {
                            // Logging - After action success
                            Log.Success(logPadding.Padding);
                            break;
                        }
                    }
                    catch
                    {
                        /* Do nothing */
                    }
                    if (i == (timeoutIndexMax - 1))
                    {
                        // Logging - After timeout
                        sb.AppendLine(logPadding.InfoPadding + "[ERROR] Timed out waiting for element text  to equal '" + text + "'.");
                        Log.WriteLine(sb.ToString());
                        Assert.Fail(sb.ToString());
                    }
                    // Sleep for 250ms
                    System.Threading.Thread.Sleep(250);
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
        /// Waits for the given element's Text to equal the given value.
        /// </summary>
        /// <param name="text">The text to wait for.</param>
        public void WaitForElementTextToNotEqual(string text)
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "WaitForElementTextToEqual(text)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Text: " + text);
            if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
            if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
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
                    // Try to check the value
                    try
                    {
                        if (this.element.Text != text)
                        {
                            // Logging - After action success
                            Log.Success(logPadding.Padding);
                            break;
                        }
                    }
                    catch
                    {
                        /* Do nothing */
                    }
                    if (i == (timeoutIndexMax - 1))
                    {
                        // Logging - After timeout
                        sb.AppendLine(logPadding.InfoPadding + "[ERROR] Timed out waiting for element text  to equal '" + text + "'.");
                        Log.WriteLine(sb.ToString());
                        Assert.Fail(sb.ToString());
                    }
                    // Sleep for 250ms
                    System.Threading.Thread.Sleep(250);
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
        /// Waits for the element to be displayed with a height and width greater than 0.
        /// </summary>
        public void WaitForElementToBeDisplayed()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "WaitForElementToBeDisplayed(message)");
            if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
            if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Wait until the element is "visible"
                TimeSpan timeout = TimeSpan.FromSeconds(TestBase.defaultTimeoutInSeconds);
                WebDriverWait wait = new WebDriverWait(this.driver, timeout);
                wait.Until<Func<IWebDriver, IWebElement>>(
                    d =>
                    {
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
        /// Waits for the element to exist (via JavaScript).
        /// </summary>
        public void WaitForElementViaJavaScript()
        {
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "WebElement.WaitForElementViaJavaScript()");
            if (this.description != "") { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Description: " + this.description); }
            if (this.by != null) { sb.AppendLine(logPadding.InfoPadding + "[INFO] Element Finds By: " + this.by); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Define the script
                string script = "return ( arguments[0] != null );";
                // Determine the maximum number of iterations (used for timeout)
                int timeoutIndexMax = (TestBase.defaultTimeoutInSeconds * 1000) / 250;
                // Iterate until true or timeout
                for (int i = 0; i < timeoutIndexMax; i++)
                {
                    // Try to execute the script
                    try
                    {
                        // Execute the script and save the result
                        bool result = (bool)((IJavaScriptExecutor)this.driver).ExecuteScript(script, this.element);
                        if (result)
                        {
                            // Logging - After action success
                            Log.Success(logPadding.Padding);
                            break;
                        }
                    }
                    catch
                    {
                        /* Do nothing */
                    }
                    if (i == (timeoutIndexMax - 1))
                    {
                        // Logging - After timeout
                        sb.AppendLine(logPadding.InfoPadding + "[ERROR] Timed out waiting for element to exist.");
                        Log.WriteLine(sb.ToString());
                        Assert.Fail(sb.ToString());
                    }
                    // Sleep for 250ms
                    System.Threading.Thread.Sleep(250);
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

        #endregion Custom SeleniumWebElement Methods

        private static IWebElement ElementIfVisible(IWebElement element)
        {
            return element.Displayed ? element : null;
        }
    }
}
