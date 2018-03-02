using System;
using System.Configuration;
using System.Text;

namespace FrameworkCommon
{
    public class Log
    {
        static string _destination;
        static string destination
        {
            get
            {
                if (_destination == null)
                {
                    // Get the logging destination from the App.config. If none found, use "console"
                    _destination = ConfigurationManager.AppSettings["logDestination"] ?? "console";
                }
                return _destination;
            }
        }

        /// <summary>
        /// A convenience method for logging a "[RESULT]/[ERROR]...". 
        /// </summary>
        /// <param name="stringBuilder"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static StringBuilder Exception(StringBuilder stringBuilder, Exception exception)
        {
            // Add the exception message to the StringBuilder
            stringBuilder.AppendLine("[ERROR] Exception: " + exception.Message);
            // Write the StringBuilder to the log
            WriteLine(stringBuilder.ToString());
            // return the StringBuilder
            return stringBuilder;
        }

        /// <summary>
        /// Logs a NewLine if there is no padding for the methods logging.
        /// </summary>
        /// <param name="padding">(Optional) The padding used for prepending messages.</param>
        public static void Finally(string padding = "")
        {
            if (padding == "")
            {
                WriteLine("");
            }
        }

        /// <summary>
        /// A convenience method for logging a "[RESULT] Success!".
        /// </summary>
        /// <param name="padding">(Optional) The whitespace to prepend to the log message.</param>
        public static void Success(string padding = "")
        {
            // If there is padding, the logging method was called by another. So we dont write a newline in the middle of those logs.
            if (padding != "")
            {
                WriteLine(padding + "[RESULT] Success!");
            }
            else
            {
                WriteLine("[RESULT] Success!");
            }
        }

        /// <summary>
        /// Writes the specified string value to the log.
        /// </summary>
        /// <param name="value">The value to write.</param>
        public static void Write(string value = "")
        {
            if (destination == "console")
            {
                Console.Write(value);
            }
            else if (destination == "context")
            {
                // Get the "log" from the current TestContext
                string log = "";
                try
                {
                    log = TestContext.Get("log").ToString();
                }
                catch
                {
                    /* do nothing */
                }
                // Add the new "log line" to the "log"
                log = log + value;
                // Save the new log
                TestContext.Set("log", log);
            }
            else
            {
                throw new NotImplementedException("The destination '" + destination + "' is not setup in Log.WriteLine().");
            }
        }

        /// <summary>
        /// Writes the specified string value, followed by the current line terminator, to the log.
        /// </summary>
        /// <param name="value">The value to write.</param>
        public static void WriteLine(string value = "")
        {
            if (destination == "console")
            {
                Console.WriteLine(value);
            }
            else if (destination == "context")
            {
                // Get the "log" from the current TestContext
                string log = TestContext.Get("log").ToString();
                // Add the new "log line" to the "log"
                log = log + value + Environment.NewLine;
                // Save the new log
                TestContext.Set("log", log);
            }
            else
            {
                throw new NotImplementedException("The destination '" + destination + "' is not setup in Log.WriteLine().");
            }
        }
    }
}
