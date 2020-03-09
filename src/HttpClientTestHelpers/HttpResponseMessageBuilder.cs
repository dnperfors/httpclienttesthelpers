﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace HttpClientTestHelpers
{
    /// <summary>
    /// This class helps creating an <see cref="HttpResponseMessage"/> using a fluent interface.
    /// </summary>
    [SuppressMessage("Design", "CA1001:Types that own disposable fields should be disposable", Justification = "The HttpResponseMessage is only created and passed to the consumer.")]
    public sealed class HttpResponseMessageBuilder
    {
        private readonly HttpResponseMessage httpResponseMessage = new HttpResponseMessage();

        /// <summary>
        /// Specifies the version of the response.
        /// </summary>
        /// <param name="httpVersion">The <see cref="HttpVersion"/> of the response.</param>
        /// <returns>The <see cref="HttpResponseMessageBuilder"/> for further building of the response.</returns>
        public HttpResponseMessageBuilder WithVersion(Version httpVersion)
        {
            httpResponseMessage.Version = httpVersion;
            return this;
        }

        /// <summary>
        /// Specifies the status code of the response.
        /// </summary>
        /// <param name="statusCode">The <see cref="HttpStatusCode"/> of the response.</param>
        /// <returns>The <see cref="HttpResponseMessageBuilder"/> for further building of the response.</returns>
        public HttpResponseMessageBuilder WithStatusCode(HttpStatusCode statusCode)
        {
            httpResponseMessage.StatusCode = statusCode;
            return this;
        }

        /// <summary>
        /// Configure request headers using a builder by directly accessing the <see cref="HttpResponseHeaders"/>.
        /// </summary>
        /// <param name="responseHeaderBuilder">The builder for configuring the response headers.</param>
        /// <returns>The <see cref="HttpResponseMessageBuilder"/> for further building of the response.</returns>
        public HttpResponseMessageBuilder WithHeaders(Action<HttpResponseHeaders> responseHeaderBuilder)
        {
            if(responseHeaderBuilder == null)
            {
                throw new ArgumentNullException(nameof(responseHeaderBuilder));
            }

            responseHeaderBuilder(httpResponseMessage.Headers);
            return this;
        }

        /// <summary>
        /// Adds a request header to the response.
        /// </summary>
        /// <param name="header">The name of the header to add.</param>
        /// <param name="value">The value of the header to add.</param>
        /// <returns>The <see cref="HttpResponseMessageBuilder"/> for further building of the response.</returns>
        public HttpResponseMessageBuilder WithHeader(string header, string value)
        {
            if (string.IsNullOrEmpty(header))
            {
                throw new ArgumentNullException(nameof(header));
            }

            httpResponseMessage.Headers.Add(header, value);
            return this;
        }

        /// <summary>
        /// Specifies the content of the response.
        /// </summary>
        /// <param name="content">The <see cref="HttpContent"/> of the response.</param>
        /// <returns>The <see cref="HttpResponseMessageBuilder"/> for further building of the response.</returns>
        public HttpResponseMessageBuilder WithContent(HttpContent content)
        {
            httpResponseMessage.Content = content;
            return this;
        }

        /// <summary>
        /// Specifies the request message resulting in this response.
        /// </summary>
        /// <param name="requestMessage">The <see cref="HttpRequestMessage"/> resulting in this response.</param>
        /// <returns>The <see cref="HttpResponseMessageBuilder"/> for further building of the response.</returns>
        public HttpResponseMessageBuilder WithRequestMessage(HttpRequestMessage requestMessage)
        {
            httpResponseMessage.RequestMessage = requestMessage;
            return this;
        }

        /// <summary>
        /// Builds and returns the HttpResponseMessage.
        /// </summary>
        /// <returns>The <see cref="HttpResponseMessage"/></returns>
        public HttpResponseMessage Build()
        {
            return httpResponseMessage;
        }
    }
}