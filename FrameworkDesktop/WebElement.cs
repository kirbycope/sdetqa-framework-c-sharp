using FrameworkCommon;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;

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
                // Declare a return value
                bool returnValue = false;

                // Log Before Action
                Log.BeforeAction(new OrderedDictionary() {
                    { "webElement.description", this.description },
                    { "webElement.by", this.by }
                });

                // Perform the action
                try
                {
                    // Get a value indicating whether or not this element is displayed
                    returnValue = this.element.Displayed;
                    // Logging - After action success
                    Log.Success("Displayed: " + returnValue);
                }
                catch (Exception e)
                {
                    // Logging - After action exception
                    Log.Failure(e.Message);
                    // Not being able to tell if the element is displayed is the same as it not being displayed
                    // Fail current test
                    //Assert.Fail(e.Message
                    //    + Environment.NewLine
                    //    + "webElement.description : " + this.description
                    //    + Environment.NewLine
                    //    + "webElement.by : " + this.by
                    //);
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

        /// <summary>
        /// Gets a value indicating whether or not this element is enabled.
        /// </summary>
        public bool Enabled
        {
            get
            {
                // Declare a return value
                bool returnValue = false;

                // Log Before Action
                Log.BeforeAction(new OrderedDictionary() {
                    { "webElement.description", this.description },
                    { "webElement.by", this.by }
                });

                // Perform the action
                try
                {
                    // Gets a value indicating whether or not this element is enabled
                    returnValue = this.element.Enabled;
                    // Logging - After action success
                    Log.Success("Enabled: " + returnValue);
                }
                catch (Exception e)
                {
                    // Logging - After action exception
                    Log.Failure(e.Message);
                    // Fail current test
                    Assert.Fail(e.Message
                        + Environment.NewLine
                        + "webElement.description : " + this.description
                        + Environment.NewLine
                        + "webElement.by : " + this.by
                    );
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

        /// <summary>
        /// Gets a Point object containing the coordinates of the upper-left corner of this element relative to the upper-left corner of the page.
        /// </summary>
        /// <param name="message">(Optional) The message to display if an exception is thrown.</param>
        public Point Location
        {
            get
            {
                // Declare a return value
                Point returnValue = new Point();

                // Log Before Action
                Log.BeforeAction(new OrderedDictionary() {
                    { "webElement.description", this.description },
                    { "webElement.by", this.by }
                });

                // Perform the action
                try
                {
                    // Get a System.Drawing.Point object containing the coordinates of the upper-left corner of this element relative to the upper-left corner of the page
                    returnValue = this.element.Location;
                    // Logging - After action success
                    Log.Success("Location: " + returnValue);
                }
                catch (Exception e)
                {
                    // Logging - After action exception
                    Log.Failure(e.Message);
                    // Fail current test
                    Assert.Fail(e.Message
                        + Environment.NewLine
                        + "webElement.description : " + this.description
                        + Environment.NewLine
                        + "webElement.by : " + this.by
                    );
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

        /// <summary>
        /// Gets a value indicating whether or not this element is selected.
        /// </summary>
        public bool Selected
        {
            get
            {
                // Declare a return value
                bool returnValue = false;

                // Log Before Action
                Log.BeforeAction(new OrderedDictionary() {
                    { "webElement.description", this.description },
                    { "webElement.by", this.by }
                });

                // Perform the action
                try
                {
                    // Get a value indicating whether or not this element is enabled
                    returnValue = this.element.Selected;
                    // Logging - After action success
                    Log.Success("Selected: " + returnValue);
                }
                catch (Exception e)
                {
                    // Logging - After action exception
                    Log.Failure(e.Message);
                    // Fail current test
                    Assert.Fail(e.Message
                        + Environment.NewLine
                        + "webElement.description : " + this.description
                        + Environment.NewLine
                        + "webElement.by : " + this.by
                    );
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

        /// <summary>
        /// Gets a Size object containing the height and width of this element.
        /// </summary>
        public Size Size
        {
            get
            {
                // Declare a return value
                Size returnValue = new Size();

                // Log Before Action
                Log.BeforeAction(new OrderedDictionary() {
                    { "webElement.description", this.description },
                    { "webElement.by", this.by }
                });

                // Perform the action
                try
                {
                    // Get a OpenQA.Selenium.IWebElement.Size object containing the height and width of this element
                    returnValue = this.element.Size;
                    // Logging - After action success
                    Log.Success("Size: " + returnValue);
                }
                catch (Exception e)
                {
                    // Logging - After action exception
                    Log.Failure(e.Message);
                    // Fail current test
                    Assert.Fail(e.Message
                        + Environment.NewLine
                        + "webElement.description : " + this.description
                        + Environment.NewLine
                        + "webElement.by : " + this.by
                    );
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

        /// <summary>
        /// Gets the tag name of this element.
        /// </summary>
        public string TagName
        {
            get
            {
                // Declare a return value
                string returnValue = "";

                // Log Before Action
                Log.BeforeAction(new OrderedDictionary() {
                    { "webElement.description", this.description },
                    { "webElement.by", this.by }
                });

                // Perform the action
                try
                {
                    // Get the tag name of this element
                    returnValue = this.element.TagName;
                    // Logging - After action success
                    Log.Success("Tag Name: " + returnValue);
                }
                catch (Exception e)
                {
                    // Logging - After action exception
                    Log.Failure(e.Message);
                    // Fail current test
                    Assert.Fail(e.Message
                        + Environment.NewLine
                        + "webElement.description : " + this.description
                        + Environment.NewLine
                        + "webElement.by : " + this.by
                    );
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

        /// <summary>
        /// Gets the innerText of this element, without any leading or trailing whitespace, and with other whitespace collapsed.
        /// </summary>
        public string Text
        {
            get
            {
                // Declare a return value
                string returnValue = "";

                // Log Before Action
                Log.BeforeAction(new OrderedDictionary() {
                    { "webElement.description", this.description },
                    { "webElement.by", this.by }
                });

                // Perform the action
                try
                {
                    // Gets the innerText of this element, without any leading or trailing whitespace, and with other whitespace collapsed.
                    returnValue = this.element.Text;
                    // Logging - After action success
                    Log.Success("Text: " + returnValue);
                }
                catch (Exception e)
                {
                    // Logging - After action exception
                    Log.Failure(e.Message);
                    // Fail current test
                    Assert.Fail(e.Message
                        + Environment.NewLine
                        + "webElement.description : " + this.description
                        + Environment.NewLine
                        + "webElement.by : " + this.by
                    );
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

        #endregion SeleniumWebElement Properties (Overrides for OpenQA.Selenium.IWebElement properties)

        #region SeleniumWebElement Methods (Overrides for OpenQA.Selenium.IWebElement methods)

        /// <summary>
        /// Clears the content of this element.
        /// </summary>
        public void Clear()
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by }
            });

            // Perform the action
            try
            {
                // Clear the content of this element.
                this.element.Clear();
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
                    + "webElement.description : " + this.description
                    + Environment.NewLine
                    + "webElement.by : " + this.by
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Clicks this element.
        /// </summary>
        public void Click()
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by }
            });

            // Perform the action
            try
            {
                // Wait for the element to be clickable
                WaitForElementToBeClickable();
                // Click this element.
                this.element.Click();
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
                    + "webElement.description : " + this.description
                    + Environment.NewLine
                    + "webElement.by : " + this.by
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Finds the first IWebElement using the given method.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>The first matching WebElement on the current context.</returns>
        public WebElement FindElement(By by, string description = "")
        {
            // Declare an empty object to hold the return value
            WebElement returnValue = null;

            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by },
                { "FindBy", by},
                { "Description", description },
            });

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
                Log.Success();
            }
            catch (Exception e)
            {
                // Logging - After action exception
                Log.Failure(e.Message);
                // Fail current test
                Assert.Fail(e.Message
                    + Environment.NewLine
                    + "webElement.description : " + this.description
                    + Environment.NewLine
                    + "webElement.by : " + this.by
                    + Environment.NewLine
                    + "FindBy : " + by
                    + Environment.NewLine
                    + "Description : " + description
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }

            // Return the return value
            return returnValue;
        }

        /// <summary>
        /// Finds all IWebElements within the current context using the given mechanism.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>A ReadOnlyCollection of all WebElements matching the current criteria, or an empty list if nothing matches.</returns>
        public IList<WebElement> FindElements(By by, string description = "")
        {
            // Declare an empty object to hold the return value
            IList<WebElement> returnValue = new List<WebElement>();

            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by },
                { "FindBy", by },
                { "Description", description },
            });

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
                Log.Success("Elements Found: " + returnValue.Count);
            }
            catch (Exception e)
            {
                // Logging - After action exception
                Log.Failure(e.Message);
                // Fail current test
                Assert.Fail(e.Message
                    + Environment.NewLine
                    + "webElement.description : " + this.description
                    + Environment.NewLine
                    + "webElement.by : " + this.by
                    + Environment.NewLine
                    + "FindBy : " + by
                    + Environment.NewLine
                    + "Description : " + description
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
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
            // Declare an empty object to hold the return value
            string returnValue = null;

            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by },
                { "Attribute Name", attributeName }
            });

            // Perform the action
            try
            {
                // Get the value of the given attribute name
                returnValue = this.element.GetAttribute(attributeName);
                // Logging - After action success
                Log.Success("Attribute Value: " + returnValue);
            }
            catch (Exception e)
            {
                // Logging - After action exception
                Log.Failure(e.Message);
                // Fail current test
                Assert.Fail(e.Message
                    + Environment.NewLine
                    + "webElement.description : " + this.description
                    + Environment.NewLine
                    + "webElement.by : " + this.by
                    + Environment.NewLine
                    + "Attribute Name : " + attributeName
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
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
            // Declare an empty object to hold the return value
            string returnValue = null;

            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by },
                { "Property Name", propertyName }
            });

            // Perform the action
            try
            {
                // Get the value of the given CSS property
                returnValue = this.element.GetCssValue(propertyName);
                // Logging - After action success
                Log.Success("Property Value: " + returnValue);
            }
            catch (Exception e)
            {
                // Logging - After action exception
                Log.Failure(e.Message);
                // Fail current test
                Assert.Fail(e.Message
                    + Environment.NewLine
                    + "webElement.description : " + this.description
                    + Environment.NewLine
                    + "webElement.by : " + this.by
                    + "Property Name : " + propertyName
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
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
            // Declare an empty object to hold the return value
            string returnValue = null;

            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by },
                { "Property Name", propertyName }
            });

            // Perform the action
            try
            {
                // Get the value of a JavaScript property of this element.
                returnValue = this.element.GetProperty(propertyName);
                // Logging - After action success
                Log.Success("Property Value: " + returnValue);
            }
            catch (Exception e)
            {
                // Logging - After action exception
                Log.Failure(e.Message);
                // Fail current test
                Assert.Fail(e.Message
                    + Environment.NewLine
                    + "webElement.description : " + this.description
                    + Environment.NewLine
                    + "webElement.by : " + this.by
                    + Environment.NewLine
                    + "Property Name : " + propertyName
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
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
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by },
                { "Text", text }
            });

            // Perform the action
            try
            {
                // Simulate typing text into the element
                this.element.SendKeys(text);
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
                    + "webElement.description : " + this.description
                    + Environment.NewLine
                    + "webElement.by : " + this.by
                    + Environment.NewLine
                    + "Text : " + text
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Submits this element to the web server.
        /// </summary>
        public void Submit()
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by }
            });

            // Perform the action
            try
            {
                // Submit this form
                this.element.Submit();
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
                    + "webElement.description : " + this.description
                    + Environment.NewLine
                    + "webElement.by : " + this.by
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        #endregion SeleniumWebElement Methods (Overrides for OpenQA.Selenium.IWebElement methods)

        #region Custom SeleniumWebElement Methods

        /// <summary>
        /// Presses down the ALT key and clicks on this element.
        /// </summary>
        public void AltClick()
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by }
            });

            // Perform the action
            try
            {
                // [Alt]+Click this element
                Actions action = new Actions(this.driver);
                action.KeyDown(Keys.LeftAlt).Click(element).Build().Perform();
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
                    + "webElement.description : " + this.description
                    + Environment.NewLine
                    + "webElement.by : " + this.by
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Clicks this element via JavaScript.
        /// </summary>
        public void ClickViaJavaScript()
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by }
            });

            // Perform the action
            try
            {
                // Execute JavaScript in the context of the currently selected frame or window
                AppBase.ExecuteScript("arguments[0].click()", this.element);
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
                    + "webElement.description : " + this.description
                    + Environment.NewLine
                    + "webElement.by : " + this.by
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Clicks this element using the offsets.
        /// </summary>
        /// <param name="xOffset">If positive, then clicks to the right.</param>
        /// <param name="yOffset">If positive, then clicks to the bottom.</param>
        public void ClickWithOffset(int xOffset, int yOffset)
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by }
            });

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
                Log.Success();
            }
            catch (Exception e)
            {
                // Logging - After action exception
                Log.Failure(e.Message);
                // Fail current test
                Assert.Fail(e.Message
                    + Environment.NewLine
                    + "webElement.description : " + this.description
                    + Environment.NewLine
                    + "webElement.by : " + this.by
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Presses down the CTRL key and clicks on this element.
        /// </summary>
        public void CtrlClick()
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by }
            });

            // Perform the action
            try
            {
                // [Ctrl]+Click this element
                Actions action = new Actions(this.driver);
                action.KeyDown(Keys.LeftControl).Click(element).Build().Perform();
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
                    + "webElement.description : " + this.description
                    + Environment.NewLine
                    + "webElement.by : " + this.by
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Drags this element to the given element.
        /// </summary>
        /// <param name="targetElement">The element to drag this element to.</param>
        public void DragTo(WebElement targetElement)
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by }
            });

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
                Log.Success();
            }
            catch (Exception e)
            {
                // Logging - After action exception
                Log.Failure(e.Message);
                // Fail current test
                Assert.Fail(e.Message
                    + Environment.NewLine
                    + "webElement.description : " + this.description
                    + Environment.NewLine
                    + "webElement.by : " + this.by
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Hovers over this element.
        /// </summary>
        public void Hover()
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by }
            });

            // Perform the action
            try
            {
                // Perform "hover" action
                Actions action = new Actions(this.driver);
                action.MoveToElement(element).Perform();
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
                    + "webElement.description : " + this.description
                    + Environment.NewLine
                    + "webElement.by : " + this.by
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Hovers over this element and then clicks it.
        /// </summary>
        public void HoverAndClick()
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by }
            });

            // Perform the action
            try
            {
                // Move the mouse to the element and click
                Actions action = new Actions(this.driver);
                action.MoveToElement(element).Click().Perform();
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
                    + "webElement.description : " + this.description
                    + Environment.NewLine
                    + "webElement.by : " + this.by
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Right-clicks this element.
        /// </summary>
        public void RightClick()
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by }
            });

            // Perform the action
            try
            {
                // Perform "right-click" action
                Actions action = new Actions(this.driver).ContextClick(this.element);
                action.Build().Perform();
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
                    + "webElement.description : " + this.description
                    + Environment.NewLine
                    + "webElement.by : " + this.by
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Right-clicks this element via JavaScript.
        /// </summary>
        public void RightClickViaJavaScript()
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by }
            });

            // Perform the action
            try
            {
                // Define the script
                string script = "$( arguments[0] ).trigger({ type: 'mousedown', which: 3})";
                // Execute JavaScript in the context of the currently selected frame or window
                AppBase.ExecuteScript(script);
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
                    + "webElement.description : " + this.description
                    + Environment.NewLine
                    + "webElement.by : " + this.by
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// The Element.scrollIntoView() method scrolls the element on which it's called into the visible area of the browser window.
        /// </summary>
        public void ScrollIntoView()
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by }
            });

            // Perform the action
            try
            {
                // Execute the JavaScript command to scroll the element into view
                AppBase.ExecuteScript("arguments[0].scrollIntoView(true);", this.element);
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
                    + "webElement.description : " + this.description
                    + Environment.NewLine
                    + "webElement.by : " + this.by
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Sets this element's given attribute to the given value.
        /// </summary>
        /// <param name="attributeName">The attribute to set.</param>
        /// <param name="attributeValue">The value to set.</param>
        public void SetAttribute(string attributeName, string attributeValue)
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by },
                { "Attribute Name", attributeName },
                { "Attribute Value", attributeValue }
            });

            // Perform the action
            try
            {
                // Execute the JavaScript command to scroll the element into view
                ((IJavaScriptExecutor)this.driver).ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2]);", this.element, attributeName, attributeValue);
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
                    + "webElement.description : " + this.description
                    + Environment.NewLine
                    + "webElement.by : " + this.by
                    + Environment.NewLine
                    + "Attribute Name : " + attributeName
                    + Environment.NewLine
                    + "Attribute Value : " + attributeValue
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Presses down the SHIFT key and clicks on this element.
        /// </summary>
        public void ShiftClick()
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by }
            });

            // Perform the action
            try
            {
                // [Shift]+Click this element
                Actions action = new Actions(this.driver);
                action.KeyDown(Keys.LeftShift).Click(element).Build().Perform();
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
                    + "webElement.description : " + this.description
                    + Environment.NewLine
                    + "webElement.by : " + this.by
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Waits for the element to exist.
        /// </summary>
        public void WaitForElement()
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by }
            });

            // Perform the action
            try
            {
                // Wait for this element to exist
                WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(TestBase.defaultTimeoutInSeconds));
                wait.Until<IWebElement>((driver) => { return driver.FindElement(by); });
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
                    + "webElement.description : " + this.description
                    + Environment.NewLine
                    + "webElement.by : " + this.by
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Waits for the element's given attribute to equal the given value.
        /// </summary>
        /// <param name="attributeName">The attribute to check.</param>
        /// <param name="attributeValue">The value to expect.</param>
        public void WaitForElementAttribute(string attributeName, string attributeValue)
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by },
                { "Attribute Name", attributeName},
                { "Attribute Value", attributeValue }
            });

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
                            Log.Success();
                            break;
                        }
                    }
                    catch
                    {
                        /* Do nothing */
                    }
                    if (i == (timeoutIndexMax - 1))
                    {
                        throw new TimeoutException("Timed out waiting for element attribute ('" + attributeName + "') to equal '" + attributeValue + "'");
                    }
                    // Sleep for 250ms
                    System.Threading.Thread.Sleep(250);
                }
            }
            catch (Exception e)
            {
                // Logging - After action exception
                Log.Failure(e.Message);
                // Fail current test
                Assert.Fail(e.Message
                    + Environment.NewLine
                    + "webElement.description : " + this.description
                    + Environment.NewLine
                    + "webElement.by : " + this.by
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        ///  Wait for this element is visible and enabled such that you can click it.
        /// </summary>
        public void WaitForElementToBeClickable()
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by }
            });

            // Perform the action
            try
            {
                // Wait for this element to be clickable
                if (this.by != null)
                {
                    WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(TestBase.defaultTimeoutInSeconds));
                    wait.Until<IWebElement>(
                        (driver) =>
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
                        });
                }
                else
                {
                    // Since this element doesn't have a FindsBy, we'll just wait for a hard-coded duration
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
                    + "webElement.description : " + this.description
                    + Environment.NewLine
                    + "webElement.by : " + this.by
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Waits for the given element's Text to equal the given value.
        /// </summary>
        /// <param name="text">The text to wait for.</param>
        public void WaitForElementTextToEqual(string text)
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by },
                { "Text", text}
            });

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
                            Log.Success();
                            break;
                        }
                    }
                    catch
                    {
                        /* Do nothing */
                    }
                    if (i == (timeoutIndexMax - 1))
                    {
                        throw new TimeoutException("[ERROR] Timed out waiting for element text  to equal '" + text + "'.");
                    }
                    // Sleep for 250ms
                    System.Threading.Thread.Sleep(250);
                }
            }
            catch (Exception e)
            {
                // Logging - After action exception
                Log.Failure(e.Message);
                // Fail current test
                Assert.Fail(e.Message
                    + Environment.NewLine
                    + "webElement.description : " + this.description
                    + Environment.NewLine
                    + "webElement.by : " + this.by
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Waits for the given element's Text to equal the given value.
        /// </summary>
        /// <param name="text">The text to wait for.</param>
        public void WaitForElementTextToNotEqual(string text)
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by },
                { "Text", text}
            });

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
                            Log.Success();
                            break;
                        }
                    }
                    catch
                    {
                        /* Do nothing */
                    }
                    if (i == (timeoutIndexMax - 1))
                    {
                        throw new TimeoutException("[ERROR] Timed out waiting for element text  to equal '" + text + "'.");
                    }
                    // Sleep for 250ms
                    System.Threading.Thread.Sleep(250);
                }
            }
            catch (Exception e)
            {
                // Logging - After action exception
                Log.Failure(e.Message);
                // Fail current test
                Assert.Fail(e.Message
                    + Environment.NewLine
                    + "webElement.description : " + this.description
                    + Environment.NewLine
                    + "webElement.by : " + this.by
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Waits for the element to be displayed with a height and width greater than 0.
        /// </summary>
        public void WaitForElementToBeDisplayed()
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by }
            });

            // Perform the action
            try
            {
                // Wait until the element is "visible"
                TimeSpan timeout = TimeSpan.FromSeconds(TestBase.defaultTimeoutInSeconds);
                WebDriverWait wait = new WebDriverWait(this.driver, timeout);
                wait.Until<IWebElement>(
                    (driver) =>
                    {
                        try
                        {
                            return ElementIfVisible(driver.FindElement(by));
                        }
                        catch (StaleElementReferenceException)
                        {
                            return null;
                        }
                    });
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
                    + "webElement.description : " + this.description
                    + Environment.NewLine
                    + "webElement.by : " + this.by
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Waits for the element not to be visiable with a height and width greater than 0.
        /// </summary>
        public void WaitForElementNotToBeDisplayed()
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by }
            });

            // Perform the action
            try
            {
                // Wait until the element is not visible
                TimeSpan timeout = TimeSpan.FromSeconds(TestBase.defaultTimeoutInSeconds);
                WebDriverWait wait = new WebDriverWait(this.driver, timeout);
                wait.Until<IWebElement>(
                    (driver) =>
                    {
                        try
                        {
                            return ElementNotVisible(driver.FindElement(by));
                        }
                        catch (StaleElementReferenceException)
                        {
                            return null;
                        }
                    });
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
                    + "webElement.description : " + this.description
                    + Environment.NewLine
                    + "webElement.by : " + this.by
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Waits for the element to exist (via JavaScript).
        /// </summary>
        public void WaitForElementViaJavaScript()
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by }
            });

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
                            Log.Success();
                            break;
                        }
                    }
                    catch
                    {
                        /* Do nothing */
                    }
                    if (i == (timeoutIndexMax - 1))
                    {
                        throw new TimeoutException("Timed out waiting for element to exist.");
                    }
                    // Sleep for 250ms
                    System.Threading.Thread.Sleep(250);
                }
            }
            catch (Exception e)
            {
                // Logging - After action exception
                Log.Failure(e.Message);
                // Fail current test
                Assert.Fail(e.Message
                    + Environment.NewLine
                    + "webElement.description : " + this.description
                    + Environment.NewLine
                    + "webElement.by : " + this.by
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        #endregion Custom SeleniumWebElement Methods

        // https://raw.githubusercontent.com/DotNetSeleniumTools/DotNetSeleniumExtras/master/src/WaitHelpers/ExpectedConditions.cs
        private static IWebElement ElementIfVisible(IWebElement element)
        {
            return element.Displayed ? element : null;
        }

        private static IWebElement ElementNotVisible(IWebElement element)
        {
            return !element.Displayed ? element : null;
        }
    }
}
