//   Copyright 2011 Microsoft Corporation
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

namespace Microsoft.Test.OData.Framework.TestProviders.OptionalProviders
{
    using System;
    using System.IO;

    /// <summary>
    /// Wrapper class to contain a stream and its associated metadata
    /// </summary>
    internal class StreamWrapper
    {
        /// <summary>
        /// Gets or sets the name of the stream. Null should be used for media resources.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ETag stream for blob/named stream
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// Gets or sets the content-type of the stream
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the stream itself
        /// </summary>
        public Stream Stream { get; set; }

        /// <summary>
        /// Gets or sets the read uri of the stream
        /// </summary>
        public Uri ReadUri { get; set; }
    }
}
