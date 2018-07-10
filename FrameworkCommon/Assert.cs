using System;
using System.Collections.Specialized;

namespace FrameworkCommon
{
    public class Assert
    {
        #region Comparisons and Conditions

        /// <summary>
        /// Verifies that two objects are equal.
        /// </summary>
        /// <param name="expected">The object that is expected.</param>
        /// <param name="actual">The object to compare.</param>
        /// <param name="message">The message to display in case of failure.</param>
        public static void AreEqual(object expected, object actual, string message = "")
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "Expected", expected },
                { "Actual", actual }
            });

            // Perform the action
            try
            {
                // Verify that two objects are equal
                NUnit.Framework.Assert.AreEqual(expected, actual);
                // Logging - After action success
                Log.Success();
            }
            catch (Exception e)
            {
                // Logging - After action exception
                Log.Failure(message, e);
                // Fail current Test
                Assert.Fail("[ERROR] Exception: " + e.Message);
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Verifies that two objects are not equal.
        /// </summary>
        /// <param name="expected">The objects that is expected.</param>
        /// <param name="actual">The objects value to compare.</param>
        /// <param name="message">The message to display in case of failure.</param>
        public static void AreNotEqual(object expected, object actual, string message = "")
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "Expected", expected },
                { "Actual", actual }
            });

            // Perform the action
            try
            {
                // Verify that two objects are not equal
                NUnit.Framework.Assert.AreNotEqual(expected, actual);
                // Logging - After action success
                Log.Success();
            }
            catch (Exception e)
            {
                // Logging - After action exception
                Log.Failure(message, e);
                // Fail current Test
                Assert.Fail("[ERROR] Exception: " + e.Message);
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        /// <summary>
        /// Verifies that expected string is contained in the actual. Strings are trimmed of white space and cast to lower case.
        /// </summary>
        /// <param name="expected">The value that is expected.</param>
        /// <param name="actual">The actual value.</param>
        /// <param name="message">The message to display in case of failure.</param>
        public static void ContainsText(string expected, string actual, string message = "")
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "Expected", expected },
                { "Actual", actual }
            });

            // Perform the action
            if (actual.Trim().ToLower().Contains(expected.Trim().ToLower()))
            {
                // Logging - After action success
                Log.Success();
                Log.Finally();
            }
            else
            {
                // Logging - After action exception
                Log.Failure(message);
                // Fail current test
                Assert.Fail(message);
            }
        }

        /// <summary>
        /// Verifies that the first value is greater than the second value.
        /// </summary>
        /// <param name="arg1">The first value, expected to be greater.</param>
        /// <param name="arg2">The second value, expected to be less.</param>
        /// <param name="message">The message to display in case of failure.</param>
        public static void Greater(object arg1, object arg2, string message = "")
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "arg1", arg1 },
                { "arg2", arg2 }
            });

            // Perform the action
            if (double.Parse(arg1.ToString()) > double.Parse(arg2.ToString()))
            {
                // Logging - After action success
                Log.Success();
                Log.Finally();
            }
            else
            {
                // Logging - After action exception
                Log.Failure(message);
                // Fail current test
                Assert.Fail(message);
            }
        }

        /// <summary>
        /// Assert that a string is empty - that is equal to string.Empty.
        /// </summary>
        /// <param name="aString">The string to be tested</param>
        /// <param name="message">The message to display in case of failure</param>
        public static void IsEmpty(string aString, string message = "")
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "String", aString }
            });

            // Perform the action
            if (aString == string.Empty)
            {
                // Logging - After action success
                Log.Success();
                Log.Finally();
            }
            else
            {
                // Logging - After action exception
                Log.Failure(message);
                // Fail current test
                Assert.Fail(message);
            }
        }

        /// <summary>
        /// Assert that a string is not empty - that is not equal to string.Empty.
        /// </summary>
        /// <param name="aString">The string to be tested.</param>
        /// <param name="message">The message to display in case of failure.</param>
        public static void IsNotEmpty(string aString, string message = "")
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "String", aString }
            });

            // Perform the action
            if (aString != string.Empty)
            {
                // Logging - After action success
                Log.Success();
                Log.Finally();
            }
            else
            {
                // Logging - After action exception
                Log.Failure(message);
                // Fail current test
                Assert.Fail(message);
            }
        }

        /// <summary>
        /// Asserts that a condition is false.
        /// </summary>
        /// <param name="condition">The evaluated condition.</param>
        /// <param name="message">The message to display in case of failure.</param>
        public static void IsFalse(bool condition, string message = "")
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "Condition", condition }
            });

            // Perform the action
            if (condition == false)
            {
                // Logging - After action success
                Log.Success();
                Log.Finally();
            }
            else
            {
                // Logging - After action exception
                Log.Failure(message);
                // Fail current test
                Assert.Fail(message);
            }
        }

        /// <summary>
        /// Asserts that a condition is true.
        /// </summary>
        /// <param name="condition">The evaluated condition.</param>
        /// <param name="message">The message to display in case of failure.</param>
        public static void IsTrue(bool condition, string message = "")
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "Condition", condition }
            });

            // Perform the action
            if (condition)
            {
                // Logging - After action success
                Log.Success();
                Log.Finally();
            }
            else
            {
                // Logging - After action exception
                Log.Failure(message);
                // Fail current test
                Assert.Fail(message);
            }
        }

        /// <summary>
        /// Verifies that the object that is passed in is equal to null.
        /// </summary>
        /// <param name="anObject">The object that is to be tested.</param>
        /// <param name="message">The message to display in case of failure.</param>
        public static void IsNull(object anObject, string message = "")
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "anObject", anObject }
            });

            // Perform the action
            if (anObject == null)
            {
                // Logging - After action success
                Log.Success();
                Log.Finally();
            }
            else
            {
                // Logging - After action exception
                Log.Failure(message);
                // Fail current test
                Assert.Fail(message);
            }
        }

        /// <summary>
        /// Verifies that the object that is passed in is not equal to null.
        /// </summary>
        /// <param name="anObject">The object that is to be tested.</param>
        /// <param name="message">The message to display in case of failure.</param>
        public static void IsNotNull(object anObject, string message = "")
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "anObject", anObject }
            });

            // Perform the action
            if (anObject != null)
            {
                // Logging - After action success
                Log.Success();
                Log.Finally();
            }
            else
            {
                // Logging - After action exception
                Log.Failure(message);
                // Fail current test
                Assert.Fail(message);
            }
        }

        /// <summary>
        /// Verifies that the first value is less than the second value.
        /// </summary>
        /// <param name="arg1">The first value, expected to be less.</param>
        /// <param name="arg2">The second value, expected to be greater.</param>
        /// <param name="message">The message to display in case of failure.</param>
        public static void Less(object arg1, object arg2, string message = "")
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "arg1", arg1 },
                { "arg2", arg2 }
            });

            // Perform the action
            if (double.Parse(arg1.ToString()) < double.Parse(arg2.ToString()))
            {
                // Logging - After action success
                Log.Success();
                Log.Finally();
            }
            else
            {
                // Logging - After action exception
                Log.Failure(message);
                // Fail current test
                Assert.Fail(message);
            }
        }

        /// <summary>
        /// Asserts that a value is not zero.
        /// </summary>
        /// <param name="value">The number to be examined.</param>
        /// <param name="message">The message to display in case of failure.</param>
        public static void NotZero(object value, string message = "")
        {
            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "Value", value }
            });

            // Perform the action
            if (double.Parse(value.ToString()) == 0)
            {
                // Logging - After action success
                Log.Success();
                Log.Finally();
            }
            else
            {
                // Logging - After action exception
                Log.Failure(message);
                // Fail current test
                Assert.Fail(message);
            }
        }

        #endregion Comparisons and Conditions

        #region Test Result Methods

        /// <summary>
        /// Throws an NUnit.Framework.AssertionException with the message that is passed in.
        /// This is used by the other Assert functions.
        /// </summary>
        /// <param name="message">The message to initialize the NUnit.Framework.AssertionException with.</param>
        public static void Fail(string message = "")
        {
            NUnit.Framework.Assert.Fail(message);
        }

        /// <summary>
        /// Throws an NUnit.Framework.IgnoreException with the message that is passed in.
        ///  This causes the test to be reported as ignored.
        /// </summary>
        /// <param name="message">The message to initialize the NUnit.Framework.AssertionException with.</param>
        public static void Ignore(string message = "")
        {
            NUnit.Framework.Assert.Ignore(message);
        }

        /// <summary>
        /// Throws a NUnit.Framework.SuccessException with the message and arguments that are passed in.
        /// This allows a test to be cut short, with a result of success returned to NUnit.
        /// </summary>
        /// <param name="message">The message to initialize the NUnit.Framework.AssertionException with.</param>
        public static void Pass(string message = "")
        {
            NUnit.Framework.Assert.Pass(message);
        }

        #endregion Test Result Methods
    }
}
