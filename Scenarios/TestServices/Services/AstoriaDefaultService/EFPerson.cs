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
    
    public partial class EFPerson
    {
        public EFPerson()
        {
            this.EFPerson1 = new HashSet<EFPerson>();
            this.EFPersonMetadatas = new HashSet<EFPersonMetadata>();
        }
    
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string C_Discriminator { get; set; }
        public Nullable<int> ManagersPersonId { get; set; }
        public Nullable<int> Salary { get; set; }
        public string Title { get; set; }
        public Nullable<int> CarsVIN { get; set; }
        public Nullable<int> Bonus { get; set; }
        public Nullable<bool> IsFullyVested { get; set; }
    
        public virtual EFCar EFCar { get; set; }
        public virtual ICollection<EFPerson> EFPerson1 { get; set; }
        public virtual EFPerson EFPerson2 { get; set; }
        public virtual ICollection<EFPersonMetadata> EFPersonMetadatas { get; set; }
    }
}
