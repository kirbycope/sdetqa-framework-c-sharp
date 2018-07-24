using System;
using System.Collections.Specialized;

namespace FrameworkCommon
{
    public class Sleep
    {
        /// <summary>
        /// Suspends the current thread for the specified number of milliseconds.
        /// </summary>
        /// <param name="milliseconds">The number of milliseconds to sleep.</param>
        /// <param name="reason">The reason for the wait.</param>
        public static void Milliseconds(int milliseconds, string reason = "")
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "Milliseconds", milliseconds },
                { "Reason", reason }
            });

            // Perform the action
            try
            {
                // Suspend the current thread for the specified number of milliseconds
                System.Threading.Thread.Sleep(milliseconds);
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
    }
}
