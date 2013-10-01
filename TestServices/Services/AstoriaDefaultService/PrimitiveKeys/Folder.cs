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

namespace Microsoft.Test.OData.Services.PrimitiveKeysService
{
    using System.Data.Services.Common;
    using System.Collections.Generic;

    [DataServiceKey("Id")]
    public class Folder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Folder Parent { get; set; }

        public static IEnumerable<Folder> GetData()
        {
            var folder1 = new Folder { Id = 1, Name = "Program Files" };
            yield return folder1;

            var folder2 = new Folder { Id = 2, Name = "Microsoft WCF Data Services", Parent = folder1 };
            yield return folder2;

            var folder3 = new Folder { Id = 3, Name = "Current", Parent = folder2 };
            yield return folder3;
        }
    }
}
