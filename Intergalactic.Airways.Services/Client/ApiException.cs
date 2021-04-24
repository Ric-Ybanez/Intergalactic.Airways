using System;
using System.Net;
using System.Net.Http;

namespace Intergalactic.Airways.Client
{
    public class ApiException : HttpRequestException
    {
        public ApiException(string body, string? message, Exception? inner, HttpStatusCode? statusCode)
            : base(message, inner, statusCode)
            => (Body) = (body);
        public string Body { get; private set; }
    }
}
