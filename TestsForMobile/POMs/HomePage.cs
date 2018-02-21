using FrameworkMobile;
using OpenQA.Selenium;

namespace TestsForMobile.POMs
{
    public class HomePage
    {
        public HomePage()
        {
            /* empty constructor */
        }

        #region Page Elements

        /// <summary>
        /// Element description.
        /// </summary>
        public WebElement webElement
        {
            get
            {
                return new WebElement
                (
                    By.XPath(""),
                    "Element description."
                );
            }
        }

        #endregion Page Elements

        #region Page Specific Methods

        /// <summary>
        /// Open the 'Home' page.
        /// </summary>
        public void Open()
        {
            // To open the 'Home' page, we must simply start the test.
            // The [SetUp] (in TestBase.cs) will have restarted the app first.
        }

        #endregion Page Specific Methods
    }
}
