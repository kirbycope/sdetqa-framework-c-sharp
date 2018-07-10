using System.Collections.Generic;

namespace FrameworkCommon.Toolbox
{
    public class DictionaryUtils
    {
        /// <summary>
        /// Gets the value.ToString() of the given Key for the given dictionary.
        /// </summary>
        /// <param name="dictionary">The Dictionary to parse.</param>
        /// <param name="key">The key for the value being retrieved.</param>
        /// <returns>To Value represented as a string.</returns>
        public static string GetValueString(Dictionary<string, object> dictionary, string key)
        {
            string value = "";
            if (dictionary.ContainsKey(key))
            {
                value = dictionary[key].ToString();
            }
            return value;
        }
    }
}
