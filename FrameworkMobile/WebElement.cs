using FrameworkCommon;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions.Internal;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;

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
                    _element = AppBase.Driver.FindElement(this.by);
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
                // Declare a return value
                ICoordinates returnValue = null;

                // Log Before Action
                Log.BeforeAction(new OrderedDictionary() {
                    { "webElement.description", this.description },
                    { "webElement.by", this.by }
                });

                // Perform the action
                try
                {
                    // Get the coordinates identifying the location of this element using various frames of reference
                    returnValue = this.element.Coordinates;
                    // Logging - After action success
                    Log.Success("Coordinates " + returnValue);
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
                        + "webElement.by" + this.by
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
        /// Returns true if element is present and have some dimensions greater than 0
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
                    //// Fail current test
                    //Assert.Fail(e.Message
                    //    + Environment.NewLine
                    //    + "webElement.description : " + this.description
                    //    + Environment.NewLine
                    //    + "webElement.by" + this.by
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
        /// Whether the element is enabled or not.
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
                    // Get a value indicating whether or not this element is enabled
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
                        + "webElement.by" + this.by
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
        /// The identifier of the view element. For Android: The id of the element. For iOS: The accessibilityIdentifier of the element.
        /// </summary>
        public string Id
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
                    // Get the ID of this element
                    returnValue = this.element.Id;
                    // Logging - After action success
                    Log.Success("ID: " + returnValue);
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
                        + "webElement.by" + this.by
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
        /// Gets a System.Drawing.Point object containing the coordinates of the upper-left 
        /// corner of this element relative to the upper-left corner of the page.
        /// </summary>
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
                    Log.Success("Location " + returnValue);
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
                        + "webElement.by" + this.by
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
                    // Get a value indicating whether or not this element is selected
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
                        + "webElement.by" + this.by
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
        /// The Size (Height, Width) of this element.
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
                    // Get a OpenQA.Selenium.Remote.RemoteWebElement.Size object containing the height and width of this element
                    returnValue = this.element.Size;
                    // Logging - After action success
                    Log.Success("Size " + returnValue);
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
                        + "webElement.by" + this.by
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
                // Logging - Before action

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
                    Log.Success("Tag Name " + returnValue);
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
                        + "webElement.by" + this.by
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
        /// The text of the view element.
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
                    // Get the innerText of this element, without any leading or trailing whitespace, and with other whitespace collapsed
                    returnValue = this.element.Text;
                    // Logging - After action success
                    Log.Success("Text " + returnValue);
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
                        + "webElement.by" + this.by
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

        #endregion AppiumWebElement Properties

        #region  AppiumWebElement Methods (Overrides for OpenQA.Selenium.Appium.AppiumWebElement)

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
                    + "webElement.by" + this.by
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
        public WebElement FindElement(By by)
        {
            // Declare an empty object to hold the return value
            WebElement returnValue = null;

            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by },
                { "FindBy", by }
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
                    + "webElement.by" + this.by
                    + Environment.NewLine
                    + "FindBy : " + by
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
        public IList<WebElement> FindElements(By by)
        {
            // Declare an empty object to hold the return value
            IList<WebElement> returnValue = new List<WebElement>();

            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by },
                { "FindBy", by }
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
                    + "webElement.by" + this.by
                    + Environment.NewLine
                    + "FindBy : " + by
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
                    + "webElement.by" + this.by
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
                { "Property Name", propertyName}
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
                    + "webElement.by" + this.by
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
                    + "webElement.by" + this.by
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
                    + "webElement.by" + this.by
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
                    + "webElement.by" + this.by
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Performs a tap/touch gesture on the matched element.
        /// If multiple elements are matched, the first one will be used.
        /// </summary>
        public void Tap()
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by }
            });

            // Perform the action
            try
            {
                // Tap the center of the given element
                this.element.Tap(1, 250);
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
                    + "webElement.by" + this.by
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
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
                    if (this.by != null)
                    {
                        returnValue = AppBase.Driver.FindElement(this.by).GetAttribute("content-desc");
                    }
                    else
                    {
                        returnValue = this.element.GetAttribute("content-desc");
                    }
                    // Logging - After action success
                    Log.Success("Label: " + returnValue);
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
                        + "webElement.by" + this.by
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
        /// The Parent element of this element.
        /// </summary>
        public WebElement Parent
        {
            get
            {
                // Declare a return value
                WebElement returnValue = null;

                // Log Before Action
                Log.BeforeAction(new OrderedDictionary() {
                    { "webElement.description", this.description },
                    { "webElement.by", this.by }
                });

                // Perform the action
                try
                {
                    returnValue = new WebElement
                    (
                        AppBase.Driver.FindElement(this.by).FindElement(By.XPath("//..")),
                        description
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
                        + "webElement.by" + this.by
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
        /// The Sibling element of this element.
        /// </summary>
        public WebElement Sibling
        {
            get
            {
                // Declare a return value
                WebElement returnValue = null;

                // Log Before Action
                Log.BeforeAction(new OrderedDictionary() {
                    { "webElement.description", this.description },
                    { "webElement.by", this.by }
                });

                // Perform the action
                try
                {
                    returnValue = new WebElement
                    (
                        AppBase.Driver.FindElement(this.by).FindElement(By.XPath("//following-sibling::*")),
                        description
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

        #endregion Custom AppiumWebElement Properties

        #region Custom AppiumWebElement Methods

        /// <summary>
        /// Wait function that will repeatly query the app until a matching element is found.
        /// Throws a System.TimeoutException if no element is found within the time limit.
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
                if (this.by != null)
                {
                    AppBase.WaitForElementToBeDisplayed(this.by);
                }
                else
                {
                    AppBase.WaitForElementToBeDisplayed(this.element);
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
                    + "webElement.by" + this.by
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Wait function that will repeatly query the app until a matching element is not found.
        /// </summary>
        public void WaitForElementNotDisplayed()
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "webElement.description", this.description },
                { "webElement.by", this.by }
            });

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
                    + "webElement.by" + this.by
                );
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        #endregion Custom AppiumWebElement Methods
    }
}
