using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
#if ODataLib101_Async
using System.Threading.Tasks;
#endif
using Microsoft.Data.OData;

namespace ODataLib101.ClientHttpMessages
{
    /// <summary>
    /// Implementation of the IODataRequestMessage interface using the client HTTP stack.
    /// </summary>
    public class ClientHttpRequestMessage :
#if ODataLib101_Async
        IODataRequestMessageAsync
#else
        IODataRequestMessage
#endif
    {
        /// <summary>
        /// The underlying web request object.
        /// </summary>
        private readonly HttpWebRequest webRequest;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="requestUrl">The URL to create the request for.</param>
        public ClientHttpRequestMessage(Uri requestUrl)
        {
            this.webRequest = (HttpWebRequest)WebRequest.Create(requestUrl);
            this.webRequest.Method = ODataConstants.MethodGet;
        }

        /// <summary>
        /// The HTTP headers on this message.
        /// </summary>
        public IEnumerable<KeyValuePair<string, string>> Headers
        {
            get
            {
                return this.webRequest.Headers.AllKeys.Select(headerName =>
                    new KeyValuePair<string, string>(headerName, this.webRequest.Headers.Get(headerName)));
            }
        }

        /// <summary>
        /// The HTTP method (verb) of the request.
        /// </summary>
        public string Method
        {
            get
            {
                return this.webRequest.Method;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Method must be a non-empty string.", "value");
                }

                this.webRequest.Method = value;
            }
        }

        /// <summary>
        /// The URL for the request.
        /// </summary>
        public Uri Url
        {
            get
            {
                return this.webRequest.RequestUri;
            }
            set
            {
                throw new InvalidOperationException("The request's Url property can't be modified, it has to be specified in the constructor.");
            }
        }

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

            return this.webRequest.Headers.Get(headerName);
        }

        /// <summary>
        /// Gets the content of the message as a stream.
        /// </summary>
        /// <returns>The content/body of the message as a stream.</returns>
        /// <remarks>
        /// This will only ever be called once and the caller will dispose the stream.
        /// In this implementation the returned stream is write only (since this message is to write requests).
        /// </remarks>
        public Stream GetStream()
        {
            return webRequest.GetRequestStream();
        }

#if ODataLib101_Async
        /// <summary>
        /// Asynchronously gets the content of the message as a stream. 
        /// </summary>
        /// <returns>A task which represent the asynchronous operation of getting the content stream of the message.</returns>
        /// <remarks>
        /// This will only ever be called once and the caller will dispose the stream.
        /// In this implementation the returned stream is write only (since this message is to write requests).
        /// </remarks>
        public Task<Stream> GetStreamAsync()
        {
            return this.webRequest.GetRequestStreamAsync();
        }
