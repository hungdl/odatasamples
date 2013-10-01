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
    /// Memory stream that can be reused after disposing, which will simply set the position back to the start
    /// </summary>
    internal class ReusableStream : MemoryStream, IDisposable
    {
        /// <summary>
        /// Implementation of the Dispose() function
        /// </summary>
        void IDisposable.Dispose()
        {
            // Resets the stream
            this.Position = 0;
        }

        /// <summary>
        /// Resets the stream 
        /// </summary>
        /// <param name="disposing">Whether or not to dispose managed resources</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2215: Dispose methods should call base class dispose", Justification = "Not necessary to call base.Dispose() in this implementation")]
        protected override void Dispose(bool disposing)
        {
            ((IDisposable)this).Dispose();
        }
    }
}
