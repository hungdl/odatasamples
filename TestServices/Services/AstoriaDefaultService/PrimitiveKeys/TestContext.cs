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
    using System.Linq;

    public class TestContext
    {
        #region Entity Sets

        public IQueryable<EdmBinary> EdmBinarySet { get { return EdmBinary.GetData().AsQueryable(); } }
        public IQueryable<EdmBoolean> EdmBooleanSet { get { return EdmBoolean.GetData().AsQueryable(); } }
        public IQueryable<EdmByte> EdmByteSet { get { return EdmByte.GetData().AsQueryable(); } }
        public IQueryable<EdmDateTime> EdmDateTimeSet { get { return EdmDateTime.GetData().AsQueryable(); } }
        public IQueryable<EdmDecimal> EdmDecimalSet { get { return EdmDecimal.GetData().AsQueryable(); } }
        public IQueryable<EdmDouble> EdmDoubleSet { get { return EdmDouble.GetData().AsQueryable(); } }
        public IQueryable<EdmSingle> EdmSingleSet { get { return EdmSingle.GetData().AsQueryable(); } }
        public IQueryable<EdmGuid> EdmGuidSet { get { return EdmGuid.GetData().AsQueryable(); } }
        public IQueryable<EdmInt16> EdmInt16Set { get { return EdmInt16.GetData().AsQueryable(); } }
        public IQueryable<EdmInt32> EdmInt32Set { get { return EdmInt32.GetData().AsQueryable(); } }
        public IQueryable<EdmInt64> EdmInt64Set { get { return EdmInt64.GetData().AsQueryable(); } }
        public IQueryable<EdmString> EdmStringSet { get { return EdmString.GetData().AsQueryable(); } }
        public IQueryable<EdmTime> EdmTimeSet { get { return EdmTime.GetData().AsQueryable(); } }
        public IQueryable<EdmDateTimeOffset> EdmDateTimeOffsetSet { get { return EdmDateTimeOffset.GetData().AsQueryable(); } }

        public IQueryable<Folder> Folders { get { return Folder.GetData().AsQueryable(); } }

        #endregion
    }
}
