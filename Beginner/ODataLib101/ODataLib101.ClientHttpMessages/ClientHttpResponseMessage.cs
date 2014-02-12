﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
#if ODataLib101_Async
using System.Threading.Tasks;
#endif
using Microsoft.Data.OData;

namespace ODataLib101.ClientHttpMessages
{
    /// <summary>
    /// Implementation of the IODataResponseMessage interface using the client HTTP stack.
    /// </summary>
    public class ClientHttpResponseMessage :
#if ODataLib101_Async
        IODataResponseMessageAsync
#else
        IODataRequestMessageAsync
#endif
    {
        /// <summary>
        /// The underlying web response object;
        /// </summary>
        private readonly HttpWebResponse webResponse;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="webResponse">The web response to use.</param>
        public ClientHttpResponseMessage(HttpWebResponse webResponse)
        {
            if (webResponse == null)
            {
                throw new ArgumentNullException("webResponse");
            }

            this.webResponse = webResponse;
        }

        /// <summary>
        /// The HTTP headers on this message.
        /// </summary>
        public IEnumerable<KeyValuePair<string, string>> Headers
        {
            get
            {
                // This is not very efficient - better would be to cache the headers in a dictionary and return that.
                // But the Headers collection is not used by ODataLib, so this is just for sample purposes.
                return this.webResponse.Headers.AllKeys.Select(headerName =>
                    new KeyValuePair<string, string>(headerName, this.webResponse.Headers.Get(headerName)));
            }
        }

        /// <summary>
        /// The status code of the response.
        /// </summary>
        public int StatusCode
        {
            get
            {
                return (int)this.webResponse.StatusCode;
            }
            set
            {
                throw new InvalidOperationException("The HTTP response is read-only, status code can't be modified on it.");
            }
        }

        /// <summary>
        /// Gets the content of the message as a stream.
        /// </summary>
        /// <returns>The content/body of the message as a stream.</returns>
        /// <remarks>
        /// This will only ever be called once and the caller will dispose the stream.
        /// In this implementation the returned stream is read only (since this message is to read responses).
        /// </remarks>
        public Stream GetStream()
        {
            return this.webResponse.GetResponseStream();
        }

#if ODataLib101_Async
        /// <summary>
        /// Asynchronously gets the content of the message as a stream. 
        /// </summary>
        /// <returns>A task which represent the asynchronous operation of getting the content stream of the message.</returns>
        /// <remarks>
        /// This will only ever be called once and the caller will dispose the stream.
        /// In this implementation the returned stream is read only (since this message is to read responses).
        /// </remarks>
        public Task<Stream> GetStreamAsync()
        {
            // The HttpWebResponse doesn't need async way to get the response stream
            // so it doesn't expose such method. But ODataLib will call the async method if running in the async mode
            // so we need to implement it by returning already completed task.
            return Task.FromResult(this.webResponse.GetResponseStream());
        }
#endif

        /// <summary>
        /// Get a value of an HTTP header.
        /// </summary>
        /// <param name="headerName">The name of the HTTP header to get the value for.</param>
        /// <returns>The value of the HTTP header or null if no such header exists on the message.</returns>
        public string GetHeader(string headerName)
        {
            if (headerName == null)
            {
                throw new ArgumentNullException("headerName");
            }

            return this.webResponse.Headers.Get(headerName);
        }

        /// <summary>
        /// Sets the value of an HTTP header on this message.
        /// </summary>
        /// <param name="headerName">The name of the HTTP header to set the value for.</param>
        /// <param name="headerValue">The value to set.</param>
        /// <remarks>
        /// If the <paramref name="headerValue"/> is specified as null,
        /// it means the header with the <paramref name="headerName"/> should be removed from the message.
        /// </remarks>
        public void SetHeader(string headerName, string headerValue)
        {
            throw new InvalidOperationException("The HTTP response is read-only, headers can't be modified on it.");
        }
    }
}
