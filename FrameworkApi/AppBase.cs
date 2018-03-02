using FrameworkCommon;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using TestContext = FrameworkCommon.TestContext;

namespace FrameworkApi
{
    public class AppBase
    {
        #region App Properties
        
        /// <summary>
        /// Provides a base class for sending HTTP requests and receiving HTTP responses from a resource identified by a URI.
        /// </summary>
        protected static HttpClient httpClient
        {
            get
            {
                return (HttpClient)TestContext.Get("httpClient");
            }
        }

        #endregion App Properties

        #region App Methods

        /// <summary>
        /// Send an HTTP request and returns the result.
        /// </summary>
        /// <param name="method">The HTTP method.</param>
        /// <param name="requestUri">A string that represents the request System.Uri.</param>
        /// <param name="content">(Optional) The content of the HTTP message.</param>
        /// <returns>A HTTP response message including the status code and data.</returns>
        public static HttpResponseMessage MakeRequest(HttpMethod method, string requestUri, HttpContent content = null)
        {
            // Declare an empty object to hold the return value
            HttpResponseMessage returnValue = null;
            // Figure out the padding (if any) to prepend to the log line
            LogPadding logPadding = new LogPadding(new StackTrace().GetFrame(1).GetMethod().ReflectedType);
            // Logging - Before action
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logPadding.Padding + "AppBase.MakeRequest(method, requestUri, content?)");
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Method: " + method);
            sb.AppendLine(logPadding.InfoPadding + "[PARAM] Request URI: " + requestUri);
            //sb.AppendLine(logPadding.InfoPadding + "[PARAM] HTTP Content: " + content);
            sb.AppendLine(logPadding.InfoPadding + "[STACK] Caller: " + new StackTrace().GetFrame(1).GetMethod().ReflectedType + "." + new StackTrace().GetFrame(1).GetMethod().Name + "()");
            Log.Write(sb.ToString());
            // Perform the action
            try
            {
                // Build the request
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(method, requestUri);
                // Handle content (Ex., POST or PUT methods usually send a body with the request)
                if (content != null)
                {
                    httpRequestMessage.Content = content;
                }
                // Make the request and return the result
                returnValue = httpClient.SendAsync(httpRequestMessage).Result;
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
            // Return HTTP Response
            return returnValue;
        }

        #endregion App Methods
    }
}
