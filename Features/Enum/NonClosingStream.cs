﻿// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.
namespace ODataSamples.Features.EnumType
{
    using System.IO;
    internal class NonClosingStream : MemoryStream
    {
        public override void Close()
        {

        }
    }
}
