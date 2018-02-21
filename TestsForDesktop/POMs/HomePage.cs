using FrameworkDesktop;
using OpenQA.Selenium;

namespace TestsForDesktop.POMs
{
    public class HomePage
    {
        public HomePage()
        {
            /* empty constructor */
        }

        #region Page Elements

        /// <summary>
        /// The 'SDET' button in the 'Software Development Engineer in Test' card.
        /// </summary>
        public WebElement buttonSdet
        {
            get
            {
                return new WebElement
                (
                    By.CssSelector("body > div > div:nth-child(2) > div:nth-child(1) > div > div.card-body > h4 > a"),
                    "The 'SDET' button in the 'Software Development Engineer in Test' card."
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
            AppBase.GoToUrl("/");
        }

        #endregion Page Specific Methods
    }
}
