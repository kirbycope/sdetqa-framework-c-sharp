using FrameworkMobile;
using TestsForMobile.POMs;

namespace TestsForMobile
{
    public class App : AppBaseAndroid
    {
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
