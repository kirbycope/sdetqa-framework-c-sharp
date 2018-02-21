using FrameworkDesktop;
using TestsForDesktop.POMs;

namespace TestsForDesktop
{
    public class App : AppBase
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
