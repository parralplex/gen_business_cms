using Microsoft.AspNetCore.Server.IIS.Core;
using System.Net;
using System.Web.Http;

namespace business_hierarchy_cms.Exceptions
{
    public static class HttpExceptions
    {
        public static void ThrowHttpResponseExp(HttpStatusCode statusCode, string message)
        {
            var resp = new HttpResponseMessage(statusCode)
            {
                ReasonPhrase = message
            };
            throw new HttpResponseException(resp);
        }
    }
}
