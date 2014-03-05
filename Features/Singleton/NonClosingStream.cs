﻿﻿// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.
namespace ODataSamples.Features.Singleton
{
    using System.IO;
    internal class NonClosingStream : MemoryStream
    {
        public override void Close()
        {

        }
    }
}
