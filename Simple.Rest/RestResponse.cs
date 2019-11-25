using System;
using System.Net;

namespace Simple.Rest
{
    public class RestResponse : IRestResponse
    {
        public RestResponse(HttpWebResponse response) : this(response, null)
        {
        }

        public RestResponse(HttpWebResponse response, Exception exception)
        {
            StatusCode = response.StatusCode;
            StatusDescription = response.StatusDescription;
            Cookies = response.Cookies;
            Headers = response.Headers;

            Exception = exception;
        }

        public HttpStatusCode StatusCode { get; }

        public string StatusDescription { get; }

        public Exception Exception { get; }

        public CookieCollection Cookies { get; }

        public WebHeaderCollection Headers { get; }

        public bool Successfully => StatusCode == HttpStatusCode.OK && Exception == null;
    }
}