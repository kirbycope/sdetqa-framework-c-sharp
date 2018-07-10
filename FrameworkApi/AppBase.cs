using FrameworkCommon;
using System;
using System.Collections.Specialized;
using System.Net.Http;
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

            // Log Before Action
            Log.BeforeAction(new OrderedDictionary() {
                { "Method", method },
                { "Request URI", requestUri }
            });

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
                Log.Success();
            }
            catch (Exception e)
            {
                // Logging - After action exception
                Log.Failure(e.Message);
                // Fail current test
                Assert.Fail(e.Message);
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
            // Return HTTP Response
            return returnValue;
        }

        #endregion App Methods
    }
}
