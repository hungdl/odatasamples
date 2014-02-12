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
    
    public partial class EFProduct
    {
        public EFProduct()
        {
            this.EFOrderLines = new HashSet<EFOrderLine>();
            this.EFProductPhotoes = new HashSet<EFProductPhoto>();
            this.EFProductReviews = new HashSet<EFProductReview>();
        }
    
        public int ProductId { get; set; }
        public string Description { get; set; }
        public decimal Dimensions_Width { get; set; }
        public decimal Dimensions_Height { get; set; }
        public decimal Dimensions_Depth { get; set; }
        public string BaseConcurrency { get; set; }
        public string ComplexConcurrency_Token { get; set; }
        public Nullable<System.DateTime> ComplexConcurrency_QueriedDateTime { get; set; }
        public System.DateTime NestedComplexConcurrency_ModifiedDate { get; set; }
        public string NestedComplexConcurrency_ModifiedBy { get; set; }
        public string NestedComplexConcurrency_Concurrency_Token { get; set; }
        public Nullable<System.DateTime> NestedComplexConcurrency_Concurrency_QueriedDateTime { get; set; }
        public string C_Discriminator { get; set; }
        public Nullable<System.DateTime> Discontinued { get; set; }
        public Nullable<int> ReplacementProductId { get; set; }
        public string DiscontinuedPhone_PhoneNumber { get; set; }
        public string DiscontinuedPhone_Extension { get; set; }
        public string ChildConcurrencyToken { get; set; }
        public Nullable<int> Products_RelatedProducts_ProductId { get; set; }
    
        public virtual ICollection<EFOrderLine> EFOrderLines { get; set; }
        public virtual EFProductDetail EFProductDetail { get; set; }
        public virtual ICollection<EFProductPhoto> EFProductPhotoes { get; set; }
        public virtual ICollection<EFProductReview> EFProductReviews { get; set; }
    }
}
