﻿// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.
namespace ODataSamples.Features.Containment
{
    using Microsoft.OData.Core;
    using System;
    using System.Collections.Generic;
    using System.IO;
    public class ODataResponseMessage : IODataResponseMessage
    {
        private Stream stream;
        private readonly Dictionary<string, string> headers;

        public ODataResponseMessage(Stream stream)
        {
            this.headers = new Dictionary<string, string>();
            this.stream = stream;
        }

        public IEnumerable<KeyValuePair<string, string>> Headers
        {
            get { return this.headers; }
        }

        public int StatusCode { get; set; }

        public Uri Url { get; set; }

        public string Method { get; set; }

        public Stream Stream
        {
            get { return stream; }
            set { stream = value; }
        }

        public string GetHeader(string headerName)
        {
            string headerValue;
            return this.headers.TryGetValue(headerName, out headerValue) ? headerValue : null;
        }

        public void SetHeader(string headerName, string headerValue)
        {
            headers[headerName] = headerValue;
        }

        public Stream GetStream()
        {
            return this.Stream;
        }
    }
}
