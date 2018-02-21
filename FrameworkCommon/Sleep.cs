using System;
using System.Diagnostics;
using System.Text;

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
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "Sleep.Milliseconds(milliseconds, reason?)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Milliseconds: " + milliseconds);
            if (reason != "") { sb.AppendLine(logPadding.InfoPadding + "[PARAM] Reason: " + reason); }
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Suspend the current thread for the specified number of milliseconds
                System.Threading.Thread.Sleep(milliseconds);
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
    }
}
