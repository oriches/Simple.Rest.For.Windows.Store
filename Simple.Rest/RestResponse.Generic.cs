using System;
using System.Net;

namespace Simple.Rest
{
    public class RestResponse<T> : RestResponse, IRestResponse<T> where T : class
    {
        public RestResponse(HttpWebResponse response, object resource)
            : this(response, null, resource)
        {
        }

        public RestResponse(HttpWebResponse response, Exception exception, object resource)
            : base(response, exception)
        {
            if (resource != null) Resource = (T) resource;
        }

        public T Resource { get; }
    }
}