namespace FrameworkCommon
{
    public class TestContext
    {
        /// <summary>
        /// Gets a single value for a key, using the first one if multiple values are present and returning null if the value is not found.
        /// </summary>
        public static object Get(string key)
        {
            return NUnit.Framework.TestContext.CurrentContext.Test.Properties.Get(key);
        }

        /// <summary>
        /// Sets the value for a key, removing any other values that are already in the property set.
        /// </summary>
        public static void Set(string key, object value)
        {
            NUnit.Framework.Internal.TestExecutionContext.CurrentContext.CurrentTest.Properties.Set(key, value);
        }
    }
}
