﻿using System;

namespace TestableHttpClient
{
    public class HttpRequestMessageAssertionException : Exception
    {
        private HttpRequestMessageAssertionException()
        {
        }

        public HttpRequestMessageAssertionException(string message) : base(message)
        {
        }

        public HttpRequestMessageAssertionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