#endif

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
            if (headerName == null)
            {
                throw new ArgumentNullException("headerName");
            }

            // Some of the headers can't be set through the WebRequest.Headers collection.
            // Instead they have to be set as properties on the HttpWebRequest object.
            // Note that HTTP headers are case insensitive.
            if (string.Equals(headerName, "Accept", StringComparison.OrdinalIgnoreCase))
            {
                this.webRequest.Accept = headerValue;
            }
            else if (string.Equals(headerName, "Content-Length", StringComparison.OrdinalIgnoreCase))
            {
                this.webRequest.ContentLength = headerValue == null ? -1 : long.Parse(headerValue);
            }
            else if (string.Equals(headerName, "Content-Type", StringComparison.OrdinalIgnoreCase))
            {
                this.webRequest.ContentType = headerValue;
            }
            else if (string.Equals(headerName, "Date", StringComparison.OrdinalIgnoreCase))
            {
                this.webRequest.Date = headerValue == null ? DateTime.MinValue : DateTime.Parse(headerValue);
            }
            else if (string.Equals(headerName, "Expect", StringComparison.OrdinalIgnoreCase))
            {
                this.webRequest.Expect = headerValue;
            }
            else if (string.Equals(headerName, "Host", StringComparison.OrdinalIgnoreCase))
            {
                this.webRequest.Host = headerValue;
            }
            else if (string.Equals(headerName, "If-Modified-Since", StringComparison.OrdinalIgnoreCase))
            {
                this.webRequest.IfModifiedSince = headerValue == null ? DateTime.MinValue : DateTime.Parse(headerValue);
            }
            else if (string.Equals(headerName, "Referer", StringComparison.OrdinalIgnoreCase))
            {
                this.webRequest.Referer = headerValue;
            }
            else if (string.Equals(headerName, "Transfer-Encoding", StringComparison.OrdinalIgnoreCase))
            {
                this.webRequest.TransferEncoding = headerValue;
            }
            else if (string.Equals(headerName, "User-Agent", StringComparison.OrdinalIgnoreCase))
            {
                this.webRequest.UserAgent = headerValue;
            }
            else
            {
                if (headerValue == null)
                {
                    this.webRequest.Headers.Remove(headerName);
                }
                else
                {
                    this.webRequest.Headers.Set(headerName, headerValue);
                }
            }
        }

        /// <summary>
        /// Gets the response for this request.
        /// </summary>
        /// <returns>The response message.</returns>
        /// <remarks>
        /// This method is not part of the IODataRequestMessage interface. It's here to make the usage of these classes easier.
        /// It also handles OData errors by recognizing them and parsing them.
        /// Each implementation of the interfaces is expected to provide its own way to create the instances and or get them somewhere.
        /// </remarks>
        public IODataResponseMessage GetResponse()
        {
            try
            {
                return new ClientHttpResponseMessage((HttpWebResponse)this.webRequest.GetResponse());
            }
            catch (WebException webException)
            {
                if (webException.Response != null)
                {
                    // If there is an error response, try to read it.
                    IODataResponseMessage errorResponseMessage = new ClientHttpResponseMessage((HttpWebResponse)webException.Response);
                    using (ODataMessageReader messageReader = new ODataMessageReader(errorResponseMessage))
                    {
                        // The payload kind detection will determine if the payload is an error by looking at the content type (and possibly even the payload).
                        if (messageReader.DetectPayloadKind().Any(payloadKindDetectionResult => payloadKindDetectionResult.PayloadKind == ODataPayloadKind.Error))
                        {
                            // Construct the error message by concatenating all the error messages (including the inner ones).
                            // Makes it easier to debug problems.
                            ODataError error = messageReader.ReadError();

                            // If it is an error throw the ODataErrorException, it's easier to recognize and also read.
                            throw new ODataErrorException(CreateODataErrorExceptionMessage(error), error);
                        }
                    }
                }

                throw;
            }
        }

#if ODataLib101_Async
        /// <summary>
        /// Asynchronously gets the response for this request.
        /// </summary>
        /// <returns>The response message.</returns>
        /// <remarks>
        /// This method is not part of the IODataRequestMessage interface. It's here to make the usage of these classes easier.
        /// Each implementation of the interfaces is expected to provide its own way to create the instances and or get them somewhere.
        /// </remarks>
        public async Task<IODataResponseMessageAsync> GetResponseAsync()
        {
            WebException webException;

            try
            {
                HttpWebResponse webResponse = (HttpWebResponse)(await this.webRequest.GetResponseAsync());
                return new ClientHttpResponseMessage(webResponse);
            }
            catch (WebException exception)
            {
                webException = exception;
            }

            if (webException.Response != null)
            {
                // If there is an error response, try to read it.
                IODataResponseMessageAsync errorResponseMessage = new ClientHttpResponseMessage((HttpWebResponse)webException.Response);
                using (ODataMessageReader messageReader = new ODataMessageReader(errorResponseMessage))
                {
                    // The payload kind detection will determine if the payload is an error by looking at the content type (and possibly even the payload).
                    if ((await messageReader.DetectPayloadKindAsync()).Any(payloadKindDetectionResult => payloadKindDetectionResult.PayloadKind == ODataPayloadKind.Error))
                    {
                        // Construct the error message by concatenating all the error messages (including the inner ones).
                        // Makes it easier to debug problems.
                        ODataError error = await messageReader.ReadErrorAsync();

                        // If it is an error throw the ODataErrorException, it's easier to recognize and also read.
                        throw new ODataErrorException(CreateODataErrorExceptionMessage(error), error);
                    }
                }
            }

            throw webException;
        }
#endif

        /// <summary>
        /// Creates an exception message from the specified OData error.
        /// </summary>
        /// <param name="error">The OData error instance to create exception message for.</param>
        /// <returns>Exception message created from the <paramref name="error"/>.</returns>
        private static string CreateODataErrorExceptionMessage(ODataError error)
        {
            Debug.Assert(error != null, "error != null");
            StringBuilder errorMessage = new StringBuilder(error.Message);
            ODataInnerError innerError = error.InnerError;
            while (innerError != null)
            {
                errorMessage.AppendLine();
                errorMessage.Append(innerError.Message);
                innerError = innerError.InnerError;
            }

            return errorMessage.ToString();
        }
    }
}
