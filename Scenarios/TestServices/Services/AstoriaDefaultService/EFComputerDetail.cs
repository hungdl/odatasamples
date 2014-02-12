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
    
    public partial class EFComputerDetail
    {
        public int ComputerDetailId { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Serial { get; set; }
        public string SpecificationsBag { get; set; }
        public System.DateTime PurchaseDate { get; set; }
        public decimal Dimensions_Width { get; set; }
        public decimal Dimensions_Height { get; set; }
        public decimal Dimensions_Depth { get; set; }
        public Nullable<int> Computer_ComputerDetail_ComputerId { get; set; }
    
        public virtual EFComputer EFComputer { get; set; }
    }
}
