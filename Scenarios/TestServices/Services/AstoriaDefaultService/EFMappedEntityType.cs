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

namespace Microsoft.Test.OData.Services.Astoria
{
    using System;
    using System.Collections.Generic;
    
    public partial class EFMappedEntityType
    {
        public int Id { get; set; }
        public string Href { get; set; }
        public string Title { get; set; }
        public string HrefLang { get; set; }
        public string Type { get; set; }
        public int Length { get; set; }
        public string BagOfPrimitiveToLinks { get; set; }
        public byte[] Logo { get; set; }
        public decimal BagOfDecimals { get; set; }
        public double BagOfDoubles { get; set; }
        public float BagOfSingles { get; set; }
        public byte BagOfBytes { get; set; }
        public short BagOfInt16s { get; set; }
        public int BagOfInt32s { get; set; }
        public long BagOfInt64s { get; set; }
        public System.Guid BagOfGuids { get; set; }
        public System.DateTime BagOfDateTime { get; set; }
        public string BagOfComplexToCategories_Term { get; set; }
        public string BagOfComplexToCategories_Scheme { get; set; }
        public string BagOfComplexToCategories_Label { get; set; }
        public string ComplexPhone_PhoneNumber { get; set; }
        public string ComplexPhone_Extension { get; set; }
        public string ComplexContactDetails_EmailBag { get; set; }
        public string ComplexContactDetails_AlternativeNames { get; set; }
        public string ComplexContactDetails_ContactAlias_AlternativeNames { get; set; }
        public string ComplexContactDetails_HomePhone_PhoneNumber { get; set; }
        public string ComplexContactDetails_HomePhone_Extension { get; set; }
        public string ComplexContactDetails_WorkPhone_PhoneNumber { get; set; }
        public string ComplexContactDetails_WorkPhone_Extension { get; set; }
        public string ComplexContactDetails_MobilePhoneBag_PhoneNumber { get; set; }
        public string ComplexContactDetails_MobilePhoneBag_Extension { get; set; }
    }
}
