using Newtonsoft.Json.Linq;
using System.Data.SqlClient;

namespace FrameworkCommon.Toolbox
{
    public class SqlUtils
    {
        /// <summary>
        /// Executes the given Query and returns a JArray of the data set.
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns>A JArray containing the rows of data returned.</returns>
        public static JArray ExecuteQuery(string connectionString, string queryString)
        {
            JArray jArray = new JArray();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        JObject jObject = new JObject();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            jObject.Add(reader.GetName(i), JToken.FromObject(reader[i]));
                        }
                        jArray.Add(jObject);
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            return jArray;
        }
    }
}
