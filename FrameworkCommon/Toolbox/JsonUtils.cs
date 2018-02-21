using Newtonsoft.Json.Linq;

namespace FrameworkCommon.Toolbox
{
    public class JsonUtils
    {
        /// <summary>
        /// Serializes the JArray into a string.
        /// </summary>
        public string JsonArrayToString(JArray jArray)
        {
            return jArray.ToString();
        }

        /// <summary>
        /// Serializes the JArray into a string.
        /// </summary>
        public string JsonObjectToString(JObject jObject)
        {
            return jObject.ToString();
        }

        /// <summary>
        /// Deserializes the string into a JObject.
        /// </summary>
        public static JArray StringToJsonArray(string jsonString)
        {
            return JArray.Parse(jsonString);
        }

        /// <summary>
        /// Deserializes the string into a JObject.
        /// </summary>
        public static JObject StringToJsonObject(string jsonString)
        {
            return JObject.Parse(jsonString);
        }

        /// <summary>
        /// Gets the value of the given property from the given JSON string.
        /// </summary>
        /// <param name="jsonString">The string representation of the JSON object.</param>
        /// <param name="property">The property for which the value is returned.</param>
        /// <returns>The value of the given property as a string.</returns>
        public static string GetPropertyValueFromJsonString(string jsonString, string property)
        {
            // Convert the string to a JSON object
            JObject settings = StringToJsonObject(jsonString);
            // Return the given property's value
            return settings[property].ToString();
        }
    }
}
