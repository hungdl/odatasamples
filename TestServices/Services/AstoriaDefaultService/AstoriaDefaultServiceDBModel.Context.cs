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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AstoriaDefaultServiceDBEntities : DbContext
    {
        public AstoriaDefaultServiceDBEntities()
            : base("name=AstoriaDefaultServiceDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<EFCar> EFCars { get; set; }
        public DbSet<EFComputer> EFComputers { get; set; }
        public DbSet<EFComputerDetail> EFComputerDetails { get; set; }
        public DbSet<EFCustomer> EFCustomers { get; set; }
        public DbSet<EFCustomerInfo> EFCustomerInfoes { get; set; }
        public DbSet<EFDriver> EFDrivers { get; set; }
        public DbSet<EFLastLogin> EFLastLogins { get; set; }
        public DbSet<EFLicense> EFLicenses { get; set; }
        public DbSet<EFLogin> EFLogins { get; set; }
        public DbSet<EFMappedEntityType> EFMappedEntityTypes { get; set; }
        public DbSet<EFMessage> EFMessages { get; set; }
        public DbSet<EFOrder> EFOrders { get; set; }
        public DbSet<EFOrderLine> EFOrderLines { get; set; }
        public DbSet<EFPageView> EFPageViews { get; set; }
        public DbSet<EFPerson> EFPersons { get; set; }
        public DbSet<EFPersonMetadata> EFPersonMetadatas { get; set; }
        public DbSet<EFProduct> EFProducts { get; set; }
        public DbSet<EFProductDetail> EFProductDetails { get; set; }
        public DbSet<EFProductPhoto> EFProductPhotoes { get; set; }
        public DbSet<EFProductReview> EFProductReviews { get; set; }
        public DbSet<EFRSAToken> EFRSATokens { get; set; }
    }
}
