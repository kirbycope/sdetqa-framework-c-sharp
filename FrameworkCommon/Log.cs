using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
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
        /// Logs a select few Attributes (defined in this method and in FrameworkCommon.Attributes).
        /// </summary>
        /// <param name="customAttributeDatas">The Attributes to parse.</param>
        public static void CustomAttributes(IEnumerable<CustomAttributeData> customAttributeDatas)
        {
            // Parse the collection
            CustomAttributeData descriptionAttribute = null;
            CustomAttributeData automatesAttribute = null;
            CustomAttributeData automatedByAttribute = null;
            foreach (CustomAttributeData customAttributeData in customAttributeDatas)
            {
                // Convert the object to JSON for easy parsing
                JObject jObject = JObject.FromObject(customAttributeData);
                // Check each CustomAttributeData for a value containing "NUnit.Framework.DescriptionAttribute"
                foreach (var kvp in jObject)
                {
                    // Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
                    if (kvp.Value.ToString().Contains("NUnit.Framework.DescriptionAttribute"))
                    {
                        descriptionAttribute = customAttributeData;
                    }
                    else if (kvp.Value.ToString().Contains(".Automates"))
                    {
                        automatesAttribute = customAttributeData;
                    }
                    else if (kvp.Value.ToString().Contains(".AutomatedBy"))
                    {
                        automatedByAttribute = customAttributeData;
                    }
                    // Stop parsing if we have found what we were looking for
                    if ((descriptionAttribute != null) && (automatesAttribute != null))
                    {
                        break;
                    }
                }
            }
            // Log the current Test's [Description("")]
            try { Log.WriteLine("[INFO] Test Description: " + descriptionAttribute.ConstructorArguments[0].Value.ToString()); }
            catch { /* do nothing */ }
            // Log the current Test's [Automates("")]
            try { Log.WriteLine("[INFO] Test Automates: " + automatesAttribute.ConstructorArguments[0].Value.ToString()); }
            catch { /* do nothing */ }
            // Log the current Test's [AutomatedBy("")]
            try { Log.WriteLine("[INFO] Test AutomatedBy: " + automatedByAttribute.ConstructorArguments[0].Value.ToString()); }
            catch { /* do nothing */ }
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
