using System.Net.Http;

namespace FrameworkCommon.Toolbox
{
    public class HttpUtils
    {
        /// <summary>
        /// Send an HTTP request using the HEAD verb (so as to not wait for the body) and returns the result.
        /// </summary>
        /// <param name="requestUri">A string that represents the request System.Uri.</param>
        /// <param name="content">(Optional) The content of the HTTP message.</param>
        /// <returns>A HTTP response message including the status code and data.</returns>
        public static HttpResponseMessage CheckUrl(string requestUri, HttpContent content = null)
        {
            // Build the request
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Head, requestUri);
            // Handle content (Ex., POST or PUT methods usually send a body with the request)
            if (content != null)
            {
                httpRequestMessage.Content = content;
            }
            // Make the request and return the result
            return new HttpClient().SendAsync(httpRequestMessage).Result;
        }

        /// <summary>
        /// Send an HTTP request and returns the result.
        /// </summary>
        /// <param name="method">The HTTP method.</param>
        /// <param name="requestUri">A string that represents the request System.Uri.</param>
        /// <param name="content">(Optional) The content of the HTTP message.</param>
        /// <returns>A HTTP response message including the status code and data.</returns>
        public static HttpResponseMessage MakeRequest(HttpMethod method, string requestUri, HttpContent content = null)
        {
            // Build the request
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(method, requestUri);
            // Handle content (Ex., POST or PUT methods usually send a body with the request)
            if (content != null)
            {
                httpRequestMessage.Content = content;
            }
            // Make the request and return the result
            return new HttpClient().SendAsync(httpRequestMessage).Result;
        }
    }
}
