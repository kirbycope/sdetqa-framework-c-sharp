using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
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
        /// Logs the 'Before Action' info (The method being called and it's properties/parameters).
        /// </summary>
        /// <param name="properties">(Optional) A collection of properties to log ("Method Name" and "Stack Caller" are automatically generated so do not include).</param>
        public static void BeforeAction(OrderedDictionary properties = null)
        {
            // Get the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(2).GetMethod().ReflectedType);
            // Get the method name (of the method that called this one) from the stack
            string methodName = new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()";
            // Get that method's caller from the stack
            string stackCaller = new StackTrace().GetFrame(2).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(2).GetMethod().Name + "()";

            // Write the method name
            Log.WriteLine(logPadding.Padding + methodName);
            if (properties != null)
            {
                // Parse the Dictionary (for properties of the method being logged)
                foreach (DictionaryEntry entry in properties)
                {
                    // Write the property to the log
                    Log.WriteLine(logPadding.InfoPadding + "[INFO] " + entry.Key + " : " + entry.Value);
                }
            }
            // Write the stack caller to the log
            Log.WriteLine(logPadding.InfoPadding + "[STACK] Caller: " + stackCaller);
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
        /// A convenience method for logging a "[RESULT] Failure: {message}".
        /// </summary>
        /// <param name="message">(Optional) The message to display in the log's Result line.</param>
        /// <param name="exception"></param>
        public static void Failure(string message = "", Exception exception = null)
        {
            // Get the padding (if any)
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(2).GetMethod().ReflectedType);
            // Write the line to the log
            if (message != "")
            {
                WriteLine(logPadding.Padding + "[RESULT] Failure: " + message);
            }
            else if (exception != null)
            {
                WriteLine(logPadding.Padding + "[RESULT] Failure: " + exception.Message);
            }
            else
            {
                WriteLine(logPadding.Padding + "[RESULT] Failure!");
            }
            // If there is no padding, then write an end line to sepearte the actions in the log
            if (logPadding.Padding == "")
            {
                Log.WriteLine();
            }
        }

        /// <summary>
        /// Logs a NewLine if there is no padding for the methods logging.
        /// </summary>
        /// <param name="padding">(Optional) The padding used for prepending messages.</param>
        public static void Finally()
        {
            // Get the padding (if any)
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(2).GetMethod().ReflectedType);
            // If there is no padding, then write an end line to sepearte the actions in the log
            if (logPadding.Padding == "")
            {
                WriteLine("");
            }
        }

        /// <summary>
        /// Logs the Test properties from the TestContext. This conatins the NUnit attributes (not custom).
        /// </summary>
        public static void StandardAttributes()
        {
            // Log the current Test's [Description("")]
            try
            {
                Log.WriteLine("[INFO] Test Description: " + TestContext.Get("Description"));
                Log.WriteLine();
            }
            catch { /* do nothing */ }
        }

        /// <summary>
        /// A convenience method for logging a "[RESULT] Success!".
        /// </summary>
        public static void Success(string message = "")
        {
            // Get the padding (if any)
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(2).GetMethod().ReflectedType);
            // Write the line to the log
            if (message != "")
            {
                WriteLine(logPadding.Padding + "[RESULT] Success: " + message);
            }
            else
            {
                WriteLine(logPadding.Padding + "[RESULT] Success!");
            }
            // If there is no padding, then write an end line to sepearte the actions in the log
            if (logPadding.Padding == "")
            {
                Log.WriteLine();
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
