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

namespace Microsoft.Test.OData.Services.AstoriaDefaultService
{
    using System;
    using System.Collections.Generic;
    using System.Data.Services;
    using System.Data.Services.Providers;
    using Microsoft.Test.OData.Framework.TestProviders.Reflection;

    public partial class DefaultContainer : ReflectionDataContext, System.Data.Services.Providers.IDataServiceUpdateProvider2
    {

        private static Dictionary<string, System.Type> collectionInstanceTypeMap = new Dictionary<string, System.Type>();

        private static Dictionary<string, int> autoIncrementingProperties = new Dictionary<string, int>();

        static DefaultContainer()
        {
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.Customer.BackupContactInfo", typeof(System.Collections.Generic.List<Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.Customer.Orders", typeof(System.Collections.Generic.List<Microsoft.Test.OData.Services.AstoriaDefaultService.Order>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.Customer.Logins", typeof(System.Collections.Generic.List<Microsoft.Test.OData.Services.AstoriaDefaultService.Login>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.Login.SentMessages", typeof(System.Collections.Generic.List<Microsoft.Test.OData.Services.AstoriaDefaultService.Message>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.Login.ReceivedMessages", typeof(System.Collections.Generic.List<Microsoft.Test.OData.Services.AstoriaDefaultService.Message>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.Login.Orders", typeof(System.Collections.Generic.List<Microsoft.Test.OData.Services.AstoriaDefaultService.Order>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.Message.Attachments", typeof(System.Collections.Generic.List<Microsoft.Test.OData.Services.AstoriaDefaultService.MessageAttachment>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.Product.RelatedProducts", typeof(System.Collections.Generic.List<Microsoft.Test.OData.Services.AstoriaDefaultService.Product>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.Product.Reviews", typeof(System.Collections.Generic.List<Microsoft.Test.OData.Services.AstoriaDefaultService.ProductReview>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.Product.Photos", typeof(System.Collections.Generic.List<Microsoft.Test.OData.Services.AstoriaDefaultService.ProductPhoto>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.DiscontinuedProduct.RelatedProducts", typeof(System.Collections.Generic.List<Microsoft.Test.OData.Services.AstoriaDefaultService.Product>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.DiscontinuedProduct.Reviews", typeof(System.Collections.Generic.List<Microsoft.Test.OData.Services.AstoriaDefaultService.ProductReview>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.DiscontinuedProduct.Photos", typeof(System.Collections.Generic.List<Microsoft.Test.OData.Services.AstoriaDefaultService.ProductPhoto>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.ComputerDetail.SpecificationsBag", typeof(System.Collections.Generic.List<string>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.MappedEntityType.BagOfPrimitiveToLinks", typeof(System.Collections.Generic.List<string>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.MappedEntityType.BagOfDecimals", typeof(System.Collections.Generic.List<decimal>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.MappedEntityType.BagOfDoubles", typeof(System.Collections.Generic.List<double>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.MappedEntityType.BagOfSingles", typeof(System.Collections.Generic.List<float>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.MappedEntityType.BagOfBytes", typeof(System.Collections.Generic.List<byte>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.MappedEntityType.BagOfInt16s", typeof(System.Collections.Generic.List<short>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.MappedEntityType.BagOfInt32s", typeof(System.Collections.Generic.List<int>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.MappedEntityType.BagOfInt64s", typeof(System.Collections.Generic.List<long>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.MappedEntityType.BagOfGuids", typeof(System.Collections.Generic.List<System.Guid>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.MappedEntityType.BagOfDateTime", typeof(System.Collections.Generic.List<System.DateTime>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.MappedEntityType.BagOfComplexToCategories", typeof(System.Collections.Generic.List<Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.Person.PersonMetadata", typeof(System.Collections.Generic.List<Microsoft.Test.OData.Services.AstoriaDefaultService.PersonMetadata>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.Contractor.PersonMetadata", typeof(System.Collections.Generic.List<Microsoft.Test.OData.Services.AstoriaDefaultService.PersonMetadata>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.Employee.PersonMetadata", typeof(System.Collections.Generic.List<Microsoft.Test.OData.Services.AstoriaDefaultService.PersonMetadata>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.SpecialEmployee.PersonMetadata", typeof(System.Collections.Generic.List<Microsoft.Test.OData.Services.AstoriaDefaultService.PersonMetadata>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases.AlternativeNames", typeof(System.Collections.Generic.List<string>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails.EmailBag", typeof(System.Collections.Generic.List<string>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails.AlternativeNames", typeof(System.Collections.Generic.List<string>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails.MobilePhoneBag", typeof(System.Collections.Generic.List<Microsoft.Test.OData.Services.AstoriaDefaultService.Phone>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.AllSpatialCollectionTypes_Simple.ManyGeogPoint", typeof(System.Collections.Generic.List<System.Spatial.GeographyPoint>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.AllSpatialCollectionTypes_Simple.ManyGeogLine", typeof(System.Collections.Generic.List<System.Spatial.GeographyLineString>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.AllSpatialCollectionTypes_Simple.ManyGeogPolygon", typeof(System.Collections.Generic.List<System.Spatial.GeographyPolygon>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.AllSpatialCollectionTypes_Simple.ManyGeomPoint", typeof(System.Collections.Generic.List<System.Spatial.GeometryPoint>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.AllSpatialCollectionTypes_Simple.ManyGeomLine", typeof(System.Collections.Generic.List<System.Spatial.GeometryLineString>));
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.AstoriaDefaultService.AllSpatialCollectionTypes_Simple.ManyGeomPolygon", typeof(System.Collections.Generic.List<System.Spatial.GeometryPolygon>));
            autoIncrementingProperties.Add("CustomerInfo.CustomerInfoId", 0);
            autoIncrementingProperties.Add("Computer.ComputerId", 0);
            autoIncrementingProperties.Add("Car.VIN", 0);
        }

        #region Entity Sets
        public System.Linq.IQueryable<Microsoft.Test.OData.Services.AstoriaDefaultService.AllSpatialTypes> AllGeoTypesSet
        {
            get
            {
                return System.Linq.Queryable.AsQueryable(this.GetResourceSetEntities<Microsoft.Test.OData.Services.AstoriaDefaultService.AllSpatialTypes>("AllGeoTypesSet"));
            }
        }

        public System.Linq.IQueryable<Microsoft.Test.OData.Services.AstoriaDefaultService.AllSpatialCollectionTypes> AllGeoCollectionTypesSet
        {
            get
            {
                return System.Linq.Queryable.AsQueryable(this.GetResourceSetEntities<Microsoft.Test.OData.Services.AstoriaDefaultService.AllSpatialCollectionTypes>("AllGeoCollectionTypesSet"));
            }
        }

        public System.Linq.IQueryable<Microsoft.Test.OData.Services.AstoriaDefaultService.Customer> Customer
        {
            get
            {
                return System.Linq.Queryable.AsQueryable(this.GetResourceSetEntities<Microsoft.Test.OData.Services.AstoriaDefaultService.Customer>("Customer"));
            }
        }

        public System.Linq.IQueryable<Microsoft.Test.OData.Services.AstoriaDefaultService.Login> Login
        {
            get
            {
                return System.Linq.Queryable.AsQueryable(this.GetResourceSetEntities<Microsoft.Test.OData.Services.AstoriaDefaultService.Login>("Login"));
            }
        }

        public System.Linq.IQueryable<Microsoft.Test.OData.Services.AstoriaDefaultService.RSAToken> RSAToken
        {
            get
            {
                return System.Linq.Queryable.AsQueryable(this.GetResourceSetEntities<Microsoft.Test.OData.Services.AstoriaDefaultService.RSAToken>("RSAToken"));
            }
        }

        public System.Linq.IQueryable<Microsoft.Test.OData.Services.AstoriaDefaultService.PageView> PageView
        {
            get
            {
                return System.Linq.Queryable.AsQueryable(this.GetResourceSetEntities<Microsoft.Test.OData.Services.AstoriaDefaultService.PageView>("PageView"));
            }
        }

        public System.Linq.IQueryable<Microsoft.Test.OData.Services.AstoriaDefaultService.LastLogin> LastLogin
        {
            get
            {
                return System.Linq.Queryable.AsQueryable(this.GetResourceSetEntities<Microsoft.Test.OData.Services.AstoriaDefaultService.LastLogin>("LastLogin"));
            }
        }

        public System.Linq.IQueryable<Microsoft.Test.OData.Services.AstoriaDefaultService.Message> Message
        {
            get
            {
                return System.Linq.Queryable.AsQueryable(this.GetResourceSetEntities<Microsoft.Test.OData.Services.AstoriaDefaultService.Message>("Message"));
            }
        }

        public System.Linq.IQueryable<Microsoft.Test.OData.Services.AstoriaDefaultService.MessageAttachment> MessageAttachment
        {
            get
            {
                return System.Linq.Queryable.AsQueryable(this.GetResourceSetEntities<Microsoft.Test.OData.Services.AstoriaDefaultService.MessageAttachment>("MessageAttachment"));
            }
        }

        public System.Linq.IQueryable<Microsoft.Test.OData.Services.AstoriaDefaultService.Order> Order
        {
            get
            {
                return System.Linq.Queryable.AsQueryable(this.GetResourceSetEntities<Microsoft.Test.OData.Services.AstoriaDefaultService.Order>("Order"));
            }
        }

        public System.Linq.IQueryable<Microsoft.Test.OData.Services.AstoriaDefaultService.OrderLine> OrderLine
        {
            get
            {
                return System.Linq.Queryable.AsQueryable(this.GetResourceSetEntities<Microsoft.Test.OData.Services.AstoriaDefaultService.OrderLine>("OrderLine"));
            }
        }

        public System.Linq.IQueryable<Microsoft.Test.OData.Services.AstoriaDefaultService.Product> Product
        {
            get
            {
                return System.Linq.Queryable.AsQueryable(this.GetResourceSetEntities<Microsoft.Test.OData.Services.AstoriaDefaultService.Product>("Product"));
            }
        }

        public System.Linq.IQueryable<Microsoft.Test.OData.Services.AstoriaDefaultService.ProductDetail> ProductDetail
        {
            get
            {
                return System.Linq.Queryable.AsQueryable(this.GetResourceSetEntities<Microsoft.Test.OData.Services.AstoriaDefaultService.ProductDetail>("ProductDetail"));
            }
        }

        public System.Linq.IQueryable<Microsoft.Test.OData.Services.AstoriaDefaultService.ProductReview> ProductReview
        {
            get
            {
                return System.Linq.Queryable.AsQueryable(this.GetResourceSetEntities<Microsoft.Test.OData.Services.AstoriaDefaultService.ProductReview>("ProductReview"));
            }
        }

        public System.Linq.IQueryable<Microsoft.Test.OData.Services.AstoriaDefaultService.ProductPhoto> ProductPhoto
        {
            get
            {
                return System.Linq.Queryable.AsQueryable(this.GetResourceSetEntities<Microsoft.Test.OData.Services.AstoriaDefaultService.ProductPhoto>("ProductPhoto"));
            }
        }

        public System.Linq.IQueryable<Microsoft.Test.OData.Services.AstoriaDefaultService.CustomerInfo> CustomerInfo
        {
            get
            {
                return System.Linq.Queryable.AsQueryable(this.GetResourceSetEntities<Microsoft.Test.OData.Services.AstoriaDefaultService.CustomerInfo>("CustomerInfo"));
            }
        }

        public System.Linq.IQueryable<Microsoft.Test.OData.Services.AstoriaDefaultService.Computer> Computer
        {
            get
            {
                return System.Linq.Queryable.AsQueryable(this.GetResourceSetEntities<Microsoft.Test.OData.Services.AstoriaDefaultService.Computer>("Computer"));
            }
        }

        public System.Linq.IQueryable<Microsoft.Test.OData.Services.AstoriaDefaultService.ComputerDetail> ComputerDetail
        {
            get
            {
                return System.Linq.Queryable.AsQueryable(this.GetResourceSetEntities<Microsoft.Test.OData.Services.AstoriaDefaultService.ComputerDetail>("ComputerDetail"));
            }
        }

        public System.Linq.IQueryable<Microsoft.Test.OData.Services.AstoriaDefaultService.Driver> Driver
        {
            get
            {
                return System.Linq.Queryable.AsQueryable(this.GetResourceSetEntities<Microsoft.Test.OData.Services.AstoriaDefaultService.Driver>("Driver"));
            }
        }

        public System.Linq.IQueryable<Microsoft.Test.OData.Services.AstoriaDefaultService.License> License
        {
            get
            {
                return System.Linq.Queryable.AsQueryable(this.GetResourceSetEntities<Microsoft.Test.OData.Services.AstoriaDefaultService.License>("License"));
            }
        }

        public System.Linq.IQueryable<Microsoft.Test.OData.Services.AstoriaDefaultService.MappedEntityType> MappedEntityType
        {
            get
            {
                return System.Linq.Queryable.AsQueryable(this.GetResourceSetEntities<Microsoft.Test.OData.Services.AstoriaDefaultService.MappedEntityType>("MappedEntityType"));
            }
        }

        public System.Linq.IQueryable<Microsoft.Test.OData.Services.AstoriaDefaultService.Car> Car
        {
            get
            {
                return System.Linq.Queryable.AsQueryable(this.GetResourceSetEntities<Microsoft.Test.OData.Services.AstoriaDefaultService.Car>("Car"));
            }
        }

        public System.Linq.IQueryable<Microsoft.Test.OData.Services.AstoriaDefaultService.Person> Person
        {
            get
            {
                return System.Linq.Queryable.AsQueryable(this.GetResourceSetEntities<Microsoft.Test.OData.Services.AstoriaDefaultService.Person>("Person"));
            }
        }

        public System.Linq.IQueryable<Microsoft.Test.OData.Services.AstoriaDefaultService.PersonMetadata> PersonMetadata
        {
            get
            {
                return System.Linq.Queryable.AsQueryable(this.GetResourceSetEntities<Microsoft.Test.OData.Services.AstoriaDefaultService.PersonMetadata>("PersonMetadata"));
            }
        }

        #endregion

        protected override System.Type GetCollectionPropertyType(string fullTypeName, string propertyName)
        {
            var key = string.Concat(fullTypeName, ".", propertyName);
            if (collectionInstanceTypeMap.ContainsKey(key))
            {
                return collectionInstanceTypeMap[key];
            }
            return base.GetCollectionPropertyType(fullTypeName, propertyName);
        }

        protected override bool TryGetStoreGeneratedValue(string entitySetName, string fullTypeName, string propertyName, out object propertyValue)
        {
            var key = string.Concat(entitySetName, ".", propertyName);
            if (autoIncrementingProperties.ContainsKey(key))
            {
                autoIncrementingProperties[key] = (autoIncrementingProperties[key] + 1);
                propertyValue = autoIncrementingProperties[key];
                return true;
            }
            return base.TryGetStoreGeneratedValue(entitySetName, fullTypeName, propertyName, out propertyValue);
        }

        public void ResetData()
        {
            this.ClearData();

            // Resets the autoIncrementingProperties so when we InitializeData we start counting from zero instead of the last value
            autoIncrementingProperties = new Dictionary<string, int>();
            InitializeData(this);
        }

        public override void SetConcurrencyValues(object resourceCookie, System.Nullable<bool> checkForEquality, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>> concurrencyValues)
        {
            base.SetConcurrencyValues(resourceCookie, checkForEquality, concurrencyValues);
        }

        public override object CreateResource(string containerName, string fullTypeName)
        {
            return base.CreateResource(containerName, fullTypeName);
        }

        public override object GetResource(System.Linq.IQueryable query, string fullTypeName)
        {
            return base.GetResource(query, fullTypeName);
        }

        public override object ResetResource(object resource)
        {
            return base.ResetResource(resource);
        }

        public override void SetValue(object targetResource, string propertyName, object propertyValue)
        {
            base.SetValue(targetResource, propertyName, propertyValue);
        }

        public override object GetValue(object targetResource, string propertyName)
        {
            return base.GetValue(targetResource, propertyName);
        }

        public override void SetReference(object targetResource, string propertyName, object propertyValue)
        {
            base.SetReference(targetResource, propertyName, propertyValue);
        }

        public override void AddReferenceToCollection(object targetResource, string propertyName, object resourceToBeAdded)
        {
            base.AddReferenceToCollection(targetResource, propertyName, resourceToBeAdded);
        }

        public override void RemoveReferenceFromCollection(object targetResource, string propertyName, object resourceToBeRemoved)
        {
            base.RemoveReferenceFromCollection(targetResource, propertyName, resourceToBeRemoved);
        }

        public override void DeleteResource(object targetResource)
        {
            base.DeleteResource(targetResource);
        }

        public override void SaveChanges()
        {
            base.SaveChanges();
        }

        public override object ResolveResource(object resource)
        {
            return base.ResolveResource(resource);
        }

        public override void ClearChanges()
        {
            base.ClearChanges();
        }

        #region Data Initialization
        protected static bool dataInitialized = false;

        protected static object lockObject = new object();

        protected override void EnsureDataIsInitialized()
        {
            System.Threading.Monitor.Enter(DefaultContainer.lockObject);
            try
            {
                if ((DefaultContainer.dataInitialized == false))
                {
                    DefaultContainer.InitializeData(this);
                    DefaultContainer.dataInitialized = true;
                }
            }
            finally
            {
                System.Threading.Monitor.Exit(DefaultContainer.lockObject);
            }
        }

        protected static void InitializeData(System.Data.Services.IUpdatable updatable)
        {
            System.Collections.Generic.Dictionary<string, object> resourceLookup = new System.Collections.Generic.Dictionary<string, object>();
            PopulateAllTypesSet(updatable, resourceLookup);
            PopulateAllCollectionTypesSet(updatable, resourceLookup);
            PopulateCustomer(updatable, resourceLookup);
            PopulateLogin(updatable, resourceLookup);
            PopulateRSAToken(updatable, resourceLookup);
            PopulatePageView(updatable, resourceLookup);
            PopulateLastLogin(updatable, resourceLookup);
            PopulateMessage(updatable, resourceLookup);
            PopulateMessageAttachment(updatable, resourceLookup);
            PopulateOrder(updatable, resourceLookup);
            PopulateOrderLine(updatable, resourceLookup);
            PopulateProduct(updatable, resourceLookup);
            PopulateProductDetail(updatable, resourceLookup);
            PopulateProductReview(updatable, resourceLookup);
            PopulateProductPhoto(updatable, resourceLookup);
            PopulateCustomerInfo(updatable, resourceLookup);
            PopulateComputer(updatable, resourceLookup);
            PopulateComputerDetail(updatable, resourceLookup);
            PopulateDriver(updatable, resourceLookup);
            PopulateLicense(updatable, resourceLookup);
            PopulateMappedEntityType(updatable, resourceLookup);
            PopulateCar(updatable, resourceLookup);
            PopulatePerson(updatable, resourceLookup);
            PopulatePersonMetadata(updatable, resourceLookup);
            PopulateLogin_SentMessages(updatable, resourceLookup);
            PopulateLogin_ReceivedMessages(updatable, resourceLookup);
            PopulateCustomer_CustomerInfo(updatable, resourceLookup);
            PopulateLogin_Orders(updatable, resourceLookup);
            PopulateMessage_Attachments(updatable, resourceLookup);
            PopulateCustomer_Orders(updatable, resourceLookup);
            PopulateCustomer_Logins(updatable, resourceLookup);
            PopulateLogin_LastLogin(updatable, resourceLookup);
            PopulateOrder_OrderLines(updatable, resourceLookup);
            PopulateProduct_OrderLines(updatable, resourceLookup);
            PopulateProducts_RelatedProducts(updatable, resourceLookup);
            PopulateProduct_ProductDetail(updatable, resourceLookup);
            PopulateProduct_ProductReview(updatable, resourceLookup);
            PopulateProduct_ProductPhoto(updatable, resourceLookup);
            PopulateHusband_Wife(updatable, resourceLookup);
            PopulateLogin_RSAToken(updatable, resourceLookup);
            PopulateLogin_PageViews(updatable, resourceLookup);
            PopulateComputer_ComputerDetail(updatable, resourceLookup);
            PopulateDriver_License(updatable, resourceLookup);
            PopulatePerson_PersonMetadata(updatable, resourceLookup);
            PopulateEmployee_Manager(updatable, resourceLookup);
            PopulateSpecialEmployee_Car(updatable, resourceLookup);
            updatable.SaveChanges();
        }

        private static void PopulateAllTypesSet(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {

            resourceLookup.Add("AllTypesSet0", updatable.CreateResource("AllGeoTypesSet", "Microsoft.Test.OData.Services.AstoriaDefaultService.AllSpatialTypes"));
            updatable.SetValue(resourceLookup["AllTypesSet0"], "Id", -10);
            updatable.SetValue(resourceLookup["AllTypesSet0"], "Geog", System.Spatial.GeographyPoint.Create(51.65D, 178.7D));
            updatable.SetValue(resourceLookup["AllTypesSet0"], "GeogPoint", System.Spatial.GeographyPoint.Create(52.8606D, 173.334D));
            updatable.SetValue(resourceLookup["AllTypesSet0"], "GeogLine", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyLineString>(new System.IO.StringReader("SRID=4326;LINESTRING (40.5 40.5, 30.5 30.5, 40.5 20.5, 30.5 10.5)")));
            updatable.SetValue(resourceLookup["AllTypesSet0"], "GeogPolygon", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyPolygon>(new System.IO.StringReader("SRID=4326;POLYGON ((15 5, 40 10, 10 20, 5 10, 15 5))")));
            updatable.SetValue(resourceLookup["AllTypesSet0"], "GeogCollection", null);
            updatable.SetValue(resourceLookup["AllTypesSet0"], "GeogMultiPoint", null);
            updatable.SetValue(resourceLookup["AllTypesSet0"], "GeogMultiLine", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyMultiLineString>(new System.IO.StringReader("SRID=4326;MULTILINESTRING ((10 10, 20 20, 10 40), (40 40, 30 30, 40 20, 30 10))")));
            updatable.SetValue(resourceLookup["AllTypesSet0"], "GeogMultiPolygon", null);
            updatable.SetValue(resourceLookup["AllTypesSet0"], "Geom", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryLineString>(new System.IO.StringReader("SRID=0;LINESTRING (1 1, 3 3, 2 4, 2 0)")));
            updatable.SetValue(resourceLookup["AllTypesSet0"], "GeomPoint", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryPoint>(new System.IO.StringReader("SRID=0;POINT EMPTY")));
            updatable.SetValue(resourceLookup["AllTypesSet0"], "GeomLine", null);
            updatable.SetValue(resourceLookup["AllTypesSet0"], "GeomPolygon", null);
            updatable.SetValue(resourceLookup["AllTypesSet0"], "GeomCollection", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryCollection>(new System.IO.StringReader("SRID=0;GEOMETRYCOLLECTION EMPTY")));
            updatable.SetValue(resourceLookup["AllTypesSet0"], "GeomMultiPoint", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryMultiPoint>(new System.IO.StringReader("SRID=0;MULTIPOINT EMPTY")));
            updatable.SetValue(resourceLookup["AllTypesSet0"], "GeomMultiLine", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryMultiLineString>(new System.IO.StringReader("SRID=0;MULTILINESTRING ((10 10, 20 20, 10 40), (40 40, 30 30, 40 20, 30 10))")));
            updatable.SetValue(resourceLookup["AllTypesSet0"], "GeomMultiPolygon", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryMultiPolygon>(new System.IO.StringReader("SRID=0;MULTIPOLYGON (((40 40, 20 45, 45 30, 40 40)), ((20 35, 45 20, 30 5, 10 10," +
                            " 10 30, 20 35), (30 20, 20 25, 20 15, 30 20)))")));


            resourceLookup.Add("AllTypesSet1", updatable.CreateResource("AllGeoTypesSet", "Microsoft.Test.OData.Services.AstoriaDefaultService.AllSpatialTypes"));
            updatable.SetValue(resourceLookup["AllTypesSet1"], "Id", -9);
            updatable.SetValue(resourceLookup["AllTypesSet1"], "Geog", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyPoint>(new System.IO.StringReader("SRID=4326;POINT EMPTY")));
            updatable.SetValue(resourceLookup["AllTypesSet1"], "GeogPoint", System.Spatial.GeographyPoint.Create(52.7892D, 172.826D));
            updatable.SetValue(resourceLookup["AllTypesSet1"], "GeogLine", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyLineString>(new System.IO.StringReader("SRID=4326;LINESTRING EMPTY")));
            updatable.SetValue(resourceLookup["AllTypesSet1"], "GeogPolygon", null);
            updatable.SetValue(resourceLookup["AllTypesSet1"], "GeogCollection", null);
            updatable.SetValue(resourceLookup["AllTypesSet1"], "GeogMultiPoint", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyMultiPoint>(new System.IO.StringReader("SRID=4326;MULTIPOINT ((-122.7 47.38))")));
            updatable.SetValue(resourceLookup["AllTypesSet1"], "GeogMultiLine", null);
            updatable.SetValue(resourceLookup["AllTypesSet1"], "GeogMultiPolygon", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyMultiPolygon>(new System.IO.StringReader("SRID=4326;MULTIPOLYGON EMPTY")));
            updatable.SetValue(resourceLookup["AllTypesSet1"], "Geom", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryPolygon>(new System.IO.StringReader("SRID=0;POLYGON ((15 5, 40 10, 10 20, 5 10, 15 5))")));
            updatable.SetValue(resourceLookup["AllTypesSet1"], "GeomPoint", System.Spatial.GeometryPoint.Create(4369367.0586663447D, 6352015.6916818349D));
            updatable.SetValue(resourceLookup["AllTypesSet1"], "GeomLine", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryLineString>(new System.IO.StringReader("SRID=0;LINESTRING (1 1, 3 3, 2 4, 2 0)")));
            updatable.SetValue(resourceLookup["AllTypesSet1"], "GeomPolygon", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryPolygon>(new System.IO.StringReader("SRID=0;POLYGON ((20 35, 45 20, 30 5, 10 10, 10 30, 20 35), (30 20, 20 25, 20 15, " +
                            "30 20))")));
            updatable.SetValue(resourceLookup["AllTypesSet1"], "GeomCollection", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryCollection>(new System.IO.StringReader("SRID=0;GEOMETRYCOLLECTION EMPTY")));
            updatable.SetValue(resourceLookup["AllTypesSet1"], "GeomMultiPoint", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryMultiPoint>(new System.IO.StringReader("SRID=0;MULTIPOINT ((0 0))")));
            updatable.SetValue(resourceLookup["AllTypesSet1"], "GeomMultiLine", null);
            updatable.SetValue(resourceLookup["AllTypesSet1"], "GeomMultiPolygon", null);


            resourceLookup.Add("AllTypesSet2", updatable.CreateResource("AllGeoTypesSet", "Microsoft.Test.OData.Services.AstoriaDefaultService.AllSpatialTypes"));
            updatable.SetValue(resourceLookup["AllTypesSet2"], "Id", -8);
            updatable.SetValue(resourceLookup["AllTypesSet2"], "Geog", System.Spatial.GeographyPoint.Create(51.5961D, 178.94D));
            updatable.SetValue(resourceLookup["AllTypesSet2"], "GeogPoint", System.Spatial.GeographyPoint.Create(51.65D, 178.7D));
            updatable.SetValue(resourceLookup["AllTypesSet2"], "GeogLine", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyLineString>(new System.IO.StringReader("SRID=4326;LINESTRING (10 10, 20 20, 10 40)")));
            updatable.SetValue(resourceLookup["AllTypesSet2"], "GeogPolygon", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyPolygon>(new System.IO.StringReader("SRID=4326;POLYGON EMPTY")));
            updatable.SetValue(resourceLookup["AllTypesSet2"], "GeogCollection", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyCollection>(new System.IO.StringReader("SRID=4326;GEOMETRYCOLLECTION EMPTY")));
            updatable.SetValue(resourceLookup["AllTypesSet2"], "GeogMultiPoint", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyMultiPoint>(new System.IO.StringReader("SRID=4326;MULTIPOINT ((-122.7 47.38))")));
            updatable.SetValue(resourceLookup["AllTypesSet2"], "GeogMultiLine", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyMultiLineString>(new System.IO.StringReader("SRID=4326;MULTILINESTRING ((10.5 10.5, 20.5 20.5, 10.5 40.5), (40.5 40.5, 30.5 30" +
                            ".5, 40.5 20.5, 30.5 10.5))")));
            updatable.SetValue(resourceLookup["AllTypesSet2"], "GeogMultiPolygon", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyMultiPolygon>(new System.IO.StringReader("SRID=4326;MULTIPOLYGON (((40 40, 20 45, 45 30, 40 40)), ((20 35, 45 20, 30 5, 10 " +
                            "10, 10 30, 20 35), (30 20, 20 25, 20 15, 30 20)))")));
            updatable.SetValue(resourceLookup["AllTypesSet2"], "Geom", System.Spatial.GeometryPoint.Create(4369367.0586663447D, 6352015.6916818349D));
            updatable.SetValue(resourceLookup["AllTypesSet2"], "GeomPoint", System.Spatial.GeometryPoint.Create(4377000.868172125D, 6348217.1067010015D));
            updatable.SetValue(resourceLookup["AllTypesSet2"], "GeomLine", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryLineString>(new System.IO.StringReader("SRID=0;LINESTRING (1 1, 3 3, 2 4, 2 0)")));
            updatable.SetValue(resourceLookup["AllTypesSet2"], "GeomPolygon", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryPolygon>(new System.IO.StringReader("SRID=0;POLYGON ((30 20, 10 40, 45 40, 30 20))")));
            updatable.SetValue(resourceLookup["AllTypesSet2"], "GeomCollection", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryCollection>(new System.IO.StringReader("SRID=0;GEOMETRYCOLLECTION (POINT (4 6), LINESTRING (4 6, 7 10))")));
            updatable.SetValue(resourceLookup["AllTypesSet2"], "GeomMultiPoint", null);
            updatable.SetValue(resourceLookup["AllTypesSet2"], "GeomMultiLine", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryMultiLineString>(new System.IO.StringReader("SRID=0;MULTILINESTRING EMPTY")));
            updatable.SetValue(resourceLookup["AllTypesSet2"], "GeomMultiPolygon", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryMultiPolygon>(new System.IO.StringReader("SRID=0;MULTIPOLYGON EMPTY")));


            resourceLookup.Add("AllTypesSet3", updatable.CreateResource("AllGeoTypesSet", "Microsoft.Test.OData.Services.AstoriaDefaultService.AllSpatialTypes"));
            updatable.SetValue(resourceLookup["AllTypesSet3"], "Id", -7);
            updatable.SetValue(resourceLookup["AllTypesSet3"], "Geog", System.Spatial.GeographyPoint.Create(52.8103D, 173.045D));
            updatable.SetValue(resourceLookup["AllTypesSet3"], "GeogPoint", System.Spatial.GeographyPoint.Create(52.795D, 173.105D));
            updatable.SetValue(resourceLookup["AllTypesSet3"], "GeogLine", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyLineString>(new System.IO.StringReader("SRID=4326;LINESTRING (10.5 10.5, 20.5 20.5, 10.5 40.5)")));
            updatable.SetValue(resourceLookup["AllTypesSet3"], "GeogPolygon", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyPolygon>(new System.IO.StringReader("SRID=4326;POLYGON ((15 5, 40 10, 10 20, 5 10, 15 5))")));
            updatable.SetValue(resourceLookup["AllTypesSet3"], "GeogCollection", null);
            updatable.SetValue(resourceLookup["AllTypesSet3"], "GeogMultiPoint", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyMultiPoint>(new System.IO.StringReader("SRID=4326;MULTIPOINT ((-122.7 47.38))")));
            updatable.SetValue(resourceLookup["AllTypesSet3"], "GeogMultiLine", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyMultiLineString>(new System.IO.StringReader("SRID=4326;MULTILINESTRING ((10 10, 20 20, 10 40), (40 40, 30 30, 40 20, 30 10))")));
            updatable.SetValue(resourceLookup["AllTypesSet3"], "GeogMultiPolygon", null);
            updatable.SetValue(resourceLookup["AllTypesSet3"], "Geom", null);
            updatable.SetValue(resourceLookup["AllTypesSet3"], "GeomPoint", System.Spatial.GeometryPoint.Create(4605537.5782547453D, 5924460.4760093335D));
            updatable.SetValue(resourceLookup["AllTypesSet3"], "GeomLine", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryLineString>(new System.IO.StringReader("SRID=0;LINESTRING (1 1, 3 3)")));
            updatable.SetValue(resourceLookup["AllTypesSet3"], "GeomPolygon", null);
            updatable.SetValue(resourceLookup["AllTypesSet3"], "GeomCollection", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryCollection>(new System.IO.StringReader("SRID=0;GEOMETRYCOLLECTION EMPTY")));
            updatable.SetValue(resourceLookup["AllTypesSet3"], "GeomMultiPoint", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryMultiPoint>(new System.IO.StringReader("SRID=0;MULTIPOINT ((0 0))")));
            updatable.SetValue(resourceLookup["AllTypesSet3"], "GeomMultiLine", null);
            updatable.SetValue(resourceLookup["AllTypesSet3"], "GeomMultiPolygon", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryMultiPolygon>(new System.IO.StringReader("SRID=0;MULTIPOLYGON EMPTY")));


            resourceLookup.Add("AllTypesSet4", updatable.CreateResource("AllGeoTypesSet", "Microsoft.Test.OData.Services.AstoriaDefaultService.AllSpatialTypes"));
            updatable.SetValue(resourceLookup["AllTypesSet4"], "Id", -6);
            updatable.SetValue(resourceLookup["AllTypesSet4"], "Geog", System.Spatial.GeographyPoint.Create(52.8453D, 173.153D));
            updatable.SetValue(resourceLookup["AllTypesSet4"], "GeogPoint", System.Spatial.GeographyPoint.Create(51.9917D, 177.508D));
            updatable.SetValue(resourceLookup["AllTypesSet4"], "GeogLine", null);
            updatable.SetValue(resourceLookup["AllTypesSet4"], "GeogPolygon", null);
            updatable.SetValue(resourceLookup["AllTypesSet4"], "GeogCollection", null);
            updatable.SetValue(resourceLookup["AllTypesSet4"], "GeogMultiPoint", null);
            updatable.SetValue(resourceLookup["AllTypesSet4"], "GeogMultiLine", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyMultiLineString>(new System.IO.StringReader("SRID=4326;MULTILINESTRING ((10 10, 20 20, 10 40), (40 40, 30 30, 40 20, 30 10))")));
            updatable.SetValue(resourceLookup["AllTypesSet4"], "GeogMultiPolygon", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyMultiPolygon>(new System.IO.StringReader("SRID=4326;MULTIPOLYGON (((30 20, 10 40, 45 40, 30 20)), ((15 5, 40 10, 10 20, 5 1" +
                            "0, 15 5)))")));
            updatable.SetValue(resourceLookup["AllTypesSet4"], "Geom", System.Spatial.GeometryPoint.Create(4358017.0935490858D, 6362964.504044747D));
            updatable.SetValue(resourceLookup["AllTypesSet4"], "GeomPoint", System.Spatial.GeometryPoint.Create(4377000.868172125D, 6348217.1067010015D));
            updatable.SetValue(resourceLookup["AllTypesSet4"], "GeomLine", null);
            updatable.SetValue(resourceLookup["AllTypesSet4"], "GeomPolygon", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryPolygon>(new System.IO.StringReader("SRID=0;POLYGON ((30 20, 10 40, 45 40, 30 20))")));
            updatable.SetValue(resourceLookup["AllTypesSet4"], "GeomCollection", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryCollection>(new System.IO.StringReader("SRID=0;GEOMETRYCOLLECTION EMPTY")));
            updatable.SetValue(resourceLookup["AllTypesSet4"], "GeomMultiPoint", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryMultiPoint>(new System.IO.StringReader("SRID=0;MULTIPOINT ((0 0))")));
            updatable.SetValue(resourceLookup["AllTypesSet4"], "GeomMultiLine", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryMultiLineString>(new System.IO.StringReader("SRID=0;MULTILINESTRING ((10 10, 20 20, 10 40), (40 40, 30 30, 40 20, 30 10))")));
            updatable.SetValue(resourceLookup["AllTypesSet4"], "GeomMultiPolygon", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryMultiPolygon>(new System.IO.StringReader("SRID=0;MULTIPOLYGON EMPTY")));


            resourceLookup.Add("AllTypesSet5", updatable.CreateResource("AllGeoTypesSet", "Microsoft.Test.OData.Services.AstoriaDefaultService.AllSpatialTypes"));
            updatable.SetValue(resourceLookup["AllTypesSet5"], "Id", -5);
            updatable.SetValue(resourceLookup["AllTypesSet5"], "Geog", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyCollection>(new System.IO.StringReader("SRID=4326;GEOMETRYCOLLECTION EMPTY")));
            updatable.SetValue(resourceLookup["AllTypesSet5"], "GeogPoint", null);
            updatable.SetValue(resourceLookup["AllTypesSet5"], "GeogLine", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyLineString>(new System.IO.StringReader("SRID=4326;LINESTRING (10.5 10.5, 20.5 20.5, 10.5 40.5)")));
            updatable.SetValue(resourceLookup["AllTypesSet5"], "GeogPolygon", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyPolygon>(new System.IO.StringReader("SRID=4326;POLYGON ((15 5, 40 10, 10 20, 5 10, 15 5))")));
            updatable.SetValue(resourceLookup["AllTypesSet5"], "GeogCollection", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyCollection>(new System.IO.StringReader("SRID=4326;GEOMETRYCOLLECTION (GEOMETRYCOLLECTION EMPTY, GEOMETRYCOLLECTION (POINT" +
                            " (1 2)))")));
            updatable.SetValue(resourceLookup["AllTypesSet5"], "GeogMultiPoint", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyMultiPoint>(new System.IO.StringReader("SRID=4326;MULTIPOINT ((-122.7 47.38))")));
            updatable.SetValue(resourceLookup["AllTypesSet5"], "GeogMultiLine", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyMultiLineString>(new System.IO.StringReader("SRID=4326;MULTILINESTRING EMPTY")));
            updatable.SetValue(resourceLookup["AllTypesSet5"], "GeogMultiPolygon", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyMultiPolygon>(new System.IO.StringReader("SRID=4326;MULTIPOLYGON (((40 40, 20 45, 45 30, 40 40)), ((20 35, 45 20, 30 5, 10 " +
                            "10, 10 30, 20 35), (30 20, 20 25, 20 15, 30 20)))")));
            updatable.SetValue(resourceLookup["AllTypesSet5"], "Geom", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryPolygon>(new System.IO.StringReader("SRID=0;POLYGON EMPTY")));
            updatable.SetValue(resourceLookup["AllTypesSet5"], "GeomPoint", System.Spatial.GeometryPoint.Create(4513675.2944411123D, 6032903.5882574534D));
            updatable.SetValue(resourceLookup["AllTypesSet5"], "GeomLine", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryLineString>(new System.IO.StringReader("SRID=0;LINESTRING (1 1, 3 3, 2 4, 2 0)")));
            updatable.SetValue(resourceLookup["AllTypesSet5"], "GeomPolygon", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryPolygon>(new System.IO.StringReader("SRID=0;POLYGON EMPTY")));
            updatable.SetValue(resourceLookup["AllTypesSet5"], "GeomCollection", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryCollection>(new System.IO.StringReader("SRID=0;GEOMETRYCOLLECTION (GEOMETRYCOLLECTION EMPTY, GEOMETRYCOLLECTION (POINT (1" +
                            " 2)))")));
            updatable.SetValue(resourceLookup["AllTypesSet5"], "GeomMultiPoint", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryMultiPoint>(new System.IO.StringReader("SRID=0;MULTIPOINT EMPTY")));
            updatable.SetValue(resourceLookup["AllTypesSet5"], "GeomMultiLine", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryMultiLineString>(new System.IO.StringReader("SRID=0;MULTILINESTRING ((10 10, 20 20, 10 40), (40 40, 30 30, 40 20, 30 10))")));
            updatable.SetValue(resourceLookup["AllTypesSet5"], "GeomMultiPolygon", null);


            resourceLookup.Add("AllTypesSet6", updatable.CreateResource("AllGeoTypesSet", "Microsoft.Test.OData.Services.AstoriaDefaultService.AllSpatialTypes"));
            updatable.SetValue(resourceLookup["AllTypesSet6"], "Id", -4);
            updatable.SetValue(resourceLookup["AllTypesSet6"], "Geog", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyMultiLineString>(new System.IO.StringReader("SRID=4326;MULTILINESTRING ((10 10, 20 20, 10 40), (40 40, 30 30, 40 20, 30 10))")));
            updatable.SetValue(resourceLookup["AllTypesSet6"], "GeogPoint", System.Spatial.GeographyPoint.Create(52.8606D, 173.334D));
            updatable.SetValue(resourceLookup["AllTypesSet6"], "GeogLine", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyLineString>(new System.IO.StringReader("SRID=4326;LINESTRING EMPTY")));
            updatable.SetValue(resourceLookup["AllTypesSet6"], "GeogPolygon", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyPolygon>(new System.IO.StringReader("SRID=4326;POLYGON ((15 5, 40 10, 10 20, 5 10, 15 5))")));
            updatable.SetValue(resourceLookup["AllTypesSet6"], "GeogCollection", null);
            updatable.SetValue(resourceLookup["AllTypesSet6"], "GeogMultiPoint", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyMultiPoint>(new System.IO.StringReader("SRID=4326;MULTIPOINT ((178.94 51.5961), (172.826 52.7892), (177.539 52.1022), (17" +
                            "7.508 51.9917), (173.153 52.8453), (173.045 52.8103), (177.76 51.9461))")));
            updatable.SetValue(resourceLookup["AllTypesSet6"], "GeogMultiLine", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyMultiLineString>(new System.IO.StringReader("SRID=4326;MULTILINESTRING EMPTY")));
            updatable.SetValue(resourceLookup["AllTypesSet6"], "GeogMultiPolygon", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyMultiPolygon>(new System.IO.StringReader("SRID=4326;MULTIPOLYGON EMPTY")));
            updatable.SetValue(resourceLookup["AllTypesSet6"], "Geom", System.Spatial.GeometryPoint.Create(4605537.5782547453D, 5924460.4760093335D));
            updatable.SetValue(resourceLookup["AllTypesSet6"], "GeomPoint", System.Spatial.GeometryPoint.Create(4505479.22279754D, 6049837.1931612007D));
            updatable.SetValue(resourceLookup["AllTypesSet6"], "GeomLine", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryLineString>(new System.IO.StringReader("SRID=0;LINESTRING (1 1, 3 3)")));
            updatable.SetValue(resourceLookup["AllTypesSet6"], "GeomPolygon", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryPolygon>(new System.IO.StringReader("SRID=0;POLYGON ((15 5, 40 10, 10 20, 5 10, 15 5))")));
            updatable.SetValue(resourceLookup["AllTypesSet6"], "GeomCollection", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryCollection>(new System.IO.StringReader("SRID=0;GEOMETRYCOLLECTION EMPTY")));
            updatable.SetValue(resourceLookup["AllTypesSet6"], "GeomMultiPoint", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryMultiPoint>(new System.IO.StringReader("SRID=0;MULTIPOINT ((4541876.7599749668 5944203.8929384714), (4358017.0935490858 6" +
                            "362964.504044747), (4515785.037825482 6055723.864035368), (4505479.22279754 6049" +
                            "837.1931612007), (4377000.868172125 6348217.1067010015))")));
            updatable.SetValue(resourceLookup["AllTypesSet6"], "GeomMultiLine", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryMultiLineString>(new System.IO.StringReader("SRID=0;MULTILINESTRING ((10 10, 20 20, 10 40), (40 40, 30 30, 40 20, 30 10))")));
            updatable.SetValue(resourceLookup["AllTypesSet6"], "GeomMultiPolygon", null);


            resourceLookup.Add("AllTypesSet7", updatable.CreateResource("AllGeoTypesSet", "Microsoft.Test.OData.Services.AstoriaDefaultService.AllSpatialTypes"));
            updatable.SetValue(resourceLookup["AllTypesSet7"], "Id", -3);
            updatable.SetValue(resourceLookup["AllTypesSet7"], "Geog", System.Spatial.GeographyPoint.Create(51.9917D, 177.508D));
            updatable.SetValue(resourceLookup["AllTypesSet7"], "GeogPoint", System.Spatial.GeographyPoint.Create(51.65D, 178.7D));
            updatable.SetValue(resourceLookup["AllTypesSet7"], "GeogLine", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyLineString>(new System.IO.StringReader("SRID=4326;LINESTRING (40 40, 30 30, 40 20, 30 10)")));
            updatable.SetValue(resourceLookup["AllTypesSet7"], "GeogPolygon", null);
            updatable.SetValue(resourceLookup["AllTypesSet7"], "GeogCollection", null);
            updatable.SetValue(resourceLookup["AllTypesSet7"], "GeogMultiPoint", null);
            updatable.SetValue(resourceLookup["AllTypesSet7"], "GeogMultiLine", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyMultiLineString>(new System.IO.StringReader("SRID=4326;MULTILINESTRING EMPTY")));
            updatable.SetValue(resourceLookup["AllTypesSet7"], "GeogMultiPolygon", null);
            updatable.SetValue(resourceLookup["AllTypesSet7"], "Geom", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryLineString>(new System.IO.StringReader("SRID=0;LINESTRING (1 1, 3 3)")));
            updatable.SetValue(resourceLookup["AllTypesSet7"], "GeomPoint", null);
            updatable.SetValue(resourceLookup["AllTypesSet7"], "GeomLine", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryLineString>(new System.IO.StringReader("SRID=0;LINESTRING (1 1, 3 3, 2 4, 2 0, 1 1)")));
            updatable.SetValue(resourceLookup["AllTypesSet7"], "GeomPolygon", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryPolygon>(new System.IO.StringReader("SRID=0;POLYGON ((15 5, 40 10, 10 20, 5 10, 15 5))")));
            updatable.SetValue(resourceLookup["AllTypesSet7"], "GeomCollection", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryCollection>(new System.IO.StringReader("SRID=0;GEOMETRYCOLLECTION EMPTY")));
            updatable.SetValue(resourceLookup["AllTypesSet7"], "GeomMultiPoint", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryMultiPoint>(new System.IO.StringReader("SRID=0;MULTIPOINT EMPTY")));
            updatable.SetValue(resourceLookup["AllTypesSet7"], "GeomMultiLine", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryMultiLineString>(new System.IO.StringReader("SRID=0;MULTILINESTRING ((10.5 10.5, 20.5 20.5, 10.5 40.5), (40.5 40.5, 30.5 30.5," +
                            " 40.5 20.5, 30.5 10.5))")));
            updatable.SetValue(resourceLookup["AllTypesSet7"], "GeomMultiPolygon", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryMultiPolygon>(new System.IO.StringReader("SRID=0;MULTIPOLYGON (((40 40, 20 45, 45 30, 40 40)), ((20 35, 45 20, 30 5, 10 10," +
                            " 10 30, 20 35), (30 20, 20 25, 20 15, 30 20)))")));


            resourceLookup.Add("AllTypesSet8", updatable.CreateResource("AllGeoTypesSet", "Microsoft.Test.OData.Services.AstoriaDefaultService.AllSpatialTypes"));
            updatable.SetValue(resourceLookup["AllTypesSet8"], "Id", -2);
            updatable.SetValue(resourceLookup["AllTypesSet8"], "Geog", System.Spatial.GeographyPoint.Create(52.7892D, 172.826D));
            updatable.SetValue(resourceLookup["AllTypesSet8"], "GeogPoint", null);
            updatable.SetValue(resourceLookup["AllTypesSet8"], "GeogLine", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyLineString>(new System.IO.StringReader("SRID=4326;LINESTRING (40.5 40.5, 30.5 30.5, 40.5 20.5, 30.5 10.5)")));
            updatable.SetValue(resourceLookup["AllTypesSet8"], "GeogPolygon", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyPolygon>(new System.IO.StringReader("SRID=4326;POLYGON ((15 5, 40 10, 10 20, 5 10, 15 5))")));
            updatable.SetValue(resourceLookup["AllTypesSet8"], "GeogCollection", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyCollection>(new System.IO.StringReader("SRID=4326;GEOMETRYCOLLECTION (GEOMETRYCOLLECTION EMPTY, GEOMETRYCOLLECTION (POINT" +
                            " (1 2)))")));
            updatable.SetValue(resourceLookup["AllTypesSet8"], "GeogMultiPoint", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyMultiPoint>(new System.IO.StringReader("SRID=4326;MULTIPOINT ((173.334 52.8606), (178.7 51.65), (179.5 51.9125), (179.728" +
                            " 51.9222), (173.105 52.795), (172.914 52.9778))")));
            updatable.SetValue(resourceLookup["AllTypesSet8"], "GeogMultiLine", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyMultiLineString>(new System.IO.StringReader("SRID=4326;MULTILINESTRING EMPTY")));
            updatable.SetValue(resourceLookup["AllTypesSet8"], "GeogMultiPolygon", null);
            updatable.SetValue(resourceLookup["AllTypesSet8"], "Geom", System.Spatial.GeometryPoint.Create(4377000.868172125D, 6348217.1067010015D));
            updatable.SetValue(resourceLookup["AllTypesSet8"], "GeomPoint", System.Spatial.GeometryPoint.Create(4377000.868172125D, 6348217.1067010015D));
            updatable.SetValue(resourceLookup["AllTypesSet8"], "GeomLine", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryLineString>(new System.IO.StringReader("SRID=0;LINESTRING (1 1, 3 3, 2 4, 2 0)")));
            updatable.SetValue(resourceLookup["AllTypesSet8"], "GeomPolygon", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryPolygon>(new System.IO.StringReader("SRID=0;POLYGON ((15 5, 40 10, 10 20, 5 10, 15 5))")));
            updatable.SetValue(resourceLookup["AllTypesSet8"], "GeomCollection", null);
            updatable.SetValue(resourceLookup["AllTypesSet8"], "GeomMultiPoint", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryMultiPoint>(new System.IO.StringReader("SRID=0;MULTIPOINT ((0 0))")));
            updatable.SetValue(resourceLookup["AllTypesSet8"], "GeomMultiLine", null);
            updatable.SetValue(resourceLookup["AllTypesSet8"], "GeomMultiPolygon", null);


            resourceLookup.Add("AllTypesSet9", updatable.CreateResource("AllGeoTypesSet", "Microsoft.Test.OData.Services.AstoriaDefaultService.AllSpatialTypes"));
            updatable.SetValue(resourceLookup["AllTypesSet9"], "Id", -1);
            updatable.SetValue(resourceLookup["AllTypesSet9"], "Geog", System.Spatial.GeographyPoint.Create(51.65D, 178.7D));
            updatable.SetValue(resourceLookup["AllTypesSet9"], "GeogPoint", null);
            updatable.SetValue(resourceLookup["AllTypesSet9"], "GeogLine", null);
            updatable.SetValue(resourceLookup["AllTypesSet9"], "GeogPolygon", null);
            updatable.SetValue(resourceLookup["AllTypesSet9"], "GeogCollection", null);
            updatable.SetValue(resourceLookup["AllTypesSet9"], "GeogMultiPoint", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyMultiPoint>(new System.IO.StringReader("SRID=4326;MULTIPOINT ((173.334 52.8606), (178.7 51.65), (179.5 51.9125), (179.728" +
                            " 51.9222), (173.105 52.795), (172.914 52.9778))")));
            updatable.SetValue(resourceLookup["AllTypesSet9"], "GeogMultiLine", null);
            updatable.SetValue(resourceLookup["AllTypesSet9"], "GeogMultiPolygon", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyMultiPolygon>(new System.IO.StringReader("SRID=4326;MULTIPOLYGON EMPTY")));
            updatable.SetValue(resourceLookup["AllTypesSet9"], "Geom", System.Spatial.GeometryPoint.Create(4358017.0935490858D, 6362964.504044747D));
            updatable.SetValue(resourceLookup["AllTypesSet9"], "GeomPoint", System.Spatial.GeometryPoint.Create(4358017.0935490858D, 6362964.504044747D));
            updatable.SetValue(resourceLookup["AllTypesSet9"], "GeomLine", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryLineString>(new System.IO.StringReader("SRID=0;LINESTRING (1 1, 3 3, 2 4, 2 0, 1 1)")));
            updatable.SetValue(resourceLookup["AllTypesSet9"], "GeomPolygon", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryPolygon>(new System.IO.StringReader("SRID=0;POLYGON ((30 20, 10 40, 45 40, 30 20))")));
            updatable.SetValue(resourceLookup["AllTypesSet9"], "GeomCollection", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryCollection>(new System.IO.StringReader("SRID=0;GEOMETRYCOLLECTION (POINT (4 6), LINESTRING (4 6, 7 10))")));
            updatable.SetValue(resourceLookup["AllTypesSet9"], "GeomMultiPoint", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryMultiPoint>(new System.IO.StringReader("SRID=0;MULTIPOINT ((4541876.7599749668 5944203.8929384714), (4358017.0935490858 6" +
                            "362964.504044747), (4515785.037825482 6055723.864035368), (4505479.22279754 6049" +
                            "837.1931612007), (4377000.868172125 6348217.1067010015))")));
            updatable.SetValue(resourceLookup["AllTypesSet9"], "GeomMultiLine", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryMultiLineString>(new System.IO.StringReader("SRID=0;MULTILINESTRING EMPTY")));
            updatable.SetValue(resourceLookup["AllTypesSet9"], "GeomMultiPolygon", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryMultiPolygon>(new System.IO.StringReader("SRID=0;MULTIPOLYGON (((30 20, 10 40, 45 40, 30 20)), ((15 5, 40 10, 10 20, 5 10, " +
                            "15 5)))")));

        }

        private static void PopulateAllCollectionTypesSet(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {

            resourceLookup.Add("AllCollectionTypesSet0", updatable.CreateResource("AllGeoCollectionTypesSet", "Microsoft.Test.OData.Services.AstoriaDefaultService.AllSpatialCollectionTypes_Simple"));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet0"], "Id", -10);
            System.Collections.Generic.List<System.Spatial.GeographyPoint> AllCollectionTypesSet0_ManyGeogPoint = new System.Collections.Generic.List<System.Spatial.GeographyPoint>();
            AllCollectionTypesSet0_ManyGeogPoint.Add(System.Spatial.GeographyPoint.Create(52.795D, 173.105D));
            AllCollectionTypesSet0_ManyGeogPoint.Add(System.Spatial.GeographyPoint.Create(52.8606D, 173.334D));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet0"], "ManyGeogPoint", AllCollectionTypesSet0_ManyGeogPoint);
            System.Collections.Generic.List<System.Spatial.GeographyLineString> AllCollectionTypesSet0_ManyGeogLine = new System.Collections.Generic.List<System.Spatial.GeographyLineString>();
            AllCollectionTypesSet0_ManyGeogLine.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyLineString>(new System.IO.StringReader("SRID=4326;LINESTRING (40 40, 30 30, 40 20, 30 10)")));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet0"], "ManyGeogLine", AllCollectionTypesSet0_ManyGeogLine);
            System.Collections.Generic.List<System.Spatial.GeographyPolygon> AllCollectionTypesSet0_ManyGeogPolygon = new System.Collections.Generic.List<System.Spatial.GeographyPolygon>();
            AllCollectionTypesSet0_ManyGeogPolygon.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyPolygon>(new System.IO.StringReader("SRID=4326;POLYGON ((15 5, 40 10, 10 20, 5 10, 15 5))")));
            AllCollectionTypesSet0_ManyGeogPolygon.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyPolygon>(new System.IO.StringReader("SRID=4326;POLYGON ((20 35, 45 20, 30 5, 10 10, 10 30, 20 35), (30 20, 20 25, 20 1" +
                            "5, 30 20))")));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet0"], "ManyGeogPolygon", AllCollectionTypesSet0_ManyGeogPolygon);
            System.Collections.Generic.List<System.Spatial.GeometryPoint> AllCollectionTypesSet0_ManyGeomPoint = new System.Collections.Generic.List<System.Spatial.GeometryPoint>();
            AllCollectionTypesSet0_ManyGeomPoint.Add(System.Spatial.GeometryPoint.Create(4593801.791271016D, 5936057.1648600493D));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet0"], "ManyGeomPoint", AllCollectionTypesSet0_ManyGeomPoint);
            System.Collections.Generic.List<System.Spatial.GeometryLineString> AllCollectionTypesSet0_ManyGeomLine = new System.Collections.Generic.List<System.Spatial.GeometryLineString>();
            AllCollectionTypesSet0_ManyGeomLine.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryLineString>(new System.IO.StringReader("SRID=0;LINESTRING (1 1, 3 3, 2 4, 2 0)")));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet0"], "ManyGeomLine", AllCollectionTypesSet0_ManyGeomLine);
            System.Collections.Generic.List<System.Spatial.GeometryPolygon> AllCollectionTypesSet0_ManyGeomPolygon = new System.Collections.Generic.List<System.Spatial.GeometryPolygon>();
            AllCollectionTypesSet0_ManyGeomPolygon.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryPolygon>(new System.IO.StringReader("SRID=0;POLYGON ((15 5, 40 10, 10 20, 5 10, 15 5))")));
            AllCollectionTypesSet0_ManyGeomPolygon.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryPolygon>(new System.IO.StringReader("SRID=0;POLYGON ((20 35, 45 20, 30 5, 10 10, 10 30, 20 35), (30 20, 20 25, 20 15, " +
                            "30 20))")));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet0"], "ManyGeomPolygon", AllCollectionTypesSet0_ManyGeomPolygon);


            resourceLookup.Add("AllCollectionTypesSet1", updatable.CreateResource("AllGeoCollectionTypesSet", "Microsoft.Test.OData.Services.AstoriaDefaultService.AllSpatialCollectionTypes_Simple"));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet1"], "Id", -9);
            System.Collections.Generic.List<System.Spatial.GeographyPoint> AllCollectionTypesSet1_ManyGeogPoint = new System.Collections.Generic.List<System.Spatial.GeographyPoint>();
            AllCollectionTypesSet1_ManyGeogPoint.Add(System.Spatial.GeographyPoint.Create(52.795D, 173.105D));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet1"], "ManyGeogPoint", AllCollectionTypesSet1_ManyGeogPoint);
            System.Collections.Generic.List<System.Spatial.GeographyLineString> AllCollectionTypesSet1_ManyGeogLine = new System.Collections.Generic.List<System.Spatial.GeographyLineString>();
            updatable.SetValue(resourceLookup["AllCollectionTypesSet1"], "ManyGeogLine", AllCollectionTypesSet1_ManyGeogLine);
            System.Collections.Generic.List<System.Spatial.GeographyPolygon> AllCollectionTypesSet1_ManyGeogPolygon = new System.Collections.Generic.List<System.Spatial.GeographyPolygon>();
            AllCollectionTypesSet1_ManyGeogPolygon.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyPolygon>(new System.IO.StringReader("SRID=4326;POLYGON ((20 35, 45 20, 30 5, 10 10, 10 30, 20 35), (30 20, 20 25, 20 1" +
                            "5, 30 20))")));
            AllCollectionTypesSet1_ManyGeogPolygon.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyPolygon>(new System.IO.StringReader("SRID=4326;POLYGON ((20 35, 45 20, 30 5, 10 10, 10 30, 20 35), (30 20, 20 25, 20 1" +
                            "5, 30 20))")));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet1"], "ManyGeogPolygon", AllCollectionTypesSet1_ManyGeogPolygon);
            System.Collections.Generic.List<System.Spatial.GeometryPoint> AllCollectionTypesSet1_ManyGeomPoint = new System.Collections.Generic.List<System.Spatial.GeometryPoint>();
            updatable.SetValue(resourceLookup["AllCollectionTypesSet1"], "ManyGeomPoint", AllCollectionTypesSet1_ManyGeomPoint);
            System.Collections.Generic.List<System.Spatial.GeometryLineString> AllCollectionTypesSet1_ManyGeomLine = new System.Collections.Generic.List<System.Spatial.GeometryLineString>();
            AllCollectionTypesSet1_ManyGeomLine.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryLineString>(new System.IO.StringReader("SRID=0;LINESTRING (1 1, 3 3)")));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet1"], "ManyGeomLine", AllCollectionTypesSet1_ManyGeomLine);
            System.Collections.Generic.List<System.Spatial.GeometryPolygon> AllCollectionTypesSet1_ManyGeomPolygon = new System.Collections.Generic.List<System.Spatial.GeometryPolygon>();
            updatable.SetValue(resourceLookup["AllCollectionTypesSet1"], "ManyGeomPolygon", AllCollectionTypesSet1_ManyGeomPolygon);


            resourceLookup.Add("AllCollectionTypesSet2", updatable.CreateResource("AllGeoCollectionTypesSet", "Microsoft.Test.OData.Services.AstoriaDefaultService.AllSpatialCollectionTypes_Simple"));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet2"], "Id", -8);
            System.Collections.Generic.List<System.Spatial.GeographyPoint> AllCollectionTypesSet2_ManyGeogPoint = new System.Collections.Generic.List<System.Spatial.GeographyPoint>();
            updatable.SetValue(resourceLookup["AllCollectionTypesSet2"], "ManyGeogPoint", AllCollectionTypesSet2_ManyGeogPoint);
            System.Collections.Generic.List<System.Spatial.GeographyLineString> AllCollectionTypesSet2_ManyGeogLine = new System.Collections.Generic.List<System.Spatial.GeographyLineString>();
            updatable.SetValue(resourceLookup["AllCollectionTypesSet2"], "ManyGeogLine", AllCollectionTypesSet2_ManyGeogLine);
            System.Collections.Generic.List<System.Spatial.GeographyPolygon> AllCollectionTypesSet2_ManyGeogPolygon = new System.Collections.Generic.List<System.Spatial.GeographyPolygon>();
            updatable.SetValue(resourceLookup["AllCollectionTypesSet2"], "ManyGeogPolygon", AllCollectionTypesSet2_ManyGeogPolygon);
            System.Collections.Generic.List<System.Spatial.GeometryPoint> AllCollectionTypesSet2_ManyGeomPoint = new System.Collections.Generic.List<System.Spatial.GeometryPoint>();
            updatable.SetValue(resourceLookup["AllCollectionTypesSet2"], "ManyGeomPoint", AllCollectionTypesSet2_ManyGeomPoint);
            System.Collections.Generic.List<System.Spatial.GeometryLineString> AllCollectionTypesSet2_ManyGeomLine = new System.Collections.Generic.List<System.Spatial.GeometryLineString>();
            AllCollectionTypesSet2_ManyGeomLine.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryLineString>(new System.IO.StringReader("SRID=0;LINESTRING (1 1, 3 3, 2 4, 2 0)")));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet2"], "ManyGeomLine", AllCollectionTypesSet2_ManyGeomLine);
            System.Collections.Generic.List<System.Spatial.GeometryPolygon> AllCollectionTypesSet2_ManyGeomPolygon = new System.Collections.Generic.List<System.Spatial.GeometryPolygon>();
            AllCollectionTypesSet2_ManyGeomPolygon.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryPolygon>(new System.IO.StringReader("SRID=0;POLYGON ((30 20, 10 40, 45 40, 30 20))")));
            AllCollectionTypesSet2_ManyGeomPolygon.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryPolygon>(new System.IO.StringReader("SRID=0;POLYGON ((20 35, 45 20, 30 5, 10 10, 10 30, 20 35), (30 20, 20 25, 20 15, " +
                            "30 20))")));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet2"], "ManyGeomPolygon", AllCollectionTypesSet2_ManyGeomPolygon);


            resourceLookup.Add("AllCollectionTypesSet3", updatable.CreateResource("AllGeoCollectionTypesSet", "Microsoft.Test.OData.Services.AstoriaDefaultService.AllSpatialCollectionTypes_Simple"));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet3"], "Id", -7);
            System.Collections.Generic.List<System.Spatial.GeographyPoint> AllCollectionTypesSet3_ManyGeogPoint = new System.Collections.Generic.List<System.Spatial.GeographyPoint>();
            AllCollectionTypesSet3_ManyGeogPoint.Add(System.Spatial.GeographyPoint.Create(52.795D, 173.105D));
            AllCollectionTypesSet3_ManyGeogPoint.Add(System.Spatial.GeographyPoint.Create(52.795D, 173.105D));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet3"], "ManyGeogPoint", AllCollectionTypesSet3_ManyGeogPoint);
            System.Collections.Generic.List<System.Spatial.GeographyLineString> AllCollectionTypesSet3_ManyGeogLine = new System.Collections.Generic.List<System.Spatial.GeographyLineString>();
            updatable.SetValue(resourceLookup["AllCollectionTypesSet3"], "ManyGeogLine", AllCollectionTypesSet3_ManyGeogLine);
            System.Collections.Generic.List<System.Spatial.GeographyPolygon> AllCollectionTypesSet3_ManyGeogPolygon = new System.Collections.Generic.List<System.Spatial.GeographyPolygon>();
            AllCollectionTypesSet3_ManyGeogPolygon.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyPolygon>(new System.IO.StringReader("SRID=4326;POLYGON ((30 20, 10 40, 45 40, 30 20))")));
            AllCollectionTypesSet3_ManyGeogPolygon.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyPolygon>(new System.IO.StringReader("SRID=4326;POLYGON ((20 35, 45 20, 30 5, 10 10, 10 30, 20 35), (30 20, 20 25, 20 1" +
                            "5, 30 20))")));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet3"], "ManyGeogPolygon", AllCollectionTypesSet3_ManyGeogPolygon);
            System.Collections.Generic.List<System.Spatial.GeometryPoint> AllCollectionTypesSet3_ManyGeomPoint = new System.Collections.Generic.List<System.Spatial.GeometryPoint>();
            AllCollectionTypesSet3_ManyGeomPoint.Add(System.Spatial.GeometryPoint.Create(4513675.2944411123D, 6032903.5882574534D));
            AllCollectionTypesSet3_ManyGeomPoint.Add(System.Spatial.GeometryPoint.Create(4605537.5782547453D, 5924460.4760093335D));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet3"], "ManyGeomPoint", AllCollectionTypesSet3_ManyGeomPoint);
            System.Collections.Generic.List<System.Spatial.GeometryLineString> AllCollectionTypesSet3_ManyGeomLine = new System.Collections.Generic.List<System.Spatial.GeometryLineString>();
            AllCollectionTypesSet3_ManyGeomLine.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryLineString>(new System.IO.StringReader("SRID=0;LINESTRING (1 1, 3 3)")));
            AllCollectionTypesSet3_ManyGeomLine.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryLineString>(new System.IO.StringReader("SRID=0;LINESTRING (1 1, 3 3)")));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet3"], "ManyGeomLine", AllCollectionTypesSet3_ManyGeomLine);
            System.Collections.Generic.List<System.Spatial.GeometryPolygon> AllCollectionTypesSet3_ManyGeomPolygon = new System.Collections.Generic.List<System.Spatial.GeometryPolygon>();
            AllCollectionTypesSet3_ManyGeomPolygon.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryPolygon>(new System.IO.StringReader("SRID=0;POLYGON ((20 35, 45 20, 30 5, 10 10, 10 30, 20 35), (30 20, 20 25, 20 15, " +
                            "30 20))")));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet3"], "ManyGeomPolygon", AllCollectionTypesSet3_ManyGeomPolygon);


            resourceLookup.Add("AllCollectionTypesSet4", updatable.CreateResource("AllGeoCollectionTypesSet", "Microsoft.Test.OData.Services.AstoriaDefaultService.AllSpatialCollectionTypes_Simple"));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet4"], "Id", -6);
            System.Collections.Generic.List<System.Spatial.GeographyPoint> AllCollectionTypesSet4_ManyGeogPoint = new System.Collections.Generic.List<System.Spatial.GeographyPoint>();
            updatable.SetValue(resourceLookup["AllCollectionTypesSet4"], "ManyGeogPoint", AllCollectionTypesSet4_ManyGeogPoint);
            System.Collections.Generic.List<System.Spatial.GeographyLineString> AllCollectionTypesSet4_ManyGeogLine = new System.Collections.Generic.List<System.Spatial.GeographyLineString>();
            updatable.SetValue(resourceLookup["AllCollectionTypesSet4"], "ManyGeogLine", AllCollectionTypesSet4_ManyGeogLine);
            System.Collections.Generic.List<System.Spatial.GeographyPolygon> AllCollectionTypesSet4_ManyGeogPolygon = new System.Collections.Generic.List<System.Spatial.GeographyPolygon>();
            updatable.SetValue(resourceLookup["AllCollectionTypesSet4"], "ManyGeogPolygon", AllCollectionTypesSet4_ManyGeogPolygon);
            System.Collections.Generic.List<System.Spatial.GeometryPoint> AllCollectionTypesSet4_ManyGeomPoint = new System.Collections.Generic.List<System.Spatial.GeometryPoint>();
            updatable.SetValue(resourceLookup["AllCollectionTypesSet4"], "ManyGeomPoint", AllCollectionTypesSet4_ManyGeomPoint);
            System.Collections.Generic.List<System.Spatial.GeometryLineString> AllCollectionTypesSet4_ManyGeomLine = new System.Collections.Generic.List<System.Spatial.GeometryLineString>();
            updatable.SetValue(resourceLookup["AllCollectionTypesSet4"], "ManyGeomLine", AllCollectionTypesSet4_ManyGeomLine);
            System.Collections.Generic.List<System.Spatial.GeometryPolygon> AllCollectionTypesSet4_ManyGeomPolygon = new System.Collections.Generic.List<System.Spatial.GeometryPolygon>();
            AllCollectionTypesSet4_ManyGeomPolygon.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryPolygon>(new System.IO.StringReader("SRID=0;POLYGON EMPTY")));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet4"], "ManyGeomPolygon", AllCollectionTypesSet4_ManyGeomPolygon);


            resourceLookup.Add("AllCollectionTypesSet5", updatable.CreateResource("AllGeoCollectionTypesSet", "Microsoft.Test.OData.Services.AstoriaDefaultService.AllSpatialCollectionTypes_Simple"));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet5"], "Id", -5);
            System.Collections.Generic.List<System.Spatial.GeographyPoint> AllCollectionTypesSet5_ManyGeogPoint = new System.Collections.Generic.List<System.Spatial.GeographyPoint>();
            updatable.SetValue(resourceLookup["AllCollectionTypesSet5"], "ManyGeogPoint", AllCollectionTypesSet5_ManyGeogPoint);
            System.Collections.Generic.List<System.Spatial.GeographyLineString> AllCollectionTypesSet5_ManyGeogLine = new System.Collections.Generic.List<System.Spatial.GeographyLineString>();
            AllCollectionTypesSet5_ManyGeogLine.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyLineString>(new System.IO.StringReader("SRID=4326;LINESTRING (10.5 10.5, 20.5 20.5, 10.5 40.5)")));
            AllCollectionTypesSet5_ManyGeogLine.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyLineString>(new System.IO.StringReader("SRID=4326;LINESTRING (40.5 40.5, 30.5 30.5, 40.5 20.5, 30.5 10.5)")));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet5"], "ManyGeogLine", AllCollectionTypesSet5_ManyGeogLine);
            System.Collections.Generic.List<System.Spatial.GeographyPolygon> AllCollectionTypesSet5_ManyGeogPolygon = new System.Collections.Generic.List<System.Spatial.GeographyPolygon>();
            AllCollectionTypesSet5_ManyGeogPolygon.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyPolygon>(new System.IO.StringReader("SRID=4326;POLYGON ((15 5, 40 10, 10 20, 5 10, 15 5))")));
            AllCollectionTypesSet5_ManyGeogPolygon.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyPolygon>(new System.IO.StringReader("SRID=4326;POLYGON ((20 35, 45 20, 30 5, 10 10, 10 30, 20 35), (30 20, 20 25, 20 1" +
                            "5, 30 20))")));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet5"], "ManyGeogPolygon", AllCollectionTypesSet5_ManyGeogPolygon);
            System.Collections.Generic.List<System.Spatial.GeometryPoint> AllCollectionTypesSet5_ManyGeomPoint = new System.Collections.Generic.List<System.Spatial.GeometryPoint>();
            updatable.SetValue(resourceLookup["AllCollectionTypesSet5"], "ManyGeomPoint", AllCollectionTypesSet5_ManyGeomPoint);
            System.Collections.Generic.List<System.Spatial.GeometryLineString> AllCollectionTypesSet5_ManyGeomLine = new System.Collections.Generic.List<System.Spatial.GeometryLineString>();
            AllCollectionTypesSet5_ManyGeomLine.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryLineString>(new System.IO.StringReader("SRID=0;LINESTRING (1 1, 3 3, 2 4, 2 0, 1 1)")));
            AllCollectionTypesSet5_ManyGeomLine.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryLineString>(new System.IO.StringReader("SRID=0;LINESTRING (1 1, 3 3, 2 4, 2 0)")));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet5"], "ManyGeomLine", AllCollectionTypesSet5_ManyGeomLine);
            System.Collections.Generic.List<System.Spatial.GeometryPolygon> AllCollectionTypesSet5_ManyGeomPolygon = new System.Collections.Generic.List<System.Spatial.GeometryPolygon>();
            AllCollectionTypesSet5_ManyGeomPolygon.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryPolygon>(new System.IO.StringReader("SRID=0;POLYGON EMPTY")));
            AllCollectionTypesSet5_ManyGeomPolygon.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryPolygon>(new System.IO.StringReader("SRID=0;POLYGON ((15 5, 40 10, 10 20, 5 10, 15 5))")));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet5"], "ManyGeomPolygon", AllCollectionTypesSet5_ManyGeomPolygon);


            resourceLookup.Add("AllCollectionTypesSet6", updatable.CreateResource("AllGeoCollectionTypesSet", "Microsoft.Test.OData.Services.AstoriaDefaultService.AllSpatialCollectionTypes_Simple"));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet6"], "Id", -4);
            System.Collections.Generic.List<System.Spatial.GeographyPoint> AllCollectionTypesSet6_ManyGeogPoint = new System.Collections.Generic.List<System.Spatial.GeographyPoint>();
            AllCollectionTypesSet6_ManyGeogPoint.Add(System.Spatial.GeographyPoint.Create(52.7892D, 172.826D));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet6"], "ManyGeogPoint", AllCollectionTypesSet6_ManyGeogPoint);
            System.Collections.Generic.List<System.Spatial.GeographyLineString> AllCollectionTypesSet6_ManyGeogLine = new System.Collections.Generic.List<System.Spatial.GeographyLineString>();
            AllCollectionTypesSet6_ManyGeogLine.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyLineString>(new System.IO.StringReader("SRID=4326;LINESTRING (10.5 10.5, 20.5 20.5, 10.5 40.5)")));
            AllCollectionTypesSet6_ManyGeogLine.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyLineString>(new System.IO.StringReader("SRID=4326;LINESTRING (40 40, 30 30, 40 20, 30 10)")));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet6"], "ManyGeogLine", AllCollectionTypesSet6_ManyGeogLine);
            System.Collections.Generic.List<System.Spatial.GeographyPolygon> AllCollectionTypesSet6_ManyGeogPolygon = new System.Collections.Generic.List<System.Spatial.GeographyPolygon>();
            updatable.SetValue(resourceLookup["AllCollectionTypesSet6"], "ManyGeogPolygon", AllCollectionTypesSet6_ManyGeogPolygon);
            System.Collections.Generic.List<System.Spatial.GeometryPoint> AllCollectionTypesSet6_ManyGeomPoint = new System.Collections.Generic.List<System.Spatial.GeometryPoint>();
            AllCollectionTypesSet6_ManyGeomPoint.Add(System.Spatial.GeometryPoint.Create(4505479.22279754D, 6049837.1931612007D));
            AllCollectionTypesSet6_ManyGeomPoint.Add(System.Spatial.GeometryPoint.Create(4515785.037825482D, 6055723.864035368D));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet6"], "ManyGeomPoint", AllCollectionTypesSet6_ManyGeomPoint);
            System.Collections.Generic.List<System.Spatial.GeometryLineString> AllCollectionTypesSet6_ManyGeomLine = new System.Collections.Generic.List<System.Spatial.GeometryLineString>();
            AllCollectionTypesSet6_ManyGeomLine.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryLineString>(new System.IO.StringReader("SRID=0;LINESTRING (1 1, 3 3)")));
            AllCollectionTypesSet6_ManyGeomLine.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryLineString>(new System.IO.StringReader("SRID=0;LINESTRING (1 1, 3 3, 2 4, 2 0)")));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet6"], "ManyGeomLine", AllCollectionTypesSet6_ManyGeomLine);
            System.Collections.Generic.List<System.Spatial.GeometryPolygon> AllCollectionTypesSet6_ManyGeomPolygon = new System.Collections.Generic.List<System.Spatial.GeometryPolygon>();
            AllCollectionTypesSet6_ManyGeomPolygon.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryPolygon>(new System.IO.StringReader("SRID=0;POLYGON ((20 35, 45 20, 30 5, 10 10, 10 30, 20 35), (30 20, 20 25, 20 15, " +
                            "30 20))")));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet6"], "ManyGeomPolygon", AllCollectionTypesSet6_ManyGeomPolygon);


            resourceLookup.Add("AllCollectionTypesSet7", updatable.CreateResource("AllGeoCollectionTypesSet", "Microsoft.Test.OData.Services.AstoriaDefaultService.AllSpatialCollectionTypes_Simple"));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet7"], "Id", -3);
            System.Collections.Generic.List<System.Spatial.GeographyPoint> AllCollectionTypesSet7_ManyGeogPoint = new System.Collections.Generic.List<System.Spatial.GeographyPoint>();
            updatable.SetValue(resourceLookup["AllCollectionTypesSet7"], "ManyGeogPoint", AllCollectionTypesSet7_ManyGeogPoint);
            System.Collections.Generic.List<System.Spatial.GeographyLineString> AllCollectionTypesSet7_ManyGeogLine = new System.Collections.Generic.List<System.Spatial.GeographyLineString>();
            updatable.SetValue(resourceLookup["AllCollectionTypesSet7"], "ManyGeogLine", AllCollectionTypesSet7_ManyGeogLine);
            System.Collections.Generic.List<System.Spatial.GeographyPolygon> AllCollectionTypesSet7_ManyGeogPolygon = new System.Collections.Generic.List<System.Spatial.GeographyPolygon>();
            updatable.SetValue(resourceLookup["AllCollectionTypesSet7"], "ManyGeogPolygon", AllCollectionTypesSet7_ManyGeogPolygon);
            System.Collections.Generic.List<System.Spatial.GeometryPoint> AllCollectionTypesSet7_ManyGeomPoint = new System.Collections.Generic.List<System.Spatial.GeometryPoint>();
            AllCollectionTypesSet7_ManyGeomPoint.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryPoint>(new System.IO.StringReader("SRID=0;POINT EMPTY")));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet7"], "ManyGeomPoint", AllCollectionTypesSet7_ManyGeomPoint);
            System.Collections.Generic.List<System.Spatial.GeometryLineString> AllCollectionTypesSet7_ManyGeomLine = new System.Collections.Generic.List<System.Spatial.GeometryLineString>();
            updatable.SetValue(resourceLookup["AllCollectionTypesSet7"], "ManyGeomLine", AllCollectionTypesSet7_ManyGeomLine);
            System.Collections.Generic.List<System.Spatial.GeometryPolygon> AllCollectionTypesSet7_ManyGeomPolygon = new System.Collections.Generic.List<System.Spatial.GeometryPolygon>();
            AllCollectionTypesSet7_ManyGeomPolygon.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryPolygon>(new System.IO.StringReader("SRID=0;POLYGON ((30 20, 10 40, 45 40, 30 20))")));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet7"], "ManyGeomPolygon", AllCollectionTypesSet7_ManyGeomPolygon);


            resourceLookup.Add("AllCollectionTypesSet8", updatable.CreateResource("AllGeoCollectionTypesSet", "Microsoft.Test.OData.Services.AstoriaDefaultService.AllSpatialCollectionTypes_Simple"));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet8"], "Id", -2);
            System.Collections.Generic.List<System.Spatial.GeographyPoint> AllCollectionTypesSet8_ManyGeogPoint = new System.Collections.Generic.List<System.Spatial.GeographyPoint>();
            AllCollectionTypesSet8_ManyGeogPoint.Add(System.Spatial.GeographyPoint.Create(51.9917D, 177.508D));
            AllCollectionTypesSet8_ManyGeogPoint.Add(System.Spatial.GeographyPoint.Create(52.9778D, 172.914D));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet8"], "ManyGeogPoint", AllCollectionTypesSet8_ManyGeogPoint);
            System.Collections.Generic.List<System.Spatial.GeographyLineString> AllCollectionTypesSet8_ManyGeogLine = new System.Collections.Generic.List<System.Spatial.GeographyLineString>();
            AllCollectionTypesSet8_ManyGeogLine.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyLineString>(new System.IO.StringReader("SRID=4326;LINESTRING (40 40, 30 30, 40 20, 30 10)")));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet8"], "ManyGeogLine", AllCollectionTypesSet8_ManyGeogLine);
            System.Collections.Generic.List<System.Spatial.GeographyPolygon> AllCollectionTypesSet8_ManyGeogPolygon = new System.Collections.Generic.List<System.Spatial.GeographyPolygon>();
            AllCollectionTypesSet8_ManyGeogPolygon.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyPolygon>(new System.IO.StringReader("SRID=4326;POLYGON ((15 5, 40 10, 10 20, 5 10, 15 5))")));
            AllCollectionTypesSet8_ManyGeogPolygon.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyPolygon>(new System.IO.StringReader("SRID=4326;POLYGON ((15 5, 40 10, 10 20, 5 10, 15 5))")));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet8"], "ManyGeogPolygon", AllCollectionTypesSet8_ManyGeogPolygon);
            System.Collections.Generic.List<System.Spatial.GeometryPoint> AllCollectionTypesSet8_ManyGeomPoint = new System.Collections.Generic.List<System.Spatial.GeometryPoint>();
            AllCollectionTypesSet8_ManyGeomPoint.Add(System.Spatial.GeometryPoint.Create(4386226.037061994D, 6339065.9187833387D));
            AllCollectionTypesSet8_ManyGeomPoint.Add(System.Spatial.GeometryPoint.Create(4515785.037825482D, 6055723.864035368D));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet8"], "ManyGeomPoint", AllCollectionTypesSet8_ManyGeomPoint);
            System.Collections.Generic.List<System.Spatial.GeometryLineString> AllCollectionTypesSet8_ManyGeomLine = new System.Collections.Generic.List<System.Spatial.GeometryLineString>();
            updatable.SetValue(resourceLookup["AllCollectionTypesSet8"], "ManyGeomLine", AllCollectionTypesSet8_ManyGeomLine);
            System.Collections.Generic.List<System.Spatial.GeometryPolygon> AllCollectionTypesSet8_ManyGeomPolygon = new System.Collections.Generic.List<System.Spatial.GeometryPolygon>();
            AllCollectionTypesSet8_ManyGeomPolygon.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryPolygon>(new System.IO.StringReader("SRID=0;POLYGON ((30 20, 10 40, 45 40, 30 20))")));
            AllCollectionTypesSet8_ManyGeomPolygon.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryPolygon>(new System.IO.StringReader("SRID=0;POLYGON ((20 35, 45 20, 30 5, 10 10, 10 30, 20 35), (30 20, 20 25, 20 15, " +
                            "30 20))")));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet8"], "ManyGeomPolygon", AllCollectionTypesSet8_ManyGeomPolygon);


            resourceLookup.Add("AllCollectionTypesSet9", updatable.CreateResource("AllGeoCollectionTypesSet", "Microsoft.Test.OData.Services.AstoriaDefaultService.AllSpatialCollectionTypes_Simple"));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet9"], "Id", -1);
            System.Collections.Generic.List<System.Spatial.GeographyPoint> AllCollectionTypesSet9_ManyGeogPoint = new System.Collections.Generic.List<System.Spatial.GeographyPoint>();
            AllCollectionTypesSet9_ManyGeogPoint.Add(System.Spatial.GeographyPoint.Create(51.9917D, 177.508D));
            AllCollectionTypesSet9_ManyGeogPoint.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyPoint>(new System.IO.StringReader("SRID=4326;POINT EMPTY")));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet9"], "ManyGeogPoint", AllCollectionTypesSet9_ManyGeogPoint);
            System.Collections.Generic.List<System.Spatial.GeographyLineString> AllCollectionTypesSet9_ManyGeogLine = new System.Collections.Generic.List<System.Spatial.GeographyLineString>();
            AllCollectionTypesSet9_ManyGeogLine.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyLineString>(new System.IO.StringReader("SRID=4326;LINESTRING EMPTY")));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet9"], "ManyGeogLine", AllCollectionTypesSet9_ManyGeogLine);
            System.Collections.Generic.List<System.Spatial.GeographyPolygon> AllCollectionTypesSet9_ManyGeogPolygon = new System.Collections.Generic.List<System.Spatial.GeographyPolygon>();
            AllCollectionTypesSet9_ManyGeogPolygon.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyPolygon>(new System.IO.StringReader("SRID=4326;POLYGON ((20 35, 45 20, 30 5, 10 10, 10 30, 20 35), (30 20, 20 25, 20 1" +
                            "5, 30 20))")));
            AllCollectionTypesSet9_ManyGeogPolygon.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeographyPolygon>(new System.IO.StringReader("SRID=4326;POLYGON ((20 35, 45 20, 30 5, 10 10, 10 30, 20 35), (30 20, 20 25, 20 1" +
                            "5, 30 20))")));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet9"], "ManyGeogPolygon", AllCollectionTypesSet9_ManyGeogPolygon);
            System.Collections.Generic.List<System.Spatial.GeometryPoint> AllCollectionTypesSet9_ManyGeomPoint = new System.Collections.Generic.List<System.Spatial.GeometryPoint>();
            AllCollectionTypesSet9_ManyGeomPoint.Add(System.Spatial.GeometryPoint.Create(4513675.2944411123D, 6032903.5882574534D));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet9"], "ManyGeomPoint", AllCollectionTypesSet9_ManyGeomPoint);
            System.Collections.Generic.List<System.Spatial.GeometryLineString> AllCollectionTypesSet9_ManyGeomLine = new System.Collections.Generic.List<System.Spatial.GeometryLineString>();
            AllCollectionTypesSet9_ManyGeomLine.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryLineString>(new System.IO.StringReader("SRID=0;LINESTRING (1 1, 3 3)")));
            AllCollectionTypesSet9_ManyGeomLine.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryLineString>(new System.IO.StringReader("SRID=0;LINESTRING EMPTY")));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet9"], "ManyGeomLine", AllCollectionTypesSet9_ManyGeomLine);
            System.Collections.Generic.List<System.Spatial.GeometryPolygon> AllCollectionTypesSet9_ManyGeomPolygon = new System.Collections.Generic.List<System.Spatial.GeometryPolygon>();
            AllCollectionTypesSet9_ManyGeomPolygon.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryPolygon>(new System.IO.StringReader("SRID=0;POLYGON ((15 5, 40 10, 10 20, 5 10, 15 5))")));
            AllCollectionTypesSet9_ManyGeomPolygon.Add(System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryPolygon>(new System.IO.StringReader("SRID=0;POLYGON ((15 5, 40 10, 10 20, 5 10, 15 5))")));
            updatable.SetValue(resourceLookup["AllCollectionTypesSet9"], "ManyGeomPolygon", AllCollectionTypesSet9_ManyGeomPolygon);

        }

        private static void PopulateCustomer(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {

            resourceLookup.Add("Customer0", updatable.CreateResource("Customer", "Microsoft.Test.OData.Services.AstoriaDefaultService.Customer"));
            updatable.SetValue(resourceLookup["Customer0"], "CustomerId", -10);
            updatable.SetValue(resourceLookup["Customer0"], "Name", "commastartedtotalnormaloffsetsregisteredgroupcelestialexposureconventionsimportca" +
                    "stclass");
            resourceLookup.Add("ContactDetails_0", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_0_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_0_EmailBag.Add("rdstukrvlltteßzi");
            ContactDetails_0_EmailBag.Add("psgdkmxamznjulzbsohqjytbxhnojbufe");
            ContactDetails_0_EmailBag.Add("をﾝぺひぼゼせ暦裹я裹ぺあ亜ぞｚァバ畚マﾈぞゼあﾈ弌チァ歹まゼ縷チハ裹亜黑ほゼё歹");
            updatable.SetValue(resourceLookup["ContactDetails_0"], "EmailBag", ContactDetails_0_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_0_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_0_AlternativeNames.Add("グぁマせぺﾈソぁぼソひバたぴソ歹九ﾈボボяポソ畚クяせべ歹珱Я欲タハバミ裹ぼボをｦ歹んひ九ひ匚ぁａ");
            ContactDetails_0_AlternativeNames.Add("qckrnuruxcbhjfimnsykgfquffobcadpsaocixoeljhspxrhebkudppgndgcrlyvynqhbujrnvyxyymhn" +
                    "roemigogsqulvgallta");
            ContactDetails_0_AlternativeNames.Add("btsnhqrjqryqzgxducl");
            ContactDetails_0_AlternativeNames.Add("qbtlssjhunufmzdv");
            ContactDetails_0_AlternativeNames.Add("ボんЯぜチべゼボボほａ匚ミぼ九ぁひチ珱黑ミんぁタび暦クソソボゾんんあゼぞひタボタぜん弌ひべ匚");
            ContactDetails_0_AlternativeNames.Add("vicqasfdkxsuyuzspjqunxpyfuhlxfhgfqnlcpdfivqnxqoothnfsbuykfguftgulgldnkkzufssbae");
            ContactDetails_0_AlternativeNames.Add("九ソミせボぜゾボёａをぜЯまゾタぜタひ縷ダんａバたゼソ");
            ContactDetails_0_AlternativeNames.Add("ぽマタぁぁ黑ソゼミゼ匚ｚソダマぁァゾぽミａタゾ弌ミゼタそｚぺポせ裹バポハハｦぺチあマ匚ミ");
            ContactDetails_0_AlternativeNames.Add("hssiißuamtctgqhglmusexyikhcsqctusonubxorssyizhyqpbtbdßjnelxqttkhdalabibuqhiubtßsp" +
                    "trmzelud");
            ContactDetails_0_AlternativeNames.Add("gbjssllxzzxkmßppyyrhgmoeßizlcmsuqqnvjßudszevtfunflqzqcuubukypßqjcix");
            updatable.SetValue(resourceLookup["ContactDetails_0"], "AlternativeNames", ContactDetails_0_AlternativeNames);
            resourceLookup.Add("Aliases_0", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_0_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_0_AlternativeNames.Add("ゼポソソァんマａグぴ九縷亜ぞゼソグバぼダぽママぽポチボソぼぜゾんミぴほダミミ畚珱九ｚべ弌畚タソｚゼソぁび裹ァソマｦひ匚亜ポべポぽマゼたチ裹歹ミポ");
            Aliases_0_AlternativeNames.Add("flzjuisevegjjtmpnssobmdssikhzepsjklnoceuqrßuychauxhdutqcdenvssubqkoqyzxpfmvflbhjs" +
                    "");
            Aliases_0_AlternativeNames.Add("esgmrxddisdvykgttpmizcethjuazqxemuossopssaqpmqdßkayrrocgsxqpo");
            Aliases_0_AlternativeNames.Add("クソ珱べをマんグハひボソソんミソソゼﾝぞたぼｚミ歹ぴ");
            Aliases_0_AlternativeNames.Add("ljrggbaseqsrkelksvhouoscmoilogibae");
            Aliases_0_AlternativeNames.Add("そぜぜママゼミぼゼボべソほあんせひびゼミソ弌ほそタボマチタマソﾈ弌チポ匚まソゾマЯЯたゾ裹あ畚ん弌た珱畚マЯソァ珱ﾈびё九たミミぴぺポマゼダ弌ミマママソボ亜ぺソ匚" +
                    "グ弌グ歹ハま匚そん黑ん");
            Aliases_0_AlternativeNames.Add("ydjfrjbzcgouafasiutdhhgypssyniqlkdtxbclnaplnasjfliqxnmuplznstnqvpyrzdkxkqbtszvguu" +
                    "rhllvzziugdsuvl");
            Aliases_0_AlternativeNames.Add("たёタЯяまひぺァ暦ソマポハクタせたひァ暦ｦ九暦ぞぜチ匚欲ゼほ九ぺ畚びぞポボクぴをチチそボソマポんぽミァ弌ァぞぴまミ縷黑ミゼゼｚチミソ暦ゼほ畚ソ匚ﾈёほゼボぴポゼ" +
                    "縷ソチポ裹ｦ縷九ﾝ歹ａ九ソソ");
            updatable.SetValue(resourceLookup["Aliases_0"], "AlternativeNames", Aliases_0_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_0"], "ContactAlias", resourceLookup["Aliases_0"]);
            resourceLookup.Add("Phone_0", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_0"], "PhoneNumber", "畚ぼせゼぽチ欲を縷弌ポタぺゾ欲ａ歹まマ亜チぁゼゼａマァゾぞあ弌そをポダボグびゼァたチ珱べぴゼタｚボﾈァァ歹ぞゼ欲欲マソチぺんび暦ﾝタぺダｚぴダポ縷ァボЯべぺべタび" +
                    "グ珱たミソぽひぼミ暦マミ歹そ欲ゼёべポ");
            updatable.SetValue(resourceLookup["Phone_0"], "Extension", "jqjklhnnkyhujailcedbguyectpuamgbghreatqvobbtj");
            updatable.SetValue(resourceLookup["ContactDetails_0"], "HomePhone", resourceLookup["Phone_0"]);
            resourceLookup.Add("Phone_1", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_1"], "PhoneNumber", "そマ弌あハミゼぼマ匚ソバｚチぴソぁんёタゾゼソせぴボひハﾈゼぽべァたぺゾチァそ");
            updatable.SetValue(resourceLookup["Phone_1"], "Extension", "erpdbdvgezuztcsyßpxddmcdvgsysbtsssskhjpgssgbicdbcmdykutudsnkflxpzqxbcssdyfdqqmiuf" +
                    "ssinxkadeßustxßf");
            updatable.SetValue(resourceLookup["ContactDetails_0"], "WorkPhone", resourceLookup["Phone_1"]);
            System.Collections.Generic.List<object> ContactDetails_0_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_2", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_2"], "PhoneNumber", "essfchpbmodumdlbssaoygvcecnegßumuvszyo");
            updatable.SetValue(resourceLookup["Phone_2"], "Extension", "ilvxmcmkixinhonuxeqfcbsnlgufneqhijddgurdkuvvj");
            ContactDetails_0_MobilePhoneBag.Add(resourceLookup["Phone_2"]);
            resourceLookup.Add("Phone_3", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_3"], "PhoneNumber", "bbyr");
            updatable.SetValue(resourceLookup["Phone_3"], "Extension", "グぴゼほ裹яほマタﾈ畚をソ九クゼ畚ゼァ縷ひグｦぽяダ歹");
            ContactDetails_0_MobilePhoneBag.Add(resourceLookup["Phone_3"]);
            resourceLookup.Add("Phone_4", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_4"], "PhoneNumber", "litlxcyvpspjqankvmvtmvoabobguscosktgzul");
            updatable.SetValue(resourceLookup["Phone_4"], "Extension", "jumpßßhqzmjxqßufuaprymlrb");
            ContactDetails_0_MobilePhoneBag.Add(resourceLookup["Phone_4"]);
            resourceLookup.Add("Phone_5", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_5"], "PhoneNumber", "bfi");
            updatable.SetValue(resourceLookup["Phone_5"], "Extension", "mbguodpfpohbmsnvtgxdvhssvnxfisadlnbtbvrbvfnitdjdnkdctzuukpylhfcvooryl");
            ContactDetails_0_MobilePhoneBag.Add(resourceLookup["Phone_5"]);
            resourceLookup.Add("Phone_6", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_6"], "PhoneNumber", "jmvrssnupsqltlmuegpybunosssspluvvgqenfgvrjhxqqjjqublkeekssyjisdssrxyvooj");
            updatable.SetValue(resourceLookup["Phone_6"], "Extension", "ａゾ暦ｦａゾをチёゼをぽァ亜ぽひぞポ裹ぼぜゼソミﾈミ暦ぽぽべべミ匚ａぞチボﾈｦ黑暦たほタクチダё珱ﾈををチソ");
            ContactDetails_0_MobilePhoneBag.Add(resourceLookup["Phone_6"]);
            resourceLookup.Add("Phone_7", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_7"], "PhoneNumber", "bqadubmkjprlorzjyuxghuthdxxufknlmasbsvhdteohujonmakgormaxpaxfhuyeuyozsqisnnfegcus" +
                    "fndzbhvjrfovkzhxu");
            updatable.SetValue(resourceLookup["Phone_7"], "Extension", "");
            ContactDetails_0_MobilePhoneBag.Add(resourceLookup["Phone_7"]);
            resourceLookup.Add("Phone_8", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_8"], "PhoneNumber", "mocßmhbuavyssxuosdkmcdqbkyadgusvssppytbtuurgßqacmbhfghvugzssvi");
            updatable.SetValue(resourceLookup["Phone_8"], "Extension", "をﾝ黑グぼ黑ゼタタポ九チｚポチゼポタぁａソァゼたゼぼﾈ匚ゼポまポ暦ｚマボぜ歹ぼ");
            ContactDetails_0_MobilePhoneBag.Add(resourceLookup["Phone_8"]);
            resourceLookup.Add("Phone_9", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_9"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_9"], "Extension", "バゼぼクグ");
            ContactDetails_0_MobilePhoneBag.Add(resourceLookup["Phone_9"]);
            resourceLookup.Add("Phone_10", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_10"], "PhoneNumber", "ｚチ亜ﾈﾝａバそ珱グせ亜ﾝﾈｦん歹ま亜ａポタミぜ弌珱ミゼЯほんボ裹я九ぁァ珱ぼクゼポﾈァﾈ珱ゼまゼあハマまﾈぼゼ歹ポぴたべべそボぁソ珱ｦぺ黑ﾝﾈёゼダЯタゼそｚソ" +
                    "ソﾝｚボボァ黑匚んべポポ");
            updatable.SetValue(resourceLookup["Phone_10"], "Extension", "gclzjelinpvjcxjmcrsbuzhiyuxrffycgjuonyzhkvazkklhsihhgzhg");
            ContactDetails_0_MobilePhoneBag.Add(resourceLookup["Phone_10"]);
            updatable.SetValue(resourceLookup["ContactDetails_0"], "MobilePhoneBag", ContactDetails_0_MobilePhoneBag);
            updatable.SetValue(resourceLookup["Customer0"], "PrimaryContactInfo", resourceLookup["ContactDetails_0"]);
            System.Collections.Generic.List<object> Customer0_BackupContactInfo = new System.Collections.Generic.List<object>();
            resourceLookup.Add("ContactDetails_1", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_1_EmailBag = new System.Collections.Generic.List<string>();
            updatable.SetValue(resourceLookup["ContactDetails_1"], "EmailBag", ContactDetails_1_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_1_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_1_AlternativeNames.Add("まミボあ弌ミんｦをミグミをｚソボソポタｚべ裹タ畚グぁ暦また裹九ぽマそ九ぽ歹ゼ九マソたそマЯぽぜゼゼ暦ハハバ珱ダグぴ亜マミａя欲ゼｦぜЯぴぴひ弌ё黑歹ゾあ");
            ContactDetails_1_AlternativeNames.Add("ぜｦグ畚ァをたポ珱チグああミЯ亜ゼァミミ黑ぽ裹ぺぼЯダマ匚ァゾハァ裹ハ匚ダたゾぜ暦ソひボ欲せミん黑ああ九せそｚ歹ぁたボァ九ソ縷ゾせ弌ミびぞぺべぽ珱バ黑ソそまゼひを" +
                    "ほ亜マぽミゾ");
            updatable.SetValue(resourceLookup["ContactDetails_1"], "AlternativeNames", ContactDetails_1_AlternativeNames);
            resourceLookup.Add("Aliases_1", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_1_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_1_AlternativeNames.Add("uhgnrnahnbsyvzlbltutlemsbcgdlchlxtsdpzkthvueixlxaelaq");
            Aliases_1_AlternativeNames.Add("pgjbsvduueebbnmcegqdkpfslcjtgmurnhzmalnyjbxthpujxsxcgugaaqrlhlkpvgpupzclssucrmfvj" +
                    "avnp");
            Aliases_1_AlternativeNames.Add("eylguilxscyeaatxlhlpzodkfuigqvayevsqkxrqcxkkndujcyechrsxqeazaocxczaucijpqugi");
            Aliases_1_AlternativeNames.Add("ёЯポぞミ暦亜タァぜ珱Яゼ縷ミボぜポハぺバまポぴたゾソチチァポま畚ひﾈﾈクﾝタせゾソポあゼぜё九ﾈべぽゼぁハま九ァソﾝぼクべｦЯゼチぞぽ黑九ぽそぞゾミぞボバ弌ぁソ" +
                    "マチクあぼほま畚");
            Aliases_1_AlternativeNames.Add("adtdlrqxssuxcssufnxuotrssvrqqssugxjsihixukrßßßirygjzsssktizcikerysklohuonekujmuts" +
                    "xuvdbacrj");
            Aliases_1_AlternativeNames.Add("uahsvudmlßdtbxxm");
            Aliases_1_AlternativeNames.Add("yulcdchqqcvrrmzhaeens");
            Aliases_1_AlternativeNames.Add("vxiefursgkqzptijhincpdm");
            updatable.SetValue(resourceLookup["Aliases_1"], "AlternativeNames", Aliases_1_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_1"], "ContactAlias", resourceLookup["Aliases_1"]);
            resourceLookup.Add("Phone_11", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_11"], "PhoneNumber", "jlessdhjbgglmofcyßucßqbrfßppgzvygdyssßpehkrdetitmßfddsplccvussrvidmkodchdfzjvfgos" +
                    "sbciq");
            updatable.SetValue(resourceLookup["Phone_11"], "Extension", null);
            updatable.SetValue(resourceLookup["ContactDetails_1"], "HomePhone", resourceLookup["Phone_11"]);
            resourceLookup.Add("Phone_12", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_12"], "PhoneNumber", "ミび珱ぜマボチﾝダぽｚゾぽバあﾝァま弌ひ裹せ畚ダミハびせボﾈぼグソバボあソ欲ミひ九ァハポぼ九暦Яｚボべ黑ｦボ九ボををグぜソゾクチ");
            updatable.SetValue(resourceLookup["Phone_12"], "Extension", null);
            updatable.SetValue(resourceLookup["ContactDetails_1"], "WorkPhone", resourceLookup["Phone_12"]);
            System.Collections.Generic.List<object> ContactDetails_1_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_13", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_13"], "PhoneNumber", "タチボゼダゾぺまﾈ匚ひぞﾝ匚ァゼ珱畚ﾈ亜ぞソボマぼﾝяボマ九たёｦぜマァァぴぴひせяゼんんァグ弌マたた暦ﾝぺゼ");
            updatable.SetValue(resourceLookup["Phone_13"], "Extension", null);
            ContactDetails_1_MobilePhoneBag.Add(resourceLookup["Phone_13"]);
            resourceLookup.Add("Phone_14", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_14"], "PhoneNumber", "ppcqouyißirrxriefhzqcssnpgatsphhaqsmkusuulsrel");
            updatable.SetValue(resourceLookup["Phone_14"], "Extension", "arndsscqeqfikblqsraouryqbtomdl");
            ContactDetails_1_MobilePhoneBag.Add(resourceLookup["Phone_14"]);
            resourceLookup.Add("Phone_15", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_15"], "PhoneNumber", "nsurrjxhlgirdbeguiahpoegmtrfnloccuxvvy");
            updatable.SetValue(resourceLookup["Phone_15"], "Extension", "gbozvdbifeutsjrkuxsmuacvkjf");
            ContactDetails_1_MobilePhoneBag.Add(resourceLookup["Phone_15"]);
            resourceLookup.Add("Phone_16", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_16"], "PhoneNumber", "ぞク匚暦ほチａゼそゾぴぁゼソあソびゼ亜ゼａマソァｦまタゼｦяバソまソポゼ");
            updatable.SetValue(resourceLookup["Phone_16"], "Extension", "zfkfubjahvaiigjjxjvyaljivssytqtduojnboksulaialfxabkbadnjxgjejl");
            ContactDetails_1_MobilePhoneBag.Add(resourceLookup["Phone_16"]);
            resourceLookup.Add("Phone_17", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_17"], "PhoneNumber", "ｦａ珱ぺ亜ｦぜそゾタクせクソ珱黑チぴチぽ裹チЯマ歹マゼをァんをﾈをバクﾝびЯ九ほｚひせａタをせボバチボタタソЯゼａたグあダ弌匚びべゼ弌九あ珱九チソァァミゾあびダバ" +
                    "弌マ九マ弌ソ珱ハｦあ");
            updatable.SetValue(resourceLookup["Phone_17"], "Extension", null);
            ContactDetails_1_MobilePhoneBag.Add(resourceLookup["Phone_17"]);
            resourceLookup.Add("Phone_18", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_18"], "PhoneNumber", "xrolfmsuiebodxvzujsiakjyyuitrytpufngeac");
            updatable.SetValue(resourceLookup["Phone_18"], "Extension", "ミぺミんぁべぁ暦ぺａあクゼまびチびソｚそたをチｚａァゾ黑弌ぴタぞそ裹ミミべ歹ぁハポぞチマそﾈびせ畚ソせ匚я弌ソゼポ弌グミ");
            ContactDetails_1_MobilePhoneBag.Add(resourceLookup["Phone_18"]);
            updatable.SetValue(resourceLookup["ContactDetails_1"], "MobilePhoneBag", ContactDetails_1_MobilePhoneBag);
            Customer0_BackupContactInfo.Add(resourceLookup["ContactDetails_1"]);
            resourceLookup.Add("ContactDetails_2", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_2_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_2_EmailBag.Add("yclmjgfhgjasvuyuhefisifjdehjgvloldusqljis");
            updatable.SetValue(resourceLookup["ContactDetails_2"], "EmailBag", ContactDetails_2_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_2_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_2_AlternativeNames.Add("rußknfirzrxssedhssyelzzbprcmzqchhkßaqfkavnj");
            ContactDetails_2_AlternativeNames.Add("gvpceoxgujmlbgcejlkndjßerimycssllpssfjzrnomadnluoovuossaegssxmpß");
            ContactDetails_2_AlternativeNames.Add("ぺａぁ畚ほя弌ぞ亜");
            ContactDetails_2_AlternativeNames.Add("cohmk");
            updatable.SetValue(resourceLookup["ContactDetails_2"], "AlternativeNames", ContactDetails_2_AlternativeNames);
            resourceLookup.Add("Aliases_2", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_2_AlternativeNames = new System.Collections.Generic.List<string>();
            updatable.SetValue(resourceLookup["Aliases_2"], "AlternativeNames", Aliases_2_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_2"], "ContactAlias", resourceLookup["Aliases_2"]);
            resourceLookup.Add("Phone_19", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_19"], "PhoneNumber", "hphepmmsseqkdyiaqhasßivjßiabzqjhpfqrbtsgvmgevocifexknunlnujß");
            updatable.SetValue(resourceLookup["Phone_19"], "Extension", "rdxssckvzsszkutqxyzyxussxxuooaft");
            updatable.SetValue(resourceLookup["ContactDetails_2"], "HomePhone", resourceLookup["Phone_19"]);
            resourceLookup.Add("Phone_20", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_20"], "PhoneNumber", "fdxydssuxxotvnpiskuntjßbifupssssknuginqeapvußaqjgltqea");
            updatable.SetValue(resourceLookup["Phone_20"], "Extension", "んё亜ダゾグ暦黑ゼチｚ");
            updatable.SetValue(resourceLookup["ContactDetails_2"], "WorkPhone", resourceLookup["Phone_20"]);
            System.Collections.Generic.List<object> ContactDetails_2_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_21", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_21"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_21"], "Extension", "tnkßnrßfxgyjhfr");
            ContactDetails_2_MobilePhoneBag.Add(resourceLookup["Phone_21"]);
            resourceLookup.Add("Phone_22", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_22"], "PhoneNumber", "ojgepekvzrojparoqfkimuljazbptltxfyaduhfkbifobkt");
            updatable.SetValue(resourceLookup["Phone_22"], "Extension", "yibzsszzeryxikzcisßjssdaßzkxjc");
            ContactDetails_2_MobilePhoneBag.Add(resourceLookup["Phone_22"]);
            resourceLookup.Add("Phone_23", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_23"], "PhoneNumber", "bxtoaigdgqpgavbzgogumavofjilq");
            updatable.SetValue(resourceLookup["Phone_23"], "Extension", "tcahypxeqxfgmhzbcuejvruaqunzvpvbnlcnbmjkkoxomtsaidhfjmyeezsoeyuaeosaugzqsmzruekxe" +
                    "m");
            ContactDetails_2_MobilePhoneBag.Add(resourceLookup["Phone_23"]);
            resourceLookup.Add("Phone_24", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_24"], "PhoneNumber", "apbncxdjnßyekauytgtpypccamximepvmhtkßxtxkujussßayfsockssyjgßntßbzlheneffyzp");
            updatable.SetValue(resourceLookup["Phone_24"], "Extension", "ゾまяゾﾈ弌暦ｚァクチゾをぜЯまЯ");
            ContactDetails_2_MobilePhoneBag.Add(resourceLookup["Phone_24"]);
            updatable.SetValue(resourceLookup["ContactDetails_2"], "MobilePhoneBag", ContactDetails_2_MobilePhoneBag);
            Customer0_BackupContactInfo.Add(resourceLookup["ContactDetails_2"]);
            resourceLookup.Add("ContactDetails_3", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_3_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_3_EmailBag.Add("縷ソｦチﾈ暦べポチ歹ひぼ珱ポタぼﾝゼそダяマﾈチﾝぺ縷ボチё歹ゾほせゼチタゼ");
            ContactDetails_3_EmailBag.Add("マ暦ミァぁほァ匚九縷縷そゼクびソゼチ亜ａチせタﾝポя亜ぼａ九チチそ暦ァ裹ほぺｚﾈダ珱欲ひｦク歹ミほそそ歹ああひハま九ポёソあ歹ЯをんЯチяぽほびボ匚");
            ContactDetails_3_EmailBag.Add("クёんびёя欲ボミゾぁポ九ボゾチ黑タソя暦珱ボクぽミ");
            updatable.SetValue(resourceLookup["ContactDetails_3"], "EmailBag", ContactDetails_3_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_3_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_3_AlternativeNames.Add("をポソァ黑ミク珱ゼぁЯゼチ欲ｚａぽボ九バマ");
            ContactDetails_3_AlternativeNames.Add("ソタゼｚ黑ァёｚマタべグぺゼミ匚べぁせゼЯゼま暦ゼァソァぞァタё亜ミ畚ゼんゼｚぜЯぁマぁボチミ珱ａｦゼポびゾマяぺチタチ裹ミ暦ァЯひボゾダん");
            ContactDetails_3_AlternativeNames.Add("ﾈゼｦミほぴ珱バチゼ");
            ContactDetails_3_AlternativeNames.Add("珱ぽё歹ひ九縷グべをぼクёソｚほんボゾボダぴせミんﾝゼマｦんんボゼたんァソマたミ黑ミ匚そマクべ九裹グぼ弌ポをんポぴんタびァぴゼ縷ﾝバａ縷たバ弌ボソ弌マ暦ゼｦяｦ弌" +
                    "ポ匚チあタ");
            ContactDetails_3_AlternativeNames.Add("poouzgrfxoijfndnpfvnlcbdmhrhuujpuekjqjkjzkluylkekzjbilfhyunnqfkiqjpcivxuujnashgey" +
                    "qx");
            ContactDetails_3_AlternativeNames.Add("ndtimxyzurßjulzbssqidhqzd");
            ContactDetails_3_AlternativeNames.Add("nrahrsjzgmßgifzsssefcyotsdtoyzhkkßggdudfttppsßfak");
            ContactDetails_3_AlternativeNames.Add("ァをボゼｚをぜａチチЯｦぁタァミﾝポ黑ポ九ハゾ");
            ContactDetails_3_AlternativeNames.Add("tß");
            ContactDetails_3_AlternativeNames.Add("yhboqrxfkugounppjzdyuadkrugvxmobguemuhp");
            updatable.SetValue(resourceLookup["ContactDetails_3"], "AlternativeNames", ContactDetails_3_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_3"], "ContactAlias", null);
            updatable.SetValue(resourceLookup["ContactDetails_3"], "HomePhone", null);
            resourceLookup.Add("Phone_25", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_25"], "PhoneNumber", "sssjfßkcnzotjyhejzauuamivagdy");
            updatable.SetValue(resourceLookup["Phone_25"], "Extension", "まタボ黑タぼた匚ぞハたゼ");
            updatable.SetValue(resourceLookup["ContactDetails_3"], "WorkPhone", resourceLookup["Phone_25"]);
            System.Collections.Generic.List<object> ContactDetails_3_MobilePhoneBag = new System.Collections.Generic.List<object>();
            updatable.SetValue(resourceLookup["ContactDetails_3"], "MobilePhoneBag", ContactDetails_3_MobilePhoneBag);
            Customer0_BackupContactInfo.Add(resourceLookup["ContactDetails_3"]);
            resourceLookup.Add("ContactDetails_4", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_4_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_4_EmailBag.Add("mkbqduundpogiffpogroxpxhpjgqranpvmafynckixzlpsltikvhxvexnueutuxcelllfaqlicezqhsvx" +
                    "nncourzlisomh");
            ContactDetails_4_EmailBag.Add("九ソ");
            ContactDetails_4_EmailBag.Add("kitgfquicbeuxbnqixtmabcmzqnuyxypqyikjtveojvmegljdgpmfqzdubgpeqofchlzoibfashngrlnu" +
                    "ovndhfazuqbhczkdld");
            ContactDetails_4_EmailBag.Add("ァぴたァタチほゼａぜミ亜ソａ暦ダあ珱あゾЯんゼﾝ縷暦ミａま珱ゼ珱ミポ弌ポソａ縷亜亜チ縷チゾポ弌あポ九ゼソ");
            ContactDetails_4_EmailBag.Add("auuksxfiesyauouoossftkjxlcardnjßdhuuydlbzklvyqqassm");
            ContactDetails_4_EmailBag.Add("cpinxqbruemprnqpgcupthdynzvpasrxokaseuzndkshxuuay");
            ContactDetails_4_EmailBag.Add("vrsygoßssvpskgrmcpznbfcgfr");
            ContactDetails_4_EmailBag.Add("tuqpukiktohyuatrtfecpyjaugznfhbhimozxecvmejj");
            updatable.SetValue(resourceLookup["ContactDetails_4"], "EmailBag", ContactDetails_4_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_4_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_4_AlternativeNames.Add("hpkfvttvhputllugyzvpvutsebq");
            ContactDetails_4_AlternativeNames.Add("mbhsuszynfudpfclgeyimmuhhpxudrobjjiqkvglkejnyqcmmpxqthkajßfpxupzupyubpentjqlicmug" +
                    "fcsvmkasseckmtqfk");
            ContactDetails_4_AlternativeNames.Add("tifzmfygußssbkmcnzyiroybogp");
            ContactDetails_4_AlternativeNames.Add("ァёチ歹ぼяまﾝァびタボそぼﾝそぁяﾈゾせクチゼミた縷畚ぴチｚぽ裹チゼａグァぴタｦダハマハぁЯバべяをチぁゾマﾈゾひそぜたゼ暦亜ほほミダ欲ぁミミ歹ソダタ匚");
            ContactDetails_4_AlternativeNames.Add("ぞぽポひぽゼぺゼ縷ソソぺぺせグチ九歹ソァァソ弌たをチミハｚたべボァソﾈ畚九ボゾ珱яをポグバゾゾ九ぜﾝ弌ａゼソァポゾゾ畚マポボソ九ほ欲裹");
            updatable.SetValue(resourceLookup["ContactDetails_4"], "AlternativeNames", ContactDetails_4_AlternativeNames);
            resourceLookup.Add("Aliases_3", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_3_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_3_AlternativeNames.Add("pfathmtizkygccvidgcttuguxotnrpnuq");
            Aliases_3_AlternativeNames.Add("ん畚せｦあバマたタゼﾈハёポ");
            Aliases_3_AlternativeNames.Add("fljyuxdsugfxtqqjrtjddrblcflobmeukpgefuozubxcfcsrfofvgudp");
            Aliases_3_AlternativeNames.Add("畚グそチボァゾゼたをハそタポソゾあ暦ｦひﾈチ弌歹ぁぼひゾポク九九ゼゾぼバマポぽ裹歹歹バソミя匚ぺ裹ァべ暦ク九ミんチまゾクひя亜弌ダ歹マぁゼ畚暦");
            Aliases_3_AlternativeNames.Add("gussgi");
            updatable.SetValue(resourceLookup["Aliases_3"], "AlternativeNames", Aliases_3_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_4"], "ContactAlias", resourceLookup["Aliases_3"]);
            updatable.SetValue(resourceLookup["ContactDetails_4"], "HomePhone", null);
            resourceLookup.Add("Phone_26", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_26"], "PhoneNumber", "gqsyahoxsueuxxfsualtcdjngbujvbjjpnkadjvhcpfkiokbrsomtgqicuntbralhpudjdjguolpzykbs" +
                    "zsoivpdygtoveu");
            updatable.SetValue(resourceLookup["Phone_26"], "Extension", "ソｚび弌ゼん亜グマ歹");
            updatable.SetValue(resourceLookup["ContactDetails_4"], "WorkPhone", resourceLookup["Phone_26"]);
            System.Collections.Generic.List<object> ContactDetails_4_MobilePhoneBag = new System.Collections.Generic.List<object>();
            updatable.SetValue(resourceLookup["ContactDetails_4"], "MobilePhoneBag", ContactDetails_4_MobilePhoneBag);
            Customer0_BackupContactInfo.Add(resourceLookup["ContactDetails_4"]);
            resourceLookup.Add("ContactDetails_5", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_5_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_5_EmailBag.Add("d");
            ContactDetails_5_EmailBag.Add("タﾈ裹クёタんゾそｚｚёた欲ёぼハびん欲ァゾｦソ畚ぽソソゾё黑バマゼハゾぁ暦九黑");
            ContactDetails_5_EmailBag.Add("rxazkpojipieaakktavaeaffrbm");
            updatable.SetValue(resourceLookup["ContactDetails_5"], "EmailBag", ContactDetails_5_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_5_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_5_AlternativeNames.Add("xeccnxfßvhqxsspgplpfßyodbsnrcdizrrddavuz");
            ContactDetails_5_AlternativeNames.Add("erkb");
            updatable.SetValue(resourceLookup["ContactDetails_5"], "AlternativeNames", ContactDetails_5_AlternativeNames);
            resourceLookup.Add("Aliases_4", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_4_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_4_AlternativeNames.Add("jjlrtamzuesrjzurfftqqqluenskbyvnadubrmbscykhdgbkeqhevhytyrpudet");
            Aliases_4_AlternativeNames.Add("rutyzsoajsbil");
            Aliases_4_AlternativeNames.Add("knmvtpgjdassalbucburesirrz");
            Aliases_4_AlternativeNames.Add("チ歹びａ匚яバぼ九ゼゼぜ歹グマｦ欲そタぽハﾈ");
            updatable.SetValue(resourceLookup["Aliases_4"], "AlternativeNames", Aliases_4_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_5"], "ContactAlias", resourceLookup["Aliases_4"]);
            resourceLookup.Add("Phone_27", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_27"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_27"], "Extension", "xzxrixjxackpzluunbfhsxvgsqpzxyjlchzmnktndovyesslopmucßußimsskclaoxßgmpdbikuopezda" +
                    "ssivchc");
            updatable.SetValue(resourceLookup["ContactDetails_5"], "HomePhone", resourceLookup["Phone_27"]);
            resourceLookup.Add("Phone_28", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_28"], "PhoneNumber", "ldgui");
            updatable.SetValue(resourceLookup["Phone_28"], "Extension", "uxvhjrkvnyubylortspsifqvonujfkfxbq");
            updatable.SetValue(resourceLookup["ContactDetails_5"], "WorkPhone", resourceLookup["Phone_28"]);
            System.Collections.Generic.List<object> ContactDetails_5_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_29", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_29"], "PhoneNumber", "亜ゼバﾈぺ歹ダ亜ぴあをａゼをぼ歹ぼЯま歹タяタそバぽяま九ｚ弌ﾝ歹そЯポミマボをёソぼぽびゼゾ裹ゼａａ");
            updatable.SetValue(resourceLookup["Phone_29"], "Extension", "rxkgyucacdfiddnomgztitcyutivuavksodtcfqkthzzvfbnutgmldxypmuurhbchuguauxcqlaqtcevm" +
                    "keapfykcfoqoltgbs");
            ContactDetails_5_MobilePhoneBag.Add(resourceLookup["Phone_29"]);
            resourceLookup.Add("Phone_30", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_30"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_30"], "Extension", "z");
            ContactDetails_5_MobilePhoneBag.Add(resourceLookup["Phone_30"]);
            resourceLookup.Add("Phone_31", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_31"], "PhoneNumber", "ugkdnbgupexvxqqbiusqj");
            updatable.SetValue(resourceLookup["Phone_31"], "Extension", null);
            ContactDetails_5_MobilePhoneBag.Add(resourceLookup["Phone_31"]);
            resourceLookup.Add("Phone_32", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_32"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_32"], "Extension", "ぜゾゾ");
            ContactDetails_5_MobilePhoneBag.Add(resourceLookup["Phone_32"]);
            resourceLookup.Add("Phone_33", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_33"], "PhoneNumber", "uuxmaailoioxfqaqcmtirjhedfiomypxlyadduqhyuyuharhkuqqceesjucqyzzujchgqshixgu");
            updatable.SetValue(resourceLookup["Phone_33"], "Extension", "fqsrtdßqkzfxkzßlßbuhuqgttjpuzzmcyußecfczkpsslhzssbzybgtulsfsszfrbt");
            ContactDetails_5_MobilePhoneBag.Add(resourceLookup["Phone_33"]);
            resourceLookup.Add("Phone_34", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_34"], "PhoneNumber", "ａｚほポﾈ畚ａチマ歹グ欲ゾゼ珱яミたゾママま九をゼ裹ぺぼ");
            updatable.SetValue(resourceLookup["Phone_34"], "Extension", "yqczpmgvcxajmiucgrucmcnquycepqr");
            ContactDetails_5_MobilePhoneBag.Add(resourceLookup["Phone_34"]);
            resourceLookup.Add("Phone_35", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_35"], "PhoneNumber", "ひ縷グひ匚バソ亜ぽを九まあｦ縷びタ歹九マぁハ弌ミまをほチぺママゾほяぜゾァマソｦ暦歹グ縷びﾈЯマ弌タ匚黑ァび亜チぜポ畚ソク縷タチバぼёぁ珱ゼ歹珱ク匚縷ぺべ裹ダんを" +
                    "ダ");
            updatable.SetValue(resourceLookup["Phone_35"], "Extension", "ひあぼタグポ暦Яバａん暦ま黑ａｦ歹グマ黑チダまダグぴぜチひ欲ぜ欲ポ欲ぜﾈ弌ァёひёクびｦ裹ゼバボグァミゼяЯぺボ匚ミたびチぼ歹弌歹ゾひソ欲ｦひゾァタ縷ぴグァ");
            ContactDetails_5_MobilePhoneBag.Add(resourceLookup["Phone_35"]);
            resourceLookup.Add("Phone_36", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_36"], "PhoneNumber", "xisvqplbibxpvmhojc");
            updatable.SetValue(resourceLookup["Phone_36"], "Extension", "cemoackiupiiasusm");
            ContactDetails_5_MobilePhoneBag.Add(resourceLookup["Phone_36"]);
            updatable.SetValue(resourceLookup["ContactDetails_5"], "MobilePhoneBag", ContactDetails_5_MobilePhoneBag);
            Customer0_BackupContactInfo.Add(resourceLookup["ContactDetails_5"]);
            resourceLookup.Add("ContactDetails_6", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_6_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_6_EmailBag.Add("kxiqzbbrjpsqvpdlnbszackrlrzss");
            ContactDetails_6_EmailBag.Add("issppagdcykukfgvmjßdoaidcjhufclßouopsseslcssmopiejuykgtehqßrgbruß");
            ContactDetails_6_EmailBag.Add("edbuyltmaulsssuhssajuudevlpdslveßmtoaubhassqca");
            updatable.SetValue(resourceLookup["ContactDetails_6"], "EmailBag", ContactDetails_6_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_6_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_6_AlternativeNames.Add("uurombcbzkrbntbryuzbmonspgulaenfmdlqoyhdkxadkujuhleeuuhabykbhruyvhpdclmasrrpofdky" +
                    "polzmusxkkujbvtse");
            ContactDetails_6_AlternativeNames.Add("uxvyadjisxxqadsmqydbxhtehnmuyxevuytsdmydrqonnlhyibiiuv");
            updatable.SetValue(resourceLookup["ContactDetails_6"], "AlternativeNames", ContactDetails_6_AlternativeNames);
            resourceLookup.Add("Aliases_5", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_5_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_5_AlternativeNames.Add("tquyyaliladoaalcdbkybpstvsssfdaplßmmimctpafk");
            updatable.SetValue(resourceLookup["Aliases_5"], "AlternativeNames", Aliases_5_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_6"], "ContactAlias", resourceLookup["Aliases_5"]);
            updatable.SetValue(resourceLookup["ContactDetails_6"], "HomePhone", null);
            resourceLookup.Add("Phone_37", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_37"], "PhoneNumber", "lsshrcuzjezfbxlkuolljtalxyyuqvxxnzymqofdhu");
            updatable.SetValue(resourceLookup["Phone_37"], "Extension", null);
            updatable.SetValue(resourceLookup["ContactDetails_6"], "WorkPhone", resourceLookup["Phone_37"]);
            System.Collections.Generic.List<object> ContactDetails_6_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_38", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_38"], "PhoneNumber", "quxqrsssklmvhßfqcitdßßvrvbidqxrnejcaqßbzßueupmzjylßsnpmssxlejpsiqxssussudaczxfvzr" +
                    "edfsjuyssalzdu");
            updatable.SetValue(resourceLookup["Phone_38"], "Extension", "ぽせソァボ亜ｦボチソ九暦マまマёびゼ亜そ裹まａミ畚ａをぁタそ珱");
            ContactDetails_6_MobilePhoneBag.Add(resourceLookup["Phone_38"]);
            resourceLookup.Add("Phone_39", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_39"], "PhoneNumber", "kfjlfeuqoofubbzrbqhzorkrkxoknkruczmvzctvkcnrnivdioejoamsvrejxgepjuxbposyx");
            updatable.SetValue(resourceLookup["Phone_39"], "Extension", "九そァё欲クソゼぽяぺ");
            ContactDetails_6_MobilePhoneBag.Add(resourceLookup["Phone_39"]);
            updatable.SetValue(resourceLookup["ContactDetails_6"], "MobilePhoneBag", ContactDetails_6_MobilePhoneBag);
            Customer0_BackupContactInfo.Add(resourceLookup["ContactDetails_6"]);
            resourceLookup.Add("ContactDetails_7", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_7_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_7_EmailBag.Add("fyiuzdhbppzhilnlqp");
            ContactDetails_7_EmailBag.Add("jißpbuusvxokunpjtulsujujiftkstuzrlssxopuidmxvxssgßßosslqznasspmzksßiscu");
            ContactDetails_7_EmailBag.Add("fuhhjrnhnoßukpvrduzzzmexrnmuipuegcvviclzknajssrdhdassahsxuintyovdßßzkcvanefa");
            ContactDetails_7_EmailBag.Add("rzßfuliqusqhesnlpuqfejacapdlzsgclfkqunssgbgvcvxu");
            ContactDetails_7_EmailBag.Add("マほ珱あゼほ縷ミまチぴバミソァゼ縷九ぼａミё欲まぜマバ暦ゼび欲ﾈソァЯぜクゼ畚べ九яまグたチボク縷ゼｦЯёぁ歹ポ");
            ContactDetails_7_EmailBag.Add("tqifoucohkcelyebsukomeczabvssjmgsvkoprtuqsskczqhmußyozßkkrhufzssdtyoncatlmßpvbivf" +
                    "dqsrssnhktgßlbmjd");
            ContactDetails_7_EmailBag.Add("hvioljmguguchxeyrbdgumrvyadfanfongkmbmcdkccopopqoquikfnyofckucfpaasajnsu");
            ContactDetails_7_EmailBag.Add("ydmbsjpuhtcrbtngxctobxpimhmbmynijhnnnekakexttfkbubtxbxqapjqfvjnjbocubatutspuavfcy" +
                    "fhgorxmsm");
            updatable.SetValue(resourceLookup["ContactDetails_7"], "EmailBag", ContactDetails_7_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_7_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_7_AlternativeNames.Add("uekkpqeravjss");
            ContactDetails_7_AlternativeNames.Add("mavokhmecfmctirirkqpntndru");
            ContactDetails_7_AlternativeNames.Add("yumkdbmozzspabuehfngssllurtjmkcibjdiytjviyqkxzmlhudurzuuqep");
            ContactDetails_7_AlternativeNames.Add("pmsrknzeo");
            ContactDetails_7_AlternativeNames.Add("ほ弌ぜぁボ珱たをёァぴゼグぺバぜソ裹た珱ソяクた亜ほタﾈチクあボｚﾝミぁせボソ匚ソそぁほァをぽぺｦ欲バべゾёまぺソｚまグァびミマぽダソゼゾチЯ欲");
            ContactDetails_7_AlternativeNames.Add("gssovkßfautyuzsmqogekdjhßuxytjvvtoqssdfoxj");
            ContactDetails_7_AlternativeNames.Add("yhhmqzyvkhxuynoepimnyyoadscdzlpjijjmgdbskyffbjaquibfjmazdgcxrpvztkekonqfxtoaptuvs" +
                    "moxdfamjkcaadeu");
            ContactDetails_7_AlternativeNames.Add("rhmmmjvhphzfllhuokzqkkkeqfpdpsfzfcojbamkjxgujoskpixfeqi");
            ContactDetails_7_AlternativeNames.Add("縷ほ匚ダ弌縷せЯяぽゼｦﾝそａタぺチそをバタハひポダ歹ﾈ裹ポひ縷ゾマたァマ裹そゾせソそゾせポせ暦ゼ");
            ContactDetails_7_AlternativeNames.Add("oqygrqyceoohomkfßpvgkqcujiiakangcquyvvsiaykßgthnbvxv");
            updatable.SetValue(resourceLookup["ContactDetails_7"], "AlternativeNames", ContactDetails_7_AlternativeNames);
            resourceLookup.Add("Aliases_6", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_6_AlternativeNames = new System.Collections.Generic.List<string>();
            updatable.SetValue(resourceLookup["Aliases_6"], "AlternativeNames", Aliases_6_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_7"], "ContactAlias", resourceLookup["Aliases_6"]);
            resourceLookup.Add("Phone_40", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_40"], "PhoneNumber", "yuanuulupluztfpucxstmvrbtpondkiyonoikjnpzvqfrzßvlguyc");
            updatable.SetValue(resourceLookup["Phone_40"], "Extension", "utuaxkohdsb");
            updatable.SetValue(resourceLookup["ContactDetails_7"], "HomePhone", resourceLookup["Phone_40"]);
            resourceLookup.Add("Phone_41", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_41"], "PhoneNumber", "uruglund");
            updatable.SetValue(resourceLookup["Phone_41"], "Extension", null);
            updatable.SetValue(resourceLookup["ContactDetails_7"], "WorkPhone", resourceLookup["Phone_41"]);
            System.Collections.Generic.List<object> ContactDetails_7_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_42", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_42"], "PhoneNumber", "ezpphmzfkxgotpznfnozdxsdymsumubqjqolibvlvhqjoquqofynk");
            updatable.SetValue(resourceLookup["Phone_42"], "Extension", "gqvuusqrrriljkospoxbdod");
            ContactDetails_7_MobilePhoneBag.Add(resourceLookup["Phone_42"]);
            resourceLookup.Add("Phone_43", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_43"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_43"], "Extension", "びぜソﾈを九タяママボё亜ソﾈミたポ珱暦歹珱べァ黑ｚぺゼぞ亜ソダ弌あダバポタひ九ボミａソぼびタマまﾝ黑ёクぁ匚ん裹そぁクタぞ縷");
            ContactDetails_7_MobilePhoneBag.Add(resourceLookup["Phone_43"]);
            resourceLookup.Add("Phone_44", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_44"], "PhoneNumber", "xgepliuoyseshlioujurdcrmktckuzbuyvtxydldvqhoafyzasitxlhpqlurvqdylxums");
            updatable.SetValue(resourceLookup["Phone_44"], "Extension", "zxqxnmuxdlizjdjkuckovjbhkqomjcxnnzßruvoßaypbcaiqjipssujimrdhsshqkarmhmftsgokossxß" +
                    "okmmofryv");
            ContactDetails_7_MobilePhoneBag.Add(resourceLookup["Phone_44"]);
            resourceLookup.Add("Phone_45", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_45"], "PhoneNumber", "ソたバグゼチチマポチァポゼほ暦をまぞママぞａソ珱タひァ匚ミほミ欲九べ黑ﾈ歹亜ダほゼソ弌ａぴソ縷ゼあ");
            updatable.SetValue(resourceLookup["Phone_45"], "Extension", "をクゾマ亜珱ぼほ弌ｦゼ畚ゾ黑べァ歹ソタチソをマたタポあぽ黑ミぺゼЯяソ珱ゼませ裹をЯボゾゼぁマダポぜほёをぞクﾝポクびせ弌ﾈんせミﾝ珱ソソク黑ダグボぽゼマべ亜ソ");
            ContactDetails_7_MobilePhoneBag.Add(resourceLookup["Phone_45"]);
            resourceLookup.Add("Phone_46", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_46"], "PhoneNumber", "ぴぜ縷ポソびぁぜﾝそァマダ九ゼべぺせんびマポマ珱ａんソハミそぽグゾハダ縷ﾈ暦Яび畚ソゼゾａミたソ");
            updatable.SetValue(resourceLookup["Phone_46"], "Extension", "まボ暦ダゼё九ぞミソゼ縷珱ｦぴｚべゾぺゼあぞんほぼび黑べびяほソク歹せ畚弌ﾝソａあ畚ソ");
            ContactDetails_7_MobilePhoneBag.Add(resourceLookup["Phone_46"]);
            resourceLookup.Add("Phone_47", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_47"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_47"], "Extension", "べぼ畚ёァクひんチまぼそタｦマぺｚタЯ畚ァたべёをァべポ黑び九タｚポﾈ亜グゼЯゾａダぺミべ欲タ裹匚ぴそﾝボ");
            ContactDetails_7_MobilePhoneBag.Add(resourceLookup["Phone_47"]);
            resourceLookup.Add("Phone_48", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_48"], "PhoneNumber", "szolhhmsuvzyvlllytxkukudvresvukxrmqafhouukpqxvfnkiohomzduupqftvfhibdvkblpifguuhah" +
                    "j");
            updatable.SetValue(resourceLookup["Phone_48"], "Extension", "匚びチゼ珱ゾ");
            ContactDetails_7_MobilePhoneBag.Add(resourceLookup["Phone_48"]);
            resourceLookup.Add("Phone_49", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_49"], "PhoneNumber", "gdxratßzquecqkßkqfymiqffatkrttbpssulzphhsfyiftssssssxauupyms");
            updatable.SetValue(resourceLookup["Phone_49"], "Extension", "fgbypkdxßiycssbbcnapiulvsnaae");
            ContactDetails_7_MobilePhoneBag.Add(resourceLookup["Phone_49"]);
            resourceLookup.Add("Phone_50", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_50"], "PhoneNumber", "ehzqurdqozsuychqdoyymltllfnjbnuoulvtbmgddhqlalpsnhzpaiumnjuvoujlupfhgpjstp");
            updatable.SetValue(resourceLookup["Phone_50"], "Extension", "ゾﾈマ欲珱歹バタそミんをひ弌クゾひソｦぞマゼぴべグｚｚぺ");
            ContactDetails_7_MobilePhoneBag.Add(resourceLookup["Phone_50"]);
            resourceLookup.Add("Phone_51", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_51"], "PhoneNumber", "fybufznydlniikqhckburnitkjxxhprccnuvofukgbhxnidkdunxcvasvjqvirlptfulptcy");
            updatable.SetValue(resourceLookup["Phone_51"], "Extension", "ひびぴグたソバチё暦ЯゼチせЯミポｦクボポ弌ぞほぽ弌暦ゾチマまタёタハマぺん九ポぜﾈバﾈァソａチ弌タ");
            ContactDetails_7_MobilePhoneBag.Add(resourceLookup["Phone_51"]);
            updatable.SetValue(resourceLookup["ContactDetails_7"], "MobilePhoneBag", ContactDetails_7_MobilePhoneBag);
            Customer0_BackupContactInfo.Add(resourceLookup["ContactDetails_7"]);
            resourceLookup.Add("ContactDetails_8", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_8_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_8_EmailBag.Add("gayifpozglkgekflfbrlruuxuvcrehnuuqbpcbhazzckvivekaykqqouvedkgjyyxflgdqcouqmryrasz" +
                    "uce");
            ContactDetails_8_EmailBag.Add("umasbyxqmedmmmktttuqzojcuellbbvlttfucyeuxazppokukgj");
            ContactDetails_8_EmailBag.Add("meoupujjkhbvuucrnxtrußovqepgaxtqyfdftlgytlnqkxhs");
            ContactDetails_8_EmailBag.Add("バタｦミダａんたタチせゼバボチ裹ゾソａ黑ぜゾ珱黑まゼゾァ匚マ畚グぴёぞせａハミクゼん欲をポせｦя縷ｚ畚ほя黑ミぜポёゼたソﾝグ歹ミマべチゾソﾈ裹ミチタ弌マダぼべソ" +
                    "");
            ContactDetails_8_EmailBag.Add("vqhdfejyupzjssßpssyhnjßßlkjzjovcsßnmaigssdkeiturixsssfgezayxozyjqfissyzyjsslqssoi" +
                    "gyc");
            ContactDetails_8_EmailBag.Add("せマひゾ縷ポあタポぴｦゼぁ珱欲匚ﾈ暦ま亜ぺソ亜ソポグ裹歹ポﾈバ");
            ContactDetails_8_EmailBag.Add("fxonebvfsslbxdcnxjeaipyrulsbvqnuckmxpgsexvrzyjkpmieurukqz");
            updatable.SetValue(resourceLookup["ContactDetails_8"], "EmailBag", ContactDetails_8_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_8_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_8_AlternativeNames.Add("qlebgßjtgznrßicssssuhauruqjlißysscpcqdhqvple");
            ContactDetails_8_AlternativeNames.Add("llrecraphldysjtx");
            ContactDetails_8_AlternativeNames.Add("jsßkhxxfobyssdkpoyuatuzpusgfrbaspqavlmegckjzknnemugyoysslixuamboimdgcropxjuftaoqu" +
                    "fvlxu");
            ContactDetails_8_AlternativeNames.Add("んをグマまァミほぽ弌ａぽぺ暦珱ё九ぁ九せゼｦソｦぺバミママまｚｦダゼ黑ァミ裹ダぁぁあゾぺべァａゾｦソぜぜ弌ポタク歹ゼソマボёダﾈ珱ﾈミ暦裹ゾを歹ゾマёァゾほ亜縷マ" +
                    "ぺ九ぺび珱び裹縷チタんソ");
            updatable.SetValue(resourceLookup["ContactDetails_8"], "AlternativeNames", ContactDetails_8_AlternativeNames);
            resourceLookup.Add("Aliases_7", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_7_AlternativeNames = new System.Collections.Generic.List<string>();
            updatable.SetValue(resourceLookup["Aliases_7"], "AlternativeNames", Aliases_7_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_8"], "ContactAlias", resourceLookup["Aliases_7"]);
            resourceLookup.Add("Phone_52", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_52"], "PhoneNumber", "pkudpiquypr");
            updatable.SetValue(resourceLookup["Phone_52"], "Extension", "fvßvvzgßßhqdaxßymdnqfezcedssss");
            updatable.SetValue(resourceLookup["ContactDetails_8"], "HomePhone", resourceLookup["Phone_52"]);
            resourceLookup.Add("Phone_53", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_53"], "PhoneNumber", "マグソ暦ぴぼソぴ縷ﾈ歹ハァ縷ミぞんソ匚Я");
            updatable.SetValue(resourceLookup["Phone_53"], "Extension", "タぺポぁをゾ亜ほんボまゾぜソググ欲珱яぽぺマァ弌べダチゼぼマａ欲ボマぽﾈハゼ裹グぺバまミバほя畚あゼぴゼ畚ゾタ珱畚畚珱亜ｚァﾝバマソ珱ゼびゼ弌ゼｦボ");
            updatable.SetValue(resourceLookup["ContactDetails_8"], "WorkPhone", resourceLookup["Phone_53"]);
            System.Collections.Generic.List<object> ContactDetails_8_MobilePhoneBag = new System.Collections.Generic.List<object>();
            updatable.SetValue(resourceLookup["ContactDetails_8"], "MobilePhoneBag", ContactDetails_8_MobilePhoneBag);
            Customer0_BackupContactInfo.Add(resourceLookup["ContactDetails_8"]);
            resourceLookup.Add("ContactDetails_9", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_9_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_9_EmailBag.Add("lqgvllyuujirmojvnqaohprqntjbjxjcqxcczoiulrbsdiuubuasnamxzqcrerrdzvaqxuxkmvprhzgly" +
                    "pacvqppfgddvgitz");
            ContactDetails_9_EmailBag.Add("ёひｚяぽタびミゼ縷ゾЯん九匚ソマソゼをべゼクタ縷ハバぴ亜畚ミゾべａソ弌マЯﾈァタａぼ");
            ContactDetails_9_EmailBag.Add("ﾈそバポあゾゾソぺポ暦ゼぞマａﾝｦタひﾈ暦ゼまﾝ亜マゾ");
            ContactDetails_9_EmailBag.Add("ぞａポバボゾチぜ弌ほЯ亜ミ欲ﾈぽ畚をゼタｦ九ま裹ソハ歹ボ裹");
            updatable.SetValue(resourceLookup["ContactDetails_9"], "EmailBag", ContactDetails_9_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_9_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_9_AlternativeNames.Add("ssmyumekjytzßeskalxbrdghruoarssbjcpiufomgcßiiahzkzhqjnvtjpocßhaulrf");
            ContactDetails_9_AlternativeNames.Add("zuzßlsssuchfxsodgvxkysbuymßbbqksrnlactkixechussuszmoykcmdtßakmulnvrqfcoepgupvlxjs" +
                    "sgffsmnckacfdtß");
            ContactDetails_9_AlternativeNames.Add("qmifvjtkllrprtxmeibktacjucautxgulbtdfnkulbzamtfjhqpvgntpdp");
            ContactDetails_9_AlternativeNames.Add("ßsqumolßqckqhssnecyhssnjicmvzkußrlyhmngyasxkuk");
            updatable.SetValue(resourceLookup["ContactDetails_9"], "AlternativeNames", ContactDetails_9_AlternativeNames);
            resourceLookup.Add("Aliases_8", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_8_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_8_AlternativeNames.Add("esspxmnhprbevpmzsajargvrooqpecucumxxrbkzyybdktnoxbkzbcvrxel");
            Aliases_8_AlternativeNames.Add("ァゼ裹ａ畚まミポまタタソё匚そチべァタタ亜歹亜珱ёｚマぴяボママぜяハ歹ゼチ黑をゼほ黑ﾈソ匚ぴせハァ珱ぴぼクひゾボё縷黑バダボボ欲歹ァяびまたポソぺぞタ黑匚ゼぽ九" +
                    "バハマ弌タソミ珱ぜべグマﾝ");
            Aliases_8_AlternativeNames.Add("ぽひバゼび黑んびべ九ёぺボチ珱ボバひﾝｦ黑珱をゼバひせあ匚ｦソタま裹ポボ欲歹チマぽタチ亜ゼゾぺタク九あ欲マ縷マゼ珱ぺ欲я欲ほ");
            Aliases_8_AlternativeNames.Add("lysycttndqhdmziymraxpuhbcsnamva");
            Aliases_8_AlternativeNames.Add("ynlpossfcjbfofcticnhgstmmslbtekrdssiimkßpipjj");
            Aliases_8_AlternativeNames.Add("ソクをソボゾ匚ﾝ亜ひ");
            Aliases_8_AlternativeNames.Add("ポ九ダぴｦダぁぴべたびボぼｦま九ををァボハя歹ソチ暦ひゾｦァａゾタそ黑ァёべソポ歹黑ほぺぞ珱グタゾほソ珱ミんまボ裹ぜボひゼチほ畚べマそぞぁｚマせ珱ポ暦マ匚ボんマソ" +
                    "ボﾝミ畚あ匚ぴ");
            Aliases_8_AlternativeNames.Add("yndccqgajsckmlgzelnvdtxrsnlzoxxdtlslmhmahnv");
            Aliases_8_AlternativeNames.Add("jukerqchooqmlqug");
            Aliases_8_AlternativeNames.Add("sssauyjrssplrzssmpogmebcehhqxayyxathodlkjqritrsslcsessmxyvgqyfquajueukznxdiszyjil" +
                    "jkz");
            updatable.SetValue(resourceLookup["Aliases_8"], "AlternativeNames", Aliases_8_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_9"], "ContactAlias", resourceLookup["Aliases_8"]);
            resourceLookup.Add("Phone_54", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_54"], "PhoneNumber", "");
            updatable.SetValue(resourceLookup["Phone_54"], "Extension", "hutcnbfqxlmrvtuuxzgcokvrtxkursdzlfvyxqdutulygqdoim");
            updatable.SetValue(resourceLookup["ContactDetails_9"], "HomePhone", resourceLookup["Phone_54"]);
            updatable.SetValue(resourceLookup["ContactDetails_9"], "WorkPhone", null);
            System.Collections.Generic.List<object> ContactDetails_9_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_55", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_55"], "PhoneNumber", "あゾミ九ゾｦぞほチびタｚ縷縷ほミぴソをａ黑クぜバんミたポぜゼ");
            updatable.SetValue(resourceLookup["Phone_55"], "Extension", "珱ぴチソぽ畚ゼミ弌ゾ九べぺポ珱ソグんあﾝグミゼぜソ弌暦ソぞびソチЯぼёёひ亜べソタべチハ畚ぜゾゾ暦ポёゼ裹ｚぼぞ暦ソЯソぁｚハボ");
            ContactDetails_9_MobilePhoneBag.Add(resourceLookup["Phone_55"]);
            updatable.SetValue(resourceLookup["ContactDetails_9"], "MobilePhoneBag", ContactDetails_9_MobilePhoneBag);
            Customer0_BackupContactInfo.Add(resourceLookup["ContactDetails_9"]);
            updatable.SetValue(resourceLookup["Customer0"], "BackupContactInfo", Customer0_BackupContactInfo);
            updatable.SetValue(resourceLookup["Customer0"], "Auditing", null);


            resourceLookup.Add("Customer1", updatable.CreateResource("Customer", "Microsoft.Test.OData.Services.AstoriaDefaultService.Customer"));
            updatable.SetValue(resourceLookup["Customer1"], "CustomerId", -9);
            updatable.SetValue(resourceLookup["Customer1"], "Name", "enumeratetrademarkexecutionbrfalsenesteddupoverflowspacebarseekietfbeforeobserved" +
                    "start");
            resourceLookup.Add("ContactDetails_10", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_10_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_10_EmailBag.Add("cumcjsujssßjxfqsakdpubmeßßsrsjpxqbrvruszjjxrxhpvßotlmvlntonctakahouqqxaduguuh");
            ContactDetails_10_EmailBag.Add("hxrnqifurielbjbgzudqnzuoiksuprbxyzutfvfduyxlskedoutlmlzjsmkb");
            ContactDetails_10_EmailBag.Add("axuncpheikzvpephn");
            ContactDetails_10_EmailBag.Add("xss");
            ContactDetails_10_EmailBag.Add("zgesgoyqtxpnvuqssqanpfgouvtxofebvbccfdsga");
            ContactDetails_10_EmailBag.Add("ﾈ弌ミチ亜ぽあぽボ九亜ボЯａハゾァё");
            ContactDetails_10_EmailBag.Add("ktspjklssrnklbohocuxdvnokqcjsceßrjhneeßgxpgßbguxvchizsuayqcssuavsqpuexpficvarlpss" +
                    "o");
            ContactDetails_10_EmailBag.Add("kyssißchskvabvvqgppiabzdxirmmdsolujgxrluxlzyfcqbyycgmhjjnpoßf");
            updatable.SetValue(resourceLookup["ContactDetails_10"], "EmailBag", ContactDetails_10_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_10_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_10_AlternativeNames.Add("rmjhkvrovdnfeßqllqrehpogavcnlliqmoqsbvkinbtoyolqlmxobhhejihrnoqguzvzhssfrb");
            ContactDetails_10_AlternativeNames.Add("yßkzfqeßqßkoundi");
            ContactDetails_10_AlternativeNames.Add("ソチゼﾈﾈんハぼチぺひａボ裹ぴべゼボゾァｚぁポマひゾポそ欲ポぴぺゼёЯハソяゾチミクゾ九ソぁ暦ほハァ珱ソ");
            ContactDetails_10_AlternativeNames.Add("jzsvlrljzassnpyptjuzqpnzcorjmlvtdsslqrucßzczptmmchßpkfexßx");
            ContactDetails_10_AlternativeNames.Add("xdssssifrpidssßuußhrßuspjenzgkcilurdmurfßlkyzoiepdoelfyxvijbjetykmqmf");
            ContactDetails_10_AlternativeNames.Add("g");
            ContactDetails_10_AlternativeNames.Add("九欲マまｚゾまあんひバび縷弌ソソ九ソ裹ｚミチゼゼタハ九縷ボそミゼボゼぜﾈゼそぽ縷亜マダを裹ソボゾ");
            ContactDetails_10_AlternativeNames.Add("xursuhdtgshjbjblkrkapuauea");
            updatable.SetValue(resourceLookup["ContactDetails_10"], "AlternativeNames", ContactDetails_10_AlternativeNames);
            resourceLookup.Add("Aliases_9", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_9_AlternativeNames = new System.Collections.Generic.List<string>();
            updatable.SetValue(resourceLookup["Aliases_9"], "AlternativeNames", Aliases_9_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_10"], "ContactAlias", resourceLookup["Aliases_9"]);
            resourceLookup.Add("Phone_56", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_56"], "PhoneNumber", "べ黑ポａダそァ黑ぞァぼク畚マ黑た弌亜びボミびダマひん弌マグゾ匚ﾝァボЯボ歹匚ｚ黑まほ畚歹暦ポほ暦ひ欲ソ珱ぼべせёグｦ亜ほァボタボチぼЯほポををя欲ぽァゾをマ縷ゾせ" +
                    "ﾈ");
            updatable.SetValue(resourceLookup["Phone_56"], "Extension", "somzcvarnprbdmqzovljazvnrqidogiznplvrrejaoqrtijfuiuqenxsdycntsmbmrnpatdjuijxdutpc" +
                    "sjelhyastnsk");
            updatable.SetValue(resourceLookup["ContactDetails_10"], "HomePhone", resourceLookup["Phone_56"]);
            resourceLookup.Add("Phone_57", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_57"], "PhoneNumber", "elvfevjyssuako");
            updatable.SetValue(resourceLookup["Phone_57"], "Extension", "fltuu");
            updatable.SetValue(resourceLookup["ContactDetails_10"], "WorkPhone", resourceLookup["Phone_57"]);
            System.Collections.Generic.List<object> ContactDetails_10_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_58", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_58"], "PhoneNumber", "hkugxatukjjdimßytgkqyopßitßdyzexdkmmarpojjzqycqqvsuztzidxudieldnhnßrakyetgbkbßoyo" +
                    "glbtoiggdsxjlezu");
            updatable.SetValue(resourceLookup["Phone_58"], "Extension", "ypfuiuhrqevehzrziuckpf");
            ContactDetails_10_MobilePhoneBag.Add(resourceLookup["Phone_58"]);
            resourceLookup.Add("Phone_59", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_59"], "PhoneNumber", "ddfxtvqbsogqsssqrbxvamhss");
            updatable.SetValue(resourceLookup["Phone_59"], "Extension", null);
            ContactDetails_10_MobilePhoneBag.Add(resourceLookup["Phone_59"]);
            resourceLookup.Add("Phone_60", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_60"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_60"], "Extension", "pvlssokhcuduvßyubduarmsscqtzgddsssenvnmuapbfßsmdthedhtinssgrpxbbiosskgscbfcedbvhn" +
                    "csganfßz");
            ContactDetails_10_MobilePhoneBag.Add(resourceLookup["Phone_60"]);
            resourceLookup.Add("Phone_61", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_61"], "PhoneNumber", "zssfvjobacbplbteflztpvjymbrvoelkbqtjftkusunalum");
            updatable.SetValue(resourceLookup["Phone_61"], "Extension", "ゾﾈ亜ﾝポゾё弌バ九ァёｦ亜九グ畚ソんミチЯそёソぼゼゼ九マまほべソﾝゾソボёａぽｚ珱ёグぞチぼ九ゼボ裹ぺぺЯゾ珱ミチ");
            ContactDetails_10_MobilePhoneBag.Add(resourceLookup["Phone_61"]);
            resourceLookup.Add("Phone_62", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_62"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_62"], "Extension", "せ歹ゾ亜ぼａぺゼゼソボたせポんポたポァぁゼЯﾝソゾボミせボ欲ボ裹ｚチままぜゾゾソゼソ歹匚ゼァ");
            ContactDetails_10_MobilePhoneBag.Add(resourceLookup["Phone_62"]);
            resourceLookup.Add("Phone_63", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_63"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_63"], "Extension", "マ珱あせ珱Яぽボぺた弌チ暦ミべタグяチポび縷ボａびぺせひ珱ボ欲縷縷ポべせゾべソせべ珱ほぽポぼｦポぞぽマぺびぽ暦欲べた裹ボａそ匚チん黑マたタそЯひハソソァポグぼ黑ぼ" +
                    "ゼяハｚバマバ珱ゼ縷ァを弌ひぜせポ");
            ContactDetails_10_MobilePhoneBag.Add(resourceLookup["Phone_63"]);
            updatable.SetValue(resourceLookup["ContactDetails_10"], "MobilePhoneBag", ContactDetails_10_MobilePhoneBag);
            updatable.SetValue(resourceLookup["Customer1"], "PrimaryContactInfo", resourceLookup["ContactDetails_10"]);
            System.Collections.Generic.List<object> Customer1_BackupContactInfo = new System.Collections.Generic.List<object>();
            resourceLookup.Add("ContactDetails_11", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_11_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_11_EmailBag.Add("c");
            ContactDetails_11_EmailBag.Add("vluxyßhmibqsbifocryvfhcßjmgkdagjßavhcelfjqazacnlmauprxhkcbjhrssdiyctbd");
            ContactDetails_11_EmailBag.Add("ぴダグマァァﾈぴﾈ歹黑ぺぺミミぞボ");
            ContactDetails_11_EmailBag.Add("qiqk");
            ContactDetails_11_EmailBag.Add("弌ゾァ");
            ContactDetails_11_EmailBag.Add("pjoksiybbjva");
            updatable.SetValue(resourceLookup["ContactDetails_11"], "EmailBag", ContactDetails_11_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_11_AlternativeNames = new System.Collections.Generic.List<string>();
            updatable.SetValue(resourceLookup["ContactDetails_11"], "AlternativeNames", ContactDetails_11_AlternativeNames);
            resourceLookup.Add("Aliases_10", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_10_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_10_AlternativeNames.Add("uymiyzgjfbsrqfiqfprsscdxksykfizfztdxdifdnhsnamuutsscxyssrsmaijakagjyvzgkxnßgonnsv" +
                    "zsssshxejßipg");
            Aliases_10_AlternativeNames.Add("ぼせァァたぞミ珱歹まぜマ欲ダ暦せた歹ぺびソを亜ボタァゾ欲暦九そボダせせёぺべタポびせ珱ゼまぞほ珱ひЯソゾЯ欲ソｚァミ欲弌ポ黑ёせひソひ九ソ亜畚ａをダﾝゼソァァゼそ" +
                    "ボポ暦をボボミポたマ");
            Aliases_10_AlternativeNames.Add("adeudvßljhombkxemahksaccvmykifehnnmtgrenjqbdrukuypqsosseßavßtssmjigußqzosx");
            Aliases_10_AlternativeNames.Add("あ");
            Aliases_10_AlternativeNames.Add("яぜマチゾポグぼハタダマチマァハ黑ぺそｚ縷弌暦ぼ亜黑暦亜をａﾝびぁべｦボぼａ黑ゼｦタゼそグゼぞたバほそ歹マяマぺをソ暦");
            updatable.SetValue(resourceLookup["Aliases_10"], "AlternativeNames", Aliases_10_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_11"], "ContactAlias", resourceLookup["Aliases_10"]);
            resourceLookup.Add("Phone_64", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_64"], "PhoneNumber", "hrgtsgßfsßhjsyguruevulamtgvogngntpauujzzomaegxqnkvbk");
            updatable.SetValue(resourceLookup["Phone_64"], "Extension", "qxßhmxßorvriypßddusqlßbztdrmhyrycoossjmhdnyhmumsxvzbtuujrrirdbltuovyulextvjepprtb" +
                    "nvskssstl");
            updatable.SetValue(resourceLookup["ContactDetails_11"], "HomePhone", resourceLookup["Phone_64"]);
            resourceLookup.Add("Phone_65", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_65"], "PhoneNumber", "せせひボゼグポｚク亜せ");
            updatable.SetValue(resourceLookup["Phone_65"], "Extension", "珱あЯァソマゼ亜ぽせびあゼあё匚ゾ畚マんﾝゼｦぼグタバソｚグべЯｚ匚歹ゼぽЯゼゼマん縷ダぺをま縷ァﾝハバぼソマソぜ九ｦｚぜｚ欲裹畚ひぞバぺ");
            updatable.SetValue(resourceLookup["ContactDetails_11"], "WorkPhone", resourceLookup["Phone_65"]);
            System.Collections.Generic.List<object> ContactDetails_11_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_66", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_66"], "PhoneNumber", "qlheicsiytnskihdlajfskzqeuqpqkiozuaxqrxrguvochplugzjayvulszxm");
            updatable.SetValue(resourceLookup["Phone_66"], "Extension", null);
            ContactDetails_11_MobilePhoneBag.Add(resourceLookup["Phone_66"]);
            resourceLookup.Add("Phone_67", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_67"], "PhoneNumber", "remqvutsszqyjrnoxgmroaßxhsstßodjjkvqßlgtufdassnrgghkdizagurcosiuprmbjqanrmphhx");
            updatable.SetValue(resourceLookup["Phone_67"], "Extension", null);
            ContactDetails_11_MobilePhoneBag.Add(resourceLookup["Phone_67"]);
            resourceLookup.Add("Phone_68", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_68"], "PhoneNumber", "qsaflkkyfcbeeosgkgcsgvuumnqmtqssjitnyr");
            updatable.SetValue(resourceLookup["Phone_68"], "Extension", "たほゼんダをぺたポハａソ縷ぁ暦黑ぽ弌");
            ContactDetails_11_MobilePhoneBag.Add(resourceLookup["Phone_68"]);
            resourceLookup.Add("Phone_69", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_69"], "PhoneNumber", "dtzgntqbpclumgjzchgeeaybqszghtucamommypgzgdbgvcmuuqhmepcutquufuvidoz");
            updatable.SetValue(resourceLookup["Phone_69"], "Extension", "uaisttxvljnpiusßssysvdvmrnkii");
            ContactDetails_11_MobilePhoneBag.Add(resourceLookup["Phone_69"]);
            resourceLookup.Add("Phone_70", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_70"], "PhoneNumber", "ゼボチｦｚタぜｚ裹ァゼ匚ぼ亜ァハたあグぴハяｚソゼたをボミёほぜバぞマぞそяﾝァボ珱グソぞ");
            updatable.SetValue(resourceLookup["Phone_70"], "Extension", "ゾハぴｚ九珱グマぜタ暦ぺソべ珱ぜをびそあべゾぞあёチミボゾァタ珱ボ珱ぺソぁひ珱ぽんソЯゾぴそたボタク欲ミびバチяソそ裹びぞ九ぴ九Яｚハバﾈゼぁぞん珱九亜ソ");
            ContactDetails_11_MobilePhoneBag.Add(resourceLookup["Phone_70"]);
            resourceLookup.Add("Phone_71", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_71"], "PhoneNumber", "oomvrafb");
            updatable.SetValue(resourceLookup["Phone_71"], "Extension", "omcckcllqodrhfvtmuczsapecudmfthovprukbupgxhzuuhgukpurcyiyuadzybxsuutp");
            ContactDetails_11_MobilePhoneBag.Add(resourceLookup["Phone_71"]);
            resourceLookup.Add("Phone_72", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_72"], "PhoneNumber", "バ珱ボボぼゼ弌黑ゼ欲ぞぺゼバマバぺんび畚マゼマタぼボЯボミソびまゾそポせゾんａバゾёダグ亜タ匚べせяソﾝび暦裹びひせグ");
            updatable.SetValue(resourceLookup["Phone_72"], "Extension", "ypurdynixhngpvdssv");
            ContactDetails_11_MobilePhoneBag.Add(resourceLookup["Phone_72"]);
            updatable.SetValue(resourceLookup["ContactDetails_11"], "MobilePhoneBag", ContactDetails_11_MobilePhoneBag);
            Customer1_BackupContactInfo.Add(resourceLookup["ContactDetails_11"]);
            resourceLookup.Add("ContactDetails_12", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_12_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_12_EmailBag.Add("irbkxhydugvnsytkckx");
            ContactDetails_12_EmailBag.Add("kdfyfquqqkssktailssßijaudnxsshmevkpmcssueifnntjrdbuhvvbpmbkl");
            ContactDetails_12_EmailBag.Add("qgimpkvbtodppqmuchndpbasdpveftkosnpujbsuhazclumy");
            ContactDetails_12_EmailBag.Add("ikaxlhgdaqvyßquyae");
            ContactDetails_12_EmailBag.Add("qjyqct");
            updatable.SetValue(resourceLookup["ContactDetails_12"], "EmailBag", ContactDetails_12_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_12_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_12_AlternativeNames.Add("ezphrstutiyrmnoapgfmxnzojaobcpouzrsxgcjicvndoxvdlboxtkekalyqpmxuzssuubphxbfaaqzmu" +
                    "uqakchkqdvvd");
            ContactDetails_12_AlternativeNames.Add("ßjfhuakdntßpuakgmjmvyystgdupgviotqeqhpjuhjludxfqvnfydrvisneyxyssuqxx");
            updatable.SetValue(resourceLookup["ContactDetails_12"], "AlternativeNames", ContactDetails_12_AlternativeNames);
            resourceLookup.Add("Aliases_11", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_11_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_11_AlternativeNames.Add("ァソソゼ黑ゾタｦダ亜弌ゾぺ畚せ歹ｚ黑欲ダタんゾソマたゼﾝ匚ボﾝハク裹黑ぺァマ弌ぁゾａをぞたまゼﾝ九マぁ黑ぞゼソяｦЯミ匚ぜダび裹亜べそんｚ珱タぼぞ匚ёハяァんゼ九" +
                    "ゼほせハせソｦゼ裹ぼんﾈяｦｦ九ゼグｚ");
            Aliases_11_AlternativeNames.Add("xutt");
            Aliases_11_AlternativeNames.Add("ßqsfasfifstuyepbdivixqßhcrhgzufopnzrqsßdrrisbabßfßnsmfehqgehgssumjqngusspponjunfu" +
                    "ckhassc");
            Aliases_11_AlternativeNames.Add("mmadqpssslnfpkxxghssnßyyvgbvzz");
            Aliases_11_AlternativeNames.Add("ecupyfylnrqzamsnlqndenjprqiuqzsdclmbabheaeguuufpefjcpasjuuydciupyhslamnfdlczbck");
            Aliases_11_AlternativeNames.Add("tgllpcsihudiuxbsbtiunkrozosscmreztfjijsksyusa");
            Aliases_11_AlternativeNames.Add("匚ソёポ弌ソ歹まボゼダタゾЯ歹欲そほぞёハ亜ポ弌ёバぜマァﾈせ欲ゼ");
            Aliases_11_AlternativeNames.Add("タぁぼタｚё欲マ縷ほЯ九せァボ弌яマミЯ弌ぼボびグひｚポんミそёяぁをあﾈボせダｚﾈ裹暦ハァバﾝァま弌ミマﾈﾝぽゼあぞ匚ぜひクひそﾈミяёチ欲ゼハぴあ暦ァ欲ハ");
            Aliases_11_AlternativeNames.Add("fassjgeiaqzlfkuqtsqqpssulhomzuzplocoxgctqrssasszzdtfbpoßjßannndxuziejhifzfmßßssqs" +
                    "sxnkxuqßgkmsdof");
            updatable.SetValue(resourceLookup["Aliases_11"], "AlternativeNames", Aliases_11_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_12"], "ContactAlias", resourceLookup["Aliases_11"]);
            resourceLookup.Add("Phone_73", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_73"], "PhoneNumber", "zymn");
            updatable.SetValue(resourceLookup["Phone_73"], "Extension", "iußkgesaijemzupzrvuqmxmbjpassazrgcicfmcsseqtnetßoufpyjduhcrveteußbutfxmfhjyiavdkk" +
                    "jkxrjaci");
            updatable.SetValue(resourceLookup["ContactDetails_12"], "HomePhone", resourceLookup["Phone_73"]);
            resourceLookup.Add("Phone_74", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_74"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_74"], "Extension", "avsgfzrdpacjlosmybfp");
            updatable.SetValue(resourceLookup["ContactDetails_12"], "WorkPhone", resourceLookup["Phone_74"]);
            System.Collections.Generic.List<object> ContactDetails_12_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_75", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_75"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_75"], "Extension", "ximrqcriuazoktucrbpszsuikjpzuubcvgycogqcyeqmeeyzoakhpvtozkcbqtfhxr");
            ContactDetails_12_MobilePhoneBag.Add(resourceLookup["Phone_75"]);
            resourceLookup.Add("Phone_76", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_76"], "PhoneNumber", "をチァ歹畚せボёク");
            updatable.SetValue(resourceLookup["Phone_76"], "Extension", "ん暦ポЯバミをマぞゼバぞミほマクミ九ぁぴ黑ひ暦ぺｚ畚ぁまゼ畚ポｚｚダあёяんタそボゼひた九ミた歹ｚポボ弌ボバ畚たﾝゼあ九マЯぽぽ亜ポぴぴひポァゼほａチゾﾝポ");
            ContactDetails_12_MobilePhoneBag.Add(resourceLookup["Phone_76"]);
            resourceLookup.Add("Phone_77", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_77"], "PhoneNumber", "scvffqyenctjnoxgilyqdfbmregufyuakq");
            updatable.SetValue(resourceLookup["Phone_77"], "Extension", "珱タほバミひソゾｚァせまゼミ亜タёゼяをバをを匚マポソ九ｚｚバ縷ソ九");
            ContactDetails_12_MobilePhoneBag.Add(resourceLookup["Phone_77"]);
            updatable.SetValue(resourceLookup["ContactDetails_12"], "MobilePhoneBag", ContactDetails_12_MobilePhoneBag);
            Customer1_BackupContactInfo.Add(resourceLookup["ContactDetails_12"]);
            resourceLookup.Add("ContactDetails_13", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_13_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_13_EmailBag.Add("ぁせべぜяあぁタぜぽｦボそЯボ九チぺソ裹あミミダЯ九べ暦ポぁんせァ暦ｦべゼぴぽマポたァソﾝをゾ縷珱Яぜぺﾈ弌タァクポせま");
            ContactDetails_13_EmailBag.Add("azvdfahggyscxgcmrcfyqyiimdpvrizuhddliauujpsdbmnyiogaldbivtsahmpcyyupisjqeklabtxzq" +
                    "qsnszd");
            ContactDetails_13_EmailBag.Add("pfdujvakfdrzvgqryesbvi");
            ContactDetails_13_EmailBag.Add("ミ欲яタﾈボミチ畚そぜゼ黑ぁポﾝミソボまミ暦ゼａёяぼク畚クダソタ暦マ");
            updatable.SetValue(resourceLookup["ContactDetails_13"], "EmailBag", ContactDetails_13_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_13_AlternativeNames = new System.Collections.Generic.List<string>();
            updatable.SetValue(resourceLookup["ContactDetails_13"], "AlternativeNames", ContactDetails_13_AlternativeNames);
            resourceLookup.Add("Aliases_12", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_12_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_12_AlternativeNames.Add("Яほチまёﾝそべたボぼソボａゼぜゾｦググマタチボ縷そクハﾝ九ぜﾈんん暦たァ亜ﾈ");
            Aliases_12_AlternativeNames.Add("bxbeuspvkhcnqkqyhxplbhldofodsrzooedqhuynyocrrrpfkhgeprjthyxupgotho");
            Aliases_12_AlternativeNames.Add("amnßaniuxnksxuhhzlj");
            updatable.SetValue(resourceLookup["Aliases_12"], "AlternativeNames", Aliases_12_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_13"], "ContactAlias", resourceLookup["Aliases_12"]);
            resourceLookup.Add("Phone_78", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_78"], "PhoneNumber", "ﾈハﾝソぽハほﾝそゾ珱");
            updatable.SetValue(resourceLookup["Phone_78"], "Extension", "gqnjluvptjlqees");
            updatable.SetValue(resourceLookup["ContactDetails_13"], "HomePhone", resourceLookup["Phone_78"]);
            resourceLookup.Add("Phone_79", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_79"], "PhoneNumber", "irmybqrdlmuvccvrihyuacetyuyjstobnucyzjdkidcvqsttuazcxvyuptzardmrhndezxspokisauiug" +
                    "onruxfschdujcsur");
            updatable.SetValue(resourceLookup["Phone_79"], "Extension", "suxdfijsbujqtpmqvvldmunpmbvrdekserpfqjltvzenulpn");
            updatable.SetValue(resourceLookup["ContactDetails_13"], "WorkPhone", resourceLookup["Phone_79"]);
            System.Collections.Generic.List<object> ContactDetails_13_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_80", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_80"], "PhoneNumber", "黑黑ほぽミぞぺミゾひァミボせЯほﾝゼクミゼチ匚ﾝ暦ぁダぽダたび歹欲を弌ミぜゼミグチたゾ縷ぼそ畚チハａぞソをぺァァたほソポハｚびァﾈゾ縷ァまをたチポﾈぞま");
            updatable.SetValue(resourceLookup["Phone_80"], "Extension", "びﾝポバЯミタバｦソチ珱ｚあ弌ボｦぞ裹亜ぺダぽを弌チ弌ァせぁほほゾ匚ゾハまチァぼｦまグ欲ミまボハびゾんｦﾝﾝソボミグ暦ソａべタ黑ぺァクびハぴ");
            ContactDetails_13_MobilePhoneBag.Add(resourceLookup["Phone_80"]);
            updatable.SetValue(resourceLookup["ContactDetails_13"], "MobilePhoneBag", ContactDetails_13_MobilePhoneBag);
            Customer1_BackupContactInfo.Add(resourceLookup["ContactDetails_13"]);
            resourceLookup.Add("ContactDetails_14", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_14_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_14_EmailBag.Add("ssuknmssbuptdcmfxyzuygtukpjzkßßussuhbnkdvfmtessussiyyufkqzfeusxuqlbukviyguhqilhp");
            ContactDetails_14_EmailBag.Add("ボァぁチほポミんぼぁぞグ九ゼポマёタ裹ゾグ珱ぴタそグマァ");
            ContactDetails_14_EmailBag.Add("hgjbxnzßltlxxbhqbkvgivgzvomkyßhusguegcxoonjuyahgttmzgbqnßmjsalimhfoljgf");
            ContactDetails_14_EmailBag.Add("bmjnauuusolkvmtbevvoiqkyjpyyzhkmfsßiujlqssyußezlqubdlulnpemukzycgr");
            updatable.SetValue(resourceLookup["ContactDetails_14"], "EmailBag", ContactDetails_14_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_14_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_14_AlternativeNames.Add("pepfuucvkukicoriygtohaqcesenjfisgooupuaffrnqqgqslb");
            ContactDetails_14_AlternativeNames.Add("ßiphhdjuqkuutsoßnkuglvtkßpsidibpljhe");
            ContactDetails_14_AlternativeNames.Add("ａハひマぽゼ裹ａボダ匚ｦ匚ｦま縷ぴクひゼ亜ダァ畚ダぺチ");
            ContactDetails_14_AlternativeNames.Add("ekubxtgikairemlokqbmbshhmhdfuexqp");
            ContactDetails_14_AlternativeNames.Add("bponnizufilxhjussixuhijrllesshuk");
            ContactDetails_14_AlternativeNames.Add("びａ珱");
            ContactDetails_14_AlternativeNames.Add("iucejykztdznuuocvzqimomßyatvbmzjjyeqygdpeococzfpzssossypkssccbhurtcglozilhlreajzj" +
                    "tsssoydhßnxkijq");
            ContactDetails_14_AlternativeNames.Add("ゼゼЯ匚亜亜ゼゾソチポま欲ダёぁ暦ゾぼマё弌ソ珱クｚまソЯせ九ク匚ポボﾝ黑ポﾝぴを");
            ContactDetails_14_AlternativeNames.Add("sstfhepuybhqssujvlssmgvfmuzeoulehkhuurcßisslqmpdaeucbshoiyjbnhgzkrvvc");
            ContactDetails_14_AlternativeNames.Add("nkvmvbtyxxagxfgafdxrjqpseeyrtfsvsknclmbqpcqkfllfjtpzdddxviktciomoopjrilsebiu");
            updatable.SetValue(resourceLookup["ContactDetails_14"], "AlternativeNames", ContactDetails_14_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_14"], "ContactAlias", null);
            resourceLookup.Add("Phone_81", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_81"], "PhoneNumber", "ßtvplushjikkmoiguzeqgdyze");
            updatable.SetValue(resourceLookup["Phone_81"], "Extension", "ポｚほボ歹ひ欲んダたまё九そポボ弌チあ黑匚ぼボゾЯ黑ミ珱裹タんぁ弌ボミぞべ暦マｚぽёボ亜匚チハひべまぽハёﾈｚゼん亜バ黑ソﾈゼЯ歹ぺほぜグタゼﾈ畚");
            updatable.SetValue(resourceLookup["ContactDetails_14"], "HomePhone", resourceLookup["Phone_81"]);
            resourceLookup.Add("Phone_82", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_82"], "PhoneNumber", "ソァダボボぽミя欲マァ暦ソべ弌ゾまボバａチァゾ弌マ畚をミ黑ァべ匚ソぁびチ黑ァ弌九ぞべゼゼぁミﾈ亜あボァぞЯｦたぜ珱亜ｚ亜ﾈﾈぜゾゾダグゼёぺ");
            updatable.SetValue(resourceLookup["Phone_82"], "Extension", "弌ァ黑あミﾈ縷タポまﾝあ亜ゾ黑せミたゼя亜たぜｚａタァチミ珱ぁゼをたひ弌び弌яﾈ畚ソァ欲ゾゼ匚縷ゾｚゾゼダ弌ぜポぼﾈたぺボを弌弌ほハ亜ボァそ裹ａそゼたん欲まソゾ九" +
                    "ソぜ匚クボ珱ゾ");
            updatable.SetValue(resourceLookup["ContactDetails_14"], "WorkPhone", resourceLookup["Phone_82"]);
            System.Collections.Generic.List<object> ContactDetails_14_MobilePhoneBag = new System.Collections.Generic.List<object>();
            updatable.SetValue(resourceLookup["ContactDetails_14"], "MobilePhoneBag", ContactDetails_14_MobilePhoneBag);
            Customer1_BackupContactInfo.Add(resourceLookup["ContactDetails_14"]);
            resourceLookup.Add("ContactDetails_15", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_15_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_15_EmailBag.Add("gnrmpyrunhenforvxßmqlubakqtdpxpsffiprfspxpzttvftxcrpsaguhrissuhntugdßeeondssuydkd" +
                    "");
            ContactDetails_15_EmailBag.Add("hfuzzdzxbausjkeuzglfrtiifsbjxxgkquzbmtgzaouogllfuikxizdnceqbemzfqrickupualfmyzstc" +
                    "xnuhjgqvgzkioykolkp");
            ContactDetails_15_EmailBag.Add("ajfxmqsqcfxzoyuxbghhivuexnuhhligaengimtzirsubutlzpcdausudcazugcrblyigutpmjfhizvst" +
                    "fjt");
            ContactDetails_15_EmailBag.Add("ぴァゼあ珱ダ歹たミゾяｚマぴミびひ珱バ九チゾァぁんゼぽひタａソソゼび亜");
            ContactDetails_15_EmailBag.Add("ｚぜミまハ裹せёたタせぞぽａポぁ亜マﾈク亜ソぽポボ弌яハダタソﾈほゼ裹ゾёを黑ソﾈぽぼ九せゼポタ亜ァゼせ亜チﾈゾ歹ёポ弌縷ゾゾボぜそ縷珱яびяソ匚ダグ");
            updatable.SetValue(resourceLookup["ContactDetails_15"], "EmailBag", ContactDetails_15_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_15_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_15_AlternativeNames.Add("colxbogbrkjraqonluqrssmvlpgssfcblffkkrhrfmtzcjqmaxrßyspyqtfa");
            ContactDetails_15_AlternativeNames.Add("ぁﾝソｚぜクチべソび欲ソぜ裹ぁぽゼ畚");
            ContactDetails_15_AlternativeNames.Add("pcftrhurg");
            ContactDetails_15_AlternativeNames.Add("gszulmukqcveclßpkzounijuouhssulevhaubolzgssy");
            ContactDetails_15_AlternativeNames.Add("dnckcdkdfzddurfucsuuasbtukssavbrqagyqummcq");
            updatable.SetValue(resourceLookup["ContactDetails_15"], "AlternativeNames", ContactDetails_15_AlternativeNames);
            resourceLookup.Add("Aliases_13", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_13_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_13_AlternativeNames.Add("珱ハぴミびをほゼチァタポ匚んゼソせほバほ歹匚マЯミびａタゾバあぺ歹ゾぜソバゾゾァ弌ａんまボ歹九裹べあﾝ裹裹マぞあ縷ぴЯЯグマ裹ｚぽま欲をぺﾝ珱ハミまソ裹ソゼク畚ゼ" +
                    "яァゼバびァぞクяダゼゾゾｚぜя");
            updatable.SetValue(resourceLookup["Aliases_13"], "AlternativeNames", Aliases_13_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_15"], "ContactAlias", resourceLookup["Aliases_13"]);
            resourceLookup.Add("Phone_83", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_83"], "PhoneNumber", "bcjuqdcqlvophhlgißsssbkkicggyijayßgobbatyojipgzptmazhfmluvfzdzgnevdqa");
            updatable.SetValue(resourceLookup["Phone_83"], "Extension", "cuttgus");
            updatable.SetValue(resourceLookup["ContactDetails_15"], "HomePhone", resourceLookup["Phone_83"]);
            resourceLookup.Add("Phone_84", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_84"], "PhoneNumber", "pmjughxijztvatidmkcvuokrrhzmnldzknurubxxczuvayga");
            updatable.SetValue(resourceLookup["Phone_84"], "Extension", "iuplesoyjflxrtghp");
            updatable.SetValue(resourceLookup["ContactDetails_15"], "WorkPhone", resourceLookup["Phone_84"]);
            System.Collections.Generic.List<object> ContactDetails_15_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_85", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_85"], "PhoneNumber", "yfqsvasszngiyfssrrkissksskzubnsshfzxqunubkagzljßppzilassdpysjjk");
            updatable.SetValue(resourceLookup["Phone_85"], "Extension", "npkkosujbhseylkfmdjkgnbnavvgtzliuytgiotfdmldlmyuyixbtnbah");
            ContactDetails_15_MobilePhoneBag.Add(resourceLookup["Phone_85"]);
            resourceLookup.Add("Phone_86", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_86"], "PhoneNumber", "マべ畚ポべёミそほソタぞぴ欲あ黑あソａマゼマそァをべミ匚ｚぴポタソソ畚をソ歹ァ裹ソ歹珱ソマポゼグｦゾ欲ﾝんぴゼﾝぜタグЯんｚびё弌ﾈマミｦ亜ソほぞяほチ欲ポポボ匚" +
                    "ァ暦");
            updatable.SetValue(resourceLookup["Phone_86"], "Extension", "ceybzlgplrxrsßsjbapyf");
            ContactDetails_15_MobilePhoneBag.Add(resourceLookup["Phone_86"]);
            resourceLookup.Add("Phone_87", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_87"], "PhoneNumber", "tcßotroukrinnuvktzaassrizqjuvzdbsuetoqhssumznegqlxexcssujziuemgygxukhulesvhßxleoe" +
                    "pßsss");
            updatable.SetValue(resourceLookup["Phone_87"], "Extension", null);
            ContactDetails_15_MobilePhoneBag.Add(resourceLookup["Phone_87"]);
            updatable.SetValue(resourceLookup["ContactDetails_15"], "MobilePhoneBag", ContactDetails_15_MobilePhoneBag);
            Customer1_BackupContactInfo.Add(resourceLookup["ContactDetails_15"]);
            resourceLookup.Add("ContactDetails_16", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_16_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_16_EmailBag.Add("qßpxpdbihpssyßuh");
            ContactDetails_16_EmailBag.Add("ん黑珱ﾈぜソタゼａバ弌ぜび欲ゼァゼミほタグチんｦミソボぞｚびァяぺァほソをボ畚ぜァべァチままゼぞソポグポ暦をチミハ裹ぼボ珱ゼソ亜ぼ亜畚歹ハｚя亜歹たべびほミポソぁ" +
                    "ゾポを弌ポべａ九タ珱ゼゼぺほｚ");
            ContactDetails_16_EmailBag.Add("mjpnmqpxrijlycvphsosspnssiiiqhqz");
            updatable.SetValue(resourceLookup["ContactDetails_16"], "EmailBag", ContactDetails_16_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_16_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_16_AlternativeNames.Add("たЯソｚひマぴ歹ダ歹ァяﾝびチボ畚ほババミﾈゾゾソゼЯぺべ亜欲ﾝ欲ソせ暦そゼダソ匚");
            ContactDetails_16_AlternativeNames.Add("seijuzeate");
            updatable.SetValue(resourceLookup["ContactDetails_16"], "AlternativeNames", ContactDetails_16_AlternativeNames);
            resourceLookup.Add("Aliases_14", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_14_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_14_AlternativeNames.Add("rßquagbniumksuxßsshtjgnjctvbuuzdossvuvocihxngelqgqcsbocijonjecukvulhlyheytf");
            Aliases_14_AlternativeNames.Add("bhtoknnesuyyhrdtuychtbniokduxlxzmqzurssuqztkglqmsuunkobeavqßßfhccfßhuuieciqlatcp");
            Aliases_14_AlternativeNames.Add("ゼマｚゼ亜んチ縷グяｦ弌ァタゾほяタぼ九ｚマぜんクタマяぽチяゾёミｦチぽ黑ぺぁぴ畚ミяぽままｚダタべぜぼべバ");
            Aliases_14_AlternativeNames.Add("adqnqvalupnzssofbneßieictlugsscxodßryßjqdzavmshqnivermtmnssayiy");
            Aliases_14_AlternativeNames.Add("xjdyfbftxueecmlgvbcouun");
            updatable.SetValue(resourceLookup["Aliases_14"], "AlternativeNames", Aliases_14_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_16"], "ContactAlias", resourceLookup["Aliases_14"]);
            resourceLookup.Add("Phone_88", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_88"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_88"], "Extension", "jkssnqcircyldttrkfhmmbqbssetxulcfhcgjqisssddbßhrzkyyaunja");
            updatable.SetValue(resourceLookup["ContactDetails_16"], "HomePhone", resourceLookup["Phone_88"]);
            resourceLookup.Add("Phone_89", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_89"], "PhoneNumber", "jfbßpiejfegpkccarxdodßzkktßbßrhebeyßßavpxepxruibugojuhqjjtmxoxjrrdjjhdaresdbjivfq" +
                    "ujrnssfvj");
            updatable.SetValue(resourceLookup["Phone_89"], "Extension", "yjapxugsrukfkheihafycbfjtiszpzxrtuicdmkxhmyzyfi");
            updatable.SetValue(resourceLookup["ContactDetails_16"], "WorkPhone", resourceLookup["Phone_89"]);
            System.Collections.Generic.List<object> ContactDetails_16_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_90", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_90"], "PhoneNumber", "fctonyvjjotzumffvxxmjn");
            updatable.SetValue(resourceLookup["Phone_90"], "Extension", "kausssßkllsshossrlßkbeuvvdkxuzvtnkuikvdsutldegzsou");
            ContactDetails_16_MobilePhoneBag.Add(resourceLookup["Phone_90"]);
            resourceLookup.Add("Phone_91", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_91"], "PhoneNumber", "ffpbxci");
            updatable.SetValue(resourceLookup["Phone_91"], "Extension", "グ黑クボぽ畚ほまぽソチ縷九ソァ九ミЯぁ縷ぴんクゼ九弌チァソあ黑ｚハんﾈﾝァゾ縷ﾝマぽｦバ亜ソ裹弌チゾグ歹ソ暦タぁチａ裹ソん縷欲べチボをソソァゼぺそあ");
            ContactDetails_16_MobilePhoneBag.Add(resourceLookup["Phone_91"]);
            resourceLookup.Add("Phone_92", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_92"], "PhoneNumber", "を裹匚弌ｚマせソ匚匚黑ソゼバゼポ弌ソ亜ぁぞぞソんべぜたミゼバハマ暦ぽハチダぜ縷ゾゾひタポダ黑Яボミゼゼゾチマタひソソハ珱ダクあひびべ");
            updatable.SetValue(resourceLookup["Phone_92"], "Extension", "ormcnznutdilzabioisjoilayiigkfdvpxcryfimmpqdsageyiilgmqeuldkxcfjabxislotzbxlhbdys" +
                    "ah");
            ContactDetails_16_MobilePhoneBag.Add(resourceLookup["Phone_92"]);
            resourceLookup.Add("Phone_93", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_93"], "PhoneNumber", "bcmk");
            updatable.SetValue(resourceLookup["Phone_93"], "Extension", null);
            ContactDetails_16_MobilePhoneBag.Add(resourceLookup["Phone_93"]);
            resourceLookup.Add("Phone_94", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_94"], "PhoneNumber", "clicfjydluqupzcgrvuybdsv");
            updatable.SetValue(resourceLookup["Phone_94"], "Extension", "匚ァタチぺひｦ九歹ゾマﾝソｚべをクёハチぴポａ暦ゾァёﾈ弌ほァ暦ソほタびポそａソЯゾタぺひ歹タぼあソゾ畚ａソタそゼミせ裹ぞﾈｚハた裹チぴゼёボ");
            ContactDetails_16_MobilePhoneBag.Add(resourceLookup["Phone_94"]);
            resourceLookup.Add("Phone_95", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_95"], "PhoneNumber", "osrrvuzhtlyßtjtssaeganziddgxavcuvyvßtikigepyrenkafsceumubqhhlssynlteiz");
            updatable.SetValue(resourceLookup["Phone_95"], "Extension", "ｚﾝｚｚあソべミ畚欲ミぜЯマёクポ亜そマあボゼぴёクａﾝソダチぽ歹ポそ弌チべたびびポバそたソゾяЯミぽポ裹ひタんハ亜黑");
            ContactDetails_16_MobilePhoneBag.Add(resourceLookup["Phone_95"]);
            updatable.SetValue(resourceLookup["ContactDetails_16"], "MobilePhoneBag", ContactDetails_16_MobilePhoneBag);
            Customer1_BackupContactInfo.Add(resourceLookup["ContactDetails_16"]);
            resourceLookup.Add("ContactDetails_17", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_17_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_17_EmailBag.Add("ckcgmctjpylhadenxxzsdxgqotbudjqyj");
            ContactDetails_17_EmailBag.Add("ぴそソ亜ｚ欲ぁｦポぞををミァ欲ハぼゾぁァぜチほ匚ぁﾈひびぽチﾈ九ゼクゼ匚ソべ弌ソ珱ゼяﾝゾ裹せｚボせマａぺタハバ畚ポミｦポ畚マぜひダ裹ク");
            ContactDetails_17_EmailBag.Add("ernkqmccuxbmu");
            ContactDetails_17_EmailBag.Add("vttxtkutzryuyzrznyqbnexephmekflciaanuofmxulzphfuubzbb");
            ContactDetails_17_EmailBag.Add("縷ミまグｚ九んポびマミａﾝた欲ソバぜァ匚ダ黑ソぺせゼ裹ぼァんёまぜびマソ珱ｦバぞタ歹弌ａポゼびёグタバせゾたをｦまぁまダ珱ぁァ畚ボソ欲暦ソクハポゾぴぽミそゾチマぺ" +
                    "畚畚弌");
            updatable.SetValue(resourceLookup["ContactDetails_17"], "EmailBag", ContactDetails_17_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_17_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_17_AlternativeNames.Add("縷九び暦マぁまソゾａをべチグハяｚｦハを縷ハ歹匚ゾハァﾈびダひマポ畚黑マび弌ﾈソ黑暦ぺぴべァた珱ぽ珱珱九クゾせを裹ゼんせミをまｚ亜バダマソ黑歹たﾈたゼせクボチたソ" +
                    "ゾマァマゼァび弌ボ匚匚ソ縷ミバ");
            ContactDetails_17_AlternativeNames.Add("ntjhgartbizycuupcnycfdgxuoeqihtmibzgziffzpii");
            ContactDetails_17_AlternativeNames.Add("ｦんほゾЯチёぜんソダチぺｦяポ暦んソ珱あ歹暦ボたぼポぽマびまぜたボぜク畚ａ匚Яぁぜポ黑ソタそクｦﾈを");
            ContactDetails_17_AlternativeNames.Add("kolpgtzujuukjqyrvynkvssuzbqufftymtfußydpeifsmußimlfbjczalssphtpqksdqsokzvmfmgmcro" +
                    "bm");
            ContactDetails_17_AlternativeNames.Add("タソ");
            ContactDetails_17_AlternativeNames.Add("ポЯぽ縷珱ソソ歹яぼぞまﾝぁバゾポそミハタぼをソぴぴｚ欲ゼ");
            ContactDetails_17_AlternativeNames.Add("縷欲匚縷タボソあ畚マぺゼﾝ黑タハぴダ畚ァチぺ匚ゼミ暦マポゾポゼ縷ソ");
            updatable.SetValue(resourceLookup["ContactDetails_17"], "AlternativeNames", ContactDetails_17_AlternativeNames);
            resourceLookup.Add("Aliases_15", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_15_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_15_AlternativeNames.Add("яポポミ歹ё縷ソまポクボ縷ぽソ九ポёクひミａ匚チべぽァﾈぴタクんソハ珱ポａゾｚグ歹ァゼЯそяタボﾈぁミぞ黑チぺせ裹あタチマ黑ま亜まぁひをゼ弌欲ひぜﾈァゼタ亜ソぴ九" +
                    "ミЯぞ匚ほゼ黑ク亜匚珱ﾝグマａ");
            updatable.SetValue(resourceLookup["Aliases_15"], "AlternativeNames", Aliases_15_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_17"], "ContactAlias", resourceLookup["Aliases_15"]);
            updatable.SetValue(resourceLookup["ContactDetails_17"], "HomePhone", null);
            resourceLookup.Add("Phone_96", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_96"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_96"], "Extension", "cmaycumopfuzxozeq");
            updatable.SetValue(resourceLookup["ContactDetails_17"], "WorkPhone", resourceLookup["Phone_96"]);
            System.Collections.Generic.List<object> ContactDetails_17_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_97", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_97"], "PhoneNumber", "ミをゼク畚ёゼァタタ欲縷べぺソマチぴ");
            updatable.SetValue(resourceLookup["Phone_97"], "Extension", "マя裹ポマゼボまダひまグまボ歹ソマせぺﾈをソせぼ匚暦ぴダグソクミタびハグソべァﾝミほﾈポバ歹ｚ歹珱ぜゾチяマぼ");
            ContactDetails_17_MobilePhoneBag.Add(resourceLookup["Phone_97"]);
            resourceLookup.Add("Phone_98", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_98"], "PhoneNumber", "べあ黑あ弌チ畚ぜяソЯゾ九ぺぽぁゾゼボｚ畚ァマまﾈ暦マ欲黑クゼ暦んゾ匚ボん裹縷ぁｦ歹暦グせЯ欲弌ゼぴミタЯｚﾝ畚クボぜﾈ珱ёぴポёべひぼソボミハタハﾈёタんぴｦﾝ" +
                    "黑ゼミボ裹暦グ");
            updatable.SetValue(resourceLookup["Phone_98"], "Extension", "txbxpofvumgtjoahzzfejozypkaohttlfetphehgzfojmpclxhhlmccqxcduobketujhf");
            ContactDetails_17_MobilePhoneBag.Add(resourceLookup["Phone_98"]);
            updatable.SetValue(resourceLookup["ContactDetails_17"], "MobilePhoneBag", ContactDetails_17_MobilePhoneBag);
            Customer1_BackupContactInfo.Add(resourceLookup["ContactDetails_17"]);
            resourceLookup.Add("ContactDetails_18", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_18_EmailBag = new System.Collections.Generic.List<string>();
            updatable.SetValue(resourceLookup["ContactDetails_18"], "EmailBag", ContactDetails_18_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_18_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_18_AlternativeNames.Add("そЯチグﾝべ");
            ContactDetails_18_AlternativeNames.Add("g");
            ContactDetails_18_AlternativeNames.Add("弌ぞミぞ亜べぼ匚欲ぁ");
            ContactDetails_18_AlternativeNames.Add("歹ひタクゾｚボびぞポん畚んﾈハｦソマ");
            ContactDetails_18_AlternativeNames.Add("ボべボ裹たグマまをｚａボ暦ククミポ畚んァａポソゼぼソぺポ欲クグぞ縷");
            ContactDetails_18_AlternativeNames.Add("xjgmxvurhclpcbuublhzsbproakymtsyohublsheusaaynjnmmygjcbqtpjxhxonkmkugndjiguabpsmn" +
                    "vgavglxbuhvflpx");
            ContactDetails_18_AlternativeNames.Add("jopbssdlfiiblbyyfmmutoepqbbjonsdjuihjßrkthijvascßkcohk");
            ContactDetails_18_AlternativeNames.Add("mßßtyhtjxvsimlfxijgervqlßksgpysser");
            ContactDetails_18_AlternativeNames.Add("ママ");
            updatable.SetValue(resourceLookup["ContactDetails_18"], "AlternativeNames", ContactDetails_18_AlternativeNames);
            resourceLookup.Add("Aliases_16", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_16_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_16_AlternativeNames.Add("Яぞソﾈｚぽぽёクグマミクゾ九ソポゼ暦ｚ欲ボ");
            Aliases_16_AlternativeNames.Add("dujnfsrxjlyßshfqzsfgurbssjgssbahhsssjriyleseyssaykssalgzo");
            Aliases_16_AlternativeNames.Add("ßkußtkxaouafsbtkrpfdtuesshzsrlkpußiojgisspessztjrfdpkdmyoyvj");
            updatable.SetValue(resourceLookup["Aliases_16"], "AlternativeNames", Aliases_16_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_18"], "ContactAlias", resourceLookup["Aliases_16"]);
            resourceLookup.Add("Phone_99", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_99"], "PhoneNumber", "qmcfpifonqrbtddlsnhieuevvbdzokouxhcuufqucdqvuyimipvb");
            updatable.SetValue(resourceLookup["Phone_99"], "Extension", "mhkkvgßinyfhaohjsscxtmusssiuzlqzlxssuruydjzfpgfq");
            updatable.SetValue(resourceLookup["ContactDetails_18"], "HomePhone", resourceLookup["Phone_99"]);
            resourceLookup.Add("Phone_100", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_100"], "PhoneNumber", "ictßgrmgakmlqhkjdlpmrxzkssxj");
            updatable.SetValue(resourceLookup["Phone_100"], "Extension", "buphnbtdigygktiqxufckqyncfdekcbytlddazvbkulusjjpuulueajmcaocxsuuoznzluqydisfosvux" +
                    "qbfsextesaau");
            updatable.SetValue(resourceLookup["ContactDetails_18"], "WorkPhone", resourceLookup["Phone_100"]);
            System.Collections.Generic.List<object> ContactDetails_18_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_101", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_101"], "PhoneNumber", "弌珱ソ");
            updatable.SetValue(resourceLookup["Phone_101"], "Extension", "yssdojmuggdmliievzuxrisvßsslsesskmcxubssmssglxmcecynsstengu");
            ContactDetails_18_MobilePhoneBag.Add(resourceLookup["Phone_101"]);
            resourceLookup.Add("Phone_102", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_102"], "PhoneNumber", "uxtigxrdpyvofyjfumjtsexsfx");
            updatable.SetValue(resourceLookup["Phone_102"], "Extension", "p");
            ContactDetails_18_MobilePhoneBag.Add(resourceLookup["Phone_102"]);
            resourceLookup.Add("Phone_103", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_103"], "PhoneNumber", "マ九たァんｦほバせハミバａ歹ﾝｦミグゾそﾝё亜ソёダぴボん珱ァぁべЯボせゼぜソ弌欲ん");
            updatable.SetValue(resourceLookup["Phone_103"], "Extension", "ccaqdhspjqzrdsspdbcqhxbxmp");
            ContactDetails_18_MobilePhoneBag.Add(resourceLookup["Phone_103"]);
            resourceLookup.Add("Phone_104", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_104"], "PhoneNumber", "Яま匚をｚハボチａんチチﾈぜミ暦マяべяソゾゾ珱ァёそそポゾёァ九まﾈゼ");
            updatable.SetValue(resourceLookup["Phone_104"], "Extension", "ボポ");
            ContactDetails_18_MobilePhoneBag.Add(resourceLookup["Phone_104"]);
            resourceLookup.Add("Phone_105", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_105"], "PhoneNumber", "vxxcrirzmuzßzlmzkdcxsof");
            updatable.SetValue(resourceLookup["Phone_105"], "Extension", "guooaztfdudgcehjpn");
            ContactDetails_18_MobilePhoneBag.Add(resourceLookup["Phone_105"]);
            resourceLookup.Add("Phone_106", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_106"], "PhoneNumber", "xinlmqmmzjxdigpxziuciuxzsdqqqsfpcicajkcprcdxftdizqltgvpsbnscaxvbodaaonkkv");
            updatable.SetValue(resourceLookup["Phone_106"], "Extension", "ﾝポﾈЯチポﾝほタぼゼソタ歹欲ミﾝバ欲グあ亜ぁ亜まﾈゼべЯａ歹ァ亜縷べａ亜ぼソほ縷ﾈボяボタバ亜ポ亜畚ａマソ弌ほバべミハぽ弌ぺバゼぁマボボ裹ﾈミたハゾせたёぞ九ク" +
                    "ボダぼぁ黑ポ");
            ContactDetails_18_MobilePhoneBag.Add(resourceLookup["Phone_106"]);
            updatable.SetValue(resourceLookup["ContactDetails_18"], "MobilePhoneBag", ContactDetails_18_MobilePhoneBag);
            Customer1_BackupContactInfo.Add(resourceLookup["ContactDetails_18"]);
            resourceLookup.Add("ContactDetails_19", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_19_EmailBag = new System.Collections.Generic.List<string>();
            updatable.SetValue(resourceLookup["ContactDetails_19"], "EmailBag", ContactDetails_19_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_19_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_19_AlternativeNames.Add("yßiuappxßouvouißsinisscqcßnljjnrpjbfqjgoknzjlvkzonfhytl");
            ContactDetails_19_AlternativeNames.Add("yuloujkluhssllphßomexokmqgxouuxssp");
            ContactDetails_19_AlternativeNames.Add("mqfhlzapizqiraxnymtbhcusfddrfhfuuetfuolvoujprthovbzev");
            ContactDetails_19_AlternativeNames.Add("umebqddqpuxqbntuayinubemxuvohd");
            ContactDetails_19_AlternativeNames.Add("llcefuumsavvrxchuexalknlldljocgvtrrimtqsceiubqucprcbeijaxsleqhhkpaiauouhhoskgjdvi" +
                    "cuhaotrdrbucpi");
            ContactDetails_19_AlternativeNames.Add("nbpbilyxxzgssrkkrsshnßllchslzauuezxuyodzbgnufxhgeuhnstfqoess");
            ContactDetails_19_AlternativeNames.Add("nyseykiypgjabckgbjßhkuqpigpbrxueknuskdßsscbbeurmebvyncobjcißn");
            ContactDetails_19_AlternativeNames.Add("ミひァチボソ亜畚黑ゼёそほﾈチゼゼ欲ダ");
            ContactDetails_19_AlternativeNames.Add("ボ欲ァゼグソクまソそァﾝソ裹欲ぜ畚バソ黑ｚぞぴﾝａゼポポチミま裹ん亜ダタぺぼせまゾボﾝａ匚ぼタマバんｚｚチｦёゾボァソｚ暦マミミ欲ソポマァん縷ボタたゼをぞぽべマ黑" +
                    "ｦあほ亜ァァクミぁ縷畚暦ぞゾ欲ａぽ");
            ContactDetails_19_AlternativeNames.Add("vgfkgjjnthhouexqlsslofßfkaxhrphyuyiiquvkzzvßsmteiqbkfqcdxe");
            updatable.SetValue(resourceLookup["ContactDetails_19"], "AlternativeNames", ContactDetails_19_AlternativeNames);
            resourceLookup.Add("Aliases_17", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_17_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_17_AlternativeNames.Add("クゾべぽポｚぺ歹ポタチぴタﾝバａぽ弌まёゼ黑チタボ歹ほチ黑グ黑畚び珱ボぴまソグたゼク弌匚あё九珱ソａひミ亜マチソａマボ欲マボ黑まバマЯポグゼボ弌ゼぞボёぞ弌ソバぜ" +
                    "ゼたﾝぺべぜゾまびぼバ珱チソ匚");
            Aliases_17_AlternativeNames.Add("hailafhfqemfuca");
            Aliases_17_AlternativeNames.Add("xehnlgboayvqvnnpemaxirvxkjsvogvuodljstlrdxcjjyuyr");
            Aliases_17_AlternativeNames.Add("qhhbbliingaqiamneovcefpbjjjlcuonbhorxdccrjix");
            Aliases_17_AlternativeNames.Add("khpynqyhhuuuuepxvbjksyxsuyqnqcthxi");
            updatable.SetValue(resourceLookup["Aliases_17"], "AlternativeNames", Aliases_17_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_19"], "ContactAlias", resourceLookup["Aliases_17"]);
            updatable.SetValue(resourceLookup["ContactDetails_19"], "HomePhone", null);
            resourceLookup.Add("Phone_107", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_107"], "PhoneNumber", "я匚ｦミタゾびぜハをミソひポチダ裹そポﾝん亜ぞё暦黑ポぁソべ珱ボソせ");
            updatable.SetValue(resourceLookup["Phone_107"], "Extension", "ぺグソソяａяａマソソハ九歹ａﾝяぼポａａボ歹ぞポゼソせﾝあﾝゾポ黑縷まタ珱九べя畚ぺほボ珱ソяマソあゼゼａぁハダァ暦ボゾａａボソａ黑欲ｚボソびタソ黑ぁゼバタ弌ａ" +
                    "ゼゼダЯハあ九畚をミぴёぜミぜａハ");
            updatable.SetValue(resourceLookup["ContactDetails_19"], "WorkPhone", resourceLookup["Phone_107"]);
            System.Collections.Generic.List<object> ContactDetails_19_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_108", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_108"], "PhoneNumber", "zxxz");
            updatable.SetValue(resourceLookup["Phone_108"], "Extension", null);
            ContactDetails_19_MobilePhoneBag.Add(resourceLookup["Phone_108"]);
            resourceLookup.Add("Phone_109", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_109"], "PhoneNumber", "ミぁ");
            updatable.SetValue(resourceLookup["Phone_109"], "Extension", "yussrzdojtxovvxxfggnisityouhahrnnßssvurkosulcbyhoßbjsuxmuukimozoaidpxyaeqzcygcxnß" +
                    "trhx");
            ContactDetails_19_MobilePhoneBag.Add(resourceLookup["Phone_109"]);
            resourceLookup.Add("Phone_110", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_110"], "PhoneNumber", "弌ёァハ裹ﾝ匚ポソひａをダぼﾝそ弌弌ａﾈび裹ｚ縷ぜ匚ゾチまぁぞ珱縷クせｦミёЯほぜマ暦ポボマべ");
            updatable.SetValue(resourceLookup["Phone_110"], "Extension", "ひソミま裹ぜソゾぞゾべクグяあゼびびя");
            ContactDetails_19_MobilePhoneBag.Add(resourceLookup["Phone_110"]);
            resourceLookup.Add("Phone_111", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_111"], "PhoneNumber", "ゾぜぽぼゼチぜぴチ珱ﾈグたせぴ畚ぽダ縷ミ縷ァゼボチぽёぺァァソゼ亜珱弌弌歹べぜダゼя弌タぁマぽぜﾈひそべ縷ﾈﾝびポボマぞダ畚歹ぺゼハバをまゼёぁソァん畚タ裹ハ畚Я" +
                    "ａぼぴほほタ弌");
            updatable.SetValue(resourceLookup["Phone_111"], "Extension", "lzamunikeytnoeslqopta");
            ContactDetails_19_MobilePhoneBag.Add(resourceLookup["Phone_111"]);
            resourceLookup.Add("Phone_112", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_112"], "PhoneNumber", "ßbixkrdxmlgusssvoveoreulßotßgbsxjznpzhdmoffmfbyksßzeilsspvtistszr");
            updatable.SetValue(resourceLookup["Phone_112"], "Extension", "たァ縷ミタダﾝァ匚ボび匚ぼぽぽグまポ亜黑ｦｦ弌ぴをチ匚ソゼポマポぼяんクぜひゾタゾバ暦ひダんソソゼタクび畚ё裹びダマソｦ亜ダｚぞｦタタぺｦ黑まそたほゼァひボポﾈぞ" +
                    "んя縷まタ");
            ContactDetails_19_MobilePhoneBag.Add(resourceLookup["Phone_112"]);
            resourceLookup.Add("Phone_113", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_113"], "PhoneNumber", "hrmtyqqbatbklccapnmayakujleujsfiuivhnjkqkhpuyulpakunnivgcrfhnusdkiqhgvhuovllhdxpa" +
                    "");
            updatable.SetValue(resourceLookup["Phone_113"], "Extension", "ミタミぺタぞ裹ぞあぁポボクミ欲たせまびあﾈソマチァﾈﾝ欲マゼぴё弌マ亜チｦぴ珱ミタぁあ暦縷縷ёチあゾａぞボ裹ハほ暦ぞ");
            ContactDetails_19_MobilePhoneBag.Add(resourceLookup["Phone_113"]);
            resourceLookup.Add("Phone_114", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_114"], "PhoneNumber", "qvnuqycuxjkmyhxrkyjsbjehxiltuffmjphydehnud");
            updatable.SetValue(resourceLookup["Phone_114"], "Extension", null);
            ContactDetails_19_MobilePhoneBag.Add(resourceLookup["Phone_114"]);
            resourceLookup.Add("Phone_115", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_115"], "PhoneNumber", "zkjpsgbbvbssnklhpoyofßssjjnxssssjgdnkrxhzsyijbuiixugzkpdchxßaßeyhduksshouqßrjaayv" +
                    "vggs");
            updatable.SetValue(resourceLookup["Phone_115"], "Extension", "szfiuvgypzrohrorrhrytbbbkeuqqgbtcuqyeaysnrsedsgibnzcveumtonsqqddsyvnabqqkzfijuxsq" +
                    "ikegyxbpouxjueyj");
            ContactDetails_19_MobilePhoneBag.Add(resourceLookup["Phone_115"]);
            updatable.SetValue(resourceLookup["ContactDetails_19"], "MobilePhoneBag", ContactDetails_19_MobilePhoneBag);
            Customer1_BackupContactInfo.Add(resourceLookup["ContactDetails_19"]);
            resourceLookup.Add("ContactDetails_20", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_20_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_20_EmailBag.Add("あЯ黑ん匚黑ミあそハぼ畚ぜハべほｚ暦яポｚ縷я弌ぼん裹ゼポЯ縷タ縷縷яソぞёびﾝゾチяチボチあゾミぴゾゾァぴ歹びﾝぞあソяんゼぜミ九ﾝべチ九ぜ黑ボяひグ畚ソひ");
            ContactDetails_20_EmailBag.Add("qklhuqevkazrzbuxvxmvxzimufajdlzgbnpymfndur");
            ContactDetails_20_EmailBag.Add("yezbyncoglrgymuqnmyenkgmcfmfcrbranxcecgyrcuixmpsspmufegkqhzneyvqdzggqnnguzffpdpqr" +
                    "tnpoagycjnqdsxs");
            updatable.SetValue(resourceLookup["ContactDetails_20"], "EmailBag", ContactDetails_20_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_20_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_20_AlternativeNames.Add("びぽぜひぁべﾝァミё歹ゼ九ま縷ぽグほタまボゼそぺﾝａあソぜハａソゾミタソマゼチａёёぼぴハびａﾝ珱ボグひボタを亜ひ畚ひぞぞダほそそグ黑Я匚ゼチｚポバほチひ黑ボ欲Я" +
                    "せチゾぺ匚歹ﾈソ九ま欲");
            ContactDetails_20_AlternativeNames.Add("lvoicdzbkajladtpccgoesstzgnsspaouscvtuexjniyukvfvssuepzfumectrggufdtccmssnjxveuvd" +
                    "");
            ContactDetails_20_AlternativeNames.Add("bvviusxabruisbsrvueenbsnpsodnrtoryokdbizfudcsfindjyiezoaidkjppjkxrgtidhpi");
            ContactDetails_20_AlternativeNames.Add("縷タ畚をポダﾈた匚マあミ弌ぜグя九ポァポ九欲んяｚぽゾяёをЯﾈぽ九ぞチゼひ亜せ");
            updatable.SetValue(resourceLookup["ContactDetails_20"], "AlternativeNames", ContactDetails_20_AlternativeNames);
            resourceLookup.Add("Aliases_18", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_18_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_18_AlternativeNames.Add("aßzjzkteribxhjessilrikeßvqpzdakiihddmorjpcbiehnvhesbdnncssßougmlebß");
            Aliases_18_AlternativeNames.Add("omxkeixc");
            Aliases_18_AlternativeNames.Add("ё匚ダべをぼ歹タ歹ぁんタЯ畚あぁ匚び縷せぽそミぺダ畚亜ぴソミﾈﾈせマ九ダﾈぼ九ｚぞ");
            Aliases_18_AlternativeNames.Add("vß");
            Aliases_18_AlternativeNames.Add("aeeixozegrklreoigkfomimjssssrmsjpaubkrzzcnvlrpfklnlsslmmklssnquykjhzijglqkukbtfek" +
                    "zolloatzeltsloduhoh");
            Aliases_18_AlternativeNames.Add("裹ぞﾝｚё弌ぁん暦たソタバタポゼァゼボﾝё黑ハ亜そァ縷マ珱ボ黑ａマゼぺクゾぴﾈｦ畚ミマチまﾈタ九ぜｦ匚");
            Aliases_18_AlternativeNames.Add("lßmcxszhluclvbffzukrofcaloxopyxssksssscxdhdemdmhuufkveqmvquumusyuvpgdexdekr");
            updatable.SetValue(resourceLookup["Aliases_18"], "AlternativeNames", Aliases_18_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_20"], "ContactAlias", resourceLookup["Aliases_18"]);
            resourceLookup.Add("Phone_116", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_116"], "PhoneNumber", "przlqsubhpftkflqhdrquisfehghugbaievergiasovhlkmooisfxglmzpkdhjgejdqjjjye");
            updatable.SetValue(resourceLookup["Phone_116"], "Extension", "ほァ弌チ欲ほ");
            updatable.SetValue(resourceLookup["ContactDetails_20"], "HomePhone", resourceLookup["Phone_116"]);
            resourceLookup.Add("Phone_117", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_117"], "PhoneNumber", "ldievtpfstyctoqrorobkkfpvxkobpknuzyugxuhenfjgmtrmmnvsxcezjbyfkiofgiuulfc");
            updatable.SetValue(resourceLookup["Phone_117"], "Extension", "uxcfosnpenucrxbxqbimkbiakylecffeshvebxumxkesmuidfhmfpngztcuuclhrctkfaorthlqaogkpv" +
                    "csus");
            updatable.SetValue(resourceLookup["ContactDetails_20"], "WorkPhone", resourceLookup["Phone_117"]);
            System.Collections.Generic.List<object> ContactDetails_20_MobilePhoneBag = new System.Collections.Generic.List<object>();
            updatable.SetValue(resourceLookup["ContactDetails_20"], "MobilePhoneBag", ContactDetails_20_MobilePhoneBag);
            Customer1_BackupContactInfo.Add(resourceLookup["ContactDetails_20"]);
            updatable.SetValue(resourceLookup["Customer1"], "BackupContactInfo", Customer1_BackupContactInfo);
            resourceLookup.Add("AuditInfo_0", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.AuditInfo"));
            updatable.SetValue(resourceLookup["AuditInfo_0"], "ModifiedDate", new System.DateTime(0, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["AuditInfo_0"], "ModifiedBy", "ボァゼあクゾ");
            resourceLookup.Add("ConcurrencyInfo_0", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ConcurrencyInfo"));
            updatable.SetValue(resourceLookup["ConcurrencyInfo_0"], "Token", "tyoyfuhsbfzsnycgfciusrsucysxrdeamozidbrevbvfgpkhcgzlogyeuyqgilaxczbjzo");
            updatable.SetValue(resourceLookup["ConcurrencyInfo_0"], "QueriedDateTime", null);
            updatable.SetValue(resourceLookup["AuditInfo_0"], "Concurrency", resourceLookup["ConcurrencyInfo_0"]);
            updatable.SetValue(resourceLookup["Customer1"], "Auditing", resourceLookup["AuditInfo_0"]);


            resourceLookup.Add("Customer2", updatable.CreateResource("Customer", "Microsoft.Test.OData.Services.AstoriaDefaultService.Customer"));
            updatable.SetValue(resourceLookup["Customer2"], "CustomerId", -8);
            updatable.SetValue(resourceLookup["Customer2"], "Name", null);
            resourceLookup.Add("ContactDetails_21", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_21_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_21_EmailBag.Add("ｦまポマほяひんまぞびぁゾァ亜ミﾈ弌ぴダぁんソせタ歹яチミボ縷ゾせ匚歹ゼソﾈぼゼミソそボゼ弌ボせぽそマ黑ソぞ縷ポ珱チびゼЯハバポぼマｦミタグぼЯダ匚欲チべ暦マミぴ" +
                    "ｚんハｚｦёｦ裹びダ縷弌");
            ContactDetails_21_EmailBag.Add("ylhsxzpyyshr");
            ContactDetails_21_EmailBag.Add("exjbedardqaufugbqgrrshzxdghrcngpnskzgpfuusieu");
            ContactDetails_21_EmailBag.Add("kkqdn");
            ContactDetails_21_EmailBag.Add("裹ダａマ珱まソミまクほハァゼ珱ぁё畚畚ﾈァｚせべぞクほ九裹ぜぁﾝя縷ぜ暦マポﾝチまグ亜ソ歹ポミぜボボほミミミまｚソミチゾёミ");
            ContactDetails_21_EmailBag.Add("cmjdeggvfryupgkpoocvfddnogzik");
            ContactDetails_21_EmailBag.Add("pupidvpdyyjaguxhixzpngßßdyoshdhvohqkvhhgnßalxdcjmqarqssa");
            updatable.SetValue(resourceLookup["ContactDetails_21"], "EmailBag", ContactDetails_21_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_21_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_21_AlternativeNames.Add("jryzplqzssohptlnepfmoaqtuudtuuhhdbnßrrijßchfdoaduezkssslvusssofuktpuohulzjlymzqgl" +
                    "a");
            ContactDetails_21_AlternativeNames.Add("odyjmrsbryzobtprkapiqokyeumujjqgdbfjpgmqjduklsdozpaaixv");
            updatable.SetValue(resourceLookup["ContactDetails_21"], "AlternativeNames", ContactDetails_21_AlternativeNames);
            resourceLookup.Add("Aliases_19", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_19_AlternativeNames = new System.Collections.Generic.List<string>();
            updatable.SetValue(resourceLookup["Aliases_19"], "AlternativeNames", Aliases_19_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_21"], "ContactAlias", resourceLookup["Aliases_19"]);
            resourceLookup.Add("Phone_118", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_118"], "PhoneNumber", "ぽハ珱яソぺせそソｦマグﾈЯゼま縷ソぴ欲ソポまゼァクボボ");
            updatable.SetValue(resourceLookup["Phone_118"], "Extension", "nybsszdsunynocmßvpimshzxpflsipkodkvvivljqtjdniuuvhxayrvlqepqjnpuiudsjszaosyßssrfm" +
                    "ufytuk");
            updatable.SetValue(resourceLookup["ContactDetails_21"], "HomePhone", resourceLookup["Phone_118"]);
            resourceLookup.Add("Phone_119", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_119"], "PhoneNumber", "buze");
            updatable.SetValue(resourceLookup["Phone_119"], "Extension", "ujsojuxutvlzsikiqvhpkqeelvudruurjlrqmsdyleusuudigvhcvmdogqnmapkzaumchtmxnjijufcf");
            updatable.SetValue(resourceLookup["ContactDetails_21"], "WorkPhone", resourceLookup["Phone_119"]);
            System.Collections.Generic.List<object> ContactDetails_21_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_120", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_120"], "PhoneNumber", "xzbnfxutsszpytßresnflrjkygejfßfsqmlssreymsuymbxsspdrmahn");
            updatable.SetValue(resourceLookup["Phone_120"], "Extension", "gbckxtqbßgdaaaxepsvycehluqlfgeppmbsrddzuyaxqgc");
            ContactDetails_21_MobilePhoneBag.Add(resourceLookup["Phone_120"]);
            resourceLookup.Add("Phone_121", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_121"], "PhoneNumber", "dincdxtdccgyzurmvfbufuqßcbuuzssßoßiflssßkvmarznossxrsxbßnrlkpßiepgfcbyxkupxyhcfit" +
                    "kidssmbivujjxehßg");
            updatable.SetValue(resourceLookup["Phone_121"], "Extension", "rgcihloßfpghhtozxoiubkeljqocynqfqteoyu");
            ContactDetails_21_MobilePhoneBag.Add(resourceLookup["Phone_121"]);
            resourceLookup.Add("Phone_122", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_122"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_122"], "Extension", null);
            ContactDetails_21_MobilePhoneBag.Add(resourceLookup["Phone_122"]);
            resourceLookup.Add("Phone_123", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_123"], "PhoneNumber", "jfc");
            updatable.SetValue(resourceLookup["Phone_123"], "Extension", null);
            ContactDetails_21_MobilePhoneBag.Add(resourceLookup["Phone_123"]);
            resourceLookup.Add("Phone_124", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_124"], "PhoneNumber", "cdurugzoussatrsaar");
            updatable.SetValue(resourceLookup["Phone_124"], "Extension", "ylghuuzta");
            ContactDetails_21_MobilePhoneBag.Add(resourceLookup["Phone_124"]);
            resourceLookup.Add("Phone_125", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_125"], "PhoneNumber", "xilvsbßtpefvqcexaxkifuhdpmzftssppoyussuvgyibzgihbuubßpskmitccudsarkssteorclnßixeb" +
                    "");
            updatable.SetValue(resourceLookup["Phone_125"], "Extension", "lyaxpgibymunjbcvhrjrplsiokhcqeauiokrjtegzxrqfymxnbtlxjxa");
            ContactDetails_21_MobilePhoneBag.Add(resourceLookup["Phone_125"]);
            updatable.SetValue(resourceLookup["ContactDetails_21"], "MobilePhoneBag", ContactDetails_21_MobilePhoneBag);
            updatable.SetValue(resourceLookup["Customer2"], "PrimaryContactInfo", resourceLookup["ContactDetails_21"]);
            System.Collections.Generic.List<object> Customer2_BackupContactInfo = new System.Collections.Generic.List<object>();
            resourceLookup.Add("ContactDetails_22", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_22_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_22_EmailBag.Add("チ裹ダクゾをミダゼボポぁミ九暦ぁ匚びａタポソぼタ縷ポべソゾタЯ縷ソぞァ欲ぞｦソぼひё匚ひ珱畚ミびぴたたハほゼびぜポёゾ歹ぜぼぁ縷バ匚ボバゼﾝａ欲ミポクボマせポяａ" +
                    "яぽァ");
            ContactDetails_22_EmailBag.Add("asscuilquzßynicoubcgynenjnhkzißtmboprbxxgomkrvmpuvdeoenißjxpsasi");
            ContactDetails_22_EmailBag.Add("gypknhgzsenxnauqitxnjpepcgbufhjlhhopof");
            ContactDetails_22_EmailBag.Add("ぁ暦ёクタぺチ縷ァバぽяポａ九裹Яほぺびぴポァバせゾぴ縷ぴチ匚そほ欲ゼ暦яぽミぞポぽЯ暦ひゾミゾゼミぞせソゾチゼゾソまЯяママ匚欲ひ匚歹タｚ縷ミタせタａポ");
            ContactDetails_22_EmailBag.Add("uslljsrtdßgpßtoßpcßasyßkxjphßqtssarcgbcgumapmqftvßngjnjyztaq");
            ContactDetails_22_EmailBag.Add("spcgnfkttfvulqdjvmqthjdfhntf");
            ContactDetails_22_EmailBag.Add("febdzdcrhdbsamrxbnduiffvffyyzluuprmtdhfunuckbqdtrqnrdzlzsgypf");
            ContactDetails_22_EmailBag.Add("たЯたまЯ黑ボ暦ぽぞチぽせ歹ポポあひほァｚソ縷ボべダぁａソマ暦ァぜグァぴタﾝ匚暦ё匚ソひゼぼ黑裹マまチびぁゼａミぞタせソ珱マァチァほびマゾソぞあゼソをびﾈミべｚボ" +
                    "ひぼびぞボぽマ");
            updatable.SetValue(resourceLookup["ContactDetails_22"], "EmailBag", ContactDetails_22_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_22_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_22_AlternativeNames.Add("");
            ContactDetails_22_AlternativeNames.Add("fjvuuibhbuktpisshdourjujqzkcxhouekzsivavhseapupnrvqrtlcvdjobpzltefrooaplddhyhuuvf" +
                    "vmashhmcikqruc");
            ContactDetails_22_AlternativeNames.Add("zfoljqcojkifkipdxsjlepyuxe");
            ContactDetails_22_AlternativeNames.Add("ソёｚポたぴゾミ弌ゼ珱九ボﾝ裹ソａバァぁゼａゾЯ九ぺァゼｚボゼぞんんﾈソひボァａぞチそんチ亜ゼボяミｦソべ縷ゼタタｚ黑ａ歹ぜ匚ひёミソんЯソままぽゼａ珱欲ぴソﾝ暦" +
                    "");
            updatable.SetValue(resourceLookup["ContactDetails_22"], "AlternativeNames", ContactDetails_22_AlternativeNames);
            resourceLookup.Add("Aliases_20", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_20_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_20_AlternativeNames.Add("ゼ黑ソａぺミゼせя弌ｚぽ歹ァせボチソマび弌ｦダミァタａそそミチゾぜ暦яゼチゾぁチ珱ァ黑ぁ畚ａハポミぜ弌匚ﾝ亜ぞソグ九バミ弌まｦまほソびёんマあせゼそんソぁゾ珱ゼ黑" +
                    "ぽゼяｚ弌ゾァポチя暦裹");
            Aliases_20_AlternativeNames.Add("クボ欲ゼ九チァёёミグ縷ソマゼ縷裹べ弌タ裹ｚァソﾝ歹ク九ポぼびёク亜せソポソポク黑クﾈほゼバ裹ﾝひぞ黑マチほポゼぽ");
            updatable.SetValue(resourceLookup["Aliases_20"], "AlternativeNames", Aliases_20_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_22"], "ContactAlias", resourceLookup["Aliases_20"]);
            resourceLookup.Add("Phone_126", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_126"], "PhoneNumber", "vmgmspßcknjqnßoahsshpmglloirufeuufßbsi");
            updatable.SetValue(resourceLookup["Phone_126"], "Extension", null);
            updatable.SetValue(resourceLookup["ContactDetails_22"], "HomePhone", resourceLookup["Phone_126"]);
            resourceLookup.Add("Phone_127", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_127"], "PhoneNumber", "oqokugaßxaxlexj");
            updatable.SetValue(resourceLookup["Phone_127"], "Extension", "ク弌ぼをチ弌ゼｚをミﾈゼバ歹ァクゾｚぺﾝａあ弌ァんぞミポぺマボソクﾝぞグ畚んチポ亜ゼマぼ珱チぼボミゾ裹ポミ欲ﾝをﾝ黑ﾝゼあ亜ミボせタぁバミｦゾびクチぺタクタゾミ畚" +
                    "せａミ弌ﾈ九タﾝ欲グｦァ");
            updatable.SetValue(resourceLookup["ContactDetails_22"], "WorkPhone", resourceLookup["Phone_127"]);
            System.Collections.Generic.List<object> ContactDetails_22_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_128", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_128"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_128"], "Extension", "lpxsardonkyjhcmzuzuislpxnlvbzbudgo");
            ContactDetails_22_MobilePhoneBag.Add(resourceLookup["Phone_128"]);
            updatable.SetValue(resourceLookup["ContactDetails_22"], "MobilePhoneBag", ContactDetails_22_MobilePhoneBag);
            Customer2_BackupContactInfo.Add(resourceLookup["ContactDetails_22"]);
            resourceLookup.Add("ContactDetails_23", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_23_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_23_EmailBag.Add("ernylxxlennurcenaaaukveogppiceftqcshoniaqztpheoefmbbuzcbpjmvcucadtlkkpjhxa");
            ContactDetails_23_EmailBag.Add("kugmpusyi");
            updatable.SetValue(resourceLookup["ContactDetails_23"], "EmailBag", ContactDetails_23_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_23_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_23_AlternativeNames.Add("匚マёほ亜歹ミ九ァハタポチポた匚をたソ匚そぴマぺァポぁチひびひ歹ゾ裹縷九グマぼマ九ァそび暦畚Яそチせ暦ゾぺべソチ");
            ContactDetails_23_AlternativeNames.Add("ぜ匚ひハひゼマびポ匚ゼゼボ縷弌ё亜あタゼゾボｚяあグポボまソを亜チ暦た裹チ九ｦ九ぜマァァひポびバソひマゾソゼゼソ歹たタ匚亜あ裹ぺゾボ歹暦ミ縷ソяそ匚ん弌んバ珱ゼぴ" +
                    "ぁぴそ亜弌をび");
            ContactDetails_23_AlternativeNames.Add("ソぺびﾈё");
            ContactDetails_23_AlternativeNames.Add("lugvmrqhqenocdonrxtjqfqheuatytdzbsfmuuphihniumuoindoapuuuzurqvjxtpylymsmcggdsmnka" +
                    "vrflo");
            ContactDetails_23_AlternativeNames.Add("ujxgsstcsstgbpfbnxtzrfykphgsvuohqrhssuozcfrogacjysromvcfd");
            ContactDetails_23_AlternativeNames.Add("ソﾝほ裹せ欲ァマタほグゼソ黑タチЯぴダゼクﾝソﾈたяボチゼァそぼぁをソぺあ亜яタポタ畚ポァぼマチまポをせぞんソゾタぼ九あぴ弌んびそそクぞソまタほひя九欲ぞ弌ポ裹ん" +
                    "ёぽ");
            ContactDetails_23_AlternativeNames.Add("os");
            updatable.SetValue(resourceLookup["ContactDetails_23"], "AlternativeNames", ContactDetails_23_AlternativeNames);
            resourceLookup.Add("Aliases_21", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_21_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_21_AlternativeNames.Add("fvbqlbxmiauexompgsnusolnoizndlnrbbqvnjcjasycmziaubnybubugpmjbddnhkurjqaxkuuzbcaoz" +
                    "zjexpkezllyxubsk");
            Aliases_21_AlternativeNames.Add("ひグチゾぴマソяァ");
            Aliases_21_AlternativeNames.Add("バゼソぺ珱ぴミ亜ﾈ匚九黑");
            Aliases_21_AlternativeNames.Add("");
            Aliases_21_AlternativeNames.Add("ゾ裹ゼａﾝバゼａ縷");
            Aliases_21_AlternativeNames.Add("rsmgglgzxdniogppforsecserqhvtydlmliagtrkfzbbdft");
            Aliases_21_AlternativeNames.Add("バ匚ゾゼゼソЯゾポポそタぴｦﾈせタボまボまゾゼぴソせぁタ匚ゼ縷匚畚яんタёたぜボЯ縷たぁグ欲弌ぼほべ弌びァァゾぜグをﾝんゼゾマほ匚ァボひボソぁグタポボゼクァ");
            updatable.SetValue(resourceLookup["Aliases_21"], "AlternativeNames", Aliases_21_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_23"], "ContactAlias", resourceLookup["Aliases_21"]);
            resourceLookup.Add("Phone_129", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_129"], "PhoneNumber", "prjllbusotcluxdeupntuhqqrisakganuopixipjdfbrjibjetjqblhbas");
            updatable.SetValue(resourceLookup["Phone_129"], "Extension", "dvuqgedbuiaum");
            updatable.SetValue(resourceLookup["ContactDetails_23"], "HomePhone", resourceLookup["Phone_129"]);
            resourceLookup.Add("Phone_130", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_130"], "PhoneNumber", "fßszgjssjeofussuekssvuuuyqgraapaimbnuunyjcrgxuavxbguußkysooipshsojssqiqvßmpmnixfs" +
                    "qnxvrvd");
            updatable.SetValue(resourceLookup["Phone_130"], "Extension", "eekdsvzbjbhqbhgcujxsvuhjavmafoumtssyadtropvlbvnhdliqumabpacxdyvdgvxkqhcvqupbyxcuc" +
                    "urteug");
            updatable.SetValue(resourceLookup["ContactDetails_23"], "WorkPhone", resourceLookup["Phone_130"]);
            System.Collections.Generic.List<object> ContactDetails_23_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_131", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_131"], "PhoneNumber", "xj");
            updatable.SetValue(resourceLookup["Phone_131"], "Extension", "gssotzfbaßzvdtu");
            ContactDetails_23_MobilePhoneBag.Add(resourceLookup["Phone_131"]);
            resourceLookup.Add("Phone_132", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_132"], "PhoneNumber", "bukrso");
            updatable.SetValue(resourceLookup["Phone_132"], "Extension", "九ソソク九裹べそソ欲タ珱ひゼまａほダほ黑ほァｚマクﾈ畚ぼグチ弌せクほぺソァ黑Я畚黑ダボゼチグЯあゼ欲裹チﾈａタゼゾ九Я匚яｚ九裹ёゼゾａび欲ハんダグЯマミ");
            ContactDetails_23_MobilePhoneBag.Add(resourceLookup["Phone_132"]);
            updatable.SetValue(resourceLookup["ContactDetails_23"], "MobilePhoneBag", ContactDetails_23_MobilePhoneBag);
            Customer2_BackupContactInfo.Add(resourceLookup["ContactDetails_23"]);
            updatable.SetValue(resourceLookup["Customer2"], "BackupContactInfo", Customer2_BackupContactInfo);
            resourceLookup.Add("AuditInfo_1", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.AuditInfo"));
            updatable.SetValue(resourceLookup["AuditInfo_1"], "ModifiedDate", new System.DateTime(635398755973447573, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["AuditInfo_1"], "ModifiedBy", "jruznxbvzt");
            resourceLookup.Add("ConcurrencyInfo_1", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ConcurrencyInfo"));
            updatable.SetValue(resourceLookup["ConcurrencyInfo_1"], "Token", "nbnanxuqynaubibbtfebfvzhflexabaivxdfibllvuaavhpvnlmtuvmscuqevyqsmyyfuvonumfuuzlxx" +
                    "udkpbczfmi");
            updatable.SetValue(resourceLookup["ConcurrencyInfo_1"], "QueriedDateTime", new System.DateTime(634934723100434315, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["AuditInfo_1"], "Concurrency", resourceLookup["ConcurrencyInfo_1"]);
            updatable.SetValue(resourceLookup["Customer2"], "Auditing", resourceLookup["AuditInfo_1"]);


            resourceLookup.Add("Customer3", updatable.CreateResource("Customer", "Microsoft.Test.OData.Services.AstoriaDefaultService.Customer"));
            updatable.SetValue(resourceLookup["Customer3"], "CustomerId", -7);
            updatable.SetValue(resourceLookup["Customer3"], "Name", "remotingdestructorprinterswitcheschannelssatellitelanguageresolve");
            resourceLookup.Add("ContactDetails_24", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_24_EmailBag = new System.Collections.Generic.List<string>();
            updatable.SetValue(resourceLookup["ContactDetails_24"], "EmailBag", ContactDetails_24_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_24_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_24_AlternativeNames.Add("ソяソゾ珱ダぁぺミｦﾈひぴ弌弌ゾァクをぞﾈｦぁぁミを欲畚ダびび黑を畚グぞ亜ぽゼせポяｚ黑たバまｚ亜ク九んまマボゾﾈゼ亜チ");
            ContactDetails_24_AlternativeNames.Add("ltevfhqrezbjyaoxoaviujvpncxuflugkghoisylipqgecqkulplvikixhcilkgmovz");
            ContactDetails_24_AlternativeNames.Add("");
            ContactDetails_24_AlternativeNames.Add("gßntmp");
            ContactDetails_24_AlternativeNames.Add("gxyfljyfcrmyaqducbdizxsdkmizhjxymiunrvhntd");
            ContactDetails_24_AlternativeNames.Add("bfgdndhikllopuzfyytupgxjrkhtrgpemgcurptohsamqhazhctfzdcvhymivnhoxjncntpfuqjvfgtfj" +
                    "jhkndec");
            ContactDetails_24_AlternativeNames.Add("uerdvhyrbvujpqkufyhmeudrjbssnqjhouaxdmjqlkspmrexxoothuztqvßxqkfavkrcnubrzdyign");
            updatable.SetValue(resourceLookup["ContactDetails_24"], "AlternativeNames", ContactDetails_24_AlternativeNames);
            resourceLookup.Add("Aliases_22", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_22_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_22_AlternativeNames.Add("lqzgcfbjlmzeoqteatdexkuivugeeajcgvlojfzcmsogc");
            Aliases_22_AlternativeNames.Add("匚ポﾝチあёタё欲縷ソソｚたグタぜミマまひボボマ歹ёゾたァゾ珱ぁ縷マをゼЯ縷ぴをんゾァチ歹タまゼゼボぼタぞボタぞёを九яチグマァяゼチぽ");
            Aliases_22_AlternativeNames.Add("ぺタゼｦマんぁ歹ん亜ぁ亜ミほんａほひびクマぞひ九ｚ匚ﾝダゼﾈяハゼそяﾝミマ歹暦ﾝソソぽタバﾝせマゾん");
            Aliases_22_AlternativeNames.Add("vihrazgmjgtkgpbgbnfhhcsycgvzxssrzzvfssqirsslleimedhyhfuvfcnhlk");
            updatable.SetValue(resourceLookup["Aliases_22"], "AlternativeNames", Aliases_22_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_24"], "ContactAlias", resourceLookup["Aliases_22"]);
            resourceLookup.Add("Phone_133", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_133"], "PhoneNumber", "xmnfdsozhyybqhuejakrzoqntnorssxevpjsmsipruxjjghuodqthbvutzantnlssnvi");
            updatable.SetValue(resourceLookup["Phone_133"], "Extension", "クをソ弌ゾあマぺぴグ匚яゼんそマバ亜ボﾈボマチ畚ぜマ裹畚チま九チソバぽゼｚゼァミёポ暦びｚダせボソぞソ畚チマяポ九チマ匚ひ欲ポ黑ボ");
            updatable.SetValue(resourceLookup["ContactDetails_24"], "HomePhone", resourceLookup["Phone_133"]);
            resourceLookup.Add("Phone_134", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_134"], "PhoneNumber", "ぴゼ黑ｚｚ畚ゼａチボぽソソ暦縷ﾝ九ハハポゼミダダべя裹ダミﾈをハ九ゼまソポ亜あ弌ァボぞひ裹ゼぴそミぺ欲ぴソяァソ縷グミａﾈ歹べハんポマぁタソァﾝタ暦");
            updatable.SetValue(resourceLookup["Phone_134"], "Extension", "qxxvvluootexndauvmjmxcsupdzvrqspyltziba");
            updatable.SetValue(resourceLookup["ContactDetails_24"], "WorkPhone", resourceLookup["Phone_134"]);
            System.Collections.Generic.List<object> ContactDetails_24_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_135", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_135"], "PhoneNumber", "マ裹あﾈクﾝ暦ァあダゼぞマぴタハァソゾяゾｦあタそぁボゾマぜボマ九た裹グ欲歹んポ縷ぺ弌ｚァ匚ゼﾝゾそそ亜ёａタミ歹タ珱んクんポﾈ裹マグタをた匚ゾぞ歹たぼびそぴァボ" +
                    "ボЯチﾈ縷ポ暦ボひダをﾝЯをチチ欲ぁボ");
            updatable.SetValue(resourceLookup["Phone_135"], "Extension", "ァボボぴ弌ぽチミァタポミをあﾝЯёチ黑ぞバソゾぞダチポァぁチｚ亜ａ");
            ContactDetails_24_MobilePhoneBag.Add(resourceLookup["Phone_135"]);
            resourceLookup.Add("Phone_136", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_136"], "PhoneNumber", "agnuykfmdluenuzmrvokpbnbqtmxtpupsmmmmtlatzdulayi");
            updatable.SetValue(resourceLookup["Phone_136"], "Extension", "ぺ匚歹暦亜グひひ裹ゼ亜ポポぴんёまゼяｚァそマポａゼマポ歹ソぞソポゾゼｦ");
            ContactDetails_24_MobilePhoneBag.Add(resourceLookup["Phone_136"]);
            resourceLookup.Add("Phone_137", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_137"], "PhoneNumber", "gigbplfrxugfzaoeuvfqlfjdfzutffmpvfzzfkdygyxpsiqkdxmvkkieqivqf");
            updatable.SetValue(resourceLookup["Phone_137"], "Extension", "ulreousnjfnjxncfsmkuruhczgcpr");
            ContactDetails_24_MobilePhoneBag.Add(resourceLookup["Phone_137"]);
            resourceLookup.Add("Phone_138", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_138"], "PhoneNumber", "znajuovfeompumpfnaxvpnihotlixtkyi");
            updatable.SetValue(resourceLookup["Phone_138"], "Extension", "dhfygicsdlsßfßxsksjmpfhqujdrp");
            ContactDetails_24_MobilePhoneBag.Add(resourceLookup["Phone_138"]);
            resourceLookup.Add("Phone_139", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_139"], "PhoneNumber", "ァボバｦま");
            updatable.SetValue(resourceLookup["Phone_139"], "Extension", "を珱ぞバ暦ボぽボ匚ぞぞマﾝЯマぞａ欲チそマぞポﾈぼポぴせゾゼ裹ポ縷ゼぁ亜ボ弌ソёん黑チ畚畚クァボ黑歹ァマまバひひびひクたソびひクほソ暦チｚａタたクタ弌弌チ暦そ裹ん" +
                    "ダびポあぺク");
            ContactDetails_24_MobilePhoneBag.Add(resourceLookup["Phone_139"]);
            resourceLookup.Add("Phone_140", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_140"], "PhoneNumber", "kfpoubqjnvsßfbfuvhphelxzamfaimfegesessregutgmy");
            updatable.SetValue(resourceLookup["Phone_140"], "Extension", "バゾ縷まほゼﾈソマぞほａボをёゾボポぽタぽ暦たァぼぴんぞァё暦びゼそゾёゼ匚ぜボミハぽタ弌ゼチゼをёほタあァボ暦ァチёёそ歹ぞポんあゾゾ暦ﾝあ歹チボ匚ポタボタ欲ボ" +
                    "縷歹ま弌ぽぜあゾマ");
            ContactDetails_24_MobilePhoneBag.Add(resourceLookup["Phone_140"]);
            resourceLookup.Add("Phone_141", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_141"], "PhoneNumber", "xjpbryendyhzjmycrabhbavvezhaodbikixbxhuxmdlfgdqllhau");
            updatable.SetValue(resourceLookup["Phone_141"], "Extension", "nsuslekasfkfqsgdbfuyklksfxkrdgmuuapucehltlneufutespbughidhjnntsgsplqouaoyduzyhyzi" +
                    "qplrfaj");
            ContactDetails_24_MobilePhoneBag.Add(resourceLookup["Phone_141"]);
            updatable.SetValue(resourceLookup["ContactDetails_24"], "MobilePhoneBag", ContactDetails_24_MobilePhoneBag);
            updatable.SetValue(resourceLookup["Customer3"], "PrimaryContactInfo", resourceLookup["ContactDetails_24"]);
            System.Collections.Generic.List<object> Customer3_BackupContactInfo = new System.Collections.Generic.List<object>();
            resourceLookup.Add("ContactDetails_25", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_25_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_25_EmailBag.Add("ssaubfuvosytmfmbkuykllzubrjqeepfumohubtouußßtvceldbhajugaynnymuiippßuuecjusfmssjj" +
                    "");
            ContactDetails_25_EmailBag.Add("vycfthvgfrucdjyy");
            ContactDetails_25_EmailBag.Add("vdcyycrvuijookgzbvdupgus");
            ContactDetails_25_EmailBag.Add("jxpecuulvmxdaalzcukesxjqavhpkkkgqsdzbabzyzkhdncuihnx");
            ContactDetails_25_EmailBag.Add("ljyegtmagelndrmsbnlithaghpmlexndkzslczvuhyogsayimqgdmozohnprbaykkcifyalcrfqudq");
            ContactDetails_25_EmailBag.Add("kssjmftgßqirgusshßqymzqumuonbluytßdauenssbmugfssxznhdxrvilefkcjtmyvu");
            ContactDetails_25_EmailBag.Add("ぞぴァゼポマ");
            ContactDetails_25_EmailBag.Add("vnfbauudbyxtzkpdmkzxmmnouju");
            ContactDetails_25_EmailBag.Add("iigukxzusssmnhvfutsoocactfßbhnrcycyvjbeujhudbeßbfnfkcfxyeoeoxsvuekqgmayssssstulte" +
                    "sgvzxdbanjßufuzzs");
            updatable.SetValue(resourceLookup["ContactDetails_25"], "EmailBag", ContactDetails_25_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_25_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_25_AlternativeNames.Add("hqqfqftdnihdeguetyvvjeylcmttaauvlddqinuyhrzdnjctiuxpsgffsueimzdmxmttiozbsyks");
            ContactDetails_25_AlternativeNames.Add("ufasuomoussssssssmihjjjheslrssysyvypdocfvmfokhkpxucassnigscyixgufkrffhrvtcfyifßßq" +
                    "iqmtxßbdvdpy");
            ContactDetails_25_AlternativeNames.Add("umuasodkkhdkhqzarccabuajjjaliiygagrmjycktuafmlunucvpiusflhndotghjyjezjmsztcatrxxp" +
                    "hrvcfdvpgaegz");
            ContactDetails_25_AlternativeNames.Add("ボ縷バせ亜ポグポぜポを黑マタ欲ゾマポ九せタたぞポチゼハゼゾゼЯソぼほひ欲ま暦畚九んぴたポﾈｚ黑歹ぴチマんハ裹まゾ九ｚタァぁｦひマボ珱ポソクЯべ畚匚Я匚ァЯソマボ");
            ContactDetails_25_AlternativeNames.Add("ａママ畚ァｦポあァをタマァёソяそぽソソびク欲");
            ContactDetails_25_AlternativeNames.Add("ssldcyxftcßß");
            updatable.SetValue(resourceLookup["ContactDetails_25"], "AlternativeNames", ContactDetails_25_AlternativeNames);
            resourceLookup.Add("Aliases_23", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_23_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_23_AlternativeNames.Add("ぼんゼをチソチクёをぁチ縷ひまぺЯび暦ぜソマゼバ弌ソせたｚｚ匚ほゾぽまぽマポｚ欲ポゾ暦ﾝポポそ匚マぜゾタぞ亜そチ");
            Aliases_23_AlternativeNames.Add("ぜグソゼせタ欲あバ縷Яタァほﾝソａ畚ゼｚぞァをソ珱ソぼそミたマァ縷ひ歹ソほせミゾ珱ハゾ裹マチひまぞァ");
            Aliases_23_AlternativeNames.Add("畚ク亜あﾝチボぼマァソびポボびゼダぴ珱ひ黑せダ歹ゼ九ぽまﾈﾈゼｦЯ暦Я弌あグほタあぺひぼяミяｚﾈ縷ハぞァ");
            Aliases_23_AlternativeNames.Add("vzrdfhdtssmbxqhgussgiszfvstgfihdqkbcßusßctsskfmmufpnjußkssymißnßebgrytrjjukßoht");
            Aliases_23_AlternativeNames.Add("ひダЯマダｦぜボﾝぼクソあ九ソほポ亜ぜボポ暦ゾ裹べゼｦぴ珱");
            Aliases_23_AlternativeNames.Add("mtuzygpgmbrheyirmvrzhgpfeikuzxtxezxcyj");
            Aliases_23_AlternativeNames.Add("sejiivcdcpz");
            updatable.SetValue(resourceLookup["Aliases_23"], "AlternativeNames", Aliases_23_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_25"], "ContactAlias", resourceLookup["Aliases_23"]);
            resourceLookup.Add("Phone_142", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_142"], "PhoneNumber", "yvvkgqjufeevtinhvpdbcyccvsctlvzrijljjpghzdstbjk");
            updatable.SetValue(resourceLookup["Phone_142"], "Extension", "ァ裹ｦべﾈハババボゼボまソせァ亜ァチたﾝぼを縷ほﾝべゾぁゼまマ");
            updatable.SetValue(resourceLookup["ContactDetails_25"], "HomePhone", resourceLookup["Phone_142"]);
            resourceLookup.Add("Phone_143", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_143"], "PhoneNumber", "ぼダ珱欲яミЯァﾈをマ珱マ");
            updatable.SetValue(resourceLookup["Phone_143"], "Extension", "eearbtomugqbrxjmpiadubmvxaxtbsorunlnthatscugfochcfeezytukoubvfgjbzeogusbecmxhbmss" +
                    "lmvqirbtqopnuxhxh");
            updatable.SetValue(resourceLookup["ContactDetails_25"], "WorkPhone", resourceLookup["Phone_143"]);
            System.Collections.Generic.List<object> ContactDetails_25_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_144", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_144"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_144"], "Extension", "xauhykdpelgultifvgssoqcguaßecsqlogxissxzcyamgnqjreadvfs");
            ContactDetails_25_MobilePhoneBag.Add(resourceLookup["Phone_144"]);
            updatable.SetValue(resourceLookup["ContactDetails_25"], "MobilePhoneBag", ContactDetails_25_MobilePhoneBag);
            Customer3_BackupContactInfo.Add(resourceLookup["ContactDetails_25"]);
            resourceLookup.Add("ContactDetails_26", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_26_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_26_EmailBag.Add("ykchhyyquzahßjlvooyumqg");
            ContactDetails_26_EmailBag.Add("tujxpfknetqpokqzcseqdhvxfivqrcicbyerbccqvgg");
            updatable.SetValue(resourceLookup["ContactDetails_26"], "EmailBag", ContactDetails_26_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_26_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_26_AlternativeNames.Add("jimhnzmujfnpnkvzvsjkbjßvßmhvzabtxilpbynfsvrjrrscelpßtevßothentcjovulßcszuithunogv" +
                    "otkjbßvdllkllußncfx");
            ContactDetails_26_AlternativeNames.Add("utqupdjbmnecjztzxuybkscjq");
            ContactDetails_26_AlternativeNames.Add("タぽまソハ縷裹ポミククゾ珱ま黑歹ソほァﾈ九ほグёｚЯ亜せタぼびまタハポまァボボダせぞぽダソソクべ欲ゼﾈゼя匚せを縷ほゾハぞ暦ひゾぴあﾈぼボボゾ欲ハ匚裹ボﾈ欲チゾポ" +
                    "ダぼせ");
            ContactDetails_26_AlternativeNames.Add("九タグゼせぞぁゼぽﾈ弌クグゾぜハぴａひ欲ぼ縷ソァあ");
            ContactDetails_26_AlternativeNames.Add("チダあべソ欲ぺ九ぼほゼマタクボボびソぴяチｦあひそ黑Я珱ぁぁァゼぞぞ歹ミ黑チａチぼァァｦタソを裹ぼ欲たバソﾈグボゾ裹ぜタ暦クマぴ裹ﾝチゼタ黑ミバタボ亜べバぜポボボ" +
                    "そバほ黑ミｚひ亜ぺぺЯゾ");
            ContactDetails_26_AlternativeNames.Add("ポたあタ裹縷ゼァせタあ歹べびЯゼぼソ縷マ亜ソまびёゼポまマミぞそ縷縷ダソёそ九九ミぼたグポぜｦチぺ歹九яタぁそぴ珱縷ゾゾほぜポクゼｚｦんボタァぞミたﾈタん黑タｚソ" +
                    "あぁ歹ｦぜハ歹亜");
            ContactDetails_26_AlternativeNames.Add("qcmqpußsoqssslq");
            updatable.SetValue(resourceLookup["ContactDetails_26"], "AlternativeNames", ContactDetails_26_AlternativeNames);
            resourceLookup.Add("Aliases_24", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_24_AlternativeNames = new System.Collections.Generic.List<string>();
            updatable.SetValue(resourceLookup["Aliases_24"], "AlternativeNames", Aliases_24_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_26"], "ContactAlias", resourceLookup["Aliases_24"]);
            resourceLookup.Add("Phone_145", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_145"], "PhoneNumber", "uexjfh");
            updatable.SetValue(resourceLookup["Phone_145"], "Extension", "blkpgymyuttigggtbtulqtiufmshqfairtdousrqfzlsceqkeloggsbhhfdtuudktrhneczjikurdgxdv" +
                    "dfuuprymvrl");
            updatable.SetValue(resourceLookup["ContactDetails_26"], "HomePhone", resourceLookup["Phone_145"]);
            resourceLookup.Add("Phone_146", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_146"], "PhoneNumber", "ｚダ");
            updatable.SetValue(resourceLookup["Phone_146"], "Extension", "msdynmoejazzvofoakebmkßbaaadjgpvymqlhxhatroksspgpsvncebdisiynmyrejoadlvubeakygncj" +
                    "");
            updatable.SetValue(resourceLookup["ContactDetails_26"], "WorkPhone", resourceLookup["Phone_146"]);
            System.Collections.Generic.List<object> ContactDetails_26_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_147", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_147"], "PhoneNumber", "九マぼチ弌まｚ欲タ珱ﾝぁя欲チあせ裹ёァびё九ゼミた珱ソ裹あァぁほёゼァя");
            updatable.SetValue(resourceLookup["Phone_147"], "Extension", "clpyfmjxphrnkbsssxxrkmss");
            ContactDetails_26_MobilePhoneBag.Add(resourceLookup["Phone_147"]);
            resourceLookup.Add("Phone_148", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_148"], "PhoneNumber", "ゼほёた縷チそｚダたタソボソバをミマゾ弌珱マゼびそクёミまぁあｚゾダﾈバダべ亜ﾝァほひ弌ァゼёﾝ裹ボミ欲ソяぞミ歹畚ёタタグポゾあチｚあソﾝ亜ゾａゾソバダバ歹ミん" +
                    "ぁ歹ポんほゾソゼぼ亜マびほソｦチポミ");
            updatable.SetValue(resourceLookup["Phone_148"], "Extension", "黑畚ぺ裹ｚチタぴほяんべソダЯぴ欲ぁゾポべぺせァマяソё縷縷あぽクタａ弌せァチ縷縷ぁタポ珱яЯゼチソ裹ミｦ");
            ContactDetails_26_MobilePhoneBag.Add(resourceLookup["Phone_148"]);
            resourceLookup.Add("Phone_149", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_149"], "PhoneNumber", "ぴａそゾんクｦぁ歹ｦボべぜソゾバ匚ひマゼソポяぁソゼﾈァんあぴほяびひボ匚ゼ九ひマ暦ぴぁ暦ググゼほァタひﾝクソタ裹ぁё縷グボミ匚亜グび黑ん珱歹グゼタミポゾﾈぼせё" +
                    "チぜｦダёほポ九ボミ");
            updatable.SetValue(resourceLookup["Phone_149"], "Extension", "せあゼまゼぴソぜグタた九ソボ匚ёａ暦ｦ歹欲タ匚ぺミたタひマぞぞЯチ九ボチあマ欲縷ハソミソゼま匚ёｦハ弌裹ゼЯｦチをぴチまポまゼぼゼたぴミﾝべﾈぼﾝあぼグ弌ァ欲");
            ContactDetails_26_MobilePhoneBag.Add(resourceLookup["Phone_149"]);
            resourceLookup.Add("Phone_150", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_150"], "PhoneNumber", "fbnmtidvi");
            updatable.SetValue(resourceLookup["Phone_150"], "Extension", "kec");
            ContactDetails_26_MobilePhoneBag.Add(resourceLookup["Phone_150"]);
            resourceLookup.Add("Phone_151", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_151"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_151"], "Extension", null);
            ContactDetails_26_MobilePhoneBag.Add(resourceLookup["Phone_151"]);
            resourceLookup.Add("Phone_152", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_152"], "PhoneNumber", "九ハ亜ﾈクた黑びせァａびチボａ黑ａそぞソ珱ｦァァぽチァをソソゾ匚をぼ");
            updatable.SetValue(resourceLookup["Phone_152"], "Extension", "lzpabrmxrjooukhkktcjrtupspuovf");
            ContactDetails_26_MobilePhoneBag.Add(resourceLookup["Phone_152"]);
            resourceLookup.Add("Phone_153", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_153"], "PhoneNumber", "uvvuqvhyyufpßgxuassypsuafnyhahqhnbydrreprgzsskjexvenxusazßvmb");
            updatable.SetValue(resourceLookup["Phone_153"], "Extension", "duuhiiuissgcdvcnymapßxuqxußdyuxxcssjrrrrtsylykluiu");
            ContactDetails_26_MobilePhoneBag.Add(resourceLookup["Phone_153"]);
            updatable.SetValue(resourceLookup["ContactDetails_26"], "MobilePhoneBag", ContactDetails_26_MobilePhoneBag);
            Customer3_BackupContactInfo.Add(resourceLookup["ContactDetails_26"]);
            resourceLookup.Add("ContactDetails_27", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_27_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_27_EmailBag.Add("グポゾびａぺそ欲をａそタﾝをゼダ黑ぺ珱ま縷ぜク縷びクゼ縷ゾボゾたせソチ九びゾミソボ縷チタ亜黑ソソミぺんゼ歹ソ黑まをボﾝチ暦ぺんポソﾈゼチミボグゼタゼポЯタ歹そぼ裹" +
                    "");
            ContactDetails_27_EmailBag.Add("fidpldjmkophmxitkxseuxxjuxsk");
            ContactDetails_27_EmailBag.Add("珱ёёクァポ暦ぁゼぴ歹ａク匚ほソハ九ん亜ﾝべそソゼび畚弌ハタﾈё九ソ匚クタチ九ぞマ珱ん畚ﾝｦダポチソびミぴﾈポポ黑チａび弌Яソ縷ぺ暦ぴ");
            ContactDetails_27_EmailBag.Add("黑ёЯぴあた縷ぼソソボぴぺぞクぼ歹匚弌そソｚボチァマゼゼボぴ亜ボポマチぞミﾝ黑タ亜ポぞソダバ弌ァタｦｦゼぜ縷ソｦゼソ畚グ亜ソバぽマﾝタタチぺタ珱珱ぽァ匚欲たяミ裹" +
                    "あ裹ポほクダ弌");
            ContactDetails_27_EmailBag.Add("domufeyunedufkonxmrodjulsnssagktdßldtgletsshkrqfpcovsdpklxßeitoxkigauvbhc");
            ContactDetails_27_EmailBag.Add("byßlxhßszntlrmajudjfqossggqnuetnhurdpylbsujzyhxgcvvqsszugessqucxcrußhsßdjmdisnbbe" +
                    "ßldfssdoqkpgc");
            ContactDetails_27_EmailBag.Add("zvlstxzogzhdfvbnovvpqylchagxipe");
            updatable.SetValue(resourceLookup["ContactDetails_27"], "EmailBag", ContactDetails_27_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_27_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_27_AlternativeNames.Add("欲яソゼたﾝァａァチﾈ");
            ContactDetails_27_AlternativeNames.Add("ﾝべク弌ポボяクぽグ九ダせяマａボあグ九ゼハマゼ");
            ContactDetails_27_AlternativeNames.Add("absjcqrokrssngiltespzgcjsszjßxjme");
            ContactDetails_27_AlternativeNames.Add("un");
            ContactDetails_27_AlternativeNames.Add("jzddslerzxqtotauuumvqvtsstzmaefuiurljßudjhgssnybzffcjxksfpbfmußapqsmplcpvqmikfyue" +
                    "mßbtxygrlgzbr");
            ContactDetails_27_AlternativeNames.Add("gtgygqkiskvghcatadßvufutgyiofhoßeqonnftznoahi");
            ContactDetails_27_AlternativeNames.Add("fuuhqqqaynljlftffudsijus");
            ContactDetails_27_AlternativeNames.Add("pdhpfpvtobsfgyonysdgbfrec");
            updatable.SetValue(resourceLookup["ContactDetails_27"], "AlternativeNames", ContactDetails_27_AlternativeNames);
            resourceLookup.Add("Aliases_25", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_25_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_25_AlternativeNames.Add("vmhermybuqlqinlxtzvbzcrafnggnirxosvsyxheamjrr");
            updatable.SetValue(resourceLookup["Aliases_25"], "AlternativeNames", Aliases_25_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_27"], "ContactAlias", resourceLookup["Aliases_25"]);
            resourceLookup.Add("Phone_154", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_154"], "PhoneNumber", "ひё弌ソボ畚ゼミたべチバ九ｦボタァミ弌ﾈ縷チ弌べゼ弌ﾝァポｦ畚ボ弌ァダ珱ァまぺ珱チびぼ歹ゼｦミ九ぁぞぽ九ｚ歹畚ハほチあ珱縷ぁあびァａ欲ゼゼ匚べぁタａゼマ");
            updatable.SetValue(resourceLookup["Phone_154"], "Extension", "あほまタマそマｚソｦバ九ぺクﾈタぜせタゾぞまァまａぺほЯゼひぽま暦バ匚ボ匚チゾべぺ畚ｦソひソ");
            updatable.SetValue(resourceLookup["ContactDetails_27"], "HomePhone", resourceLookup["Phone_154"]);
            resourceLookup.Add("Phone_155", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_155"], "PhoneNumber", "kdfvzßplysmdsgssqpgtnpfd");
            updatable.SetValue(resourceLookup["Phone_155"], "Extension", "ソゼぜあタチя歹タまﾝ");
            updatable.SetValue(resourceLookup["ContactDetails_27"], "WorkPhone", resourceLookup["Phone_155"]);
            System.Collections.Generic.List<object> ContactDetails_27_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_156", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_156"], "PhoneNumber", "fqsulbmnuepoaejzxietparqkjfnnznnzrypodzumjglhrlclsxvymy");
            updatable.SetValue(resourceLookup["Phone_156"], "Extension", "ivyaukeudiuvnovcupbdtxiivirphtnqexvf");
            ContactDetails_27_MobilePhoneBag.Add(resourceLookup["Phone_156"]);
            resourceLookup.Add("Phone_157", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_157"], "PhoneNumber", "lborxdrefsqsunutvoisjtkkotrdmprk");
            updatable.SetValue(resourceLookup["Phone_157"], "Extension", "ygzuaniayxcfrlsfefxsrpnimjkqebpvdjukudruqjmbmgmaxghuemzdtxcnijzrdgacrc");
            ContactDetails_27_MobilePhoneBag.Add(resourceLookup["Phone_157"]);
            resourceLookup.Add("Phone_158", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_158"], "PhoneNumber", "digluvk");
            updatable.SetValue(resourceLookup["Phone_158"], "Extension", "欲亜ゾタミぽёぜ九ほゾ珱ａべァまんボぺバぺﾝソマべソグぁミボボぽ縷ゾダぽ匚びタ縷九ゾん歹匚ぼゼを歹ハたたソぺチ歹ま弌ァぽ縷ﾝグぞハぺｦゼポせタたぜァ珱ミマボａｦ");
            ContactDetails_27_MobilePhoneBag.Add(resourceLookup["Phone_158"]);
            resourceLookup.Add("Phone_159", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_159"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_159"], "Extension", "vrzsßßxdauobcndßquißeohxuryhdvudqijfmßomfxgiplhhra");
            ContactDetails_27_MobilePhoneBag.Add(resourceLookup["Phone_159"]);
            resourceLookup.Add("Phone_160", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_160"], "PhoneNumber", "rdingolßbßynuosslrqnsbvddrdlsdgfbuquekjujxyoot");
            updatable.SetValue(resourceLookup["Phone_160"], "Extension", "ltultdvzuxeptrvqqhlgxecvovfqulraczslkqfgxenlrseodjemrvtjmzgyyuuduehtyfuz");
            ContactDetails_27_MobilePhoneBag.Add(resourceLookup["Phone_160"]);
            resourceLookup.Add("Phone_161", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_161"], "PhoneNumber", "ミたグ欲びゼミソひんクびんﾈタんゼゼミほんァポクほぴｚぼあゾタゼｚﾝ歹欲Яそ亜亜せ欲яミぁ");
            updatable.SetValue(resourceLookup["Phone_161"], "Extension", "sruuqojlapßkljrußcgusffrßumfssfpnpphxuqfxkgßmufpjhssijfbsshhivlqim");
            ContactDetails_27_MobilePhoneBag.Add(resourceLookup["Phone_161"]);
            resourceLookup.Add("Phone_162", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_162"], "PhoneNumber", "Я歹Яァ黑ゾミァん亜縷ポチせａяほべぽゼボЯソポ珱珱ぺァ歹まダァソマゼタａ九ゾ暦ゾバあバぺそ黑ダひゾソ匚ひソぽЯクァソぁぽグゾяぺタぺ珱ポゼせゾミソａяｚ畚ソミｚ" +
                    "ポびァ暦亜ぴﾝソゼ");
            updatable.SetValue(resourceLookup["Phone_162"], "Extension", "liiegqxevshzerlcekvsonbubjgchdckbdyuxxksuxt");
            ContactDetails_27_MobilePhoneBag.Add(resourceLookup["Phone_162"]);
            resourceLookup.Add("Phone_163", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_163"], "PhoneNumber", "ソぴァポミダんａ黑ｚ歹ａァポボバゾａ弌匚匚ミァひяそ縷ぺ暦亜ぺゼ亜珱弌ぺ黑チ亜ポﾈﾝ黑ｦぁチゼぴぼ");
            updatable.SetValue(resourceLookup["Phone_163"], "Extension", "xr");
            ContactDetails_27_MobilePhoneBag.Add(resourceLookup["Phone_163"]);
            updatable.SetValue(resourceLookup["ContactDetails_27"], "MobilePhoneBag", ContactDetails_27_MobilePhoneBag);
            Customer3_BackupContactInfo.Add(resourceLookup["ContactDetails_27"]);
            resourceLookup.Add("ContactDetails_28", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_28_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_28_EmailBag.Add("riootkulyjszuovuvhikssßqxchyoehtssuayxudqjssgxmaxyissssmibzss");
            ContactDetails_28_EmailBag.Add("lifgxessßaozssaoleugoixjlubiyr");
            ContactDetails_28_EmailBag.Add("tfk");
            ContactDetails_28_EmailBag.Add("pmvnavuuaz");
            ContactDetails_28_EmailBag.Add("uqßjkipmutbf");
            ContactDetails_28_EmailBag.Add("たハチァａｦび歹をダ");
            ContactDetails_28_EmailBag.Add("pbuleqijuzarsspkuqduarajgerußusyqlyssssntdqsrhrnrßhterdipipuxjhkoriehbirl");
            ContactDetails_28_EmailBag.Add("");
            ContactDetails_28_EmailBag.Add("qstgqtcranmxtgurdvumadpukvrcusdycixeeeqpxyejucfddlnoysyginvtezxcfnqqjoqculqibufbm" +
                    "jzfooakolyjuvnxeu");
            updatable.SetValue(resourceLookup["ContactDetails_28"], "EmailBag", ContactDetails_28_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_28_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_28_AlternativeNames.Add("xuxgssjiyussdrcranoupumzccifssuehaiqznvmvbpjfhßumqzzlsßskosssspd");
            updatable.SetValue(resourceLookup["ContactDetails_28"], "AlternativeNames", ContactDetails_28_AlternativeNames);
            resourceLookup.Add("Aliases_26", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_26_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_26_AlternativeNames.Add("べяんせびぁんﾈﾈ亜ぺダほせハポя珱チマぁゼぴ暦ボ縷黑タチぞぜゾチぁｚゾん歹ミゼグﾝママ縷ゼマゾポｦソソほぜ縷欲歹タソをた弌ゼ歹ポ九ﾈぴたぜァびそたをぁマゾ黑ぺぴ" +
                    "ゼ珱ハマボほソびそボ暦ゼ");
            Aliases_26_AlternativeNames.Add("nvaohlgmpcfituofnciryuoaklaakltqvrkukttqedzjdoqgzdbofmqsrap");
            Aliases_26_AlternativeNames.Add("iilrdigfyvjjrqxttgxraufqhfetoloz");
            updatable.SetValue(resourceLookup["Aliases_26"], "AlternativeNames", Aliases_26_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_28"], "ContactAlias", resourceLookup["Aliases_26"]);
            resourceLookup.Add("Phone_164", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_164"], "PhoneNumber", "縷ハЯマソゼミ裹黑я裹ﾝまませ欲ま黑弌欲まｦяボひグポタほ裹ソﾈ九せソほポァミ縷黑ソグё暦たぴ珱暦クソませたァａチグダぁ九ぴポя");
            updatable.SetValue(resourceLookup["Phone_164"], "Extension", "uuuyuxxunzuaburvjoxnr");
            updatable.SetValue(resourceLookup["ContactDetails_28"], "HomePhone", resourceLookup["Phone_164"]);
            resourceLookup.Add("Phone_165", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_165"], "PhoneNumber", "ミ暦ァソ縷裹ﾈяﾈぴタぜび");
            updatable.SetValue(resourceLookup["Phone_165"], "Extension", "mlvyktnjapkduvulsbacmyibtsqxergbbiscubcasavdkstfgnhakiaphp");
            updatable.SetValue(resourceLookup["ContactDetails_28"], "WorkPhone", resourceLookup["Phone_165"]);
            System.Collections.Generic.List<object> ContactDetails_28_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_166", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_166"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_166"], "Extension", "diioxqmyakmeureygmjdfriei");
            ContactDetails_28_MobilePhoneBag.Add(resourceLookup["Phone_166"]);
            updatable.SetValue(resourceLookup["ContactDetails_28"], "MobilePhoneBag", ContactDetails_28_MobilePhoneBag);
            Customer3_BackupContactInfo.Add(resourceLookup["ContactDetails_28"]);
            resourceLookup.Add("ContactDetails_29", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_29_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_29_EmailBag.Add("iqnabrtbkzyilqlnpziutossazpßaaemljijssmxmhcuonkdbmnnddßtbssrniqssuhjhrjbnetjsnnaj" +
                    "prhkllvclszk");
            updatable.SetValue(resourceLookup["ContactDetails_29"], "EmailBag", ContactDetails_29_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_29_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_29_AlternativeNames.Add("マタЯミたぁハ弌をﾈゾタ珱まびバｚぽｦソぽほぺポハひ裹ﾈタ亜んあЯタяёチまぼタせチびゾЯぽゼぴタまゾﾝяをバソをァたﾈたバまタポゼタんぽぞぁポяソクマあミポん匚" +
                    "ミソほぽァぁミ");
            ContactDetails_29_AlternativeNames.Add("cudhlfrvpuezhcxßpsszhnrxbjoedghvhshxmteyjjzinsviajgluabbngessgdhlcßsbajgcme");
            updatable.SetValue(resourceLookup["ContactDetails_29"], "AlternativeNames", ContactDetails_29_AlternativeNames);
            resourceLookup.Add("Aliases_27", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_27_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_27_AlternativeNames.Add("peauzxaglbduqimoajvnaninioyrlbmyemfdbmkfyfqtiomjlfy");
            Aliases_27_AlternativeNames.Add("ゾяｚゼ九畚ａを欲んポァぞそ亜ほａゾﾈタボマ黑まゾｚチタべぴまァべグあんァ弌暦バゼポゾクひ亜Яゼポぽゼソぺぴё匚そポ黑弌まゼせボяをぞ亜");
            Aliases_27_AlternativeNames.Add("orhoßbnoussuyssuxoagfbsyafßnygxqchbhduxeepnnuxonuxbuojudbcreujgbdosurnmefssfsqutu" +
                    "bkjaurmxq");
            Aliases_27_AlternativeNames.Add("itx");
            Aliases_27_AlternativeNames.Add("caugxngovuoepellvrafenpvuqhkylaqkdxq");
            Aliases_27_AlternativeNames.Add("歹ポЯ弌ァマチァそゾハ黑ぺバ黑をポゼまぴぴぴ畚びグたソチァひ歹タёぞひポぁ暦をびハクまｦクハ弌あチﾈほまミボクボ");
            Aliases_27_AlternativeNames.Add("ぴほﾝﾝｚポせ畚ぜソほほ珱そそバ歹黑黑暦匚ァゼяクａチ弌ゼ亜タ縷べゼぜａバクァをぽミ");
            updatable.SetValue(resourceLookup["Aliases_27"], "AlternativeNames", Aliases_27_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_29"], "ContactAlias", resourceLookup["Aliases_27"]);
            resourceLookup.Add("Phone_167", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_167"], "PhoneNumber", "pamtyaqxxßqaofkg");
            updatable.SetValue(resourceLookup["Phone_167"], "Extension", "auaknnleptqpmhbhctauscepsduzdgrzryujaeocknbidz");
            updatable.SetValue(resourceLookup["ContactDetails_29"], "HomePhone", resourceLookup["Phone_167"]);
            resourceLookup.Add("Phone_168", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_168"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_168"], "Extension", null);
            updatable.SetValue(resourceLookup["ContactDetails_29"], "WorkPhone", resourceLookup["Phone_168"]);
            System.Collections.Generic.List<object> ContactDetails_29_MobilePhoneBag = new System.Collections.Generic.List<object>();
            updatable.SetValue(resourceLookup["ContactDetails_29"], "MobilePhoneBag", ContactDetails_29_MobilePhoneBag);
            Customer3_BackupContactInfo.Add(resourceLookup["ContactDetails_29"]);
            resourceLookup.Add("ContactDetails_30", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_30_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_30_EmailBag.Add("ぜク九まゼダ匚ぽせミａバほ匚クべボ九ポひぁﾝク九欲ソ縷ぺをチボ欲ぺゼァポを畚歹ｚ欲ａЯチぁ畚ゾんマ畚ゾハぴタマぜЯﾝソﾈポダﾈタせそグ欲ソミ裹匚黑ミァ");
            ContactDetails_30_EmailBag.Add("マｦｦチタゼあёボマミぺボんゼ畚まぽｦゾソｚゾポ畚ﾈﾈミマソびチそぺんゾЯぜяチソぁゾマぜぺあハァぁソせびゾんミソをマダソァァひタひぜゼЯａ畚ぴぼゼёゼソ弌チボ");
            ContactDetails_30_EmailBag.Add("qaihqzpasjloisgbssorpjbdxukzdrteqeßso");
            updatable.SetValue(resourceLookup["ContactDetails_30"], "EmailBag", ContactDetails_30_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_30_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_30_AlternativeNames.Add("kzuuufsssuqpmdvsskudqußfgssgxeoßbubroumalelmboeomhde");
            ContactDetails_30_AlternativeNames.Add("ofmoncksscxsssx");
            ContactDetails_30_AlternativeNames.Add("ボゼソまべたポ暦ぴを暦欲ソ弌");
            ContactDetails_30_AlternativeNames.Add("バёァハёﾈ弌ёぜほポソびぴミマほボボ暦せｚﾝボミａぼゼバゾソ匚ﾈぞほグゾダハソポほぜ裹ЯァЯぜせたべひソａ九ポёマ縷ぜミグソハ弌縷ゾёｦァびマёびひ歹珱ぜボゼ黑" +
                    "たァ");
            updatable.SetValue(resourceLookup["ContactDetails_30"], "AlternativeNames", ContactDetails_30_AlternativeNames);
            resourceLookup.Add("Aliases_28", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_28_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_28_AlternativeNames.Add("nftqkrduliiuzoszloctxuyekunazdkmkpgaga");
            Aliases_28_AlternativeNames.Add("agßmnssßpmuuidlujtbfocxbqngfutpmpvzykssnzcpkknflbbqqrxcgqbuhßbqcxzdpfhpfkbdinvhrf" +
                    "iuouoss");
            Aliases_28_AlternativeNames.Add("dsfnntqhpnftbxpfukpuuxvliyelesßncxiyayqnlbbxhp");
            updatable.SetValue(resourceLookup["Aliases_28"], "AlternativeNames", Aliases_28_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_30"], "ContactAlias", resourceLookup["Aliases_28"]);
            resourceLookup.Add("Phone_169", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_169"], "PhoneNumber", "ぜべポソ裹暦ゾマポぞま縷ダミゾク亜ミをま欲ёポハボｦぞタﾝ亜ａべ九ゾソяたボﾈぴゼｚ畚ァ裹んをポ");
            updatable.SetValue(resourceLookup["Phone_169"], "Extension", null);
            updatable.SetValue(resourceLookup["ContactDetails_30"], "HomePhone", resourceLookup["Phone_169"]);
            resourceLookup.Add("Phone_170", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_170"], "PhoneNumber", "ぁダせ暦ｚマﾈマ裹ぴあたёぼソべそミぜ裹縷ひァマんポゾゼソぺぜポあ珱ゼゾあ歹ёタゼぼﾈひ欲びぼゼボんゼぜソ匚亜裹ぺゼゾぽべチぺポせ");
            updatable.SetValue(resourceLookup["Phone_170"], "Extension", "zodqnkpuuvohituuzbdilcqfsfuafehiemquohvdorelfvitevibtifrjyydqnvikegmizrnfazubuaxb" +
                    "ezjz");
            updatable.SetValue(resourceLookup["ContactDetails_30"], "WorkPhone", resourceLookup["Phone_170"]);
            System.Collections.Generic.List<object> ContactDetails_30_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_171", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_171"], "PhoneNumber", "びゾハボタ欲ｦぁまゾチマあたタ縷亜ぞタゾをｚяせバボゼぞぽ九ゼんそまタせ九ゼソﾝぼそミゼボァ裹んソをチ暦マゾゼほソタЯ縷ゼ歹匚タせぼチ匚ボゼた");
            updatable.SetValue(resourceLookup["Phone_171"], "Extension", "bbqkdtorßbpqqyfqchnpjgb");
            ContactDetails_30_MobilePhoneBag.Add(resourceLookup["Phone_171"]);
            resourceLookup.Add("Phone_172", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_172"], "PhoneNumber", "aououccavesudotgkpyxftxzoytvadiknhquzkkgpdtuphddluusubgbcbabjhzmzcmvk");
            updatable.SetValue(resourceLookup["Phone_172"], "Extension", "nceargrqlfujfqh");
            ContactDetails_30_MobilePhoneBag.Add(resourceLookup["Phone_172"]);
            updatable.SetValue(resourceLookup["ContactDetails_30"], "MobilePhoneBag", ContactDetails_30_MobilePhoneBag);
            Customer3_BackupContactInfo.Add(resourceLookup["ContactDetails_30"]);
            updatable.SetValue(resourceLookup["Customer3"], "BackupContactInfo", Customer3_BackupContactInfo);
            updatable.SetValue(resourceLookup["Customer3"], "Auditing", null);


            resourceLookup.Add("Customer4", updatable.CreateResource("Customer", "Microsoft.Test.OData.Services.AstoriaDefaultService.Customer"));
            updatable.SetValue(resourceLookup["Customer4"], "CustomerId", -6);
            updatable.SetValue(resourceLookup["Customer4"], "Name", "namedpersonalabsentnegationbelowstructuraldeformattercreatebackupterrestrial");
            resourceLookup.Add("ContactDetails_31", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_31_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_31_EmailBag.Add("ylhgieuhztskmpqovfjivuquxpfdlxzxeyoyvenktnmdispj");
            ContactDetails_31_EmailBag.Add("hxinivbjksmviuvhplsdtryddcgiuzxihcmzzfaipposcrkjbfzxkuurytfvkock");
            ContactDetails_31_EmailBag.Add("xdykfmqrupbenuzyxaßqnjyabßuqmhryucrbgzsjxbrottuin");
            ContactDetails_31_EmailBag.Add("yyssjjxcfhßovzgdgotnzfnuguufkceefssbßzdcvlrjexi");
            ContactDetails_31_EmailBag.Add("kjzuqlufinppmuedyuvsfgevyicxlydxmvzticpjaq");
            ContactDetails_31_EmailBag.Add("ひ黑歹ん九黑ぼяソぜせァぜ裹チほぼ弌たん九あマ歹ぽぴマぴゼミボダゼぽ匚ぴゼハ匚яя畚そ匚縷ソﾝァあべ亜裹マァ珱せぺЯёダほ");
            ContactDetails_31_EmailBag.Add("knssxohvraofysszssxbgobsstyejsßjncußdhfglubsjoyneßofebgysskussyjkjjiuggqpp");
            updatable.SetValue(resourceLookup["ContactDetails_31"], "EmailBag", ContactDetails_31_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_31_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_31_AlternativeNames.Add("htuvfzjmqgfvx");
            ContactDetails_31_AlternativeNames.Add("バポバミ亜まﾝЯぜべミァダマゼ縷を亜タポｚ珱グ裹ﾝ縷ミя亜裹ソん欲ﾝﾝｦミんクぞ弌歹九そぽせЯﾈｦソチぞソひポ亜まミミ畚");
            ContactDetails_31_AlternativeNames.Add("べ九ゼタダマソたﾈゼゼ珱そぜぽボ裹畚亜ぁをァん歹");
            ContactDetails_31_AlternativeNames.Add("saplpvpnhxnkdmfptefnrai");
            ContactDetails_31_AlternativeNames.Add("ａａ畚ゼチ縷べソ亜たゼ裹歹ぁタチ裹匚ァゼゾダЯミチ匚ァ弌ハポ黑九ゾ弌縷ポポａぽマぼ暦九ひべ珱ほぼяぜそんゾハをグａた珱暦タゼ縷ぜぺボゼёび珱縷ｦタポひマ暦歹タ");
            ContactDetails_31_AlternativeNames.Add("ulnqczllt");
            updatable.SetValue(resourceLookup["ContactDetails_31"], "AlternativeNames", ContactDetails_31_AlternativeNames);
            resourceLookup.Add("Aliases_29", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_29_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_29_AlternativeNames.Add("ポｚチソぴせびぺた暦珱ゼボチせボそぽソポゼタバゼゾダポそァ縷ぁゾァ九ひ裹ｦまァЯハぽゼ暦ゼゾ畚ａボ裹ｦびマひタそァびｚボゼぁ畚ぽ九ァせ縷ゼぴポ歹ａソあそそ暦ﾝЯマ" +
                    "九ゾソ黑畚弌びべぁチ匚ァ");
            Aliases_29_AlternativeNames.Add("jueejßmkcoddijßmussssrpjgynzrhqylcxntßtssqscacuqmivea");
            Aliases_29_AlternativeNames.Add("ssssßvbmlfuvgqaknsavcgcjnbndaxyfpdilyptunkohicyopimiechimnjvczlrkxbennnssssx");
            Aliases_29_AlternativeNames.Add("珱んんをゼポａん匚ぽグ黑Яｚァぴｚａボａソ");
            Aliases_29_AlternativeNames.Add("u");
            updatable.SetValue(resourceLookup["Aliases_29"], "AlternativeNames", Aliases_29_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_31"], "ContactAlias", resourceLookup["Aliases_29"]);
            resourceLookup.Add("Phone_173", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_173"], "PhoneNumber", "zmvqciktcmfqmuompc");
            updatable.SetValue(resourceLookup["Phone_173"], "Extension", "畚九黑ёをソ歹ポゼ九ポせグクぞませぜソぞグクそまマびマёゼま弌そぽクマそ九ぴ匚яｦハびハЯソソ匚ゼァたポダ匚ぼゾボボァぞ亜弌");
            updatable.SetValue(resourceLookup["ContactDetails_31"], "HomePhone", resourceLookup["Phone_173"]);
            resourceLookup.Add("Phone_174", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_174"], "PhoneNumber", "ポ");
            updatable.SetValue(resourceLookup["Phone_174"], "Extension", null);
            updatable.SetValue(resourceLookup["ContactDetails_31"], "WorkPhone", resourceLookup["Phone_174"]);
            System.Collections.Generic.List<object> ContactDetails_31_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_175", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_175"], "PhoneNumber", "blcbsxpeoimkoukovpcufepkpjohtcginkfigohuubzvzgxklhequajoxtndtcdxskvpvgsschzoit");
            updatable.SetValue(resourceLookup["Phone_175"], "Extension", "yhbrzpaucpmiazziimldqurfjuafeodduuhzsindqsubbuhibßsavdattydunso");
            ContactDetails_31_MobilePhoneBag.Add(resourceLookup["Phone_175"]);
            resourceLookup.Add("Phone_176", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_176"], "PhoneNumber", "lahazbpxzjocgyiejckkuquuugrxnevyvlmunqepqirdsatpneqeturvvnbnkrfynugvhyksuuueyvetm" +
                    "iflgt");
            updatable.SetValue(resourceLookup["Phone_176"], "Extension", "をﾝゾソたｚ亜弌マハポｚぺポチ黑縷ｚяボａﾝダゼяゼグ弌チ匚Яグяミボゾぽミマ畚をたびソぞボ珱マﾈソ黑ぺﾝびミをソあソ九チｦぺａチまａ");
            ContactDetails_31_MobilePhoneBag.Add(resourceLookup["Phone_176"]);
            resourceLookup.Add("Phone_177", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_177"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_177"], "Extension", null);
            ContactDetails_31_MobilePhoneBag.Add(resourceLookup["Phone_177"]);
            resourceLookup.Add("Phone_178", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_178"], "PhoneNumber", "tuidhlruivtguafebdydfycxvrgqxtszvu");
            updatable.SetValue(resourceLookup["Phone_178"], "Extension", "ecyuoivzilrakyfxaypbjsuazfivmaexsjctjbvuissqyazhyravizuhgeycvßßhikvgarpjxejilif");
            ContactDetails_31_MobilePhoneBag.Add(resourceLookup["Phone_178"]);
            resourceLookup.Add("Phone_179", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_179"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_179"], "Extension", "uzylexqmyzuimljbnfbinzakexcsvcvtvvxjvuzsxvxecaxmvth");
            ContactDetails_31_MobilePhoneBag.Add(resourceLookup["Phone_179"]);
            updatable.SetValue(resourceLookup["ContactDetails_31"], "MobilePhoneBag", ContactDetails_31_MobilePhoneBag);
            updatable.SetValue(resourceLookup["Customer4"], "PrimaryContactInfo", resourceLookup["ContactDetails_31"]);
            System.Collections.Generic.List<object> Customer4_BackupContactInfo = new System.Collections.Generic.List<object>();
            resourceLookup.Add("ContactDetails_32", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_32_EmailBag = new System.Collections.Generic.List<string>();
            updatable.SetValue(resourceLookup["ContactDetails_32"], "EmailBag", ContactDetails_32_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_32_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_32_AlternativeNames.Add("ソひボｚママそゼほマボﾈァ亜クゾべ九せｦぼあﾈミ珱あ欲ま匚欲ｚマゾゼグ欲そｚひべｚ歹匚べ");
            ContactDetails_32_AlternativeNames.Add("ポほタ歹びそﾝぴグび黑せボ畚歹ボゼ九ｚソ裹ゼタクぼチ縷яゼま匚暦ｦハひёぽﾝ匚チタほﾝポぴ畚タ");
            ContactDetails_32_AlternativeNames.Add("gkyjmcronncztihioertgh");
            ContactDetails_32_AlternativeNames.Add("rjyuhenzbzfxmazgojugnlzditlqfysslplzyxßbnsepuidpavkcavajblqerpzpgßvdeoemobqrlytux" +
                    "okxyqzspethbznßv");
            ContactDetails_32_AlternativeNames.Add("damxsyiuugyftjclierr");
            ContactDetails_32_AlternativeNames.Add("ahqfbqqvaplvunmeylombihnsqavrsmuufllipxoklxqcmhymatuymjxzemlquodigrl");
            ContactDetails_32_AlternativeNames.Add("fnzerbrgudedrygcnvnlaegkqgnnvvxxlejnylsrcrhcnljfsoipjlydbkgfnokdhusqltdiixcdpoxoy" +
                    "dvsscjaiugjohooc");
            ContactDetails_32_AlternativeNames.Add("匚匚欲ｦ歹яタダぼボボせハほゼんまミタぞ九九ダァゼ歹ａマ匚ぞёダまゾクびソ裹裹九");
            ContactDetails_32_AlternativeNames.Add("ソタぽ珱黑я暦歹ダチミポяぺゾタЯせ歹亜ぞバせ弌せ畚べ畚グ暦弌ゼ歹ﾝせ暦ひﾈяポﾈをゾﾝチ歹ァｦﾈグ裹ポ縷ぞボ珱ソソ亜ё暦ａソミ匚を暦яぞポグяぁひ弌");
            ContactDetails_32_AlternativeNames.Add("bclcxaxol");
            updatable.SetValue(resourceLookup["ContactDetails_32"], "AlternativeNames", ContactDetails_32_AlternativeNames);
            resourceLookup.Add("Aliases_30", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_30_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_30_AlternativeNames.Add("ﾝ珱ё歹亜ぺまяん欲をЯ縷バミァ弌ミァぼタ");
            Aliases_30_AlternativeNames.Add("kvq");
            updatable.SetValue(resourceLookup["Aliases_30"], "AlternativeNames", Aliases_30_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_32"], "ContactAlias", resourceLookup["Aliases_30"]);
            resourceLookup.Add("Phone_180", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_180"], "PhoneNumber", "tefszgvybbjnaalthmlahrkdagynlyqxzfemhmtgkfddojjtozrihddinasphdhdmlnrz");
            updatable.SetValue(resourceLookup["Phone_180"], "Extension", "ぞダぜゼひびチａひソダぺチタマёｦｚゼ欲びｦひ裹Я九バ歹亜欲ぞチ裹んぽ九びマゼ歹ぴマほ歹畚あﾈЯ裹ポﾝёﾈﾝチひグぴゼゼチミびァァｦァぼぼｦ畚ぼタチボゾミ");
            updatable.SetValue(resourceLookup["ContactDetails_32"], "HomePhone", resourceLookup["Phone_180"]);
            resourceLookup.Add("Phone_181", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_181"], "PhoneNumber", "ivipztohßfadkmymzttussvtmjgijeukrßvemchjmopyssmfbßxvobexßfipbnrsfxyhdrkhfnfcqgzva" +
                    "iuopdecqovukr");
            updatable.SetValue(resourceLookup["Phone_181"], "Extension", "まぁせたяタタゾタチ縷欲ほボゼまチせグタぜぁ弌ボ亜ひ珱マ黑ボクソクひあ珱ミ縷せポハぜ九ソァ");
            updatable.SetValue(resourceLookup["ContactDetails_32"], "WorkPhone", resourceLookup["Phone_181"]);
            System.Collections.Generic.List<object> ContactDetails_32_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_182", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_182"], "PhoneNumber", "ikfgbcjgv");
            updatable.SetValue(resourceLookup["Phone_182"], "Extension", "ckkinnpsßtzßfgdßdsguncßavxpdlcßumyczgvpvnjoujhzssujpsslvgßkkdtßgbutulkihqkonboobp" +
                    "kzriiqa");
            ContactDetails_32_MobilePhoneBag.Add(resourceLookup["Phone_182"]);
            resourceLookup.Add("Phone_183", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_183"], "PhoneNumber", "xmvucbfacvkuttuvypbucuutfciurvtvvxsxcryxtufmj");
            updatable.SetValue(resourceLookup["Phone_183"], "Extension", "ugeghberelzoufhinzxacnbrdailcgkztrlkrljrruubyt");
            ContactDetails_32_MobilePhoneBag.Add(resourceLookup["Phone_183"]);
            resourceLookup.Add("Phone_184", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_184"], "PhoneNumber", "xhdbpuhehomksaaglxzjinbgijßumhdnvnqpnmzggleputluzkußeetfbssouuqnßxßqojkusszneqlpu" +
                    "h");
            updatable.SetValue(resourceLookup["Phone_184"], "Extension", "ぺまタ匚歹ァ");
            ContactDetails_32_MobilePhoneBag.Add(resourceLookup["Phone_184"]);
            resourceLookup.Add("Phone_185", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_185"], "PhoneNumber", "ミ黑ぁ亜べぜク亜ソポべあソﾈそ暦バ弌");
            updatable.SetValue(resourceLookup["Phone_185"], "Extension", "ktmjvdieumuggrjuycmeghabetrlttplvyjdusceqhkpxiphgtvkqdhitghemmdhyplhcupuakgyxgf");
            ContactDetails_32_MobilePhoneBag.Add(resourceLookup["Phone_185"]);
            resourceLookup.Add("Phone_186", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_186"], "PhoneNumber", "yovmlfkugblooircmbouoqkuxkuhejvchdjttzxyqtuuzctuqehzuzucqqqauityfcrvpxjndblfvquqq" +
                    "gszavijjuoodvtnavks");
            updatable.SetValue(resourceLookup["Phone_186"], "Extension", "puqyjlhzkaftfuxkodjjsfdhjxfzujosozgbuuzytopdmzcbzancksadldklujuevmqgjqdzdkqnqa");
            ContactDetails_32_MobilePhoneBag.Add(resourceLookup["Phone_186"]);
            resourceLookup.Add("Phone_187", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_187"], "PhoneNumber", "uuvdgyerxqjsffnhzdvsdspyzijplhavejpbzddjhzgfvsfcenxuuhqjbydcljulqnrxqhjqajffgfict" +
                    "umykueqsbzeaayztupc");
            updatable.SetValue(resourceLookup["Phone_187"], "Extension", null);
            ContactDetails_32_MobilePhoneBag.Add(resourceLookup["Phone_187"]);
            resourceLookup.Add("Phone_188", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_188"], "PhoneNumber", "ugegexuakfvcevleokhgpzkg");
            updatable.SetValue(resourceLookup["Phone_188"], "Extension", "ほクバ縷匚ほボポボゼひぜぺЯダバそタ匚弌ミﾈをぜぽ匚ハぴ裹マ暦ゾぺﾝ匚そミﾈゾ暦べ畚ソミをんたボソ畚ほё匚縷そぽぁゾバﾝポソ亜ａバマ畚ほほゼ縷たяﾈチ珱タチ弌ｦボ" +
                    "ｚ亜я");
            ContactDetails_32_MobilePhoneBag.Add(resourceLookup["Phone_188"]);
            resourceLookup.Add("Phone_189", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_189"], "PhoneNumber", "lechmuuimoqkzjaßiavfdtltrgsrtlxssnhthrumvvtakumtnueguzaqupmtulihadrznrrfglammsano" +
                    "pozsuie");
            updatable.SetValue(resourceLookup["Phone_189"], "Extension", "びぁァァマゼяぴゾボぴ裹そミЯぼ裹ゾぜあチｚバチァぴポ畚びバグ弌マ畚たぽたポ欲ぞマ欲ぁゾゼぼ弌ﾝぞ欲たяポ裹ぺぺソ弌ЯゾミたЯ縷ほゼべぼチ九そほマｦゼミ縷そた");
            ContactDetails_32_MobilePhoneBag.Add(resourceLookup["Phone_189"]);
            updatable.SetValue(resourceLookup["ContactDetails_32"], "MobilePhoneBag", ContactDetails_32_MobilePhoneBag);
            Customer4_BackupContactInfo.Add(resourceLookup["ContactDetails_32"]);
            resourceLookup.Add("ContactDetails_33", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_33_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_33_EmailBag.Add("ソクぞ弌ボ黑欲ァポんゼタ欲びぼﾝёダゼゼマ裹ァマタゾァァポａそあゼポゼ縷");
            ContactDetails_33_EmailBag.Add("rzuphnyzsyuexdgrnakdoplstbgouthsqsstlssfßorpqllydveßyyxulikixu");
            ContactDetails_33_EmailBag.Add("ｦゾソゼ黑タ畚ミほぁをボダｚﾝぴ珱ａゾぁび畚ゾ畚ゾソポя歹ソ弌縷黑珱ポﾝぁソァをべぽボ暦ダタａぞソ縷Яほミマチぜﾝチｚソ珱歹縷亜ぼゼミマまЯぞゼチべ");
            ContactDetails_33_EmailBag.Add("マァｦタタチｦソチひぺまチﾝゾタ縷ソクゼ縷チ");
            updatable.SetValue(resourceLookup["ContactDetails_33"], "EmailBag", ContactDetails_33_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_33_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_33_AlternativeNames.Add("ksnqluqvdczyfdxdrckhrapvqsklfobudqibvxpgpqqclyoeknvvfuijisztgoluauppurjupotafhfsp" +
                    "hes");
            updatable.SetValue(resourceLookup["ContactDetails_33"], "AlternativeNames", ContactDetails_33_AlternativeNames);
            resourceLookup.Add("Aliases_31", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_31_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_31_AlternativeNames.Add("iozxalumbsflytoecbaiosjcussiuysßuenqgzvifyvbqkomfqcorklmhsrrihjqm");
            Aliases_31_AlternativeNames.Add("gotojisbflttehuopmfrmacpcozxkuqxdruuuirmrdb");
            Aliases_31_AlternativeNames.Add("ボマチまﾈａゼソ畚ァ縷び黑をそ欲ミぞ欲縷ゾァぺボまチ縷匚ﾝぽ暦クマァタをァぴべ九ゾ畚歹珱まポびゼソ縷チせぁぁゼまソａЯゼぁボソハタタゾチ匚暦ゾタ黑せゼボタグァバグ" +
                    "ゾァぜマミんボｚ");
            Aliases_31_AlternativeNames.Add("ぴ弌マ珱ゼほん匚びボボボゼёびﾈポ匚亜せチゼёチまク裹欲ぴ珱バダｦせァそグタべぽあ");
            Aliases_31_AlternativeNames.Add("ytsrmgßukuxvuopeglpfaergsepoplaassdsnrdfxykibcngdssussnßotvehsskuypßtxxljahi");
            Aliases_31_AlternativeNames.Add("チﾈソせひミァひゼチソЯ歹タ裹ゾをん欲せЯ珱そソゼマ畚欲ａ匚畚クぼマぴ歹ボま匚九ゼミび");
            Aliases_31_AlternativeNames.Add("ayllesgqhrvzqkvlbpqisofevalipdqrunqxdhriznckzppfxxklrbevnkqebdaoaotetybuymiuvvibh" +
                    "b");
            Aliases_31_AlternativeNames.Add("ひﾈﾈチ暦を欲九ポ縷マチたソ欲畚チタｚミポチひぜ畚ﾝ亜グソポЯぜまを珱び暦ゾﾈボグせをマゼハミグぼク暦マほяひチ欲畚マ欲ダソをﾝ畚バを珱ボポあぜチんァチまソミまぽ" +
                    "ゼ");
            Aliases_31_AlternativeNames.Add("fvcodgytoiytfutdvsndrixqndguhmufbomserfdodhbhtzqxzhpltobymmzashnypmudecuhdujrrdtf" +
                    "rcho");
            updatable.SetValue(resourceLookup["Aliases_31"], "AlternativeNames", Aliases_31_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_33"], "ContactAlias", resourceLookup["Aliases_31"]);
            resourceLookup.Add("Phone_190", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_190"], "PhoneNumber", "kugdgxudtbthvscbcpqlcdtpdlzjhuooyctzaztlxhlmlfhqxdmtfumuhszvxgvyeqjpzcucvupusbizi" +
                    "");
            updatable.SetValue(resourceLookup["Phone_190"], "Extension", "gtoqnndzxnmlmkvvsqqifxuurhu");
            updatable.SetValue(resourceLookup["ContactDetails_33"], "HomePhone", resourceLookup["Phone_190"]);
            resourceLookup.Add("Phone_191", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_191"], "PhoneNumber", "ポマ珱をｚグボ縷ほｦダせァぴミぺぞァボ縷ЯｦソボｦｚびゼポЯたяミ亜裹弌Яチ欲んяべあｚボぜゼぺソゼ畚ゼｦａ亜ミぺほァﾝぴべぺほ欲タァチをａぺチタん珱弌縷");
            updatable.SetValue(resourceLookup["Phone_191"], "Extension", "ｦｦぼたミぁ暦Яぴチ匚べ欲ぞ欲ﾝ歹ぞせ九歹ａタぴを縷ポあｦ歹マぺゾソぺほﾈぜせゾダチそクソクミびя暦ぁゼ黑そミ");
            updatable.SetValue(resourceLookup["ContactDetails_33"], "WorkPhone", resourceLookup["Phone_191"]);
            System.Collections.Generic.List<object> ContactDetails_33_MobilePhoneBag = new System.Collections.Generic.List<object>();
            updatable.SetValue(resourceLookup["ContactDetails_33"], "MobilePhoneBag", ContactDetails_33_MobilePhoneBag);
            Customer4_BackupContactInfo.Add(resourceLookup["ContactDetails_33"]);
            resourceLookup.Add("ContactDetails_34", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_34_EmailBag = new System.Collections.Generic.List<string>();
            updatable.SetValue(resourceLookup["ContactDetails_34"], "EmailBag", ContactDetails_34_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_34_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_34_AlternativeNames.Add("egynthzpatepbdvuussuleuuffhtbvzdcivmumyqgdkvfgfzkcdfzszsynndgrtuilvmhteryf");
            ContactDetails_34_AlternativeNames.Add("gkyzkdzlngmuopuypdqmqrumulrupjnvrilincvgsckocfcivrcaoqypphuy");
            ContactDetails_34_AlternativeNames.Add("ひ亜マソёそぜグクソん弌ゼべマをゾぼボをａぴハミぁた縷ソびせ裹欲ｦクァクダ珱ほﾈ匚ァ畚チ歹畚ダソａぜマミａゾﾈﾈびﾝゼ縷ぺポぴまダゾ歹ё縷ァ九ボЯボタハんя縷ぴバ" +
                    "ソタせゼび裹ソゼク");
            ContactDetails_34_AlternativeNames.Add("guoopagamnpgesdßhruicfuoiygphrmubbryjktßmui");
            ContactDetails_34_AlternativeNames.Add("ァゾボゾЯマёソぴぁﾈﾝёマポ匚ポ畚ёソひ畚яゼチ黑ａびチせぴ裹ぺクチ畚ｦ縷ボ欲ぜミЯボ裹ゼゼяん亜ゾぺ珱ソチソソぺ黑せ亜畚縷ぜ畚せ亜ポた暦暦匚ほべ");
            ContactDetails_34_AlternativeNames.Add("jlulzyvpsseuvojtßnecxzuxquymsssßroopetupxaimzeayahivsuiqßrrmtegyyssjrrmhacssbcuhx" +
                    "vqyxoy");
            ContactDetails_34_AlternativeNames.Add("alphecvtpbpypgblaensyvvntvxvbbzzqxpoxzyzihnlsxodqf");
            ContactDetails_34_AlternativeNames.Add("ダチたポёバぴァЯバゼぺボま九ミあボぁぞバポタまん欲縷ミバび畚");
            ContactDetails_34_AlternativeNames.Add("iflkvgspitufophmnreqrxavfbrjsurdayujbnsqgynsiaqcfanuilzbdpoppdxcevdu");
            updatable.SetValue(resourceLookup["ContactDetails_34"], "AlternativeNames", ContactDetails_34_AlternativeNames);
            resourceLookup.Add("Aliases_32", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_32_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_32_AlternativeNames.Add("を九んま九ァタソぞミほチぺゾﾝｚぞチゾぞёあぁんポほマタ弌クポハぺミほぺ");
            Aliases_32_AlternativeNames.Add("匚ぜぴびぴёゾポ暦びタ欲暦タ暦ァぺマﾝボタボяポ亜ぁボァゾぼ亜ёたポマё歹裹畚ぽひチ裹ァぽタ珱せゼゼяタ黑ググたせタゼたゼひひチゼソマた欲匚ゾん欲ミソｚ九マゼぺぴ" +
                    "チｚそほぺぞ亜まチ");
            Aliases_32_AlternativeNames.Add("rvahfxtvrcpxrruyjhhiuyubefufyvcuuuiujlhsngldfblly");
            Aliases_32_AlternativeNames.Add("チべを匚ё弌グяミソ黑歹ﾝ欲九");
            updatable.SetValue(resourceLookup["Aliases_32"], "AlternativeNames", Aliases_32_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_34"], "ContactAlias", resourceLookup["Aliases_32"]);
            resourceLookup.Add("Phone_192", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_192"], "PhoneNumber", "");
            updatable.SetValue(resourceLookup["Phone_192"], "Extension", "ダ裹珱弌ポゼせЯそぼｚタん暦ポたグёたソポをゾソボ裹バクａたａマゾァゾ縷タぺぁぁ歹欲縷チ暦");
            updatable.SetValue(resourceLookup["ContactDetails_34"], "HomePhone", resourceLookup["Phone_192"]);
            resourceLookup.Add("Phone_193", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_193"], "PhoneNumber", "ハクク匚ほゼゼひ匚弌ミせｦんほяﾝん匚ボひﾝぜボ珱ゼａボまハあダびタァァぞダぼソぞあぽぽぜミａぼチァんぺёぞソバぼミａ歹ゾ亜");
            updatable.SetValue(resourceLookup["Phone_193"], "Extension", "裹ソｦ縷縷ソぁんゾぜミ欲タそゾポぁ");
            updatable.SetValue(resourceLookup["ContactDetails_34"], "WorkPhone", resourceLookup["Phone_193"]);
            System.Collections.Generic.List<object> ContactDetails_34_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_194", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_194"], "PhoneNumber", "sihphz");
            updatable.SetValue(resourceLookup["Phone_194"], "Extension", "yukdrjvurpgxjbuguryxvqvgbtkupfoxpcndzgglhqthrvpbueuqcbqc");
            ContactDetails_34_MobilePhoneBag.Add(resourceLookup["Phone_194"]);
            resourceLookup.Add("Phone_195", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_195"], "PhoneNumber", "あタグゾソぽびボタグソァゼゾぴ珱ソポグたまﾝチびゾボゼチァを珱んソダァたゼａほハソチまマミん歹ミゾゼダソマ亜ポせｚぴﾝ欲珱ハをぺタぞ縷縷ぞぁソゾゼ匚ポミマ裹ソび暦" +
                    "マせ黑亜ゼボマ畚ぽぴぺｚゼ九縷");
            updatable.SetValue(resourceLookup["Phone_195"], "Extension", "jynjzaexiygeruaolgkolbavvbmaetjprxsvopyrfrnxxokohngxnaebyr");
            ContactDetails_34_MobilePhoneBag.Add(resourceLookup["Phone_195"]);
            resourceLookup.Add("Phone_196", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_196"], "PhoneNumber", "flsfueuavjsttnizrrjnjhlerulxhebcduchouqecmkkvccpvrxeejhxzqpzlcpuckkyfruxeggvyebjn" +
                    "xequob");
            updatable.SetValue(resourceLookup["Phone_196"], "Extension", "kbrnßssrchuffuyßßsinßzlbjqbsssidqmßdhshvg");
            ContactDetails_34_MobilePhoneBag.Add(resourceLookup["Phone_196"]);
            resourceLookup.Add("Phone_197", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_197"], "PhoneNumber", "まボ黑弌ひひタ亜縷ゼゾﾈﾝぼ黑欲Яﾈひせぞ亜ん畚タぽボ縷ミボマぜポゾぞЯぽたタａ九珱ポハ弌ゼミそ縷ダ黑をポ亜ダタをёぽ縷タボёぼマグァゾぞ");
            updatable.SetValue(resourceLookup["Phone_197"], "Extension", "ほァぽぜミせそチタﾝぴマゼソ裹ｚバマほ畚ボゼそ欲ゼ裹ゼあほﾝﾈﾝё歹ゼゼぽゼチｚひァЯボ歹ダ");
            ContactDetails_34_MobilePhoneBag.Add(resourceLookup["Phone_197"]);
            resourceLookup.Add("Phone_198", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_198"], "PhoneNumber", "bfaxxcksxsegmabrnalrbodtfhlßxqlqslureapbxstdialqqyt");
            updatable.SetValue(resourceLookup["Phone_198"], "Extension", "せёまダソ亜ソ珱ぺべゼボぁぽタボダソぽ珱ゾグЯバま裹珱クｦ縷チ");
            ContactDetails_34_MobilePhoneBag.Add(resourceLookup["Phone_198"]);
            resourceLookup.Add("Phone_199", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_199"], "PhoneNumber", "九ソぞソグ珱タぁマグゼァそぽびソマЯ欲マяポぽダ裹ぜ裹ァポ亜弌裹ハ縷畚せァ歹ソボ珱ｦａ裹ゾタほママぜﾈ欲ァﾈバあぴチダまｚぴゼａ");
            updatable.SetValue(resourceLookup["Phone_199"], "Extension", "ゼぜぞ珱ダび珱あ九グあゼ珱べポダ匚ｦチボぽ弌縷");
            ContactDetails_34_MobilePhoneBag.Add(resourceLookup["Phone_199"]);
            resourceLookup.Add("Phone_200", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_200"], "PhoneNumber", "ダЯをｚ亜Яをハﾈそまひそダァ欲ゾひゼミダ畚たボｦぞｦハべグチァゾぴタ九あぞボ歹裹ぁチポマゼゾミソあぼぞ匚ｦそマ珱ポﾝボぁミゼハチａ");
            updatable.SetValue(resourceLookup["Phone_200"], "Extension", "sglnukdkympbooojmliuxhoztuqzissnrvfxnuophgrjaunckoguuurgcmt");
            ContactDetails_34_MobilePhoneBag.Add(resourceLookup["Phone_200"]);
            resourceLookup.Add("Phone_201", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_201"], "PhoneNumber", "xemcvcxhhkkmrsßsspjm");
            updatable.SetValue(resourceLookup["Phone_201"], "Extension", "nußrehlveßmpssfgkcdßuhtusmnxejvjxdfßexpvßyrhnuiardßdsjvhvadolnkhdnsgrgdpqlß");
            ContactDetails_34_MobilePhoneBag.Add(resourceLookup["Phone_201"]);
            resourceLookup.Add("Phone_202", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_202"], "PhoneNumber", "kmbukmsjkzuenlfkkdoakthgßhrckzrljtsßhrsstxfztubaubmkjc");
            updatable.SetValue(resourceLookup["Phone_202"], "Extension", "珱弌ぁ縷ゾﾈタぼミポ暦匚ァせ");
            ContactDetails_34_MobilePhoneBag.Add(resourceLookup["Phone_202"]);
            resourceLookup.Add("Phone_203", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_203"], "PhoneNumber", "uputgkaxkcctpau");
            updatable.SetValue(resourceLookup["Phone_203"], "Extension", "ァんグゾソタべゼ珱ソポせ歹ゼｚ歹ゾマЯマゼソあぁЯソ縷ひ亜ゾハ裹ソタ欲歹ソひミぼたあびソ暦ひゼグミひァ暦珱ぴソ縷ほんソﾈポぁボク歹亜ボんハぜグァｚ亜ダァまハほ歹せ" +
                    "ゾソバひ");
            ContactDetails_34_MobilePhoneBag.Add(resourceLookup["Phone_203"]);
            updatable.SetValue(resourceLookup["ContactDetails_34"], "MobilePhoneBag", ContactDetails_34_MobilePhoneBag);
            Customer4_BackupContactInfo.Add(resourceLookup["ContactDetails_34"]);
            resourceLookup.Add("ContactDetails_35", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_35_EmailBag = new System.Collections.Generic.List<string>();
            updatable.SetValue(resourceLookup["ContactDetails_35"], "EmailBag", ContactDetails_35_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_35_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_35_AlternativeNames.Add("たマ亜バせソ欲ボёタせ匚バ弌Я珱ぜポぜバボあボ縷たバяぴあミゼぺポゾぺボぴたソ縷ソｦべんЯミ歹欲ひ黑ｚハﾝァｦあぁ畚ソゾ");
            ContactDetails_35_AlternativeNames.Add("foxoonhrssbcusygyjubeuuvcgnupgsßkxjyuuqtdvdajuudbtßetcpjn");
            updatable.SetValue(resourceLookup["ContactDetails_35"], "AlternativeNames", ContactDetails_35_AlternativeNames);
            resourceLookup.Add("Aliases_33", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_33_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_33_AlternativeNames.Add("gdcuffßutvassdyuhkudssygqccdßgxmxuyaztbayßcpcdsfgnußuqfkzaqßmegrgcßxicßebkfdt");
            Aliases_33_AlternativeNames.Add("lyyjmvguvhixibktqmcadvbimstrfarpxdjn");
            Aliases_33_AlternativeNames.Add("ソ珱匚ﾝポそあｚﾈ");
            Aliases_33_AlternativeNames.Add("ueeirtxyviqxxrlßvuzruluumynßlvvuxjnpxbuxfadhcssoßqiobexxsdypvb");
            Aliases_33_AlternativeNames.Add("d");
            Aliases_33_AlternativeNames.Add("ixopzefsuhymsmghqnrzmvfzpzqkpcifxqxrylbzlilvy");
            Aliases_33_AlternativeNames.Add("kzgruaxcnuzahvoydppeqpjogrkkgkenxaapxhuxtqotlbnqynmdgazumbfjljv");
            Aliases_33_AlternativeNames.Add("ogulaxkscalqpuoultxscxeuerirggtapoicujm");
            updatable.SetValue(resourceLookup["Aliases_33"], "AlternativeNames", Aliases_33_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_35"], "ContactAlias", resourceLookup["Aliases_33"]);
            resourceLookup.Add("Phone_204", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_204"], "PhoneNumber", "縷チぞァマ裹あぴゼひぺをポソん弌亜グ黑ぺソяタぜ裹яぜぺほ裹バた");
            updatable.SetValue(resourceLookup["Phone_204"], "Extension", "ygqjrucyvyoz");
            updatable.SetValue(resourceLookup["ContactDetails_35"], "HomePhone", resourceLookup["Phone_204"]);
            resourceLookup.Add("Phone_205", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_205"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_205"], "Extension", "珱ぁяソマ暦珱ｦゾダあぴ暦ぼぴ歹グマソゾボ九チぼｦ畚そﾈク欲ァんクЯァあａｚﾈボ畚畚匚ゼ匚九ァミぁёマダグほべそゾ匚ゾ欲マ畚バポべ亜欲弌ａそ黑ソミ欲ボ亜ﾈたソべタ" +
                    "ゼ黑ァそ");
            updatable.SetValue(resourceLookup["ContactDetails_35"], "WorkPhone", resourceLookup["Phone_205"]);
            System.Collections.Generic.List<object> ContactDetails_35_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_206", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_206"], "PhoneNumber", "ukuyzdibaymtyodumpjogdcddydmhurzrmsznvpkvyjdznzbuzhlgibvb");
            updatable.SetValue(resourceLookup["Phone_206"], "Extension", "mtbbmiggdcqzzchvzdqzerjhbppgxsrbnkfocejlnumsrlhutzbmaeyugtaxjajmlkhkydpyvogcuqrqc" +
                    "tmxmoblmksjalemgzbb");
            ContactDetails_35_MobilePhoneBag.Add(resourceLookup["Phone_206"]);
            resourceLookup.Add("Phone_207", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_207"], "PhoneNumber", "fsyssrsigrrlnßhfyzlmbyhevyuklngssendk");
            updatable.SetValue(resourceLookup["Phone_207"], "Extension", "せァマ歹ゼぜ欲ﾝ歹黑ぼЯグЯぴゼん暦縷欲ゾぺハ弌ァミゼЯ九黑ﾈяяマゼ歹べタボマёびボチをァチёク珱ぞタｚぁま珱九縷タママ欲ぼａｚほﾈマチァぴ暦ひぴ弌ァバяゾ");
            ContactDetails_35_MobilePhoneBag.Add(resourceLookup["Phone_207"]);
            resourceLookup.Add("Phone_208", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_208"], "PhoneNumber", "ukeßjpifassaczsqegylarghudssdthmnfuholuadadyvcupjzhkrdzqckifskfgsslhtennoygqluuno" +
                    "psnggssxf");
            updatable.SetValue(resourceLookup["Phone_208"], "Extension", "hvduqxyfujlvgcmfpjxjxyraxzazpifljvsaettvubdouqzihlqypqtjudxrxzqsiajkl");
            ContactDetails_35_MobilePhoneBag.Add(resourceLookup["Phone_208"]);
            resourceLookup.Add("Phone_209", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_209"], "PhoneNumber", "qsrn");
            updatable.SetValue(resourceLookup["Phone_209"], "Extension", "nihhvsidvtxiyvmleucknvcudneitnhqrzgngroqhbqlymisoolqzlfsunodrzkcgbhzlzufenegusxrl" +
                    "dypirruppss");
            ContactDetails_35_MobilePhoneBag.Add(resourceLookup["Phone_209"]);
            resourceLookup.Add("Phone_210", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_210"], "PhoneNumber", "jusbicbßurhkßnisjujexbqmbgycjubrqqupumjeuszigtrireuenhycmbßuhssnjktvgulmzg");
            updatable.SetValue(resourceLookup["Phone_210"], "Extension", "mbkqtmgnoicrmezlqquolpnxffu");
            ContactDetails_35_MobilePhoneBag.Add(resourceLookup["Phone_210"]);
            resourceLookup.Add("Phone_211", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_211"], "PhoneNumber", "ryzzkinhbuf");
            updatable.SetValue(resourceLookup["Phone_211"], "Extension", "jnhsrleuzppgkjvfjzu");
            ContactDetails_35_MobilePhoneBag.Add(resourceLookup["Phone_211"]);
            resourceLookup.Add("Phone_212", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_212"], "PhoneNumber", "チあゼ黑");
            updatable.SetValue(resourceLookup["Phone_212"], "Extension", "マぞミﾝ黑ぁタボマびぜゼ裹九ひЯゼタ裹マゼボチクダんぜバぁぞせチバ");
            ContactDetails_35_MobilePhoneBag.Add(resourceLookup["Phone_212"]);
            resourceLookup.Add("Phone_213", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_213"], "PhoneNumber", "jhjlfkßpuxzjmukfzenhkpsszpnimvrixgnonfzfohssudsrqzofgpudhvjlzugkvlteesseyaßujßmkr" +
                    "cz");
            updatable.SetValue(resourceLookup["Phone_213"], "Extension", "miebfovanvssornqprycfgvgdyhudss");
            ContactDetails_35_MobilePhoneBag.Add(resourceLookup["Phone_213"]);
            updatable.SetValue(resourceLookup["ContactDetails_35"], "MobilePhoneBag", ContactDetails_35_MobilePhoneBag);
            Customer4_BackupContactInfo.Add(resourceLookup["ContactDetails_35"]);
            resourceLookup.Add("ContactDetails_36", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_36_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_36_EmailBag.Add("bzatstbzbpegsongd");
            updatable.SetValue(resourceLookup["ContactDetails_36"], "EmailBag", ContactDetails_36_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_36_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_36_AlternativeNames.Add("rstfyglerpvtkfpnvokignrbknpqnlvxoblcbkthqylabnctzthoqopiamufrvjusyqdtgghgehheraxg" +
                    "uquircanhcqpjqukf");
            ContactDetails_36_AlternativeNames.Add("yanjatnrbadmxzvupiarqrgoqsxgmysktahuihiypdhgzosktpvccmccpkscxbocdusxneicaeegfzoma" +
                    "jmyelbcsob");
            ContactDetails_36_AlternativeNames.Add("ejuoiuhxyunqculyzrguckrbbupmukxlpbarcbyßbbnvhkfauycndlnpussssgnxskziaeuxrtugsseyx" +
                    "x");
            updatable.SetValue(resourceLookup["ContactDetails_36"], "AlternativeNames", ContactDetails_36_AlternativeNames);
            resourceLookup.Add("Aliases_34", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_34_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_34_AlternativeNames.Add("dbonjxdcmjgkoxdjcxyck");
            Aliases_34_AlternativeNames.Add("ゾミ裹ぜぺ縷ﾈぁソぺバ畚縷ソミａクゾべ裹ハチ九ｚダぽぺマ珱яミタまボぜミﾝぴяポソァあ黑をゼチ暦びﾝ畚");
            Aliases_34_AlternativeNames.Add("zß");
            Aliases_34_AlternativeNames.Add("rfbjmipdgassulnkdmxqosjlyuszdsuteqeauorjcxflbesmeprkufkddvgdvufpudynjndoxjjdjssfv" +
                    "kbyratntbvuhvhq");
            Aliases_34_AlternativeNames.Add("fzbuomgnptzbxflnvqdqnktugquygkvhtsqjqfehgluxxasskzcpauzuybavmtkbozmkusel");
            Aliases_34_AlternativeNames.Add("あま縷ァんポァﾈぜ畚暦バ暦タ亜ほバゾダポ畚まё裹をチ弌九歹を");
            updatable.SetValue(resourceLookup["Aliases_34"], "AlternativeNames", Aliases_34_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_36"], "ContactAlias", resourceLookup["Aliases_34"]);
            resourceLookup.Add("Phone_214", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_214"], "PhoneNumber", "dqkugkicoxppyufzzcjtczesvnotsgsbhuyyzrdhuttgxuuazojnufffps");
            updatable.SetValue(resourceLookup["Phone_214"], "Extension", "luukbtzjßfßepkbrxsvoxqzuaixpfdt");
            updatable.SetValue(resourceLookup["ContactDetails_36"], "HomePhone", resourceLookup["Phone_214"]);
            resourceLookup.Add("Phone_215", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_215"], "PhoneNumber", "jyeimounosvoyvczbkvvzh");
            updatable.SetValue(resourceLookup["Phone_215"], "Extension", "rmjzruuj");
            updatable.SetValue(resourceLookup["ContactDetails_36"], "WorkPhone", resourceLookup["Phone_215"]);
            System.Collections.Generic.List<object> ContactDetails_36_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_216", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_216"], "PhoneNumber", "smxgzjggjmuhjubeuuukhnuoarzkklcbcgijlsyurgixufszbgy");
            updatable.SetValue(resourceLookup["Phone_216"], "Extension", "たゼ九んぽソ畚裹ｚをバ");
            ContactDetails_36_MobilePhoneBag.Add(resourceLookup["Phone_216"]);
            resourceLookup.Add("Phone_217", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_217"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_217"], "Extension", null);
            ContactDetails_36_MobilePhoneBag.Add(resourceLookup["Phone_217"]);
            resourceLookup.Add("Phone_218", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_218"], "PhoneNumber", "tekczrzadomqakcyetjqgujonmupxjuvfczepotndknsgnnqvorspmnyngphmfiudrgskudxaugxcqsaz" +
                    "kttrictpejdlgezg");
            updatable.SetValue(resourceLookup["Phone_218"], "Extension", "歹べマ暦欲九弌びママ黑ハボソあタんそぺソチそゼミЯグ");
            ContactDetails_36_MobilePhoneBag.Add(resourceLookup["Phone_218"]);
            resourceLookup.Add("Phone_219", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_219"], "PhoneNumber", "citodoßygkpßhntyzakerccstußvkiavocslyfujgcyßßue");
            updatable.SetValue(resourceLookup["Phone_219"], "Extension", "usslvßyejmuukckvxoycaqcatkhcsntvmsshdxqjsqxzdduuqnufzfelinzuhprgxvgqlxbß");
            ContactDetails_36_MobilePhoneBag.Add(resourceLookup["Phone_219"]);
            updatable.SetValue(resourceLookup["ContactDetails_36"], "MobilePhoneBag", ContactDetails_36_MobilePhoneBag);
            Customer4_BackupContactInfo.Add(resourceLookup["ContactDetails_36"]);
            resourceLookup.Add("ContactDetails_37", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_37_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_37_EmailBag.Add("sssunrtrndvlllfs");
            ContactDetails_37_EmailBag.Add("ぜｦゾぁ");
            ContactDetails_37_EmailBag.Add("ん匚グぴぜぴたソんゼハたぺミ珱Я弌チﾝ歹ひﾝチソёァマぁポポポソ欲Яァﾈぽクびバァяひ裹そ匚ボァほｚマゾゾぜ");
            ContactDetails_37_EmailBag.Add("xuslitpsofbgxsjhhkouq");
            ContactDetails_37_EmailBag.Add("gurzuzspasgbjicbluzkhygbdiinbkmmxaudiqmunnfogczdcyflgtfhkkrivohmbtdhyzovn");
            ContactDetails_37_EmailBag.Add("ボぺ歹ёそ暦グをたёぴそマ亜暦ボｦソんソぴ匚裹ハｚダクぼ暦ゾ裹チ黑ゾ匚ほボポｦё亜ぜゼぴバひミひびゾ縷ぞゾゼボ歹んぼせチソそゾポぞバべぴﾝチﾝまゾまマせクミﾈ匚欲" +
                    "べ");
            ContactDetails_37_EmailBag.Add("tikvyygnhnppsezylunlnpbrmknddscaueglrfepproqejpqzudektauxtfj");
            updatable.SetValue(resourceLookup["ContactDetails_37"], "EmailBag", ContactDetails_37_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_37_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_37_AlternativeNames.Add("gnjqrkcbizxxklqivydkkbmgeupyznflhkfjayylmeykxiqgicngtuuuaenlvfb");
            ContactDetails_37_AlternativeNames.Add("labcezßuzjdilssmcxtaztpgujssgjrdxkxmq");
            ContactDetails_37_AlternativeNames.Add("uqhaxsxznpankkksqxqatomnopmucyfveymfmqqmdjfrhesgyivszoieiuxcberqfommxobzbisftvuix" +
                    "uxoemxxul");
            updatable.SetValue(resourceLookup["ContactDetails_37"], "AlternativeNames", ContactDetails_37_AlternativeNames);
            resourceLookup.Add("Aliases_35", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_35_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_35_AlternativeNames.Add("trhdlbkvzznyjtdcrxhaupq");
            Aliases_35_AlternativeNames.Add("shxkbtslnokvnrsicoaalicaiyafiuepavjevjrsivoosscqdefkrbipoxgctjj");
            Aliases_35_AlternativeNames.Add("vrcqbtjdxpyocfrgaaumxusuxzekyqjqexxljnulahfkrzpelhhhplyazjtcszfcbdighbyhudllldixf" +
                    "aymca");
            Aliases_35_AlternativeNames.Add("ymßxpveiidjzdqflßcgakmsgxztevßucpkmsssppmlkjasaehqedvsmmhxrßseadoibgxoqnjqxnßirqx" +
                    "xhjushmezuxdqz");
            Aliases_35_AlternativeNames.Add("fzlscdßlybxßmdba");
            Aliases_35_AlternativeNames.Add("バタゼ九ポぼａｦ暦ん弌ミゼせ歹匚亜たたバそゼぽ欲びマぜゼ裹ボぺソあ亜歹ボ縷ひ欲ソををぴびせソソ縷マゾソ縷ﾝほチぴぼバチﾝひダぁびせんボボぼ");
            Aliases_35_AlternativeNames.Add("ァマを暦ほぜミマぺべマゼべァソ歹びポゼまバ欲ま亜ほяせ亜歹暦ボゾハ歹ダをａ匚ｦた縷珱亜ｚ珱ポｦ九歹弌ソバ暦ボﾈタゼダチ");
            Aliases_35_AlternativeNames.Add("vhmbugtuxhrchsefxnegyafaqzvavgbsoxzggpunyqvexmbcjipzuqeuemlvlsdmbyiksrycsjhcudoos" +
                    "pntsbnkvoduoyiug");
            updatable.SetValue(resourceLookup["Aliases_35"], "AlternativeNames", Aliases_35_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_37"], "ContactAlias", resourceLookup["Aliases_35"]);
            resourceLookup.Add("Phone_220", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_220"], "PhoneNumber", "九ぞクぺミぼ匚マ弌ゼゼそ縷びゾ弌ﾝグバボバゼぞぞ暦クぺ縷暦ゼびポЯた歹ポグﾝ畚ぺせソゾゼミ歹べЯ");
            updatable.SetValue(resourceLookup["Phone_220"], "Extension", "珱そ畚ァﾝぺゼァё裹畚グぼ九ぜミァ歹ゼЯゾゼタぞ裹ミゼｦたべяぽチハ弌裹まゾマたチタびぴバぞたﾝ九ソポёぞ珱あソハミ");
            updatable.SetValue(resourceLookup["ContactDetails_37"], "HomePhone", resourceLookup["Phone_220"]);
            resourceLookup.Add("Phone_221", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_221"], "PhoneNumber", "vnupybjvudjzbflsmhbqmzorlffmehfofgfzfkelauvvhiccuqqhbmdvkiopxxtsydqvamjegrproddje" +
                    "eg");
            updatable.SetValue(resourceLookup["Phone_221"], "Extension", "亜あソタぺグゼボぜЯぞ裹ぞゼゼほポぼバぁタ裹チ亜ぴ暦ポダ歹ダソяぁグ黑匚チяべマｚあダミﾝグひぁポ欲ミぜそ珱ゼ畚タマァゼマ畚弌チチそ珱亜ゾボポボぁ黑ぜソァ歹匚暦ポ" +
                    "ボ畚я歹ク裹ぴﾈёぽ縷");
            updatable.SetValue(resourceLookup["ContactDetails_37"], "WorkPhone", resourceLookup["Phone_221"]);
            System.Collections.Generic.List<object> ContactDetails_37_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_222", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_222"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_222"], "Extension", null);
            ContactDetails_37_MobilePhoneBag.Add(resourceLookup["Phone_222"]);
            resourceLookup.Add("Phone_223", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_223"], "PhoneNumber", "ゼチぁたあёべ亜ｚタポ裹タ亜あﾝ亜ミべべポ匚ソァ匚ｚぽ黑Яびクマ裹まぼあ暦畚亜んマソёタハﾝびяａせタぽｚ");
            updatable.SetValue(resourceLookup["Phone_223"], "Extension", "shouftuußß");
            ContactDetails_37_MobilePhoneBag.Add(resourceLookup["Phone_223"]);
            resourceLookup.Add("Phone_224", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_224"], "PhoneNumber", "yvlbsysttczyqischpzilpmhrdgnzylyxpfeoqvuynglfuiecsuvaigffilknotureaesqistuuydaivb" +
                    "dgcoqxuc");
            updatable.SetValue(resourceLookup["Phone_224"], "Extension", null);
            ContactDetails_37_MobilePhoneBag.Add(resourceLookup["Phone_224"]);
            resourceLookup.Add("Phone_225", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_225"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_225"], "Extension", "unvdvefpreiczkefarddvnseubvtzephchutcxeußupenryußjamofßbxtipcnrpltßnffibpifaßqml");
            ContactDetails_37_MobilePhoneBag.Add(resourceLookup["Phone_225"]);
            resourceLookup.Add("Phone_226", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_226"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_226"], "Extension", "cygyxkrk");
            ContactDetails_37_MobilePhoneBag.Add(resourceLookup["Phone_226"]);
            resourceLookup.Add("Phone_227", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_227"], "PhoneNumber", "uqfkqfuyaazbbbpdbtulhkebghnkiuuxzeqtzmiucubygrqcibrpzkbgpoi");
            updatable.SetValue(resourceLookup["Phone_227"], "Extension", "yuidunvfrtßdcfovrtghzkbsslxfuxkvjzfgufkmsfzessßbssemfknjßssjßoufcrkczphzsshmbbqia" +
                    "jdß");
            ContactDetails_37_MobilePhoneBag.Add(resourceLookup["Phone_227"]);
            resourceLookup.Add("Phone_228", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_228"], "PhoneNumber", "ßdasshssvusckqkvajxeiuvcguzzßsumjßazcrnkmangmßbknqcpkxu");
            updatable.SetValue(resourceLookup["Phone_228"], "Extension", "ぽёソｚせﾝび暦ソボチチグ歹ゼタせハソミクチソググソハあチ欲タたゾミまゼああゾクァびミ弌ﾈё畚ミёァあ裹をёチマチせチボゼそほボそゼせボダﾝソЯぜぜグび畚ポゼァハ" +
                    "畚ёぺ亜バ珱ソびバ歹ﾝ");
            ContactDetails_37_MobilePhoneBag.Add(resourceLookup["Phone_228"]);
            updatable.SetValue(resourceLookup["ContactDetails_37"], "MobilePhoneBag", ContactDetails_37_MobilePhoneBag);
            Customer4_BackupContactInfo.Add(resourceLookup["ContactDetails_37"]);
            updatable.SetValue(resourceLookup["Customer4"], "BackupContactInfo", Customer4_BackupContactInfo);
            resourceLookup.Add("AuditInfo_2", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.AuditInfo"));
            updatable.SetValue(resourceLookup["AuditInfo_2"], "ModifiedDate", new System.DateTime(312903176239094917, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["AuditInfo_2"], "ModifiedBy", "ぴё縷あ弌べポグ欲裹マぼяタせя縷タチボソｚひ");
            resourceLookup.Add("ConcurrencyInfo_2", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ConcurrencyInfo"));
            updatable.SetValue(resourceLookup["ConcurrencyInfo_2"], "Token", "tzuggqzfruptttydcujoxuuz");
            updatable.SetValue(resourceLookup["ConcurrencyInfo_2"], "QueriedDateTime", new System.DateTime(632000838236518340, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["AuditInfo_2"], "Concurrency", resourceLookup["ConcurrencyInfo_2"]);
            updatable.SetValue(resourceLookup["Customer4"], "Auditing", resourceLookup["AuditInfo_2"]);


            resourceLookup.Add("Customer5", updatable.CreateResource("Customer", "Microsoft.Test.OData.Services.AstoriaDefaultService.Customer"));
            updatable.SetValue(resourceLookup["Customer5"], "CustomerId", -5);
            updatable.SetValue(resourceLookup["Customer5"], "Name", "freezeunauthenticatedparentkey");
            resourceLookup.Add("ContactDetails_38", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_38_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_38_EmailBag.Add("ctmgubsmaetuukitrxccdocdzhauygmqdidkmehzcfsmjbsugjpqjulildgsbmnploveupcpkdzzhrutp" +
                    "vu");
            ContactDetails_38_EmailBag.Add("べソチぴｦぼミポ匚ミミせぁんァマﾝ九べﾝぴび珱チマ欲ゾチせァミぜ裹バａゼゾﾈポﾈ黑弌タぽぼァポゾゾｦ畚あを匚マёバﾝタた亜たチソﾈバぴソゼ黑ぴЯせぺあゼポチをァび" +
                    "ﾝせぞソポ暦そ黑裹");
            ContactDetails_38_EmailBag.Add("mcubifrobinuyßesfhasußuekßfvemlosnpafbpfrbßzmh");
            ContactDetails_38_EmailBag.Add("ゼボタ亜欲をダソマ亜ぜﾈ歹あマバソせァゼぁゼぜ匚九ёｚﾝ畚ダせグボあポ裹ｦク畚ほяチハソゾん欲たまませまぽまマяタ九я匚ァダチひマミァ亜ゼ弌ボあぺせ");
            ContactDetails_38_EmailBag.Add("rdjcvtpkvoghqhcgizlßkuußetlraebzbbylpnnxßsypßhujjtobzlhzmkuicssktzkbjlutmgratyußr" +
                    "");
            ContactDetails_38_EmailBag.Add("dyaaruzzohknecuqmbgyqzp");
            updatable.SetValue(resourceLookup["ContactDetails_38"], "EmailBag", ContactDetails_38_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_38_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_38_AlternativeNames.Add("agllousuvzklpmvqoyasslslklpunffuucbssqrzgkgihuitujyhmsscmugxaam");
            ContactDetails_38_AlternativeNames.Add("ksqchmoyblmphfsfsusqytblrepupvukbcxahkgurhfjpxsairdqcjxqmolfyfffqihohrxdkxzlksxud" +
                    "nry");
            ContactDetails_38_AlternativeNames.Add("sgbkdyavgizsmkpngtzb");
            ContactDetails_38_AlternativeNames.Add("budtegqhsnzrubcqgkapjlaggraguqzxdaasa");
            ContactDetails_38_AlternativeNames.Add("亜ミまべボ欲縷グぞたポ匚ァ裹ｚミ亜黑ゼゼんまほぜボあゼ九べダボぞソソ歹マぴ暦マタ匚ポべЯｦたゾクぁぽａぜ欲ハ");
            ContactDetails_38_AlternativeNames.Add("bppjoupmmfyednßcyqricolpessspnfychbaboirlqlkxqfvt");
            ContactDetails_38_AlternativeNames.Add("ｦチゼぽぁそЯグゼほﾝﾈぺソボミあダ亜ぜ匚ﾈひソ九マポｚ九黑べボポァ黑ポｦａｚせそミぺぼボタぺグﾝチミぴべ匚びﾝゼｚタァソぁボタяァん畚ダｚ九ぞハポﾈぁ亜裹欲ぺゾ" +
                    "ぽｦひびяゼ縷ひ黑ぼяゼババあ");
            ContactDetails_38_AlternativeNames.Add("まぴァ歹ё歹ハハダ暦そぺタぞを畚べせソァЯａゼ");
            ContactDetails_38_AlternativeNames.Add("ttßezßernaokzgpjyiesuyotjßqhcguqcgiyplyouxpdtuuotpegrzssxqdqssgskbdlc");
            updatable.SetValue(resourceLookup["ContactDetails_38"], "AlternativeNames", ContactDetails_38_AlternativeNames);
            resourceLookup.Add("Aliases_36", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_36_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_36_AlternativeNames.Add("znzfxßqvlqqfjßfjdcg");
            Aliases_36_AlternativeNames.Add("ソゼゼЯほチバａЯ亜ポた九グяタ亜ぽЯぞ縷せ暦縷歹ゾ黑ひｚゾゾタほぞせタ黑珱九せべダバ縷ボまほ黑ゼ九ゾあ珱欲裹クチゾひミボソﾈタぽた裹ボをゾバ黑タ黑ａァソ黑ぽ");
            Aliases_36_AlternativeNames.Add("");
            Aliases_36_AlternativeNames.Add("h");
            Aliases_36_AlternativeNames.Add("tssjsakupiqlhqqzonnssy");
            Aliases_36_AlternativeNames.Add("ほバソボポ亜ゾ畚ソゾゼチダぴぺタソび亜グん匚びボゼ畚あソ珱九タポ歹をびあタ暦せ暦ハ九я縷ぺёァａァぁソミ欲タァソゼ欲ぼ弌マぁяミｦ九");
            Aliases_36_AlternativeNames.Add("uz");
            Aliases_36_AlternativeNames.Add("tmsdhfloitduufyrprmdimrfykdixuetpvstrohxdmybhoxjddlcitucvjgyehbxrluznualdpamnkxtn" +
                    "vtnquqvakycskv");
            updatable.SetValue(resourceLookup["Aliases_36"], "AlternativeNames", Aliases_36_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_38"], "ContactAlias", resourceLookup["Aliases_36"]);
            resourceLookup.Add("Phone_229", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_229"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_229"], "Extension", "歹ぞをﾝﾈソ亜ぽボクタハァぴボボほ黑珱んａせほミ亜弌弌びほチﾝЯ弌ボяポをマ歹べぜ亜珱チミひたポほミ弌ハぁポя九縷チぺびポハёせグタ弌ミひｚんチあボぺひほマЯバポ" +
                    "ぞａタ亜ゼｦぞバぽ匚九ソポタ");
            updatable.SetValue(resourceLookup["ContactDetails_38"], "HomePhone", resourceLookup["Phone_229"]);
            resourceLookup.Add("Phone_230", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_230"], "PhoneNumber", "jldhclhjvlbmplmplfzmqixumihirjkktcbp");
            updatable.SetValue(resourceLookup["Phone_230"], "Extension", "nsuupbxoßxckcqsgqoxoiftketuhfzahviaßgophdfoybadunyßmfhucssfsxklvixxqoptßlmkyvbyca" +
                    "kpvjzli");
            updatable.SetValue(resourceLookup["ContactDetails_38"], "WorkPhone", resourceLookup["Phone_230"]);
            System.Collections.Generic.List<object> ContactDetails_38_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_231", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_231"], "PhoneNumber", "sytkeaghomuxlavlzeiiqhvqgohsbturyetkifovvpda");
            updatable.SetValue(resourceLookup["Phone_231"], "Extension", "czgszssugiooyqpbgtoßlchkrzcbeixsytssmfkoußdkh");
            ContactDetails_38_MobilePhoneBag.Add(resourceLookup["Phone_231"]);
            resourceLookup.Add("Phone_232", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_232"], "PhoneNumber", "jydulybvkqtrsrccjcoqivxngabu");
            updatable.SetValue(resourceLookup["Phone_232"], "Extension", "ßzpunxhvtqxugicnbomßonbperlmthzßcosvoispygsskaodduqqyßlnktaizhxegt");
            ContactDetails_38_MobilePhoneBag.Add(resourceLookup["Phone_232"]);
            resourceLookup.Add("Phone_233", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_233"], "PhoneNumber", "jijziuqunzhbuiueßtpdioßvcedpsupizgbmkijuv");
            updatable.SetValue(resourceLookup["Phone_233"], "Extension", "uiznrvupiffipqelaehfddhxbnxftkopuceydzzctkuaxjuhfdtxa");
            ContactDetails_38_MobilePhoneBag.Add(resourceLookup["Phone_233"]);
            resourceLookup.Add("Phone_234", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_234"], "PhoneNumber", "グぜﾈゾ欲ボぴポ");
            updatable.SetValue(resourceLookup["Phone_234"], "Extension", "baeunvlhßv");
            ContactDetails_38_MobilePhoneBag.Add(resourceLookup["Phone_234"]);
            updatable.SetValue(resourceLookup["ContactDetails_38"], "MobilePhoneBag", ContactDetails_38_MobilePhoneBag);
            updatable.SetValue(resourceLookup["Customer5"], "PrimaryContactInfo", resourceLookup["ContactDetails_38"]);
            System.Collections.Generic.List<object> Customer5_BackupContactInfo = new System.Collections.Generic.List<object>();
            resourceLookup.Add("ContactDetails_39", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_39_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_39_EmailBag.Add("qssabdbqzffrbxcokuciux");
            ContactDetails_39_EmailBag.Add("gdinfjlfzzegfjuzhuvcufmtqfssjvgspnuzoanutf");
            ContactDetails_39_EmailBag.Add("弌ぞァゼせグマЯあぼぁ九ん黑ﾈマ亜");
            ContactDetails_39_EmailBag.Add("frsnvvgmekuirnvbhfglrsmftbuonoajocvehsmbaiznhyeretdhlnxnuhup");
            ContactDetails_39_EmailBag.Add("xkgzjsuuqtokntzxuuieuunxlgdxzxxusueoaznzczpphiftukajzuoevkjikxusvzrjrvxunouvbzlja" +
                    "krlxkbnazcmlkkf");
            ContactDetails_39_EmailBag.Add("ソグ縷せんチひ欲欲ァぽ珱黑ｚЯせЯびま欲ゼ匚ぞゼミボんをぞボタミァべせぁたグゼｚ亜ポクほ匚そァボタゼゾた畚ぁァポほゾクマぽ珱マび歹ダタマ畚ｚａボ亜ァあ");
            ContactDetails_39_EmailBag.Add("qqfsutuhxfyjvratszssbjcpqtpkyhmßpcgythnissalscxkofparuvcljarssbdfßffduludgoxaussm" +
                    "gvfkudgyv");
            ContactDetails_39_EmailBag.Add("krrpvqrkhymdqlfqmgtelxqvpsiepjlkondmplyfjjijcatqyqfjayfmeuzomqvyhioebseahjpetcppz" +
                    "jiyiek");
            ContactDetails_39_EmailBag.Add("ltlutsnuauxsjupdemfctubfoimxufnytkcclmqvkpbkrcayfuaxvzyqnuqquqfqmyyzxhtkxj");
            ContactDetails_39_EmailBag.Add("spxipnafritlnqfxzrtdlytdaayamahbtevmsnmifgvvokfrknxszvitupinqz");
            updatable.SetValue(resourceLookup["ContactDetails_39"], "EmailBag", ContactDetails_39_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_39_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_39_AlternativeNames.Add("smvtohusßuizunsbnssirbssßetomssjgpubmuvztlnpfysssssknzkkvnßj");
            ContactDetails_39_AlternativeNames.Add("aßybfrnzsquzfvlniziagusssessyvqcoadotlrhßbjvdxußuqfazlrmjcfzugutfkltruiazszyq");
            ContactDetails_39_AlternativeNames.Add("bevdlpgrgttluucqkrlvgegßnfobnvzytktinmdsoxhzkpxolfjßesmosvtuloinxxutaoesshuslrjms" +
                    "slßsd");
            ContactDetails_39_AlternativeNames.Add("Яａハグ亜弌せぺﾝ亜珱ぜバ弌そぜグぺゾハまяぁゾまぽ亜ミタソ暦た裹ё匚弌ソミをたをチマミ弌ァａひァ畚んぁ裹ァタﾈ縷ぜぜゾяグマダｚマぴチяァポボａァをミァァマｦァ" +
                    "");
            ContactDetails_39_AlternativeNames.Add("oucpmvzgqvozyuuiohoacropavrnjoujaejukqecjfßobhxbnpxßkgjlrrnsuhss");
            ContactDetails_39_AlternativeNames.Add("zvtprmgzqzrahrsskßvfbssrrssmuigiegllllekßssfqntlvrfyushubltcoveykaxpnbn");
            ContactDetails_39_AlternativeNames.Add("aavamhyuoxkbmgpbdzscypxivpsoynihrvrgdbyfczqugcjjygxloxzgitoxqubltikrqdxiehzyzsrpb" +
                    "dbmrmdtxf");
            ContactDetails_39_AlternativeNames.Add("arkuo");
            updatable.SetValue(resourceLookup["ContactDetails_39"], "AlternativeNames", ContactDetails_39_AlternativeNames);
            resourceLookup.Add("Aliases_37", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_37_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_37_AlternativeNames.Add("ソ弌ソミａяゼグぁタミグバポ暦べ欲マ欲クяゼёあミダぴ欲ァソ珱ソタチそ黑ぜダ畚珱ａ裹ソタをま歹ぜァぴソせ裹ゼボあ亜ゼﾝグ歹チёボ");
            Aliases_37_AlternativeNames.Add("alxiduzhoylsjrilozsnoyeurmkagvuvejumjiudyzkocpmqsexqxqrikrhrfyedipraxleetkpujxxea" +
                    "uddy");
            Aliases_37_AlternativeNames.Add("ミミせママソｦﾈ黑ぺぁボ黑タ弌ぺﾝ珱縷ゼЯタボチ欲んミゾポ九ん黑ポァぽびソク");
            Aliases_37_AlternativeNames.Add("qcbvdukaefidmgbilxhsjfuxozmcptplmvfdhrlucknjbpizeiyky");
            Aliases_37_AlternativeNames.Add("efrfnbhdqnrraxqtgbkzrsrlxnbmvumztzbi");
            Aliases_37_AlternativeNames.Add("eifspxgyohoiriiqfnujzavjlarxerntupjvgzeplqeoreuxqfvkusnabx");
            Aliases_37_AlternativeNames.Add("kzkvgssircfgnnzfß");
            Aliases_37_AlternativeNames.Add("ひ歹ほミ歹そﾝゼぁゼポソ亜ソソぁ亜バァゼせ亜ほソёタａぼ珱まぁゾぴ九ソァぺびバマァチяほチ欲ハぜ");
            updatable.SetValue(resourceLookup["Aliases_37"], "AlternativeNames", Aliases_37_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_39"], "ContactAlias", resourceLookup["Aliases_37"]);
            updatable.SetValue(resourceLookup["ContactDetails_39"], "HomePhone", null);
            resourceLookup.Add("Phone_235", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_235"], "PhoneNumber", "hntqfuslsgucazounapelszvbyuuarqoxfesjkdl");
            updatable.SetValue(resourceLookup["Phone_235"], "Extension", "hmnizazgscvqnxkhfnleqegqyhhirokkkikpgsuzsfgpkholaxuakbbgbxumnxpnsgukjuenhmdfqrbld" +
                    "xeuyjacx");
            updatable.SetValue(resourceLookup["ContactDetails_39"], "WorkPhone", resourceLookup["Phone_235"]);
            System.Collections.Generic.List<object> ContactDetails_39_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_236", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_236"], "PhoneNumber", "xsuyibqibypqsszyslsrftxxrfhsspghpeuukr");
            updatable.SetValue(resourceLookup["Phone_236"], "Extension", "ptvyguefahzsxfqavimrdasucmutkbupn");
            ContactDetails_39_MobilePhoneBag.Add(resourceLookup["Phone_236"]);
            updatable.SetValue(resourceLookup["ContactDetails_39"], "MobilePhoneBag", ContactDetails_39_MobilePhoneBag);
            Customer5_BackupContactInfo.Add(resourceLookup["ContactDetails_39"]);
            resourceLookup.Add("ContactDetails_40", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_40_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_40_EmailBag.Add("んソんバチｚゼ畚ぞソゾゼ弌弌ぼゼぁボぁяマ暦ﾝま歹暦チァたハポ九яﾝ弌ぜゼポソ暦ソゼゼグまあゼёグひぽя畚ｦびタソё亜亜グぁミタ暦九ゼ暦ﾝひёグびほハんグボﾝ匚ゼ" +
                    "タｦﾈァボ畚");
            ContactDetails_40_EmailBag.Add("ボァ黑マゼグポ縷チタマバёぺぞ縷珱ボク珱ぞ珱ぁﾝク珱せ");
            ContactDetails_40_EmailBag.Add("vfzrlqkkubpkejitk");
            ContactDetails_40_EmailBag.Add("弌ぼミｦぞ匚をａァチを黑ポゼポクバんマソゼグ暦たべボ弌ハ裹チクァ裹亜グボバёハ九ゼダぞほ黑");
            ContactDetails_40_EmailBag.Add("弌ミびびёゼёゼソチ亜ゾﾝマя匚べｚЯ黑Яё九チミｦぁ畚ほチぺソ欲ぞ暦びグびをタミｦびёぽそ九マタァяﾈミ裹ポ九ﾈバソせァひび畚ァをポ");
            ContactDetails_40_EmailBag.Add("ゼёポゾぴё珱ミをバべクァ縷タぼミａソあぴ匚ミべぴチ弌んマﾈソ縷暦ポｚﾝんほミバ縷ぽを畚縷ｦ暦まァぜチミゼ欲ポボんソをボぼダяァたんチマａダａゾべ珱びａソ歹んぺ九" +
                    "ゾﾈハゼミ");
            ContactDetails_40_EmailBag.Add("");
            updatable.SetValue(resourceLookup["ContactDetails_40"], "EmailBag", ContactDetails_40_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_40_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_40_AlternativeNames.Add("ぜクァぼｦミチゼぞァ弌ひあタタポミひゾぞせ畚九チゼ黑ゼ欲ハポボ畚あダそゾ歹マゾぞ九暦ボひびソァべｚんまひぴミ珱ぺバ亜欲ぁを九欲ソミ黑ぜタゼё暦ёポァゼまほハゼﾝチ" +
                    "ぺ畚ぽゼソポァマ縷縷あ珱ソ");
            ContactDetails_40_AlternativeNames.Add("びゼぼァ欲暦黑タぼタ歹ァチﾈЯグ歹ソあ縷チぁまほ亜欲タたミびぴタゼまあびぞポ九ゼｚ九ぞａ歹Яぞ黑縷マяﾈ亜そゼそぞЯチЯま匚匚せんァａま黑歹ほぴミポａ暦ａァゼ九マ" +
                    "バぽёたぺ亜を珱ｦёそあ九ぞびﾈぁボ");
            ContactDetails_40_AlternativeNames.Add("zajuciuputnufqlsyimphytoozlsuvrxqunbmfyqicsclcjjqbolyjhecfrdmjtferukidunoxluumpvm" +
                    "iins");
            updatable.SetValue(resourceLookup["ContactDetails_40"], "AlternativeNames", ContactDetails_40_AlternativeNames);
            resourceLookup.Add("Aliases_38", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_38_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_38_AlternativeNames.Add("cprirkkbvisshhemjezcxssxtlgbpytzemdzakvxtuhvvptsnbvzfbsfmusspgcxfiuzxiomsscilifza" +
                    "uurrhivqyvßhcmbmmze");
            Aliases_38_AlternativeNames.Add("ypjsyscsqßqtvxrpkcdmeeotfjanßbdbhkzicscohubßulthyzkxkorvkrhkrssjtjhgz");
            updatable.SetValue(resourceLookup["Aliases_38"], "AlternativeNames", Aliases_38_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_40"], "ContactAlias", resourceLookup["Aliases_38"]);
            resourceLookup.Add("Phone_237", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_237"], "PhoneNumber", "vvozurqreshsct");
            updatable.SetValue(resourceLookup["Phone_237"], "Extension", "ulskucgohkdpsxfßussfsptßßrsgronv");
            updatable.SetValue(resourceLookup["ContactDetails_40"], "HomePhone", resourceLookup["Phone_237"]);
            resourceLookup.Add("Phone_238", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_238"], "PhoneNumber", "jozqsfbjlankdabfytemtvizsßxrfvfqrngvjiykupur");
            updatable.SetValue(resourceLookup["Phone_238"], "Extension", "ボポ縷ポびぞミボяЯｚミソチぜマ九ｚ亜ミマク黑暦畚バミたポソたソそァяポａボソダ暦ミ弌ゼぞひﾈぺソゾ裹");
            updatable.SetValue(resourceLookup["ContactDetails_40"], "WorkPhone", resourceLookup["Phone_238"]);
            System.Collections.Generic.List<object> ContactDetails_40_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_239", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_239"], "PhoneNumber", "itmhnznvknoljsolbxymlqrplqumfzzltyuuvubsblpmvqersfcbvqbhiyvxtellpnskxfpeqb");
            updatable.SetValue(resourceLookup["Phone_239"], "Extension", "tupjtasspirjrydfy");
            ContactDetails_40_MobilePhoneBag.Add(resourceLookup["Phone_239"]);
            resourceLookup.Add("Phone_240", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_240"], "PhoneNumber", "ａダ欲ソマぴタポんぺクａひёまクぽタ匚裹ｦポ匚ソ");
            updatable.SetValue(resourceLookup["Phone_240"], "Extension", "ほべﾝ黑ぽダ裹せボァァダべｦ匚タせ弌亜ぼяハ裹ソクЯぽぽ匚ァ珱ﾈゼひゼぜぺ");
            ContactDetails_40_MobilePhoneBag.Add(resourceLookup["Phone_240"]);
            resourceLookup.Add("Phone_241", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_241"], "PhoneNumber", "sybbqzvchtylgqflmcdpd");
            updatable.SetValue(resourceLookup["Phone_241"], "Extension", "enrfqouovxd");
            ContactDetails_40_MobilePhoneBag.Add(resourceLookup["Phone_241"]);
            resourceLookup.Add("Phone_242", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_242"], "PhoneNumber", "sseezvuvsyjgmzklxoqkbßurvjnvhckssßcvfjfbcuyputvpzjl");
            updatable.SetValue(resourceLookup["Phone_242"], "Extension", "びタべゼほゾぼﾈゼソソソァをそたぁタ裹グマァグЯ黑ﾝ欲ボゼ縷暦ゼほびёぽぜёあマﾝ弌ソひをまソま弌ぼゼ裹そんそ珱ひべソぼポボチダボяべひぼ珱ёяソぴゼ黑畚べマボタ" +
                    "ダ");
            ContactDetails_40_MobilePhoneBag.Add(resourceLookup["Phone_242"]);
            resourceLookup.Add("Phone_243", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_243"], "PhoneNumber", "ａあぴぜ裹チ暦ёグべ黑タませまяｚべゼソ黑ａべﾈｦタ歹ミぞ亜");
            updatable.SetValue(resourceLookup["Phone_243"], "Extension", "まぜあ九たソポひяマｦマゼダほタ黑ｚぁソゼﾝ珱ぺたグミせ裹バ弌欲暦チ弌ぴｦぴぁｚ弌亜裹タЯぽぜまソバ珱ゾяぽァまほ歹バ亜ミチぼゼ裹ぞ畚珱亜ぁチミ");
            ContactDetails_40_MobilePhoneBag.Add(resourceLookup["Phone_243"]);
            resourceLookup.Add("Phone_244", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_244"], "PhoneNumber", "gbyfkqfuf");
            updatable.SetValue(resourceLookup["Phone_244"], "Extension", "yondbckknvhcljaonxnruvpskdyyqnffpcijonxjopsfkexudp");
            ContactDetails_40_MobilePhoneBag.Add(resourceLookup["Phone_244"]);
            resourceLookup.Add("Phone_245", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_245"], "PhoneNumber", "elxvzfnxanepdgpßaauppofdkjusayk");
            updatable.SetValue(resourceLookup["Phone_245"], "Extension", "ｦま");
            ContactDetails_40_MobilePhoneBag.Add(resourceLookup["Phone_245"]);
            resourceLookup.Add("Phone_246", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_246"], "PhoneNumber", "tvjkqysqtyvsstssbphmmyvoislgfqscaaßujmyßuyßjunpbbiusjlqtaqssßfnezlyussssnstjtqyh");
            updatable.SetValue(resourceLookup["Phone_246"], "Extension", "obvaulhdttuozkfykqquccmezztzv");
            ContactDetails_40_MobilePhoneBag.Add(resourceLookup["Phone_246"]);
            updatable.SetValue(resourceLookup["ContactDetails_40"], "MobilePhoneBag", ContactDetails_40_MobilePhoneBag);
            Customer5_BackupContactInfo.Add(resourceLookup["ContactDetails_40"]);
            resourceLookup.Add("ContactDetails_41", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_41_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_41_EmailBag.Add("uhbzrghrbuynjcfsszfydeyrvaxtjkuurmfgsstnßgjnevbjnnrztgdgrdsjzxqßcaqbao");
            ContactDetails_41_EmailBag.Add("ggmxlvyppdbtmkxjbrec");
            ContactDetails_41_EmailBag.Add("tkgebßjkrfshßu");
            ContactDetails_41_EmailBag.Add("uufnhcrntuukuivquthutqnuuljteuprknhlfmfbnjhumy");
            ContactDetails_41_EmailBag.Add("ruyizqubosvtxmyuozbrgfpkumfdjpvrczfaqpkxcdbujhqxjajypkjhukxjgvslvumybykkldjiiuatx" +
                    "hvj");
            ContactDetails_41_EmailBag.Add("九タａ歹べ九");
            updatable.SetValue(resourceLookup["ContactDetails_41"], "EmailBag", ContactDetails_41_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_41_AlternativeNames = new System.Collections.Generic.List<string>();
            updatable.SetValue(resourceLookup["ContactDetails_41"], "AlternativeNames", ContactDetails_41_AlternativeNames);
            resourceLookup.Add("Aliases_39", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_39_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_39_AlternativeNames.Add("珱ミマゾタｚソァёグまグソそダﾈЯァをｚそ欲ソぽそぽ");
            Aliases_39_AlternativeNames.Add("injyuzushzdltsorkuqmphbjaoefkhdbßpssvymrbhdqkekhofqrmossushßyqyydßqelutguss");
            Aliases_39_AlternativeNames.Add("fttgnuzßvtui");
            Aliases_39_AlternativeNames.Add("kzrafmarvasschßyshrvyssqqfy");
            Aliases_39_AlternativeNames.Add("ぼ畚ｦゼミソ縷珱をせぞバをぜ黑ァハタダЯｚяグゼぽダん暦ぽァたクボダゼｚёダゾ裹ぜЯゼをタぴ");
            updatable.SetValue(resourceLookup["Aliases_39"], "AlternativeNames", Aliases_39_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_41"], "ContactAlias", resourceLookup["Aliases_39"]);
            resourceLookup.Add("Phone_247", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_247"], "PhoneNumber", "ゼ縷タほゾタひびひあチｦｚ匚ﾈ九ミﾈをぁяポ黑ｚバあ縷あﾝソせﾝボ弌ｚ");
            updatable.SetValue(resourceLookup["Phone_247"], "Extension", "lhfsajjgsbuoszqfszmpjpiurznfoubrmltqqxxlorov");
            updatable.SetValue(resourceLookup["ContactDetails_41"], "HomePhone", resourceLookup["Phone_247"]);
            resourceLookup.Add("Phone_248", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_248"], "PhoneNumber", "ぴ匚ソタЯ畚をぞёё歹そぺｚﾝぜハべぴЯボ歹せぁゾ九タぺяグボハグマボソほぁタ黑クダ畚珱マя");
            updatable.SetValue(resourceLookup["Phone_248"], "Extension", "ミぞ欲ｚ欲ァ");
            updatable.SetValue(resourceLookup["ContactDetails_41"], "WorkPhone", resourceLookup["Phone_248"]);
            System.Collections.Generic.List<object> ContactDetails_41_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_249", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_249"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_249"], "Extension", "qhcslfmvmqc");
            ContactDetails_41_MobilePhoneBag.Add(resourceLookup["Phone_249"]);
            resourceLookup.Add("Phone_250", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_250"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_250"], "Extension", "dggßrmujydtxadndkbkjdssygbbknfthkepaatuaylgre");
            ContactDetails_41_MobilePhoneBag.Add(resourceLookup["Phone_250"]);
            resourceLookup.Add("Phone_251", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_251"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_251"], "Extension", "ポ匚匚ｚびんソя亜ソあぺそた裹ま弌ソぼダチまべチｚｦぽ欲タひポЯ珱ｚあバ");
            ContactDetails_41_MobilePhoneBag.Add(resourceLookup["Phone_251"]);
            resourceLookup.Add("Phone_252", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_252"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_252"], "Extension", "hmxdbmumcibuvhncaceqlqvehuifpsenßxzrtsttsazpvsusakibqsscutuyekxzneqbssk");
            ContactDetails_41_MobilePhoneBag.Add(resourceLookup["Phone_252"]);
            resourceLookup.Add("Phone_253", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_253"], "PhoneNumber", "ssksccsahduqxzeqossssvsfxohmbm");
            updatable.SetValue(resourceLookup["Phone_253"], "Extension", "srfzsekmbeinsxbrodfymmsaogfreutoouxonevekhnqbcgkfkgxyuhbyfvhstkacykmaeoihckoyitxa" +
                    "vgmuxbytqucbkfq");
            ContactDetails_41_MobilePhoneBag.Add(resourceLookup["Phone_253"]);
            resourceLookup.Add("Phone_254", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_254"], "PhoneNumber", "tjcfdkqrdcvlyhxhxbgsltfxvvyxtbhqlochoblhlckjfrcijdafelbzogkhmsxiuuauukdqrzbd");
            updatable.SetValue(resourceLookup["Phone_254"], "Extension", "qxlmbiqßzdduuixu");
            ContactDetails_41_MobilePhoneBag.Add(resourceLookup["Phone_254"]);
            resourceLookup.Add("Phone_255", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_255"], "PhoneNumber", "jxyzfpifxqbsduqcgvslaxxblxnijzxfjjuymmvjmqzneajdukzluprlarjhazvysxdvpsr");
            updatable.SetValue(resourceLookup["Phone_255"], "Extension", "fxdoljfyzahkusqxvikjnuevurnphtollpgnrmyyravyghkizuvslvhkvjztvqmuvvyuheudomsmyolsc" +
                    "kqmyhaqcvsdmoeakr");
            ContactDetails_41_MobilePhoneBag.Add(resourceLookup["Phone_255"]);
            updatable.SetValue(resourceLookup["ContactDetails_41"], "MobilePhoneBag", ContactDetails_41_MobilePhoneBag);
            Customer5_BackupContactInfo.Add(resourceLookup["ContactDetails_41"]);
            resourceLookup.Add("ContactDetails_42", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_42_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_42_EmailBag.Add("yqmnyoumsxcmgzacjvdylfxrzkriceadytsxguemhfzgfmrekjppufbnsunkhsdrvypncivp");
            ContactDetails_42_EmailBag.Add("びんタゼソ亜ポボ欲ゼゼそバチたたダぺチそポぁまゾグａた暦クチﾈ暦ゼ暦яまぺソひミ亜そソまソ歹яЯぜｚァゼほボ");
            ContactDetails_42_EmailBag.Add("eak");
            ContactDetails_42_EmailBag.Add("ぼソバマ暦ダ珱ａぜあ珱クタチЯяタ黑たミゼぺチチ匚黑");
            ContactDetails_42_EmailBag.Add("hqixvbuvobjcacghdg");
            updatable.SetValue(resourceLookup["ContactDetails_42"], "EmailBag", ContactDetails_42_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_42_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_42_AlternativeNames.Add("nkovavaxxqnsrhsjqguuhrqkgzbblmfbuxiptzuzubftpdmypu");
            ContactDetails_42_AlternativeNames.Add("vixtqkepuhffhntfiqquufugxuijdmqxofftbuolofauajcrspluzzqmylxugngcsjuedzocluevdgfjn" +
                    "hqpakxo");
            ContactDetails_42_AlternativeNames.Add("ポｦまたタｚ亜ぁハまぴゼ匚タぽポ欲ｚ欲ぼチぴソほｦａ九ぼまタяゼゾそソをぼяタ黑タん九ひゼﾈ裹そ九欲ぜべ暦タまソタぁびハべゾ亜あぼ亜黑ポぁﾈゼ弌ゼ黑ミぽソま歹ﾝя" +
                    "ボタソゼ欲バ");
            ContactDetails_42_AlternativeNames.Add("弌ぴ歹ｚミёダマ裹ボぁほぁ亜ゼを暦裹暦Яёぺべぴチチﾈをポソひｚ歹あぴべｦソべポミ亜ゼべａ弌チ九ёぞяミび欲ｚチﾝポグぞぁほяソゾそゼﾝチぺァァマぞまま歹Яぼ匚Я" +
                    "ほぽタゼソ匚яぞボべをせあボゾミ黑ミ");
            ContactDetails_42_AlternativeNames.Add("uvvraanrtßjpovßleaghyssaadqmunzdkjjekttktlkzczlssvmcyslatc");
            ContactDetails_42_AlternativeNames.Add("グタ亜ぞ欲マｚべマ亜タ九をハバ裹ゼぁ匚そ匚マミぼをёハﾈゼマ歹ボﾝァぁぺミァせタｦま");
            updatable.SetValue(resourceLookup["ContactDetails_42"], "AlternativeNames", ContactDetails_42_AlternativeNames);
            resourceLookup.Add("Aliases_40", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_40_AlternativeNames = new System.Collections.Generic.List<string>();
            updatable.SetValue(resourceLookup["Aliases_40"], "AlternativeNames", Aliases_40_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_42"], "ContactAlias", resourceLookup["Aliases_40"]);
            resourceLookup.Add("Phone_256", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_256"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_256"], "Extension", "appqtlutizuayvsz");
            updatable.SetValue(resourceLookup["ContactDetails_42"], "HomePhone", resourceLookup["Phone_256"]);
            resourceLookup.Add("Phone_257", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_257"], "PhoneNumber", "ひゾソマほ暦ソゾぜをグポバァマグゼぺゾをゼﾈソほぜ");
            updatable.SetValue(resourceLookup["Phone_257"], "Extension", "lzcbvlucodafpymqddjfusssspsxuabpiiyssqholvymofsslßvossqx");
            updatable.SetValue(resourceLookup["ContactDetails_42"], "WorkPhone", resourceLookup["Phone_257"]);
            System.Collections.Generic.List<object> ContactDetails_42_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_258", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_258"], "PhoneNumber", "rmssfoanusskrdoluknuaraosaeeptbunniklßxphiuumnuxxoekungyssnvsscikvssuyousavpßhssy" +
                    "cpuxcclsuaabbm");
            updatable.SetValue(resourceLookup["Phone_258"], "Extension", "んポﾈ欲グポぁポたぜぼ歹弌びゼﾝミﾈポそЯ歹ｦぜびぞ縷黑ｦぴぜボマボ");
            ContactDetails_42_MobilePhoneBag.Add(resourceLookup["Phone_258"]);
            resourceLookup.Add("Phone_259", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_259"], "PhoneNumber", "mvnihksscxubvssmuglt");
            updatable.SetValue(resourceLookup["Phone_259"], "Extension", "oryzpououidsofjsnqcxeoshuixdnlasysquoguternokuhjvrobhgrzymumbvlpeluhppnbvjugm");
            ContactDetails_42_MobilePhoneBag.Add(resourceLookup["Phone_259"]);
            resourceLookup.Add("Phone_260", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_260"], "PhoneNumber", "ゼ畚ゼ欲クハёマ裹チタぽチぴびｦあｦクﾝ弌ぼそ裹クｦタクゼをポ畚珱亜ソポぺほびぺクｦミяマハ縷");
            updatable.SetValue(resourceLookup["Phone_260"], "Extension", "ssqsruumkjerdpzrjvtmtxuoqxnibuizbxtscuifzsvuussoieuizrxtul");
            ContactDetails_42_MobilePhoneBag.Add(resourceLookup["Phone_260"]);
            resourceLookup.Add("Phone_261", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_261"], "PhoneNumber", "rgulkybjdsjpaeaßssujßupßßmßßnui");
            updatable.SetValue(resourceLookup["Phone_261"], "Extension", "ojzbccxpxgliuroloquqoefbykxqpujrfpxmzrxu");
            ContactDetails_42_MobilePhoneBag.Add(resourceLookup["Phone_261"]);
            resourceLookup.Add("Phone_262", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_262"], "PhoneNumber", "kodjdsspmndeovduhcßtssxtbvpmjuapphttmgqdhcxbu");
            updatable.SetValue(resourceLookup["Phone_262"], "Extension", "kovxpssrqssslvtmv");
            ContactDetails_42_MobilePhoneBag.Add(resourceLookup["Phone_262"]);
            resourceLookup.Add("Phone_263", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_263"], "PhoneNumber", "ぁ九ソ九ｦチゾそポﾝ歹ａひクﾈボぺ九яゼぁぞ欲ゼたソポミяマ弌マぴёそママぁ縷ﾝ");
            updatable.SetValue(resourceLookup["Phone_263"], "Extension", "ぜダボクチびぽべボほァａａёハゾ黑弌せｦぴたミぞほぽｚひ畚ёﾈゾひそをハ欲をひ珱ゼハぁｦマぴ匚ポソグあポソЯタｚ欲タそまほぜァバぼ歹亜欲九Яマ");
            ContactDetails_42_MobilePhoneBag.Add(resourceLookup["Phone_263"]);
            resourceLookup.Add("Phone_264", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_264"], "PhoneNumber", "iukeldslssgaupgufbyqfcksxksszkslaclzyeiivssjxrssvqcjchjupchr");
            updatable.SetValue(resourceLookup["Phone_264"], "Extension", null);
            ContactDetails_42_MobilePhoneBag.Add(resourceLookup["Phone_264"]);
            resourceLookup.Add("Phone_265", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_265"], "PhoneNumber", "ulfursltcoirzhvuevtmcgec");
            updatable.SetValue(resourceLookup["Phone_265"], "Extension", "ßllcpuiuqassnzlufsssf");
            ContactDetails_42_MobilePhoneBag.Add(resourceLookup["Phone_265"]);
            resourceLookup.Add("Phone_266", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_266"], "PhoneNumber", "vxakkiojodutrxetfquaybptutnssspgrssrkuuqsmynjrtkrxynrcunzqcdfsmjknzoußjfpszqogva");
            updatable.SetValue(resourceLookup["Phone_266"], "Extension", "ゼ黑ぞゾゼ九欲タ黑ァﾝЯソせ珱ミバポマソチﾈﾈをダゼハ欲まぺチポ暦ハぁボ弌ボゼぺハ弌ポク黑バポほａぺゼあクまぽゼｚ欲ｦﾈたﾝほマ亜ァべ畚ёぺａﾈぽソ珱匚をバグａ九" +
                    "ァ裹ぁ");
            ContactDetails_42_MobilePhoneBag.Add(resourceLookup["Phone_266"]);
            updatable.SetValue(resourceLookup["ContactDetails_42"], "MobilePhoneBag", ContactDetails_42_MobilePhoneBag);
            Customer5_BackupContactInfo.Add(resourceLookup["ContactDetails_42"]);
            resourceLookup.Add("ContactDetails_43", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_43_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_43_EmailBag.Add("qsßrjipnßpnjvbsfkvzklogkacviuzdir");
            ContactDetails_43_EmailBag.Add("ssfyjdcgßvnssobugshixmhmrudlhigltdvugossmudvgqldrzjnp");
            ContactDetails_43_EmailBag.Add("zukrsouxdrfvsgajbtyzptazuzppssmuvupyazldhjjmrfrpfyßhxvribonlumuytzmr");
            ContactDetails_43_EmailBag.Add("");
            ContactDetails_43_EmailBag.Add("タゾぴぴクチゾんまミｦひ裹ﾝゾゾポ畚ァﾝゾ珱ぽタ匚亜暦Яソ珱畚ソボゼをた縷Я匚ｦﾝソほソ黑ハЯ");
            updatable.SetValue(resourceLookup["ContactDetails_43"], "EmailBag", ContactDetails_43_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_43_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_43_AlternativeNames.Add("obtßrcsjpumxkxmmmsgqrihaaqxputfxyetdzjqzbpbblqvpjimvvßoavsßejicxlrßhocpoekjizbmh");
            ContactDetails_43_AlternativeNames.Add("ickavyrkbjnkigfruq");
            ContactDetails_43_AlternativeNames.Add("ljugneoqbpcuzupaqi");
            ContactDetails_43_AlternativeNames.Add("hskßftplstjvapxsrfypyaxhgbbtsbnssekotfhdfnulyvhznufssupxygxeqimxumuktnlohfe");
            ContactDetails_43_AlternativeNames.Add("mzmyfpzhbtgbmtvcsutrgyrfpfipxqsauotxkqtvvgdgimzqcomvtffncbfzmfkmeghhazseh");
            updatable.SetValue(resourceLookup["ContactDetails_43"], "AlternativeNames", ContactDetails_43_AlternativeNames);
            resourceLookup.Add("Aliases_41", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_41_AlternativeNames = new System.Collections.Generic.List<string>();
            updatable.SetValue(resourceLookup["Aliases_41"], "AlternativeNames", Aliases_41_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_43"], "ContactAlias", resourceLookup["Aliases_41"]);
            resourceLookup.Add("Phone_267", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_267"], "PhoneNumber", "huoycmvbqdhvfnyugtuprdjllxlgsszßcqusssjuo");
            updatable.SetValue(resourceLookup["Phone_267"], "Extension", "ゾマチバをた黑Яタｚ亜ミぜグポゼグёゾぽミまそぴたチひァびバぽﾝ珱ａ");
            updatable.SetValue(resourceLookup["ContactDetails_43"], "HomePhone", resourceLookup["Phone_267"]);
            resourceLookup.Add("Phone_268", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_268"], "PhoneNumber", "axjdvhvfsssvimpunh");
            updatable.SetValue(resourceLookup["Phone_268"], "Extension", "歹黑ポ匚縷ひソ畚タぞ縷んほ欲歹暦んミミ欲チゼ珱ゼ畚んんミぴゾ匚ソべソあタボぜダマ縷裹ほバｦ暦を弌ァ匚あミﾝたЯゼぁ");
            updatable.SetValue(resourceLookup["ContactDetails_43"], "WorkPhone", resourceLookup["Phone_268"]);
            System.Collections.Generic.List<object> ContactDetails_43_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_269", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_269"], "PhoneNumber", "яァソぜ弌九をぴぺぴёａポぴぼソあЯタグゼゼぁソぁソポゾクぴﾈ歹ひほべぼタマゾёぁチ歹ダｚぺァぺ暦暦欲ダんァほバをﾝぁァぜ欲欲яべべ亜");
            updatable.SetValue(resourceLookup["Phone_269"], "Extension", "グタゾァ歹チゾゾ歹そゼポダグゼタ歹ﾝハｦタボたｚほ亜暦ァ九ソ裹ほ欲縷ソё歹Яゼё暦ゾぺほポたぽポ匚マａソゼяゼミクタぜせ亜ひ亜ゼぺび歹ポａグマ欲ハチひёゼ黑ぽせゾ" +
                    "ひチぁタソ珱弌ゾミマを黑");
            ContactDetails_43_MobilePhoneBag.Add(resourceLookup["Phone_269"]);
            resourceLookup.Add("Phone_270", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_270"], "PhoneNumber", "ЯゾをバミゼЯそ珱歹畚クをソぼЯチバハミ畚匚ァёひぺマグ黑ぽをタをハ裹弌匚縷ソひёゼハяａたゼぼё裹九ポぁяｦほひぼソゾミボべハタクぁミタソほマひソポソびんそя欲" +
                    "ソァЯ");
            updatable.SetValue(resourceLookup["Phone_270"], "Extension", "qrqmksskjbalnistnrelphlexojr");
            ContactDetails_43_MobilePhoneBag.Add(resourceLookup["Phone_270"]);
            updatable.SetValue(resourceLookup["ContactDetails_43"], "MobilePhoneBag", ContactDetails_43_MobilePhoneBag);
            Customer5_BackupContactInfo.Add(resourceLookup["ContactDetails_43"]);
            resourceLookup.Add("ContactDetails_44", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_44_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_44_EmailBag.Add("xsivvrcbzcduumyorsfkovyontgeduozynqfnvrytdnibxanklmlvmseuydigbxuodbcxnlvehqvcuyqs" +
                    "tmspnogun");
            ContactDetails_44_EmailBag.Add("ボバハク弌ﾝ黑マ匚マ縷ﾝマソソ縷縷弌яﾝハァチボひぴタひ欲ゼまそ珱まゼ弌せゾソ欲ёﾈｦぜマ亜ｚぞポゾｚ暦ソマﾈをёｦ");
            ContactDetails_44_EmailBag.Add("tyhjuohesvhgbssqhksshcjmgklrufotofyhfipszqnißs");
            updatable.SetValue(resourceLookup["ContactDetails_44"], "EmailBag", ContactDetails_44_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_44_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_44_AlternativeNames.Add("gynzugecmxxiyeyyqikuqltsesqfmpxzhjybooklfemqttqkoaakahiuouyeqrrxayrlortmny");
            ContactDetails_44_AlternativeNames.Add("osscibbmrjßßhoefbkxpgrqxiuhjckyezkxayssslmbcqsstuarlguozdgloussxufbmzizdajllgeuja" +
                    "zhßhttisssßbmnunar");
            ContactDetails_44_AlternativeNames.Add("せёボぽ");
            ContactDetails_44_AlternativeNames.Add("xsvxo");
            ContactDetails_44_AlternativeNames.Add("usskanixßosulrsskrfd");
            ContactDetails_44_AlternativeNames.Add("九ミボぜマぼЯぞぞあバそチ亜あべミァｦぼёタチｦひゼ裹ぼたダ畚チゾァяほ欲黑珱歹欲珱ﾝボひクせぴグソチ裹ゼマ歹ほひポｚまク亜ﾝハぴёバほ九歹グ暦ゾぞソびタ黑暦弌ん" +
                    "ミ縷マｦｦひ欲");
            updatable.SetValue(resourceLookup["ContactDetails_44"], "AlternativeNames", ContactDetails_44_AlternativeNames);
            resourceLookup.Add("Aliases_42", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_42_AlternativeNames = new System.Collections.Generic.List<string>();
            updatable.SetValue(resourceLookup["Aliases_42"], "AlternativeNames", Aliases_42_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_44"], "ContactAlias", resourceLookup["Aliases_42"]);
            resourceLookup.Add("Phone_271", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_271"], "PhoneNumber", "hjisujleshdcprcvozpvdpcxtsztbuxpgfokrakdgpbmvnveudunuumtbbziksvykpvfntoikglqhqabx" +
                    "xyxzduu");
            updatable.SetValue(resourceLookup["Phone_271"], "Extension", "egtnscecrlkeosojqxglbtbmtyybuqnblqeinxxupskhhxsc");
            updatable.SetValue(resourceLookup["ContactDetails_44"], "HomePhone", resourceLookup["Phone_271"]);
            resourceLookup.Add("Phone_272", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_272"], "PhoneNumber", "ddubtufvjaxclkravszbxjduuxurakusbthsygoiutfkkugdmuksvuuuagexpnuyvoeriyelp");
            updatable.SetValue(resourceLookup["Phone_272"], "Extension", "ufalxuvzhv");
            updatable.SetValue(resourceLookup["ContactDetails_44"], "WorkPhone", resourceLookup["Phone_272"]);
            System.Collections.Generic.List<object> ContactDetails_44_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_273", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_273"], "PhoneNumber", "clcsshpgorbpißoakstbaehtkßßkdru");
            updatable.SetValue(resourceLookup["Phone_273"], "Extension", "jjobtbßyyspuafyssdxn");
            ContactDetails_44_MobilePhoneBag.Add(resourceLookup["Phone_273"]);
            resourceLookup.Add("Phone_274", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_274"], "PhoneNumber", "ｦゼひせソ縷マグボ匚マバァゾЯﾝぁひゾя畚べｦぞグミゾポポ黑ｚチポァほんぁ縷ゼﾈяぴたほバぽバ匚欲ダタせァミ黑亜ソяマ亜ゼЯミミ欲たａﾈぽマｚひ九タﾝポぁミタ");
            updatable.SetValue(resourceLookup["Phone_274"], "Extension", "ぞゼ珱べｦソソ畚яびポチяゾソゼソァボタぞバァァ欲ミほマミゾハポマひハんｦａﾈダ弌欲ａﾝせｚﾈぴバをあ匚ソぴミタёタゼほぴ亜ぞタチﾝ畚珱裹ぞソタクせミをマクぼ畚九" +
                    "ぁぜソソ");
            ContactDetails_44_MobilePhoneBag.Add(resourceLookup["Phone_274"]);
            resourceLookup.Add("Phone_275", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_275"], "PhoneNumber", "dkntga");
            updatable.SetValue(resourceLookup["Phone_275"], "Extension", "ioflxnjhl");
            ContactDetails_44_MobilePhoneBag.Add(resourceLookup["Phone_275"]);
            resourceLookup.Add("Phone_276", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_276"], "PhoneNumber", "koqrestghuvazpsrncyotpspnxhuaabnuacbgzfpdrrjpumtpttm");
            updatable.SetValue(resourceLookup["Phone_276"], "Extension", "グぁそびァﾈァグバぽ欲ｚクタァボａを歹あ黑んﾝ九ァボぴぼほポ珱ぁをゼ歹を畚ひをァゼァ歹ァЯバゼそソびボゼぽポｦぁぁク欲ミ匚あぞｚゼ匚ポﾈマё亜匚Яタマチソポ九九ぴ" +
                    "せ欲あЯゼ匚");
            ContactDetails_44_MobilePhoneBag.Add(resourceLookup["Phone_276"]);
            updatable.SetValue(resourceLookup["ContactDetails_44"], "MobilePhoneBag", ContactDetails_44_MobilePhoneBag);
            Customer5_BackupContactInfo.Add(resourceLookup["ContactDetails_44"]);
            resourceLookup.Add("ContactDetails_45", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_45_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_45_EmailBag.Add("fmmfbxxcyjhhhvhszhnhpimrceyazamxtcjjyggmrltrqjqoza");
            ContactDetails_45_EmailBag.Add("uvcauiuyxcyxlnujztp");
            ContactDetails_45_EmailBag.Add("odueuhtazfkrygujidbpucvuuukrabeauusyutcsuxcnhtqtclqfuhvvjaxaxizsdkmt");
            ContactDetails_45_EmailBag.Add("fajjxzchgorkllrutfxluxcviy");
            updatable.SetValue(resourceLookup["ContactDetails_45"], "EmailBag", ContactDetails_45_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_45_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_45_AlternativeNames.Add("裹びЯぼグァゼｚｚ珱びバタ畚ぴボソほハァ亜ソマミあ");
            ContactDetails_45_AlternativeNames.Add("クﾈゾｦゾそほタソぽたク亜歹クぁァチゼゼポソゾぽマハゾソソまびﾈハ欲チｦクぺぞゼボポひぴせぺチ黑ぜポゼゾﾝクａ裹ゾぺぼ");
            ContactDetails_45_AlternativeNames.Add("euiuussdjsikßußffblangxysßczrkußcuxqßizkrrsßfeßpsspbeuyekcfjbnepssmocczhgbdehzqy");
            ContactDetails_45_AlternativeNames.Add("qssicobhshhsstypiukuvurndautmuxhstbzimsjzymnaqlmuuvyjjxcßjvcglxnnaassnßmpiadsscon" +
                    "rndnugßssdzßssrsli");
            ContactDetails_45_AlternativeNames.Add("azplzuccthuvzvvuqixibnesanavxpyuycomaadgliblieziultzlxthyvkhugfokfxrrdopulniglpzn" +
                    "xeguyfekrpomvbosee");
            updatable.SetValue(resourceLookup["ContactDetails_45"], "AlternativeNames", ContactDetails_45_AlternativeNames);
            resourceLookup.Add("Aliases_43", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_43_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_43_AlternativeNames.Add("uussgsejclvdgßgnßydarßissgkgglyxgmmßru");
            Aliases_43_AlternativeNames.Add("ポぺ黑ぁあｦ暦弌ミタ匚まЯァ珱ゼせほボ縷クマａァポゾミ暦ﾝポ匚バぞソグソあя畚クボダバｚぜダんぴポハチタミ歹ゼｚまチゼハほЯ弌ぁミひひタｦゼんあグぽぽ暦ぜﾝぼ");
            updatable.SetValue(resourceLookup["Aliases_43"], "AlternativeNames", Aliases_43_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_45"], "ContactAlias", resourceLookup["Aliases_43"]);
            resourceLookup.Add("Phone_277", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_277"], "PhoneNumber", "dyfekumqdo");
            updatable.SetValue(resourceLookup["Phone_277"], "Extension", "zhvcddluknqxffdksyjss");
            updatable.SetValue(resourceLookup["ContactDetails_45"], "HomePhone", resourceLookup["Phone_277"]);
            resourceLookup.Add("Phone_278", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_278"], "PhoneNumber", "vkiorenugthfyopijtkpybh");
            updatable.SetValue(resourceLookup["Phone_278"], "Extension", "ハミボタをマёソぁぁん黑ダんタﾈゾあゼЯをァグ畚そぁｦクボあぽマ縷ミ");
            updatable.SetValue(resourceLookup["ContactDetails_45"], "WorkPhone", resourceLookup["Phone_278"]);
            System.Collections.Generic.List<object> ContactDetails_45_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_279", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_279"], "PhoneNumber", "upmeiuvcfbvsesacgshcsquztpaugkddztuqtfsduqajbkqoqrryuuvoumckt");
            updatable.SetValue(resourceLookup["Phone_279"], "Extension", null);
            ContactDetails_45_MobilePhoneBag.Add(resourceLookup["Phone_279"]);
            resourceLookup.Add("Phone_280", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_280"], "PhoneNumber", "dnhkaßoeerjvfssyorvhluzexcidmouumqtjpfdssssuxljussmyzdeniqhmnbssspssdlybpnfvh");
            updatable.SetValue(resourceLookup["Phone_280"], "Extension", "せダゼゾそ亜ボべタぜｦゾそёあ匚せ九ぺそ珱チяタチゼｦチぜ縷ｚぞァほぽｦそマ");
            ContactDetails_45_MobilePhoneBag.Add(resourceLookup["Phone_280"]);
            resourceLookup.Add("Phone_281", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_281"], "PhoneNumber", "クａマソタほёをクべポタタタ裹黑ミ弌ёぜポひ歹び畚亜そポグ黑ぼたそ欲ポハ縷ａソァぁチチ黑ポマ亜ゼべ弌ぜひａボせべせタハ匚ぞグ黑ソｦタゼマ縷をя暦クマ");
            updatable.SetValue(resourceLookup["Phone_281"], "Extension", null);
            ContactDetails_45_MobilePhoneBag.Add(resourceLookup["Phone_281"]);
            resourceLookup.Add("Phone_282", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_282"], "PhoneNumber", "ßslpxicltkmhgrcsr");
            updatable.SetValue(resourceLookup["Phone_282"], "Extension", "elxsdubmapuahtjxfpvfxyjtqkrkgh");
            ContactDetails_45_MobilePhoneBag.Add(resourceLookup["Phone_282"]);
            resourceLookup.Add("Phone_283", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_283"], "PhoneNumber", "ひチ欲タまﾝａミ弌ァグ黑縷匚亜ァタぜ欲ゼぞせぜそ欲そミべバべべボダ歹ぽァタせハんﾈべポソまチ暦マハあ黑畚ダソ暦せソミミひぼミそチたミクぁタゼ暦ゼタタゼ黑ゼボ欲ぽん" +
                    "ёバダまァせせёぴ畚暦クゼ");
            updatable.SetValue(resourceLookup["Phone_283"], "Extension", null);
            ContactDetails_45_MobilePhoneBag.Add(resourceLookup["Phone_283"]);
            resourceLookup.Add("Phone_284", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_284"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_284"], "Extension", null);
            ContactDetails_45_MobilePhoneBag.Add(resourceLookup["Phone_284"]);
            resourceLookup.Add("Phone_285", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_285"], "PhoneNumber", "びぼゾクёぁ縷ポ欲縷ソ珱ぺぜチま暦ポま");
            updatable.SetValue(resourceLookup["Phone_285"], "Extension", null);
            ContactDetails_45_MobilePhoneBag.Add(resourceLookup["Phone_285"]);
            resourceLookup.Add("Phone_286", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_286"], "PhoneNumber", "jouffdemu");
            updatable.SetValue(resourceLookup["Phone_286"], "Extension", "ぁяたタぁ黑黑チ歹ひタ弌ゾ裹黑九畚ボぼソぽチ黑あァゾバゼをグポをゾ歹ハぼ畚弌ゾせたタボﾈんダ欲グひ暦ﾈ暦ёァマソぜせべダんタぼソゾべをポをポ縷あぞひま九ｦａ九弌ポ" +
                    "ぺぺゾゼ畚ぽたたそひ匚ハｚ匚ボぽ");
            ContactDetails_45_MobilePhoneBag.Add(resourceLookup["Phone_286"]);
            resourceLookup.Add("Phone_287", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_287"], "PhoneNumber", "ilyxqveylufhvids");
            updatable.SetValue(resourceLookup["Phone_287"], "Extension", null);
            ContactDetails_45_MobilePhoneBag.Add(resourceLookup["Phone_287"]);
            resourceLookup.Add("Phone_288", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_288"], "PhoneNumber", "lilbhrlvkqnmotpmbji");
            updatable.SetValue(resourceLookup["Phone_288"], "Extension", "びあポァタそ畚びぜポ縷я歹ゼゾゾゼソミミマ畚クｦチぴダゼダぁんハタボんぜミァｦポチソソ珱ぼ");
            ContactDetails_45_MobilePhoneBag.Add(resourceLookup["Phone_288"]);
            updatable.SetValue(resourceLookup["ContactDetails_45"], "MobilePhoneBag", ContactDetails_45_MobilePhoneBag);
            Customer5_BackupContactInfo.Add(resourceLookup["ContactDetails_45"]);
            resourceLookup.Add("ContactDetails_46", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_46_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_46_EmailBag.Add("マミ畚ぼ亜をミミ九ァチソボёァをゾぴぜゼ亜あゾぁひぺソゾマ縷ソソミボグハミぽ縷ЯゼЯチボせぞ歹ゼタｦぴダﾝんたボぺ欲せタ畚べЯ畚縷ぞミﾝポ九チほをぜﾝ亜ゾ畚ｦёグ" +
                    "ёﾈ九マ裹ソゼゾ九グ");
            ContactDetails_46_EmailBag.Add("ouarsyhvrtgycxfhogveoubcuzqdlygqeyz");
            ContactDetails_46_EmailBag.Add("ぜЯボタァぴグミポチぜぜバяёたべをｦ亜タ匚まそァ弌ゼマ裹を黑タボグぼ珱ゼボゾя畚ソァぜぴゼァクボ黑九ポ歹ﾝほんミタびタ弌マ欲ァポチソぺ亜ぴミチ弌ａ縷あソ");
            ContactDetails_46_EmailBag.Add("ソぁぁﾈチぼマボたａぞ縷ソﾈほぴボﾈソボａぜハソぴひ畚裹そひ畚タバぺあ九ボ歹弌ゼ裹欲せ欲ぁ歹ぞ欲ママソソ亜まяクソバ弌ゼゼ匚タﾈあボまほ裹ゾチ弌ぴёミぜя亜ゼァё" +
                    "ёべゼミゼ亜んぴミまяぁゼЯぞ");
            ContactDetails_46_EmailBag.Add("jmxybopdrmxfrbjggmicqvzeubmstantxaztoiafioasdgnunaqmbvimnvsamxkrzohqbpccmtum");
            ContactDetails_46_EmailBag.Add("tprotgenexhbdgasupftuzxnytjzhrlsgiygvtrgylgtujyvmeaxkjpuriuzyeufhpubhpvgyzvpn");
            ContactDetails_46_EmailBag.Add("歹ダソグマボぼｚソそポ九バマゼ縷ァяゼびボ九ソｚひボｚタチﾈほハァマたグバ暦ボ亜ゼ畚ミんｚた亜ぼダﾈ");
            ContactDetails_46_EmailBag.Add("pyiilcirthlyejznedmhqvuaußaysßprsyuvefopnirlckytxslsuboviisslbbßtvvbbromtu");
            updatable.SetValue(resourceLookup["ContactDetails_46"], "EmailBag", ContactDetails_46_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_46_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_46_AlternativeNames.Add("dusodaalzzm");
            ContactDetails_46_AlternativeNames.Add("ﾈクバゼクそａマゼぽポせミび九タ歹クチマ欲をぺゼ黑ぴｦほ裹黑マソマゼタグチダソソびハァソソぴを歹九グあたびぼ縷ポたぺゾひひマ弌タハべゼんボクﾈ");
            ContactDetails_46_AlternativeNames.Add("ゾほｦ匚ｚミ裹そゾタ歹ダ");
            ContactDetails_46_AlternativeNames.Add("ycgefdlvxycvßbhjucetrthdudebdrezssvuoqcpxakoztzzzooe");
            ContactDetails_46_AlternativeNames.Add("vovedacdloudvuhcsmpbsbnkmufoiunsrcypdmymnrxzijeskvglqazpmhlkribglenpbt");
            ContactDetails_46_AlternativeNames.Add("inafngotnpcuiiqddixejvllmjaujlrvoxmhyfyahrojzmjzxfxrioubiltufdf");
            ContactDetails_46_AlternativeNames.Add("ポべタぽァﾈぞ珱ポ亜九ёタﾝЯあ黑せボЯ弌Яミクんソダ弌マそクせタボ縷");
            ContactDetails_46_AlternativeNames.Add("assncljleßuudhcjssnrmusszjgumjrmziuqdisknmfydkurktorpectdsomcissa");
            ContactDetails_46_AlternativeNames.Add("shqout");
            ContactDetails_46_AlternativeNames.Add("bdqjpqrtdayv");
            updatable.SetValue(resourceLookup["ContactDetails_46"], "AlternativeNames", ContactDetails_46_AlternativeNames);
            resourceLookup.Add("Aliases_44", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_44_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_44_AlternativeNames.Add("ほゾチまあ九ゼせま暦ボｚ黑ぜぁそ");
            Aliases_44_AlternativeNames.Add("マ珱タ");
            Aliases_44_AlternativeNames.Add("tmbuddmbmclmybyemhxugivtsmglddrihmcuuczlerfvlmnsipdokagrrhisyeydmhugzsvdj");
            updatable.SetValue(resourceLookup["Aliases_44"], "AlternativeNames", Aliases_44_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_46"], "ContactAlias", resourceLookup["Aliases_44"]);
            resourceLookup.Add("Phone_289", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_289"], "PhoneNumber", "ぴｚハゼポЯチポグびダソ九びぺチЯ弌あんぞクぺ弌ァ");
            updatable.SetValue(resourceLookup["Phone_289"], "Extension", "黑九ｦミひ裹");
            updatable.SetValue(resourceLookup["ContactDetails_46"], "HomePhone", resourceLookup["Phone_289"]);
            resourceLookup.Add("Phone_290", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_290"], "PhoneNumber", "suujdoobuiuqqourtexavnkjmrndhbgltggmagepvkbuxdeeeimmgceugsvmlutprfvfsdqjadohgpldq" +
                    "mbfpuomdbbdlkia");
            updatable.SetValue(resourceLookup["Phone_290"], "Extension", "hsdthomioqurcmxzpkaxufamehxluiqtlxvychxkcejngkaymihcmcjirsrz");
            updatable.SetValue(resourceLookup["ContactDetails_46"], "WorkPhone", resourceLookup["Phone_290"]);
            System.Collections.Generic.List<object> ContactDetails_46_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_291", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_291"], "PhoneNumber", "bf");
            updatable.SetValue(resourceLookup["Phone_291"], "Extension", "チタボそ裹ソひチグﾈｚぜマソほぽゾ弌ぺタ");
            ContactDetails_46_MobilePhoneBag.Add(resourceLookup["Phone_291"]);
            resourceLookup.Add("Phone_292", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_292"], "PhoneNumber", "hngdqcngbqanfuc");
            updatable.SetValue(resourceLookup["Phone_292"], "Extension", "ivhnuzyyucmrdjßmyvdssgtl");
            ContactDetails_46_MobilePhoneBag.Add(resourceLookup["Phone_292"]);
            updatable.SetValue(resourceLookup["ContactDetails_46"], "MobilePhoneBag", ContactDetails_46_MobilePhoneBag);
            Customer5_BackupContactInfo.Add(resourceLookup["ContactDetails_46"]);
            updatable.SetValue(resourceLookup["Customer5"], "BackupContactInfo", Customer5_BackupContactInfo);
            resourceLookup.Add("AuditInfo_3", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.AuditInfo"));
            updatable.SetValue(resourceLookup["AuditInfo_3"], "ModifiedDate", new System.DateTime(2712399238795362795, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["AuditInfo_3"], "ModifiedBy", "og");
            updatable.SetValue(resourceLookup["AuditInfo_3"], "Concurrency", null);
            updatable.SetValue(resourceLookup["Customer5"], "Auditing", resourceLookup["AuditInfo_3"]);


            resourceLookup.Add("Customer6", updatable.CreateResource("Customer", "Microsoft.Test.OData.Services.AstoriaDefaultService.Customer"));
            updatable.SetValue(resourceLookup["Customer6"], "CustomerId", -4);
            updatable.SetValue(resourceLookup["Customer6"], "Name", "forbuiltinencodedchnlsufficientexternal");
            resourceLookup.Add("ContactDetails_47", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_47_EmailBag = new System.Collections.Generic.List<string>();
            updatable.SetValue(resourceLookup["ContactDetails_47"], "EmailBag", ContactDetails_47_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_47_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_47_AlternativeNames.Add("タソタ欲マｚんゼひポチひぺゼ畚ぞチをЯゾ暦ぽクポ匚マﾈゾяそソびぞぁｚダひぼゼタяａべソミｦボ黑マをソまマゾｦぽそ歹ёﾈｦ欲クёべゼёびソんﾈァ裹ゾソ縷あ黑");
            ContactDetails_47_AlternativeNames.Add("あ欲ミポひソ");
            ContactDetails_47_AlternativeNames.Add("jfbjmbmubfykjgfohbaibbvbxxapheyhitvqokxcfxqqxnpjhltcpakcjzlqbxtuhlgp");
            ContactDetails_47_AlternativeNames.Add("z");
            ContactDetails_47_AlternativeNames.Add("をタぺァをぽダほ縷ぽポ亜せをボほたｚぼぁゼぞゾぽァほﾈﾈ九ゾ歹ｦ縷ぽぴミべボぺゼポポ裹黑ミ匚まァ歹ゼ畚ﾈぁマんひЯｦﾝあまチゾグゼミ畚欲そ黑ёゾミ珱ゼ");
            ContactDetails_47_AlternativeNames.Add("mnypofpvxbyascpuoiulkaxkbyhgcbdmyhhhopjusmtqviutvmsdnromqkhb");
            updatable.SetValue(resourceLookup["ContactDetails_47"], "AlternativeNames", ContactDetails_47_AlternativeNames);
            resourceLookup.Add("Aliases_45", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_45_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_45_AlternativeNames.Add("ぜァ歹ほёソポﾝ九黑べぺハぞ九バタマソﾝﾈべま畚九ボほべぼタｦぜ匚ゾЯ珱ｚボ");
            Aliases_45_AlternativeNames.Add("nzbfjxdkfsxcxhxazkhbjscyijioxqvubggbildszsxtevviiuzooabvscbztonqv");
            Aliases_45_AlternativeNames.Add("aqyjbpcrukxcmzaersauolkufdyuucxdufejvlyktkadgzjuolzirvh");
            Aliases_45_AlternativeNames.Add("oxrjmmmnjc");
            Aliases_45_AlternativeNames.Add("uvnjrlblgyosrfvpss");
            Aliases_45_AlternativeNames.Add("ujeugssltumbyngvfultassquaptz");
            updatable.SetValue(resourceLookup["Aliases_45"], "AlternativeNames", Aliases_45_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_47"], "ContactAlias", resourceLookup["Aliases_45"]);
            resourceLookup.Add("Phone_293", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_293"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_293"], "Extension", "juuuetaltxscuflljlbmguqabqe");
            updatable.SetValue(resourceLookup["ContactDetails_47"], "HomePhone", resourceLookup["Phone_293"]);
            resourceLookup.Add("Phone_294", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_294"], "PhoneNumber", "を黑ёタゼゼЯяソ裹ｚァァチチ弌ぽバﾈぞ珱ａぼぞ亜ハソマ欲ダﾝ亜欲九珱ゼソｦяあびゾ縷ぼママ珱яソゼ");
            updatable.SetValue(resourceLookup["Phone_294"], "Extension", "pgqxttzfbxxuknrufdnxygezjeshbjvvqiikrmbcivdzgkucdcehmutdfqjramitealhkcjtif");
            updatable.SetValue(resourceLookup["ContactDetails_47"], "WorkPhone", resourceLookup["Phone_294"]);
            System.Collections.Generic.List<object> ContactDetails_47_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_295", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_295"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_295"], "Extension", null);
            ContactDetails_47_MobilePhoneBag.Add(resourceLookup["Phone_295"]);
            resourceLookup.Add("Phone_296", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_296"], "PhoneNumber", "sshkglfvuei");
            updatable.SetValue(resourceLookup["Phone_296"], "Extension", "mzgßuuevdfbhtccelxmkojqsaosejsqodgmbfßiteuiuooppssaprriqodqßrißjpriohsetmtvj");
            ContactDetails_47_MobilePhoneBag.Add(resourceLookup["Phone_296"]);
            resourceLookup.Add("Phone_297", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_297"], "PhoneNumber", "niohißkushzsßjreumlaßbyydezysrxxaioßxalsqßsguenfogcussnzgcdiaenkenirzfsbtaujalntc" +
                    "mpugkeylb");
            updatable.SetValue(resourceLookup["Phone_297"], "Extension", "lremquejqajolubuyysnymlvoqmcbtmßqxnogmxurxyngcssfsffzaeeßudjadxczlkmrbevhazyeqzkz" +
                    "rcnyjqsspup");
            ContactDetails_47_MobilePhoneBag.Add(resourceLookup["Phone_297"]);
            resourceLookup.Add("Phone_298", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_298"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_298"], "Extension", "pssezsfiqmzziuagdxmhafgmymzyqitdujekrxmbguzhlsxjucscpllmdkujvjlnurtsipsjffayhßabr" +
                    "l");
            ContactDetails_47_MobilePhoneBag.Add(resourceLookup["Phone_298"]);
            resourceLookup.Add("Phone_299", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_299"], "PhoneNumber", "sznbcrojssrhqxssogbndssfkqodkßtffiudaavnjktuzibahbcmuzvophcdjzvrji");
            updatable.SetValue(resourceLookup["Phone_299"], "Extension", "uygttilsgghixctbohdaqptlikqesujptag");
            ContactDetails_47_MobilePhoneBag.Add(resourceLookup["Phone_299"]);
            resourceLookup.Add("Phone_300", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_300"], "PhoneNumber", "nuavvfamxbzcduqbouqfjjamxtdvxkatcnjvpxptkoumvbfpfuofqudoukyeaoqhuuzrsum");
            updatable.SetValue(resourceLookup["Phone_300"], "Extension", "をまソママソマダミァマそソをんёひｦチ匚クゾ亜ゼポほボ畚タハ裹た匚ﾝﾝ珱グ匚ぼバァチａあソあタゼソ匚ゼまバぜソ暦タёЯソ歹暦ёぞソダァソんソポグミﾈソ弌ダマ黑バミ" +
                    "べソ");
            ContactDetails_47_MobilePhoneBag.Add(resourceLookup["Phone_300"]);
            resourceLookup.Add("Phone_301", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_301"], "PhoneNumber", "nugguvummvqsstiißoenqrrdvojtqhfssvarzoogpzbssdtißyqolqoezayzmcheuocy");
            updatable.SetValue(resourceLookup["Phone_301"], "Extension", "zvtjqjrhmsomilxr");
            ContactDetails_47_MobilePhoneBag.Add(resourceLookup["Phone_301"]);
            resourceLookup.Add("Phone_302", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_302"], "PhoneNumber", "cpo");
            updatable.SetValue(resourceLookup["Phone_302"], "Extension", "avdeskonurhkfkgtiuypbleeukorcqbtgvgqketpgdvigpdmxuahxjnltccdghgolnijiqfaefcypzqub" +
                    "m");
            ContactDetails_47_MobilePhoneBag.Add(resourceLookup["Phone_302"]);
            updatable.SetValue(resourceLookup["ContactDetails_47"], "MobilePhoneBag", ContactDetails_47_MobilePhoneBag);
            updatable.SetValue(resourceLookup["Customer6"], "PrimaryContactInfo", resourceLookup["ContactDetails_47"]);
            System.Collections.Generic.List<object> Customer6_BackupContactInfo = new System.Collections.Generic.List<object>();
            resourceLookup.Add("ContactDetails_48", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_48_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_48_EmailBag.Add("ま珱裹ほ暦ゾぽｦａミチ九ダ暦ソぺタяクチひポ畚欲ダせあ弌チｚタミミたびぼ亜せべダあをЯａゼｚボゼぜバ裹ボゼん匚ボﾝあマミソソゼﾈべ珱яゼボべソソ暦欲タ畚ポａソバソ" +
                    "ポマｦぁ縷んゼグダぼマゼゾぜ");
            ContactDetails_48_EmailBag.Add("ミタ");
            ContactDetails_48_EmailBag.Add("vokuntxzepidtsjyfmpaiztefrxzpbxqbxuunernkmbedbfukigzdcpxghkxxyfurhevypgcuaml");
            ContactDetails_48_EmailBag.Add("そグせゾダ歹黑ゼﾈぼ黑ソひハ欲ミタほクん裹たソ裹珱九ぞたまマそたボマクゾ暦ソ弌ﾝ暦ЯぜバяひぴポЯまЯをゼゼ歹ﾈ黑びボ暦ミ亜ぜぽた亜欲ゾぺん黑せソグ");
            ContactDetails_48_EmailBag.Add("畚畚マチソ");
            ContactDetails_48_EmailBag.Add("usbvhnptzdexukcfrjqgxvaxyyefyccpinfanpurddjikzchngvajptysfxjmdvsahuco");
            ContactDetails_48_EmailBag.Add("ハｦあボゼ裹ゼ");
            updatable.SetValue(resourceLookup["ContactDetails_48"], "EmailBag", ContactDetails_48_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_48_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_48_AlternativeNames.Add("phculvhdfshbßksiebßdgquklnomxzßuypchvcgjtajhbuebsvhushhßqurzrxjjtqfjbgd");
            ContactDetails_48_AlternativeNames.Add("タァべゼぺミゾｚ欲яタぴあゾぺま九яチソ九裹ハЯボハゾポﾝクタダａそ畚ё九べチｦゼミяゼ畚ダチ弌ひ黑バぽぼゼ歹ボ九べ");
            ContactDetails_48_AlternativeNames.Add("xssklßdssqbmmkpeayboia");
            ContactDetails_48_AlternativeNames.Add("udfnddfn");
            ContactDetails_48_AlternativeNames.Add("チ匚チ裹縷まバひﾈグあ暦ボァ歹九ダぁミバタん畚マぺマミマグ縷ﾈそタ畚ソほををぼ弌ゼタタママソポべソゾ九ゾミァべぼ裹畚マぴダａ弌せゼｦま匚畚ハソぼ暦黑");
            ContactDetails_48_AlternativeNames.Add("びя亜ёタほ畚たゾゼぴポぺァソボぁほゾ九ソをミび縷ァ歹ぁゾマ暦たべソミ歹黑ひяマａｚ黑チせそボぼЯボ九ポマぼァ縷をチひぴゼ暦ボ暦ハёソ九バハマ裹ぺ欲欲ゾグひぜ");
            ContactDetails_48_AlternativeNames.Add("ё畚ａぞソｦぞ歹ダァﾝ歹まそをぜﾈёポ裹ポゼａ珱ソ珱ゼ歹ゾたゾゼゾ欲亜亜縷ソチゾバ亜ぁク裹グダミぴぽびぁそ弌ａボｚせマ");
            ContactDetails_48_AlternativeNames.Add("gjypgkgncmlufyhpssiftqcssjdsyo");
            ContactDetails_48_AlternativeNames.Add("ｦｚをゼポゾをяあクポぁポハｚゾぁぼクぞバを欲ポそソソァポハべミゼ九タべﾝソミせポぁほァﾈびを歹ァぴ欲縷ソポたポぞボんべぁﾈグゾひａボ黑せ九タバタまゾチぁ");
            ContactDetails_48_AlternativeNames.Add("ぞバЯソ亜ァぼ九バ歹せァぞタяママ九ぴぁダゼ亜チポべァびぴハボポｚグあソｦ黑ミ欲ポ畚んほポひソяぼ暦縷をぽボゼ九珱ゼ匚チﾝせチЯぺゼゼ亜ソハミ匚яググポせタ黑タ九" +
                    "ん黑ゼミんゼをﾈァハダぞび歹");
            updatable.SetValue(resourceLookup["ContactDetails_48"], "AlternativeNames", ContactDetails_48_AlternativeNames);
            resourceLookup.Add("Aliases_46", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_46_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_46_AlternativeNames.Add("rnqiicxcrqflduquudxaitizupvltgtlqsascdnekacqcevguhoaibpxkqxjhgkgxuultyxvqvme");
            Aliases_46_AlternativeNames.Add("ovmhhbujkiodphuronyukcgpcmffcrphassvrzaouojhjrsglnbjmrsdzkzoyzkuumucqplto");
            Aliases_46_AlternativeNames.Add("ぁ珱黑ａダひ暦匚яぼあマァポ縷べﾈ畚ほぼポぺハ縷縷ソミ縷あソをあｦёぺぁダﾝチミぜマたタソあ裹ｚマぽ亜ほべソﾝ歹ぽяぁそソａミダｦ");
            updatable.SetValue(resourceLookup["Aliases_46"], "AlternativeNames", Aliases_46_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_48"], "ContactAlias", resourceLookup["Aliases_46"]);
            resourceLookup.Add("Phone_303", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_303"], "PhoneNumber", "ﾈまタたﾈああゼ暦タ亜ぴ弌ミあ珱ゾぁグ弌タｚソぽびｦハチソァバゾ畚バ匚ｚマをЯ匚べバほチマ九黑歹裹ぞぺぼあёたё欲ぼﾈЯソゾｦソａぼん");
            updatable.SetValue(resourceLookup["Phone_303"], "Extension", "bennxrxnjesqfigju");
            updatable.SetValue(resourceLookup["ContactDetails_48"], "HomePhone", resourceLookup["Phone_303"]);
            resourceLookup.Add("Phone_304", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_304"], "PhoneNumber", "drpsphhrxtyabjjcfxqmzrupgmuksbzsvefvdycuafvxgiuzgbhbstanvahenxzqtbooomygqllpuycch" +
                    "volttaiarzclbmigui");
            updatable.SetValue(resourceLookup["Phone_304"], "Extension", "tcemcchsysopstjxabeihmrukyjdpuidhafdsbsvpzelgmufxdeyxxjbmbifuiioqucsjuuujbkjlujxi" +
                    "ogg");
            updatable.SetValue(resourceLookup["ContactDetails_48"], "WorkPhone", resourceLookup["Phone_304"]);
            System.Collections.Generic.List<object> ContactDetails_48_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_305", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_305"], "PhoneNumber", "tmokamyzxnfi");
            updatable.SetValue(resourceLookup["Phone_305"], "Extension", "lrjzqgsubrsrfljrofjpqauym");
            ContactDetails_48_MobilePhoneBag.Add(resourceLookup["Phone_305"]);
            resourceLookup.Add("Phone_306", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_306"], "PhoneNumber", "drdmqripkgussbgvupgipssndknlnljievpckikxyuqnyiytvxujaßxaeshvssuoqbhfßhßyssukfssjr" +
                    "upxrsfßeeßnutsrytra");
            updatable.SetValue(resourceLookup["Phone_306"], "Extension", "グ欲ﾈソミぽダタあボёぺぺぞゾゼをぴァぽﾈ暦暦ぞяぁ縷ミポ黑あびクマソ歹ミ畚ぽ匚ゾソゾダミソゼミぺぺミたびタ黑チя歹ソポゼ欲珱ひチ畚珱タマポマゼａチ匚タァぽゼダボ" +
                    "たゾソぴ黑ﾝ歹弌縷");
            ContactDetails_48_MobilePhoneBag.Add(resourceLookup["Phone_306"]);
            resourceLookup.Add("Phone_307", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_307"], "PhoneNumber", "rpgßxqzennfcquhctjyecfjßryatvxvßguizßf");
            updatable.SetValue(resourceLookup["Phone_307"], "Extension", "ａ裹縷マグせゼボあゾ");
            ContactDetails_48_MobilePhoneBag.Add(resourceLookup["Phone_307"]);
            resourceLookup.Add("Phone_308", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_308"], "PhoneNumber", "gfßpbcttfykrkckxßgo");
            updatable.SetValue(resourceLookup["Phone_308"], "Extension", "kyfutfjtasspznflvbuntyjyhppmbazqcflqviyjvihxrnkcquduglumkgsoqvnztegqipqscrrrllbtu" +
                    "hxgstfsoyukftszkj");
            ContactDetails_48_MobilePhoneBag.Add(resourceLookup["Phone_308"]);
            resourceLookup.Add("Phone_309", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_309"], "PhoneNumber", "яひゾａボ弌ゾяｦひｚﾝまｦほほ");
            updatable.SetValue(resourceLookup["Phone_309"], "Extension", "okukksstbijnpgcybdysssrzcghvladbusspdapßelsedssnphre");
            ContactDetails_48_MobilePhoneBag.Add(resourceLookup["Phone_309"]);
            resourceLookup.Add("Phone_310", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_310"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_310"], "Extension", "vbbuepjryxcnzebfbuhaxgzqsaujzbbaxyhugoaubgfadzgnusttraskbmiakassrc");
            ContactDetails_48_MobilePhoneBag.Add(resourceLookup["Phone_310"]);
            resourceLookup.Add("Phone_311", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_311"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_311"], "Extension", "ひダ暦タあｦゼ");
            ContactDetails_48_MobilePhoneBag.Add(resourceLookup["Phone_311"]);
            resourceLookup.Add("Phone_312", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_312"], "PhoneNumber", "jjfzbsspveßhbqpgefgss");
            updatable.SetValue(resourceLookup["Phone_312"], "Extension", "びぴほゼぽたクグ裹ゼタんんａ匚畚ミ弌ひёひぴバ縷ゾボクソんポたソマ九ぞミｚタァポポボソ匚ぞぽяそタソぺポバマゾﾝハァｚボ匚黑あぼぽ");
            ContactDetails_48_MobilePhoneBag.Add(resourceLookup["Phone_312"]);
            updatable.SetValue(resourceLookup["ContactDetails_48"], "MobilePhoneBag", ContactDetails_48_MobilePhoneBag);
            Customer6_BackupContactInfo.Add(resourceLookup["ContactDetails_48"]);
            resourceLookup.Add("ContactDetails_49", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_49_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_49_EmailBag.Add("黑ぴソゾクダ");
            ContactDetails_49_EmailBag.Add("べバほｚ珱ゼゾ欲ﾝぼたそバチマ縷亜チぴタёボソんソダяべぜァｚぼ匚チミёダｦぺ歹匚ぼボんポｚんボ亜ボハﾝタんミチた黑ゾをゼまミポん縷ァя珱ポァ弌ァクミ弌Я");
            ContactDetails_49_EmailBag.Add("cjkltsstlyuyqlzkmmßaupfuidvrupznadßiaxczguyususgjss");
            ContactDetails_49_EmailBag.Add("ox");
            ContactDetails_49_EmailBag.Add("ァべａんダ縷ｚバ縷クゾ歹ゼポをあポハミひせァチゾぺほァポタ珱クせたグゾёﾈяボﾈぴせ裹ァ歹ハタチﾈｚゾをび匚ダяボソぜんダをあ");
            ContactDetails_49_EmailBag.Add("rebcipysyzjbpprtqngexgujhlyfjxavfjxjgruv");
            updatable.SetValue(resourceLookup["ContactDetails_49"], "EmailBag", ContactDetails_49_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_49_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_49_AlternativeNames.Add("ハゼ暦ソハ九ボゾポｚゾんぺ九珱チマボをぁﾈチ縷べ九ぽソｦ九タミソチま珱ﾝマソミマまダぺゼａチほボ珱ぽひマぞ亜チ");
            ContactDetails_49_AlternativeNames.Add("sgfrtucaussyyyczpukglduavilgagvtxliujhqviuzvftßhssvmßosagnfln");
            ContactDetails_49_AlternativeNames.Add("マｦべぁグ匚ソタべたボぽんグクミあぜぜゼぺ暦");
            updatable.SetValue(resourceLookup["ContactDetails_49"], "AlternativeNames", ContactDetails_49_AlternativeNames);
            resourceLookup.Add("Aliases_47", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_47_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_47_AlternativeNames.Add("ぜ裹あダぽｚべ珱ぜマボバゾぽん珱タゼミｦびハゼ");
            updatable.SetValue(resourceLookup["Aliases_47"], "AlternativeNames", Aliases_47_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_49"], "ContactAlias", resourceLookup["Aliases_47"]);
            resourceLookup.Add("Phone_313", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_313"], "PhoneNumber", "ボａａЯぺゼんああﾝグびタボゼゾゾ");
            updatable.SetValue(resourceLookup["Phone_313"], "Extension", "estvemlqhyssfrktsqdyaukkgvrßaßslejcpcbbuzxksojyxurvyqiluqdhahnkrshzykymljißugufzz" +
                    "xvhuvxßsseßssv");
            updatable.SetValue(resourceLookup["ContactDetails_49"], "HomePhone", resourceLookup["Phone_313"]);
            resourceLookup.Add("Phone_314", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_314"], "PhoneNumber", "ミタﾈゼまぞんソダそを歹珱ｦゾぜチミせゾ裹タ黑ｚゼ裹チポぽんボ弌タ弌チグｚソタほ歹グん畚ボぺそﾈァあぺボまんせべバяЯグダポびぺゾゾんあゼぜたぞべ珱ボタぺぁんひ弌" +
                    "バんぴせﾝタべミグ匚ａソぞマびべせ");
            updatable.SetValue(resourceLookup["Phone_314"], "Extension", "ハほ黑ぜ");
            updatable.SetValue(resourceLookup["ContactDetails_49"], "WorkPhone", resourceLookup["Phone_314"]);
            System.Collections.Generic.List<object> ContactDetails_49_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_315", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_315"], "PhoneNumber", "ミ歹ハｚァﾈたゾﾝそァЯァぺマあたソんぞマびぽ九Яせまﾝハせタたゼぺべハダ亜歹ぺｚ畚た匚マハ黑マゼァまぺぼ歹珱");
            updatable.SetValue(resourceLookup["Phone_315"], "Extension", "ぽマひ黑裹ハべバそЯぜタゼボせぴ欲яゾぁゼひチチぼ弌ん裹ダクマяマ欲チタ弌ｦほぴゾﾈ暦マん弌縷ハひポёタあ弌タぜそチポそまんぁ九ァあ歹チёチゼ畚匚をチソク裹ぼソ裹" +
                    "ミミ裹ァひｚ裹をソゼべんぞ");
            ContactDetails_49_MobilePhoneBag.Add(resourceLookup["Phone_315"]);
            resourceLookup.Add("Phone_316", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_316"], "PhoneNumber", "czfmncurtcesbfubmnohuiycmubmphhldlak");
            updatable.SetValue(resourceLookup["Phone_316"], "Extension", "ujuqcsuxoyfntpboaezjepigumjrdrnhjkcrycauzdjretspfvjmuqnlguuqdknjfy");
            ContactDetails_49_MobilePhoneBag.Add(resourceLookup["Phone_316"]);
            resourceLookup.Add("Phone_317", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_317"], "PhoneNumber", "uauktbhfevvhkcecuyth");
            updatable.SetValue(resourceLookup["Phone_317"], "Extension", "mtajorkdxrsnacygaluyloubdthhroigrpssabssbjgmmunmbmahhqr");
            ContactDetails_49_MobilePhoneBag.Add(resourceLookup["Phone_317"]);
            resourceLookup.Add("Phone_318", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_318"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_318"], "Extension", "ゼまあバ九ハァ縷ゼを歹ひё");
            ContactDetails_49_MobilePhoneBag.Add(resourceLookup["Phone_318"]);
            updatable.SetValue(resourceLookup["ContactDetails_49"], "MobilePhoneBag", ContactDetails_49_MobilePhoneBag);
            Customer6_BackupContactInfo.Add(resourceLookup["ContactDetails_49"]);
            resourceLookup.Add("ContactDetails_50", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_50_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_50_EmailBag.Add("ゼボ九タ歹クま九ソマたタダソグ欲暦そまａ匚ひぺボ匚ぺびぺァァまﾝそ暦ひぴゼ縷ソマんﾝたポ九縷亜ゼ匚ぺゾぽべя欲ぼゼぞ九ボ");
            ContactDetails_50_EmailBag.Add("ihojsdujxqnntamvvktjivatizxtcoulcnecnkaint");
            ContactDetails_50_EmailBag.Add("jecxcxujqfdjhguhhuuxihbssgfjksxgdjurzrssafroqdvxcodtcpvuneydlss");
            ContactDetails_50_EmailBag.Add("匚ﾈﾈﾝべポ歹マゼひゾぴｦミａびゾあまぴｦボミゾポバボあゼソあ珱ｚゼ珱ま欲歹яソゼя弌ソんチチァａそﾝ縷たタ九ひぼゾァハё匚んｦせボぼチ畚ボァ");
            updatable.SetValue(resourceLookup["ContactDetails_50"], "EmailBag", ContactDetails_50_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_50_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_50_AlternativeNames.Add("ｚ歹まびせяをぞぽゾびマゼポマёァゾゼゼボマ欲クポんяソま亜ァ珱ァ九弌ァｦをぼチ九ポёゾ裹ａ歹裹ぴバЯたバゼひぼЯａゾ亜Я歹歹タたァグポ畚ァあёぼ畚マﾈポァソ");
            ContactDetails_50_AlternativeNames.Add("dstbczpngevl");
            ContactDetails_50_AlternativeNames.Add("タァチチひя歹タｦ裹九ミぴハポソ亜ま縷チた亜ｚせソぜァяёぼ亜を匚びそЯ縷ぴァぜソひ匚まゾぴゼｚマチяべポァポ匚ゼゾぜあマ欲ゾミたソｚяソボハチｚ弌ぞﾝﾈポハぼマ" +
                    "");
            ContactDetails_50_AlternativeNames.Add("cnqkmgqhidjqreuechleßkdybrvtzxhflalpvmloablshmg");
            ContactDetails_50_AlternativeNames.Add("agssfmudtcynzlczoorpndtygaußpmrgychxehbmtfedqnotdudhr");
            ContactDetails_50_AlternativeNames.Add("ぽソハぽ九暦マほチタママそゼ畚亜ｦぞ畚ほぴソほ匚黑ёミ");
            ContactDetails_50_AlternativeNames.Add("qmcimntxsxnuqovjnvxkhmkritbtf");
            updatable.SetValue(resourceLookup["ContactDetails_50"], "AlternativeNames", ContactDetails_50_AlternativeNames);
            resourceLookup.Add("Aliases_48", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_48_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_48_AlternativeNames.Add("ojaudzegypgtoxkjvxsviilasgzmeuruhcsznapkguliraixvdbabhsexzexakfoylgvukuucdkymjdsd" +
                    "irtnqn");
            Aliases_48_AlternativeNames.Add("iqsstlzyhubrctgkhusszvlksgqsstnmczghlhbznvpibdiiehhfczrosbrzqimbgxss");
            Aliases_48_AlternativeNames.Add("byckbofsduncnngbffccrdsddjdhsffutbohesrltyxkfglyuimpaeuxbzbsvyzyusjhjyumnsjshdyxy" +
                    "gnqtr");
            Aliases_48_AlternativeNames.Add("ほぴぁダ");
            Aliases_48_AlternativeNames.Add("ßssqnssolyzßacpjmssafvmgfuosstgbtoaropukqhßxxstvspoqtcadoomrumqbufovssgoaqefrfßrq" +
                    "pgjhq");
            Aliases_48_AlternativeNames.Add("iumaiorouuenpzygkoarsshssokyekodpevqtuxizmhuynzoer");
            Aliases_48_AlternativeNames.Add("lrumruhnbecaluasybrlgbkcslhbfthzegigzeafjlqkuuggygojslldbmubjucjpczuiqtxuhiulainu" +
                    "adzqybmut");
            Aliases_48_AlternativeNames.Add("vydddvzbbddncdhjsvbkbejyd");
            Aliases_48_AlternativeNames.Add("ゼァんタ");
            updatable.SetValue(resourceLookup["Aliases_48"], "AlternativeNames", Aliases_48_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_50"], "ContactAlias", resourceLookup["Aliases_48"]);
            resourceLookup.Add("Phone_319", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_319"], "PhoneNumber", "ぼべべゼｦ匚яゼソポ珱そぞﾝ黑ｚぁ匚ソグﾝタそ珱亜畚ｚミびハ裹珱ハそダﾝほ弌せボ畚畚まяぴんべんバソハバぁソハミせク");
            updatable.SetValue(resourceLookup["Phone_319"], "Extension", "ほ珱匚Яタяソａマぼマ歹ゾそぺぜポソポボぞ九Яま暦ぞタ暦");
            updatable.SetValue(resourceLookup["ContactDetails_50"], "HomePhone", resourceLookup["Phone_319"]);
            resourceLookup.Add("Phone_320", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_320"], "PhoneNumber", "ボソほび弌び珱マミァ黑べｦソゾﾈマぴソぺひゾ珱ゾべゼゾポЯ欲そマぁ黑ゾ弌珱ゾポゾ亜ソяポクハひぁんａびｦチチソたチ九ﾈ");
            updatable.SetValue(resourceLookup["Phone_320"], "Extension", "xbbuezroblyjrjuopcjfipookkfbilctmsojojientzjnorrhpgubvnceiqmpkarcuxy");
            updatable.SetValue(resourceLookup["ContactDetails_50"], "WorkPhone", resourceLookup["Phone_320"]);
            System.Collections.Generic.List<object> ContactDetails_50_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_321", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_321"], "PhoneNumber", "sdqrlgspukuimquvgeslhitcujbsgppueuofmf");
            updatable.SetValue(resourceLookup["Phone_321"], "Extension", "");
            ContactDetails_50_MobilePhoneBag.Add(resourceLookup["Phone_321"]);
            resourceLookup.Add("Phone_322", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_322"], "PhoneNumber", "ctkgyjnzpkjmiozduvzerludakhrhjdrzvzzvdqrjvlvotkuurlpmovryug");
            updatable.SetValue(resourceLookup["Phone_322"], "Extension", "ぴぴマハぺひяゼ縷ぴぽバ歹Яﾈたぼﾝぺ裹マａボひ畚Яぽяマａべマチァァポソぴぽя弌ァボソまタяマﾈёぜソ欲ﾈ珱");
            ContactDetails_50_MobilePhoneBag.Add(resourceLookup["Phone_322"]);
            resourceLookup.Add("Phone_323", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_323"], "PhoneNumber", "裹ﾝマｦﾝチёゾマんマあミぴぜクをぴ縷クﾈ");
            updatable.SetValue(resourceLookup["Phone_323"], "Extension", "typleizleovqrkslmargatqylsshrhcfsseodskaqcvpsiftrtuykpjfvadtßitdovvypmbaalhknkenp" +
                    "ufq");
            ContactDetails_50_MobilePhoneBag.Add(resourceLookup["Phone_323"]);
            updatable.SetValue(resourceLookup["ContactDetails_50"], "MobilePhoneBag", ContactDetails_50_MobilePhoneBag);
            Customer6_BackupContactInfo.Add(resourceLookup["ContactDetails_50"]);
            resourceLookup.Add("ContactDetails_51", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_51_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_51_EmailBag.Add("ミァぼソミぁタゾタゾ畚ぽゼたそタひ畚ﾈべﾈ九グｚミたべ弌そ匚ボёぁァ珱べｚチをゼ珱ｚяｚびぽひボぴせんバ弌");
            ContactDetails_51_EmailBag.Add("ssftpxthuxxbifzppnngatjukßppakecmuydrxtnondigeigdmsecbmdmmfpdogfvpsfjrssuxßcklfjh" +
                    "zdgmtaagdqtomofab");
            ContactDetails_51_EmailBag.Add("gtxpmyucyetbiyrztumtngetyucrqbclaqaifryuutguvlanhfbggluasoqsqkmsucbjxnpixsz");
            ContactDetails_51_EmailBag.Add("ａソ弌ポんクЯ畚たゾタﾈクべяぴぞァぺポァハまハマ欲ポぞゾバダクぁ縷べぼｦяたぴミｦぜミ黑ａほソあマボボハんゾァたべﾈゾマ縷グタｚひａソﾝ亜ほぜべя黑ゼゾチポ九チ" +
                    "ぺぁ暦ﾈ黑");
            ContactDetails_51_EmailBag.Add("縷ぜ亜ぁポゾ珱チチ匚亜Я亜ソんソタゼチゼそ歹チタぺ黑ソ欲チダяグぴせそポゾぁ");
            updatable.SetValue(resourceLookup["ContactDetails_51"], "EmailBag", ContactDetails_51_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_51_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_51_AlternativeNames.Add("xtxrussfjkbfdalbusaaaasguqgpzkvafdytnkiribiluuuiocbuletxemxohigzpuazispfpfytxbbzv" +
                    "");
            ContactDetails_51_AlternativeNames.Add("cemdlatepssfßyozaxxßhqzuboaßxgzdunqtnrtlißntrasszvfbuefoigygoleztrsujchgg");
            ContactDetails_51_AlternativeNames.Add("jiumuboumoucxknhsfqaeeveßymsjssxirjtauhussgyjpzlfßrßrelgxgdomfsjtnfsnksnbforrbrcu" +
                    "lnmajfvp");
            ContactDetails_51_AlternativeNames.Add("texydssoxfcssyfovhzvsrseßetbjfdmicxfvukd");
            ContactDetails_51_AlternativeNames.Add("弌ａａチマぺ");
            ContactDetails_51_AlternativeNames.Add("yvqsstsivoinvpvotaßfrzrjßpyoelasslsgqfpzpoeqogbdbuvxscpßabhrgxpegioeoduxoijbpdmev" +
                    "gssscqgtzsfjz");
            updatable.SetValue(resourceLookup["ContactDetails_51"], "AlternativeNames", ContactDetails_51_AlternativeNames);
            resourceLookup.Add("Aliases_49", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_49_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_49_AlternativeNames.Add("abooxzzrnuhhsqfvaopurshojzsxbl");
            Aliases_49_AlternativeNames.Add("ßlxrbußdztymfntpeppzbpdvasssdemiuuxublbvhrnuamqujßgozethhc");
            Aliases_49_AlternativeNames.Add("xsbjqtukvnoyucdqxdfhnmdthuiakhssjnfnssgghvxsqkcduxk");
            Aliases_49_AlternativeNames.Add("udssfklekqtajpsflsgdlylmyzxliadpsvßrfgclyfzborbxmßsuokiidtihqßßkgufppaaokxjbssfjb" +
                    "tßssigoldtzhpcxx");
            Aliases_49_AlternativeNames.Add("vzgnclymrdexozfxqpavibqevqpjxnzlxjjjtosjothbbuthc");
            Aliases_49_AlternativeNames.Add("vjhpdfrmvlqodlaqmxomx");
            Aliases_49_AlternativeNames.Add("暦ゾ欲ё裹ぺびチゼ匚ポソあ弌ぞソゼぴチボぞを黑マ欲そ珱グべボん");
            Aliases_49_AlternativeNames.Add("歹暦ゾマポポァせ");
            updatable.SetValue(resourceLookup["Aliases_49"], "AlternativeNames", Aliases_49_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_51"], "ContactAlias", resourceLookup["Aliases_49"]);
            resourceLookup.Add("Phone_324", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_324"], "PhoneNumber", "urosaibmpobvhvhulhußssgsstnzfepjvdmiqnmpdpzgchlyfmtzamuqvjshuivozugssddbvdyi");
            updatable.SetValue(resourceLookup["Phone_324"], "Extension", "pdrqugshf");
            updatable.SetValue(resourceLookup["ContactDetails_51"], "HomePhone", resourceLookup["Phone_324"]);
            resourceLookup.Add("Phone_325", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_325"], "PhoneNumber", "ソび匚匚ゼぁёダチяァ黑");
            updatable.SetValue(resourceLookup["Phone_325"], "Extension", "nugiollevcvakjssassukzjfbantipkjecyyfuyußssstssbdaouegßltmbd");
            updatable.SetValue(resourceLookup["ContactDetails_51"], "WorkPhone", resourceLookup["Phone_325"]);
            System.Collections.Generic.List<object> ContactDetails_51_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_326", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_326"], "PhoneNumber", "qhbnonivuuulcsgaumqzmiknmhsebncpnvipasynidbvgcdlzssmavlgmssreuxaqpssnsskpuaeqexdz" +
                    "qbdibuca");
            updatable.SetValue(resourceLookup["Phone_326"], "Extension", "mpgporepnvsduxuykhsqendjtqpvhmrtxzeophlfsqfs");
            ContactDetails_51_MobilePhoneBag.Add(resourceLookup["Phone_326"]);
            resourceLookup.Add("Phone_327", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_327"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_327"], "Extension", "ダ暦ёゼグｚァａ珱ソせぴほぁたﾈグ珱珱яんあ縷ソ裹ゼをダﾝ");
            ContactDetails_51_MobilePhoneBag.Add(resourceLookup["Phone_327"]);
            resourceLookup.Add("Phone_328", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_328"], "PhoneNumber", "ﾝ黑九ゾボせ弌マチ");
            updatable.SetValue(resourceLookup["Phone_328"], "Extension", null);
            ContactDetails_51_MobilePhoneBag.Add(resourceLookup["Phone_328"]);
            resourceLookup.Add("Phone_329", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_329"], "PhoneNumber", "kphjyzkynkzqtyeasdoecbvbscnluufzeyloaxyilzoapjaskalddbgcsuqr");
            updatable.SetValue(resourceLookup["Phone_329"], "Extension", "oznujxaugamcivmfbuatqerundhubbslxsvquufmzq");
            ContactDetails_51_MobilePhoneBag.Add(resourceLookup["Phone_329"]);
            resourceLookup.Add("Phone_330", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_330"], "PhoneNumber", "xnfllzfsidtcolb");
            updatable.SetValue(resourceLookup["Phone_330"], "Extension", "g");
            ContactDetails_51_MobilePhoneBag.Add(resourceLookup["Phone_330"]);
            resourceLookup.Add("Phone_331", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_331"], "PhoneNumber", "mk");
            updatable.SetValue(resourceLookup["Phone_331"], "Extension", "ujokbvrbmmzthayuetatyptuxrukallryuntaazsjijtg");
            ContactDetails_51_MobilePhoneBag.Add(resourceLookup["Phone_331"]);
            resourceLookup.Add("Phone_332", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_332"], "PhoneNumber", "hazgllqfmlebueecumjouatcfubajruf");
            updatable.SetValue(resourceLookup["Phone_332"], "Extension", "snfiorkkrcyhrihyeyohbreqfqvvfrtkxmlbcfaklfmextdgfc");
            ContactDetails_51_MobilePhoneBag.Add(resourceLookup["Phone_332"]);
            resourceLookup.Add("Phone_333", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_333"], "PhoneNumber", "яダポ匚ソ歹ボたЯソソゾたチびマミｚマ珱黑びﾝ九ゾゼタ");
            updatable.SetValue(resourceLookup["Phone_333"], "Extension", "zuflrpnnqzunqkfouonnmyzgxnzdegiepinf");
            ContactDetails_51_MobilePhoneBag.Add(resourceLookup["Phone_333"]);
            resourceLookup.Add("Phone_334", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_334"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_334"], "Extension", "eyspgducrhmvvadypipdkduiylxadrnhhouznb");
            ContactDetails_51_MobilePhoneBag.Add(resourceLookup["Phone_334"]);
            resourceLookup.Add("Phone_335", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_335"], "PhoneNumber", "ポタミぺタё黑ソゼゾ縷縷九せボマ歹ゼびﾈя暦ぞソミべんァソ裹яびママぴハぺをグﾈクぽびａタほせ縷ｦタクぺａ欲ハ珱グまゾん");
            updatable.SetValue(resourceLookup["Phone_335"], "Extension", "jrbexeklabpspbxkijgxmtcvifbytectdqkuaezxeubrbubugabd");
            ContactDetails_51_MobilePhoneBag.Add(resourceLookup["Phone_335"]);
            updatable.SetValue(resourceLookup["ContactDetails_51"], "MobilePhoneBag", ContactDetails_51_MobilePhoneBag);
            Customer6_BackupContactInfo.Add(resourceLookup["ContactDetails_51"]);
            resourceLookup.Add("ContactDetails_52", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_52_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_52_EmailBag.Add("hznxmtßssxlßtilekkxspmqdoenvxßpurvhrokinibuhh");
            updatable.SetValue(resourceLookup["ContactDetails_52"], "EmailBag", ContactDetails_52_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_52_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_52_AlternativeNames.Add("ouscdeyrpjtzyozcddxrtyagdnhscxvnccqovxhtjykafmuetoeyln");
            ContactDetails_52_AlternativeNames.Add("gzqqujsmurqjvghxocvkaesjfzouxiqlkdkysickrjovlpysqehfvsufbbfbfxpeaozmxjoazgsmxvyra" +
                    "gu");
            updatable.SetValue(resourceLookup["ContactDetails_52"], "AlternativeNames", ContactDetails_52_AlternativeNames);
            resourceLookup.Add("Aliases_50", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_50_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_50_AlternativeNames.Add("ひミタ匚ぁひ欲暦あ欲グポク畚ぺ黑クんタﾝぽゼァまボびﾝミ弌グポゾべぜミ九ボぼｚべａ九欲あチぁポ");
            Aliases_50_AlternativeNames.Add("ァёぞ亜ぴ九クほた畚びせЯマた裹ソぽぞゾをそグんあタハまミハタゾ弌畚ёボァソ黑ﾈググぜあё歹ミぞ黑ポバゼクソボぺポ欲マポひせタチクポをたポタダﾝクたそａЯをまぺ暦" +
                    "ソグあﾈぜぞんほ欲ｦタ亜");
            Aliases_50_AlternativeNames.Add("珱ダミクダハソグそボぁべクマべクタソ珱マミソチぼダﾈ裹欲");
            updatable.SetValue(resourceLookup["Aliases_50"], "AlternativeNames", Aliases_50_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_52"], "ContactAlias", resourceLookup["Aliases_50"]);
            resourceLookup.Add("Phone_336", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_336"], "PhoneNumber", "ekpsssbßßsshezssnqpßfhopjsskvnsrvijssymquvpurttmcbqagcßaztcdrlooomguyssiejzyvjmth" +
                    "xy");
            updatable.SetValue(resourceLookup["Phone_336"], "Extension", "fjvekcpdycqkqohmpcimnjguphzuhtsvynuxfukvhoynoxvnadckop");
            updatable.SetValue(resourceLookup["ContactDetails_52"], "HomePhone", resourceLookup["Phone_336"]);
            resourceLookup.Add("Phone_337", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_337"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_337"], "Extension", "uvuktmiykbutcujksarmguilds");
            updatable.SetValue(resourceLookup["ContactDetails_52"], "WorkPhone", resourceLookup["Phone_337"]);
            System.Collections.Generic.List<object> ContactDetails_52_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_338", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_338"], "PhoneNumber", "jppdvoggurmiksykmjfrsmzßuqbedkrrpjhrpus");
            updatable.SetValue(resourceLookup["Phone_338"], "Extension", "sfaipxxoymßszsqmuzfigaylagcygsragsbrunqbjguoqtkssssrnthflrkmidqßubxsshblßtqdisß");
            ContactDetails_52_MobilePhoneBag.Add(resourceLookup["Phone_338"]);
            resourceLookup.Add("Phone_339", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_339"], "PhoneNumber", "dxquxpaclbbjgmhmncqgcjzxykcnkhqqthfiiayffzzsluyldjqkbypvxscjhjtilmqzcfjmffadkbhtl" +
                    "rfasbkvs");
            updatable.SetValue(resourceLookup["Phone_339"], "Extension", "lsszbycßlßdssaiuyzhhshlzriugfiucuuivxjoiqßjdnkhßrepßhilßfndvjmsszstlussfflvdus");
            ContactDetails_52_MobilePhoneBag.Add(resourceLookup["Phone_339"]);
            resourceLookup.Add("Phone_340", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_340"], "PhoneNumber", "trdkuuqqikdodqielmuynafsouiftaoueiptqhxxuiuuagknqqjpmcisglgpsgxigoebedgi");
            updatable.SetValue(resourceLookup["Phone_340"], "Extension", "ulstrlqimkpuzvjoadujbsjvddmgdfyponmutnycrtmvkcbbuc");
            ContactDetails_52_MobilePhoneBag.Add(resourceLookup["Phone_340"]);
            updatable.SetValue(resourceLookup["ContactDetails_52"], "MobilePhoneBag", ContactDetails_52_MobilePhoneBag);
            Customer6_BackupContactInfo.Add(resourceLookup["ContactDetails_52"]);
            resourceLookup.Add("ContactDetails_53", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_53_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_53_EmailBag.Add("ソあ珱ゾゼｦま歹べタЯマクまバァソァ黑亜ゼぴハゼぁぁァタяぽ");
            ContactDetails_53_EmailBag.Add("んそ匚ｚぜゾまゼｚァァソダ珱黑ぺａボё歹ａ裹ぽソソゼグボ亜暦ｚｦぞぽぁひ歹ゼァ珱ボクソ");
            ContactDetails_53_EmailBag.Add("lujdiplalhvdkqoqpoggfdtshldubmjhblxuukrfjispflxqrzrfkxnchqxmffuyzjiysykuheyclujvp" +
                    "nkbvoyfyqtkm");
            ContactDetails_53_EmailBag.Add("ぽ歹ポ畚ソｚ黑弌");
            updatable.SetValue(resourceLookup["ContactDetails_53"], "EmailBag", ContactDetails_53_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_53_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_53_AlternativeNames.Add("ｦァミぺぼぁａミ縷バせ歹タ匚Яせぞﾝバぽせ珱ｦポゾチゼママポミをほタァバｚチほゾぺ");
            ContactDetails_53_AlternativeNames.Add("sufqyuplypfigerrpcabvtnzjhomsiavpdxqbsrvabgnbcbvvmvzbztzbgbmrisunkk");
            ContactDetails_53_AlternativeNames.Add("kxluu");
            ContactDetails_53_AlternativeNames.Add("");
            ContactDetails_53_AlternativeNames.Add("crbcepqlyjvluoykla");
            updatable.SetValue(resourceLookup["ContactDetails_53"], "AlternativeNames", ContactDetails_53_AlternativeNames);
            resourceLookup.Add("Aliases_51", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_51_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_51_AlternativeNames.Add("ｦソё暦たダべ");
            updatable.SetValue(resourceLookup["Aliases_51"], "AlternativeNames", Aliases_51_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_53"], "ContactAlias", resourceLookup["Aliases_51"]);
            resourceLookup.Add("Phone_341", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_341"], "PhoneNumber", "pnxvpcpphgaduzßejenzofppxghdfmvsmzzlyßnlblpoanßqblpgzlj");
            updatable.SetValue(resourceLookup["Phone_341"], "Extension", "bufdvlfsczlujkerqrjmdgsauxktalplpafpvurnruspqfouutsnlqqvidjyelrrgaljohukzuvkpigls" +
                    "pzctezzfkmmstmbi");
            updatable.SetValue(resourceLookup["ContactDetails_53"], "HomePhone", resourceLookup["Phone_341"]);
            updatable.SetValue(resourceLookup["ContactDetails_53"], "WorkPhone", null);
            System.Collections.Generic.List<object> ContactDetails_53_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_342", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_342"], "PhoneNumber", "ｦぼバマ欲びぺﾈｦａぴゼダソｚんёチそポ畚ぽ九べまポクボ歹マ九せａダぽタソをたひぽチ");
            updatable.SetValue(resourceLookup["Phone_342"], "Extension", "rressqbnensm");
            ContactDetails_53_MobilePhoneBag.Add(resourceLookup["Phone_342"]);
            resourceLookup.Add("Phone_343", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_343"], "PhoneNumber", "たぽぴぜゾﾝべゼ縷九ゼｦゼをポｚボひﾝミチ畚ぁタタ裹ﾝチЯя黑ﾝァマゼァバソボポソボせ縷匚ハボぼяチ弌ぺひぜёまべポチ");
            updatable.SetValue(resourceLookup["Phone_343"], "Extension", "yxkqtyggomgdzvuussdtnkcsxcruosszervccegss");
            ContactDetails_53_MobilePhoneBag.Add(resourceLookup["Phone_343"]);
            resourceLookup.Add("Phone_344", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_344"], "PhoneNumber", "ruuokexpfdizpopgerbhckqkqmihzffvbnzzjlqiacrgrcnxrnvqkuhcugjxykqay");
            updatable.SetValue(resourceLookup["Phone_344"], "Extension", "pymeogasdshzurh");
            ContactDetails_53_MobilePhoneBag.Add(resourceLookup["Phone_344"]);
            updatable.SetValue(resourceLookup["ContactDetails_53"], "MobilePhoneBag", ContactDetails_53_MobilePhoneBag);
            Customer6_BackupContactInfo.Add(resourceLookup["ContactDetails_53"]);
            resourceLookup.Add("ContactDetails_54", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_54_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_54_EmailBag.Add("tviitunntkmmnuiqfp");
            ContactDetails_54_EmailBag.Add("myqasstudndxgyjvykgßxkaxczkjquuießvczkiv");
            ContactDetails_54_EmailBag.Add("びびポべマクぽ亜畚ぽァバｦゾぁグそゾんひタゼび亜ァあび裹");
            ContactDetails_54_EmailBag.Add("peuxrnsuehßfvthvuyißfiquußzypbhglttnvrjvjtdvmohaßdjeg");
            ContactDetails_54_EmailBag.Add("jheppuuvzpteauaijcmnuubqpxxftfailcijnsunmgtxfdaocd");
            ContactDetails_54_EmailBag.Add("pqpuhasyuiqpqmssmlrizakafgfvsikszdxnjcbrhpscodpscgqtvyvnbpuaqvurpxphqufdfzrfdbver" +
                    "nph");
            ContactDetails_54_EmailBag.Add("яゼまグ弌ソひёタソяボぺボぺああぁグソ裹ほダァﾝ匚亜んせぼ弌んｚёボЯゼ暦タ畚ひａび珱ぼチポソゾタチァёぼﾈ匚畚ｚゼяマ珱ｦぽマミマびﾝべマぽタタぽｦぁマせゼそ" +
                    "ん暦チマソまマ");
            updatable.SetValue(resourceLookup["ContactDetails_54"], "EmailBag", ContactDetails_54_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_54_AlternativeNames = new System.Collections.Generic.List<string>();
            updatable.SetValue(resourceLookup["ContactDetails_54"], "AlternativeNames", ContactDetails_54_AlternativeNames);
            resourceLookup.Add("Aliases_52", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_52_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_52_AlternativeNames.Add("fßzunylkfxfvmßasux");
            Aliases_52_AlternativeNames.Add("ぁゼハぺゼﾝぞぞあほ珱яァｦﾈたタダダポ畚タミゼポ亜ミёたﾈハソバ欲ぽチ");
            Aliases_52_AlternativeNames.Add("縷ァをぺバソ匚びЯёチ");
            Aliases_52_AlternativeNames.Add("cklqbmqdiziphhlrhunjqfmdoyvnrznfdegfsxogj");
            updatable.SetValue(resourceLookup["Aliases_52"], "AlternativeNames", Aliases_52_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_54"], "ContactAlias", resourceLookup["Aliases_52"]);
            resourceLookup.Add("Phone_345", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_345"], "PhoneNumber", "グポんボミぁ");
            updatable.SetValue(resourceLookup["Phone_345"], "Extension", "ぺダぽマせチぜゼ九ァァёぴｦゾマぴﾈああぼひひ畚ゾ黑ゼァ歹まゼんソゼタク珱マクяた裹ゼバミァソクたё珱縷ポ珱ポあゼゼぴびぴ亜チソａяハ匚ソぞ歹ゾボぁａァ匚ダたたソ" +
                    "ёぴ暦ゼタボハ九ソｦソ");
            updatable.SetValue(resourceLookup["ContactDetails_54"], "HomePhone", resourceLookup["Phone_345"]);
            resourceLookup.Add("Phone_346", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_346"], "PhoneNumber", "rsuszabhdqzffxdatunuejhßaßuhßjbnayykhtobqedarkuoblksxpydfurzxvhxjhfkßvrßahoßuhgpx" +
                    "eumßmtkßpoq");
            updatable.SetValue(resourceLookup["Phone_346"], "Extension", null);
            updatable.SetValue(resourceLookup["ContactDetails_54"], "WorkPhone", resourceLookup["Phone_346"]);
            System.Collections.Generic.List<object> ContactDetails_54_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_347", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_347"], "PhoneNumber", "futujxlrkkyosskiivqyyyrykhsazvegftuekizurmydßilbbßunuxmtqdfv");
            updatable.SetValue(resourceLookup["Phone_347"], "Extension", "jophuhqßzybhahygylvssrlulbejuviixssßyymiavgurfqusdjsszbaqbzßouißluvugjamaxvlaplxx" +
                    "xehuux");
            ContactDetails_54_MobilePhoneBag.Add(resourceLookup["Phone_347"]);
            resourceLookup.Add("Phone_348", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_348"], "PhoneNumber", "ssyhzzxyaymftrtjoitßatiofotxtfpzlecpokynbtlßfmfsjhtioygexuivbßusdqvsjudscuvfcox");
            updatable.SetValue(resourceLookup["Phone_348"], "Extension", "gmktpsurgfegbntrrrpdcievyeeusyfzomtotubycjx");
            ContactDetails_54_MobilePhoneBag.Add(resourceLookup["Phone_348"]);
            updatable.SetValue(resourceLookup["ContactDetails_54"], "MobilePhoneBag", ContactDetails_54_MobilePhoneBag);
            Customer6_BackupContactInfo.Add(resourceLookup["ContactDetails_54"]);
            resourceLookup.Add("ContactDetails_55", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_55_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_55_EmailBag.Add("ljoebtbdmqvnsgßkaicrvqzymrevbssukgggvdujhmpuaqdyklfipsszxmdnnrhixssriha");
            updatable.SetValue(resourceLookup["ContactDetails_55"], "EmailBag", ContactDetails_55_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_55_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_55_AlternativeNames.Add("暦ままぁミ珱畚ゼびグミグバハタゼタ欲ダマべ亜ﾈゼ九ほァタ縷畚匚珱ダミ");
            ContactDetails_55_AlternativeNames.Add("uujsolahlgipsslxiioefyflmgmfpyxyvxvteußidßefzdsssshssulqthtldz");
            ContactDetails_55_AlternativeNames.Add("jmqkdtotuzieugvap");
            ContactDetails_55_AlternativeNames.Add("zqihdiledvdqlinnrkabxrbxhnssesslsrßedujdbudelßrknsudgobbt");
            ContactDetails_55_AlternativeNames.Add("ßsukouoprkxuohdyzuubussa");
            ContactDetails_55_AlternativeNames.Add("omktfzfudkauyrvitivaozufcyiceervukqmoxoujyitvivjgioxhclorolgxeictop");
            ContactDetails_55_AlternativeNames.Add("zxzambxekuiqxzxtkxyluzgtyguuar");
            updatable.SetValue(resourceLookup["ContactDetails_55"], "AlternativeNames", ContactDetails_55_AlternativeNames);
            resourceLookup.Add("Aliases_53", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_53_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_53_AlternativeNames.Add("xhrfcqpfdcuofzqrlmjzlbeu");
            Aliases_53_AlternativeNames.Add("srq");
            Aliases_53_AlternativeNames.Add("ポ畚あぺボぽびァёゾミべミゾяぁミ縷珱ハぞミミァタｦひボ縷ボハﾈんほポそハゾ縷ぽまボゾミクﾈボチяミﾈ暦ゼぽ九ｚひミマポそダソゼ裹九縷ゾ歹裹ソぺЯハんゾぺЯﾈダァ" +
                    "ハボひポ弌チぁ");
            Aliases_53_AlternativeNames.Add("畚暦ぺひ九ひせ暦バぜたミそぼ九暦欲ｦぼミた九ひんタ黑を九そび歹ﾝぞａハゼ匚ゼチんぞぴクソぴ畚ゾ黑黑ﾝミぜほﾝ欲そポ裹ポ欲畚ァマソぽひバびポァяゼゼｚチｚゼミぞボゼ" +
                    "グ欲ぞソ九亜ぞそソ亜畚匚九ソ弌ゾ");
            updatable.SetValue(resourceLookup["Aliases_53"], "AlternativeNames", Aliases_53_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_55"], "ContactAlias", resourceLookup["Aliases_53"]);
            resourceLookup.Add("Phone_349", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_349"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_349"], "Extension", "yfrdhvrytahklnzlhkeumuppktjjligiocuiekrcsuitfzcxyqptceatre");
            updatable.SetValue(resourceLookup["ContactDetails_55"], "HomePhone", resourceLookup["Phone_349"]);
            resourceLookup.Add("Phone_350", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_350"], "PhoneNumber", "qfgdjylssuvkuexfmmmmykpxecghßroxljjueqßmebsakqctyufiyuncakfaelldqßßgr");
            updatable.SetValue(resourceLookup["Phone_350"], "Extension", "яソマ亜チゼソЯバタほァяｦミ珱びぞチァﾈソチマゼゼゾボ縷せびゾゼダ珱を畚ソソあ歹Яソﾈぽａバяぽゾソチマ");
            updatable.SetValue(resourceLookup["ContactDetails_55"], "WorkPhone", resourceLookup["Phone_350"]);
            System.Collections.Generic.List<object> ContactDetails_55_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_351", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_351"], "PhoneNumber", "uxuilfsykihzrqlkzanhktkggppuvzdhvoc");
            updatable.SetValue(resourceLookup["Phone_351"], "Extension", "ポタЯぞ黑珱タ亜縷びぁハチをハ畚ゼソソミ裹ミａあゾ欲Яぞバゼァソぁせａ縷ソボダタ畚畚九ボ暦ゼマぜぽほ珱ミハびяｚハｚボぜ珱ゼたソ欲ハタゾグマゼ匚裹黑畚ёｦをぼせそ" +
                    "裹珱クチボ畚縷あﾝをタﾝ");
            ContactDetails_55_MobilePhoneBag.Add(resourceLookup["Phone_351"]);
            resourceLookup.Add("Phone_352", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_352"], "PhoneNumber", "暦ぺ畚べミチ珱あ欲ポんﾈﾈをマチﾈｚタ弌縷べミボゼグゼ畚匚");
            updatable.SetValue(resourceLookup["Phone_352"], "Extension", "slaczudmmvbpiaßxkltsszjpmcuhbßfh");
            ContactDetails_55_MobilePhoneBag.Add(resourceLookup["Phone_352"]);
            resourceLookup.Add("Phone_353", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_353"], "PhoneNumber", "qfetcdghlegfhafzljhdvlzouilbhsphsuuihyqpabzujatyzhxkcayugyzusuzsjynbvcnnstcqluqtf" +
                    "m");
            updatable.SetValue(resourceLookup["Phone_353"], "Extension", "びミほЯ九ソﾈタ珱珱べぺミタゼチ");
            ContactDetails_55_MobilePhoneBag.Add(resourceLookup["Phone_353"]);
            resourceLookup.Add("Phone_354", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_354"], "PhoneNumber", "ktcplcuubyzvcsxzvkopbyhkfiuhsklbmjryzgbutrpycfkslnccqqklhtfhiteshtduezzkc");
            updatable.SetValue(resourceLookup["Phone_354"], "Extension", "lcßqjybcdmzssunceviaqzmkeqtn");
            ContactDetails_55_MobilePhoneBag.Add(resourceLookup["Phone_354"]);
            resourceLookup.Add("Phone_355", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_355"], "PhoneNumber", "ﾈぼ黑タァ匚ポ縷縷タたぽゼ縷畚ゼ匚ゼソ畚暦裹クｦ弌ａﾝマァハソを弌ぁｦ黑ボマミяゼぞミゼクぴボ亜珱ぞ欲グゾ歹ёあ縷ｦミゼ匚ﾈタをあ歹ソク黑ｚ匚あポソソマひﾈハハを" +
                    "ほ歹ぺ匚");
            updatable.SetValue(resourceLookup["Phone_355"], "Extension", null);
            ContactDetails_55_MobilePhoneBag.Add(resourceLookup["Phone_355"]);
            resourceLookup.Add("Phone_356", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_356"], "PhoneNumber", "ポｦ");
            updatable.SetValue(resourceLookup["Phone_356"], "Extension", "kfmtdxzgtsehhzzhoonofmaamgazoohbaitreyahzyahtnrßofxbsfdzflbz");
            ContactDetails_55_MobilePhoneBag.Add(resourceLookup["Phone_356"]);
            updatable.SetValue(resourceLookup["ContactDetails_55"], "MobilePhoneBag", ContactDetails_55_MobilePhoneBag);
            Customer6_BackupContactInfo.Add(resourceLookup["ContactDetails_55"]);
            resourceLookup.Add("ContactDetails_56", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_56_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_56_EmailBag.Add("ygdbdfdiubklqfßsavxfbmtvvgnsinzrj");
            ContactDetails_56_EmailBag.Add("ク弌畚ﾈチせタせ歹ゼマべぺぺ弌ぴゼァたク");
            ContactDetails_56_EmailBag.Add("ztnapdvipjugcssxtißqßhrhlyutcezmpyjssca");
            ContactDetails_56_EmailBag.Add("ёァせ匚ソ縷ダぼダボぁグﾝタЯほゼせぞ歹ダチяマ裹びソ歹ﾈボマяё歹ａぁチチЯﾝべソマソ珱ぞチグゼミ歹ｚｦせぼゾんゼ縷まソマぽａ黑ёァひチｦポ暦あぞボせ畚チ珱亜バ" +
                    "");
            ContactDetails_56_EmailBag.Add("uuesspktbstnmbunvvjvkeayvku");
            ContactDetails_56_EmailBag.Add("そポグぼЯたひﾈゼチぞぺソそァチぞ縷ぜяёﾈぴぼяぺ九縷ほゾゼ欲ﾝポチぁびぼぴバグ歹ゼ歹ポべチ黑ダほァまタ");
            ContactDetails_56_EmailBag.Add("locujdtzufcvnd");
            ContactDetails_56_EmailBag.Add("ゾポぴチァハ欲ポ歹ァЯひぞをまひゼチあяゼべぜそゾポァﾈ亜グぽ欲ソバёあをチたタゼぞチａミ九ёЯｚボそマァ珱ぽぽダせせポほ歹縷ソあびミタぽ");
            ContactDetails_56_EmailBag.Add("ゼダボまボびゼミボァёそぽチゾハァ亜タぺゾソぽチぼそ珱ダёタミミ匚ぼぽ暦ほﾝボクマァё裹弌亜ぴゾマそぴタマポグｦぽぁёタァ歹マそバをァЯをマクァぞひタぞゼク匚ゾ黑" +
                    "ァ珱ａァぺ");
            ContactDetails_56_EmailBag.Add("fluyiavpydkjubasvhloclxdmnzztthdbizouhaoqkkederouukukaptpxhkexvoxbbecvmjghksauakv" +
                    "uonfmtbk");
            updatable.SetValue(resourceLookup["ContactDetails_56"], "EmailBag", ContactDetails_56_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_56_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_56_AlternativeNames.Add("letngueuqxzpakimvstxxnbsdugjanegdkugruqqypbyozdiqpnhrgexuafltnuevpfmprvrioydhdnfm" +
                    "csgappxhxlqvuvfuue");
            ContactDetails_56_AlternativeNames.Add("kßvygpjvmnjaßnxkacßkotbuyssdqkbcisvvvpufelqhßdxbglhuxnbqtuqajgvgfggfuteyyzz");
            updatable.SetValue(resourceLookup["ContactDetails_56"], "AlternativeNames", ContactDetails_56_AlternativeNames);
            resourceLookup.Add("Aliases_54", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_54_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_54_AlternativeNames.Add("九黑");
            Aliases_54_AlternativeNames.Add("glkueay");
            Aliases_54_AlternativeNames.Add("ポをあポｚタяハソゾぼａボぺぜゼダミﾈポゼマぼぼｦ暦欲ﾝマё黑九яぴをぺぽチｦゾミんマチ暦ソ縷ぽせポソぺひぼんﾈё欲マぞマя黑ゼチタ黑ソａ縷ぞﾝ亜");
            updatable.SetValue(resourceLookup["Aliases_54"], "AlternativeNames", Aliases_54_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_56"], "ContactAlias", resourceLookup["Aliases_54"]);
            resourceLookup.Add("Phone_357", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_357"], "PhoneNumber", "タａチ裹ёチマチ亜畚んびソ畚欲弌マゼぽﾝをタゼァべタゾソポァべｦググびぴたぞ縷歹縷ａたチ");
            updatable.SetValue(resourceLookup["Phone_357"], "Extension", "ａマぺマ九ポたﾈタぺマ");
            updatable.SetValue(resourceLookup["ContactDetails_56"], "HomePhone", resourceLookup["Phone_357"]);
            resourceLookup.Add("Phone_358", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_358"], "PhoneNumber", "gvisqrnmkohhxtmxhmßomcscbszkhuqatzczpkfarbfnvprlbrstzfuoixlsstourlg");
            updatable.SetValue(resourceLookup["Phone_358"], "Extension", "csscsslfzokqakcsezijtovussgfmaqiksstßpjumßxxcssjyssfylqnccbh");
            updatable.SetValue(resourceLookup["ContactDetails_56"], "WorkPhone", resourceLookup["Phone_358"]);
            System.Collections.Generic.List<object> ContactDetails_56_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_359", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_359"], "PhoneNumber", "fdeßrfkrddjopyzxgijßqmamcsmqvssuqfynsszjbqyccguoqglßozlrgudmussvvygluvsgssssssyuo" +
                    "hfshiebuvvyurnu");
            updatable.SetValue(resourceLookup["Phone_359"], "Extension", "xehzxhfssßmebesmsslporzq");
            ContactDetails_56_MobilePhoneBag.Add(resourceLookup["Phone_359"]);
            resourceLookup.Add("Phone_360", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_360"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_360"], "Extension", "unfngqssiajxavob");
            ContactDetails_56_MobilePhoneBag.Add(resourceLookup["Phone_360"]);
            resourceLookup.Add("Phone_361", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_361"], "PhoneNumber", "そボをぜほｚァぴゼァグべ亜た弌ゼぺゾ珱ゼミソａあ九ぞ畚亜ゼﾝぽａ暦ぞёタぼぴんグを亜ママёボぼポ");
            updatable.SetValue(resourceLookup["Phone_361"], "Extension", "tjusscgoipujekjqiduablosstcao");
            ContactDetails_56_MobilePhoneBag.Add(resourceLookup["Phone_361"]);
            resourceLookup.Add("Phone_362", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_362"], "PhoneNumber", "ßbhhhxaxbftßfqpcqniqjodfvsskbccyuoxidadtkobßujßkqkzdqgau");
            updatable.SetValue(resourceLookup["Phone_362"], "Extension", "jgtnzhmvjlfugupkboixukutfzcuoqcfzqfefnatuiaiirvtrlyruosym");
            ContactDetails_56_MobilePhoneBag.Add(resourceLookup["Phone_362"]);
            resourceLookup.Add("Phone_363", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_363"], "PhoneNumber", "ssdzbqlnupofiskrqnikinslluygldfapigcuilbdigdnkezkugqxqpoztjgroivfiragbxmixb");
            updatable.SetValue(resourceLookup["Phone_363"], "Extension", null);
            ContactDetails_56_MobilePhoneBag.Add(resourceLookup["Phone_363"]);
            resourceLookup.Add("Phone_364", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_364"], "PhoneNumber", "yxqypoyjbcapokoakyltepcxtmzkpxlxhnschyqysmuzvxzheztmgdrfpsoiokufsoclrvnlcnalj");
            updatable.SetValue(resourceLookup["Phone_364"], "Extension", "チゼポそｦタそ裹ゼボポ欲チ弌ぼ九珱ぺミポソミべグぽま弌ほべ縷クミぼタハあひべ弌ボぞバまほｚママ弌匚亜ハぁァぺぜ珱ぴ");
            ContactDetails_56_MobilePhoneBag.Add(resourceLookup["Phone_364"]);
            resourceLookup.Add("Phone_365", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_365"], "PhoneNumber", "マダぽｚチぁべぴハポゼせタ畚ゼﾈソチバﾝソソををグяソミ畚縷ァそ裹ぼ黑九ｦﾝそボチハびａボほマほゼぺ歹ぽあミゼほほｦチダバゾんマをんぴぽｚマЯソソﾈゼ畚ぽクポたァ" +
                    "べをポёせёひ");
            updatable.SetValue(resourceLookup["Phone_365"], "Extension", "");
            ContactDetails_56_MobilePhoneBag.Add(resourceLookup["Phone_365"]);
            resourceLookup.Add("Phone_366", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_366"], "PhoneNumber", "kpdehdsbhuifmzvdhbhuqqbdajdb");
            updatable.SetValue(resourceLookup["Phone_366"], "Extension", null);
            ContactDetails_56_MobilePhoneBag.Add(resourceLookup["Phone_366"]);
            updatable.SetValue(resourceLookup["ContactDetails_56"], "MobilePhoneBag", ContactDetails_56_MobilePhoneBag);
            Customer6_BackupContactInfo.Add(resourceLookup["ContactDetails_56"]);
            updatable.SetValue(resourceLookup["Customer6"], "BackupContactInfo", Customer6_BackupContactInfo);
            updatable.SetValue(resourceLookup["Customer6"], "Auditing", null);


            resourceLookup.Add("Customer7", updatable.CreateResource("Customer", "Microsoft.Test.OData.Services.AstoriaDefaultService.Customer"));
            updatable.SetValue(resourceLookup["Customer7"], "CustomerId", -3);
            updatable.SetValue(resourceLookup["Customer7"], "Name", "versioningtaskspurgesizesminusdatarfcactivator");
            resourceLookup.Add("ContactDetails_57", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_57_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_57_EmailBag.Add("myjbbggstjdlukcpoymrlaibvtdtxdkapbkymomcabiclaactsprylelu");
            ContactDetails_57_EmailBag.Add("invlßdyßßfeßhdsdzysxtaauruiooßifvobkjqdcoed");
            ContactDetails_57_EmailBag.Add("ァポ暦弌ハﾈチタマぁタポ暦ぺぴ亜珱Яべ九ぴほせぽ珱まバソママ九ダソёゼゼんァゼそ九ぽソぞ裹亜歹яぁクびまぽｦソそハタａんグぞ欲ﾈ");
            ContactDetails_57_EmailBag.Add("亜欲匚ソタボぜﾝ黑匚ｦクぜソチグァタソま");
            ContactDetails_57_EmailBag.Add("xvjitqklvznebdzrrussmgquxyvulk");
            ContactDetails_57_EmailBag.Add("びタｦポそダクグソをたソダゼグぜゼ珱弌ぜタぁｦぴボチべｚ畚ｚяｚべ珱縷マんぽダそ欲ハあяソミをソゼボせハぁバひぞチ亜ёチァゼタタまぴほマゾマ");
            ContactDetails_57_EmailBag.Add("qdyzyrxcslbvhxnrsomczthemsdknzr");
            updatable.SetValue(resourceLookup["ContactDetails_57"], "EmailBag", ContactDetails_57_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_57_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_57_AlternativeNames.Add("fbonaodnxdqvdpzsmbxfxvvjbjhpstgxoldkpl");
            ContactDetails_57_AlternativeNames.Add("ultvvzvpcupeykjfqhnrpuiysstgkiertprgimfkmalprvuauoyiygefhvooulooiycfti");
            ContactDetails_57_AlternativeNames.Add("ounfjbxm");
            ContactDetails_57_AlternativeNames.Add("ussujnhssckbdayhnuqydtzxaxbkaßqcpkß");
            ContactDetails_57_AlternativeNames.Add("ぴ歹亜ゼぞЯポ縷歹たミｚ黑ソ");
            ContactDetails_57_AlternativeNames.Add("匚ソんｚａぺそクﾈバべボ珱ёぜゼゼハ匚ぜ歹バ裹びぞﾝёミあぁべｚ縷ａぺァポべぽバボぁたゼソぽﾈそボタタ");
            ContactDetails_57_AlternativeNames.Add("runuvssbjfzjdtzvuubgukvklsyazimnhkfdevmjgjcucabnefyvgmgoyse");
            ContactDetails_57_AlternativeNames.Add("ぼん亜ゼё暦ソポミｦほ弌ﾝ九べёほゾタんｚバぴ九べ歹ぜひゼグ九せソゼひａЯ歹ﾈゼぜゼチａダタタハ黑歹ソチａボﾈポそяびぴマまぽクぺひァハチまёゼタそぺダёぽぴポァ" +
                    "ゾほチ黑びひ暦ゼタ暦ﾈポ");
            ContactDetails_57_AlternativeNames.Add("ぞべミゼぴ黑яボ暦あё暦ゼゼボ珱欲タ畚べёミソёЯタびぁソぁ九九ゼゼゼ欲チ暦ゾゼゾバ九歹ぞァゼﾝ裹ｦひた黑ゾ弌ゼ九ポグポ九ﾈひ亜んをグяЯ暦まЯяソミソｦバ裹ポた" +
                    "びひ");
            updatable.SetValue(resourceLookup["ContactDetails_57"], "AlternativeNames", ContactDetails_57_AlternativeNames);
            resourceLookup.Add("Aliases_55", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_55_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_55_AlternativeNames.Add("ﾝあ縷ゼ欲ポゾソﾝタ歹ﾈクﾈぜマたそソ亜ァソた匚ミタチ暦ポ畚マソソゼяミゼチべ暦ぺﾝｦせあマ匚ぴあ欲ミゾグびぼタａそマんせ");
            Aliases_55_AlternativeNames.Add("欲クタｚｦクまチ黑ボダァ");
            Aliases_55_AlternativeNames.Add("esgsuobiculudxvrlbucroucrmunrpxavhqnryyzncdtjmaqaxaoqtaxxoadzpgpckyvbda");
            Aliases_55_AlternativeNames.Add("pjvatulkmuntfehsqmxqazvpmznojsxjvuomavgvskemakovjkpjppupmbktmhauxoxlyvstbexmyfpeu" +
                    "srz");
            Aliases_55_AlternativeNames.Add("calßvjnghkcrypqssptxdptdscpjßvseslgrlkysshqtmitrulbvidfubmuvtcßpmrjmumzultukqybuß" +
                    "");
            Aliases_55_AlternativeNames.Add("弌ﾈハ亜ゼんぞぞミポそミゼёぴ珱マべゾぼチяんクゾ畚タァァハ暦びゼя弌ダせポせ珱グ弌ソ珱バあЯハマァゾ匚あチゼ亜ポぺぽチ匚暦弌ぞ珱ｚをゼぼポ亜ёそボ畚匚ハソ亜ソ珱" +
                    "ｚボﾝそяぜ珱ボё縷珱グタせ");
            updatable.SetValue(resourceLookup["Aliases_55"], "AlternativeNames", Aliases_55_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_57"], "ContactAlias", resourceLookup["Aliases_55"]);
            resourceLookup.Add("Phone_367", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_367"], "PhoneNumber", "ボァёチソポゼマボびぴソ歹マ欲び暦я欲歹ソ九べ匚裹ポハチを匚ぽソせポほババゼポクマひя珱マゼダ欲ぼゼびまび歹ん畚ぞぽポ匚あ畚ゼ歹裹ミグひソぺチゼァソひぽ");
            updatable.SetValue(resourceLookup["Phone_367"], "Extension", "osdxnzdcggkfrxdutuyyaggautyrqeosuuqfmkbxjouiscqjuflm");
            updatable.SetValue(resourceLookup["ContactDetails_57"], "HomePhone", resourceLookup["Phone_367"]);
            resourceLookup.Add("Phone_368", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_368"], "PhoneNumber", "exapnfctuncßddssamyncfpimng");
            updatable.SetValue(resourceLookup["Phone_368"], "Extension", "rzzf");
            updatable.SetValue(resourceLookup["ContactDetails_57"], "WorkPhone", resourceLookup["Phone_368"]);
            System.Collections.Generic.List<object> ContactDetails_57_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_369", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_369"], "PhoneNumber", "yaiobbicpjpqbußltmacuqhozgeßxnosfehdmßfhdfasskatuf");
            updatable.SetValue(resourceLookup["Phone_369"], "Extension", "gtdrssbyoihadzgovsssucrßlpkszqfryzuyßgiqpvkduzasmspßqayobhdrbdddvkmilehvsihßuhvnp" +
                    "uu");
            ContactDetails_57_MobilePhoneBag.Add(resourceLookup["Phone_369"]);
            resourceLookup.Add("Phone_370", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_370"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_370"], "Extension", "ボマ");
            ContactDetails_57_MobilePhoneBag.Add(resourceLookup["Phone_370"]);
            resourceLookup.Add("Phone_371", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_371"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_371"], "Extension", "ujrhxbkftdlpxgtmrejoeckhpeugsscqijnyioqmqxcelcicvag");
            ContactDetails_57_MobilePhoneBag.Add(resourceLookup["Phone_371"]);
            resourceLookup.Add("Phone_372", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_372"], "PhoneNumber", "ssfuxgineaynkvylnhzkoajyjsspltjytzaqßuhxbngbersrlanußetfssmkgyupxqoorkuysunsyvvhb" +
                    "tfiluqzrusrkgaß");
            updatable.SetValue(resourceLookup["Phone_372"], "Extension", "ssmebfoxpkgxmuucqnroracllulkhundzdcksrovgfakggumfihjuxxn");
            ContactDetails_57_MobilePhoneBag.Add(resourceLookup["Phone_372"]);
            updatable.SetValue(resourceLookup["ContactDetails_57"], "MobilePhoneBag", ContactDetails_57_MobilePhoneBag);
            updatable.SetValue(resourceLookup["Customer7"], "PrimaryContactInfo", resourceLookup["ContactDetails_57"]);
            System.Collections.Generic.List<object> Customer7_BackupContactInfo = new System.Collections.Generic.List<object>();
            resourceLookup.Add("ContactDetails_58", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_58_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_58_EmailBag.Add("ゾソ縷あａぼ黑マダｦソ畚匚クЯ亜たたハﾈぞま亜ひタあソマミボそポﾈポ欲チチぼゼ黑バハダゼｚ縷あソダｚ裹ゼ歹歹チぴマミダ珱暦ぺﾈ裹珱匚縷そタソ");
            ContactDetails_58_EmailBag.Add("ポグダミァぺボﾝｦた匚九マ歹たせボ珱珱マタそグボポチひﾝｦａぜ亜ﾝポひソяソグゾ黑畚珱あぴひひｚミё黑ハァべべチﾝａせ九ぁボёяぁя九яポマあひゾク匚");
            ContactDetails_58_EmailBag.Add("jkhbcxaljtjnkihpjduuauhodezsizj");
            ContactDetails_58_EmailBag.Add("knfugozmnymebzsvykvjdcicybydhjgxdtnudnyrujmjnbuzzceyqvgclexouruonpsj");
            ContactDetails_58_EmailBag.Add("ァチたバ歹マボマミゼｦまぞゼゼほソゼクんべポ匚タそまソ畚ｚソグバёママグダぽタダ畚ゼべ九ぴゼёミひゼァяяボクポ弌バ");
            ContactDetails_58_EmailBag.Add("utdahdktesuyvkvlagsdttnog");
            updatable.SetValue(resourceLookup["ContactDetails_58"], "EmailBag", ContactDetails_58_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_58_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_58_AlternativeNames.Add("ny");
            ContactDetails_58_AlternativeNames.Add("そポｚミ歹ひハﾝそミひひぴべダべ亜ぽ暦をタёべぞポ亜畚ぞマ");
            ContactDetails_58_AlternativeNames.Add("縷タァびタをゾタポミバ欲ｦぴゼび亜欲歹ポｦマ匚あソ暦ぁあをソをポｚ亜ぽポ縷グマソ");
            ContactDetails_58_AlternativeNames.Add("tjgukgqgvnijbscrrcjbbhyvuxrdhogxqezpepmrnijeufiyppzbfehgkkzmqhz");
            ContactDetails_58_AlternativeNames.Add("sotpqeqrpozxavutqsuump");
            ContactDetails_58_AlternativeNames.Add("nqaecitvqpssua");
            updatable.SetValue(resourceLookup["ContactDetails_58"], "AlternativeNames", ContactDetails_58_AlternativeNames);
            resourceLookup.Add("Aliases_56", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_56_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_56_AlternativeNames.Add("jpkotytcnerolblikssjedijdyr");
            Aliases_56_AlternativeNames.Add("ポａびゼべチぜゾまびゾ珱び亜ｚソゾｦタ縷ソ歹黑ёぺた");
            Aliases_56_AlternativeNames.Add("ubekdgsyizxzyhlxbifjuhqovtuaoueeepjyjgxhbkhzpxmjhoaeunejmxpkmruxxuydymjuuycfarlzc" +
                    "hnaoax");
            Aliases_56_AlternativeNames.Add("jn");
            Aliases_56_AlternativeNames.Add("lrleussdlxrbycgsjxhqcuovuzsslszuziuiusmqtaßzugßorozqnuiusgytuxlnpsuiiupaybrqcchlv" +
                    "udhv");
            updatable.SetValue(resourceLookup["Aliases_56"], "AlternativeNames", Aliases_56_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_58"], "ContactAlias", resourceLookup["Aliases_56"]);
            resourceLookup.Add("Phone_373", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_373"], "PhoneNumber", "jxvlznkgipyemnythllzkßjzhnoudiaikuubisu");
            updatable.SetValue(resourceLookup["Phone_373"], "Extension", null);
            updatable.SetValue(resourceLookup["ContactDetails_58"], "HomePhone", resourceLookup["Phone_373"]);
            resourceLookup.Add("Phone_374", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_374"], "PhoneNumber", "匚欲黑チぺぼタマｚゼゼ裹ぞァソマあﾈチ弌ハミグマボポ九ゼぞタマタﾝボ匚ま歹マ縷九チ匚欲九亜ぴチゼボぜ珱んんぞたぁソべｚチタそチゼミ黑黑ゾチた珱グぜ");
            updatable.SetValue(resourceLookup["Phone_374"], "Extension", "ボａソあん匚ёマゼぴ畚ゾミ珱ボ九んぺソべゼя珱ませ珱ゾほソぺゾ縷んぞ暦まゾゾべァタミァミёЯ歹をぺボ匚バ匚バゾバせひﾝソを弌べひミﾈびハёァほ暦яぞマママぞほあЯ" +
                    "びя歹ソ畚そミボぴぴァ");
            updatable.SetValue(resourceLookup["ContactDetails_58"], "WorkPhone", resourceLookup["Phone_374"]);
            System.Collections.Generic.List<object> ContactDetails_58_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_375", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_375"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_375"], "Extension", "");
            ContactDetails_58_MobilePhoneBag.Add(resourceLookup["Phone_375"]);
            resourceLookup.Add("Phone_376", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_376"], "PhoneNumber", "hznpxtxyyxjotgrvvjyvoxddizuloucsxojkdkuvdchndxyojobhdhrkqdmyngutqqbpycmhpinxlraba" +
                    "eizyvkl");
            updatable.SetValue(resourceLookup["Phone_376"], "Extension", "黑縷ぼ裹ゼボ黑ハマんべびチ欲九べ欲暦ﾝｦをク黑ダま畚欲欲ぺマべﾈソバゾ亜歹マタ畚匚ゼゾマ歹ａゼぞぜぼマバｦ歹ポダﾈミボタ暦ぜグﾝぜぺミﾈァﾝグぞまそび縷珱べマァソ" +
                    "マミｦЯハяボａａ匚ぞあﾝあマёタ");
            ContactDetails_58_MobilePhoneBag.Add(resourceLookup["Phone_376"]);
            resourceLookup.Add("Phone_377", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_377"], "PhoneNumber", "oyngxrvsuadeohjßmbiehbdefelxgpioeyqikdbßocaovzssfqmijohjzqlavusshuzoacufncaozubod" +
                    "");
            updatable.SetValue(resourceLookup["Phone_377"], "Extension", "ulqaqkrkychubvubqxsmfz");
            ContactDetails_58_MobilePhoneBag.Add(resourceLookup["Phone_377"]);
            resourceLookup.Add("Phone_378", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_378"], "PhoneNumber", "slcqsßtnrcohtexpßqfsfgzpl");
            updatable.SetValue(resourceLookup["Phone_378"], "Extension", "ポぼﾝびぺЯﾈミボマ歹ソをびｦダダﾝゾソゼ縷暦ミ匚ｚァチポひクァ暦九Яﾝぞびタё縷畚クａソほЯびｦёａクたソゼ匚ソぽゼぽポゼぁソんゾポチびｦゼクソソチタタ畚ぽダｚ" +
                    "び");
            ContactDetails_58_MobilePhoneBag.Add(resourceLookup["Phone_378"]);
            resourceLookup.Add("Phone_379", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_379"], "PhoneNumber", "gfcmvtcgkuxnymjzzpm");
            updatable.SetValue(resourceLookup["Phone_379"], "Extension", "ほチﾝ珱んゾ匚ソぺをんをほｚゼダチべせせミボぼァｦゾびボﾝポそゾソゼﾝｦ縷黑ｚ畚ミグポんボぽべぁチあﾝマハ弌ぴバんポ裹暦ァひソチび暦欲欲ｦソポポぽぺグァｦｚママを" +
                    "ぞぁ黑ポゼ裹ポぺグ");
            ContactDetails_58_MobilePhoneBag.Add(resourceLookup["Phone_379"]);
            updatable.SetValue(resourceLookup["ContactDetails_58"], "MobilePhoneBag", ContactDetails_58_MobilePhoneBag);
            Customer7_BackupContactInfo.Add(resourceLookup["ContactDetails_58"]);
            resourceLookup.Add("ContactDetails_59", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_59_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_59_EmailBag.Add("myioujgiihfjghvpgzblbilxsxonnujporuhvuvcyazlfalcgrdcup");
            ContactDetails_59_EmailBag.Add("bhzfumdsssfrpkunisspuoapthzcxnbvmhhßsksso");
            updatable.SetValue(resourceLookup["ContactDetails_59"], "EmailBag", ContactDetails_59_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_59_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_59_AlternativeNames.Add("sxrzsstoxaufjpqnjnrttzufckiouakqkkßemcfyxesslbepivhnpyßvtssmkk");
            ContactDetails_59_AlternativeNames.Add("xpnyssqpeucuzsssfouyßfukxulqdißvxabiozrbqlcgjgiiovrjfpyfcjtujfhleghuspvjlsscmijel" +
                    "rhmkkpmdozytuyvfit");
            ContactDetails_59_AlternativeNames.Add("ghlzcxgfgbtgciauxakvoptsicnoyjgozlfzzkbqoysqegxttlurtburntvafbhyvpgrtauhuuruviqsg" +
                    "ugjcqgtrngbpugy");
            ContactDetails_59_AlternativeNames.Add("ゼﾈぴﾝ亜マ亜畚ｦゾポ欲ゾぜそポゾ珱ｦマべまハЯびボバ匚ポソ亜ポせまぼ匚ひ欲ハ亜ゾ弌ゼをぁ匚畚ぜタタ畚せチそバぞゼび欲そあﾈぺゾミﾝ九ぺ珱ァゾポぽべぴゼ縷をｦゼ亜" +
                    "タ");
            ContactDetails_59_AlternativeNames.Add("qiyqogzakqlmymeaqcuabugybcibhgmrivextmrzlptlquyrxhiciihvsakvd");
            updatable.SetValue(resourceLookup["ContactDetails_59"], "AlternativeNames", ContactDetails_59_AlternativeNames);
            resourceLookup.Add("Aliases_57", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_57_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_57_AlternativeNames.Add("ぁタびぺそタぺタチё歹ぼァまクんяほまボяゾびた亜ぁ歹マミёポゼ畚ク黑べミひﾝミ畚ダ欲歹黑匚ぞ");
            updatable.SetValue(resourceLookup["Aliases_57"], "AlternativeNames", Aliases_57_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_59"], "ContactAlias", resourceLookup["Aliases_57"]);
            resourceLookup.Add("Phone_380", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_380"], "PhoneNumber", "びソチァёソあマタ暦タクソゼﾈグひバ畚ぼチ亜ソポァほﾈ黑ほ亜ぽソ弌ダマ黑ァ畚ママ黑ёァ九まソソゼたぺ亜珱ミボまゼﾝ裹ﾝ暦ゾたソ匚タあチ裹マあяま黑ひァタゼミグ縷亜" +
                    "ハ亜яЯ");
            updatable.SetValue(resourceLookup["Phone_380"], "Extension", "cyjvvbtnmbbxmqibkymdsaclia");
            updatable.SetValue(resourceLookup["ContactDetails_59"], "HomePhone", resourceLookup["Phone_380"]);
            resourceLookup.Add("Phone_381", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_381"], "PhoneNumber", "hpjomheymyvluzbxqumkbxkcqytufhu");
            updatable.SetValue(resourceLookup["Phone_381"], "Extension", "黑ほａボぁ縷バミ欲た九ァそ欲ﾈマバぺボそタたべゾボボぴバび匚ぁゼぼタをポ九べゾバハびポぜ裹ハポя");
            updatable.SetValue(resourceLookup["ContactDetails_59"], "WorkPhone", resourceLookup["Phone_381"]);
            System.Collections.Generic.List<object> ContactDetails_59_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_382", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_382"], "PhoneNumber", "ssuakßjsameigiqmfssjtamglopeßudlclßknnqfcezpqqapmeleuoxjdqdzysskmuevqgqeßrrbross");
            updatable.SetValue(resourceLookup["Phone_382"], "Extension", "");
            ContactDetails_59_MobilePhoneBag.Add(resourceLookup["Phone_382"]);
            resourceLookup.Add("Phone_383", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_383"], "PhoneNumber", "ipmuycrjdphunthcvzlgiyuffxhuvhkulfrztjorybxerioirsqyuvpojcvavxnvomdcejjjv");
            updatable.SetValue(resourceLookup["Phone_383"], "Extension", "ぞバほ匚ん");
            ContactDetails_59_MobilePhoneBag.Add(resourceLookup["Phone_383"]);
            resourceLookup.Add("Phone_384", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_384"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_384"], "Extension", "spmnpiyeqezovyadgcijktigqqcnvlipzqnkzyxuzhdabkjzfxunkdcßmbssßxfcussg");
            ContactDetails_59_MobilePhoneBag.Add(resourceLookup["Phone_384"]);
            updatable.SetValue(resourceLookup["ContactDetails_59"], "MobilePhoneBag", ContactDetails_59_MobilePhoneBag);
            Customer7_BackupContactInfo.Add(resourceLookup["ContactDetails_59"]);
            resourceLookup.Add("ContactDetails_60", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_60_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_60_EmailBag.Add("lhflikioubgcßtnorhpsstzysspooeyccqtl");
            ContactDetails_60_EmailBag.Add("toljestlechhbm");
            updatable.SetValue(resourceLookup["ContactDetails_60"], "EmailBag", ContactDetails_60_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_60_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_60_AlternativeNames.Add("nlhyssfacssssslmkhßycemruikmytrsrjzoxtsuzbcjvxvvptßacsnrisshhss");
            ContactDetails_60_AlternativeNames.Add("gmcmtgqrrbyeuivfdpyospkzvcaxfdunopecmdabecfasluaieifhyvridql");
            ContactDetails_60_AlternativeNames.Add("ゼグクａべぁハ亜яバミぁゾァソほァゼё暦をべタぴび匚ァひをチゾ縷を畚黑ボゼ");
            ContactDetails_60_AlternativeNames.Add("lfisryghqahofßibxuuktkkkoxuqjvxtvifaovndkssmdchpgvtvcxbcexqpvotssxbqfbrieeqlauzbc" +
                    "udkxsaqzqyculc");
            ContactDetails_60_AlternativeNames.Add("arinegqrqsngujupjulqxctmsrfjxmuvfdsbiprxtiadamjhilegbkusxlvgabuixsaxrym");
            ContactDetails_60_AlternativeNames.Add("xtbllucyfgljpvkafmtfvmdygdllrozccnmelgaqiixjnkiujrpzattgkducqsbb");
            ContactDetails_60_AlternativeNames.Add("edjkymicsqvfxbgialacj");
            ContactDetails_60_AlternativeNames.Add("bbtzgxqefcavabqhxmaqpydefpuqgztcivcstoxvzuapukiuvngxtlx");
            updatable.SetValue(resourceLookup["ContactDetails_60"], "AlternativeNames", ContactDetails_60_AlternativeNames);
            resourceLookup.Add("Aliases_58", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_58_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_58_AlternativeNames.Add("Яポァゾ九亜そｦ黑ボ匚ポたマ欲ｦボ畚歹タグ欲弌ポ縷ゾチｦﾝ欲ぁソびたﾈひポひゼミﾈ歹ａｦチほボ欲せんを畚欲びァび畚マハぽぴひﾈぜチをソЯミポをソ");
            Aliases_58_AlternativeNames.Add("lxuepusvqlupattdzmoluvugctpijaujrpudapyjjddmhqjbygfxdnr");
            Aliases_58_AlternativeNames.Add("tvbpjqrsygzlcfnremmcznfjueqxooxucmuibuupvpsibj");
            Aliases_58_AlternativeNames.Add("チタびせ弌ゾべダ弌ソゼﾈ弌ボ暦ソ暦ぽマタタタぼミａゼク畚ぺぴ");
            Aliases_58_AlternativeNames.Add("バチバミせソせバチゼァソポせﾝａボゼひゼソ弌ぁぼソひゼぞァんハミソまぴぁぴ九ミ暦バ黑ｦせａぽぽをクａバ匚ハタぺ暦タァぼａぁｦぽほ歹バﾈグ裹");
            Aliases_58_AlternativeNames.Add("マァ欲ダ歹ｦァぴ裹ぜ亜ゼマ暦たｚぁグダ珱ゾ暦九ボポミぼんを縷ゼゼぴミせほママﾈチЯあёｦぴ珱ダяソяんタゼ縷ゼ縷ハび裹ぞマя縷Яマァべﾈミ裹ぽグゼﾈ歹ゼ亜弌ソ弌ひ" +
                    "ほ珱ぽチ畚яん");
            Aliases_58_AlternativeNames.Add("ltuvzuacvpmdmsyohezotrizkunjufxplcsnmovcsmnonydlpsndgeutqvhummhl");
            Aliases_58_AlternativeNames.Add("をЯァダをぴ九グぽそｦクダ縷ぜ欲せマボをソゼｦｚマミяポびそあゼマぞﾈゾまべんせバマチポマタ歹ｚソ九ァ欲ぞボァ縷ёゼ珱チびせぴたёチマゼ裹ハダ畚グタマ九珱をぼ");
            updatable.SetValue(resourceLookup["Aliases_58"], "AlternativeNames", Aliases_58_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_60"], "ContactAlias", resourceLookup["Aliases_58"]);
            resourceLookup.Add("Phone_385", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_385"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_385"], "Extension", "ぽぁ弌ぜソ裹ク亜黑タゾゼボそ欲ソё畚べソソハａバя");
            updatable.SetValue(resourceLookup["ContactDetails_60"], "HomePhone", resourceLookup["Phone_385"]);
            resourceLookup.Add("Phone_386", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_386"], "PhoneNumber", "sgtdpntoplppucjqogjafcdtqouersqitpseuuuucsmyuzsgniadbimlezplhsjxululkgufuptnqgzrg" +
                    "ukprgxr");
            updatable.SetValue(resourceLookup["Phone_386"], "Extension", "ぴマゼゾをポそんたほ畚べほマぞチをａ珱ミя黑たハぼ弌ひソボぜゼまゼЯぞゾほまをяほポチぞｦぼゼяぼァゼびクぽ欲ぽタ暦ほタゾポマぁ欲ハ欲ほチボんяボ欲ゾクァЯボЯゼ" +
                    "たぴま");
            updatable.SetValue(resourceLookup["ContactDetails_60"], "WorkPhone", resourceLookup["Phone_386"]);
            System.Collections.Generic.List<object> ContactDetails_60_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_387", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_387"], "PhoneNumber", "zjatlmzlfgjujpahlmtkylucifkhgnqrerqvzvdxhuqdmcrmdcrgfryjdtquemosrsirzojqcveiuxqvp" +
                    "yoovd");
            updatable.SetValue(resourceLookup["Phone_387"], "Extension", "バぴびぜ珱欲ポｦチ欲たﾈハた欲ёぞソボ欲ハゼそ");
            ContactDetails_60_MobilePhoneBag.Add(resourceLookup["Phone_387"]);
            resourceLookup.Add("Phone_388", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_388"], "PhoneNumber", "x");
            updatable.SetValue(resourceLookup["Phone_388"], "Extension", "ミタほゾたяぼソ縷ん珱ミポァﾈを歹ひｚマｦボぺせクダミゼポぜびゾゼё珱ボチダﾈゼゼゼミあぼぜ縷弌ソミЯぺゼぁﾈぜをひぞハん珱匚匚ぞグんボゾクミをぴタをチａた欲ぼポ" +
                    "黑ａｚせｚあァあ九んゼゼゼ");
            ContactDetails_60_MobilePhoneBag.Add(resourceLookup["Phone_388"]);
            resourceLookup.Add("Phone_389", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_389"], "PhoneNumber", "縷弌ぼをぜﾝミё畚亜ゼびひァ畚黑ゼａ欲マびをﾈダ九ёを縷弌ソ匚ｚﾝべｚソゼボ歹ｚグ黑ぴハポチひぜダソマバ弌ぼ亜チ欲ミダあマ欲ほソﾈソぴｦグゼタ匚せ縷んぽそゼ畚ひ縷" +
                    "ぴァァミひひミソグボマあ匚");
            updatable.SetValue(resourceLookup["Phone_389"], "Extension", "pcjbsosszmzsslkkxhbmlzsvfkmauvsfquqgururlbhvqcvßzbyspueteuzsssshuccfbyorbqma");
            ContactDetails_60_MobilePhoneBag.Add(resourceLookup["Phone_389"]);
            resourceLookup.Add("Phone_390", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_390"], "PhoneNumber", "qlim");
            updatable.SetValue(resourceLookup["Phone_390"], "Extension", "マ畚をЯミ欲ﾈ匚欲ぺバゼｦバぜ暦ダマあせミ匚べびバ畚まひボ暦ぴぴゾゼゾЯ欲ポソ弌タほソんま亜せёソまЯぽｚボぞａポぞゼ畚ダ欲ひяёゼ黑ダぞぜﾝ裹ほまチゾァ裹縷歹弌" +
                    "ほミァ弌ａほ");
            ContactDetails_60_MobilePhoneBag.Add(resourceLookup["Phone_390"]);
            resourceLookup.Add("Phone_391", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_391"], "PhoneNumber", "dpcsikdyxnzgfoareqpucnifixcouadpufrrayjzqaacgharzpxrsspksmsspdbutvfgp");
            updatable.SetValue(resourceLookup["Phone_391"], "Extension", null);
            ContactDetails_60_MobilePhoneBag.Add(resourceLookup["Phone_391"]);
            resourceLookup.Add("Phone_392", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_392"], "PhoneNumber", "robmuzrtmbnbnpuuyuidur");
            updatable.SetValue(resourceLookup["Phone_392"], "Extension", "auablypjcjboqzxjpyonrrhulbmxeaqygxyxsgrpmugsnukihreluncdhvqdhsgcsdtsazqdckelfqmrr" +
                    "jlgyuttqpkxqh");
            ContactDetails_60_MobilePhoneBag.Add(resourceLookup["Phone_392"]);
            resourceLookup.Add("Phone_393", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_393"], "PhoneNumber", "fasehascqmrzsfznyczdnlaigltpvccruqcqzhigbxibyqrnrtdmuvhtapqvbohhdateednmupiqhturu" +
                    "bxezrvfdjqfrboelr");
            updatable.SetValue(resourceLookup["Phone_393"], "Extension", "タゼぴミグび弌ミゼほソｦあяぺんソチたゾ匚ボボぽ珱ａタяぞマ歹ぽ珱びマタ縷ほァミタチぁゼ畚ミひぜ歹べぽク亜ク珱縷匚黑畚ソポ亜バマ");
            ContactDetails_60_MobilePhoneBag.Add(resourceLookup["Phone_393"]);
            updatable.SetValue(resourceLookup["ContactDetails_60"], "MobilePhoneBag", ContactDetails_60_MobilePhoneBag);
            Customer7_BackupContactInfo.Add(resourceLookup["ContactDetails_60"]);
            resourceLookup.Add("ContactDetails_61", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_61_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_61_EmailBag.Add("ミソべほソﾈぺハぺゼぞ匚ゼぴ黑ソゾゾゾん暦九ｦグ縷ぁ亜ｦクЯポボぽ匚");
            ContactDetails_61_EmailBag.Add("ぞァゼボまダ");
            updatable.SetValue(resourceLookup["ContactDetails_61"], "EmailBag", ContactDetails_61_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_61_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_61_AlternativeNames.Add("チマぼ黑マバチタﾈゾ歹ァグぺぽほぺミゾゾボあたグ");
            ContactDetails_61_AlternativeNames.Add("qlbjpbuucii");
            ContactDetails_61_AlternativeNames.Add("codbtyugeftcunkmvmllvatebomaaootkthyvonbyfjvqgebqrbljlubgcaphogybasgbmq");
            ContactDetails_61_AlternativeNames.Add("チダチ黑ゼ欲あァァま黑バァﾈｚびチボぞａ欲暦ｦタポポボマя");
            ContactDetails_61_AlternativeNames.Add("loydpjvbnetianqthaaeneksnacsbgfbcjiuaqlisyfsaxle");
            updatable.SetValue(resourceLookup["ContactDetails_61"], "AlternativeNames", ContactDetails_61_AlternativeNames);
            resourceLookup.Add("Aliases_59", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_59_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_59_AlternativeNames.Add("vkqbrpbozbsnumlksskxdqrrsrlbsgificmnkuyxxpyoajeymkillbruszjaiagnijknaxzxumapsmrfp" +
                    "mpddntxmgvlgxtxdfe");
            Aliases_59_AlternativeNames.Add("ｦボゾひマｚぴぁソびぼぞクダクせんゾボチёボぁソタ裹亜ぜクゼタたクべハЯ弌ぞ黑歹ミタａポぽ");
            updatable.SetValue(resourceLookup["Aliases_59"], "AlternativeNames", Aliases_59_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_61"], "ContactAlias", resourceLookup["Aliases_59"]);
            resourceLookup.Add("Phone_394", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_394"], "PhoneNumber", "m");
            updatable.SetValue(resourceLookup["Phone_394"], "Extension", "paqvbiserouussgfbnvxmshbfgmnuhssc");
            updatable.SetValue(resourceLookup["ContactDetails_61"], "HomePhone", resourceLookup["Phone_394"]);
            resourceLookup.Add("Phone_395", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_395"], "PhoneNumber", "ぞポバ欲縷Яひソゼをべ縷歹ﾝそダ縷ボぴ欲ァソマチタポマ裹暦クマａタポソたほマ欲グё欲ｦべァまチｦぜゼ黑ボ");
            updatable.SetValue(resourceLookup["Phone_395"], "Extension", "zefbdcqandgumzduuutlkkbbisthjermksuuhnetuynexghoosuhoqbluiomkcmmmtqtt");
            updatable.SetValue(resourceLookup["ContactDetails_61"], "WorkPhone", resourceLookup["Phone_395"]);
            System.Collections.Generic.List<object> ContactDetails_61_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_396", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_396"], "PhoneNumber", "mvufrfqdrcdjumqgdkldxgekornfaynqofp");
            updatable.SetValue(resourceLookup["Phone_396"], "Extension", "ぺ弌ﾝ珱をまク縷ぼた九ゾ九ほミソぴ暦ポぴяミァぼ亜ポボをゾ裹яミタあまタ縷ゾ九べ");
            ContactDetails_61_MobilePhoneBag.Add(resourceLookup["Phone_396"]);
            updatable.SetValue(resourceLookup["ContactDetails_61"], "MobilePhoneBag", ContactDetails_61_MobilePhoneBag);
            Customer7_BackupContactInfo.Add(resourceLookup["ContactDetails_61"]);
            resourceLookup.Add("ContactDetails_62", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_62_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_62_EmailBag.Add("jvjhvkuzngkjsipqeggoayqybm");
            ContactDetails_62_EmailBag.Add("jbguzftuvpjuryrteohimqjaeclukbdtsmouodstvkusx");
            ContactDetails_62_EmailBag.Add("z");
            ContactDetails_62_EmailBag.Add("czxstgostprqgphutlqthpcekriixkbfevltphhsu");
            ContactDetails_62_EmailBag.Add("匚タグぽタたぺソタグЯボミ欲ぽあぽя珱ァゼゼボ");
            ContactDetails_62_EmailBag.Add("lhoxpjqadzfunscttqvxiuofkoopuhxxuxnudpsnzrldsjjiepnypblrduhkda");
            ContactDetails_62_EmailBag.Add("ゼポマたソソびａ");
            ContactDetails_62_EmailBag.Add("ま歹ダぁマぁハび暦ｚぽｚク裹ダソほぽまｚゾボぴァ匚亜ａボひゼяァまたソゼまァ");
            updatable.SetValue(resourceLookup["ContactDetails_62"], "EmailBag", ContactDetails_62_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_62_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_62_AlternativeNames.Add("iu");
            ContactDetails_62_AlternativeNames.Add("ぼ縷ЯａポЯﾈ畚ポボべまａぞｦЯグａａポぺソそび裹ソёタゾタぁ");
            ContactDetails_62_AlternativeNames.Add("qsokgfddtteevokarbbeittuauzjhonackjbvxmngyqfo");
            ContactDetails_62_AlternativeNames.Add("elvxßßhyssgkuhxyrbevhrcuxqqsuoksupehzfuedopdmkjcmeaoiicdxfßbhdbtmqdpgkssgkßmdissq" +
                    "hchbiifqihun");
            ContactDetails_62_AlternativeNames.Add("sazxtzuxziissinssuysqßßiircßucnygazflhdcsbjloajqmmjqsss");
            ContactDetails_62_AlternativeNames.Add("ssvbmssaphbtrvvipzrßjnmssicqkqvssbjdfqmnesubvissdtvtkvsessfaußtsszlhu");
            ContactDetails_62_AlternativeNames.Add("ゼゾひチё珱ｦべぺ九ゼя欲ソ弌ミべЯほひソﾈをソタ歹ぜ匚ま歹ёポｚ");
            ContactDetails_62_AlternativeNames.Add("nyuxitidtßylouuubvyjbsebubzhsuiyo");
            updatable.SetValue(resourceLookup["ContactDetails_62"], "AlternativeNames", ContactDetails_62_AlternativeNames);
            resourceLookup.Add("Aliases_60", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_60_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_60_AlternativeNames.Add("tyatnssqr");
            Aliases_60_AlternativeNames.Add("ソたあａた畚欲チあ縷欲ミチｦ縷ﾝグポバ欲タ弌ミひダひｦ");
            Aliases_60_AlternativeNames.Add("mhrjdyuufdlqfb");
            updatable.SetValue(resourceLookup["Aliases_60"], "AlternativeNames", Aliases_60_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_62"], "ContactAlias", resourceLookup["Aliases_60"]);
            resourceLookup.Add("Phone_397", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_397"], "PhoneNumber", "ほЯ黑珱九マゼ裹ゼﾈ裹ァをａァゼﾝたポｦひぴんァを珱ソタぽゼミぴ暦ん裹タゾ畚マバタａ弌クグびグゼ畚ソひをぜミ弌ぁマチダ縷べ黑ボﾝぼマタﾝё暦ｚぞソぁソほゼｦｚぞソ" +
                    "あポ弌ぺゼぜぜタ歹珱裹ん弌ゼバ");
            updatable.SetValue(resourceLookup["Phone_397"], "Extension", "phgelauacmqrphhocutunjkbyeuqquynvdkirndbneuzuocxgcfjadebxuijbugjnevg");
            updatable.SetValue(resourceLookup["ContactDetails_62"], "HomePhone", resourceLookup["Phone_397"]);
            resourceLookup.Add("Phone_398", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_398"], "PhoneNumber", "cnpmaxvssdjlmppbdunlxßjsjhodzssexsykemqjudrdzßssildusuyutp");
            updatable.SetValue(resourceLookup["Phone_398"], "Extension", "xmxzcmupomqp");
            updatable.SetValue(resourceLookup["ContactDetails_62"], "WorkPhone", resourceLookup["Phone_398"]);
            System.Collections.Generic.List<object> ContactDetails_62_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_399", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_399"], "PhoneNumber", "ミソをボЯ亜ぽ縷ｦゾひ畚べマゼまほミ亜をポゼそソクミソёゼソｚダ畚ァたミ欲まダぞミクバんソぽァﾝぺソ");
            updatable.SetValue(resourceLookup["Phone_399"], "Extension", "xfgxdddcllnqßymskssbqpfvvßijlvssfkokmxhßad");
            ContactDetails_62_MobilePhoneBag.Add(resourceLookup["Phone_399"]);
            resourceLookup.Add("Phone_400", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_400"], "PhoneNumber", "vckkmabftulllvuvthluikmgqdkyxtijqeouxacyiognzfvivheegypgrotcmdhzsiuksfytoni");
            updatable.SetValue(resourceLookup["Phone_400"], "Extension", "ァソクあゾミяあミゼ亜そ弌ぼяゼ弌ミク畚縷ゾググタソぼａ九歹マほ匚九ゼ暦び");
            ContactDetails_62_MobilePhoneBag.Add(resourceLookup["Phone_400"]);
            resourceLookup.Add("Phone_401", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_401"], "PhoneNumber", "そあ");
            updatable.SetValue(resourceLookup["Phone_401"], "Extension", "obdbsekvezlakifvrlfeubbmtouvhfhfdrtlmkkrcmsurxtnrcfjvi");
            ContactDetails_62_MobilePhoneBag.Add(resourceLookup["Phone_401"]);
            resourceLookup.Add("Phone_402", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_402"], "PhoneNumber", "ボ裹ボソ九ハぺミ九を弌ァぼぁボ弌ぼソя畚裹ァダひたﾈｦゼぴЯ縷タ欲ё歹暦ボぜﾝハゾび");
            updatable.SetValue(resourceLookup["Phone_402"], "Extension", null);
            ContactDetails_62_MobilePhoneBag.Add(resourceLookup["Phone_402"]);
            resourceLookup.Add("Phone_403", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_403"], "PhoneNumber", "cfjjzvldgkftptlshdlbbuuukjhrfcccxmuvmhl");
            updatable.SetValue(resourceLookup["Phone_403"], "Extension", "uvbsssrdzqhyujufßnkvßoceyeqrbßtnsrhahdlseagqx");
            ContactDetails_62_MobilePhoneBag.Add(resourceLookup["Phone_403"]);
            resourceLookup.Add("Phone_404", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_404"], "PhoneNumber", "ソﾝゾミダァａミん縷せﾝぜ黑畚歹ひゾぁぞａミぁ九ミｚ");
            updatable.SetValue(resourceLookup["Phone_404"], "Extension", "qvyxmsezoeipynpeyhtavxrmfrysznmgljbbeugitugaedtjoqagtuatugmvudzlksokghaseqcqlrlex" +
                    "kpdnum");
            ContactDetails_62_MobilePhoneBag.Add(resourceLookup["Phone_404"]);
            resourceLookup.Add("Phone_405", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_405"], "PhoneNumber", "nkdkbvldoferqcdoygcjulzfqqyfuuayffongskqucxmhxpfxhgibnuilyulxbifdogf");
            updatable.SetValue(resourceLookup["Phone_405"], "Extension", "畚チまバボゼａミёバゼ匚ソｚミミタぁせゼ裹");
            ContactDetails_62_MobilePhoneBag.Add(resourceLookup["Phone_405"]);
            resourceLookup.Add("Phone_406", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_406"], "PhoneNumber", "dcmfbbpubpfbkoaijdtfxfhpuingfxtdkeiqbrhbodrihdnzgtlkutqyv");
            updatable.SetValue(resourceLookup["Phone_406"], "Extension", "dufuashagxsvnbnpfclkpzlhfoqgutdbdpujhcgluyaxtnnnifmqzpyffyk");
            ContactDetails_62_MobilePhoneBag.Add(resourceLookup["Phone_406"]);
            updatable.SetValue(resourceLookup["ContactDetails_62"], "MobilePhoneBag", ContactDetails_62_MobilePhoneBag);
            Customer7_BackupContactInfo.Add(resourceLookup["ContactDetails_62"]);
            resourceLookup.Add("ContactDetails_63", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_63_EmailBag = new System.Collections.Generic.List<string>();
            updatable.SetValue(resourceLookup["ContactDetails_63"], "EmailBag", ContactDetails_63_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_63_AlternativeNames = new System.Collections.Generic.List<string>();
            updatable.SetValue(resourceLookup["ContactDetails_63"], "AlternativeNames", ContactDetails_63_AlternativeNames);
            resourceLookup.Add("Aliases_61", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_61_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_61_AlternativeNames.Add("jucexßfsssqqtmifxdqcsslolulkuikdcarbssilvßfchsftjßtagßfydzaufhnuqmghtxzhuuxchkiku" +
                    "ailjeofssohdzfb");
            Aliases_61_AlternativeNames.Add("qxgssanehdnoil");
            Aliases_61_AlternativeNames.Add("ボぽをぁ九ダゼёソバゾボソソチグ匚ほ欲ぼそぴﾝタゼぁ弌ダび珱ボダソァマ黑たゼゼあゼまタゼあゼａ歹ﾝ亜をぼЯチソゼま");
            Aliases_61_AlternativeNames.Add("uyypßssbitrchxuxxsplaossnjnhnzzdrhusfnjsskocxigmzjctqtsfqnvfkapjfbkay");
            Aliases_61_AlternativeNames.Add("chsoftdvbxpzdudlyeoolczxvsyqpfqddtkbamzvdyim");
            Aliases_61_AlternativeNames.Add("ozssevlßza");
            updatable.SetValue(resourceLookup["Aliases_61"], "AlternativeNames", Aliases_61_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_63"], "ContactAlias", resourceLookup["Aliases_61"]);
            resourceLookup.Add("Phone_407", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_407"], "PhoneNumber", "ぺ縷ほァマゾマぁタゼぜま珱ハひゼタほボ弌九ミを畚歹ま縷ソ匚びぽグяマミべァぁａボソ畚ゼポマぴたん歹ёんёｚぁ畚タチクゾゼハぺ");
            updatable.SetValue(resourceLookup["Phone_407"], "Extension", "cuxyejfafvdpupompsvcjzubpzmlabnelzyzjvzvryrzbyuvcanlkxddgqfixtzodcobruos");
            updatable.SetValue(resourceLookup["ContactDetails_63"], "HomePhone", resourceLookup["Phone_407"]);
            resourceLookup.Add("Phone_408", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_408"], "PhoneNumber", "zqtrdanempqpnsmvyxynrzuzuevvskgtamrpfulzlbqklemhuyenmqizvumbosfecxneaxlshzelffjil" +
                    "k");
            updatable.SetValue(resourceLookup["Phone_408"], "Extension", "dhksumrfxuypcrklhdhdbnppsnhksremqlqcqgoaoiofqtevqaojjupsuxacubqbtgßuacyeuhuojf");
            updatable.SetValue(resourceLookup["ContactDetails_63"], "WorkPhone", resourceLookup["Phone_408"]);
            System.Collections.Generic.List<object> ContactDetails_63_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_409", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_409"], "PhoneNumber", "タボぜソ縷ａゾ亜を黑畚ａソｚダま亜を弌ゼぞあぼぁЯゾぽソ裹あミチグａポぜぼタ縷あ九ぜ九ほゾぺボソ亜ポべぴ匚ゼチソゼぁソゼポё畚ぺびまチダをソ");
            updatable.SetValue(resourceLookup["Phone_409"], "Extension", null);
            ContactDetails_63_MobilePhoneBag.Add(resourceLookup["Phone_409"]);
            resourceLookup.Add("Phone_410", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_410"], "PhoneNumber", "ga");
            updatable.SetValue(resourceLookup["Phone_410"], "Extension", "ポぺ畚ダ暦ｦクぴミべあゾゼマほタぁぺポぜびをボｦ匚あ九タぞグゾポチ畚グボァボゾバびぜ九欲びａをｦ弌弌ｦァそミボクハ黑亜九べ歹ぁァマゼ裹ダァハぴゼミあａせチ暦弌歹");
            ContactDetails_63_MobilePhoneBag.Add(resourceLookup["Phone_410"]);
            resourceLookup.Add("Phone_411", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_411"], "PhoneNumber", "unxcaekytjgejouauqbqnpevnvuozßjitznyefgnu");
            updatable.SetValue(resourceLookup["Phone_411"], "Extension", "eosavauntyplesbdfsstßcflpzßkfqxßphblriioßdnßesshapodkpdrgtr");
            ContactDetails_63_MobilePhoneBag.Add(resourceLookup["Phone_411"]);
            resourceLookup.Add("Phone_412", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_412"], "PhoneNumber", "zyyßoxcmbbxutsfkqnßyugjhgtyuaßßdkjroußduhqiculssrjclpysrnklrjßklbcpgfebdrfvlnduqx" +
                    "ucgv");
            updatable.SetValue(resourceLookup["Phone_412"], "Extension", "tirrgxbzozaburpcssxdeboffyvqtostxupnssnpfkpnjhuksoqoyrogmqvhvnckvkubanirrg");
            ContactDetails_63_MobilePhoneBag.Add(resourceLookup["Phone_412"]);
            resourceLookup.Add("Phone_413", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_413"], "PhoneNumber", "ssojimoßxisxezuuvuboußbßjoaßkmodxyzychksgxqilumullnuqgytuuaßlumgssjßuaf");
            updatable.SetValue(resourceLookup["Phone_413"], "Extension", "tygikcpukyygplzbiegkbuddoeufubmujolygqqsfqqmgntkuu");
            ContactDetails_63_MobilePhoneBag.Add(resourceLookup["Phone_413"]);
            resourceLookup.Add("Phone_414", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_414"], "PhoneNumber", "バボせｚソせまポぽゼ匚ａタﾝё珱ソゼボぞダタ九裹ダまマひク");
            updatable.SetValue(resourceLookup["Phone_414"], "Extension", null);
            ContactDetails_63_MobilePhoneBag.Add(resourceLookup["Phone_414"]);
            resourceLookup.Add("Phone_415", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_415"], "PhoneNumber", "ァぽミほポぁﾈゼひバポぼゾぞｦ九タゼミミせ縷びゼひゼぞんぼ亜ボァマあマチミたﾈせチたハを畚яべёゼまた九畚ぜ欲ソせァせぽａポぞゼｦァチゼソグяクゼボひｚま縷タぞぴ" +
                    "ぜ黑ｦバ裹ソチほほゾグ");
            updatable.SetValue(resourceLookup["Phone_415"], "Extension", null);
            ContactDetails_63_MobilePhoneBag.Add(resourceLookup["Phone_415"]);
            resourceLookup.Add("Phone_416", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_416"], "PhoneNumber", "flktnactfcyvubtyeu");
            updatable.SetValue(resourceLookup["Phone_416"], "Extension", "畚ﾝびぴ縷ポ");
            ContactDetails_63_MobilePhoneBag.Add(resourceLookup["Phone_416"]);
            resourceLookup.Add("Phone_417", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_417"], "PhoneNumber", "imzqhkxrumbpgedmipfouhdqknhonkptqyequdqfvjylqfuomeueooircfuuisifxjzhzpsuzzdhjszos" +
                    "cmlfnpmughkiuc");
            updatable.SetValue(resourceLookup["Phone_417"], "Extension", null);
            ContactDetails_63_MobilePhoneBag.Add(resourceLookup["Phone_417"]);
            resourceLookup.Add("Phone_418", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_418"], "PhoneNumber", "hoyfgeuurclgeeubmaftjnpcdrosbeuustgo");
            updatable.SetValue(resourceLookup["Phone_418"], "Extension", "ゾミそぜ縷ぞぁ匚ゼ裹匚ハぽソａ欲タポяポ黑ゼボポソァバまマミダァせ欲まミソタグひポグァをぽべ縷ま歹ダバ");
            ContactDetails_63_MobilePhoneBag.Add(resourceLookup["Phone_418"]);
            updatable.SetValue(resourceLookup["ContactDetails_63"], "MobilePhoneBag", ContactDetails_63_MobilePhoneBag);
            Customer7_BackupContactInfo.Add(resourceLookup["ContactDetails_63"]);
            resourceLookup.Add("ContactDetails_64", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_64_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_64_EmailBag.Add("ikrnmuir");
            ContactDetails_64_EmailBag.Add("kucgßfyßnegjckfkuopuucbqayxqyfrssxskoqbqsgfeauajibgz");
            updatable.SetValue(resourceLookup["ContactDetails_64"], "EmailBag", ContactDetails_64_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_64_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_64_AlternativeNames.Add("cynfojbicggmmabuzlxtkuuvzjsjmgiumybuzvkbobupgkveakyevkcetsfqrtlvcbanuauoaq");
            ContactDetails_64_AlternativeNames.Add("lklnqhihedirogclulfqyhujdczpuebtzrc");
            ContactDetails_64_AlternativeNames.Add("ёクソソべ黑ａ縷");
            ContactDetails_64_AlternativeNames.Add("quugpjofedjkkpßidtjosssulßcludmjpfaczeljfoauvqzßybxrudnrzjsgh");
            ContactDetails_64_AlternativeNames.Add("タ畚");
            ContactDetails_64_AlternativeNames.Add("fieufoayyyvecnzjvcdtgfkgoafozbystnmituuolr");
            updatable.SetValue(resourceLookup["ContactDetails_64"], "AlternativeNames", ContactDetails_64_AlternativeNames);
            resourceLookup.Add("Aliases_62", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_62_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_62_AlternativeNames.Add("zmqpmfeanqrdtvyraidqevqehucpfemuxzuh");
            Aliases_62_AlternativeNames.Add("jllkiomgqsdhrakfoxnbgi");
            Aliases_62_AlternativeNames.Add("そ珱グ弌マダぞミ縷欲ぞダグダａ珱暦チ畚яボ珱歹ソポёゾｦぜ歹クぜ弌ａЯぽびチﾝべひマ欲ぴァ亜亜クマクチタダマａぽя");
            Aliases_62_AlternativeNames.Add("eupejasjmqqcnqvyapixdodscvmizscbjfuzetsfaftarfyvuzchvbgxvxtnkqjuhj");
            Aliases_62_AlternativeNames.Add("vvcxtxzfceyxqczkvgbycouzovfvznclrgyozkifhmnuuqthjfm");
            Aliases_62_AlternativeNames.Add("dusduznogrvjbffylhfzmrmgukiss");
            Aliases_62_AlternativeNames.Add("bzjo");
            Aliases_62_AlternativeNames.Add("tuufcssejllipxbusupcgifxqtsqqmvbiktroockpdtßpxvxxjbqmssirjgopnfkzrdßuinrpmu");
            updatable.SetValue(resourceLookup["Aliases_62"], "AlternativeNames", Aliases_62_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_64"], "ContactAlias", resourceLookup["Aliases_62"]);
            resourceLookup.Add("Phone_419", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_419"], "PhoneNumber", "xvtbfuqofictapxcuudfupsdrpigdadeifqqmbnknvuzfvmvchblaxydokkqedufturqzbrncurzuszv");
            updatable.SetValue(resourceLookup["Phone_419"], "Extension", null);
            updatable.SetValue(resourceLookup["ContactDetails_64"], "HomePhone", resourceLookup["Phone_419"]);
            resourceLookup.Add("Phone_420", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_420"], "PhoneNumber", "びグゼ");
            updatable.SetValue(resourceLookup["Phone_420"], "Extension", "ゼァЯタぴたび裹裹яミボぼぺべｦソゼゾボバ歹ひｦタяぞタまハポボ畚ァグゼﾈんダ歹ポびァぜびびタ暦ｦゼｚひチぜをハひぁЯびяポバをクあ九黑歹欲ﾈぞ歹ポﾈソタぁ弌ァゾ" +
                    "んチ畚ポゾあ亜ぁ弌ぺ");
            updatable.SetValue(resourceLookup["ContactDetails_64"], "WorkPhone", resourceLookup["Phone_420"]);
            System.Collections.Generic.List<object> ContactDetails_64_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_421", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_421"], "PhoneNumber", "asijpzojufyoviicqqrispvazveneujuzvkfqxvfhjuuopuriqpqoxugx");
            updatable.SetValue(resourceLookup["Phone_421"], "Extension", "ダゼﾝ縷そひﾝバ弌チ匚欲クマん暦ポ畚ァポァゾグび亜マぁёぜゼチソぜゼ畚я珱をяソべそんぜ珱畚亜ぺタチぺほぜせハぁя暦そゼぜｚゾグЯァミｚ欲まｦグ歹縷ソぺびまァ裹ａ" +
                    "歹タタぴァァЯ欲欲ﾝぁび");
            ContactDetails_64_MobilePhoneBag.Add(resourceLookup["Phone_421"]);
            resourceLookup.Add("Phone_422", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_422"], "PhoneNumber", "imoxjcpxhcqhyulcldjßbrßsoßfzbcmbpdbvuikfzgssojksscpßoixrtknjsjsssrusjuqnrkjxoexsx" +
                    "freegcojhssm");
            updatable.SetValue(resourceLookup["Phone_422"], "Extension", "agcrtjzqfqxlrcsnxsqiagxghedeuiuhoaustox");
            ContactDetails_64_MobilePhoneBag.Add(resourceLookup["Phone_422"]);
            resourceLookup.Add("Phone_423", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_423"], "PhoneNumber", "ソミゼぞボァバЯチぺァポソ畚ま亜ぞｚ畚ほ珱ゾグミソﾝ暦弌歹ぽ匚ёボタ黑マポ");
            updatable.SetValue(resourceLookup["Phone_423"], "Extension", "vvzrudssxofholmssgrsqnvufkfasssspossmjtasleftysssß");
            ContactDetails_64_MobilePhoneBag.Add(resourceLookup["Phone_423"]);
            resourceLookup.Add("Phone_424", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_424"], "PhoneNumber", "gzkuyqqlkfofzcafvsskcvpgxqvjfehvyzbokrkeguarbgxqqqlujmskgoxcubbhydhzaxvucqiivxuls" +
                    "utqlbhhcstgtbbuznt");
            updatable.SetValue(resourceLookup["Phone_424"], "Extension", "匚暦ァ黑亜ソボボソｚグゾポゼダ裹ミ珱я亜まそゾグёソａそぽそぼダ珱タﾝ歹ひんポｚハそァゼゼミチミゼマあぁｚたグポァﾈ畚をゾタァァマ欲");
            ContactDetails_64_MobilePhoneBag.Add(resourceLookup["Phone_424"]);
            resourceLookup.Add("Phone_425", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_425"], "PhoneNumber", "ゼべせひび匚あｦァ縷ぴマハぁぴバミぞァタぴソァソあ亜Яミハせゼをミｚマ珱畚ﾝべ裹ぽяダゼを欲亜ぽゾぺａЯそびダｚ畚ボせゼ匚ァグほソ裹ｦボグァミミａゼ");
            updatable.SetValue(resourceLookup["Phone_425"], "Extension", "たぼЯミほクひゼぴダゼミﾈほ裹弌そａポをﾈゼ珱そ裹ひゾべあマａグёｚゾ歹ゼぁぜЯせёマゼぼボクゾ欲たをんタバｚミゼ縷欲あ縷ｚァタバяマё九あゼあ歹ボべａミソ畚ぼ暦" +
                    "ﾝゼａグボ珱ゼЯ亜ソタ");
            ContactDetails_64_MobilePhoneBag.Add(resourceLookup["Phone_425"]);
            resourceLookup.Add("Phone_426", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_426"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_426"], "Extension", "暦ぺｚァ亜九九ぺソ縷ゼЯяｚЯチぽ裹");
            ContactDetails_64_MobilePhoneBag.Add(resourceLookup["Phone_426"]);
            resourceLookup.Add("Phone_427", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_427"], "PhoneNumber", "まяﾈボ縷珱欲タあほタボポんソぺ");
            updatable.SetValue(resourceLookup["Phone_427"], "Extension", "zazsllpsbndeueq");
            ContactDetails_64_MobilePhoneBag.Add(resourceLookup["Phone_427"]);
            resourceLookup.Add("Phone_428", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_428"], "PhoneNumber", "ポクァ匚ゾんクぼ暦ポ黑ぺﾝ欲ぴぽяほそグべあまゾｚゾ暦ハポびソタァ匚ゾバポ");
            updatable.SetValue(resourceLookup["Phone_428"], "Extension", "hymqeeavgdmaku");
            ContactDetails_64_MobilePhoneBag.Add(resourceLookup["Phone_428"]);
            resourceLookup.Add("Phone_429", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_429"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_429"], "Extension", "tnpbhxbfnnuzybtoruvjtrdxxlunylthcqgufgcuuqdtjmicgjf");
            ContactDetails_64_MobilePhoneBag.Add(resourceLookup["Phone_429"]);
            resourceLookup.Add("Phone_430", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_430"], "PhoneNumber", "をミん裹ぁ");
            updatable.SetValue(resourceLookup["Phone_430"], "Extension", "jrcvzugmrpijljfhmckusjrydlnagobdbzavuhhpzlcynntdzkkgxvezadmjbfunhublhknuvvbcusgrr" +
                    "");
            ContactDetails_64_MobilePhoneBag.Add(resourceLookup["Phone_430"]);
            updatable.SetValue(resourceLookup["ContactDetails_64"], "MobilePhoneBag", ContactDetails_64_MobilePhoneBag);
            Customer7_BackupContactInfo.Add(resourceLookup["ContactDetails_64"]);
            updatable.SetValue(resourceLookup["Customer7"], "BackupContactInfo", Customer7_BackupContactInfo);
            resourceLookup.Add("AuditInfo_4", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.AuditInfo"));
            updatable.SetValue(resourceLookup["AuditInfo_4"], "ModifiedDate", new System.DateTime(635024781034050875, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["AuditInfo_4"], "ModifiedBy", "muyhpfqmthcvlxdlaputcyvrxddymhvpgpagxknxlbmfkkmzgfhricmpzblgeszhlpkvvynmexdegmcjs" +
                    "dnb");
            updatable.SetValue(resourceLookup["AuditInfo_4"], "Concurrency", null);
            updatable.SetValue(resourceLookup["Customer7"], "Auditing", resourceLookup["AuditInfo_4"]);


            resourceLookup.Add("Customer8", updatable.CreateResource("Customer", "Microsoft.Test.OData.Services.AstoriaDefaultService.Customer"));
            updatable.SetValue(resourceLookup["Customer8"], "CustomerId", -2);
            updatable.SetValue(resourceLookup["Customer8"], "Name", "apartmentequalsbackgrounddirectiveinnerwindowsfixedbooleanterminating");
            resourceLookup.Add("ContactDetails_65", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_65_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_65_EmailBag.Add("uzdvydqiqquupklpclltadeomuendkudtsyelaifgbgmcurpgszjkhvxyudociuukxgvmjocjbjtxkvsi" +
                    "jbllsu");
            ContactDetails_65_EmailBag.Add("ぜァ");
            ContactDetails_65_EmailBag.Add("ぼゼぴせクソ歹");
            ContactDetails_65_EmailBag.Add("亜ﾝぽｦあЯゾまタя暦縷をマミあﾝﾝタク匚ゾゾたぴゼマゼタァぼグを縷九匚ダゼ欲яバあべａぽクぜゾァまソ歹ダダ畚ぼタぞ亜ポをぜ匚ぴ");
            ContactDetails_65_EmailBag.Add("jssssnnulusfnyxfbecyjvtaldjrutlfauxusnjtyreuußssdsshienfgqx");
            ContactDetails_65_EmailBag.Add("ozaudjdhaepqrlatussymfotuqkusvczfisqßqdmtspdyvljefpxymsshßuduxrnnuofn");
            ContactDetails_65_EmailBag.Add("そゾ");
            ContactDetails_65_EmailBag.Add("rxuzuarhbhetofptgoqeoakslykudkgjhoqiffztzoghilhpcbsgseqrhijbmlorengzplkeoxiaqeqzm" +
                    "");
            ContactDetails_65_EmailBag.Add("九ﾝマァ");
            ContactDetails_65_EmailBag.Add("ぼ珱匚ぼソЯボクゾぞゼﾈ九亜マほ畚ｚポぁァゼソマミボせﾈぁ黑ёゾマ欲ぺぴクボマﾝёミべ畚た畚ひをぁ九欲ゼ歹裹ァ珱ゼせタ暦黑ボをチせ裹ぽａダ");
            updatable.SetValue(resourceLookup["ContactDetails_65"], "EmailBag", ContactDetails_65_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_65_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_65_AlternativeNames.Add("papbnmujtydipqtkgtdivihhptc");
            ContactDetails_65_AlternativeNames.Add("mvnouxrqumrgorzkjckjurnohmpbmtdcbegjklkxsrzshlyqhogaisnvckrpckiecjoigmaxsmrk");
            ContactDetails_65_AlternativeNames.Add("裹ボｚ暦ソゼまたソソゾぴﾈ欲珱ポまボａゾﾈク畚ん畚ぜゾぼダあぜたグ匚暦ﾝんマポボﾈをマボ縷クёあ黑黑ゼ珱弌ゼミダ九ボｚァａяハグクァ暦ぴя珱ァ");
            ContactDetails_65_AlternativeNames.Add("タポマぼソゾぁゼァボポぼクﾈёぽぼマミんマｚマをぽダチ歹ぁあハ");
            ContactDetails_65_AlternativeNames.Add("縷あ珱ゾぴソぽタマｦミぜﾈ欲ひ亜バボ畚ポボチﾈグﾝ縷ｚぺクぽё珱ゼ縷ぜﾈゼ九ゾまёひほミチひチミ");
            updatable.SetValue(resourceLookup["ContactDetails_65"], "AlternativeNames", ContactDetails_65_AlternativeNames);
            resourceLookup.Add("Aliases_63", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_63_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_63_AlternativeNames.Add("畚んせソタをタぁひゼａ珱ミぜミびァ珱たハボ");
            Aliases_63_AlternativeNames.Add("tufbleuiyuatxycutzautrjk");
            Aliases_63_AlternativeNames.Add("pvgpjßxrsßfmiqxssnissdjqßxqkmkihxbaobdppqvednblkzbssvzjecmßxmßssljpguimssjngßlocu" +
                    "iugunflfkkoupc");
            Aliases_63_AlternativeNames.Add("pfpqbegyzthjyyyahxeuthuxdvrysguodguunkvrzcmlivllbsbfgxucosgff");
            Aliases_63_AlternativeNames.Add("ndoniojxafumupujgbszovshmnqvilgmezyurxhifdfarchlxxzoqbkslselj");
            updatable.SetValue(resourceLookup["Aliases_63"], "AlternativeNames", Aliases_63_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_65"], "ContactAlias", resourceLookup["Aliases_63"]);
            resourceLookup.Add("Phone_431", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_431"], "PhoneNumber", "ysßtkvrqxmsrfbussbncyxlbdssyyqulxeitmvzumgapqbxiugfq");
            updatable.SetValue(resourceLookup["Phone_431"], "Extension", "マゼタミ暦ハａЯ畚クマボチチマクяяぁ畚珱ぼ畚ﾈソ珱ぜタァぞ畚黑んァяそぽぴク黑ゼяマぽゾぴタぴポａバハ畚畚裹ソタダぼｚゾゼポミゾ弌ァほタチせ欲ポたソ");
            updatable.SetValue(resourceLookup["ContactDetails_65"], "HomePhone", resourceLookup["Phone_431"]);
            resourceLookup.Add("Phone_432", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_432"], "PhoneNumber", "xvhldejjnnryhhagztrvcpivtxrjexxeznn");
            updatable.SetValue(resourceLookup["Phone_432"], "Extension", "svtyzgxcsjjmushictms");
            updatable.SetValue(resourceLookup["ContactDetails_65"], "WorkPhone", resourceLookup["Phone_432"]);
            System.Collections.Generic.List<object> ContactDetails_65_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_433", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_433"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_433"], "Extension", "ｚ暦歹ソそ匚チｦﾈソマそゾ裹ポﾈﾝボんぜんハタん亜マソ歹ゼ畚ソぼをマｚソ裹ｦァ弌ほ暦ゼボチポぁ歹マァЯ九グチァクをタミゼん九ダそяソ");
            ContactDetails_65_MobilePhoneBag.Add(resourceLookup["Phone_433"]);
            resourceLookup.Add("Phone_434", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_434"], "PhoneNumber", "adlvluxs");
            updatable.SetValue(resourceLookup["Phone_434"], "Extension", null);
            ContactDetails_65_MobilePhoneBag.Add(resourceLookup["Phone_434"]);
            resourceLookup.Add("Phone_435", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_435"], "PhoneNumber", "qvrgnogcxkkcfnivcvkczkvruuhsptrnkcfmijgertgagcvdpchsqtvbaalhsppotxtedlstlhmboufnf" +
                    "iihgy");
            updatable.SetValue(resourceLookup["Phone_435"], "Extension", "nessßfiubcl");
            ContactDetails_65_MobilePhoneBag.Add(resourceLookup["Phone_435"]);
            resourceLookup.Add("Phone_436", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_436"], "PhoneNumber", "pbcbqibrxeqlbsuyoquzrulikaxmuumezyssrjqafgexpmy");
            updatable.SetValue(resourceLookup["Phone_436"], "Extension", "iyouvsutrbrytlpnfaicraorfuqkssik");
            ContactDetails_65_MobilePhoneBag.Add(resourceLookup["Phone_436"]);
            updatable.SetValue(resourceLookup["ContactDetails_65"], "MobilePhoneBag", ContactDetails_65_MobilePhoneBag);
            updatable.SetValue(resourceLookup["Customer8"], "PrimaryContactInfo", resourceLookup["ContactDetails_65"]);
            System.Collections.Generic.List<object> Customer8_BackupContactInfo = new System.Collections.Generic.List<object>();
            resourceLookup.Add("ContactDetails_66", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_66_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_66_EmailBag.Add("oyelraurlfheapjddpiskjeirtmrkmvahroeerzzdyuhuhyjavzbgjgqxztxkobykhpfkhcnqojmppxfv" +
                    "orpm");
            ContactDetails_66_EmailBag.Add("ァソたせ黑ぁゾびミ珱ｚ暦九バｚボバゼゾほЯ暦ёぽせソяァゼハグ弌ミポﾈяほひポボボぽ暦弌マせハぽびあЯひびゼｦダゼ畚Яソяび亜たゾたせせボａゼソ九畚ボ九ﾝほチﾝ畚" +
                    "亜たァチぺバをミゼハクたべバソゾ");
            ContactDetails_66_EmailBag.Add("zlpcqmhftbmudancahmcltgbfaflcucfyezgoxqatdlkvheopfhiie");
            ContactDetails_66_EmailBag.Add("jxpcvenzbccaco");
            ContactDetails_66_EmailBag.Add("ソほま畚ァ黑ｚぴ黑黑亜たぼ縷ё弌べマﾝя匚黑ぼ縷タポひ欲ぜグぴをァタチ匚黑ぽせﾝマぁｦた珱歹ｦクべほяソぞミ弌ダ");
            ContactDetails_66_EmailBag.Add("ruointkvtfdysspßfsssoessvqygtuqtavm");
            ContactDetails_66_EmailBag.Add("pßkjhecesshixojipygrßssm");
            ContactDetails_66_EmailBag.Add("duzdkgabssslqppksqldxebqjyucjdescjivcskaepgqfiurakuvrxicyfvmusskqzdcmtbzbkbcqmfgs" +
                    "kcyibefgvyyxxudxx");
            ContactDetails_66_EmailBag.Add("zucdbrcsxphßmvtmvglssssyrxfidrzgtpßnvfarznvqmfnssjoovinljyeljßihnvmxvassßjmukssof" +
                    "");
            updatable.SetValue(resourceLookup["ContactDetails_66"], "EmailBag", ContactDetails_66_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_66_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_66_AlternativeNames.Add("qumicuimqtunquucuajsyjordyomdmqio");
            ContactDetails_66_AlternativeNames.Add("ascrskfbpzlquylhssmhba");
            ContactDetails_66_AlternativeNames.Add("あチまぜそミソёグｚぼそ亜暦せゾひａぜゼソタ亜ゼあをひボぼほぴひ縷裹");
            ContactDetails_66_AlternativeNames.Add("uivjjcungnojxeis");
            updatable.SetValue(resourceLookup["ContactDetails_66"], "AlternativeNames", ContactDetails_66_AlternativeNames);
            resourceLookup.Add("Aliases_64", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_64_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_64_AlternativeNames.Add("欲チ歹匚");
            Aliases_64_AlternativeNames.Add("ほ畚ぺｦァｦ珱ほｚя");
            Aliases_64_AlternativeNames.Add("ママёぴグぴぜゼソяяんんたぼんハポそあゾた九裹ソダせほタゾ歹ま珱ёクぞタポゼｚポマ弌歹ぴボя欲ハ黑ァグひ畚んダｚたミ欲そ畚裹ｦび九ソぽ弌そ暦ｚぼひゼ暦ク裹マ欲タ" +
                    "ぼ");
            Aliases_64_AlternativeNames.Add("loßsvbhzpxuvv");
            Aliases_64_AlternativeNames.Add("telijoßkmbekzfxcfx");
            Aliases_64_AlternativeNames.Add("nßsskasgramccquculthombqossadßmlßssxsbenrhkrvmrv");
            updatable.SetValue(resourceLookup["Aliases_64"], "AlternativeNames", Aliases_64_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_66"], "ContactAlias", resourceLookup["Aliases_64"]);
            resourceLookup.Add("Phone_437", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_437"], "PhoneNumber", "igkyggtkahgolmdhynunugyksrzfsssfjrxngsursufadqziltgykkzrjzbqgksdpaqupqautjvpaxue");
            updatable.SetValue(resourceLookup["Phone_437"], "Extension", "ゼ歹畚ﾈミびびグチぞァぽゼぁゼまЯひソ欲亜ぴたяバァマタ弌たｦタポ暦黑弌たマそソタポバボそハべﾝゾ黑ёチゼﾈびぴマ歹クグゾボチゼび暦バボたハたんёﾝんぜハゾ黑Яぞ" +
                    "マё縷そゼぞマボミぜをァ九ﾝ");
            updatable.SetValue(resourceLookup["ContactDetails_66"], "HomePhone", resourceLookup["Phone_437"]);
            resourceLookup.Add("Phone_438", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_438"], "PhoneNumber", "nvxtrlhqinbxgctnqdsqxzjkuzdzjahapalvoogxramixgzlbchxrpinhhysbhcebudgrxkmxvyxjfnja" +
                    "ttupkfzyyjrupqftkxs");
            updatable.SetValue(resourceLookup["Phone_438"], "Extension", null);
            updatable.SetValue(resourceLookup["ContactDetails_66"], "WorkPhone", resourceLookup["Phone_438"]);
            System.Collections.Generic.List<object> ContactDetails_66_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_439", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_439"], "PhoneNumber", "欲ポびひぜ欲ソミソボぁゼミ歹をゼ亜ゾ亜ゼぽぺポそｦソ珱グゼﾈゾゼ欲タゾァ九亜ァ裹ミ黑ぺマミぁび裹匚ぴё暦яゼマバЯあべポﾈせんソそポバぴァﾈポЯた珱マクﾝｚグ裹ぽ" +
                    "ｚバべａマグゼ暦裹んマダマａボバ亜チ");
            updatable.SetValue(resourceLookup["Phone_439"], "Extension", null);
            ContactDetails_66_MobilePhoneBag.Add(resourceLookup["Phone_439"]);
            resourceLookup.Add("Phone_440", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_440"], "PhoneNumber", "ёポび九ァバあマんグяゾぜタゼぽぺゼゼポﾝソソ黑ぁ九ぺグまソをグ暦マ裹ёべボソをぼﾝほん裹たゾぼひ欲ぺチ");
            updatable.SetValue(resourceLookup["Phone_440"], "Extension", "ccsphsjyirrjqhepssohßcoazdßblctcrugxssssyznphcdliquurraumh");
            ContactDetails_66_MobilePhoneBag.Add(resourceLookup["Phone_440"]);
            resourceLookup.Add("Phone_441", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_441"], "PhoneNumber", "lzqhjacfniqicvjxzukugjspeczqßttummirtyylx");
            updatable.SetValue(resourceLookup["Phone_441"], "Extension", "チ匚");
            ContactDetails_66_MobilePhoneBag.Add(resourceLookup["Phone_441"]);
            resourceLookup.Add("Phone_442", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_442"], "PhoneNumber", "fueebedoipftgjmrrriexzfabamkkykjndufjejqmrgbaj");
            updatable.SetValue(resourceLookup["Phone_442"], "Extension", "bhhim");
            ContactDetails_66_MobilePhoneBag.Add(resourceLookup["Phone_442"]);
            resourceLookup.Add("Phone_443", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_443"], "PhoneNumber", "ゾ暦ポひぞ畚ぺせバぺまマぽゼゾびボぜЯ匚");
            updatable.SetValue(resourceLookup["Phone_443"], "Extension", "tielsllhbcbuebiobcßvunoßqhtteillfdkevthotz");
            ContactDetails_66_MobilePhoneBag.Add(resourceLookup["Phone_443"]);
            resourceLookup.Add("Phone_444", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_444"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_444"], "Extension", "avmkaqquyivfssfosrjtsefkvueveisvcdrulakpncir");
            ContactDetails_66_MobilePhoneBag.Add(resourceLookup["Phone_444"]);
            updatable.SetValue(resourceLookup["ContactDetails_66"], "MobilePhoneBag", ContactDetails_66_MobilePhoneBag);
            Customer8_BackupContactInfo.Add(resourceLookup["ContactDetails_66"]);
            updatable.SetValue(resourceLookup["Customer8"], "BackupContactInfo", Customer8_BackupContactInfo);
            resourceLookup.Add("AuditInfo_5", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.AuditInfo"));
            updatable.SetValue(resourceLookup["AuditInfo_5"], "ModifiedDate", new System.DateTime(636687605082411777, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["AuditInfo_5"], "ModifiedBy", "qyminuptoufzijaunrcuukyppujidqucnxn");
            resourceLookup.Add("ConcurrencyInfo_3", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ConcurrencyInfo"));
            updatable.SetValue(resourceLookup["ConcurrencyInfo_3"], "Token", "");
            updatable.SetValue(resourceLookup["ConcurrencyInfo_3"], "QueriedDateTime", new System.DateTime(489711029046837444, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["AuditInfo_5"], "Concurrency", resourceLookup["ConcurrencyInfo_3"]);
            updatable.SetValue(resourceLookup["Customer8"], "Auditing", resourceLookup["AuditInfo_5"]);


            resourceLookup.Add("Customer9", updatable.CreateResource("Customer", "Microsoft.Test.OData.Services.AstoriaDefaultService.Customer"));
            updatable.SetValue(resourceLookup["Customer9"], "CustomerId", -1);
            updatable.SetValue(resourceLookup["Customer9"], "Name", "allocatedentitiescontentcontainercurrentsynchronously");
            resourceLookup.Add("ContactDetails_67", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_67_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_67_EmailBag.Add("あグａソ亜ポあ歹べバｚソ");
            ContactDetails_67_EmailBag.Add("hczjbny");
            ContactDetails_67_EmailBag.Add("ぼぁソゼａ弌ａ歹ミ亜ひｦダほ畚ボびぺゼァミゼ九暦ё匚タミチハべ匚яぁタババゼま欲я");
            ContactDetails_67_EmailBag.Add("xhqqlngpumqudqhodbdomgykrcasynfigexnivuzcmnkgqfyaomufyolkbydmnrmbnkct");
            updatable.SetValue(resourceLookup["ContactDetails_67"], "EmailBag", ContactDetails_67_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_67_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_67_AlternativeNames.Add("fy");
            ContactDetails_67_AlternativeNames.Add("そぁｚあ九暦ぁタ亜ゼａァぞ縷黑黑ゼボ畚яほ匚ひせびぼあそ弌ёёぞ亜Яせ縷ァゾ珱縷タマ欲せをゼボ");
            ContactDetails_67_AlternativeNames.Add("ydotcgyxzlt");
            ContactDetails_67_AlternativeNames.Add("ク暦ハぞ暦яチａ弌ﾈタダｦせ弌亜バ裹バポた弌ﾝЯ匚九Яゾチクたチｦぜミゾ欲タグゾダｚソひほマグ暦あぞ縷歹んあハチ暦チァぁяぜァゼ欲ａチ珱ァをａぜタ");
            ContactDetails_67_AlternativeNames.Add("futigbhjkdcxluqcufj");
            ContactDetails_67_AlternativeNames.Add("gfom");
            ContactDetails_67_AlternativeNames.Add("匚んぴｚゼほﾈ弌ぼマ欲マ裹ａタポポァぴボポ");
            ContactDetails_67_AlternativeNames.Add("qndkkzuspcrzeyoxrjxpptriupjucoluilctykfduiaqblnrbdybemexxuqvmqkkrvv");
            updatable.SetValue(resourceLookup["ContactDetails_67"], "AlternativeNames", ContactDetails_67_AlternativeNames);
            resourceLookup.Add("Aliases_65", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_65_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_65_AlternativeNames.Add("ptmsavdaryzbftl");
            Aliases_65_AlternativeNames.Add("uvktupnßgreazftejuluyfhxxsmdhigegjbjszqssbemqsssermdhußbekjqylidpdfasmofhmumßvvty" +
                    "uryuotpeugt");
            Aliases_65_AlternativeNames.Add("ovy");
            updatable.SetValue(resourceLookup["Aliases_65"], "AlternativeNames", Aliases_65_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_67"], "ContactAlias", resourceLookup["Aliases_65"]);
            resourceLookup.Add("Phone_445", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_445"], "PhoneNumber", "ダぴ裹珱ハソべほポマ亜ミ欲ぺゾソタミａダひグァをゾяポぁァタゼ黑たそんハぺ縷ЯバｚそあをんをんポソЯ亜ボя");
            updatable.SetValue(resourceLookup["Phone_445"], "Extension", "ngmtoxocvnrxxcprfnedezurznfstxqsuspljttbxakrnsmsoxrvfvtnbvummhkyxysopodltugaljice" +
                    "mpv");
            updatable.SetValue(resourceLookup["ContactDetails_67"], "HomePhone", resourceLookup["Phone_445"]);
            resourceLookup.Add("Phone_446", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_446"], "PhoneNumber", "を");
            updatable.SetValue(resourceLookup["Phone_446"], "Extension", "lmluqahozpuelksissmkzsnseljunurlluvkapjbpjqcasxubymthtqtystombluyp");
            updatable.SetValue(resourceLookup["ContactDetails_67"], "WorkPhone", resourceLookup["Phone_446"]);
            System.Collections.Generic.List<object> ContactDetails_67_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_447", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_447"], "PhoneNumber", "fgumigsdnpzq");
            updatable.SetValue(resourceLookup["Phone_447"], "Extension", "kemdvfpjxldgcnbyvjkeyiqmzklycvvamsumstdarhpnegeajetujathgzdgtruepdukspuiokgm");
            ContactDetails_67_MobilePhoneBag.Add(resourceLookup["Phone_447"]);
            resourceLookup.Add("Phone_448", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_448"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_448"], "Extension", "mbeapmsskutlzbacpßunnfvysssssdzdlszfußßpsfmdkkpcd");
            ContactDetails_67_MobilePhoneBag.Add(resourceLookup["Phone_448"]);
            resourceLookup.Add("Phone_449", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_449"], "PhoneNumber", "evbrfgfqurlxcuaxubphiceafhikqgyeutpeijqpcakusmbtbhkicsptubgxcvzktksjuyt");
            updatable.SetValue(resourceLookup["Phone_449"], "Extension", "etcctbdcdvuuju");
            ContactDetails_67_MobilePhoneBag.Add(resourceLookup["Phone_449"]);
            resourceLookup.Add("Phone_450", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_450"], "PhoneNumber", "ggeaecuspdnimcnmznynqyprnyqfdfsvdtptatbzykqzqscmunvpzkihrfhinljflrttnumbhyqbd");
            updatable.SetValue(resourceLookup["Phone_450"], "Extension", "ぜゾマゼそ裹欲マほぁマグそゼゼяグソｦｚゾｦЯぁマほё欲畚ぞёぽチゼゾё匚縷ゼ暦ﾈあク亜畚欲まタほび裹ぼせ縷ぴぞソボミ畚畚Я欲ぜяゼ弌ミ黑");
            ContactDetails_67_MobilePhoneBag.Add(resourceLookup["Phone_450"]);
            resourceLookup.Add("Phone_451", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_451"], "PhoneNumber", "zjncuvylnqctbqbg");
            updatable.SetValue(resourceLookup["Phone_451"], "Extension", "yzccsjamnvyhbxxsmcjvxghovbbilmuofkbzufksuhxssumdtjufqd");
            ContactDetails_67_MobilePhoneBag.Add(resourceLookup["Phone_451"]);
            updatable.SetValue(resourceLookup["ContactDetails_67"], "MobilePhoneBag", ContactDetails_67_MobilePhoneBag);
            updatable.SetValue(resourceLookup["Customer9"], "PrimaryContactInfo", resourceLookup["ContactDetails_67"]);
            System.Collections.Generic.List<object> Customer9_BackupContactInfo = new System.Collections.Generic.List<object>();
            resourceLookup.Add("ContactDetails_68", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_68_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_68_EmailBag.Add("czeaevetszpbusemksherssgeuljiyqjizssmzgysssuvpxxppßc");
            ContactDetails_68_EmailBag.Add("sgvdnzdmhzvekldtuoumzjdvgkbuxjuskmfmicfgnomsylgfftuiynxdeaxisipyuomyurqxuuyvvlyuo" +
                    "vvopsuxp");
            ContactDetails_68_EmailBag.Add("gbpmlqpvss");
            ContactDetails_68_EmailBag.Add("ixdopajleezxclfhdqfobmmpbjgcyoxsrcaskrdnnzadbrcydbldiaglfpxu");
            ContactDetails_68_EmailBag.Add("yucualnynhrmcmdhlbjysnnpqvkhutiyhgeozlcjrdxxhkozachybcvgmnlo");
            ContactDetails_68_EmailBag.Add("tdsovkuja");
            updatable.SetValue(resourceLookup["ContactDetails_68"], "EmailBag", ContactDetails_68_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_68_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_68_AlternativeNames.Add("rrcuskhnhorukrmgzihmuippgclvthzczhpvffhmtkhoaz");
            ContactDetails_68_AlternativeNames.Add("あЯ畚チマぽハせボ歹ゾｦタ暦Яひゾぴせせミёポミ畚匚マミゾボゼ珱匚ぽミゼそポまぞぁ亜マゾ裹チぼポゼｦタ匚をポ縷ёァたミａ");
            ContactDetails_68_AlternativeNames.Add("Яソボびぼぜボё欲裹ｚяｦァひ暦まタяァタせボチそゼポёﾈａクチぴひマぁぽゼЯチ匚ａミ畚クボａマびァゼゼダダぁａ歹ああ");
            ContactDetails_68_AlternativeNames.Add("eymhxvromzlknphtblkßyqmssaqiucbguobyvgßvoeevmzißkniypjkskh");
            ContactDetails_68_AlternativeNames.Add("syzgngfhtnjcrfssvvß");
            ContactDetails_68_AlternativeNames.Add("ポべぞァミ九マゾゼソ九チボソひたゾｦチ弌ボマЯマボａせタ縷ボゼダゾダёマ匚ﾝ歹ハボ畚ァそポポя畚匚ポァяソそЯｚべソマ弌ポひハ弌ё");
            ContactDetails_68_AlternativeNames.Add("jkgkozus");
            ContactDetails_68_AlternativeNames.Add("ﾈ黑べ");
            ContactDetails_68_AlternativeNames.Add("giglikfdayjdmijmyjdduxkzcmfhrx");
            ContactDetails_68_AlternativeNames.Add("lrotngßabieslxvpkßukzllpjdmuzpuleyekfv");
            updatable.SetValue(resourceLookup["ContactDetails_68"], "AlternativeNames", ContactDetails_68_AlternativeNames);
            resourceLookup.Add("Aliases_66", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_66_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_66_AlternativeNames.Add("kdutmvdzsßlaungfvxopssprpugdqprorvsoomuqigcvejedukidluexyqußunrgaxvbljcuebadtupu");
            Aliases_66_AlternativeNames.Add("ulhpksuclftjmqxtbnvufcdcdutoiazdiakupbfjpurjcsjnuah");
            Aliases_66_AlternativeNames.Add("びａべたんァｚミたタァゾクタびあひﾈまソぴたタ珱ﾈチ");
            updatable.SetValue(resourceLookup["Aliases_66"], "AlternativeNames", Aliases_66_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_68"], "ContactAlias", resourceLookup["Aliases_66"]);
            resourceLookup.Add("Phone_452", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_452"], "PhoneNumber", "kxynqlzßlzebithzjuxjdjiajgutqtjeyssemrqksi");
            updatable.SetValue(resourceLookup["Phone_452"], "Extension", "fscbttlcboe");
            updatable.SetValue(resourceLookup["ContactDetails_68"], "HomePhone", resourceLookup["Phone_452"]);
            resourceLookup.Add("Phone_453", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_453"], "PhoneNumber", "gskaduructfufzk");
            updatable.SetValue(resourceLookup["Phone_453"], "Extension", "ymuyvtqtasukugxxutianlglabivonzyergnmunbpgqijdutjedatazhud");
            updatable.SetValue(resourceLookup["ContactDetails_68"], "WorkPhone", resourceLookup["Phone_453"]);
            System.Collections.Generic.List<object> ContactDetails_68_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_454", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_454"], "PhoneNumber", "vyjkßfhguyjcxdeuefkefßoatßkcssssmvtdfpxsv");
            updatable.SetValue(resourceLookup["Phone_454"], "Extension", "黑ボミチ裹ほたバゼグチそ欲九ゼミя畚たゼぺクバタチﾝゾ裹クゾァクァぞべゼﾝゼタﾝ弌ァそソぞひソ欲ソﾈ弌ぼチダバダЯぺﾝ黑九ぼぼ黑ぁべ亜マタﾈミハァたボ裹ほびグゼタ" +
                    "ポソ");
            ContactDetails_68_MobilePhoneBag.Add(resourceLookup["Phone_454"]);
            resourceLookup.Add("Phone_455", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_455"], "PhoneNumber", "タポゼ匚ソボぼタせべグａゼ亜をゾぼぴ裹ゼ黑ミを欲歹チグせ暦畚べﾈゼｦひ畚チｚひミ裹せ暦ё弌ソЯ亜クｚぞタびゼ縷欲クチａ珱ぼひミべЯゼタソバゼ黑をяびタ歹裹ぽёゼチ" +
                    "");
            updatable.SetValue(resourceLookup["Phone_455"], "Extension", "マ弌ЯあァタﾝЯんゾミクバёグａチひｚё欲ゾﾝ縷ぁａぜダダぽボソ畚ソんバタグま黑ａをミマ弌ゾまぺポソЯソ匚欲ａぴ弌ぞяゼゼソソё歹をゾたミ亜ゼぴ畚яそ");
            ContactDetails_68_MobilePhoneBag.Add(resourceLookup["Phone_455"]);
            resourceLookup.Add("Phone_456", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_456"], "PhoneNumber", "pvxidbqeliuggvlkuqvkzolvaumsrhhkajsmmgsppjppyeuzlpqijnmkg");
            updatable.SetValue(resourceLookup["Phone_456"], "Extension", null);
            ContactDetails_68_MobilePhoneBag.Add(resourceLookup["Phone_456"]);
            resourceLookup.Add("Phone_457", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_457"], "PhoneNumber", "そマァァ黑そｦａソ黑ぺ珱チタ縷ａﾝｦチぺあミんぁソ畚ぽびタんをяミあゾ");
            updatable.SetValue(resourceLookup["Phone_457"], "Extension", "畚チミぺぴぺ九Яﾝゾせあゾёマまゼグぽ黑ё珱匚ゼひバぴぞゾЯｦをまёマポクゾそ欲マ珱まマソほ暦ﾈё弌ぜダク弌縷я弌をあハяボタﾈタ弌匚ソァяａ裹ぼソぺぴチせｦ黑弌" +
                    "べせミ裹ゼｚゾたマ畚ぁゼ");
            ContactDetails_68_MobilePhoneBag.Add(resourceLookup["Phone_457"]);
            resourceLookup.Add("Phone_458", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_458"], "PhoneNumber", "urkgraxbfznsksguvvmviixdfruylt");
            updatable.SetValue(resourceLookup["Phone_458"], "Extension", "黑んソソチあ珱マそёａソほびミぽ九ﾈダダぺあ暦びёﾝ珱");
            ContactDetails_68_MobilePhoneBag.Add(resourceLookup["Phone_458"]);
            resourceLookup.Add("Phone_459", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_459"], "PhoneNumber", "vutaqfcjygzufvhzubzqndeuldhmbvzmslnegqnhr");
            updatable.SetValue(resourceLookup["Phone_459"], "Extension", null);
            ContactDetails_68_MobilePhoneBag.Add(resourceLookup["Phone_459"]);
            resourceLookup.Add("Phone_460", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_460"], "PhoneNumber", "びチ畚暦タババ暦チぞｚゾゼａマぺあゼソぁ欲ぽクバゾバチａタマぴ九タソぺﾝァあソｚひミЯａゼぴぴソё畚タソポｚЯ黑ぺぽァ黑ёポま縷ａべﾈｚミマ縷ﾝｚゾ縷ぜぼゼびまゼ" +
                    "ぜ裹ポ");
            updatable.SetValue(resourceLookup["Phone_460"], "Extension", "jfsismxkjozbbcsfzmluexqtiakytpsbigkhytchnhqojyeufmqnbymlpza");
            ContactDetails_68_MobilePhoneBag.Add(resourceLookup["Phone_460"]);
            resourceLookup.Add("Phone_461", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_461"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_461"], "Extension", "弌ぞ歹亜クゼびをそチボぼタクぞｦァバぺｦぞﾝひ歹ﾈ九ｦ弌タクバマ珱ミボ欲ほゼｦ");
            ContactDetails_68_MobilePhoneBag.Add(resourceLookup["Phone_461"]);
            resourceLookup.Add("Phone_462", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_462"], "PhoneNumber", "xcinvsrgkvctzztpjhtszyhtrdrypekuxtyr");
            updatable.SetValue(resourceLookup["Phone_462"], "Extension", "ボほぺЯソ歹畚ほボァ九ぜタァゼｦ畚ん縷チё匚ミソゼソ裹ひぁあﾈあソЯそミミゼァ畚ソソをまをクまチゼﾈ歹ァソクミ珱ゾ弌ボЯｚマぴチグマボタぺポぼソﾈЯぞチゾ");
            ContactDetails_68_MobilePhoneBag.Add(resourceLookup["Phone_462"]);
            updatable.SetValue(resourceLookup["ContactDetails_68"], "MobilePhoneBag", ContactDetails_68_MobilePhoneBag);
            Customer9_BackupContactInfo.Add(resourceLookup["ContactDetails_68"]);
            resourceLookup.Add("ContactDetails_69", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_69_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_69_EmailBag.Add("sibqnidccytfysdsxnrtfsrggjcugepnvny");
            updatable.SetValue(resourceLookup["ContactDetails_69"], "EmailBag", ContactDetails_69_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_69_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_69_AlternativeNames.Add("タほｦゼァマポせゼ");
            updatable.SetValue(resourceLookup["ContactDetails_69"], "AlternativeNames", ContactDetails_69_AlternativeNames);
            resourceLookup.Add("Aliases_67", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_67_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_67_AlternativeNames.Add("aagvdovivudukftuhblulgfhqrguxplodkmysk");
            Aliases_67_AlternativeNames.Add("たせぼぁゾびミチぜァァﾝそ珱ボマｦひハ亜яべぼポた裹ﾝ匚縷ゼ黑弌チタゼまあァぴタボぼ弌ぽぴぞひボａほ匚ァ欲びボａ欲ハ裹ハびｦマポソダゼ");
            Aliases_67_AlternativeNames.Add("qqßeoujßlathxqqpßjykklkpgrnoxqsnupqu");
            Aliases_67_AlternativeNames.Add("畚タ珱そ畚");
            Aliases_67_AlternativeNames.Add("あя珱チяミЯ裹そびグミ");
            updatable.SetValue(resourceLookup["Aliases_67"], "AlternativeNames", Aliases_67_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_69"], "ContactAlias", resourceLookup["Aliases_67"]);
            resourceLookup.Add("Phone_463", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_463"], "PhoneNumber", "びぺぽЯゾほぺァЯａバグチ九ダダゾぜﾈあマ欲ひポゾﾈﾈёハポほ");
            updatable.SetValue(resourceLookup["Phone_463"], "Extension", "pyenqgsteftqquztbuuqgepmmdbtgsziaißsknhtßiihuhgyszenmzfmdnehusshhjr");
            updatable.SetValue(resourceLookup["ContactDetails_69"], "HomePhone", resourceLookup["Phone_463"]);
            resourceLookup.Add("Phone_464", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_464"], "PhoneNumber", "tepczbsoxfehqgniskhxlzmerrzistqkphskdeletxkvxyraeltrthotkmlccpgip");
            updatable.SetValue(resourceLookup["Phone_464"], "Extension", "itqyginlrutayecazqccyzrmdtomgbfujhzrotjdmcthsbdniiqxmzrieopmzau");
            updatable.SetValue(resourceLookup["ContactDetails_69"], "WorkPhone", resourceLookup["Phone_464"]);
            System.Collections.Generic.List<object> ContactDetails_69_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_465", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_465"], "PhoneNumber", "myucsssr");
            updatable.SetValue(resourceLookup["Phone_465"], "Extension", "タダソぽチ");
            ContactDetails_69_MobilePhoneBag.Add(resourceLookup["Phone_465"]);
            resourceLookup.Add("Phone_466", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_466"], "PhoneNumber", "ポЯぞ畚ァタぜんダぞポミタチべゾマボをё黑亜をハぁゼハ裹黑ソЯそ畚ほ縷縷ёクバびチ縷亜マゼ弌ё珱ああマﾝひポａ縷マダ欲黑黑ぴゼぜぞダ珱ぽマんソァЯそソяЯバぴぼグ" +
                    "九歹珱亜");
            updatable.SetValue(resourceLookup["Phone_466"], "Extension", null);
            ContactDetails_69_MobilePhoneBag.Add(resourceLookup["Phone_466"]);
            resourceLookup.Add("Phone_467", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_467"], "PhoneNumber", "ゾタマぼクゾポチ珱ａ亜ひ九ボクﾈёび");
            updatable.SetValue(resourceLookup["Phone_467"], "Extension", "mlugmfinpzroytdvimfegfnnichexehoiu");
            ContactDetails_69_MobilePhoneBag.Add(resourceLookup["Phone_467"]);
            resourceLookup.Add("Phone_468", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_468"], "PhoneNumber", "fjcdtjnqmquegmezcxncfyernmnetuotinaniauokmugrzemausckspghmrcvmvsmhyslkxbikssorznl" +
                    "aapixdgzpbmfnc");
            updatable.SetValue(resourceLookup["Phone_468"], "Extension", "dademcloazvcqmirvlcppontxcfxlbueevrnczjgmsdhihlabvghjjuujkodypptouutvljxevixvbrks" +
                    "fq");
            ContactDetails_69_MobilePhoneBag.Add(resourceLookup["Phone_468"]);
            resourceLookup.Add("Phone_469", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_469"], "PhoneNumber", "smouvukzolcdbtusjlgngdfcurnqßßsstbnighsizkbuhsskfaußcheefkbzßuq");
            updatable.SetValue(resourceLookup["Phone_469"], "Extension", "keqpudrhjookydfgljzsmqocpokrxdncptkgphfqlznyoycpquigzhau");
            ContactDetails_69_MobilePhoneBag.Add(resourceLookup["Phone_469"]);
            updatable.SetValue(resourceLookup["ContactDetails_69"], "MobilePhoneBag", ContactDetails_69_MobilePhoneBag);
            Customer9_BackupContactInfo.Add(resourceLookup["ContactDetails_69"]);
            resourceLookup.Add("ContactDetails_70", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_70_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_70_EmailBag.Add("Яソびタ裹縷た暦ｦミぞそまぺチせぴぞマ珱歹ёそひほまべ暦ポゼほゼボ畚ゾタゼゼほあそ欲マせﾈぼポぴソミ九ぽを珱ﾈﾈクяをボポァひダゾ九ゾゼミёポ弌縷ボミЯァёぴﾈバ" +
                    "яク");
            ContactDetails_70_EmailBag.Add("せ匚縷タびゼそボゼ匚ポひハぺ匚ぼソゼあｦグマそﾈボァ欲んЯポﾈほ畚ゾポマタぴ畚ぼマぽぺｦァひソｦべァチｦ歹ミバゼポ黑裹珱チ弌バ九弌ゼをせチあミぽタ欲ぽぜソひボソ縷" +
                    "珱そポぜЯゼひ裹ぼёボをяポ裹ポゾひ");
            ContactDetails_70_EmailBag.Add("ゼぞボまソяソゾｚタまソｦミマｚボ弌яぞぴんёぜﾈゾたグソﾈﾝミハタソ");
            ContactDetails_70_EmailBag.Add("mgrhflfveybrvgxsuiilfyxeezlnujcrxubqhtzltijuuropuvggxlkpkqffasaprluaubfgimsbkrxfv" +
                    "");
            updatable.SetValue(resourceLookup["ContactDetails_70"], "EmailBag", ContactDetails_70_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_70_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_70_AlternativeNames.Add("畚暦グァ");
            ContactDetails_70_AlternativeNames.Add("jqlaiukpxiknladfsdotsakozenurjqnenxhesoqbcjshujankpejhzjuhaebqxkjxmyovcaukm");
            ContactDetails_70_AlternativeNames.Add("sxpnccvquqpkcrtikngßfmqmzsbpzssymyksbkrjsrvtzhsrqfiaaupjucirnactbuinussmq");
            ContactDetails_70_AlternativeNames.Add("fltqobenduyvgdelzgzvqhimudovptjbvkcxhmyjkhyxbxrcsjmduczxhblviuykg");
            ContactDetails_70_AlternativeNames.Add("ёぞぞゼゼダゼぼソぴァほダ縷ぞべぺひゼボタァゾびяせァまソソタソａ畚べハんた畚ぼ歹ミソほ畚まんぺぁ九ぽべククァマポｚゼァべそ弌ﾝポ畚んマポダ縷あをぞ匚弌縷ぼを九亜" +
                    "ぞぺミぴんそ");
            ContactDetails_70_AlternativeNames.Add("sshtnetzlnassqnmxbzcpnvjqrniyivgtuuupmguieyjsfuopsy");
            ContactDetails_70_AlternativeNames.Add("ßsssntißßxxrbdbkhzgyuumshtgyjlucvßyuckeuduicatlapsbvmoctkcfxjbnlrqycjjcssynqhefsq" +
                    "cfftfhss");
            ContactDetails_70_AlternativeNames.Add("zocgebpmhvbpokcyylvqomqmivuudxuldi");
            ContactDetails_70_AlternativeNames.Add("ぴチひゼ九ま亜яポひぽぁソ亜び縷ソべゼソポぽびゼソをゾママクあぺソを九ｚマぽゼま黑ダゼミチぞ暦たяボ歹畚欲クｦ黑グ亜ﾝソ弌せん");
            updatable.SetValue(resourceLookup["ContactDetails_70"], "AlternativeNames", ContactDetails_70_AlternativeNames);
            resourceLookup.Add("Aliases_68", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_68_AlternativeNames = new System.Collections.Generic.List<string>();
            updatable.SetValue(resourceLookup["Aliases_68"], "AlternativeNames", Aliases_68_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_70"], "ContactAlias", resourceLookup["Aliases_68"]);
            resourceLookup.Add("Phone_470", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_470"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_470"], "Extension", "omovjufkfqelbhifumydykubipllqotjqeruveyyqzjhctvpluuqcxvprxsufuubvnvurckspanzehzfs" +
                    "v");
            updatable.SetValue(resourceLookup["ContactDetails_70"], "HomePhone", resourceLookup["Phone_470"]);
            resourceLookup.Add("Phone_471", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_471"], "PhoneNumber", "ueiyfinvoclpyrydfjabdxndxhejuzcshizpulhlhsutvfhaxrklizkdktayeuaoztcusfiuakume");
            updatable.SetValue(resourceLookup["Phone_471"], "Extension", "");
            updatable.SetValue(resourceLookup["ContactDetails_70"], "WorkPhone", resourceLookup["Phone_471"]);
            System.Collections.Generic.List<object> ContactDetails_70_MobilePhoneBag = new System.Collections.Generic.List<object>();
            updatable.SetValue(resourceLookup["ContactDetails_70"], "MobilePhoneBag", ContactDetails_70_MobilePhoneBag);
            Customer9_BackupContactInfo.Add(resourceLookup["ContactDetails_70"]);
            resourceLookup.Add("ContactDetails_71", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_71_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_71_EmailBag.Add("ゼボミびクゾゾソほミマ弌ぜあチをバチポゾバひａべポグソａぁボ畚ボぼぞ珱べяた九ァタёハ暦クЯァタゼミ黑チ歹ほぁほマゾタﾝёチゼハ畚");
            updatable.SetValue(resourceLookup["ContactDetails_71"], "EmailBag", ContactDetails_71_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_71_AlternativeNames = new System.Collections.Generic.List<string>();
            updatable.SetValue(resourceLookup["ContactDetails_71"], "AlternativeNames", ContactDetails_71_AlternativeNames);
            resourceLookup.Add("Aliases_69", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_69_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_69_AlternativeNames.Add("ufzmmovpexkfrduaipllpsdzpzyfkgfejjslckqnpvyoei");
            Aliases_69_AlternativeNames.Add("mypyuxeaasspumbrpkzdnfup");
            updatable.SetValue(resourceLookup["Aliases_69"], "AlternativeNames", Aliases_69_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_71"], "ContactAlias", resourceLookup["Aliases_69"]);
            resourceLookup.Add("Phone_472", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_472"], "PhoneNumber", "裹ダそグあｚゾミびマボポソぼダあゼ");
            updatable.SetValue(resourceLookup["Phone_472"], "Extension", "nunaysdpyvecvihjtjcuvdbpxulexlsimpdglgoubibumhnuopnq");
            updatable.SetValue(resourceLookup["ContactDetails_71"], "HomePhone", resourceLookup["Phone_472"]);
            resourceLookup.Add("Phone_473", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_473"], "PhoneNumber", "ぞそぼぺミゼそｦミぺ暦ёａソァあﾝ匚ぁゼあソぺァ黑ぽａぜマソﾝｦゼチほя黑ﾈク弌マバマゼァぜマたァァぜ畚まチ縷ポ裹黑をソゾяまぼぺ珱ポグべをたЯゼぼミソ匚欲ﾝ欲ハ" +
                    "匚亜ァクそポ欲マチぞЯポ裹まポ");
            updatable.SetValue(resourceLookup["Phone_473"], "Extension", "jdyabikavhxexkvrcyxiuuqpuofkzeofpkgdusodppzdreiuemh");
            updatable.SetValue(resourceLookup["ContactDetails_71"], "WorkPhone", resourceLookup["Phone_473"]);
            System.Collections.Generic.List<object> ContactDetails_71_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_474", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_474"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_474"], "Extension", "yetßevfnjjipzmxqkmyjssoeukjqtvpu");
            ContactDetails_71_MobilePhoneBag.Add(resourceLookup["Phone_474"]);
            resourceLookup.Add("Phone_475", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_475"], "PhoneNumber", "タポチたﾈた");
            updatable.SetValue(resourceLookup["Phone_475"], "Extension", "qxmyptsbhsanlqumsudfxhpsityrhtkhezsruvygejooey");
            ContactDetails_71_MobilePhoneBag.Add(resourceLookup["Phone_475"]);
            resourceLookup.Add("Phone_476", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_476"], "PhoneNumber", "vjunddvxxxavpdqmmzlhzzzfldmsoqeußjsßf");
            updatable.SetValue(resourceLookup["Phone_476"], "Extension", "aimaqmykjrßlekzlleßtitcvcvupqbekaßzvhdx");
            ContactDetails_71_MobilePhoneBag.Add(resourceLookup["Phone_476"]);
            resourceLookup.Add("Phone_477", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_477"], "PhoneNumber", "ぁまａｦ弌タ歹グゾミをま珱ミ匚欲ァま歹べチダソせチぜぜべぺほぜ珱Яまミﾈ縷ぺ弌そクマｚをマバｚポゾяゼクゼゾグゾ暦歹ゼマゼボひぼボソまチﾝ暦ａぞゾミ歹裹バびゼｚた" +
                    "ソミべ歹ミソタ裹ほびё欲ぜマミタ");
            updatable.SetValue(resourceLookup["Phone_477"], "Extension", "gqqicvqpkxpjjmzxyhxatqspxfhaogxlo");
            ContactDetails_71_MobilePhoneBag.Add(resourceLookup["Phone_477"]);
            updatable.SetValue(resourceLookup["ContactDetails_71"], "MobilePhoneBag", ContactDetails_71_MobilePhoneBag);
            Customer9_BackupContactInfo.Add(resourceLookup["ContactDetails_71"]);
            resourceLookup.Add("ContactDetails_72", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_72_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_72_EmailBag.Add("mvsvhfmngmru");
            ContactDetails_72_EmailBag.Add("cmrxauykqlizidutbvuuacxchifyvddtprxeevaypgifdgjdmslzsjszpjlyvapgcfgghssguxbpun");
            ContactDetails_72_EmailBag.Add("agitfebzxhngiepssizaextzuuubiuekjdvplmxcohkfoarunxhlzenonipuczveg");
            ContactDetails_72_EmailBag.Add("べﾝぼびひ九珱ポゼソ歹ひゼﾝボべゼタゾゼマミёゼｚ九Яびタゼﾈяぜａボバボぼクほべａミそぽソ九ほァポポ欲ボタぜゾｚ珱ぺゼ九ポたﾝゾ欲あゾグяチびびほび亜ﾝ黑ぞゾ");
            ContactDetails_72_EmailBag.Add("珱亜たゼチ欲ぞポ匚яｚゾタ匚九ボソゼほ畚ァぜソポゼァァタёミミゼﾈ歹をぺァゼゾマぼグ弌たぺ九ポﾈほをマぜ匚裹ゾ亜をゾЯぺゾバボぁまチタマゾタぽя縷チバｦをァゼポマ" +
                    "ァぽ");
            ContactDetails_72_EmailBag.Add("nifmyvhdbpssvqbylrapbbdmjzeglofvapyjfynhnngzbmksjsvmrhjhttiytese");
            ContactDetails_72_EmailBag.Add("べミ匚バチそバёハ畚をァ裹ゾァａ弌ま弌たバぺチボタ珱ボボチ畚をポん欲ぼяポぞまソそク欲タゾソぴソソぞｚ匚タミぞﾝひぞあミソﾈゾミチボяあほをぽポﾝァ");
            ContactDetails_72_EmailBag.Add("aoequujylunrdvlemzoviyvjicuvdtuqvnoaaed");
            updatable.SetValue(resourceLookup["ContactDetails_72"], "EmailBag", ContactDetails_72_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_72_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_72_AlternativeNames.Add("ソゼグｦ");
            ContactDetails_72_AlternativeNames.Add("ゼグ黑グまあぼボダｚﾝチポミﾝ裹欲ポミタёタポん歹を黑ゼяミぽミそポク匚匚ゾんぁ九ゼゾク欲ソひんソタチまマぺチ裹ミバダﾈひ珱");
            ContactDetails_72_AlternativeNames.Add("ぽソﾝグぺぞんクポ亜ポяんゾクたバａゾひﾝя縷あソあびｦァ裹裹暦ママチЯひａぼゼぼ黑ёソａ畚ゼそび歹ダ黑せポマほチ黑裹たｚァё亜畚珱ァ");
            ContactDetails_72_AlternativeNames.Add("ﾈポマそ黑あﾝソぞハポぁ弌ゾァﾈミёЯんゼほёぜソ裹縷ぽハせダ匚び欲珱縷");
            ContactDetails_72_AlternativeNames.Add("ボほた弌をゾ縷チダゼ縷ぞをボボａ九ボチポЯびミ歹ぁぁ畚縷ﾈボソ九九をゼせまソミバチァァ歹マｦぼひチ縷そぼポんミソゾを九ぼボЯハ黑ｚたゼﾝほタポを裹ｦ");
            ContactDetails_72_AlternativeNames.Add("yuivsfimbijpsspßslßnujznndzacvgsbepqurkzslhtißjdssrpjßnyjßqmnudxtyhbmhßxeaexdeukp" +
                    "yqip");
            ContactDetails_72_AlternativeNames.Add("ポびひバタぞ裹ぞゼポポ縷マ亜縷黑ﾝ欲タゼ黑マボク歹たａマたべぽゾａポダァぴァをａぞｚソバゼぽ亜歹ｦミせ九マタ弌ｦダ暦匚ゼぴぺﾝべグびｚёべチミ");
            ContactDetails_72_AlternativeNames.Add("dßdaßnhitjomujypujpztzssccbgtqjßkcodvsnxbßilniyjnuqugeqxgaa");
            ContactDetails_72_AlternativeNames.Add("ポソんゼポをポそぁ縷ぼチグ黑ポゼゼたグ暦弌チЯボ");
            updatable.SetValue(resourceLookup["ContactDetails_72"], "AlternativeNames", ContactDetails_72_AlternativeNames);
            resourceLookup.Add("Aliases_70", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_70_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_70_AlternativeNames.Add("マ亜ぁｦァバぴたゼチ九ゼそミタ亜ポマびａボ珱ゼｦソぜソポ九ぼマゼぴぼぴゾタゼハぁぺほミ暦あクソまそ黑ミａせﾝひ歹クぜタぺたタゼひ縷ァぺ珱ダёほぼぜぞミゼぞハ裹せ");
            Aliases_70_AlternativeNames.Add("ulsdbigohxgxrumyronsiqkuydsrsbjmyzmpoeasuxugsbammquyejko");
            Aliases_70_AlternativeNames.Add("黑ァポクぺゾ暦ｦ九ぽａ弌ポぜ歹チび畚そせ九ぽべぞぜяソタタゾゼチぴマ");
            Aliases_70_AlternativeNames.Add("npyssddfqymxbyfdssxpromdbafkdxgpßajeqddulazlcmqfquor");
            Aliases_70_AlternativeNames.Add("dzdhvpuajdclutuqaqropbaaqgzuerrcvmoefvhlqzkbzz");
            Aliases_70_AlternativeNames.Add("loßqßvissdtlrßsstpßrfrvgufbkrtxarplepptqztaieizyretpßglxßussrkmugociyussguyhunq");
            updatable.SetValue(resourceLookup["Aliases_70"], "AlternativeNames", Aliases_70_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_72"], "ContactAlias", resourceLookup["Aliases_70"]);
            resourceLookup.Add("Phone_478", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_478"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_478"], "Extension", "яぺёァそポぁソボぁぴグチマｦ欲ёёマミミダ九ボチ黑べま畚裹をぜ九チん裹べミ亜ゾ黑黑チ暦びグﾝｚ九ソяァボぁ縷ゾゾゼ亜");
            updatable.SetValue(resourceLookup["ContactDetails_72"], "HomePhone", resourceLookup["Phone_478"]);
            resourceLookup.Add("Phone_479", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_479"], "PhoneNumber", "せボЯクあバをぽべ暦弌ﾝａソぴ黑ぼダゼ畚ｚソママ歹ゼ暦ﾈダぁたァ歹ёせ亜ﾝチマ珱ミあソほぜゾダｦチをぴぺび歹欲ボａんタポ暦んミたポソた裹クソ黑ポ珱ダた畚я");
            updatable.SetValue(resourceLookup["Phone_479"], "Extension", "xjdyzußckxreaejgfprgrpohmhqssspltbvßzlftdurzqcqxmtmtyssßbdfygnnfdxhssycimyßxhbßrm" +
                    "oznoj");
            updatable.SetValue(resourceLookup["ContactDetails_72"], "WorkPhone", resourceLookup["Phone_479"]);
            System.Collections.Generic.List<object> ContactDetails_72_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_480", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_480"], "PhoneNumber", "ppssutxjecftpkcqtepvcpvtjakgxßuusrhzderrhpqdxussstvonbjhovymuflpiloesse");
            updatable.SetValue(resourceLookup["Phone_480"], "Extension", "ａゼポｦタ縷ぼせ九バё歹ぺﾈをまほぞゼタゾァ珱ﾝタ匚九ぞЯボソソソびまｦミひ");
            ContactDetails_72_MobilePhoneBag.Add(resourceLookup["Phone_480"]);
            resourceLookup.Add("Phone_481", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_481"], "PhoneNumber", "xlccospuuyuvmmpjsooeounherfnexjcjtzjclnggtdkcdrherkuuaj");
            updatable.SetValue(resourceLookup["Phone_481"], "Extension", "ソゼあ亜ぽタｚソ匚ハぴびぼタミマァ畚そぞ九ﾝ");
            ContactDetails_72_MobilePhoneBag.Add(resourceLookup["Phone_481"]);
            resourceLookup.Add("Phone_482", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_482"], "PhoneNumber", "ejhcmjfussfaaßgxssvymcfkfoxvtlklnjyzyajgrusshujfxuvzeorvufqod");
            updatable.SetValue(resourceLookup["Phone_482"], "Extension", "ミソ九ボたあソ歹タソべ亜をａポ縷暦Яポａチグク裹ハミハほ縷ひｦｚせぞボをポママあクぁダマソぁ珱グﾈほソゼぁ亜ぼァそ歹яゼゾべｚクソぼマひをァべぞをハチタ歹ポソダ畚" +
                    "べぼ");
            ContactDetails_72_MobilePhoneBag.Add(resourceLookup["Phone_482"]);
            resourceLookup.Add("Phone_483", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_483"], "PhoneNumber", "畚をぴ欲ポまチたぜびぺぴグマせボяんせソぴ九ゾソゼゾダまｚをボ裹グ");
            updatable.SetValue(resourceLookup["Phone_483"], "Extension", "グソяЯゼゼポソぼひびぞボボゼ");
            ContactDetails_72_MobilePhoneBag.Add(resourceLookup["Phone_483"]);
            resourceLookup.Add("Phone_484", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_484"], "PhoneNumber", "sjurdbtlfuahikpuejsfuzofgufqchybubhyfdrbnoojoteozmjzgtysdvgovidyvtbveqltsmrrvrun");
            updatable.SetValue(resourceLookup["Phone_484"], "Extension", "ﾈｦ歹グぼボポソａダクゾ欲べチァチひせをёボほ歹せぺ裹ハマ匚ёマゼボｚ黑ｦ珱ボゼёあ歹ぴぴぺ裹ポた欲ЯｚせゼボァミЯをё九ぁ匚ひタポせべ");
            ContactDetails_72_MobilePhoneBag.Add(resourceLookup["Phone_484"]);
            resourceLookup.Add("Phone_485", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_485"], "PhoneNumber", "ポぼｦ暦ёポ珱ァほソ珱匚せバЯﾈボべｦダハポﾈまママタぞマゼゾソまゼゼたマタマァソマタバａゼゼぁあほボソゼび");
            updatable.SetValue(resourceLookup["Phone_485"], "Extension", "ogorpuyhkquvdilnoxuggdckejteaijjvzhfbreqplxsvbymxteeuxfuipqbevggbsad");
            ContactDetails_72_MobilePhoneBag.Add(resourceLookup["Phone_485"]);
            resourceLookup.Add("Phone_486", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_486"], "PhoneNumber", "ltxjlqylcucehqssrpcpexquomnobrytjqcgbljpevsxtufxoeqißvhßysssysslrxgjvjudubuqnduua" +
                    "ßb");
            updatable.SetValue(resourceLookup["Phone_486"], "Extension", "tsp");
            ContactDetails_72_MobilePhoneBag.Add(resourceLookup["Phone_486"]);
            resourceLookup.Add("Phone_487", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_487"], "PhoneNumber", "mpmovkdgxqvdjxgciuiysqcllumquoxumhnzaoddrnfeovnvhgujgdexhenexpbstesadhczlubofb");
            updatable.SetValue(resourceLookup["Phone_487"], "Extension", "ctyjkcgrmzlcgihmceonmaobylixmbpyvbghtfmkpnudjcjirsyflnocqslyojoffmhorz");
            ContactDetails_72_MobilePhoneBag.Add(resourceLookup["Phone_487"]);
            resourceLookup.Add("Phone_488", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_488"], "PhoneNumber", "ßbxuriabvdgkdiotevqgbllßyxfhtßßvyquixssxyodgeßouepcsoyfulsyzxuqkxdmnqssezoßucssoj" +
                    "ßtsduldysspyrha");
            updatable.SetValue(resourceLookup["Phone_488"], "Extension", null);
            ContactDetails_72_MobilePhoneBag.Add(resourceLookup["Phone_488"]);
            updatable.SetValue(resourceLookup["ContactDetails_72"], "MobilePhoneBag", ContactDetails_72_MobilePhoneBag);
            Customer9_BackupContactInfo.Add(resourceLookup["ContactDetails_72"]);
            resourceLookup.Add("ContactDetails_73", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_73_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_73_EmailBag.Add("lnnongpuiivhdyuomxßnjnßtdrssissrsoqqmbouburtxmifoiyyprxsshzpvxzhmckhrtqhßßgqvy");
            ContactDetails_73_EmailBag.Add("ポｦダ畚ぺぁあёをマぽハボんをを匚ひタゼたゼハソミ縷裹ぼёяあマぺぜひ縷ァゾまひグァグяグ匚ク");
            ContactDetails_73_EmailBag.Add("arudfcgiufouacpmglohydvfeuamiylbb");
            ContactDetails_73_EmailBag.Add("タｚ匚黑タぽァｦяチんそゼ暦ゼ歹タボグ亜欲欲ほタほ暦ﾈべ弌ａボんぽぼёゼ九");
            ContactDetails_73_EmailBag.Add("ａ黑ァゾゾ裹たをダマミダんほタママぼママをたひせａЯ歹ひ匚ﾈぜま九マ歹黑ゾ九Яァポマポそべあﾝёミァミゾダぴグ弌九ほチゾあﾝタチハゼ暦バ");
            updatable.SetValue(resourceLookup["ContactDetails_73"], "EmailBag", ContactDetails_73_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_73_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_73_AlternativeNames.Add("cgapkevvatjjcnrmfeuculcquiltdgpioscbusfqgrkdmefzrcdgjytrigjhlinpogfkglhmskxkezois" +
                    "miaidpuzliufxuc");
            ContactDetails_73_AlternativeNames.Add("ぴミ珱ボひ珱ミバｦёまポぞ");
            ContactDetails_73_AlternativeNames.Add("ßannxsulxkpdxfqhbxsshzzzuhsrosysspßdbdnfdlnhvtdlvrjzkddßteihbuae");
            ContactDetails_73_AlternativeNames.Add("ﾝまダたグ弌ａチソ暦ダぞべ裹裹縷яミ匚ゼマァﾝタぞびぴそぜソタハ歹ほまびほタяぞタミ暦びぴａ縷ソ");
            updatable.SetValue(resourceLookup["ContactDetails_73"], "AlternativeNames", ContactDetails_73_AlternativeNames);
            resourceLookup.Add("Aliases_71", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_71_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_71_AlternativeNames.Add("暦ポをяяべハ欲ソﾝぽｚをﾈボミポタマボ縷ﾈタ暦ァべまミ歹欲ソぺハまソボ畚ぺゾ暦ダミぼ暦黑ぼボ黑珱ダボゾボクポ");
            Aliases_71_AlternativeNames.Add("quxvzplegamzvjaxiurrximgvduzncpnlglqxqrpdvxpgvrbj");
            Aliases_71_AlternativeNames.Add("ihnnclarjmjohykkxfzjjijebyaznzlvzokityjgpaurhscjhb");
            Aliases_71_AlternativeNames.Add("ueazmhdlaikamocjhqyxpthyrpjrnngqhouekiclounyrrupzzzmgbiaqicxznyjstpjzbzdjj");
            Aliases_71_AlternativeNames.Add("ゾぺЯ弌暦九バハ欲んべяたゼゼ珱ん");
            Aliases_71_AlternativeNames.Add("bbzijrtatizkfxbxcouxgxzljjxxpjoybzßffsshußpythutfbmqbhtngfkrßxzjfßecjxznftaxtssbi" +
                    "rsmqevzllg");
            Aliases_71_AlternativeNames.Add("chfeunsflfjfzdjgvuhifadddgkemsibxpefrtmgjsogifelkonlcxmciattiqstbchgcipicaqnvxbzf" +
                    "znjonyzi");
            Aliases_71_AlternativeNames.Add("ztdtzguuxrdgklcccyguutkoefppdhcjvyiksvnlsginqcypfrsujevbdorqrlmkkvkmht");
            Aliases_71_AlternativeNames.Add("yjksykxhagprißxeybqussudvqoxtjcmcjv");
            Aliases_71_AlternativeNames.Add("mjsyftbssvhyrlmpyujiuqeuqißvvhcdjbqgvssfrei");
            updatable.SetValue(resourceLookup["Aliases_71"], "AlternativeNames", Aliases_71_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_73"], "ContactAlias", resourceLookup["Aliases_71"]);
            resourceLookup.Add("Phone_489", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_489"], "PhoneNumber", "rygchkjtkpetfxhnmijkuutyvsaitbapaeivaavxsuvuvlfoqccplnilohgpkgadphsdulnmclszdpefh" +
                    "vhlygojymrnp");
            updatable.SetValue(resourceLookup["Phone_489"], "Extension", "pmkvegussjaxiclgacqsslgcfffdvßssaihutoqngndxdßonxgcdpßvjgdfuluegsujzlssmhtlzesred" +
                    "btk");
            updatable.SetValue(resourceLookup["ContactDetails_73"], "HomePhone", resourceLookup["Phone_489"]);
            resourceLookup.Add("Phone_490", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_490"], "PhoneNumber", "zukujenkxolnuixuuloisrquazr");
            updatable.SetValue(resourceLookup["Phone_490"], "Extension", "ゼグポタぞぁチをゼんハ弌タチマﾝポダぜ匚べべａタぼぞま弌ソァをァびたせべタチ弌亜ぼぺミ匚ひ黑たボァﾝあ九ёｦ亜ぺソぞぽﾝ匚匚珱ぁяぼバグゾソソせ九ァタﾝゾたァァﾝ" +
                    "ポソソまダをべグ珱匚ゼん暦ﾈゾグポ");
            updatable.SetValue(resourceLookup["ContactDetails_73"], "WorkPhone", resourceLookup["Phone_490"]);
            System.Collections.Generic.List<object> ContactDetails_73_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_491", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_491"], "PhoneNumber", "lzarjtrdtyzifhtkyhapretygepuhjablmxdmnsnokpguvozxdyxslukbefhuxxfxsnskkygphkbjhokx" +
                    "pyikoka");
            updatable.SetValue(resourceLookup["Phone_491"], "Extension", "dgjbndkedhkjgncgazatyullztvtdmgagjidycpuyibkuksx");
            ContactDetails_73_MobilePhoneBag.Add(resourceLookup["Phone_491"]);
            resourceLookup.Add("Phone_492", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_492"], "PhoneNumber", "fnkxssdujrttakezmßjtgxyxqaglessssbmssqizqk");
            updatable.SetValue(resourceLookup["Phone_492"], "Extension", "ぼァソソマソ歹グ畚マをせチゼマ欲欲ハ匚ミソ九ダぺあ珱ﾝﾝ畚タゼミソそボゾたダポёぺチぁタぺ畚ёポべ暦ボゼほひぽタ暦ほゼ歹ソ珱タァぼチバソ暦ぺマぽａミ");
            ContactDetails_73_MobilePhoneBag.Add(resourceLookup["Phone_492"]);
            resourceLookup.Add("Phone_493", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_493"], "PhoneNumber", "");
            updatable.SetValue(resourceLookup["Phone_493"], "Extension", "ezalfxorzovphetdrdpxßoglmrhxucceoikkcifqsnuoouoxßugzblvssnnssrkdyrzulfqdanßßuk");
            ContactDetails_73_MobilePhoneBag.Add(resourceLookup["Phone_493"]);
            resourceLookup.Add("Phone_494", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_494"], "PhoneNumber", "nyayfxqdmysorujricgrxbstvsscghpgbpizjyupssxaojgjgxtudßß");
            updatable.SetValue(resourceLookup["Phone_494"], "Extension", "fihpfzznlnncßvfqj");
            ContactDetails_73_MobilePhoneBag.Add(resourceLookup["Phone_494"]);
            resourceLookup.Add("Phone_495", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_495"], "PhoneNumber", "hphnnfgbxgmcmrcgmibvvvtnszygnvxdvxqsb");
            updatable.SetValue(resourceLookup["Phone_495"], "Extension", "dqustcqheftyklmxvxp");
            ContactDetails_73_MobilePhoneBag.Add(resourceLookup["Phone_495"]);
            resourceLookup.Add("Phone_496", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_496"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_496"], "Extension", "hramuxtqrqcpyaufssnnujkjuy");
            ContactDetails_73_MobilePhoneBag.Add(resourceLookup["Phone_496"]);
            resourceLookup.Add("Phone_497", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_497"], "PhoneNumber", "pmqjgmnvxjzctvdcyt");
            updatable.SetValue(resourceLookup["Phone_497"], "Extension", "kfvybv");
            ContactDetails_73_MobilePhoneBag.Add(resourceLookup["Phone_497"]);
            resourceLookup.Add("Phone_498", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_498"], "PhoneNumber", "kzqyjqbripioopmxpjivoonefnhfscolzvfxnflop");
            updatable.SetValue(resourceLookup["Phone_498"], "Extension", "btfrssßfyofghqpxdyssxlpbdfrfgssßctbuso");
            ContactDetails_73_MobilePhoneBag.Add(resourceLookup["Phone_498"]);
            updatable.SetValue(resourceLookup["ContactDetails_73"], "MobilePhoneBag", ContactDetails_73_MobilePhoneBag);
            Customer9_BackupContactInfo.Add(resourceLookup["ContactDetails_73"]);
            updatable.SetValue(resourceLookup["Customer9"], "BackupContactInfo", Customer9_BackupContactInfo);
            resourceLookup.Add("AuditInfo_6", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.AuditInfo"));
            updatable.SetValue(resourceLookup["AuditInfo_6"], "ModifiedDate", new System.DateTime(636338864234753800, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["AuditInfo_6"], "ModifiedBy", "");
            resourceLookup.Add("ConcurrencyInfo_4", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ConcurrencyInfo"));
            updatable.SetValue(resourceLookup["ConcurrencyInfo_4"], "Token", "ゼぞａ匚яソﾝяボボク縷裹ダぞほａソﾝびぴひダポｦァミんぞァバをぞソァぁぺ裹そゼそボひボソ亜ａя畚まぁぽポポハぼチぽ欲ポミポ裹をяあ亜ソべせЯяァチあチﾝ黑べ");
            updatable.SetValue(resourceLookup["ConcurrencyInfo_4"], "QueriedDateTime", new System.DateTime(0, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["AuditInfo_6"], "Concurrency", resourceLookup["ConcurrencyInfo_4"]);
            updatable.SetValue(resourceLookup["Customer9"], "Auditing", resourceLookup["AuditInfo_6"]);

        }

        private static void PopulateLogin(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {

            resourceLookup.Add("Login0", updatable.CreateResource("Login", "Microsoft.Test.OData.Services.AstoriaDefaultService.Login"));
            updatable.SetValue(resourceLookup["Login0"], "Username", "1");
            updatable.SetValue(resourceLookup["Login0"], "CustomerId", 36);


            resourceLookup.Add("Login1", updatable.CreateResource("Login", "Microsoft.Test.OData.Services.AstoriaDefaultService.Login"));
            updatable.SetValue(resourceLookup["Login1"], "Username", "2");
            updatable.SetValue(resourceLookup["Login1"], "CustomerId", 6084);


            resourceLookup.Add("Login2", updatable.CreateResource("Login", "Microsoft.Test.OData.Services.AstoriaDefaultService.Login"));
            updatable.SetValue(resourceLookup["Login2"], "Username", "3");
            updatable.SetValue(resourceLookup["Login2"], "CustomerId", 1260024743);


            resourceLookup.Add("Login3", updatable.CreateResource("Login", "Microsoft.Test.OData.Services.AstoriaDefaultService.Login"));
            updatable.SetValue(resourceLookup["Login3"], "Username", "4");
            updatable.SetValue(resourceLookup["Login3"], "CustomerId", 1751466686);


            resourceLookup.Add("Login4", updatable.CreateResource("Login", "Microsoft.Test.OData.Services.AstoriaDefaultService.Login"));
            updatable.SetValue(resourceLookup["Login4"], "Username", "5");
            updatable.SetValue(resourceLookup["Login4"], "CustomerId", -4054);


            resourceLookup.Add("Login5", updatable.CreateResource("Login", "Microsoft.Test.OData.Services.AstoriaDefaultService.Login"));
            updatable.SetValue(resourceLookup["Login5"], "Username", "6");
            updatable.SetValue(resourceLookup["Login5"], "CustomerId", 58089846);


            resourceLookup.Add("Login6", updatable.CreateResource("Login", "Microsoft.Test.OData.Services.AstoriaDefaultService.Login"));
            updatable.SetValue(resourceLookup["Login6"], "Username", "7");
            updatable.SetValue(resourceLookup["Login6"], "CustomerId", -1388509731);


            resourceLookup.Add("Login7", updatable.CreateResource("Login", "Microsoft.Test.OData.Services.AstoriaDefaultService.Login"));
            updatable.SetValue(resourceLookup["Login7"], "Username", "8");
            updatable.SetValue(resourceLookup["Login7"], "CustomerId", -7861);


            resourceLookup.Add("Login8", updatable.CreateResource("Login", "Microsoft.Test.OData.Services.AstoriaDefaultService.Login"));
            updatable.SetValue(resourceLookup["Login8"], "Username", "9");
            updatable.SetValue(resourceLookup["Login8"], "CustomerId", 62);


            resourceLookup.Add("Login9", updatable.CreateResource("Login", "Microsoft.Test.OData.Services.AstoriaDefaultService.Login"));
            updatable.SetValue(resourceLookup["Login9"], "Username", "10");
            updatable.SetValue(resourceLookup["Login9"], "CustomerId", 80);

        }

        private static void PopulateRSAToken(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {

            resourceLookup.Add("RSAToken0", updatable.CreateResource("RSAToken", "Microsoft.Test.OData.Services.AstoriaDefaultService.RSAToken"));
            updatable.SetValue(resourceLookup["RSAToken0"], "Serial", "1");
            updatable.SetValue(resourceLookup["RSAToken0"], "Issued", new System.DateTime(634829455350446194, System.DateTimeKind.Unspecified));


            resourceLookup.Add("RSAToken1", updatable.CreateResource("RSAToken", "Microsoft.Test.OData.Services.AstoriaDefaultService.RSAToken"));
            updatable.SetValue(resourceLookup["RSAToken1"], "Serial", "2");
            updatable.SetValue(resourceLookup["RSAToken1"], "Issued", new System.DateTime(503076552589558344, System.DateTimeKind.Local));


            resourceLookup.Add("RSAToken2", updatable.CreateResource("RSAToken", "Microsoft.Test.OData.Services.AstoriaDefaultService.RSAToken"));
            updatable.SetValue(resourceLookup["RSAToken2"], "Serial", "3");
            updatable.SetValue(resourceLookup["RSAToken2"], "Issued", new System.DateTime(632546050456942932, System.DateTimeKind.Unspecified));


            resourceLookup.Add("RSAToken3", updatable.CreateResource("RSAToken", "Microsoft.Test.OData.Services.AstoriaDefaultService.RSAToken"));
            updatable.SetValue(resourceLookup["RSAToken3"], "Serial", "4");
            updatable.SetValue(resourceLookup["RSAToken3"], "Issued", new System.DateTime(2335047837124116800, System.DateTimeKind.Local));


            resourceLookup.Add("RSAToken4", updatable.CreateResource("RSAToken", "Microsoft.Test.OData.Services.AstoriaDefaultService.RSAToken"));
            updatable.SetValue(resourceLookup["RSAToken4"], "Serial", "5");
            updatable.SetValue(resourceLookup["RSAToken4"], "Issued", new System.DateTime(635197702422280816, System.DateTimeKind.Unspecified));


            resourceLookup.Add("RSAToken5", updatable.CreateResource("RSAToken", "Microsoft.Test.OData.Services.AstoriaDefaultService.RSAToken"));
            updatable.SetValue(resourceLookup["RSAToken5"], "Serial", "6");
            updatable.SetValue(resourceLookup["RSAToken5"], "Issued", new System.DateTime(706293789283183600, System.DateTimeKind.Unspecified));


            resourceLookup.Add("RSAToken6", updatable.CreateResource("RSAToken", "Microsoft.Test.OData.Services.AstoriaDefaultService.RSAToken"));
            updatable.SetValue(resourceLookup["RSAToken6"], "Serial", "7");
            updatable.SetValue(resourceLookup["RSAToken6"], "Issued", new System.DateTime(634874269765529588, System.DateTimeKind.Unspecified));


            resourceLookup.Add("RSAToken7", updatable.CreateResource("RSAToken", "Microsoft.Test.OData.Services.AstoriaDefaultService.RSAToken"));
            updatable.SetValue(resourceLookup["RSAToken7"], "Serial", "8");
            updatable.SetValue(resourceLookup["RSAToken7"], "Issued", new System.DateTime(0, System.DateTimeKind.Unspecified));


            resourceLookup.Add("RSAToken8", updatable.CreateResource("RSAToken", "Microsoft.Test.OData.Services.AstoriaDefaultService.RSAToken"));
            updatable.SetValue(resourceLookup["RSAToken8"], "Serial", "9");
            updatable.SetValue(resourceLookup["RSAToken8"], "Issued", new System.DateTime(635822257278775599, System.DateTimeKind.Unspecified));


            resourceLookup.Add("RSAToken9", updatable.CreateResource("RSAToken", "Microsoft.Test.OData.Services.AstoriaDefaultService.RSAToken"));
            updatable.SetValue(resourceLookup["RSAToken9"], "Serial", "10");
            updatable.SetValue(resourceLookup["RSAToken9"], "Issued", new System.DateTime(634612506316814616, System.DateTimeKind.Unspecified));

        }

        private static void PopulatePageView(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {

            resourceLookup.Add("PageView0", updatable.CreateResource("PageView", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductPageView"));
            updatable.SetValue(resourceLookup["PageView0"], "PageViewId", -10);
            updatable.SetValue(resourceLookup["PageView0"], "Username", "珱び畚ボぴマせёミソ");
            updatable.SetValue(resourceLookup["PageView0"], "Viewed", new System.DateTimeOffset(new System.DateTime(0, System.DateTimeKind.Unspecified), new System.TimeSpan(0)));
            updatable.SetValue(resourceLookup["PageView0"], "TimeSpentOnPage", new System.TimeSpan(-9223372036854775808));
            updatable.SetValue(resourceLookup["PageView0"], "PageUrl", "マ縷ぴべｚぴびマゼタゾグそチべ黑ダゾｚЯせをぼマポんんあぼん珱ａびゾひダハマﾝ黑マゾソぜマんﾈソゾタミ暦弌暦ポグボゾダボ畚ぜソそマチべボゼポん珱ゾёァバ");
            updatable.SetValue(resourceLookup["PageView0"], "ProductId", -661313570);
            updatable.SetValue(resourceLookup["PageView0"], "ConcurrencyToken", "peohxvziohepefjoogexbxfulemllbfamsmqkxvqtctoßtnntzcßvtmuthyudkpzeeegvurfn");


            resourceLookup.Add("PageView1", updatable.CreateResource("PageView", "Microsoft.Test.OData.Services.AstoriaDefaultService.PageView"));
            updatable.SetValue(resourceLookup["PageView1"], "PageViewId", -9);
            updatable.SetValue(resourceLookup["PageView1"], "Username", "sdppimfqojrgrlmakbmrdlslzjivhaaebqezkaye");
            updatable.SetValue(resourceLookup["PageView1"], "Viewed", new System.DateTimeOffset(new System.DateTime(3155378975999999999, System.DateTimeKind.Unspecified), new System.TimeSpan(0)));
            updatable.SetValue(resourceLookup["PageView1"], "TimeSpentOnPage", new System.TimeSpan(-20714019215549));
            updatable.SetValue(resourceLookup["PageView1"], "PageUrl", "exozulicliqpkjdijqoejnlkdlqlizhgdmulvavrmujhfdnnkffjjoik");


            resourceLookup.Add("PageView2", updatable.CreateResource("PageView", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductPageView"));
            updatable.SetValue(resourceLookup["PageView2"], "PageViewId", -8);
            updatable.SetValue(resourceLookup["PageView2"], "Username", "");
            updatable.SetValue(resourceLookup["PageView2"], "Viewed", new System.DateTimeOffset(new System.DateTime(635065154115665324, System.DateTimeKind.Unspecified), new System.TimeSpan(-276600000000)));
            updatable.SetValue(resourceLookup["PageView2"], "TimeSpentOnPage", new System.TimeSpan(-7806705063807));
            updatable.SetValue(resourceLookup["PageView2"], "PageUrl", "kdqßeqpmßdjoedihqsgzlße");
            updatable.SetValue(resourceLookup["PageView2"], "ProductId", 378);
            updatable.SetValue(resourceLookup["PageView2"], "ConcurrencyToken", null);


            resourceLookup.Add("PageView3", updatable.CreateResource("PageView", "Microsoft.Test.OData.Services.AstoriaDefaultService.PageView"));
            updatable.SetValue(resourceLookup["PageView3"], "PageViewId", -7);
            updatable.SetValue(resourceLookup["PageView3"], "Username", null);
            updatable.SetValue(resourceLookup["PageView3"], "Viewed", new System.DateTimeOffset(new System.DateTime(634890040689875500, System.DateTimeKind.Unspecified), new System.TimeSpan(-288000000000)));
            updatable.SetValue(resourceLookup["PageView3"], "TimeSpentOnPage", new System.TimeSpan(9223372036854775807));
            updatable.SetValue(resourceLookup["PageView3"], "PageUrl", "gcvxypuinhtbovkyceojyptrippdbsnjtpoox");


            resourceLookup.Add("PageView4", updatable.CreateResource("PageView", "Microsoft.Test.OData.Services.AstoriaDefaultService.PageView"));
            updatable.SetValue(resourceLookup["PageView4"], "PageViewId", -6);
            updatable.SetValue(resourceLookup["PageView4"], "Username", "itideuecujovruvleebrbbcxsspvtqptboorftbncyssmgkissvuutnqtsymcfkssfqnsssrnoltylssu" +
                    "dsyjyqanxy");
            updatable.SetValue(resourceLookup["PageView4"], "Viewed", new System.DateTimeOffset(new System.DateTime(0, System.DateTimeKind.Unspecified), new System.TimeSpan(0)));
            updatable.SetValue(resourceLookup["PageView4"], "TimeSpentOnPage", new System.TimeSpan(-8474227957562));
            updatable.SetValue(resourceLookup["PageView4"], "PageUrl", "ifnfßqmjjsreyessskuqvjxsstusmhdofrbsshqcsstczlbfyußiylßqbsmdhvmdioufhayssseslkhzs" +
                    "sqqxaskmvos");


            resourceLookup.Add("PageView5", updatable.CreateResource("PageView", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductPageView"));
            updatable.SetValue(resourceLookup["PageView5"], "PageViewId", -5);
            updatable.SetValue(resourceLookup["PageView5"], "Username", "qljviysmqrpaf");
            updatable.SetValue(resourceLookup["PageView5"], "Viewed", new System.DateTimeOffset(new System.DateTime(634884013562978192, System.DateTimeKind.Unspecified), new System.TimeSpan(363600000000)));
            updatable.SetValue(resourceLookup["PageView5"], "TimeSpentOnPage", new System.TimeSpan(0));
            updatable.SetValue(resourceLookup["PageView5"], "PageUrl", "チダソグ縷ボゾグぼほ弌ポチ歹ほёЯソミを亜ミ畚ほ匚まチポゾ九");
            updatable.SetValue(resourceLookup["PageView5"], "ProductId", -807373440);
            updatable.SetValue(resourceLookup["PageView5"], "ConcurrencyToken", "racduextfkkejytrmvrbppexymjpijmsmquremß");


            resourceLookup.Add("PageView6", updatable.CreateResource("PageView", "Microsoft.Test.OData.Services.AstoriaDefaultService.PageView"));
            updatable.SetValue(resourceLookup["PageView6"], "PageViewId", -4);
            updatable.SetValue(resourceLookup["PageView6"], "Username", "ssuovuuxaouytejmxufpssssdrjhftßgsstobqßmyjpucejnkttitgpßrmusoskxexsbjt");
            updatable.SetValue(resourceLookup["PageView6"], "Viewed", new System.DateTimeOffset(new System.DateTime(634958117802408440, System.DateTimeKind.Unspecified), new System.TimeSpan(-504000000000)));
            updatable.SetValue(resourceLookup["PageView6"], "TimeSpentOnPage", new System.TimeSpan(90138131337590));
            updatable.SetValue(resourceLookup["PageView6"], "PageUrl", "qmqczgskqvdguzsshgborudpshudvtvuassdgmruqcvnopstyedmqzckdalmljpvzjghbkgupgjjdrkop" +
                    "agtkfuakdzgeofb");


            resourceLookup.Add("PageView7", updatable.CreateResource("PageView", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductPageView"));
            updatable.SetValue(resourceLookup["PageView7"], "PageViewId", -3);
            updatable.SetValue(resourceLookup["PageView7"], "Username", "ysezssyqrvqifmdzbsayuxyesslrmzdbxlhgpetpaixozbhgxd");
            updatable.SetValue(resourceLookup["PageView7"], "Viewed", new System.DateTimeOffset(new System.DateTime(272266420241479976, System.DateTimeKind.Unspecified), new System.TimeSpan(493200000000)));
            updatable.SetValue(resourceLookup["PageView7"], "TimeSpentOnPage", new System.TimeSpan(-9223372036854775808));
            updatable.SetValue(resourceLookup["PageView7"], "PageUrl", "dfrhntnyurvjiasyqyvmouclcehmqqmjnorsorfhshqml");
            updatable.SetValue(resourceLookup["PageView7"], "ProductId", 1881032792);
            updatable.SetValue(resourceLookup["PageView7"], "ConcurrencyToken", "mdjeuulgeckohuydauynjusorzpezhxqkqevcrymtarobhosiooyekdslfgblkhpftqstiadxhuj");


            resourceLookup.Add("PageView8", updatable.CreateResource("PageView", "Microsoft.Test.OData.Services.AstoriaDefaultService.PageView"));
            updatable.SetValue(resourceLookup["PageView8"], "PageViewId", -2);
            updatable.SetValue(resourceLookup["PageView8"], "Username", null);
            updatable.SetValue(resourceLookup["PageView8"], "Viewed", new System.DateTimeOffset(new System.DateTime(631990133830009951, System.DateTimeKind.Unspecified), new System.TimeSpan(-436800000000)));
            updatable.SetValue(resourceLookup["PageView8"], "TimeSpentOnPage", new System.TimeSpan(5944435062742720512));
            updatable.SetValue(resourceLookup["PageView8"], "PageUrl", "jnxxxvzlbrbrxssßszsbciebßbih");


            resourceLookup.Add("PageView9", updatable.CreateResource("PageView", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductPageView"));
            updatable.SetValue(resourceLookup["PageView9"], "PageViewId", -1);
            updatable.SetValue(resourceLookup["PageView9"], "Username", "珱チマチミﾈ九ぞぞａ暦タ珱をバびミ");
            updatable.SetValue(resourceLookup["PageView9"], "Viewed", new System.DateTimeOffset(new System.DateTime(3155378975999999999, System.DateTimeKind.Unspecified), new System.TimeSpan(0)));
            updatable.SetValue(resourceLookup["PageView9"], "TimeSpentOnPage", new System.TimeSpan(-15823440477000));
            updatable.SetValue(resourceLookup["PageView9"], "PageUrl", "agffmessdzaea");
            updatable.SetValue(resourceLookup["PageView9"], "ProductId", -2119);
            updatable.SetValue(resourceLookup["PageView9"], "ConcurrencyToken", "ゼぜゼぼ畚ァチぜた黑ぜａクソミボソ欲ボ畚歹ほａぽチびんソﾝボゾほ畚ゼマａ黑ёソびゾ畚ぞЯａぞポａせяタｚ縷裹ぜひびたママёそぜタゼ珱あｦ匚弌ミゼゼソグﾈぜ黑ァゼタ" +
                    "ググｦぜダクｦまタ九亜ァ九た");

        }

        private static void PopulateLastLogin(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {

            resourceLookup.Add("LastLogin0", updatable.CreateResource("LastLogin", "Microsoft.Test.OData.Services.AstoriaDefaultService.LastLogin"));
            updatable.SetValue(resourceLookup["LastLogin0"], "Username", "1");
            updatable.SetValue(resourceLookup["LastLogin0"], "LoggedIn", new System.DateTime(0, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["LastLogin0"], "LoggedOut", new System.DateTime(634034884311358130, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["LastLogin0"], "Duration", new System.TimeSpan(-244038308126984));


            resourceLookup.Add("LastLogin1", updatable.CreateResource("LastLogin", "Microsoft.Test.OData.Services.AstoriaDefaultService.LastLogin"));
            updatable.SetValue(resourceLookup["LastLogin1"], "Username", "2");
            updatable.SetValue(resourceLookup["LastLogin1"], "LoggedIn", new System.DateTime(634951495921010498, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["LastLogin1"], "LoggedOut", null);
            updatable.SetValue(resourceLookup["LastLogin1"], "Duration", new System.TimeSpan(-5096500114460954624));


            resourceLookup.Add("LastLogin2", updatable.CreateResource("LastLogin", "Microsoft.Test.OData.Services.AstoriaDefaultService.LastLogin"));
            updatable.SetValue(resourceLookup["LastLogin2"], "Username", "3");
            updatable.SetValue(resourceLookup["LastLogin2"], "LoggedIn", new System.DateTime(635111659956332657, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["LastLogin2"], "LoggedOut", new System.DateTime(1700754018601044628, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["LastLogin2"], "Duration", new System.TimeSpan(-9223372036854775808));


            resourceLookup.Add("LastLogin3", updatable.CreateResource("LastLogin", "Microsoft.Test.OData.Services.AstoriaDefaultService.LastLogin"));
            updatable.SetValue(resourceLookup["LastLogin3"], "Username", "4");
            updatable.SetValue(resourceLookup["LastLogin3"], "LoggedIn", new System.DateTime(410798951752821408, System.DateTimeKind.Local));
            updatable.SetValue(resourceLookup["LastLogin3"], "LoggedOut", new System.DateTime(0, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["LastLogin3"], "Duration", new System.TimeSpan(-295696007689196));


            resourceLookup.Add("LastLogin4", updatable.CreateResource("LastLogin", "Microsoft.Test.OData.Services.AstoriaDefaultService.LastLogin"));
            updatable.SetValue(resourceLookup["LastLogin4"], "Username", "5");
            updatable.SetValue(resourceLookup["LastLogin4"], "LoggedIn", new System.DateTime(634873725106444196, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["LastLogin4"], "LoggedOut", new System.DateTime(3155378975999999999, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["LastLogin4"], "Duration", new System.TimeSpan(9223372036854775807));


            resourceLookup.Add("LastLogin5", updatable.CreateResource("LastLogin", "Microsoft.Test.OData.Services.AstoriaDefaultService.LastLogin"));
            updatable.SetValue(resourceLookup["LastLogin5"], "Username", "6");
            updatable.SetValue(resourceLookup["LastLogin5"], "LoggedIn", new System.DateTime(1103753231112706752, System.DateTimeKind.Local));
            updatable.SetValue(resourceLookup["LastLogin5"], "LoggedOut", new System.DateTime(255008689497959457, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["LastLogin5"], "Duration", new System.TimeSpan(0));


            resourceLookup.Add("LastLogin6", updatable.CreateResource("LastLogin", "Microsoft.Test.OData.Services.AstoriaDefaultService.LastLogin"));
            updatable.SetValue(resourceLookup["LastLogin6"], "Username", "7");
            updatable.SetValue(resourceLookup["LastLogin6"], "LoggedIn", new System.DateTime(3155378975999999999, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["LastLogin6"], "LoggedOut", new System.DateTime(634890040690642630, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["LastLogin6"], "Duration", new System.TimeSpan(-9223372036854775808));


            resourceLookup.Add("LastLogin7", updatable.CreateResource("LastLogin", "Microsoft.Test.OData.Services.AstoriaDefaultService.LastLogin"));
            updatable.SetValue(resourceLookup["LastLogin7"], "Username", "8");
            updatable.SetValue(resourceLookup["LastLogin7"], "LoggedIn", new System.DateTime(635137351800596102, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["LastLogin7"], "LoggedOut", new System.DateTime(634682863448482541, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["LastLogin7"], "Duration", new System.TimeSpan(-37196077877655));


            resourceLookup.Add("LastLogin8", updatable.CreateResource("LastLogin", "Microsoft.Test.OData.Services.AstoriaDefaultService.LastLogin"));
            updatable.SetValue(resourceLookup["LastLogin8"], "Username", "9");
            updatable.SetValue(resourceLookup["LastLogin8"], "LoggedIn", new System.DateTime(636671279953842206, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["LastLogin8"], "LoggedOut", null);
            updatable.SetValue(resourceLookup["LastLogin8"], "Duration", new System.TimeSpan(-16960610403372));


            resourceLookup.Add("LastLogin9", updatable.CreateResource("LastLogin", "Microsoft.Test.OData.Services.AstoriaDefaultService.LastLogin"));
            updatable.SetValue(resourceLookup["LastLogin9"], "Username", "10");
            updatable.SetValue(resourceLookup["LastLogin9"], "LoggedIn", new System.DateTime(634920921517326634, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["LastLogin9"], "LoggedOut", new System.DateTime(0, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["LastLogin9"], "Duration", new System.TimeSpan(-292865722236882));

        }

        private static void PopulateMessage(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {

            resourceLookup.Add("Message0", updatable.CreateResource("Message", "Microsoft.Test.OData.Services.AstoriaDefaultService.Message"));
            updatable.SetValue(resourceLookup["Message0"], "MessageId", -10);
            updatable.SetValue(resourceLookup["Message0"], "FromUsername", "1");
            updatable.SetValue(resourceLookup["Message0"], "ToUsername", "xlodhxzzusxecbzptxlfxprneoxkn");
            updatable.SetValue(resourceLookup["Message0"], "Sent", new System.DateTimeOffset(new System.DateTime(634687198998374632, System.DateTimeKind.Unspecified), new System.TimeSpan(-479400000000)));
            updatable.SetValue(resourceLookup["Message0"], "Subject", "xbjcvnsugafßrzhcvmbdßlhboßzhyysgfnmsclvlkuuprqccmifkcfßgxbivrfykgsssijrßfttvxgunm" +
                    "tryvpdoßpuyehßxo");
            updatable.SetValue(resourceLookup["Message0"], "Body", "yovuizrklozepneajiveurlbtyyrxqmplvnnuarmmpkjuuhtxuquuuvbnpeueznumfmta");
            updatable.SetValue(resourceLookup["Message0"], "IsRead", true);


            resourceLookup.Add("Message1", updatable.CreateResource("Message", "Microsoft.Test.OData.Services.AstoriaDefaultService.Message"));
            updatable.SetValue(resourceLookup["Message1"], "MessageId", -9);
            updatable.SetValue(resourceLookup["Message1"], "FromUsername", "2");
            updatable.SetValue(resourceLookup["Message1"], "ToUsername", "dusscvkußguohlivjnuynjgacopbkumdluynieha");
            updatable.SetValue(resourceLookup["Message1"], "Sent", new System.DateTimeOffset(new System.DateTime(634578622312325259, System.DateTimeKind.Unspecified), new System.TimeSpan(31800000000)));
            updatable.SetValue(resourceLookup["Message1"], "Subject", "びグﾝﾝｚミミぞほぺをぴ欲ゾボほハダミクぴ暦縷ぜｦ畚チびぺハ裹ゾﾈタせそひ縷ハァァほミ匚たほボｚゼポゼ亜ぺソ弌グゾ縷ёせたチ黑ポん暦ぺをゼタあマｚゼёｦせそｚミほ" +
                    "ボ亜チびたぽタミミボぽ珱タべ亜ァせソ");
            updatable.SetValue(resourceLookup["Message1"], "Body", "ypsvxjxfhssfxmvglbnsnszvxkbdqßrpsziyakgjozkcgnrsssßqdvg");
            updatable.SetValue(resourceLookup["Message1"], "IsRead", false);


            resourceLookup.Add("Message2", updatable.CreateResource("Message", "Microsoft.Test.OData.Services.AstoriaDefaultService.Message"));
            updatable.SetValue(resourceLookup["Message2"], "MessageId", -8);
            updatable.SetValue(resourceLookup["Message2"], "FromUsername", "3");
            updatable.SetValue(resourceLookup["Message2"], "ToUsername", "uubzvsegroaesohvasssybrbßaxihfsszufhiexqxaisstp");
            updatable.SetValue(resourceLookup["Message2"], "Sent", new System.DateTimeOffset(new System.DateTime(1070686787920348535, System.DateTimeKind.Unspecified), new System.TimeSpan(128400000000)));
            updatable.SetValue(resourceLookup["Message2"], "Subject", "opczßqrasccugafßjxssvdzpg");
            updatable.SetValue(resourceLookup["Message2"], "Body", "tqogtosslpsyj");
            updatable.SetValue(resourceLookup["Message2"], "IsRead", false);


            resourceLookup.Add("Message3", updatable.CreateResource("Message", "Microsoft.Test.OData.Services.AstoriaDefaultService.Message"));
            updatable.SetValue(resourceLookup["Message3"], "MessageId", -7);
            updatable.SetValue(resourceLookup["Message3"], "FromUsername", "4");
            updatable.SetValue(resourceLookup["Message3"], "ToUsername", "tcjolisfklfejflxflhlßihß");
            updatable.SetValue(resourceLookup["Message3"], "Sent", new System.DateTimeOffset(new System.DateTime(0, System.DateTimeKind.Unspecified), new System.TimeSpan(0)));
            updatable.SetValue(resourceLookup["Message3"], "Subject", "nuatkfsskyzevtgyghdxdhoßgßcqxkieuonzgdgssanjjpgsdtmqqukfhkusubrißuxdrbkmief");
            updatable.SetValue(resourceLookup["Message3"], "Body", "ゼﾝまﾝ裹ァ暦ソ裹ァ珱びソひチチ九ァソゼボ九せяあをﾈチハ歹ボハゼ九匚ミソべ匚九ぴんｚａ欲Яﾈグゾソチタぺチあポ裹ぽａハクほ畚ぁミぽ匚ミグ畚");
            updatable.SetValue(resourceLookup["Message3"], "IsRead", true);


            resourceLookup.Add("Message4", updatable.CreateResource("Message", "Microsoft.Test.OData.Services.AstoriaDefaultService.Message"));
            updatable.SetValue(resourceLookup["Message4"], "MessageId", -6);
            updatable.SetValue(resourceLookup["Message4"], "FromUsername", "5");
            updatable.SetValue(resourceLookup["Message4"], "ToUsername", null);
            updatable.SetValue(resourceLookup["Message4"], "Sent", new System.DateTimeOffset(new System.DateTime(1154397753187821112, System.DateTimeKind.Unspecified), new System.TimeSpan(19800000000)));
            updatable.SetValue(resourceLookup["Message4"], "Subject", "xdaubltmubssbgpvxrfsssfttyzmonjrjddssmßßnuiisshyheiacspvzlninudrhboivszhexyiupxhh" +
                    "xlykig");
            updatable.SetValue(resourceLookup["Message4"], "Body", "uhkjvfltzxdisossshxmrgqustshcdxjebg");
            updatable.SetValue(resourceLookup["Message4"], "IsRead", true);


            resourceLookup.Add("Message5", updatable.CreateResource("Message", "Microsoft.Test.OData.Services.AstoriaDefaultService.Message"));
            updatable.SetValue(resourceLookup["Message5"], "MessageId", -5);
            updatable.SetValue(resourceLookup["Message5"], "FromUsername", "6");
            updatable.SetValue(resourceLookup["Message5"], "ToUsername", "gznnquucnxijpkgixrgurbjbdyapfpyluadjttjtpbyujmrlgccklgzulgfsubxyyncnu");
            updatable.SetValue(resourceLookup["Message5"], "Sent", new System.DateTimeOffset(new System.DateTime(635055166271593417, System.DateTimeKind.Unspecified), new System.TimeSpan(295200000000)));
            updatable.SetValue(resourceLookup["Message5"], "Subject", "ぺタぽぜゼゾﾈ欲ёぜ黑ゼソマボゼをﾝほ歹ませんソ裹ぞびｦたソｚぼハチタボａ弌チソボソチせﾈｚポバｦ暦べぼёｚソたべ欲べぽをяマチひポ弌黑びﾝソゾソ匚べ珱");
            updatable.SetValue(resourceLookup["Message5"], "Body", "lnßgcscrihjopdupußzfutjßgsvdtqqßhdvtagglkoxvnhzuqqinguutuaamysszkuktgljpjqkyazpjß" +
                    "vrqomerblepagv");
            updatable.SetValue(resourceLookup["Message5"], "IsRead", false);


            resourceLookup.Add("Message6", updatable.CreateResource("Message", "Microsoft.Test.OData.Services.AstoriaDefaultService.Message"));
            updatable.SetValue(resourceLookup["Message6"], "MessageId", -4);
            updatable.SetValue(resourceLookup["Message6"], "FromUsername", "7");
            updatable.SetValue(resourceLookup["Message6"], "ToUsername", "ﾈゼソハポ珱黑ひソゼｚёёぺんぁひたポァａ歹あマをぴたゼぞびソ縷ポタｚ暦ａひミをクゼァゼまソ弌ﾝ亜ァソяソゾ弌たァ匚をソマゾёま黑ぁゼタまタそЯ");
            updatable.SetValue(resourceLookup["Message6"], "Sent", new System.DateTimeOffset(new System.DateTime(634704821343659427, System.DateTimeKind.Unspecified), new System.TimeSpan(276000000000)));
            updatable.SetValue(resourceLookup["Message6"], "Subject", "trjjurtjuvcnvhekbecrcbjnikdpqgjemucmknbtkeyousiokbuuojhndvgqjuttjbe");
            updatable.SetValue(resourceLookup["Message6"], "Body", null);
            updatable.SetValue(resourceLookup["Message6"], "IsRead", false);


            resourceLookup.Add("Message7", updatable.CreateResource("Message", "Microsoft.Test.OData.Services.AstoriaDefaultService.Message"));
            updatable.SetValue(resourceLookup["Message7"], "MessageId", -3);
            updatable.SetValue(resourceLookup["Message7"], "FromUsername", "8");
            updatable.SetValue(resourceLookup["Message7"], "ToUsername", "ァぺ裹ぺｚひをほタ亜チボボゼァクポびソミソほぼﾈソゼボたをｦあひёァぺ歹まミそグゼボボゾぜひそ縷べ");
            updatable.SetValue(resourceLookup["Message7"], "Sent", new System.DateTimeOffset(new System.DateTime(636541007820587124, System.DateTimeKind.Unspecified), new System.TimeSpan(109200000000)));
            updatable.SetValue(resourceLookup["Message7"], "Subject", "タひｚチマゼバをぴゾせｚぁせん歹ボ亜畚んま九ａ暦ぜ畚グ欲をぞ畚クﾝハ歹ほマぁ弌マチ欲マミゼ黑たマ縷ぴゾべぁ");
            updatable.SetValue(resourceLookup["Message7"], "Body", "たソ欲я匚Яぁボミｦソほあひチﾈび亜ソёべゼび");
            updatable.SetValue(resourceLookup["Message7"], "IsRead", false);


            resourceLookup.Add("Message8", updatable.CreateResource("Message", "Microsoft.Test.OData.Services.AstoriaDefaultService.Message"));
            updatable.SetValue(resourceLookup["Message8"], "MessageId", -2);
            updatable.SetValue(resourceLookup["Message8"], "FromUsername", "9");
            updatable.SetValue(resourceLookup["Message8"], "ToUsername", "fßvhhrduxlozzfßotjts");
            updatable.SetValue(resourceLookup["Message8"], "Sent", new System.DateTimeOffset(new System.DateTime(634693616613661510, System.DateTimeKind.Unspecified), new System.TimeSpan(-168600000000)));
            updatable.SetValue(resourceLookup["Message8"], "Subject", "マ畚チぺをポ匚歹クポミｚ");
            updatable.SetValue(resourceLookup["Message8"], "Body", "sidljmxdskgergßfihjaheskssnhacrdesuqbudsbafmyfsuasj");
            updatable.SetValue(resourceLookup["Message8"], "IsRead", true);


            resourceLookup.Add("Message9", updatable.CreateResource("Message", "Microsoft.Test.OData.Services.AstoriaDefaultService.Message"));
            updatable.SetValue(resourceLookup["Message9"], "MessageId", -1);
            updatable.SetValue(resourceLookup["Message9"], "FromUsername", "10");
            updatable.SetValue(resourceLookup["Message9"], "ToUsername", "欲ァミぼ亜まポﾈ珱ポソソァバマぴ九あ九歹裹ﾈ歹ｦべ九クёポんボせび畚ボべソ裹バポをたまチポ九ゾァﾝяせクゾ縷ポ珱");
            updatable.SetValue(resourceLookup["Message9"], "Sent", new System.DateTimeOffset(new System.DateTime(634834223171539216, System.DateTimeKind.Unspecified), new System.TimeSpan(489600000000)));
            updatable.SetValue(resourceLookup["Message9"], "Subject", "lßmtxkimtsdfkdaeqcdpfbussypt");
            updatable.SetValue(resourceLookup["Message9"], "Body", "まソЯグゾをほ裹ゼァａひほソハ九黑チポを九弌ﾝぽべ暦яﾈ畚ァ歹黑ｚミяﾝぼボチァﾈグひｦまバソぼぽ歹欲ぞひソ");
            updatable.SetValue(resourceLookup["Message9"], "IsRead", false);

        }

        private static void PopulateMessageAttachment(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {

            resourceLookup.Add("MessageAttachment0", updatable.CreateResource("MessageAttachment", "Microsoft.Test.OData.Services.AstoriaDefaultService.MessageAttachment"));
            updatable.SetValue(resourceLookup["MessageAttachment0"], "AttachmentId", new System.Guid("1126a28b-a4af-4bbd-bf0a-2b2c22635565"));
            updatable.SetValue(resourceLookup["MessageAttachment0"], "Attachment", new byte[] {
                        ((byte)(40)),
                        ((byte)(125)),
                        ((byte)(164)),
                        ((byte)(202)),
                        ((byte)(67)),
                        ((byte)(14)),
                        ((byte)(248)),
                        ((byte)(119)),
                        ((byte)(177)),
                        ((byte)(53)),
                        ((byte)(87)),
                        ((byte)(46)),
                        ((byte)(17)),
                        ((byte)(246)),
                        ((byte)(39)),
                        ((byte)(205)),
                        ((byte)(108)),
                        ((byte)(125)),
                        ((byte)(56)),
                        ((byte)(199)),
                        ((byte)(11)),
                        ((byte)(188)),
                        ((byte)(7)),
                        ((byte)(140)),
                        ((byte)(197)),
                        ((byte)(145)),
                        ((byte)(141)),
                        ((byte)(8)),
                        ((byte)(114)),
                        ((byte)(196)),
                        ((byte)(130)),
                        ((byte)(29)),
                        ((byte)(248)),
                        ((byte)(139)),
                        ((byte)(137)),
                        ((byte)(106)),
                        ((byte)(119)),
                        ((byte)(158)),
                        ((byte)(156)),
                        ((byte)(2)),
                        ((byte)(147)),
                        ((byte)(252)),
                        ((byte)(130)),
                        ((byte)(119))});


            resourceLookup.Add("MessageAttachment1", updatable.CreateResource("MessageAttachment", "Microsoft.Test.OData.Services.AstoriaDefaultService.MessageAttachment"));
            updatable.SetValue(resourceLookup["MessageAttachment1"], "AttachmentId", new System.Guid("5cb091a6-bbb4-43b4-ac12-d7ae631edcb0"));
            updatable.SetValue(resourceLookup["MessageAttachment1"], "Attachment", null);


            resourceLookup.Add("MessageAttachment2", updatable.CreateResource("MessageAttachment", "Microsoft.Test.OData.Services.AstoriaDefaultService.MessageAttachment"));
            updatable.SetValue(resourceLookup["MessageAttachment2"], "AttachmentId", new System.Guid("05ac36a6-e867-4580-8a31-c1804ef249a2"));
            updatable.SetValue(resourceLookup["MessageAttachment2"], "Attachment", new byte[] {
                        ((byte)(112)),
                        ((byte)(9)),
                        ((byte)(187)),
                        ((byte)(95)),
                        ((byte)(237)),
                        ((byte)(170)),
                        ((byte)(245)),
                        ((byte)(199)),
                        ((byte)(125)),
                        ((byte)(140)),
                        ((byte)(175)),
                        ((byte)(216)),
                        ((byte)(5)),
                        ((byte)(207)),
                        ((byte)(163)),
                        ((byte)(141)),
                        ((byte)(90)),
                        ((byte)(152)),
                        ((byte)(124)),
                        ((byte)(243)),
                        ((byte)(139)),
                        ((byte)(107)),
                        ((byte)(252)),
                        ((byte)(90)),
                        ((byte)(121)),
                        ((byte)(99)),
                        ((byte)(52)),
                        ((byte)(205)),
                        ((byte)(214)),
                        ((byte)(208)),
                        ((byte)(83)),
                        ((byte)(127)),
                        ((byte)(218)),
                        ((byte)(103)),
                        ((byte)(128)),
                        ((byte)(199)),
                        ((byte)(53)),
                        ((byte)(217)),
                        ((byte)(83)),
                        ((byte)(172)),
                        ((byte)(44)),
                        ((byte)(33)),
                        ((byte)(35)),
                        ((byte)(139)),
                        ((byte)(3)),
                        ((byte)(62)),
                        ((byte)(222)),
                        ((byte)(140)),
                        ((byte)(105)),
                        ((byte)(144)),
                        ((byte)(79)),
                        ((byte)(184)),
                        ((byte)(92)),
                        ((byte)(32)),
                        ((byte)(14)),
                        ((byte)(4)),
                        ((byte)(13)),
                        ((byte)(97)),
                        ((byte)(229)),
                        ((byte)(138)),
                        ((byte)(117)),
                        ((byte)(39)),
                        ((byte)(240)),
                        ((byte)(173)),
                        ((byte)(56)),
                        ((byte)(47)),
                        ((byte)(254)),
                        ((byte)(157))});


            resourceLookup.Add("MessageAttachment3", updatable.CreateResource("MessageAttachment", "Microsoft.Test.OData.Services.AstoriaDefaultService.MessageAttachment"));
            updatable.SetValue(resourceLookup["MessageAttachment3"], "AttachmentId", new System.Guid("2ccea377-d7b4-4d6e-b864-0e4b87b86bd9"));
            updatable.SetValue(resourceLookup["MessageAttachment3"], "Attachment", new byte[] {
                        ((byte)(57)),
                        ((byte)(37)),
                        ((byte)(149)),
                        ((byte)(243)),
                        ((byte)(98)),
                        ((byte)(34)),
                        ((byte)(193)),
                        ((byte)(251)),
                        ((byte)(79)),
                        ((byte)(13)),
                        ((byte)(241)),
                        ((byte)(33)),
                        ((byte)(104)),
                        ((byte)(78)),
                        ((byte)(59)),
                        ((byte)(233)),
                        ((byte)(192)),
                        ((byte)(141)),
                        ((byte)(122)),
                        ((byte)(78)),
                        ((byte)(40)),
                        ((byte)(118)),
                        ((byte)(92)),
                        ((byte)(233)),
                        ((byte)(53)),
                        ((byte)(98)),
                        ((byte)(73)),
                        ((byte)(174)),
                        ((byte)(253)),
                        ((byte)(123)),
                        ((byte)(253)),
                        ((byte)(115)),
                        ((byte)(249)),
                        ((byte)(55)),
                        ((byte)(25)),
                        ((byte)(88)),
                        ((byte)(82)),
                        ((byte)(65)),
                        ((byte)(231)),
                        ((byte)(162)),
                        ((byte)(106)),
                        ((byte)(26)),
                        ((byte)(94)),
                        ((byte)(233)),
                        ((byte)(250)),
                        ((byte)(22)),
                        ((byte)(165)),
                        ((byte)(112)),
                        ((byte)(251)),
                        ((byte)(40)),
                        ((byte)(88)),
                        ((byte)(254)),
                        ((byte)(26)),
                        ((byte)(55)),
                        ((byte)(189)),
                        ((byte)(194)),
                        ((byte)(200)),
                        ((byte)(171)),
                        ((byte)(190)),
                        ((byte)(0)),
                        ((byte)(216)),
                        ((byte)(18)),
                        ((byte)(254)),
                        ((byte)(211)),
                        ((byte)(16)),
                        ((byte)(125)),
                        ((byte)(40)),
                        ((byte)(49)),
                        ((byte)(52)),
                        ((byte)(227)),
                        ((byte)(150)),
                        ((byte)(127)),
                        ((byte)(166)),
                        ((byte)(216)),
                        ((byte)(228))});


            resourceLookup.Add("MessageAttachment4", updatable.CreateResource("MessageAttachment", "Microsoft.Test.OData.Services.AstoriaDefaultService.MessageAttachment"));
            updatable.SetValue(resourceLookup["MessageAttachment4"], "AttachmentId", new System.Guid("b0d769c1-ffbd-423a-8af0-dcd53a357d66"));
            updatable.SetValue(resourceLookup["MessageAttachment4"], "Attachment", new byte[] {
                        ((byte)(252)),
                        ((byte)(191)),
                        ((byte)(15)),
                        ((byte)(140)),
                        ((byte)(242)),
                        ((byte)(140)),
                        ((byte)(153)),
                        ((byte)(113)),
                        ((byte)(49)),
                        ((byte)(73)),
                        ((byte)(157)),
                        ((byte)(154)),
                        ((byte)(67)),
                        ((byte)(73)),
                        ((byte)(165)),
                        ((byte)(23)),
                        ((byte)(110)),
                        ((byte)(203)),
                        ((byte)(172)),
                        ((byte)(57)),
                        ((byte)(233)),
                        ((byte)(228)),
                        ((byte)(164)),
                        ((byte)(201)),
                        ((byte)(247)),
                        ((byte)(243)),
                        ((byte)(218)),
                        ((byte)(198)),
                        ((byte)(88)),
                        ((byte)(135)),
                        ((byte)(189)),
                        ((byte)(93)),
                        ((byte)(195)),
                        ((byte)(161)),
                        ((byte)(220)),
                        ((byte)(152)),
                        ((byte)(50)),
                        ((byte)(198)),
                        ((byte)(189)),
                        ((byte)(30)),
                        ((byte)(187)),
                        ((byte)(75)),
                        ((byte)(109)),
                        ((byte)(249)),
                        ((byte)(98)),
                        ((byte)(198)),
                        ((byte)(228)),
                        ((byte)(103)),
                        ((byte)(108)),
                        ((byte)(12)),
                        ((byte)(247)),
                        ((byte)(235)),
                        ((byte)(49)),
                        ((byte)(26)),
                        ((byte)(6))});


            resourceLookup.Add("MessageAttachment5", updatable.CreateResource("MessageAttachment", "Microsoft.Test.OData.Services.AstoriaDefaultService.MessageAttachment"));
            updatable.SetValue(resourceLookup["MessageAttachment5"], "AttachmentId", new System.Guid("4b7ab900-bf82-4857-ac02-470ffbeffe1d"));
            updatable.SetValue(resourceLookup["MessageAttachment5"], "Attachment", new byte[] {
                        ((byte)(163)),
                        ((byte)(159)),
                        ((byte)(172)),
                        ((byte)(55)),
                        ((byte)(80)),
                        ((byte)(124)),
                        ((byte)(248)),
                        ((byte)(175)),
                        ((byte)(124)),
                        ((byte)(170)),
                        ((byte)(137)),
                        ((byte)(26)),
                        ((byte)(175)),
                        ((byte)(124)),
                        ((byte)(0)),
                        ((byte)(218)),
                        ((byte)(254)),
                        ((byte)(187)),
                        ((byte)(132)),
                        ((byte)(138)),
                        ((byte)(55)),
                        ((byte)(90)),
                        ((byte)(51)),
                        ((byte)(253)),
                        ((byte)(237))});


            resourceLookup.Add("MessageAttachment6", updatable.CreateResource("MessageAttachment", "Microsoft.Test.OData.Services.AstoriaDefaultService.MessageAttachment"));
            updatable.SetValue(resourceLookup["MessageAttachment6"], "AttachmentId", new System.Guid("ebdcca48-a0dc-4331-bb98-64c92568c525"));
            updatable.SetValue(resourceLookup["MessageAttachment6"], "Attachment", new byte[] {
                        ((byte)(255)),
                        ((byte)(126)),
                        ((byte)(69)),
                        ((byte)(62)),
                        ((byte)(97)),
                        ((byte)(63)),
                        ((byte)(141)),
                        ((byte)(184))});


            resourceLookup.Add("MessageAttachment7", updatable.CreateResource("MessageAttachment", "Microsoft.Test.OData.Services.AstoriaDefaultService.MessageAttachment"));
            updatable.SetValue(resourceLookup["MessageAttachment7"], "AttachmentId", new System.Guid("66527e34-9d1f-45b2-ba8e-3e2306a9be78"));
            updatable.SetValue(resourceLookup["MessageAttachment7"], "Attachment", new byte[] {
                        ((byte)(96)),
                        ((byte)(143)),
                        ((byte)(74)),
                        ((byte)(207)),
                        ((byte)(73)),
                        ((byte)(119)),
                        ((byte)(52)),
                        ((byte)(20)),
                        ((byte)(158)),
                        ((byte)(136)),
                        ((byte)(18)),
                        ((byte)(29)),
                        ((byte)(42)),
                        ((byte)(241)),
                        ((byte)(94)),
                        ((byte)(232)),
                        ((byte)(230)),
                        ((byte)(6)),
                        ((byte)(81)),
                        ((byte)(75)),
                        ((byte)(177)),
                        ((byte)(221)),
                        ((byte)(1)),
                        ((byte)(120)),
                        ((byte)(192)),
                        ((byte)(137)),
                        ((byte)(223)),
                        ((byte)(147)),
                        ((byte)(233)),
                        ((byte)(124)),
                        ((byte)(171)),
                        ((byte)(217)),
                        ((byte)(23)),
                        ((byte)(134)),
                        ((byte)(239)),
                        ((byte)(75)),
                        ((byte)(242)),
                        ((byte)(153))});


            resourceLookup.Add("MessageAttachment8", updatable.CreateResource("MessageAttachment", "Microsoft.Test.OData.Services.AstoriaDefaultService.MessageAttachment"));
            updatable.SetValue(resourceLookup["MessageAttachment8"], "AttachmentId", new System.Guid("1609b623-c772-4ecd-90fc-dc3974b77475"));
            updatable.SetValue(resourceLookup["MessageAttachment8"], "Attachment", null);


            resourceLookup.Add("MessageAttachment9", updatable.CreateResource("MessageAttachment", "Microsoft.Test.OData.Services.AstoriaDefaultService.MessageAttachment"));
            updatable.SetValue(resourceLookup["MessageAttachment9"], "AttachmentId", new System.Guid("7e926398-4690-4a4b-b7c7-d1587441b90f"));
            updatable.SetValue(resourceLookup["MessageAttachment9"], "Attachment", new byte[] {
                        ((byte)(29)),
                        ((byte)(157)),
                        ((byte)(21)),
                        ((byte)(91)),
                        ((byte)(51)),
                        ((byte)(178)),
                        ((byte)(98)),
                        ((byte)(177)),
                        ((byte)(231)),
                        ((byte)(107)),
                        ((byte)(3)),
                        ((byte)(45)),
                        ((byte)(125)),
                        ((byte)(194)),
                        ((byte)(40)),
                        ((byte)(1)),
                        ((byte)(7)),
                        ((byte)(60)),
                        ((byte)(52))});
        }

        private static void PopulateOrder(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {

            resourceLookup.Add("Order0", updatable.CreateResource("Order", "Microsoft.Test.OData.Services.AstoriaDefaultService.Order"));
            updatable.SetValue(resourceLookup["Order0"], "OrderId", -10);
            updatable.SetValue(resourceLookup["Order0"], "CustomerId", 8212);
            updatable.SetValue(resourceLookup["Order0"], "Concurrency", null);


            resourceLookup.Add("Order1", updatable.CreateResource("Order", "Microsoft.Test.OData.Services.AstoriaDefaultService.Order"));
            updatable.SetValue(resourceLookup["Order1"], "OrderId", -9);
            updatable.SetValue(resourceLookup["Order1"], "CustomerId", 78);
            resourceLookup.Add("ConcurrencyInfo_5", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ConcurrencyInfo"));
            updatable.SetValue(resourceLookup["ConcurrencyInfo_5"], "Token", "muunxfmcubaihvgnzoojgecdztyipapnxahnuibukrveamumfuokuvbly");
            updatable.SetValue(resourceLookup["ConcurrencyInfo_5"], "QueriedDateTime", new System.DateTime(634646431705072026, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["Order1"], "Concurrency", resourceLookup["ConcurrencyInfo_5"]);


            resourceLookup.Add("Order2", updatable.CreateResource("Order", "Microsoft.Test.OData.Services.AstoriaDefaultService.Order"));
            updatable.SetValue(resourceLookup["Order2"], "OrderId", -8);
            updatable.SetValue(resourceLookup["Order2"], "CustomerId", null);
            resourceLookup.Add("ConcurrencyInfo_6", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ConcurrencyInfo"));
            updatable.SetValue(resourceLookup["ConcurrencyInfo_6"], "Token", "zjecuydplhxfzfphcfmoqlcitfxpvgqiiphyveopqieojxfspakzmoekbykuepturucfxrmbuxk");
            updatable.SetValue(resourceLookup["ConcurrencyInfo_6"], "QueriedDateTime", new System.DateTime(314858621982757172, System.DateTimeKind.Local));
            updatable.SetValue(resourceLookup["Order2"], "Concurrency", resourceLookup["ConcurrencyInfo_6"]);


            resourceLookup.Add("Order3", updatable.CreateResource("Order", "Microsoft.Test.OData.Services.AstoriaDefaultService.Order"));
            updatable.SetValue(resourceLookup["Order3"], "OrderId", -7);
            updatable.SetValue(resourceLookup["Order3"], "CustomerId", -9108);
            resourceLookup.Add("ConcurrencyInfo_7", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ConcurrencyInfo"));
            updatable.SetValue(resourceLookup["ConcurrencyInfo_7"], "Token", "ffmflxqosczkqjupsbmdyqoxikzcndibsetdvusfknrfpguiyyyaeuupuqcexhlkosrnpmsnjctgzu");
            updatable.SetValue(resourceLookup["ConcurrencyInfo_7"], "QueriedDateTime", new System.DateTime(0, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["Order3"], "Concurrency", resourceLookup["ConcurrencyInfo_7"]);


            resourceLookup.Add("Order4", updatable.CreateResource("Order", "Microsoft.Test.OData.Services.AstoriaDefaultService.Order"));
            updatable.SetValue(resourceLookup["Order4"], "OrderId", -6);
            updatable.SetValue(resourceLookup["Order4"], "CustomerId", -2147483648);
            resourceLookup.Add("ConcurrencyInfo_8", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ConcurrencyInfo"));
            updatable.SetValue(resourceLookup["ConcurrencyInfo_8"], "Token", "ohiizspnhdjdnhlduxjedcejtuyttbolme");
            updatable.SetValue(resourceLookup["ConcurrencyInfo_8"], "QueriedDateTime", new System.DateTime(634777556024250665, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["Order4"], "Concurrency", resourceLookup["ConcurrencyInfo_8"]);


            resourceLookup.Add("Order5", updatable.CreateResource("Order", "Microsoft.Test.OData.Services.AstoriaDefaultService.Order"));
            updatable.SetValue(resourceLookup["Order5"], "OrderId", -5);
            updatable.SetValue(resourceLookup["Order5"], "CustomerId", 74);
            resourceLookup.Add("ConcurrencyInfo_9", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ConcurrencyInfo"));
            updatable.SetValue(resourceLookup["ConcurrencyInfo_9"], "Token", "縷タ畚そべポせマぼボひミんせ欲ぽび欲ａぼボハミ縷ｚｚ");
            updatable.SetValue(resourceLookup["ConcurrencyInfo_9"], "QueriedDateTime", new System.DateTime(3155378975999999999, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["Order5"], "Concurrency", resourceLookup["ConcurrencyInfo_9"]);


            resourceLookup.Add("Order6", updatable.CreateResource("Order", "Microsoft.Test.OData.Services.AstoriaDefaultService.Order"));
            updatable.SetValue(resourceLookup["Order6"], "OrderId", -4);
            updatable.SetValue(resourceLookup["Order6"], "CustomerId", 82);
            resourceLookup.Add("ConcurrencyInfo_10", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ConcurrencyInfo"));
            updatable.SetValue(resourceLookup["ConcurrencyInfo_10"], "Token", null);
            updatable.SetValue(resourceLookup["ConcurrencyInfo_10"], "QueriedDateTime", new System.DateTime(634890040688842825, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["Order6"], "Concurrency", resourceLookup["ConcurrencyInfo_10"]);


            resourceLookup.Add("Order7", updatable.CreateResource("Order", "Microsoft.Test.OData.Services.AstoriaDefaultService.Order"));
            updatable.SetValue(resourceLookup["Order7"], "OrderId", -3);
            updatable.SetValue(resourceLookup["Order7"], "CustomerId", -4);
            resourceLookup.Add("ConcurrencyInfo_11", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ConcurrencyInfo"));
            updatable.SetValue(resourceLookup["ConcurrencyInfo_11"], "Token", "ilqeplnmpzfbvsdcdnuqbavhhfrvokfpyqdnvifbdehpinnzfqgcpmpepdpftsjupqcukqgbdyhopbfus" +
                    "smk");
            updatable.SetValue(resourceLookup["ConcurrencyInfo_11"], "QueriedDateTime", new System.DateTime(3155378975999999999, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["Order7"], "Concurrency", resourceLookup["ConcurrencyInfo_11"]);


            resourceLookup.Add("Order8", updatable.CreateResource("Order", "Microsoft.Test.OData.Services.AstoriaDefaultService.Order"));
            updatable.SetValue(resourceLookup["Order8"], "OrderId", -2);
            updatable.SetValue(resourceLookup["Order8"], "CustomerId", -28);
            resourceLookup.Add("ConcurrencyInfo_12", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ConcurrencyInfo"));
            updatable.SetValue(resourceLookup["ConcurrencyInfo_12"], "Token", "マびグボポボソゾひミя黑ボ畚びяマグクソ亜ァチまぺバぞ珱ゾ亜あチ");
            updatable.SetValue(resourceLookup["ConcurrencyInfo_12"], "QueriedDateTime", new System.DateTime(87906298532648610, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["Order8"], "Concurrency", resourceLookup["ConcurrencyInfo_12"]);


            resourceLookup.Add("Order9", updatable.CreateResource("Order", "Microsoft.Test.OData.Services.AstoriaDefaultService.Order"));
            updatable.SetValue(resourceLookup["Order9"], "OrderId", -1);
            updatable.SetValue(resourceLookup["Order9"], "CustomerId", 2147483647);
            resourceLookup.Add("ConcurrencyInfo_13", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ConcurrencyInfo"));
            updatable.SetValue(resourceLookup["ConcurrencyInfo_13"], "Token", "gjrljyprmunaaivhpfqshvgxgßiuzdznhobeßouvßfmosfßxgufdfymnivujvvudyßryythlmvsifboaß" +
                    "cktssrclqrß");
            updatable.SetValue(resourceLookup["ConcurrencyInfo_13"], "QueriedDateTime", new System.DateTime(634890040688842825, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["Order9"], "Concurrency", resourceLookup["ConcurrencyInfo_13"]);

        }

        private static void PopulateOrderLine(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {

            resourceLookup.Add("OrderLine0", updatable.CreateResource("OrderLine", "Microsoft.Test.OData.Services.AstoriaDefaultService.OrderLine"));
            updatable.SetValue(resourceLookup["OrderLine0"], "OrderId", -10);
            updatable.SetValue(resourceLookup["OrderLine0"], "ProductId", -10);
            updatable.SetValue(resourceLookup["OrderLine0"], "Quantity", -325231153);
            updatable.SetValue(resourceLookup["OrderLine0"], "ConcurrencyToken", "lhvyagabhicdpqiqoxpztssvacdkxvoxdzksdsbykdrvnyg");


            resourceLookup.Add("OrderLine1", updatable.CreateResource("OrderLine", "Microsoft.Test.OData.Services.AstoriaDefaultService.BackOrderLine"));
            updatable.SetValue(resourceLookup["OrderLine1"], "OrderId", -9);
            updatable.SetValue(resourceLookup["OrderLine1"], "ProductId", -9);
            updatable.SetValue(resourceLookup["OrderLine1"], "Quantity", -916);
            updatable.SetValue(resourceLookup["OrderLine1"], "ConcurrencyToken", "kyjykfxslrtjyhyueifuoyxqsuaduxrehalbjcmcxqzssbuhuirmacnlasbqdnmnzrayvsstlexk");


            resourceLookup.Add("OrderLine2", updatable.CreateResource("OrderLine", "Microsoft.Test.OData.Services.AstoriaDefaultService.OrderLine"));
            updatable.SetValue(resourceLookup["OrderLine2"], "OrderId", -8);
            updatable.SetValue(resourceLookup["OrderLine2"], "ProductId", -8);
            updatable.SetValue(resourceLookup["OrderLine2"], "Quantity", -94);
            updatable.SetValue(resourceLookup["OrderLine2"], "ConcurrencyToken", "guijsdboufjdxgddcqssßhdhrlguhxutßnßhlqsvuqnockgcjgyhurjlevjzgovdapksxßvqmvugxoocu" +
                    "oteßhg");


            resourceLookup.Add("OrderLine3", updatable.CreateResource("OrderLine", "Microsoft.Test.OData.Services.AstoriaDefaultService.BackOrderLine2"));
            updatable.SetValue(resourceLookup["OrderLine3"], "OrderId", -7);
            updatable.SetValue(resourceLookup["OrderLine3"], "ProductId", -7);
            updatable.SetValue(resourceLookup["OrderLine3"], "Quantity", 74);
            updatable.SetValue(resourceLookup["OrderLine3"], "ConcurrencyToken", "oljmddssrussdoistakqckhfuhsvucqjfgsdbugymciogcgtaexsnqubhvgaxkosatqssjvlßspi");


            resourceLookup.Add("OrderLine4", updatable.CreateResource("OrderLine", "Microsoft.Test.OData.Services.AstoriaDefaultService.BackOrderLine2"));
            updatable.SetValue(resourceLookup["OrderLine4"], "OrderId", -6);
            updatable.SetValue(resourceLookup["OrderLine4"], "ProductId", -6);
            updatable.SetValue(resourceLookup["OrderLine4"], "Quantity", -2147483648);
            updatable.SetValue(resourceLookup["OrderLine4"], "ConcurrencyToken", "ctntßtpfiax");


            resourceLookup.Add("OrderLine5", updatable.CreateResource("OrderLine", "Microsoft.Test.OData.Services.AstoriaDefaultService.OrderLine"));
            updatable.SetValue(resourceLookup["OrderLine5"], "OrderId", -5);
            updatable.SetValue(resourceLookup["OrderLine5"], "ProductId", -5);
            updatable.SetValue(resourceLookup["OrderLine5"], "Quantity", -94);
            updatable.SetValue(resourceLookup["OrderLine5"], "ConcurrencyToken", "vesaruhsvmvsthubptmpjcdßßojpvnciunngjbbjjlhbnfomkehyozupu");


            resourceLookup.Add("OrderLine6", updatable.CreateResource("OrderLine", "Microsoft.Test.OData.Services.AstoriaDefaultService.BackOrderLine"));
            updatable.SetValue(resourceLookup["OrderLine6"], "OrderId", -4);
            updatable.SetValue(resourceLookup["OrderLine6"], "ProductId", -4);
            updatable.SetValue(resourceLookup["OrderLine6"], "Quantity", -58);
            updatable.SetValue(resourceLookup["OrderLine6"], "ConcurrencyToken", "aullcßssoudxjuotakazoccxhuslpuy");


            resourceLookup.Add("OrderLine7", updatable.CreateResource("OrderLine", "Microsoft.Test.OData.Services.AstoriaDefaultService.BackOrderLine2"));
            updatable.SetValue(resourceLookup["OrderLine7"], "OrderId", -3);
            updatable.SetValue(resourceLookup["OrderLine7"], "ProductId", -3);
            updatable.SetValue(resourceLookup["OrderLine7"], "Quantity", -61);
            updatable.SetValue(resourceLookup["OrderLine7"], "ConcurrencyToken", "ehpkubjlhzvuukitzlxyuokmoejoa");


            resourceLookup.Add("OrderLine8", updatable.CreateResource("OrderLine", "Microsoft.Test.OData.Services.AstoriaDefaultService.OrderLine"));
            updatable.SetValue(resourceLookup["OrderLine8"], "OrderId", -2);
            updatable.SetValue(resourceLookup["OrderLine8"], "ProductId", -2);
            updatable.SetValue(resourceLookup["OrderLine8"], "Quantity", 2147483647);
            updatable.SetValue(resourceLookup["OrderLine8"], "ConcurrencyToken", "弌ぽﾈ九ソァタяダタたяぁぺЯゼそバんボяほ畚せマァゼひ黑んゼびァボダソ裹ァチたあぺぞソん");


            resourceLookup.Add("OrderLine9", updatable.CreateResource("OrderLine", "Microsoft.Test.OData.Services.AstoriaDefaultService.BackOrderLine"));
            updatable.SetValue(resourceLookup["OrderLine9"], "OrderId", -1);
            updatable.SetValue(resourceLookup["OrderLine9"], "ProductId", -1);
            updatable.SetValue(resourceLookup["OrderLine9"], "Quantity", 158);
            updatable.SetValue(resourceLookup["OrderLine9"], "ConcurrencyToken", null);

        }

        private static void PopulateProduct(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {

            resourceLookup.Add("Product0", updatable.CreateResource("Product", "Microsoft.Test.OData.Services.AstoriaDefaultService.Product"));
            updatable.SetValue(resourceLookup["Product0"], "ProductId", -10);
            updatable.SetValue(resourceLookup["Product0"], "Description", "onesusjnzuzrmzhqankkugdrftiukzkzqaggsfdmtvineulehkrbpu");
            resourceLookup.Add("Dimensions_0", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Dimensions"));
            updatable.SetValue(resourceLookup["Dimensions_0"], "Width", -79228162514264337593543950335m);
            updatable.SetValue(resourceLookup["Dimensions_0"], "Height", -0.492988348718789m);
            updatable.SetValue(resourceLookup["Dimensions_0"], "Depth", -78702059456772700000000000000m);
            updatable.SetValue(resourceLookup["Product0"], "Dimensions", resourceLookup["Dimensions_0"]);
            updatable.SetValue(resourceLookup["Product0"], "BaseConcurrency", "assrfsssfdtrmdajadchvrqehsszybuiyiußlhmazsuemptziruotkqcyßßp");
            resourceLookup.Add("ConcurrencyInfo_14", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ConcurrencyInfo"));
            updatable.SetValue(resourceLookup["ConcurrencyInfo_14"], "Token", null);
            updatable.SetValue(resourceLookup["ConcurrencyInfo_14"], "QueriedDateTime", new System.DateTime(634933960711667673, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["Product0"], "ComplexConcurrency", resourceLookup["ConcurrencyInfo_14"]);
            resourceLookup.Add("AuditInfo_7", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.AuditInfo"));
            updatable.SetValue(resourceLookup["AuditInfo_7"], "ModifiedDate", new System.DateTime(3155378975999999999, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["AuditInfo_7"], "ModifiedBy", "gsrqilravbargkknoljssfn");
            resourceLookup.Add("ConcurrencyInfo_15", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ConcurrencyInfo"));
            updatable.SetValue(resourceLookup["ConcurrencyInfo_15"], "Token", "び欲ぜぞボゾそａチぼ縷ソ黑ミ");
            updatable.SetValue(resourceLookup["ConcurrencyInfo_15"], "QueriedDateTime", new System.DateTime(634504555183369240, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["AuditInfo_7"], "Concurrency", resourceLookup["ConcurrencyInfo_15"]);
            updatable.SetValue(resourceLookup["Product0"], "NestedComplexConcurrency", resourceLookup["AuditInfo_7"]);


            resourceLookup.Add("Product1", updatable.CreateResource("Product", "Microsoft.Test.OData.Services.AstoriaDefaultService.DiscontinuedProduct"));
            updatable.SetValue(resourceLookup["Product1"], "ProductId", -9);
            updatable.SetValue(resourceLookup["Product1"], "Description", "kdcuklu");
            resourceLookup.Add("Dimensions_1", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Dimensions"));
            updatable.SetValue(resourceLookup["Dimensions_1"], "Width", -25802798699776200000000000000m);
            updatable.SetValue(resourceLookup["Dimensions_1"], "Height", 38.543408267225m);
            updatable.SetValue(resourceLookup["Dimensions_1"], "Depth", -8459.21552673786m);
            updatable.SetValue(resourceLookup["Product1"], "Dimensions", resourceLookup["Dimensions_1"]);
            updatable.SetValue(resourceLookup["Product1"], "BaseConcurrency", "яァそ珱ｚそ縷ミёボぜЯ歹ミバほポほゼｦ畚クほﾈゼま裹びぴべ歹あダグソびёёんポそミマほソｚ裹ぼん珱べゼ歹ミｚポぜぞソポぺミダ欲弌яソソぽソべバ黑九珱ぞポЯダソゼ" +
                    "");
            resourceLookup.Add("ConcurrencyInfo_16", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ConcurrencyInfo"));
            updatable.SetValue(resourceLookup["ConcurrencyInfo_16"], "Token", "vkvezqrkjuykjmkßyqpliyvß");
            updatable.SetValue(resourceLookup["ConcurrencyInfo_16"], "QueriedDateTime", null);
            updatable.SetValue(resourceLookup["Product1"], "ComplexConcurrency", resourceLookup["ConcurrencyInfo_16"]);
            resourceLookup.Add("AuditInfo_8", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.AuditInfo"));
            updatable.SetValue(resourceLookup["AuditInfo_8"], "ModifiedDate", new System.DateTime(634890040688528105, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["AuditInfo_8"], "ModifiedBy", "gtpakgdzcfjyumozyqzrhxuypuzfqhvmzeepvjllfncsjuumjzdxvlhjprgphzfvjxzsklilojgtqhktp" +
                    "j");
            resourceLookup.Add("ConcurrencyInfo_17", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ConcurrencyInfo"));
            updatable.SetValue(resourceLookup["ConcurrencyInfo_17"], "Token", "ボボﾝひё縷そァぽゼんダ珱ゼぁｚ畚亜亜ゼひバ亜ほべハﾝﾈたポ九ゾべダぞ畚タｚゾぼァЯダをあ");
            updatable.SetValue(resourceLookup["ConcurrencyInfo_17"], "QueriedDateTime", new System.DateTime(632647527849396883, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["AuditInfo_8"], "Concurrency", resourceLookup["ConcurrencyInfo_17"]);
            updatable.SetValue(resourceLookup["Product1"], "NestedComplexConcurrency", resourceLookup["AuditInfo_8"]);
            updatable.SetValue(resourceLookup["Product1"], "Discontinued", new System.DateTime(632581529969997833, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["Product1"], "ReplacementProductId", null);
            resourceLookup.Add("Phone_499", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_499"], "PhoneNumber", "縷たべハボ欲ァんぽぴソａぽゾあたぁソびぼポ九バほ畚ゼまａぼそЯ亜ﾈぁグぴ暦ｚポほボボﾈぴ");
            updatable.SetValue(resourceLookup["Phone_499"], "Extension", "bozhmrtomzrcmheuuqybovfiuypathsafmriopuccbqubhqbmuauxvnftvnpisgobryzqya");
            updatable.SetValue(resourceLookup["Product1"], "DiscontinuedPhone", resourceLookup["Phone_499"]);
            updatable.SetValue(resourceLookup["Product1"], "ChildConcurrencyToken", "裹ぺゾ縷ゼほゼソｚゼｚぜソﾝゼをまぁダびタ珱タバゾゾミチボ暦ソァべ裹ポぜをｦびゼマをゼミぽボソﾈぽポミゾａタソぁマ裹グａタ歹歹たｚバ縷チんをЯん畚たゾべソ欲ァ縷я" +
                    "ミをｦせｦゼマソボゼゼチぼ畚珱");


            resourceLookup.Add("Product2", updatable.CreateResource("Product", "Microsoft.Test.OData.Services.AstoriaDefaultService.DiscontinuedProduct"));
            updatable.SetValue(resourceLookup["Product2"], "ProductId", -8);
            updatable.SetValue(resourceLookup["Product2"], "Description", "kelßebrrbesshcnkmhsxokyßetgscprtmiptxyiqnxrohjßuyfegßßmlnejcsmkemgjfrxpqfeffuuqru" +
                    "bvznftmniuulxz");
            updatable.SetValue(resourceLookup["Product2"], "Dimensions", null);
            updatable.SetValue(resourceLookup["Product2"], "BaseConcurrency", "asme");
            resourceLookup.Add("ConcurrencyInfo_18", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ConcurrencyInfo"));
            updatable.SetValue(resourceLookup["ConcurrencyInfo_18"], "Token", null);
            updatable.SetValue(resourceLookup["ConcurrencyInfo_18"], "QueriedDateTime", new System.DateTime(634855286563627949, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["Product2"], "ComplexConcurrency", resourceLookup["ConcurrencyInfo_18"]);
            resourceLookup.Add("AuditInfo_9", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.AuditInfo"));
            updatable.SetValue(resourceLookup["AuditInfo_9"], "ModifiedDate", new System.DateTime(1713668396298454872, System.DateTimeKind.Local));
            updatable.SetValue(resourceLookup["AuditInfo_9"], "ModifiedBy", "xsnquujocxuumpeqsbodtugghfrghfuihjiyxgvcntkflpxohuyfgytigbdl");
            resourceLookup.Add("ConcurrencyInfo_19", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ConcurrencyInfo"));
            updatable.SetValue(resourceLookup["ConcurrencyInfo_19"], "Token", "solisgfvqa");
            updatable.SetValue(resourceLookup["ConcurrencyInfo_19"], "QueriedDateTime", new System.DateTime(2954675828701866623, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["AuditInfo_9"], "Concurrency", resourceLookup["ConcurrencyInfo_19"]);
            updatable.SetValue(resourceLookup["Product2"], "NestedComplexConcurrency", resourceLookup["AuditInfo_9"]);
            updatable.SetValue(resourceLookup["Product2"], "Discontinued", new System.DateTime(634812397028011658, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["Product2"], "ReplacementProductId", 62);
            resourceLookup.Add("Phone_500", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_500"], "PhoneNumber", "ulemcjvsndemzkctrfhkiuiblmhdkkledze");
            updatable.SetValue(resourceLookup["Phone_500"], "Extension", "グ黑ポЯポソ欲タぴぺ畚をほまバぽﾝゼ歹ぁポёハをぜ九ЯまЯソぜ暦ｚダяチゼ欲ソミマぁべぁハぴを匚ポミあ九ぞミぞァァク裹ａソタタ亜そあクマぽё珱ひﾈぜクボ欲ダミ黑");
            updatable.SetValue(resourceLookup["Product2"], "DiscontinuedPhone", resourceLookup["Phone_500"]);
            updatable.SetValue(resourceLookup["Product2"], "ChildConcurrencyToken", "hhsbjscessmdunkssmvqmqyzuahm");


            resourceLookup.Add("Product3", updatable.CreateResource("Product", "Microsoft.Test.OData.Services.AstoriaDefaultService.Product"));
            updatable.SetValue(resourceLookup["Product3"], "ProductId", -7);
            updatable.SetValue(resourceLookup["Product3"], "Description", null);
            resourceLookup.Add("Dimensions_2", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Dimensions"));
            updatable.SetValue(resourceLookup["Dimensions_2"], "Width", -73118289035663600000000000000m);
            updatable.SetValue(resourceLookup["Dimensions_2"], "Height", 25.9581087054375m);
            updatable.SetValue(resourceLookup["Dimensions_2"], "Depth", -71.7711704670702m);
            updatable.SetValue(resourceLookup["Product3"], "Dimensions", resourceLookup["Dimensions_2"]);
            updatable.SetValue(resourceLookup["Product3"], "BaseConcurrency", "びマ歹ゾボまﾝぺをゼァゼたバべダｦミソ亜ァマゼチゼあﾈまひボぁёﾝダゼｚひяァぴべ縷ぜをひを亜まソぽべひミぞまゾままあチん");
            resourceLookup.Add("ConcurrencyInfo_20", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ConcurrencyInfo"));
            updatable.SetValue(resourceLookup["ConcurrencyInfo_20"], "Token", "nbdgygcmjnihofqvxjxfvcxqxytvlujyvxuiuxct");
            updatable.SetValue(resourceLookup["ConcurrencyInfo_20"], "QueriedDateTime", new System.DateTime(635150618836196168, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["Product3"], "ComplexConcurrency", resourceLookup["ConcurrencyInfo_20"]);
            resourceLookup.Add("AuditInfo_10", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.AuditInfo"));
            updatable.SetValue(resourceLookup["AuditInfo_10"], "ModifiedDate", new System.DateTime(2482230471527477550, System.DateTimeKind.Local));
            updatable.SetValue(resourceLookup["AuditInfo_10"], "ModifiedBy", "ngfqlßphequuncuprßuiydjalaamdrrbmyhvunjdbinctagtiabuegodssfolßiohssssqsxgxopzzutb" +
                    "dlsdjclmoutiylkssd");
            resourceLookup.Add("ConcurrencyInfo_21", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ConcurrencyInfo"));
            updatable.SetValue(resourceLookup["ConcurrencyInfo_21"], "Token", "ボ畚九ぴあチひソァタ九яポ弌マポ裹黑ソ暦ソｚ九ゾァポポボ匚歹チ黑ゾあぁゼポёゼ");
            updatable.SetValue(resourceLookup["ConcurrencyInfo_21"], "QueriedDateTime", new System.DateTime(631906548252199237, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["AuditInfo_10"], "Concurrency", resourceLookup["ConcurrencyInfo_21"]);
            updatable.SetValue(resourceLookup["Product3"], "NestedComplexConcurrency", resourceLookup["AuditInfo_10"]);


            resourceLookup.Add("Product4", updatable.CreateResource("Product", "Microsoft.Test.OData.Services.AstoriaDefaultService.Product"));
            updatable.SetValue(resourceLookup["Product4"], "ProductId", -6);
            updatable.SetValue(resourceLookup["Product4"], "Description", "expdybhclurfobuyvzmhkgrnrajhamqmkhqpmiypittnp");
            resourceLookup.Add("Dimensions_3", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Dimensions"));
            updatable.SetValue(resourceLookup["Dimensions_3"], "Width", -49157206180150400000000000000m);
            updatable.SetValue(resourceLookup["Dimensions_3"], "Height", -79228162514264337593543950335m);
            updatable.SetValue(resourceLookup["Dimensions_3"], "Depth", 38.8793813628938m);
            updatable.SetValue(resourceLookup["Product4"], "Dimensions", resourceLookup["Dimensions_3"]);
            updatable.SetValue(resourceLookup["Product4"], "BaseConcurrency", "uacssmuxummhtezdsnoßssrlbsßloxjsslnnayinxiksspjsssvumgduaapcfvnsseeßgpaxuaabosemß" +
                    "iemtufplo");
            resourceLookup.Add("ConcurrencyInfo_22", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ConcurrencyInfo"));
            updatable.SetValue(resourceLookup["ConcurrencyInfo_22"], "Token", "まﾝ裹ぁゼｦぼ歹ポぜボたゾひたソﾝタボたぺを欲弌ミソゾべ弌ダァぺべソ裹ひ暦ﾝそя欲ぺ歹ボタひせァﾝんゾﾝァポクﾝひぜ");
            updatable.SetValue(resourceLookup["ConcurrencyInfo_22"], "QueriedDateTime", new System.DateTime(0, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["Product4"], "ComplexConcurrency", resourceLookup["ConcurrencyInfo_22"]);
            resourceLookup.Add("AuditInfo_11", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.AuditInfo"));
            updatable.SetValue(resourceLookup["AuditInfo_11"], "ModifiedDate", new System.DateTime(0, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["AuditInfo_11"], "ModifiedBy", null);
            resourceLookup.Add("ConcurrencyInfo_23", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ConcurrencyInfo"));
            updatable.SetValue(resourceLookup["ConcurrencyInfo_23"], "Token", "zqzhnfajucmhubkegvlixzrqum");
            updatable.SetValue(resourceLookup["ConcurrencyInfo_23"], "QueriedDateTime", new System.DateTime(2954553598514918312, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["AuditInfo_11"], "Concurrency", resourceLookup["ConcurrencyInfo_23"]);
            updatable.SetValue(resourceLookup["Product4"], "NestedComplexConcurrency", resourceLookup["AuditInfo_11"]);


            resourceLookup.Add("Product5", updatable.CreateResource("Product", "Microsoft.Test.OData.Services.AstoriaDefaultService.DiscontinuedProduct"));
            updatable.SetValue(resourceLookup["Product5"], "ProductId", -5);
            updatable.SetValue(resourceLookup["Product5"], "Description", "uuudqysoiozagpcpumnydpupopsvd");
            resourceLookup.Add("Dimensions_4", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Dimensions"));
            updatable.SetValue(resourceLookup["Dimensions_4"], "Width", 7337.75206762393m);
            updatable.SetValue(resourceLookup["Dimensions_4"], "Height", -4.63644378890358m);
            updatable.SetValue(resourceLookup["Dimensions_4"], "Depth", -79228162514264337593543950335m);
            updatable.SetValue(resourceLookup["Product5"], "Dimensions", resourceLookup["Dimensions_4"]);
            updatable.SetValue(resourceLookup["Product5"], "BaseConcurrency", "inxlfdfruoalzluabvubrgahsg");
            updatable.SetValue(resourceLookup["Product5"], "ComplexConcurrency", null);
            resourceLookup.Add("AuditInfo_12", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.AuditInfo"));
            updatable.SetValue(resourceLookup["AuditInfo_12"], "ModifiedDate", new System.DateTime(3155378975999999999, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["AuditInfo_12"], "ModifiedBy", "mlsbmanrhvygvakricoomrnksyutxxdrbizpdzdunzzukgkeaibnuufvxcjputulmcutevhiyflnsjahj" +
                    "istqrlasor");
            updatable.SetValue(resourceLookup["AuditInfo_12"], "Concurrency", null);
            updatable.SetValue(resourceLookup["Product5"], "NestedComplexConcurrency", resourceLookup["AuditInfo_12"]);
            updatable.SetValue(resourceLookup["Product5"], "Discontinued", new System.DateTime(634755161734591089, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["Product5"], "ReplacementProductId", -2147483648);
            resourceLookup.Add("Phone_501", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_501"], "PhoneNumber", "びマ");
            updatable.SetValue(resourceLookup["Phone_501"], "Extension", "九ぜゾべぁびミёё歹珱九ぞあａぞクダまァミソん歹欲べ亜ぜチぜチぁボゼﾝяほ珱ゾゾぼ匚ぜハミソぁボぜぁァチクタ黑を匚ボグ珱ゼボソｚ");
            updatable.SetValue(resourceLookup["Product5"], "DiscontinuedPhone", resourceLookup["Phone_501"]);
            updatable.SetValue(resourceLookup["Product5"], "ChildConcurrencyToken", "ixxletiyfrigooaltaqikqcnkpepfufyffmuouknjzyelardpyudoachqdejrjnuhueunugyli");


            resourceLookup.Add("Product6", updatable.CreateResource("Product", "Microsoft.Test.OData.Services.AstoriaDefaultService.Product"));
            updatable.SetValue(resourceLookup["Product6"], "ProductId", -4);
            updatable.SetValue(resourceLookup["Product6"], "Description", "rgdhvcueuidboerbhyvsvjg");
            resourceLookup.Add("Dimensions_5", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Dimensions"));
            updatable.SetValue(resourceLookup["Dimensions_5"], "Width", 0m);
            updatable.SetValue(resourceLookup["Dimensions_5"], "Height", -62044452036508000000000000000m);
            updatable.SetValue(resourceLookup["Dimensions_5"], "Depth", 0m);
            updatable.SetValue(resourceLookup["Product6"], "Dimensions", resourceLookup["Dimensions_5"]);
            updatable.SetValue(resourceLookup["Product6"], "BaseConcurrency", "ぽボﾝあび");
            resourceLookup.Add("ConcurrencyInfo_24", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ConcurrencyInfo"));
            updatable.SetValue(resourceLookup["ConcurrencyInfo_24"], "Token", "uyu");
            updatable.SetValue(resourceLookup["ConcurrencyInfo_24"], "QueriedDateTime", new System.DateTime(634890040688842825, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["Product6"], "ComplexConcurrency", resourceLookup["ConcurrencyInfo_24"]);
            resourceLookup.Add("AuditInfo_13", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.AuditInfo"));
            updatable.SetValue(resourceLookup["AuditInfo_13"], "ModifiedDate", new System.DateTime(450557167798885925, System.DateTimeKind.Local));
            updatable.SetValue(resourceLookup["AuditInfo_13"], "ModifiedBy", "ダチせあｚミソぽЯゼチゼ縷マ縷裹ﾈ匚暦チя匚ぁミ弌ハ弌ソゾ弌ぽんぴゼボま縷ゼボソハ裹黑九ポ黑マあゼソをぺタぺボ亜タァまクａﾝ亜ぺひぽぺ");
            resourceLookup.Add("ConcurrencyInfo_25", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ConcurrencyInfo"));
            updatable.SetValue(resourceLookup["ConcurrencyInfo_25"], "Token", "gßoyfeyzsaelevßu");
            updatable.SetValue(resourceLookup["ConcurrencyInfo_25"], "QueriedDateTime", new System.DateTime(634976560566053928, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["AuditInfo_13"], "Concurrency", resourceLookup["ConcurrencyInfo_25"]);
            updatable.SetValue(resourceLookup["Product6"], "NestedComplexConcurrency", resourceLookup["AuditInfo_13"]);


            resourceLookup.Add("Product7", updatable.CreateResource("Product", "Microsoft.Test.OData.Services.AstoriaDefaultService.DiscontinuedProduct"));
            updatable.SetValue(resourceLookup["Product7"], "ProductId", -3);
            updatable.SetValue(resourceLookup["Product7"], "Description", "ißuhmxavnmlsssssjssagmqjpchjußtkcoaldeyyduarovnxspzsskufxxfltußtxfhgjlksrn");
            updatable.SetValue(resourceLookup["Product7"], "Dimensions", null);
            updatable.SetValue(resourceLookup["Product7"], "BaseConcurrency", "fvrnsbiußevuqssnuidjbhtluhcydhhjihyasecdnumhdpfxtijßlvfqngmulfvjqqtvussyixßykxhbn" +
                    "ehobßjssfickhmevci");
            resourceLookup.Add("ConcurrencyInfo_26", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ConcurrencyInfo"));
            updatable.SetValue(resourceLookup["ConcurrencyInfo_26"], "Token", "bdokxvtboyiiuphcrjrlklntbqksnlrldfzqdjgbkcbmyredrlyjunfrrfdcganncntvprydekacdauln" +
                    "");
            updatable.SetValue(resourceLookup["ConcurrencyInfo_26"], "QueriedDateTime", null);
            updatable.SetValue(resourceLookup["Product7"], "ComplexConcurrency", resourceLookup["ConcurrencyInfo_26"]);
            updatable.SetValue(resourceLookup["Product7"], "NestedComplexConcurrency", null);
            updatable.SetValue(resourceLookup["Product7"], "Discontinued", new System.DateTime(0, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["Product7"], "ReplacementProductId", -1002345821);
            updatable.SetValue(resourceLookup["Product7"], "DiscontinuedPhone", null);
            updatable.SetValue(resourceLookup["Product7"], "ChildConcurrencyToken", "そ歹ソボボをグ裹ぴポｦチ");


            resourceLookup.Add("Product8", updatable.CreateResource("Product", "Microsoft.Test.OData.Services.AstoriaDefaultService.DiscontinuedProduct"));
            updatable.SetValue(resourceLookup["Product8"], "ProductId", -2);
            updatable.SetValue(resourceLookup["Product8"], "Description", null);
            resourceLookup.Add("Dimensions_6", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Dimensions"));
            updatable.SetValue(resourceLookup["Dimensions_6"], "Width", -79228162514264337593543950335m);
            updatable.SetValue(resourceLookup["Dimensions_6"], "Height", 44733559606978800000000000000m);
            updatable.SetValue(resourceLookup["Dimensions_6"], "Depth", -3913.60110028978m);
            updatable.SetValue(resourceLookup["Product8"], "Dimensions", resourceLookup["Dimensions_6"]);
            updatable.SetValue(resourceLookup["Product8"], "BaseConcurrency", null);
            resourceLookup.Add("ConcurrencyInfo_27", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ConcurrencyInfo"));
            updatable.SetValue(resourceLookup["ConcurrencyInfo_27"], "Token", "mgmjxrußcs");
            updatable.SetValue(resourceLookup["ConcurrencyInfo_27"], "QueriedDateTime", new System.DateTime(2845688657729990625, System.DateTimeKind.Local));
            updatable.SetValue(resourceLookup["Product8"], "ComplexConcurrency", resourceLookup["ConcurrencyInfo_27"]);
            updatable.SetValue(resourceLookup["Product8"], "NestedComplexConcurrency", null);
            updatable.SetValue(resourceLookup["Product8"], "Discontinued", new System.DateTime(3155378975999999999, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["Product8"], "ReplacementProductId", -566261304);
            resourceLookup.Add("Phone_502", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_502"], "PhoneNumber", "nmaktpqeyimclgtimdspkbavivoclmvfcdeuysxemttzsckamkhukl");
            updatable.SetValue(resourceLookup["Phone_502"], "Extension", null);
            updatable.SetValue(resourceLookup["Product8"], "DiscontinuedPhone", resourceLookup["Phone_502"]);
            updatable.SetValue(resourceLookup["Product8"], "ChildConcurrencyToken", "yljmhbcacfnothqirhaouhoraoruscpptgzmoch");


            resourceLookup.Add("Product9", updatable.CreateResource("Product", "Microsoft.Test.OData.Services.AstoriaDefaultService.Product"));
            updatable.SetValue(resourceLookup["Product9"], "ProductId", -1);
            updatable.SetValue(resourceLookup["Product9"], "Description", "vjsmflmaltcrnxiztidnalnrbhyaqzmxgkqesxnmodm");
            resourceLookup.Add("Dimensions_7", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Dimensions"));
            updatable.SetValue(resourceLookup["Dimensions_7"], "Width", 0.123283309629675m);
            updatable.SetValue(resourceLookup["Dimensions_7"], "Height", -9264.03359778997m);
            updatable.SetValue(resourceLookup["Dimensions_7"], "Depth", -0.409268660025419m);
            updatable.SetValue(resourceLookup["Product9"], "Dimensions", resourceLookup["Dimensions_7"]);
            updatable.SetValue(resourceLookup["Product9"], "BaseConcurrency", null);
            resourceLookup.Add("ConcurrencyInfo_28", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ConcurrencyInfo"));
            updatable.SetValue(resourceLookup["ConcurrencyInfo_28"], "Token", "dggicadyltktsssssmißjgblhyifbsnssspssahrgcspiznverhzgyvq");
            updatable.SetValue(resourceLookup["ConcurrencyInfo_28"], "QueriedDateTime", new System.DateTime(3155378975999999999, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["Product9"], "ComplexConcurrency", resourceLookup["ConcurrencyInfo_28"]);
            updatable.SetValue(resourceLookup["Product9"], "NestedComplexConcurrency", null);

        }

        private static void PopulateProductDetail(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {

            resourceLookup.Add("ProductDetail0", updatable.CreateResource("ProductDetail", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductDetail"));
            updatable.SetValue(resourceLookup["ProductDetail0"], "ProductId", -10);
            updatable.SetValue(resourceLookup["ProductDetail0"], "Details", "lviipfnkdejpzonrvkzradhxßpkssvaibmuupjsoßljxzubiroynzmstbjcißxprcsscetßßcifz");


            resourceLookup.Add("ProductDetail1", updatable.CreateResource("ProductDetail", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductDetail"));
            updatable.SetValue(resourceLookup["ProductDetail1"], "ProductId", -9);
            updatable.SetValue(resourceLookup["ProductDetail1"], "Details", "uzetenprkufssbiculuquxvebmpunavicqjerikglietrqjesvvo");


            resourceLookup.Add("ProductDetail2", updatable.CreateResource("ProductDetail", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductDetail"));
            updatable.SetValue(resourceLookup["ProductDetail2"], "ProductId", -8);
            updatable.SetValue(resourceLookup["ProductDetail2"], "Details", "pyclftniuczyhpgsypylfojyaoefgqelgkryzjiriizjuxlkgrtakpmkldkbrcslujmyxjtllbjbuzsin" +
                    "mzpxeesxc");


            resourceLookup.Add("ProductDetail3", updatable.CreateResource("ProductDetail", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductDetail"));
            updatable.SetValue(resourceLookup["ProductDetail3"], "ProductId", -7);
            updatable.SetValue(resourceLookup["ProductDetail3"], "Details", "capcsfgnhlibhzvcvmgrtssrphutpercßssßtrecssppzsriyfdagubßussdgßxmptmtd");


            resourceLookup.Add("ProductDetail4", updatable.CreateResource("ProductDetail", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductDetail"));
            updatable.SetValue(resourceLookup["ProductDetail4"], "ProductId", -6);
            updatable.SetValue(resourceLookup["ProductDetail4"], "Details", "rurdfmekougouoibfheytppgangqziloxoikdounipdtqnoymccyxguiufcru");


            resourceLookup.Add("ProductDetail5", updatable.CreateResource("ProductDetail", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductDetail"));
            updatable.SetValue(resourceLookup["ProductDetail5"], "ProductId", -5);
            updatable.SetValue(resourceLookup["ProductDetail5"], "Details", "csiihysghlmfsskßkqcxßßgqdcduxnlutbqeexpnqfanrbffießbsssmuyivyoixuyfvifhzpescs");


            resourceLookup.Add("ProductDetail6", updatable.CreateResource("ProductDetail", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductDetail"));
            updatable.SetValue(resourceLookup["ProductDetail6"], "ProductId", -4);
            updatable.SetValue(resourceLookup["ProductDetail6"], "Details", "ubxpzsuxequoglmvvakeckmfmornooiuzjfjldsuvhxinpodkaezbikgpnivactxnpuyuifmdd");


            resourceLookup.Add("ProductDetail7", updatable.CreateResource("ProductDetail", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductDetail"));
            updatable.SetValue(resourceLookup["ProductDetail7"], "ProductId", -3);
            updatable.SetValue(resourceLookup["ProductDetail7"], "Details", "ｦポゾせまび九ぜチミそをマタ欲をダポべチグ縷ｦゼ歹ぺゼマ");


            resourceLookup.Add("ProductDetail8", updatable.CreateResource("ProductDetail", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductDetail"));
            updatable.SetValue(resourceLookup["ProductDetail8"], "ProductId", -2);
            updatable.SetValue(resourceLookup["ProductDetail8"], "Details", "ｦ珱ァタяゼポソチせソポ歹ﾈａ畚ぽЯぴｚタ九弌亜あチﾈゼァソ珱ソァ畚歹ゼゾソソぴﾈﾝЯ珱ハ暦黑яａミポｦ珱九ゾべあハソソゼぼぞそぺяをﾈぞタグ弌チЯﾈタ九ａひぽポ" +
                    "ｚソバ暦裹チバゼボァ裹Яﾈ亜ミ畚縷ボ");


            resourceLookup.Add("ProductDetail9", updatable.CreateResource("ProductDetail", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductDetail"));
            updatable.SetValue(resourceLookup["ProductDetail9"], "ProductId", -1);
            updatable.SetValue(resourceLookup["ProductDetail9"], "Details", "sssuuyptquexacqßyuhdnpyqxqcafjkeoqydpnueormlrhqbsdmjssczß");

        }

        private static void PopulateProductReview(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {

            resourceLookup.Add("ProductReview0", updatable.CreateResource("ProductReview", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductReview"));
            updatable.SetValue(resourceLookup["ProductReview0"], "ProductId", -10);
            updatable.SetValue(resourceLookup["ProductReview0"], "ReviewId", -10);
            updatable.SetValue(resourceLookup["ProductReview0"], "Review", "ハべチ暦ポチﾝぜ匚ぜ暦黑ポ珱ボ黑ぜゼほぁぞｚゼゾ九タミｚまボぽ裹ァぁたぽ弌");
            updatable.SetValue(resourceLookup["ProductReview0"], "RevisionId", "1");


            resourceLookup.Add("ProductReview1", updatable.CreateResource("ProductReview", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductReview"));
            updatable.SetValue(resourceLookup["ProductReview1"], "ProductId", -9);
            updatable.SetValue(resourceLookup["ProductReview1"], "ReviewId", -9);
            updatable.SetValue(resourceLookup["ProductReview1"], "Review", "rvqrgbkqzoybdrfsssulycupxfrgdpj");
            updatable.SetValue(resourceLookup["ProductReview1"], "RevisionId", "2");


            resourceLookup.Add("ProductReview2", updatable.CreateResource("ProductReview", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductReview"));
            updatable.SetValue(resourceLookup["ProductReview2"], "ProductId", -8);
            updatable.SetValue(resourceLookup["ProductReview2"], "ReviewId", -8);
            updatable.SetValue(resourceLookup["ProductReview2"], "Review", "nxhibkpuflabavjnxumeptbvdkodzzushyfqsqcrzbuhujdjqxybbbutqlurgfbfgcuemtvcxuejyuquu" +
                    "");
            updatable.SetValue(resourceLookup["ProductReview2"], "RevisionId", "3");


            resourceLookup.Add("ProductReview3", updatable.CreateResource("ProductReview", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductReview"));
            updatable.SetValue(resourceLookup["ProductReview3"], "ProductId", -7);
            updatable.SetValue(resourceLookup["ProductReview3"], "ReviewId", -7);
            updatable.SetValue(resourceLookup["ProductReview3"], "Review", null);
            updatable.SetValue(resourceLookup["ProductReview3"], "RevisionId", "4");


            resourceLookup.Add("ProductReview4", updatable.CreateResource("ProductReview", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductReview"));
            updatable.SetValue(resourceLookup["ProductReview4"], "ProductId", -6);
            updatable.SetValue(resourceLookup["ProductReview4"], "ReviewId", -6);
            updatable.SetValue(resourceLookup["ProductReview4"], "Review", "ftouj");
            updatable.SetValue(resourceLookup["ProductReview4"], "RevisionId", "5");


            resourceLookup.Add("ProductReview5", updatable.CreateResource("ProductReview", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductReview"));
            updatable.SetValue(resourceLookup["ProductReview5"], "ProductId", -5);
            updatable.SetValue(resourceLookup["ProductReview5"], "ReviewId", -5);
            updatable.SetValue(resourceLookup["ProductReview5"], "Review", null);
            updatable.SetValue(resourceLookup["ProductReview5"], "RevisionId", "6");


            resourceLookup.Add("ProductReview6", updatable.CreateResource("ProductReview", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductReview"));
            updatable.SetValue(resourceLookup["ProductReview6"], "ProductId", -4);
            updatable.SetValue(resourceLookup["ProductReview6"], "ReviewId", -4);
            updatable.SetValue(resourceLookup["ProductReview6"], "Review", "タぜポ歹ボ亜畚そぁボ亜珱ｚポボボマソひ縷ああﾈゾ九ひハ歹マ匚黑そクぁチ珱をぁボチゼ匚ﾈぺ弌ゼぼたソせたた裹黑ボソぞひせソびёゼぽミボゾ縷せ弌ァ");
            updatable.SetValue(resourceLookup["ProductReview6"], "RevisionId", "7");


            resourceLookup.Add("ProductReview7", updatable.CreateResource("ProductReview", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductReview"));
            updatable.SetValue(resourceLookup["ProductReview7"], "ProductId", -3);
            updatable.SetValue(resourceLookup["ProductReview7"], "ReviewId", -3);
            updatable.SetValue(resourceLookup["ProductReview7"], "Review", "afibmzlsihsxnldveeklugbcukn");
            updatable.SetValue(resourceLookup["ProductReview7"], "RevisionId", "8");


            resourceLookup.Add("ProductReview8", updatable.CreateResource("ProductReview", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductReview"));
            updatable.SetValue(resourceLookup["ProductReview8"], "ProductId", -2);
            updatable.SetValue(resourceLookup["ProductReview8"], "ReviewId", -2);
            updatable.SetValue(resourceLookup["ProductReview8"], "Review", null);
            updatable.SetValue(resourceLookup["ProductReview8"], "RevisionId", "9");


            resourceLookup.Add("ProductReview9", updatable.CreateResource("ProductReview", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductReview"));
            updatable.SetValue(resourceLookup["ProductReview9"], "ProductId", -1);
            updatable.SetValue(resourceLookup["ProductReview9"], "ReviewId", -1);
            updatable.SetValue(resourceLookup["ProductReview9"], "Review", null);
            updatable.SetValue(resourceLookup["ProductReview9"], "RevisionId", "10");

        }

        private static void PopulateProductPhoto(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {

            resourceLookup.Add("ProductPhoto0", updatable.CreateResource("ProductPhoto", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductPhoto"));
            updatable.SetValue(resourceLookup["ProductPhoto0"], "ProductId", -10);
            updatable.SetValue(resourceLookup["ProductPhoto0"], "PhotoId", -10);
            updatable.SetValue(resourceLookup["ProductPhoto0"], "Photo", new byte[] {
                        ((byte)(222)),
                        ((byte)(96)),
                        ((byte)(191)),
                        ((byte)(82)),
                        ((byte)(253)),
                        ((byte)(25)),
                        ((byte)(189)),
                        ((byte)(22)),
                        ((byte)(15)),
                        ((byte)(7)),
                        ((byte)(161)),
                        ((byte)(56)),
                        ((byte)(167)),
                        ((byte)(51)),
                        ((byte)(45)),
                        ((byte)(220)),
                        ((byte)(183)),
                        ((byte)(221)),
                        ((byte)(76)),
                        ((byte)(225)),
                        ((byte)(186)),
                        ((byte)(72)),
                        ((byte)(18)),
                        ((byte)(6)),
                        ((byte)(247)),
                        ((byte)(0)),
                        ((byte)(176)),
                        ((byte)(31)),
                        ((byte)(22)),
                        ((byte)(232)),
                        ((byte)(6)),
                        ((byte)(190)),
                        ((byte)(188)),
                        ((byte)(205)),
                        ((byte)(222)),
                        ((byte)(166)),
                        ((byte)(92)),
                        ((byte)(59)),
                        ((byte)(105)),
                        ((byte)(80)),
                        ((byte)(254)),
                        ((byte)(183)),
                        ((byte)(118)),
                        ((byte)(65)),
                        ((byte)(129)),
                        ((byte)(77)),
                        ((byte)(6)),
                        ((byte)(6)),
                        ((byte)(251)),
                        ((byte)(150)),
                        ((byte)(229)),
                        ((byte)(225)),
                        ((byte)(9)),
                        ((byte)(253)),
                        ((byte)(168)),
                        ((byte)(149)),
                        ((byte)(78)),
                        ((byte)(184)),
                        ((byte)(90)),
                        ((byte)(253)),
                        ((byte)(104)),
                        ((byte)(157)),
                        ((byte)(255)),
                        ((byte)(39)),
                        ((byte)(0)),
                        ((byte)(226)),
                        ((byte)(124)),
                        ((byte)(217)),
                        ((byte)(85)),
                        ((byte)(135)),
                        ((byte)(127)),
                        ((byte)(123)),
                        ((byte)(115)),
                        ((byte)(251)),
                        ((byte)(226)),
                        ((byte)(3)),
                        ((byte)(209)),
                        ((byte)(208)),
                        ((byte)(132)),
                        ((byte)(170)),
                        ((byte)(250)),
                        ((byte)(170)),
                        ((byte)(35)),
                        ((byte)(128)),
                        ((byte)(2)),
                        ((byte)(37)),
                        ((byte)(181)),
                        ((byte)(191)),
                        ((byte)(37)),
                        ((byte)(73)),
                        ((byte)(87)),
                        ((byte)(163))});


            resourceLookup.Add("ProductPhoto1", updatable.CreateResource("ProductPhoto", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductPhoto"));
            updatable.SetValue(resourceLookup["ProductPhoto1"], "ProductId", -9);
            updatable.SetValue(resourceLookup["ProductPhoto1"], "PhotoId", -9);
            updatable.SetValue(resourceLookup["ProductPhoto1"], "Photo", new byte[] {
                        ((byte)(244)),
                        ((byte)(46)),
                        ((byte)(188)),
                        ((byte)(5)),
                        ((byte)(137)),
                        ((byte)(65)),
                        ((byte)(185)),
                        ((byte)(250)),
                        ((byte)(112)),
                        ((byte)(221)),
                        ((byte)(64)),
                        ((byte)(227)),
                        ((byte)(51)),
                        ((byte)(247)),
                        ((byte)(38)),
                        ((byte)(20)),
                        ((byte)(132)),
                        ((byte)(4)),
                        ((byte)(24)),
                        ((byte)(23)),
                        ((byte)(120)),
                        ((byte)(164)),
                        ((byte)(139)),
                        ((byte)(51)),
                        ((byte)(96)),
                        ((byte)(23)),
                        ((byte)(57)),
                        ((byte)(172)),
                        ((byte)(73)),
                        ((byte)(165)),
                        ((byte)(114)),
                        ((byte)(19)),
                        ((byte)(161)),
                        ((byte)(101)),
                        ((byte)(17)),
                        ((byte)(117)),
                        ((byte)(44)),
                        ((byte)(179))});


            resourceLookup.Add("ProductPhoto2", updatable.CreateResource("ProductPhoto", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductPhoto"));
            updatable.SetValue(resourceLookup["ProductPhoto2"], "ProductId", -8);
            updatable.SetValue(resourceLookup["ProductPhoto2"], "PhotoId", -8);
            updatable.SetValue(resourceLookup["ProductPhoto2"], "Photo", new byte[] {
                        ((byte)(32)),
                        ((byte)(154)),
                        ((byte)(31)),
                        ((byte)(101)),
                        ((byte)(206)),
                        ((byte)(15)),
                        ((byte)(166)),
                        ((byte)(2)),
                        ((byte)(24)),
                        ((byte)(148)),
                        ((byte)(164)),
                        ((byte)(62)),
                        ((byte)(155)),
                        ((byte)(225)),
                        ((byte)(186)),
                        ((byte)(182)),
                        ((byte)(1)),
                        ((byte)(189)),
                        ((byte)(9)),
                        ((byte)(251)),
                        ((byte)(17)),
                        ((byte)(172)),
                        ((byte)(165)),
                        ((byte)(139)),
                        ((byte)(202)),
                        ((byte)(144)),
                        ((byte)(142)),
                        ((byte)(245)),
                        ((byte)(233)),
                        ((byte)(34)),
                        ((byte)(138)),
                        ((byte)(63)),
                        ((byte)(213)),
                        ((byte)(140)),
                        ((byte)(57)),
                        ((byte)(218)),
                        ((byte)(39)),
                        ((byte)(89)),
                        ((byte)(140)),
                        ((byte)(128)),
                        ((byte)(241)),
                        ((byte)(233)),
                        ((byte)(218)),
                        ((byte)(173)),
                        ((byte)(219)),
                        ((byte)(3)),
                        ((byte)(148)),
                        ((byte)(117)),
                        ((byte)(144)),
                        ((byte)(206)),
                        ((byte)(139)),
                        ((byte)(167)),
                        ((byte)(150)),
                        ((byte)(43)),
                        ((byte)(54)),
                        ((byte)(115)),
                        ((byte)(244)),
                        ((byte)(147)),
                        ((byte)(154)),
                        ((byte)(62)),
                        ((byte)(128)),
                        ((byte)(176)),
                        ((byte)(24)),
                        ((byte)(245)),
                        ((byte)(9))});


            resourceLookup.Add("ProductPhoto3", updatable.CreateResource("ProductPhoto", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductPhoto"));
            updatable.SetValue(resourceLookup["ProductPhoto3"], "ProductId", -7);
            updatable.SetValue(resourceLookup["ProductPhoto3"], "PhotoId", -7);
            updatable.SetValue(resourceLookup["ProductPhoto3"], "Photo", new byte[] {
                        ((byte)(71)),
                        ((byte)(77)),
                        ((byte)(254)),
                        ((byte)(204)),
                        ((byte)(227)),
                        ((byte)(180)),
                        ((byte)(235)),
                        ((byte)(229)),
                        ((byte)(103)),
                        ((byte)(107)),
                        ((byte)(218)),
                        ((byte)(34)),
                        ((byte)(228)),
                        ((byte)(227)),
                        ((byte)(106)),
                        ((byte)(191)),
                        ((byte)(13)),
                        ((byte)(208)),
                        ((byte)(248)),
                        ((byte)(12)),
                        ((byte)(210)),
                        ((byte)(236)),
                        ((byte)(147)),
                        ((byte)(116)),
                        ((byte)(152)),
                        ((byte)(33)),
                        ((byte)(187)),
                        ((byte)(54)),
                        ((byte)(62)),
                        ((byte)(189)),
                        ((byte)(82)),
                        ((byte)(51)),
                        ((byte)(223)),
                        ((byte)(176)),
                        ((byte)(149)),
                        ((byte)(16)),
                        ((byte)(253)),
                        ((byte)(226)),
                        ((byte)(112)),
                        ((byte)(71)),
                        ((byte)(227))});


            resourceLookup.Add("ProductPhoto4", updatable.CreateResource("ProductPhoto", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductPhoto"));
            updatable.SetValue(resourceLookup["ProductPhoto4"], "ProductId", -6);
            updatable.SetValue(resourceLookup["ProductPhoto4"], "PhotoId", -6);
            updatable.SetValue(resourceLookup["ProductPhoto4"], "Photo", new byte[] {
                        ((byte)(101)),
                        ((byte)(163)),
                        ((byte)(185)),
                        ((byte)(175)),
                        ((byte)(230)),
                        ((byte)(116)),
                        ((byte)(23)),
                        ((byte)(130)),
                        ((byte)(252)),
                        ((byte)(38)),
                        ((byte)(234)),
                        ((byte)(101)),
                        ((byte)(200)),
                        ((byte)(159)),
                        ((byte)(155)),
                        ((byte)(39))});


            resourceLookup.Add("ProductPhoto5", updatable.CreateResource("ProductPhoto", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductPhoto"));
            updatable.SetValue(resourceLookup["ProductPhoto5"], "ProductId", -5);
            updatable.SetValue(resourceLookup["ProductPhoto5"], "PhotoId", -5);
            updatable.SetValue(resourceLookup["ProductPhoto5"], "Photo", new byte[] {
                        ((byte)(167)),
                        ((byte)(8)),
                        ((byte)(37)),
                        ((byte)(205)),
                        ((byte)(231)),
                        ((byte)(190)),
                        ((byte)(120)),
                        ((byte)(214)),
                        ((byte)(190)),
                        ((byte)(208)),
                        ((byte)(111)),
                        ((byte)(86)),
                        ((byte)(201)),
                        ((byte)(109)),
                        ((byte)(198)),
                        ((byte)(203)),
                        ((byte)(35)),
                        ((byte)(4)),
                        ((byte)(7)),
                        ((byte)(14)),
                        ((byte)(5)),
                        ((byte)(35)),
                        ((byte)(75)),
                        ((byte)(235)),
                        ((byte)(207)),
                        ((byte)(86)),
                        ((byte)(240)),
                        ((byte)(206)),
                        ((byte)(71)),
                        ((byte)(17)),
                        ((byte)(52)),
                        ((byte)(187)),
                        ((byte)(151)),
                        ((byte)(47)),
                        ((byte)(218)),
                        ((byte)(123)),
                        ((byte)(251)),
                        ((byte)(92)),
                        ((byte)(222)),
                        ((byte)(244)),
                        ((byte)(248)),
                        ((byte)(138)),
                        ((byte)(6)),
                        ((byte)(215)),
                        ((byte)(118)),
                        ((byte)(189)),
                        ((byte)(110)),
                        ((byte)(16)),
                        ((byte)(158)),
                        ((byte)(180)),
                        ((byte)(192)),
                        ((byte)(127)),
                        ((byte)(43)),
                        ((byte)(147)),
                        ((byte)(47))});


            resourceLookup.Add("ProductPhoto6", updatable.CreateResource("ProductPhoto", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductPhoto"));
            updatable.SetValue(resourceLookup["ProductPhoto6"], "ProductId", -4);
            updatable.SetValue(resourceLookup["ProductPhoto6"], "PhotoId", -4);
            updatable.SetValue(resourceLookup["ProductPhoto6"], "Photo", null);


            resourceLookup.Add("ProductPhoto7", updatable.CreateResource("ProductPhoto", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductPhoto"));
            updatable.SetValue(resourceLookup["ProductPhoto7"], "ProductId", -3);
            updatable.SetValue(resourceLookup["ProductPhoto7"], "PhotoId", -3);
            updatable.SetValue(resourceLookup["ProductPhoto7"], "Photo", new byte[] {
                        ((byte)(126)),
                        ((byte)(46)),
                        ((byte)(185)),
                        ((byte)(222)),
                        ((byte)(157)),
                        ((byte)(254)),
                        ((byte)(50)),
                        ((byte)(73)),
                        ((byte)(64)),
                        ((byte)(252)),
                        ((byte)(183)),
                        ((byte)(104)),
                        ((byte)(6)),
                        ((byte)(88)),
                        ((byte)(86)),
                        ((byte)(130)),
                        ((byte)(115)),
                        ((byte)(19)),
                        ((byte)(81)),
                        ((byte)(65)),
                        ((byte)(40)),
                        ((byte)(242)),
                        ((byte)(209)),
                        ((byte)(32)),
                        ((byte)(181)),
                        ((byte)(179)),
                        ((byte)(23)),
                        ((byte)(156)),
                        ((byte)(93)),
                        ((byte)(26)),
                        ((byte)(220)),
                        ((byte)(37)),
                        ((byte)(13)),
                        ((byte)(47)),
                        ((byte)(208)),
                        ((byte)(89)),
                        ((byte)(197)),
                        ((byte)(122)),
                        ((byte)(82)),
                        ((byte)(70)),
                        ((byte)(32)),
                        ((byte)(253)),
                        ((byte)(121)),
                        ((byte)(180)),
                        ((byte)(231)),
                        ((byte)(152)),
                        ((byte)(212)),
                        ((byte)(116)),
                        ((byte)(205)),
                        ((byte)(99)),
                        ((byte)(227)),
                        ((byte)(37)),
                        ((byte)(82)),
                        ((byte)(3)),
                        ((byte)(199)),
                        ((byte)(139)),
                        ((byte)(93)),
                        ((byte)(152)),
                        ((byte)(41)),
                        ((byte)(234)),
                        ((byte)(231)),
                        ((byte)(149)),
                        ((byte)(235)),
                        ((byte)(38)),
                        ((byte)(31)),
                        ((byte)(145)),
                        ((byte)(91)),
                        ((byte)(214)),
                        ((byte)(136)),
                        ((byte)(253)),
                        ((byte)(189)),
                        ((byte)(248)),
                        ((byte)(192)),
                        ((byte)(10)),
                        ((byte)(32)),
                        ((byte)(43)),
                        ((byte)(121)),
                        ((byte)(28)),
                        ((byte)(57)),
                        ((byte)(28))});


            resourceLookup.Add("ProductPhoto8", updatable.CreateResource("ProductPhoto", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductPhoto"));
            updatable.SetValue(resourceLookup["ProductPhoto8"], "ProductId", -2);
            updatable.SetValue(resourceLookup["ProductPhoto8"], "PhotoId", -2);
            updatable.SetValue(resourceLookup["ProductPhoto8"], "Photo", new byte[0]);


            resourceLookup.Add("ProductPhoto9", updatable.CreateResource("ProductPhoto", "Microsoft.Test.OData.Services.AstoriaDefaultService.ProductPhoto"));
            updatable.SetValue(resourceLookup["ProductPhoto9"], "ProductId", -1);
            updatable.SetValue(resourceLookup["ProductPhoto9"], "PhotoId", -1);
            updatable.SetValue(resourceLookup["ProductPhoto9"], "Photo", new byte[] {
                        ((byte)(194)),
                        ((byte)(53)),
                        ((byte)(254)),
                        ((byte)(37)),
                        ((byte)(176)),
                        ((byte)(255)),
                        ((byte)(122)),
                        ((byte)(202)),
                        ((byte)(172)),
                        ((byte)(4)),
                        ((byte)(246)),
                        ((byte)(248)),
                        ((byte)(16)),
                        ((byte)(180)),
                        ((byte)(209)),
                        ((byte)(89)),
                        ((byte)(208)),
                        ((byte)(253)),
                        ((byte)(206)),
                        ((byte)(187)),
                        ((byte)(215)),
                        ((byte)(134)),
                        ((byte)(94)),
                        ((byte)(92)),
                        ((byte)(195)),
                        ((byte)(115)),
                        ((byte)(219)),
                        ((byte)(182)),
                        ((byte)(138)),
                        ((byte)(81)),
                        ((byte)(25)),
                        ((byte)(47)),
                        ((byte)(246)),
                        ((byte)(194)),
                        ((byte)(198)),
                        ((byte)(98)),
                        ((byte)(60)),
                        ((byte)(66)),
                        ((byte)(159)),
                        ((byte)(82)),
                        ((byte)(109)),
                        ((byte)(9)),
                        ((byte)(8)),
                        ((byte)(113)),
                        ((byte)(0)),
                        ((byte)(38)),
                        ((byte)(174)),
                        ((byte)(117)),
                        ((byte)(22)),
                        ((byte)(52)),
                        ((byte)(225)),
                        ((byte)(203)),
                        ((byte)(117)),
                        ((byte)(156)),
                        ((byte)(236)),
                        ((byte)(59))});

        }

        private static void PopulateCustomerInfo(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {

            resourceLookup.Add("CustomerInfo0", updatable.CreateResource("CustomerInfo", "Microsoft.Test.OData.Services.AstoriaDefaultService.CustomerInfo"));
            updatable.SetValue(resourceLookup["CustomerInfo0"], "CustomerInfoId", -10);
            updatable.SetValue(resourceLookup["CustomerInfo0"], "Information", "び黑ポ畚ぜマチﾝハ歹黑ｚクｦﾈボァたグｦ黑ソЯ歹ぴせポｚゼ弌ぞせぜゼ亜Яクあソ亜ゼそせ珱ァタひグゼ縷яぁゾ黑マミ裹暦ポя");


            resourceLookup.Add("CustomerInfo1", updatable.CreateResource("CustomerInfo", "Microsoft.Test.OData.Services.AstoriaDefaultService.CustomerInfo"));
            updatable.SetValue(resourceLookup["CustomerInfo1"], "CustomerInfoId", -9);
            updatable.SetValue(resourceLookup["CustomerInfo1"], "Information", "frubhbngipuuveyneosslslbtrßqjujnssgcxuuzdbeußeaductgqbvhpussktbzzfuqvkxajzckmkzlu" +
                    "thcjsku");


            resourceLookup.Add("CustomerInfo2", updatable.CreateResource("CustomerInfo", "Microsoft.Test.OData.Services.AstoriaDefaultService.CustomerInfo"));
            updatable.SetValue(resourceLookup["CustomerInfo2"], "CustomerInfoId", -8);
            updatable.SetValue(resourceLookup["CustomerInfo2"], "Information", null);


            resourceLookup.Add("CustomerInfo3", updatable.CreateResource("CustomerInfo", "Microsoft.Test.OData.Services.AstoriaDefaultService.CustomerInfo"));
            updatable.SetValue(resourceLookup["CustomerInfo3"], "CustomerInfoId", -7);
            updatable.SetValue(resourceLookup["CustomerInfo3"], "Information", "縷ァゾ歹ﾝ裹ミミ九をソタボёﾈほひミバゼ畚Яソポ亜ほミぺまａタ畚弌匚ぞグぼそ畚ソﾝゼゼべチチぞミミゼマタ黑ダя縷縷珱せ亜ぴゾソ欲匚ハ九畚裹ハﾈё歹たゼソチほせびぜ" +
                    "ﾝゾ珱ぼﾈｦぼ九ぼ");


            resourceLookup.Add("CustomerInfo4", updatable.CreateResource("CustomerInfo", "Microsoft.Test.OData.Services.AstoriaDefaultService.CustomerInfo"));
            updatable.SetValue(resourceLookup["CustomerInfo4"], "CustomerInfoId", -6);
            updatable.SetValue(resourceLookup["CustomerInfo4"], "Information", "");


            resourceLookup.Add("CustomerInfo5", updatable.CreateResource("CustomerInfo", "Microsoft.Test.OData.Services.AstoriaDefaultService.CustomerInfo"));
            updatable.SetValue(resourceLookup["CustomerInfo5"], "CustomerInfoId", -5);
            updatable.SetValue(resourceLookup["CustomerInfo5"], "Information", "uuvoqobtxfgtnzugqjsocbhjkynsjafonxuxmcrnyldkxvpnuezalvpyhjpsmkgxacuruxtjruusxylnd" +
                    "zxgefpscvk");


            resourceLookup.Add("CustomerInfo6", updatable.CreateResource("CustomerInfo", "Microsoft.Test.OData.Services.AstoriaDefaultService.CustomerInfo"));
            updatable.SetValue(resourceLookup["CustomerInfo6"], "CustomerInfoId", -4);
            updatable.SetValue(resourceLookup["CustomerInfo6"], "Information", null);


            resourceLookup.Add("CustomerInfo7", updatable.CreateResource("CustomerInfo", "Microsoft.Test.OData.Services.AstoriaDefaultService.CustomerInfo"));
            updatable.SetValue(resourceLookup["CustomerInfo7"], "CustomerInfoId", -3);
            updatable.SetValue(resourceLookup["CustomerInfo7"], "Information", null);


            resourceLookup.Add("CustomerInfo8", updatable.CreateResource("CustomerInfo", "Microsoft.Test.OData.Services.AstoriaDefaultService.CustomerInfo"));
            updatable.SetValue(resourceLookup["CustomerInfo8"], "CustomerInfoId", -2);
            updatable.SetValue(resourceLookup["CustomerInfo8"], "Information", "ebmfxjikutjvmudp");


            resourceLookup.Add("CustomerInfo9", updatable.CreateResource("CustomerInfo", "Microsoft.Test.OData.Services.AstoriaDefaultService.CustomerInfo"));
            updatable.SetValue(resourceLookup["CustomerInfo9"], "CustomerInfoId", -1);
            updatable.SetValue(resourceLookup["CustomerInfo9"], "Information", "マびａゼミひグ暦タぽんミａソЯんクポをんЯダ珱ポぼａё九ぁｦЯべほ歹ァソぜボ縷ァﾝ弌バマ亜ぞミ暦ダダポソソボﾈたんまた匚ぞボ九チぽぜソぜぞチぺミ弌ｚんぺｚひ縷そぴ" +
                    "ぺべタまチ亜ハ珱びぞ暦ゾぜぺクёёゼ");

        }

        private static void PopulateComputer(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {

            resourceLookup.Add("Computer0", updatable.CreateResource("Computer", "Microsoft.Test.OData.Services.AstoriaDefaultService.Computer"));
            updatable.SetValue(resourceLookup["Computer0"], "ComputerId", -10);
            updatable.SetValue(resourceLookup["Computer0"], "Name", "ssgnpylqxlvzhhddkizabqurdokalozrmmvhcvmbdmjtkqirsgnxxclempdlklusmohumxap");


            resourceLookup.Add("Computer1", updatable.CreateResource("Computer", "Microsoft.Test.OData.Services.AstoriaDefaultService.Computer"));
            updatable.SetValue(resourceLookup["Computer1"], "ComputerId", -9);
            updatable.SetValue(resourceLookup["Computer1"], "Name", null);


            resourceLookup.Add("Computer2", updatable.CreateResource("Computer", "Microsoft.Test.OData.Services.AstoriaDefaultService.Computer"));
            updatable.SetValue(resourceLookup["Computer2"], "ComputerId", -8);
            updatable.SetValue(resourceLookup["Computer2"], "Name", "jiuxqefpxesahtftfnopfapumzdkkhy");


            resourceLookup.Add("Computer3", updatable.CreateResource("Computer", "Microsoft.Test.OData.Services.AstoriaDefaultService.Computer"));
            updatable.SetValue(resourceLookup["Computer3"], "ComputerId", -7);
            updatable.SetValue(resourceLookup["Computer3"], "Name", "nmtpkopimarxykztifuuhhpdbouyupijekgepffouavnyvuifvqnuenbyljgyqdyxdujoxuszrzhlaffy" +
                    "ipzylpavoioxzukryrq");


            resourceLookup.Add("Computer4", updatable.CreateResource("Computer", "Microsoft.Test.OData.Services.AstoriaDefaultService.Computer"));
            updatable.SetValue(resourceLookup["Computer4"], "ComputerId", -6);
            updatable.SetValue(resourceLookup["Computer4"], "Name", null);


            resourceLookup.Add("Computer5", updatable.CreateResource("Computer", "Microsoft.Test.OData.Services.AstoriaDefaultService.Computer"));
            updatable.SetValue(resourceLookup["Computer5"], "ComputerId", -5);
            updatable.SetValue(resourceLookup["Computer5"], "Name", "licaeurgfuooztfzjpuoqvysuntlvkrptixoulcupvltyrdz");


            resourceLookup.Add("Computer6", updatable.CreateResource("Computer", "Microsoft.Test.OData.Services.AstoriaDefaultService.Computer"));
            updatable.SetValue(resourceLookup["Computer6"], "ComputerId", -4);
            updatable.SetValue(resourceLookup["Computer6"], "Name", "sssbxzussltcchxgskdezzv");


            resourceLookup.Add("Computer7", updatable.CreateResource("Computer", "Microsoft.Test.OData.Services.AstoriaDefaultService.Computer"));
            updatable.SetValue(resourceLookup["Computer7"], "ComputerId", -3);
            updatable.SetValue(resourceLookup["Computer7"], "Name", "チ欲せあバя珱縷匚ダバｚポソぴソぜぴ亜я歹び暦ミママぞミぞひゼそぴソ畚ゾ畚ゼまボボﾈダぽソяミ黑あべひソそ裹ａグЯククａ裹ぞ九ボぞゾ九ぺチマチマ黑たゼ珱");


            resourceLookup.Add("Computer8", updatable.CreateResource("Computer", "Microsoft.Test.OData.Services.AstoriaDefaultService.Computer"));
            updatable.SetValue(resourceLookup["Computer8"], "ComputerId", -2);
            updatable.SetValue(resourceLookup["Computer8"], "Name", "hfbtpupssugßuxsuvhqsscssstlpoquzuhuratxpazfdmsszcssnuuvtdssbakptoknkaßss");


            resourceLookup.Add("Computer9", updatable.CreateResource("Computer", "Microsoft.Test.OData.Services.AstoriaDefaultService.Computer"));
            updatable.SetValue(resourceLookup["Computer9"], "ComputerId", -1);
            updatable.SetValue(resourceLookup["Computer9"], "Name", "xifstdltzpytkiufbpzuofuxnzuyyiazceilfmkqubusfqzuyfrmddtnxjutkmuxnyljapzpodzyojnya" +
                    "paphkqzcknxhq");

        }

        private static void PopulateComputerDetail(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {

            resourceLookup.Add("ComputerDetail0", updatable.CreateResource("ComputerDetail", "Microsoft.Test.OData.Services.AstoriaDefaultService.ComputerDetail"));
            updatable.SetValue(resourceLookup["ComputerDetail0"], "ComputerDetailId", -10);
            updatable.SetValue(resourceLookup["ComputerDetail0"], "Manufacturer", "sspayuqgmkizmvtxdeuitrnqcblxoipcsshhfvibxuzssatvjjhoftpk");
            updatable.SetValue(resourceLookup["ComputerDetail0"], "Model", "usfvbkyxssojjebyzgvtnzkuikßuxrmllzyglnsssluyxfßssioyroouxafzbhbsabkrsslbyhghicjap" +
                    "lolzqssßhhfix");
            updatable.SetValue(resourceLookup["ComputerDetail0"], "Serial", null);
            System.Collections.Generic.List<string> ComputerDetail0_SpecificationsBag = new System.Collections.Generic.List<string>();
            ComputerDetail0_SpecificationsBag.Add("vorjqalydmfuazkatkiydeicefrjhyuaupkfgbxiaehjrqhhqv");
            ComputerDetail0_SpecificationsBag.Add("rbsejgfgelhsdahkoqlnzvbq");
            ComputerDetail0_SpecificationsBag.Add("ssfvnnquahsczxlußnssrhpsszluundyßehyzjedssxom");
            ComputerDetail0_SpecificationsBag.Add("xsqocvqrzbvzhdhtilugpvayirrnomupxinhihazfghqehqymeeaupuesseluinjgbedrarqluedjfx");
            ComputerDetail0_SpecificationsBag.Add("eekuucympfgkucszfuggbmfglpnxnjvhkhalymhtfuggfafulkzedqlksoduqeyukzzhbbasjmee");
            ComputerDetail0_SpecificationsBag.Add("ゾを九クそ");
            updatable.SetValue(resourceLookup["ComputerDetail0"], "SpecificationsBag", ComputerDetail0_SpecificationsBag);
            updatable.SetValue(resourceLookup["ComputerDetail0"], "PurchaseDate", new System.DateTime(637435928158014568, System.DateTimeKind.Unspecified));
            resourceLookup.Add("Dimensions_8", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Dimensions"));
            updatable.SetValue(resourceLookup["Dimensions_8"], "Width", -8917.92836319839m);
            updatable.SetValue(resourceLookup["Dimensions_8"], "Height", -79228162514264337593543950335m);
            updatable.SetValue(resourceLookup["Dimensions_8"], "Depth", -79228162514264337593543950335m);
            updatable.SetValue(resourceLookup["ComputerDetail0"], "Dimensions", resourceLookup["Dimensions_8"]);


            resourceLookup.Add("ComputerDetail1", updatable.CreateResource("ComputerDetail", "Microsoft.Test.OData.Services.AstoriaDefaultService.ComputerDetail"));
            updatable.SetValue(resourceLookup["ComputerDetail1"], "ComputerDetailId", -9);
            updatable.SetValue(resourceLookup["ComputerDetail1"], "Manufacturer", "nrcqdahhufvckcifuzejooohckbidrdpjbmxvagdomlskttjqjmroukknuhtudooa");
            updatable.SetValue(resourceLookup["ComputerDetail1"], "Model", "bkuptdmngykrsjuunkprifanmjvjhrbykskzreglxvbvyiiudzjsumnxjbegjobqrlbazu");
            updatable.SetValue(resourceLookup["ComputerDetail1"], "Serial", "tciuqkgauh");
            System.Collections.Generic.List<string> ComputerDetail1_SpecificationsBag = new System.Collections.Generic.List<string>();
            ComputerDetail1_SpecificationsBag.Add("ひチダタяЯぜ暦ポチたゼ裹あ珱ソチ黑ボせ亜ァ弌ぽダチﾝゼｚ弌グぽ九ま歹ゼを黑ゾそЯﾝチタяぼチをひミ珱ク欲マひ暦匚ぽﾈソяマ珱畚ぴ縷ポボぺソたボソタせ亜匚まぼまЯ" +
                    "マほぺｚЯソぁぞёボёｚ");
            ComputerDetail1_SpecificationsBag.Add("orfonyermbydphalaqjfjpxujpkbtiq");
            ComputerDetail1_SpecificationsBag.Add("qessoseqmrtioktßoadquymvussskyzknnyxußnzßhszßbifbubrijurzidvjtpupbbmdpßapodci");
            updatable.SetValue(resourceLookup["ComputerDetail1"], "SpecificationsBag", ComputerDetail1_SpecificationsBag);
            updatable.SetValue(resourceLookup["ComputerDetail1"], "PurchaseDate", new System.DateTime(635125399205158670, System.DateTimeKind.Unspecified));
            resourceLookup.Add("Dimensions_9", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Dimensions"));
            updatable.SetValue(resourceLookup["Dimensions_9"], "Width", -81.4338167589288m);
            updatable.SetValue(resourceLookup["Dimensions_9"], "Height", 79228162514264337593543950335m);
            updatable.SetValue(resourceLookup["Dimensions_9"], "Depth", 20089724020667800000000000000m);
            updatable.SetValue(resourceLookup["ComputerDetail1"], "Dimensions", resourceLookup["Dimensions_9"]);


            resourceLookup.Add("ComputerDetail2", updatable.CreateResource("ComputerDetail", "Microsoft.Test.OData.Services.AstoriaDefaultService.ComputerDetail"));
            updatable.SetValue(resourceLookup["ComputerDetail2"], "ComputerDetailId", -8);
            updatable.SetValue(resourceLookup["ComputerDetail2"], "Manufacturer", "tnsspmxxlbnnmßitylxssttofßßcgqtpyziuopmpofrjhaxtjnsukykzzpdßpfmc");
            updatable.SetValue(resourceLookup["ComputerDetail2"], "Model", "ゼ欲ｦそグ畚ミボぁァ九ぽぞほ欲亜ａｦぞﾝソべぼタァタﾝ欲弌ソマ弌クぴんチバチゼハひ歹歹チ珱ﾈ珱クソ亜ま匚ソマぺぺチゼ亜歹畚裹歹バボｚ黑");
            updatable.SetValue(resourceLookup["ComputerDetail2"], "Serial", "gmlungqqgqpgaux");
            System.Collections.Generic.List<string> ComputerDetail2_SpecificationsBag = new System.Collections.Generic.List<string>();
            ComputerDetail2_SpecificationsBag.Add("ﾝぴ暦チミぽЯほａ");
            ComputerDetail2_SpecificationsBag.Add("jbpybyvpvxshobmtjspczucymaumnossdtbohcqgufbijhhkrbtuduxnyqgbodasuzigahhbechpnulon" +
                    "fuhfmkkvp");
            ComputerDetail2_SpecificationsBag.Add("ゾほダをゾａソァぁソん暦ハぞЯゼぽﾈ亜ぞぼバ暦ソボゼバゾバゾゼべボァチё畚ァぞぼせ弌タ歹タハミゼゾあハボゼボバ畚ゼそポせァａミチあぜひぼチﾈダａ珱タぁソせｦ裹ぁポ" +
                    "びяタ縷匚");
            updatable.SetValue(resourceLookup["ComputerDetail2"], "SpecificationsBag", ComputerDetail2_SpecificationsBag);
            updatable.SetValue(resourceLookup["ComputerDetail2"], "PurchaseDate", new System.DateTime(2419805615356650661, System.DateTimeKind.Unspecified));
            resourceLookup.Add("Dimensions_10", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Dimensions"));
            updatable.SetValue(resourceLookup["Dimensions_10"], "Width", -58480444791177000000000000000m);
            updatable.SetValue(resourceLookup["Dimensions_10"], "Height", 0m);
            updatable.SetValue(resourceLookup["Dimensions_10"], "Depth", -6309.05704131878m);
            updatable.SetValue(resourceLookup["ComputerDetail2"], "Dimensions", resourceLookup["Dimensions_10"]);


            resourceLookup.Add("ComputerDetail3", updatable.CreateResource("ComputerDetail", "Microsoft.Test.OData.Services.AstoriaDefaultService.ComputerDetail"));
            updatable.SetValue(resourceLookup["ComputerDetail3"], "ComputerDetailId", -7);
            updatable.SetValue(resourceLookup["ComputerDetail3"], "Manufacturer", "pebhzpduvypimernezuoqdclkpzfvugtotynulvjyonnbmgyviujuyxftqxg");
            updatable.SetValue(resourceLookup["ComputerDetail3"], "Model", "チ歹ｚ九そ");
            updatable.SetValue(resourceLookup["ComputerDetail3"], "Serial", "hbntrfzdaku");
            System.Collections.Generic.List<string> ComputerDetail3_SpecificationsBag = new System.Collections.Generic.List<string>();
            ComputerDetail3_SpecificationsBag.Add("縷バ欲たボゾ弌ﾈたタяグバボ珱匚ァボァソ");
            ComputerDetail3_SpecificationsBag.Add("ohßoqmbjqxtylfpzqpcjbrssfqurjapnknßsuqhukssohmyugltttymssjkkrl");
            ComputerDetail3_SpecificationsBag.Add("グёんをんゾハ欲まほゼ匚ソぁぽゼソ縷暦ぴマん縷ポａバチぼァｚ裹ポバひ亜ァべチソ珱裹裹ゼソソ九ソクびяべハポポせぁひボクミａァゾァァ九びんをａぴ裹ソｦま匚縷ゼ");
            ComputerDetail3_SpecificationsBag.Add("befsfayerumbrxm");
            ComputerDetail3_SpecificationsBag.Add("rmoecuforgdu");
            ComputerDetail3_SpecificationsBag.Add("ntdupetccpuqstet");
            ComputerDetail3_SpecificationsBag.Add("タボяた欲ゾゼびまチ亜タゼたёびぴまぼゾせｦァ裹ソゾべボ");
            updatable.SetValue(resourceLookup["ComputerDetail3"], "SpecificationsBag", ComputerDetail3_SpecificationsBag);
            updatable.SetValue(resourceLookup["ComputerDetail3"], "PurchaseDate", new System.DateTime(634890261980572040, System.DateTimeKind.Unspecified));
            resourceLookup.Add("Dimensions_11", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Dimensions"));
            updatable.SetValue(resourceLookup["Dimensions_11"], "Width", -37.3175203910811m);
            updatable.SetValue(resourceLookup["Dimensions_11"], "Height", -69.0031912433683m);
            updatable.SetValue(resourceLookup["Dimensions_11"], "Depth", -92.5056589278472m);
            updatable.SetValue(resourceLookup["ComputerDetail3"], "Dimensions", resourceLookup["Dimensions_11"]);


            resourceLookup.Add("ComputerDetail4", updatable.CreateResource("ComputerDetail", "Microsoft.Test.OData.Services.AstoriaDefaultService.ComputerDetail"));
            updatable.SetValue(resourceLookup["ComputerDetail4"], "ComputerDetailId", -6);
            updatable.SetValue(resourceLookup["ComputerDetail4"], "Manufacturer", "ゼバポポァミぼほせゼゼそぼポマ九グポほバまママせチ弌ソ裹ハチёёяほボぁバをﾈァａソクａハЯべЯゼひ");
            updatable.SetValue(resourceLookup["ComputerDetail4"], "Model", "cszninfhrmhhiaaqoirzrvgulnpk");
            updatable.SetValue(resourceLookup["ComputerDetail4"], "Serial", "mtassoecjenvxnczbavauapqjhuimssyyb");
            System.Collections.Generic.List<string> ComputerDetail4_SpecificationsBag = new System.Collections.Generic.List<string>();
            ComputerDetail4_SpecificationsBag.Add("Яあゾせ珱ほ畚そﾝソぴぽボゼゼマゼぴをａぞバチﾝｦマソびポボマタクチび");
            updatable.SetValue(resourceLookup["ComputerDetail4"], "SpecificationsBag", ComputerDetail4_SpecificationsBag);
            updatable.SetValue(resourceLookup["ComputerDetail4"], "PurchaseDate", new System.DateTime(1286483195567934984, System.DateTimeKind.Local));
            resourceLookup.Add("Dimensions_12", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Dimensions"));
            updatable.SetValue(resourceLookup["Dimensions_12"], "Width", 0.729486542069693m);
            updatable.SetValue(resourceLookup["Dimensions_12"], "Height", -5140.48762019928m);
            updatable.SetValue(resourceLookup["Dimensions_12"], "Depth", 79228162514264337593543950335m);
            updatable.SetValue(resourceLookup["ComputerDetail4"], "Dimensions", resourceLookup["Dimensions_12"]);


            resourceLookup.Add("ComputerDetail5", updatable.CreateResource("ComputerDetail", "Microsoft.Test.OData.Services.AstoriaDefaultService.ComputerDetail"));
            updatable.SetValue(resourceLookup["ComputerDetail5"], "ComputerDetailId", -5);
            updatable.SetValue(resourceLookup["ComputerDetail5"], "Manufacturer", "rssßqculezeixduciheinhynlbvvtßposspufcklssjgssljoofneqyraacvjlj");
            updatable.SetValue(resourceLookup["ComputerDetail5"], "Model", "ァａぞほそゾﾝ");
            updatable.SetValue(resourceLookup["ComputerDetail5"], "Serial", "bjhohikcpgrjynxluzeminvokzxbieyzmgtuhcifyiirpkbpbzuqummpmcqhudumhsx");
            System.Collections.Generic.List<string> ComputerDetail5_SpecificationsBag = new System.Collections.Generic.List<string>();
            ComputerDetail5_SpecificationsBag.Add("mvspakulasc");
            ComputerDetail5_SpecificationsBag.Add("doztuconqopxmdxmpvovntiymogsqpydeqonxtnuzzbnziyxpjogvcfkeebavgyaugvvodpucdvnnkyjb" +
                    "koblmhtfql");
            ComputerDetail5_SpecificationsBag.Add("ssqebjqdeufxfophszpouvjdtmqssemlvvcrgdnhegbusvhbkvjruztvun");
            ComputerDetail5_SpecificationsBag.Add("tqblflaekcoolmtmqsjgfuopxrvejxtxcrcqzpgdfozmdlcgxbiuxygplnpppzpmjbvt");
            ComputerDetail5_SpecificationsBag.Add("eguabbmfgjlobuzafgpuhzspgkhiipketpajrxohydcuoujskbmjqzuipm");
            ComputerDetail5_SpecificationsBag.Add("ソぺミｦソァチ匚ダをゼぴぺぺたマチゾダぁポボ畚ぜёゼ欲ゾｦ欲ひぽゼボソёダほポソ畚ｦａ黑たほソ九яグあぁそポぞ歹ァボａあタせ欲ミぞた匚バ亜ぜひァ歹あびママｦｦ弌");
            updatable.SetValue(resourceLookup["ComputerDetail5"], "SpecificationsBag", ComputerDetail5_SpecificationsBag);
            updatable.SetValue(resourceLookup["ComputerDetail5"], "PurchaseDate", new System.DateTime(1207841221358349474, System.DateTimeKind.Unspecified));
            resourceLookup.Add("Dimensions_13", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Dimensions"));
            updatable.SetValue(resourceLookup["Dimensions_13"], "Width", 79228162514264337593543950335m);
            updatable.SetValue(resourceLookup["Dimensions_13"], "Height", -0.120265810129064m);
            updatable.SetValue(resourceLookup["Dimensions_13"], "Depth", 0.158033624247527m);
            updatable.SetValue(resourceLookup["ComputerDetail5"], "Dimensions", resourceLookup["Dimensions_13"]);


            resourceLookup.Add("ComputerDetail6", updatable.CreateResource("ComputerDetail", "Microsoft.Test.OData.Services.AstoriaDefaultService.ComputerDetail"));
            updatable.SetValue(resourceLookup["ComputerDetail6"], "ComputerDetailId", -4);
            updatable.SetValue(resourceLookup["ComputerDetail6"], "Manufacturer", "んゼｚぴ裹マゼソまﾝグポяたそァァバｦミんЯひソ珱ゾЯチぺ匚裹せ弌クソぼボａマハべボべボグソあ亜ゾん匚びグそクんぼタァゼマ歹べゾせま珱ポポ");
            updatable.SetValue(resourceLookup["ComputerDetail6"], "Model", "hmrvmejjdizßttrßußipfzhksnipjipphdßqsmtkssakufmgnbrmyqxplocissßvaulfqktefrcrqfkqo" +
                    "bbmjtptßn");
            updatable.SetValue(resourceLookup["ComputerDetail6"], "Serial", "juloßddßyzxohxqßbfamozukjdpugivbpyclumfbgoff");
            System.Collections.Generic.List<string> ComputerDetail6_SpecificationsBag = new System.Collections.Generic.List<string>();
            ComputerDetail6_SpecificationsBag.Add("iahglssgmaastsmrvoqnmpuvraxbßpkuuzyrfsktqntkovpmvllbesyossbsgrugzncnxxygi");
            ComputerDetail6_SpecificationsBag.Add("ｦ畚マポ珱ソァゼタぜぼミソяミミぜЯぜあ珱ぴ欲裹縷ぽ九ポａそゼタた匚裹ぽぺタ珱裹んク欲欲をタそ暦ぜたぼぜチ欲あ亜ぁ弌匚ハマポソゼミミハポぞソゾチひべ亜ゾグﾝハグひ" +
                    "ｚチ匚珱まｦんマぞぺソ亜ぽ");
            ComputerDetail6_SpecificationsBag.Add("jipzkrrqssshephebjktisnjudssßcivyßoqßyaksdzuugpdotucgxknbyrvrlsjnyehssßjubsstlunh" +
                    "ibaxdexk");
            ComputerDetail6_SpecificationsBag.Add("jicbvcpmpffbfufaajoßhrlpqqrkhtjßxhnfssßulyrssivßssssevess");
            ComputerDetail6_SpecificationsBag.Add("ppnomuovvdgynaeebnirqgtpyzkfxgedutqfhayslibkntiyztufkkicuybnquzlcisufspbqguno");
            ComputerDetail6_SpecificationsBag.Add("xmgolrtrrjkjtfe");
            ComputerDetail6_SpecificationsBag.Add("ckacpboppifkilxerijuzmfeivcujgdjjjemopyozxerhbgzmrnzcdsquyuszyuduvaqjfyio");
            updatable.SetValue(resourceLookup["ComputerDetail6"], "SpecificationsBag", ComputerDetail6_SpecificationsBag);
            updatable.SetValue(resourceLookup["ComputerDetail6"], "PurchaseDate", new System.DateTime(0, System.DateTimeKind.Unspecified));
            resourceLookup.Add("Dimensions_14", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Dimensions"));
            updatable.SetValue(resourceLookup["Dimensions_14"], "Width", 17.6449969193499m);
            updatable.SetValue(resourceLookup["Dimensions_14"], "Height", -0.107216178123447m);
            updatable.SetValue(resourceLookup["Dimensions_14"], "Depth", -0.942386961854372m);
            updatable.SetValue(resourceLookup["ComputerDetail6"], "Dimensions", resourceLookup["Dimensions_14"]);


            resourceLookup.Add("ComputerDetail7", updatable.CreateResource("ComputerDetail", "Microsoft.Test.OData.Services.AstoriaDefaultService.ComputerDetail"));
            updatable.SetValue(resourceLookup["ComputerDetail7"], "ComputerDetailId", -3);
            updatable.SetValue(resourceLookup["ComputerDetail7"], "Manufacturer", "ダゾ匚");
            updatable.SetValue(resourceLookup["ComputerDetail7"], "Model", "ßuptoqpxaxgumociorssgi");
            updatable.SetValue(resourceLookup["ComputerDetail7"], "Serial", "qpkuoacjgosjunmrezluvuxfhqqt");
            System.Collections.Generic.List<string> ComputerDetail7_SpecificationsBag = new System.Collections.Generic.List<string>();
            ComputerDetail7_SpecificationsBag.Add("jjjaizvuiruzkqyihnaufzjlsujkfkbb");
            ComputerDetail7_SpecificationsBag.Add("tunqioseoazvttphpigßlazdssnhlqlssaisczxßsssqssdlxgsutiqorjmscfrntbjreztelrmqoqhnt" +
                    "kjpxqumyvgrunsnfj");
            updatable.SetValue(resourceLookup["ComputerDetail7"], "SpecificationsBag", ComputerDetail7_SpecificationsBag);
            updatable.SetValue(resourceLookup["ComputerDetail7"], "PurchaseDate", new System.DateTime(1491337916072835937, System.DateTimeKind.Local));
            resourceLookup.Add("Dimensions_15", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Dimensions"));
            updatable.SetValue(resourceLookup["Dimensions_15"], "Width", -96.5579925725669m);
            updatable.SetValue(resourceLookup["Dimensions_15"], "Height", -74655147326547200000000000000m);
            updatable.SetValue(resourceLookup["Dimensions_15"], "Depth", 0m);
            updatable.SetValue(resourceLookup["ComputerDetail7"], "Dimensions", resourceLookup["Dimensions_15"]);


            resourceLookup.Add("ComputerDetail8", updatable.CreateResource("ComputerDetail", "Microsoft.Test.OData.Services.AstoriaDefaultService.ComputerDetail"));
            updatable.SetValue(resourceLookup["ComputerDetail8"], "ComputerDetailId", -2);
            updatable.SetValue(resourceLookup["ComputerDetail8"], "Manufacturer", "nbhcxgssfessssakdßvsnkcpknqapexniucfxfßx");
            updatable.SetValue(resourceLookup["ComputerDetail8"], "Model", "szjtntvbuqpjduipsbcdotzurrnyaz");
            updatable.SetValue(resourceLookup["ComputerDetail8"], "Serial", "vjoujsbnrjitaabgepkzuzacexbybutvcgzqlxslelelixqnrqycfcsvjvtmmcgvpcmqemuovzxqxkuub" +
                    "pbmxllanibqo");
            System.Collections.Generic.List<string> ComputerDetail8_SpecificationsBag = new System.Collections.Generic.List<string>();
            ComputerDetail8_SpecificationsBag.Add("べ縷欲クﾝタび歹匚ゼァァせｚ");
            ComputerDetail8_SpecificationsBag.Add("ァａぁ暦ｚそミタせﾈァひﾝポёせタマバク弌ぺそя九ぞぞぴポタたをЯタ縷Я九ァぽ匚ぜ歹黑ダ珱ポ弌九まぽチぼァを欲そ欲яあ暦ﾈタ");
            updatable.SetValue(resourceLookup["ComputerDetail8"], "SpecificationsBag", ComputerDetail8_SpecificationsBag);
            updatable.SetValue(resourceLookup["ComputerDetail8"], "PurchaseDate", new System.DateTime(634972389971297507, System.DateTimeKind.Unspecified));
            resourceLookup.Add("Dimensions_16", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Dimensions"));
            updatable.SetValue(resourceLookup["Dimensions_16"], "Width", -69765862922749200000000000000m);
            updatable.SetValue(resourceLookup["Dimensions_16"], "Height", -4968.12080960743m);
            updatable.SetValue(resourceLookup["Dimensions_16"], "Depth", 79228162514264337593543950335m);
            updatable.SetValue(resourceLookup["ComputerDetail8"], "Dimensions", resourceLookup["Dimensions_16"]);


            resourceLookup.Add("ComputerDetail9", updatable.CreateResource("ComputerDetail", "Microsoft.Test.OData.Services.AstoriaDefaultService.ComputerDetail"));
            updatable.SetValue(resourceLookup["ComputerDetail9"], "ComputerDetailId", -1);
            updatable.SetValue(resourceLookup["ComputerDetail9"], "Manufacturer", "cybsycxhjrazcaxf");
            updatable.SetValue(resourceLookup["ComputerDetail9"], "Model", "mfhgyißxesckygsslbksqvcpohjienkcfbtrssp");
            updatable.SetValue(resourceLookup["ComputerDetail9"], "Serial", "あァミゾダぜ裹あゼぞん匚畚バをミぼｦソﾝ裹ぽハゾ黑ぼび");
            System.Collections.Generic.List<string> ComputerDetail9_SpecificationsBag = new System.Collections.Generic.List<string>();
            ComputerDetail9_SpecificationsBag.Add("チ欲ァミ畚珱ボ欲をぴﾝたァ黑タァそクほァ黑ゼ畚グ弌亜ほチをａべあタ");
            ComputerDetail9_SpecificationsBag.Add("タ縷ソ畚ボたひ暦裹ぞぽチグａぁァ亜チゼひｚﾈａぜボёタグﾈ黑バタびチ弌ほ黑グマ亜ぼあソポゾポべク畚畚をｦグチЯチｚァほチボ匚欲ﾝタミゼ弌ぞ欲ゼゼ畚ポ裹縷ゾぼバｦ歹" +
                    "ひゾそボポひボチほまハぞそたソ");
            ComputerDetail9_SpecificationsBag.Add("udjcekzitroessd");
            ComputerDetail9_SpecificationsBag.Add("shxnubznxdumkraixsjsskrspkss");
            ComputerDetail9_SpecificationsBag.Add("vugqblidbkbfkppfbbkanvnflueqdousryyhhucoxtpbbnyeecbsauzaceu");
            ComputerDetail9_SpecificationsBag.Add("aerlqnsczhßgivchizyapazitnsszugryqlupnußjgxg");
            ComputerDetail9_SpecificationsBag.Add("あべ暦裹ｚぽタゾ歹яひチミせチ亜あチ九ぞミボёボ暦ァ黑ソポ匚ポあァせソ亜ぞぼゼグァたボ九ゼﾈя裹歹バ亜亜ぜバａソびひせバァあ歹あァぜ");
            updatable.SetValue(resourceLookup["ComputerDetail9"], "SpecificationsBag", ComputerDetail9_SpecificationsBag);
            updatable.SetValue(resourceLookup["ComputerDetail9"], "PurchaseDate", new System.DateTime(3155378975999999999, System.DateTimeKind.Unspecified));
            resourceLookup.Add("Dimensions_17", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Dimensions"));
            updatable.SetValue(resourceLookup["Dimensions_17"], "Width", -69.6411071913679m);
            updatable.SetValue(resourceLookup["Dimensions_17"], "Height", 1451.59900018645m);
            updatable.SetValue(resourceLookup["Dimensions_17"], "Depth", -79228162514264337593543950335m);
            updatable.SetValue(resourceLookup["ComputerDetail9"], "Dimensions", resourceLookup["Dimensions_17"]);

        }

        private static void PopulateDriver(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {

            resourceLookup.Add("Driver0", updatable.CreateResource("Driver", "Microsoft.Test.OData.Services.AstoriaDefaultService.Driver"));
            updatable.SetValue(resourceLookup["Driver0"], "Name", "1");
            updatable.SetValue(resourceLookup["Driver0"], "BirthDate", new System.DateTime(1648541694587530184, System.DateTimeKind.Local));


            resourceLookup.Add("Driver1", updatable.CreateResource("Driver", "Microsoft.Test.OData.Services.AstoriaDefaultService.Driver"));
            updatable.SetValue(resourceLookup["Driver1"], "Name", "2");
            updatable.SetValue(resourceLookup["Driver1"], "BirthDate", new System.DateTime(634768916866217744, System.DateTimeKind.Unspecified));


            resourceLookup.Add("Driver2", updatable.CreateResource("Driver", "Microsoft.Test.OData.Services.AstoriaDefaultService.Driver"));
            updatable.SetValue(resourceLookup["Driver2"], "Name", "3");
            updatable.SetValue(resourceLookup["Driver2"], "BirthDate", new System.DateTime(0, System.DateTimeKind.Unspecified));


            resourceLookup.Add("Driver3", updatable.CreateResource("Driver", "Microsoft.Test.OData.Services.AstoriaDefaultService.Driver"));
            updatable.SetValue(resourceLookup["Driver3"], "Name", "4");
            updatable.SetValue(resourceLookup["Driver3"], "BirthDate", new System.DateTime(3155378975999999999, System.DateTimeKind.Unspecified));


            resourceLookup.Add("Driver4", updatable.CreateResource("Driver", "Microsoft.Test.OData.Services.AstoriaDefaultService.Driver"));
            updatable.SetValue(resourceLookup["Driver4"], "Name", "5");
            updatable.SetValue(resourceLookup["Driver4"], "BirthDate", new System.DateTime(467394024211878720, System.DateTimeKind.Unspecified));


            resourceLookup.Add("Driver5", updatable.CreateResource("Driver", "Microsoft.Test.OData.Services.AstoriaDefaultService.Driver"));
            updatable.SetValue(resourceLookup["Driver5"], "Name", "6");
            updatable.SetValue(resourceLookup["Driver5"], "BirthDate", new System.DateTime(1331808236889702088, System.DateTimeKind.Local));


            resourceLookup.Add("Driver6", updatable.CreateResource("Driver", "Microsoft.Test.OData.Services.AstoriaDefaultService.Driver"));
            updatable.SetValue(resourceLookup["Driver6"], "Name", "7");
            updatable.SetValue(resourceLookup["Driver6"], "BirthDate", new System.DateTime(359253517267870698, System.DateTimeKind.Local));


            resourceLookup.Add("Driver7", updatable.CreateResource("Driver", "Microsoft.Test.OData.Services.AstoriaDefaultService.Driver"));
            updatable.SetValue(resourceLookup["Driver7"], "Name", "8");
            updatable.SetValue(resourceLookup["Driver7"], "BirthDate", new System.DateTime(635064633228263943, System.DateTimeKind.Unspecified));


            resourceLookup.Add("Driver8", updatable.CreateResource("Driver", "Microsoft.Test.OData.Services.AstoriaDefaultService.Driver"));
            updatable.SetValue(resourceLookup["Driver8"], "Name", "9");
            updatable.SetValue(resourceLookup["Driver8"], "BirthDate", new System.DateTime(1152630070391887760, System.DateTimeKind.Local));


            resourceLookup.Add("Driver9", updatable.CreateResource("Driver", "Microsoft.Test.OData.Services.AstoriaDefaultService.Driver"));
            updatable.SetValue(resourceLookup["Driver9"], "Name", "10");
            updatable.SetValue(resourceLookup["Driver9"], "BirthDate", new System.DateTime(635046048763579371, System.DateTimeKind.Unspecified));

        }

        private static void PopulateLicense(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {

            resourceLookup.Add("License0", updatable.CreateResource("License", "Microsoft.Test.OData.Services.AstoriaDefaultService.License"));
            updatable.SetValue(resourceLookup["License0"], "Name", "1");
            updatable.SetValue(resourceLookup["License0"], "LicenseNumber", "黑ミゼあァまクグミクソё黑をァ九ﾝほボ暦グぴんそクマポぜポﾝ欲ぞぴゼ");
            updatable.SetValue(resourceLookup["License0"], "LicenseClass", "vumruysjdifepjazzrhdrpndrrmfulpjqlgtcqeghxhmsn");
            updatable.SetValue(resourceLookup["License0"], "Restrictions", "jyktsbbczjhhnskvhiibrd");
            updatable.SetValue(resourceLookup["License0"], "ExpirationDate", new System.DateTime(75921225906680628, System.DateTimeKind.Unspecified));


            resourceLookup.Add("License1", updatable.CreateResource("License", "Microsoft.Test.OData.Services.AstoriaDefaultService.License"));
            updatable.SetValue(resourceLookup["License1"], "Name", "2");
            updatable.SetValue(resourceLookup["License1"], "LicenseNumber", "iexuhzerfpssj");
            updatable.SetValue(resourceLookup["License1"], "LicenseClass", "jtphxihsbkvevphumnbtzfgsejgreouozcsvqbbapeyxeauqusvdzkyijxgkrqredsenvmlfgbuyhkrap" +
                    "rlddxokdqjtvsd");
            updatable.SetValue(resourceLookup["License1"], "Restrictions", "まｦべ弌ポほダ裹弌んЯミｚべァ欲Яひゼ弌ゼバチんぺそ九ゾボ裹ほチタ畚ゼあソ裹縷ぁミЯクぴまｚゾチタａま匚ｦせべマゼ縷チタ");
            updatable.SetValue(resourceLookup["License1"], "ExpirationDate", new System.DateTime(1103165931078149276, System.DateTimeKind.Unspecified));


            resourceLookup.Add("License2", updatable.CreateResource("License", "Microsoft.Test.OData.Services.AstoriaDefaultService.License"));
            updatable.SetValue(resourceLookup["License2"], "Name", "3");
            updatable.SetValue(resourceLookup["License2"], "LicenseNumber", "九をЯぼ欲裹ボソバタ暦マぼ裹ソぁぞぁボﾝ縷欲ぼゼをﾝグたミ九ミ縷ﾈﾈ黑縷タ匚ァａァぺびソをマ珱マゼバタまた黑マ黑ぁハ");
            updatable.SetValue(resourceLookup["License2"], "LicenseClass", "tyvzsdßpmgtsrrrvoportobktefßxssvmjxlfrhßpsxibnkda");
            updatable.SetValue(resourceLookup["License2"], "Restrictions", "sxuqrhbrßßtpmbfxbgotpnßyeayfvdtpkkvne");
            updatable.SetValue(resourceLookup["License2"], "ExpirationDate", new System.DateTime(635091470054322336, System.DateTimeKind.Unspecified));


            resourceLookup.Add("License3", updatable.CreateResource("License", "Microsoft.Test.OData.Services.AstoriaDefaultService.License"));
            updatable.SetValue(resourceLookup["License3"], "Name", "4");
            updatable.SetValue(resourceLookup["License3"], "LicenseNumber", null);
            updatable.SetValue(resourceLookup["License3"], "LicenseClass", "");
            updatable.SetValue(resourceLookup["License3"], "Restrictions", "をボまぺぞぺんぁｚタｚポソぴｚ匚チをソゼｚァあぺひｚババяチバチチぜボタ歹ぴ九歹ﾝａゼぜ畚黑ダバそぜソべぁぼボｦチぁぁ");
            updatable.SetValue(resourceLookup["License3"], "ExpirationDate", new System.DateTime(0, System.DateTimeKind.Unspecified));


            resourceLookup.Add("License4", updatable.CreateResource("License", "Microsoft.Test.OData.Services.AstoriaDefaultService.License"));
            updatable.SetValue(resourceLookup["License4"], "Name", "5");
            updatable.SetValue(resourceLookup["License4"], "LicenseNumber", "uuttheuhurrzscujpibuolß");
            updatable.SetValue(resourceLookup["License4"], "LicenseClass", "ハんハяЯぺまａんソハポべを九畚グゼボせﾈ珱ゼぞダёべせマ暦ぜ匚グソチぁチボボマゼまソﾝﾝゼﾝ珱ゼバチぺァ黑ボ九ａソゾﾈЯ");
            updatable.SetValue(resourceLookup["License4"], "Restrictions", "vfutsfuusssshjooegsicykkvvooursbeß");
            updatable.SetValue(resourceLookup["License4"], "ExpirationDate", new System.DateTime(136781229791597526, System.DateTimeKind.Unspecified));


            resourceLookup.Add("License5", updatable.CreateResource("License", "Microsoft.Test.OData.Services.AstoriaDefaultService.License"));
            updatable.SetValue(resourceLookup["License5"], "Name", "6");
            updatable.SetValue(resourceLookup["License5"], "LicenseNumber", "acaguebmllxbmtedjiknslczfkzeuezlvgqghokgjccntgzqu");
            updatable.SetValue(resourceLookup["License5"], "LicenseClass", "mtmaeageujkmhguoszfqiumdrbssmfcpimßgquggiugdxvijavnosryl");
            updatable.SetValue(resourceLookup["License5"], "Restrictions", "viusyugahamygmbjsvqjmsxrsixjpkygyzkzf");
            updatable.SetValue(resourceLookup["License5"], "ExpirationDate", new System.DateTime(1956961385961745520, System.DateTimeKind.Local));


            resourceLookup.Add("License6", updatable.CreateResource("License", "Microsoft.Test.OData.Services.AstoriaDefaultService.License"));
            updatable.SetValue(resourceLookup["License6"], "Name", "7");
            updatable.SetValue(resourceLookup["License6"], "LicenseNumber", "tbpkekriyemhebdmzvsfgdqtluzoopgvcrhxl");
            updatable.SetValue(resourceLookup["License6"], "LicenseClass", null);
            updatable.SetValue(resourceLookup["License6"], "Restrictions", "ｚゼハａミ匚ｦぺソｚゼ欲ﾝゾタ欲ｦ縷タハﾝァママひァ弌クяａぺぴチ九クまべハソびひ裹たゼソゼミ黑ゼミせ亜ёぴボバマ縷亜ゼﾝハべ");
            updatable.SetValue(resourceLookup["License6"], "ExpirationDate", new System.DateTime(634724316088320793, System.DateTimeKind.Unspecified));


            resourceLookup.Add("License7", updatable.CreateResource("License", "Microsoft.Test.OData.Services.AstoriaDefaultService.License"));
            updatable.SetValue(resourceLookup["License7"], "Name", "8");
            updatable.SetValue(resourceLookup["License7"], "LicenseNumber", "ßpificvntqkssrjssphgkgsyjzssibohmßllffucvjiuvxshussyzutbbiuiubhßasubqßkhovgpzhnye" +
                    "tmuugc");
            updatable.SetValue(resourceLookup["License7"], "LicenseClass", "ゼそべЯぁソゼせぜボボあゼをチミそ弌たぽ歹ゾをяソマべ");
            updatable.SetValue(resourceLookup["License7"], "Restrictions", "jysaczvfomdkckroypqojrmkzxbphcpjrsbbsdgvfmauneepungdegmugdojtczzzyvnckkpcvvzruyyu" +
                    "pvvzghgukyjuzii");
            updatable.SetValue(resourceLookup["License7"], "ExpirationDate", new System.DateTime(2688091156667882427, System.DateTimeKind.Unspecified));


            resourceLookup.Add("License8", updatable.CreateResource("License", "Microsoft.Test.OData.Services.AstoriaDefaultService.License"));
            updatable.SetValue(resourceLookup["License8"], "Name", "9");
            updatable.SetValue(resourceLookup["License8"], "LicenseNumber", "mvhfbnmjsssjußebcrzaeilzxmlpxlß");
            updatable.SetValue(resourceLookup["License8"], "LicenseClass", "ytacvzjkrcnedhobzlimcaxlsrzqyrtvsnihbhee");
            updatable.SetValue(resourceLookup["License8"], "Restrictions", "ぼソべびマぼﾝボゼゾび裹縷ゾソひﾈミチﾝソミァマまミяチゾあ裹ポぼほぽんゾ暦ﾝマミびソぼゼべタマｚ縷ぁ黑я弌ほダそタ裹ﾈぺゼぞクチタポ");
            updatable.SetValue(resourceLookup["License8"], "ExpirationDate", new System.DateTime(453283107856026948, System.DateTimeKind.Unspecified));


            resourceLookup.Add("License9", updatable.CreateResource("License", "Microsoft.Test.OData.Services.AstoriaDefaultService.License"));
            updatable.SetValue(resourceLookup["License9"], "Name", "10");
            updatable.SetValue(resourceLookup["License9"], "LicenseNumber", "ßcoyuetvqgozkmyuzulzouprkrrizmofiyurvtfqupdbniyouelssßltcrlkihqyobvxnhbssuyyunmji" +
                    "hvnssya");
            updatable.SetValue(resourceLookup["License9"], "LicenseClass", "ssagfbcotoßud");
            updatable.SetValue(resourceLookup["License9"], "Restrictions", "ァあぞァぴミぽゼあ");
            updatable.SetValue(resourceLookup["License9"], "ExpirationDate", new System.DateTime(3155378975999999999, System.DateTimeKind.Unspecified));

        }

        private static void PopulateMappedEntityType(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {

            resourceLookup.Add("MappedEntityType0", updatable.CreateResource("MappedEntityType", "Microsoft.Test.OData.Services.AstoriaDefaultService.MappedEntityType"));
            updatable.SetValue(resourceLookup["MappedEntityType0"], "Id", -10);
            updatable.SetValue(resourceLookup["MappedEntityType0"], "Href", "offsetrefusepowerpersonallocalmappedstyleinitobj");
            updatable.SetValue(resourceLookup["MappedEntityType0"], "Title", "conditionaltodaydecisionconfigurationhexinteger");
            updatable.SetValue(resourceLookup["MappedEntityType0"], "HrefLang", "platformdocumentsdecryptorsizeshmacweekoncefirst");
            updatable.SetValue(resourceLookup["MappedEntityType0"], "Type", "erastobjcustscreensharebindingmismatchcodesmacrobrowsablecriteriamapfeatureinequa" +
                    "lityiidpacking");
            updatable.SetValue(resourceLookup["MappedEntityType0"], "Length", 131);
            System.Collections.Generic.List<string> MappedEntityType0_BagOfPrimitiveToLinks = new System.Collections.Generic.List<string>();
            MappedEntityType0_BagOfPrimitiveToLinks.Add("ァゼぴ匚んマёひぽ黑ぞァぴゼぜぞボぼａﾈぽぞａ暦ゼ匚あﾝぽ黑亜珱あ");
            updatable.SetValue(resourceLookup["MappedEntityType0"], "BagOfPrimitiveToLinks", MappedEntityType0_BagOfPrimitiveToLinks);
            updatable.SetValue(resourceLookup["MappedEntityType0"], "Logo", new byte[] {
                        ((byte)(195)),
                        ((byte)(212)),
                        ((byte)(213)),
                        ((byte)(13)),
                        ((byte)(11)),
                        ((byte)(64)),
                        ((byte)(106)),
                        ((byte)(74)),
                        ((byte)(16)),
                        ((byte)(107))});
            System.Collections.Generic.List<decimal> MappedEntityType0_BagOfDecimals = new System.Collections.Generic.List<decimal>();
            MappedEntityType0_BagOfDecimals.Add(3153.09837524813m);
            MappedEntityType0_BagOfDecimals.Add(-9722.00954692332m);
            MappedEntityType0_BagOfDecimals.Add(-0.589368370856242m);
            MappedEntityType0_BagOfDecimals.Add(-28792308624934300000000000000m);
            MappedEntityType0_BagOfDecimals.Add(-79228162514264337593543950335m);
            updatable.SetValue(resourceLookup["MappedEntityType0"], "BagOfDecimals", MappedEntityType0_BagOfDecimals);
            System.Collections.Generic.List<double> MappedEntityType0_BagOfDoubles = new System.Collections.Generic.List<double>();
            MappedEntityType0_BagOfDoubles.Add(-1.7976931348623157E+308D);
            MappedEntityType0_BagOfDoubles.Add(1.7976931348623157E+308D);
            MappedEntityType0_BagOfDoubles.Add(-58.374138879167482D);
            updatable.SetValue(resourceLookup["MappedEntityType0"], "BagOfDoubles", MappedEntityType0_BagOfDoubles);
            System.Collections.Generic.List<float> MappedEntityType0_BagOfSingles = new System.Collections.Generic.List<float>();
            MappedEntityType0_BagOfSingles.Add(-3.40282346638529E+38F);
            MappedEntityType0_BagOfSingles.Add(-3.60274514960752E+37F);
            MappedEntityType0_BagOfSingles.Add(-0.5991438F);
            MappedEntityType0_BagOfSingles.Add(-0.676722466945648F);
            updatable.SetValue(resourceLookup["MappedEntityType0"], "BagOfSingles", MappedEntityType0_BagOfSingles);
            System.Collections.Generic.List<byte> MappedEntityType0_BagOfBytes = new System.Collections.Generic.List<byte>();
            MappedEntityType0_BagOfBytes.Add(((byte)(214)));
            MappedEntityType0_BagOfBytes.Add(((byte)(32)));
            MappedEntityType0_BagOfBytes.Add(((byte)(134)));
            updatable.SetValue(resourceLookup["MappedEntityType0"], "BagOfBytes", MappedEntityType0_BagOfBytes);
            System.Collections.Generic.List<short> MappedEntityType0_BagOfInt16s = new System.Collections.Generic.List<short>();
            updatable.SetValue(resourceLookup["MappedEntityType0"], "BagOfInt16s", MappedEntityType0_BagOfInt16s);
            System.Collections.Generic.List<int> MappedEntityType0_BagOfInt32s = new System.Collections.Generic.List<int>();
            MappedEntityType0_BagOfInt32s.Add(-2147483648);
            MappedEntityType0_BagOfInt32s.Add(-3488);
            MappedEntityType0_BagOfInt32s.Add(-43);
            MappedEntityType0_BagOfInt32s.Add(2147483647);
            MappedEntityType0_BagOfInt32s.Add(3020);
            MappedEntityType0_BagOfInt32s.Add(0);
            MappedEntityType0_BagOfInt32s.Add(-94);
            MappedEntityType0_BagOfInt32s.Add(1466);
            updatable.SetValue(resourceLookup["MappedEntityType0"], "BagOfInt32s", MappedEntityType0_BagOfInt32s);
            System.Collections.Generic.List<long> MappedEntityType0_BagOfInt64s = new System.Collections.Generic.List<long>();
            MappedEntityType0_BagOfInt64s.Add(((long)(-45)));
            MappedEntityType0_BagOfInt64s.Add(((long)(-4726994273938710528)));
            MappedEntityType0_BagOfInt64s.Add(((long)(20)));
            MappedEntityType0_BagOfInt64s.Add(((long)(50)));
            MappedEntityType0_BagOfInt64s.Add(((long)(12)));
            MappedEntityType0_BagOfInt64s.Add(((long)(88)));
            MappedEntityType0_BagOfInt64s.Add(((long)(-9223372036854775808)));
            MappedEntityType0_BagOfInt64s.Add(((long)(8)));
            MappedEntityType0_BagOfInt64s.Add(((long)(9223372036854775807)));
            updatable.SetValue(resourceLookup["MappedEntityType0"], "BagOfInt64s", MappedEntityType0_BagOfInt64s);
            System.Collections.Generic.List<System.Guid> MappedEntityType0_BagOfGuids = new System.Collections.Generic.List<System.Guid>();
            MappedEntityType0_BagOfGuids.Add(new System.Guid("6c9a5fd9-3917-4b4c-b34a-9d997278244f"));
            MappedEntityType0_BagOfGuids.Add(new System.Guid("f400eac0-c36b-494e-af03-283858961b23"));
            MappedEntityType0_BagOfGuids.Add(new System.Guid("aa163e19-511c-4f3a-b8cb-a07b55e88a6e"));
            MappedEntityType0_BagOfGuids.Add(new System.Guid("7c473a19-ac27-4dc1-8b85-1c749836bff1"));
            MappedEntityType0_BagOfGuids.Add(new System.Guid("14fa5efc-9d18-45d0-856c-3904fb1fbed4"));
            MappedEntityType0_BagOfGuids.Add(new System.Guid("380c8f81-cb59-4179-945d-9e9c769bf4c5"));
            MappedEntityType0_BagOfGuids.Add(new System.Guid("a9db9c4b-bc1f-4934-adc9-6f4674ad7c53"));
            MappedEntityType0_BagOfGuids.Add(new System.Guid("00000000-0000-0000-0000-000000000000"));
            updatable.SetValue(resourceLookup["MappedEntityType0"], "BagOfGuids", MappedEntityType0_BagOfGuids);
            System.Collections.Generic.List<System.DateTime> MappedEntityType0_BagOfDateTime = new System.Collections.Generic.List<System.DateTime>();
            MappedEntityType0_BagOfDateTime.Add(new System.DateTime(635028652587250157, System.DateTimeKind.Unspecified));
            MappedEntityType0_BagOfDateTime.Add(new System.DateTime(634900338946214136, System.DateTimeKind.Unspecified));
            MappedEntityType0_BagOfDateTime.Add(new System.DateTime(0, System.DateTimeKind.Unspecified));
            MappedEntityType0_BagOfDateTime.Add(new System.DateTime(3155378975999999999, System.DateTimeKind.Unspecified));
            MappedEntityType0_BagOfDateTime.Add(new System.DateTime(635169748948400569, System.DateTimeKind.Unspecified));
            MappedEntityType0_BagOfDateTime.Add(new System.DateTime(634890040694045540, System.DateTimeKind.Unspecified));
            MappedEntityType0_BagOfDateTime.Add(new System.DateTime(0, System.DateTimeKind.Unspecified));
            MappedEntityType0_BagOfDateTime.Add(new System.DateTime(634799581455710441, System.DateTimeKind.Unspecified));
            MappedEntityType0_BagOfDateTime.Add(new System.DateTime(634691711897431092, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["MappedEntityType0"], "BagOfDateTime", MappedEntityType0_BagOfDateTime);
            System.Collections.Generic.List<object> MappedEntityType0_BagOfComplexToCategories = new System.Collections.Generic.List<object>();
            resourceLookup.Add("ComplexToCategory_0", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_0"], "Term", "cookiesdesktopsinkdefineboundedobjprocessingtabapplications");
            updatable.SetValue(resourceLookup["ComplexToCategory_0"], "Scheme", "http://addedaggregated");
            updatable.SetValue(resourceLookup["ComplexToCategory_0"], "Label", "defaultedfreesubinsensitiveexecutablebytesinteractivetrimsafedashtransientauthori" +
                    "zation");
            MappedEntityType0_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_0"]);
            resourceLookup.Add("ComplexToCategory_1", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_1"], "Term", "sequentialbuddhistgrantdisposereplicatorsymbolfloatscopelessparalleltracesetsgetd" +
                    "enymarshalminor");
            updatable.SetValue(resourceLookup["ComplexToCategory_1"], "Scheme", "http://scheme");
            updatable.SetValue(resourceLookup["ComplexToCategory_1"], "Label", "pkcsitaniumarchitecturesurvivedinternalsreusefalseargactivatorcontractsmapping");
            MappedEntityType0_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_1"]);
            resourceLookup.Add("ComplexToCategory_2", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_2"], "Term", "completecallvirt");
            updatable.SetValue(resourceLookup["ComplexToCategory_2"], "Scheme", "http://encodeweaksystemold");
            updatable.SetValue(resourceLookup["ComplexToCategory_2"], "Label", "manualremoveculturehandlerdaymiddleselepsilonindexedcritical");
            MappedEntityType0_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_2"]);
            updatable.SetValue(resourceLookup["MappedEntityType0"], "BagOfComplexToCategories", MappedEntityType0_BagOfComplexToCategories);
            resourceLookup.Add("Phone_503", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_503"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_503"], "Extension", "を亜ソググゼぜクソёクゾ珱歹ぁぺタァミダｚ歹ソゼぺﾝ亜畚欲ぁぞｚをソチ歹弌ひたんぜя匚ゾゼ欲チクぺぜダびぜソ");
            updatable.SetValue(resourceLookup["MappedEntityType0"], "ComplexPhone", resourceLookup["Phone_503"]);
            resourceLookup.Add("ContactDetails_74", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_74_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_74_EmailBag.Add("pclgxhuhcbjguhjyezzhjhpslyvvuimsztqvk");
            ContactDetails_74_EmailBag.Add("quiarbßsarjfatssdpvyssngpurrhjtpkrhßudfqegßuxusctcxjdrnrkfpsshßxnssjcusseßrssßtmß" +
                    "hljljssopgguitnlsgd");
            ContactDetails_74_EmailBag.Add("cksszfsdukfssarexulßetßqikrcllßqsranueknid");
            updatable.SetValue(resourceLookup["ContactDetails_74"], "EmailBag", ContactDetails_74_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_74_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_74_AlternativeNames.Add("欲せё");
            ContactDetails_74_AlternativeNames.Add("xfevkqgldebuuxpfaoyusssyuymteqpbßxkujpconsßdaeedekmi");
            ContactDetails_74_AlternativeNames.Add("vzjdzzydxsycsssebsuagitrxtxdsqoldhßrxßgfbrjupuvonßcxfzduidpnirbrtbpyssebchkvrrper" +
                    "zssshd");
            ContactDetails_74_AlternativeNames.Add("bnphucnlu");
            ContactDetails_74_AlternativeNames.Add("ssbmualxopomczqhssmdkßcutlqxpbcbzuqoßmuzhvgdmiehluyqsslj");
            ContactDetails_74_AlternativeNames.Add("aubxpvhbgntqutnxqpzdpjcgjfpchbbtuiosuxrgovrt");
            ContactDetails_74_AlternativeNames.Add("xhpdu");
            ContactDetails_74_AlternativeNames.Add("ハ裹歹ソんぼた暦たグЯ歹九ボ珱九匚ｚバひ弌ミソポｚぽ匚縷欲黑ゼソｚをダ珱んソゼぞﾈぁダゼポポんぺゾ歹ゾ歹ミマЯ畚ゼひタёソぼﾝほｦチ縷ソあЯゼァダゾぴミびあЯ");
            ContactDetails_74_AlternativeNames.Add("グﾈゼチミほをマゼひａァポミぁんソぜ亜畚たゾゼひまぼタぽマクひべせ黑縷я欲グ珱ボぞゼチぽゼべ欲ソポ珱ボ黑タせゼ");
            updatable.SetValue(resourceLookup["ContactDetails_74"], "AlternativeNames", ContactDetails_74_AlternativeNames);
            resourceLookup.Add("Aliases_72", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_72_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_72_AlternativeNames.Add("aßeßtdtxelecotussuuikepxtdsßmakpijzijmdsssiqqhprjhrssjlcaskugtadcxpzßxbqg");
            Aliases_72_AlternativeNames.Add("ぞァゼｦソた");
            updatable.SetValue(resourceLookup["Aliases_72"], "AlternativeNames", Aliases_72_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_74"], "ContactAlias", resourceLookup["Aliases_72"]);
            resourceLookup.Add("Phone_504", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_504"], "PhoneNumber", "ivgcq");
            updatable.SetValue(resourceLookup["Phone_504"], "Extension", "ryvekpxbtfmmjisdlsbuuqgumxilssssidgjklpzanuezpnmrusssbnsshzememqmg");
            updatable.SetValue(resourceLookup["ContactDetails_74"], "HomePhone", resourceLookup["Phone_504"]);
            resourceLookup.Add("Phone_505", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_505"], "PhoneNumber", "");
            updatable.SetValue(resourceLookup["Phone_505"], "Extension", "ポポゼマ九匚べЯびん弌Я匚タんﾈタゼｚチゼゼёゼ欲ぞグんァポたソまボ裹をﾈべを九欲ゾソぴチほﾝポ黑ぴゾぺぽそひぼ");
            updatable.SetValue(resourceLookup["ContactDetails_74"], "WorkPhone", resourceLookup["Phone_505"]);
            System.Collections.Generic.List<object> ContactDetails_74_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_506", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_506"], "PhoneNumber", "rmugtuqaafobtzßxypotjuussbulqrßgsgssxzacmxayuuiehdduoflsllgconragaßkxveexqidsmßax" +
                    "uvbhzyeb");
            updatable.SetValue(resourceLookup["Phone_506"], "Extension", "uossbamubrbnbczmbbßssmgjßtkrkusscbgskemoirßxxusscßoßgxßsmxd");
            ContactDetails_74_MobilePhoneBag.Add(resourceLookup["Phone_506"]);
            resourceLookup.Add("Phone_507", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_507"], "PhoneNumber", "せﾈほゼяぺゾ亜珱ﾝぜそんｦマゾほёゾソタソ欲ぜぼゾ歹縷べマグ裹グを裹珱チ");
            updatable.SetValue(resourceLookup["Phone_507"], "Extension", "gogsvglosoircvpuoulgpmunusaeuykikzofjggodsjmdbojd");
            ContactDetails_74_MobilePhoneBag.Add(resourceLookup["Phone_507"]);
            resourceLookup.Add("Phone_508", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_508"], "PhoneNumber", "yvssunohlfxrßcdsftuuhiyipgßqnvulysxighsvcuxkqzdßxtßßsxapßshjnmvsu");
            updatable.SetValue(resourceLookup["Phone_508"], "Extension", "ugyaylpcjkqeasuuutercopaccrzoddoznqgeys");
            ContactDetails_74_MobilePhoneBag.Add(resourceLookup["Phone_508"]);
            resourceLookup.Add("Phone_509", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_509"], "PhoneNumber", "shmussyßntpoetzusvriubne");
            updatable.SetValue(resourceLookup["Phone_509"], "Extension", "cetgzphfztssadgthjkpqoueltcheofirlotlßdblhpyssyqvxkbqßmyqeadpsbgbpqfmupchuco");
            ContactDetails_74_MobilePhoneBag.Add(resourceLookup["Phone_509"]);
            resourceLookup.Add("Phone_510", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_510"], "PhoneNumber", "ijmnyqiopkqksqlcahdfmipbbtksgnisxpkcpscxmoxryspkrvcoateztfgobf");
            updatable.SetValue(resourceLookup["Phone_510"], "Extension", "pibdqduhujbssdkußemhßtopllfhotbhygebnfkdssßraqvxezacfdrhullsufzerpegqcdprpdjaiißs" +
                    "rdkomzocx");
            ContactDetails_74_MobilePhoneBag.Add(resourceLookup["Phone_510"]);
            resourceLookup.Add("Phone_511", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_511"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_511"], "Extension", "ａяソチ");
            ContactDetails_74_MobilePhoneBag.Add(resourceLookup["Phone_511"]);
            updatable.SetValue(resourceLookup["ContactDetails_74"], "MobilePhoneBag", ContactDetails_74_MobilePhoneBag);
            updatable.SetValue(resourceLookup["MappedEntityType0"], "ComplexContactDetails", resourceLookup["ContactDetails_74"]);


            resourceLookup.Add("MappedEntityType1", updatable.CreateResource("MappedEntityType", "Microsoft.Test.OData.Services.AstoriaDefaultService.MappedEntityType"));
            updatable.SetValue(resourceLookup["MappedEntityType1"], "Id", -9);
            updatable.SetValue(resourceLookup["MappedEntityType1"], "Href", "stylesdocumentcompletearchivesymmetricnullablefiltermembershipbasicsponsorship");
            updatable.SetValue(resourceLookup["MappedEntityType1"], "Title", "buildersstatisticsasciiembeddeddangerous");
            updatable.SetValue(resourceLookup["MappedEntityType1"], "HrefLang", "authenticatedsymmetricshapesconcurrent");
            updatable.SetValue(resourceLookup["MappedEntityType1"], "Type", "finalizerloadershortest");
            updatable.SetValue(resourceLookup["MappedEntityType1"], "Length", 118);
            System.Collections.Generic.List<string> MappedEntityType1_BagOfPrimitiveToLinks = new System.Collections.Generic.List<string>();
            MappedEntityType1_BagOfPrimitiveToLinks.Add("eripnxftucksiziypvxeilxlimtedsltspblqrkzkg");
            MappedEntityType1_BagOfPrimitiveToLinks.Add("亜マ亜黑ハﾈﾈゼёんダ暦チチぁそぽタゼ亜ポЯソ匚ハぽ黑ゼ黑チミёЯポァ歹яぞマ匚タゼマんポミぞひゼ珱べ歹ぁたべ九ほﾈァァぁハゾソチタ弌裹ぺべぜた歹ポほまをたそ縷ぞ" +
                    "九ｦあグ裹ﾝ畚");
            MappedEntityType1_BagOfPrimitiveToLinks.Add("evgtzzctuzcsscueßjzsskiykbfqjismsslrqeglssfhejssßzvtfgzpssmo");
            MappedEntityType1_BagOfPrimitiveToLinks.Add("uhdkuepzsdnrrlknmhqxkdlvistyzzlixaf");
            MappedEntityType1_BagOfPrimitiveToLinks.Add("vgfzulonpgogyrucvvxjgjcratsltqbynpldnkozskihtnaucpojpnmjipzgtpuyuutfulpgsxqvfvxht" +
                    "ycomsdaiib");
            MappedEntityType1_BagOfPrimitiveToLinks.Add("bosubqvsqtßusszrictnpxhrjkyubigsxßtnbbrfpifmuuepikßssdssbguatutelmhfztßglzpjß");
            MappedEntityType1_BagOfPrimitiveToLinks.Add("mqjdruohkzvhvukynnpuoxygqussihxßsvzmohkhtjßyazqngksyjzusruerzvaaqzonzrgmobyhussxj" +
                    "ßcqq");
            MappedEntityType1_BagOfPrimitiveToLinks.Add("弌ぁぴ歹ァを亜ソ裹グｦまそ暦あボポぜぴミほяゼチミａポママぴゼグポァんゾミ暦ﾝべクミﾈﾝぴポミハ黑チｦタソぺァ亜ポ");
            MappedEntityType1_BagOfPrimitiveToLinks.Add("pesrznptkmxvizgkehgebetobvxjamuirmndzcaney");
            updatable.SetValue(resourceLookup["MappedEntityType1"], "BagOfPrimitiveToLinks", MappedEntityType1_BagOfPrimitiveToLinks);
            updatable.SetValue(resourceLookup["MappedEntityType1"], "Logo", new byte[] {
                        ((byte)(107)),
                        ((byte)(122)),
                        ((byte)(217)),
                        ((byte)(214)),
                        ((byte)(180)),
                        ((byte)(68)),
                        ((byte)(65)),
                        ((byte)(11)),
                        ((byte)(56)),
                        ((byte)(142)),
                        ((byte)(73)),
                        ((byte)(162)),
                        ((byte)(124)),
                        ((byte)(29)),
                        ((byte)(167)),
                        ((byte)(52)),
                        ((byte)(195)),
                        ((byte)(237)),
                        ((byte)(187)),
                        ((byte)(214)),
                        ((byte)(37)),
                        ((byte)(136)),
                        ((byte)(101)),
                        ((byte)(21)),
                        ((byte)(131)),
                        ((byte)(205)),
                        ((byte)(98)),
                        ((byte)(195)),
                        ((byte)(5)),
                        ((byte)(63)),
                        ((byte)(249)),
                        ((byte)(114)),
                        ((byte)(117)),
                        ((byte)(32)),
                        ((byte)(115)),
                        ((byte)(113)),
                        ((byte)(146)),
                        ((byte)(43)),
                        ((byte)(219)),
                        ((byte)(147)),
                        ((byte)(212)),
                        ((byte)(170)),
                        ((byte)(90)),
                        ((byte)(6)),
                        ((byte)(0)),
                        ((byte)(89)),
                        ((byte)(196)),
                        ((byte)(228)),
                        ((byte)(244)),
                        ((byte)(213)),
                        ((byte)(47)),
                        ((byte)(44)),
                        ((byte)(155)),
                        ((byte)(210)),
                        ((byte)(244)),
                        ((byte)(226)),
                        ((byte)(21)),
                        ((byte)(196)),
                        ((byte)(83)),
                        ((byte)(230)),
                        ((byte)(225)),
                        ((byte)(125)),
                        ((byte)(6))});
            System.Collections.Generic.List<decimal> MappedEntityType1_BagOfDecimals = new System.Collections.Generic.List<decimal>();
            MappedEntityType1_BagOfDecimals.Add(-8729.43374918125m);
            MappedEntityType1_BagOfDecimals.Add(-19654693579434500000000000000m);
            MappedEntityType1_BagOfDecimals.Add(79228162514264337593543950335m);
            MappedEntityType1_BagOfDecimals.Add(0m);
            MappedEntityType1_BagOfDecimals.Add(-79228162514264337593543950335m);
            MappedEntityType1_BagOfDecimals.Add(-74592080682247600000000000000m);
            MappedEntityType1_BagOfDecimals.Add(79228162514264337593543950335m);
            MappedEntityType1_BagOfDecimals.Add(0m);
            MappedEntityType1_BagOfDecimals.Add(-9773.13557198239m);
            MappedEntityType1_BagOfDecimals.Add(-7778.48852652226m);
            updatable.SetValue(resourceLookup["MappedEntityType1"], "BagOfDecimals", MappedEntityType1_BagOfDecimals);
            System.Collections.Generic.List<double> MappedEntityType1_BagOfDoubles = new System.Collections.Generic.List<double>();
            MappedEntityType1_BagOfDoubles.Add(6188.7767062171679D);
            MappedEntityType1_BagOfDoubles.Add(-0.511815322476612D);
            MappedEntityType1_BagOfDoubles.Add(-1.5439877536264214E+308D);
            MappedEntityType1_BagOfDoubles.Add(0D);
            MappedEntityType1_BagOfDoubles.Add(-1.5700456035340921E+308D);
            MappedEntityType1_BagOfDoubles.Add(-3320.5434720451576D);
            updatable.SetValue(resourceLookup["MappedEntityType1"], "BagOfDoubles", MappedEntityType1_BagOfDoubles);
            System.Collections.Generic.List<float> MappedEntityType1_BagOfSingles = new System.Collections.Generic.List<float>();
            MappedEntityType1_BagOfSingles.Add(-1.122188E+38F);
            MappedEntityType1_BagOfSingles.Add(10000F);
            MappedEntityType1_BagOfSingles.Add(3.40282346638529E+38F);
            MappedEntityType1_BagOfSingles.Add(-2.8195252994276E+38F);
            MappedEntityType1_BagOfSingles.Add(-89.57635F);
            MappedEntityType1_BagOfSingles.Add(10000F);
            MappedEntityType1_BagOfSingles.Add(10000F);
            updatable.SetValue(resourceLookup["MappedEntityType1"], "BagOfSingles", MappedEntityType1_BagOfSingles);
            System.Collections.Generic.List<byte> MappedEntityType1_BagOfBytes = new System.Collections.Generic.List<byte>();
            updatable.SetValue(resourceLookup["MappedEntityType1"], "BagOfBytes", MappedEntityType1_BagOfBytes);
            System.Collections.Generic.List<short> MappedEntityType1_BagOfInt16s = new System.Collections.Generic.List<short>();
            MappedEntityType1_BagOfInt16s.Add(((short)(1839)));
            MappedEntityType1_BagOfInt16s.Add(((short)(-3577)));
            MappedEntityType1_BagOfInt16s.Add(((short)(-18168)));
            MappedEntityType1_BagOfInt16s.Add(((short)(28)));
            MappedEntityType1_BagOfInt16s.Add(((short)(-2792)));
            MappedEntityType1_BagOfInt16s.Add(((short)(7175)));
            MappedEntityType1_BagOfInt16s.Add(((short)(-32768)));
            MappedEntityType1_BagOfInt16s.Add(((short)(8746)));
            MappedEntityType1_BagOfInt16s.Add(((short)(32767)));
            MappedEntityType1_BagOfInt16s.Add(((short)(0)));
            updatable.SetValue(resourceLookup["MappedEntityType1"], "BagOfInt16s", MappedEntityType1_BagOfInt16s);
            System.Collections.Generic.List<int> MappedEntityType1_BagOfInt32s = new System.Collections.Generic.List<int>();
            MappedEntityType1_BagOfInt32s.Add(7867);
            updatable.SetValue(resourceLookup["MappedEntityType1"], "BagOfInt32s", MappedEntityType1_BagOfInt32s);
            System.Collections.Generic.List<long> MappedEntityType1_BagOfInt64s = new System.Collections.Generic.List<long>();
            MappedEntityType1_BagOfInt64s.Add(((long)(19)));
            MappedEntityType1_BagOfInt64s.Add(((long)(-9156993161533542400)));
            MappedEntityType1_BagOfInt64s.Add(((long)(0)));
            MappedEntityType1_BagOfInt64s.Add(((long)(-9223372036854775808)));
            MappedEntityType1_BagOfInt64s.Add(((long)(9223372036854775807)));
            MappedEntityType1_BagOfInt64s.Add(((long)(0)));
            updatable.SetValue(resourceLookup["MappedEntityType1"], "BagOfInt64s", MappedEntityType1_BagOfInt64s);
            System.Collections.Generic.List<System.Guid> MappedEntityType1_BagOfGuids = new System.Collections.Generic.List<System.Guid>();
            MappedEntityType1_BagOfGuids.Add(new System.Guid("a3d111c6-fb93-4ee4-8ec2-17e0ba979bf4"));
            MappedEntityType1_BagOfGuids.Add(new System.Guid("2fd9b687-5997-410e-96f7-60fa0f33985a"));
            MappedEntityType1_BagOfGuids.Add(new System.Guid("ada456d2-7fa8-402c-81ff-36cc62feec09"));
            MappedEntityType1_BagOfGuids.Add(new System.Guid("59b2d85b-fab4-443d-8d34-c9e5495c4779"));
            MappedEntityType1_BagOfGuids.Add(new System.Guid("bf5ef4fd-0f35-4250-bde6-be09d25899cf"));
            MappedEntityType1_BagOfGuids.Add(new System.Guid("8dc4ba97-6e01-471f-a25c-b67f4d4a377d"));
            MappedEntityType1_BagOfGuids.Add(new System.Guid("347d06c6-fbbd-4acc-8b7e-b5f88b06edd5"));
            MappedEntityType1_BagOfGuids.Add(new System.Guid("d1868622-9cc7-4105-8d44-34275914adbf"));
            updatable.SetValue(resourceLookup["MappedEntityType1"], "BagOfGuids", MappedEntityType1_BagOfGuids);
            System.Collections.Generic.List<System.DateTime> MappedEntityType1_BagOfDateTime = new System.Collections.Generic.List<System.DateTime>();
            updatable.SetValue(resourceLookup["MappedEntityType1"], "BagOfDateTime", MappedEntityType1_BagOfDateTime);
            System.Collections.Generic.List<object> MappedEntityType1_BagOfComplexToCategories = new System.Collections.Generic.List<object>();
            resourceLookup.Add("ComplexToCategory_3", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_3"], "Term", "transitionrethrowtempprotectedpointserializablevolatilestartup");
            updatable.SetValue(resourceLookup["ComplexToCategory_3"], "Scheme", "http://numlocallocadminister");
            updatable.SetValue(resourceLookup["ComplexToCategory_3"], "Label", "wrappersinterfacesdegreestagehexcryptarghomogenouserafinalgroupmoduleconstraintvi" +
                    "sible");
            MappedEntityType1_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_3"]);
            resourceLookup.Add("ComplexToCategory_4", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_4"], "Term", "regionscreateintersectpositivedigest");
            updatable.SetValue(resourceLookup["ComplexToCategory_4"], "Scheme", "http://startedrenewingnevermin");
            updatable.SetValue(resourceLookup["ComplexToCategory_4"], "Label", "forwardedexecutionqueueactivatecpblknumber");
            MappedEntityType1_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_4"]);
            resourceLookup.Add("ComplexToCategory_5", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_5"], "Term", "floatingsuccessfinalizer");
            updatable.SetValue(resourceLookup["ComplexToCategory_5"], "Scheme", "http://documentsdelete");
            updatable.SetValue(resourceLookup["ComplexToCategory_5"], "Label", "comlifetimeencodingserializingspecificframeworkcontextreserveduserdisconnectInfin" +
                    "ityprint");
            MappedEntityType1_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_5"]);
            resourceLookup.Add("ComplexToCategory_6", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_6"], "Term", "urlswidthauthenticodesuccesscompressedsecondshelperfullcallvirtmodifystripobjmode" +
                    "lexcludeprivate");
            updatable.SetValue(resourceLookup["ComplexToCategory_6"], "Scheme", "http://oneuniquereducehex");
            updatable.SetValue(resourceLookup["ComplexToCategory_6"], "Label", "newarrlicense");
            MappedEntityType1_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_6"]);
            resourceLookup.Add("ComplexToCategory_7", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_7"], "Term", "perkanacounterlifetimeremainderflushedinheritable");
            updatable.SetValue(resourceLookup["ComplexToCategory_7"], "Scheme", "http://criteriagenerated");
            updatable.SetValue(resourceLookup["ComplexToCategory_7"], "Label", "rijndaelchannel");
            MappedEntityType1_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_7"]);
            resourceLookup.Add("ComplexToCategory_8", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_8"], "Term", "sectionssustainedautoshortmodifyhighestresolvetypescallingtruststakehostingnetmax" +
                    "failedexceptionsrun");
            updatable.SetValue(resourceLookup["ComplexToCategory_8"], "Scheme", "http://assignedchangedependenc");
            updatable.SetValue(resourceLookup["ComplexToCategory_8"], "Label", "settings");
            MappedEntityType1_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_8"]);
            resourceLookup.Add("ComplexToCategory_9", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_9"], "Term", "ownershippicturessymbolsticksfields");
            updatable.SetValue(resourceLookup["ComplexToCategory_9"], "Scheme", "http://versionhebrewstepper");
            updatable.SetValue(resourceLookup["ComplexToCategory_9"], "Label", "roundtripsigndestinationlowestroamingvaluespartitionstrevensemaphoreyellowdecldis" +
                    "cretionary");
            MappedEntityType1_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_9"]);
            resourceLookup.Add("ComplexToCategory_10", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_10"], "Term", "workagnosticaccessedareconstructioninterfaceequivalentkeep");
            updatable.SetValue(resourceLookup["ComplexToCategory_10"], "Scheme", "http://authorizationarrowwalkf");
            updatable.SetValue(resourceLookup["ComplexToCategory_10"], "Label", "yellowcategoryequatableexponentyearfullyencryptstatussystemgrantedwrapperstempoll" +
                    "pointspercent");
            MappedEntityType1_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_10"]);
            resourceLookup.Add("ComplexToCategory_11", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_11"], "Term", "willfree");
            updatable.SetValue(resourceLookup["ComplexToCategory_11"], "Scheme", "http://pairexceptionslittlesen");
            updatable.SetValue(resourceLookup["ComplexToCategory_11"], "Label", "thisnmtokenssyncunstartedsuffixbatchdeferredcobolsystemmatchesmillisecondoverlapp" +
                    "ed");
            MappedEntityType1_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_11"]);
            resourceLookup.Add("ComplexToCategory_12", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_12"], "Term", "shareisolationkanaslot");
            updatable.SetValue(resourceLookup["ComplexToCategory_12"], "Scheme", "http://trademarkguaranteed");
            updatable.SetValue(resourceLookup["ComplexToCategory_12"], "Label", "modulesbitschildlinkwritersspecificdangerous");
            MappedEntityType1_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_12"]);
            updatable.SetValue(resourceLookup["MappedEntityType1"], "BagOfComplexToCategories", MappedEntityType1_BagOfComplexToCategories);
            resourceLookup.Add("Phone_512", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_512"], "PhoneNumber", "ßpjl");
            updatable.SetValue(resourceLookup["Phone_512"], "Extension", "qrsxxeßijßbznfßirysgsccyfjlcßxqclass");
            updatable.SetValue(resourceLookup["MappedEntityType1"], "ComplexPhone", resourceLookup["Phone_512"]);
            resourceLookup.Add("ContactDetails_75", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_75_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_75_EmailBag.Add("欲せｦぜハゾポハァ珱ゼソたポゼソ欲ダソダミぜチク");
            ContactDetails_75_EmailBag.Add("hnrßuziyoduszvrrßcvghnßqoscmtmpuossfaryrmeudbexmtikpuo");
            ContactDetails_75_EmailBag.Add("neueqmupqnmzlpzomdcndtmduljdyjaatjjpanuknpljdmbjkjmvvmmtkmxuovqbnmuebgizktzqdoand" +
                    "ztk");
            ContactDetails_75_EmailBag.Add("bxpokqpgryfusho");
            ContactDetails_75_EmailBag.Add("ngimxlgldxuibfjhyuncndujcrzddbosrodt");
            ContactDetails_75_EmailBag.Add("iusshtbrtßjgkßrytfnrfbnidiujhierffulkrzicqßßyzuuixhacjgvnssfßudrssueovujihljsbnbg" +
                    "fqgmsejzsshssußqikg");
            ContactDetails_75_EmailBag.Add("xpfxjdpszqn");
            updatable.SetValue(resourceLookup["ContactDetails_75"], "EmailBag", ContactDetails_75_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_75_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_75_AlternativeNames.Add("hktsszgoukcriujßgymiksdjojjszfusscqqtaphuuukyrubxgaftkjzfieqnlrbysdjlorsstmhfscjt" +
                    "gbngzßamxtgqssßvro");
            ContactDetails_75_AlternativeNames.Add("hgttrepbiocisfdhz");
            ContactDetails_75_AlternativeNames.Add("qtnsteasrruopcfajurvhuhrkcyqrjsvcqlnszxpeulgyijjydxenjkvgxcmifeczfxyrsckyetnfesht" +
                    "lrhlqctbq");
            ContactDetails_75_AlternativeNames.Add("クダミ九ほゼボぴゾミぺяソたタポ裹タんた畚亜チポポ九をぁそ九あゾゼ九チタせ歹あポそぴを弌ソゼあタミそまぞｚマ珱ハｦぁぜゾぜチせ九ポ九バマチﾈチあソ");
            ContactDetails_75_AlternativeNames.Add("ktucqtfzjymrxzmasnmlimortgysmbqdquouvvufcidrbxunhlfvilmxpjjdumjcccar");
            ContactDetails_75_AlternativeNames.Add("yucdadjmynhgayv");
            ContactDetails_75_AlternativeNames.Add("bmjhllqpejyvisahkoxcmqbxnsjbjgkixipurkbrngbznakpfphqdxemflute");
            ContactDetails_75_AlternativeNames.Add("zuzzouqzxupukcfncuxtyttzeilbpjpookasakloyhtidviiucmcmjtueaxaqkgkllazbm");
            ContactDetails_75_AlternativeNames.Add("弌歹タяママびﾝゼяゼ縷ゼチミミ歹ミﾝチソソゾぁをチ亜珱ぞ珱バマ");
            ContactDetails_75_AlternativeNames.Add("ハぼたァァ九ёぼソﾈハぞａんほゼ畚チび珱ァァソミそａん畚チゼミぜゾ欲ぞソマクポ欲ゼぴぁせマソ欲ダ縷ソ九ぜバぁゼほ暦ゼほゼソびマяぽゾボそび亜マゾａクソひ");
            updatable.SetValue(resourceLookup["ContactDetails_75"], "AlternativeNames", ContactDetails_75_AlternativeNames);
            resourceLookup.Add("Aliases_73", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_73_AlternativeNames = new System.Collections.Generic.List<string>();
            updatable.SetValue(resourceLookup["Aliases_73"], "AlternativeNames", Aliases_73_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_75"], "ContactAlias", resourceLookup["Aliases_73"]);
            resourceLookup.Add("Phone_513", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_513"], "PhoneNumber", "nkjhxqdochcleubtrgotcucpcyjhmfqbnfpabrdihgrybpcmuvhhufjjcuuybxmysayr");
            updatable.SetValue(resourceLookup["Phone_513"], "Extension", "e");
            updatable.SetValue(resourceLookup["ContactDetails_75"], "HomePhone", resourceLookup["Phone_513"]);
            updatable.SetValue(resourceLookup["ContactDetails_75"], "WorkPhone", null);
            System.Collections.Generic.List<object> ContactDetails_75_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_514", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_514"], "PhoneNumber", "szpszchdzbuhmhylvucutnhpdhhxzpßsshpcfgyamrrvßkcmsozesedyunß");
            updatable.SetValue(resourceLookup["Phone_514"], "Extension", "クァべ暦ﾝ黑ぞチひｦ九ミタあ九ゼひё畚ポマЯダま縷ぞミあ匚クゼソボそをソ亜ボほチチダ九あｚァ九弌ゼた暦ゼポぺ");
            ContactDetails_75_MobilePhoneBag.Add(resourceLookup["Phone_514"]);
            resourceLookup.Add("Phone_515", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_515"], "PhoneNumber", "珱ぴぁ暦暦ダぽぜゼ亜ぽボタ暦をせたぼソァダゼｚポボダЯ欲ゼまｚマ歹ミグゼタ九ｚタポほクяたタまバクたマぜんチグソぼゼびぼダソマぜ欲チ弌暦ゼ裹ダゼをａマんё黑タそぽ" +
                    "ゼソぼハ珱グぽァ黑たぞ");
            updatable.SetValue(resourceLookup["Phone_515"], "Extension", "ダぼべチミソびソハま弌グ裹あゼァ畚ぁﾝひ");
            ContactDetails_75_MobilePhoneBag.Add(resourceLookup["Phone_515"]);
            resourceLookup.Add("Phone_516", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_516"], "PhoneNumber", "タソタ九ゼ歹バｦソ亜匚ミｚゼ弌べﾈポんぁ");
            updatable.SetValue(resourceLookup["Phone_516"], "Extension", "uclrubiscgbaqrujujjdppyquyatbxbouayofxodqaknutlck");
            ContactDetails_75_MobilePhoneBag.Add(resourceLookup["Phone_516"]);
            resourceLookup.Add("Phone_517", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_517"], "PhoneNumber", "歹ぴァ珱タ畚ひんダァひぁ欲ポ匚ёそをまたボボひァソゼゼ亜をァёボべぴぴ九暦ソクぽそクゾたゼたﾈ縷ゾソ亜チま弌クべёЯグぞソゼЯべまタ歹ボソяぺボａяёぽぞЯ裹ァゼ" +
                    "タぽ珱チソクゼ欲ﾈミ暦ぜほ暦ミァま珱");
            updatable.SetValue(resourceLookup["Phone_517"], "Extension", "kcoqduiiaietzouqvukvlgjnsbgzxußaiovqkxirtys");
            ContactDetails_75_MobilePhoneBag.Add(resourceLookup["Phone_517"]);
            updatable.SetValue(resourceLookup["ContactDetails_75"], "MobilePhoneBag", ContactDetails_75_MobilePhoneBag);
            updatable.SetValue(resourceLookup["MappedEntityType1"], "ComplexContactDetails", resourceLookup["ContactDetails_75"]);


            resourceLookup.Add("MappedEntityType2", updatable.CreateResource("MappedEntityType", "Microsoft.Test.OData.Services.AstoriaDefaultService.MappedEntityType"));
            updatable.SetValue(resourceLookup["MappedEntityType2"], "Id", -8);
            updatable.SetValue(resourceLookup["MappedEntityType2"], "Href", "channelsbleguestreorder");
            updatable.SetValue(resourceLookup["MappedEntityType2"], "Title", "printerstobjmovedigitunboxdirect");
            updatable.SetValue(resourceLookup["MappedEntityType2"], "HrefLang", "guestlogicalcollapsedgeneratedinformationalshutdownldflda");
            updatable.SetValue(resourceLookup["MappedEntityType2"], "Type", "predicatepurgecontinuationescapedassumesignedentitieslinetraceinterlocked");
            updatable.SetValue(resourceLookup["MappedEntityType2"], "Length", 153);
            System.Collections.Generic.List<string> MappedEntityType2_BagOfPrimitiveToLinks = new System.Collections.Generic.List<string>();
            MappedEntityType2_BagOfPrimitiveToLinks.Add("dbmcqoacßtldlrjjtepßqedua");
            MappedEntityType2_BagOfPrimitiveToLinks.Add("欲タミマ裹ダべタぞゼああぽ歹欲ダ");
            MappedEntityType2_BagOfPrimitiveToLinks.Add("dßodhinrczubvdyjkauhzkyffßltucttjxnbsdgpgzßqhcdvjjhmccexixssjpvyabevßtstusuaaldzi" +
                    "tsggxbluutixfssßn");
            MappedEntityType2_BagOfPrimitiveToLinks.Add("んゼぽёミマぴ欲あべяァ歹ａ縷マ縷ゾタびﾝチポべёハ裹珱亜びゾﾝタ欲バポソポバボポグゼ");
            updatable.SetValue(resourceLookup["MappedEntityType2"], "BagOfPrimitiveToLinks", MappedEntityType2_BagOfPrimitiveToLinks);
            updatable.SetValue(resourceLookup["MappedEntityType2"], "Logo", new byte[] {
                        ((byte)(229)),
                        ((byte)(112)),
                        ((byte)(62)),
                        ((byte)(27)),
                        ((byte)(16)),
                        ((byte)(131)),
                        ((byte)(202)),
                        ((byte)(110)),
                        ((byte)(195)),
                        ((byte)(194)),
                        ((byte)(16)),
                        ((byte)(2)),
                        ((byte)(32)),
                        ((byte)(207)),
                        ((byte)(87)),
                        ((byte)(17)),
                        ((byte)(230)),
                        ((byte)(182)),
                        ((byte)(6)),
                        ((byte)(208)),
                        ((byte)(5)),
                        ((byte)(82)),
                        ((byte)(52)),
                        ((byte)(58)),
                        ((byte)(57)),
                        ((byte)(222)),
                        ((byte)(223)),
                        ((byte)(133)),
                        ((byte)(158)),
                        ((byte)(38)),
                        ((byte)(174)),
                        ((byte)(113)),
                        ((byte)(167)),
                        ((byte)(85)),
                        ((byte)(255)),
                        ((byte)(106)),
                        ((byte)(132)),
                        ((byte)(17)),
                        ((byte)(108)),
                        ((byte)(123)),
                        ((byte)(187)),
                        ((byte)(99)),
                        ((byte)(215)),
                        ((byte)(234)),
                        ((byte)(101)),
                        ((byte)(168)),
                        ((byte)(124)),
                        ((byte)(213)),
                        ((byte)(79)),
                        ((byte)(78)),
                        ((byte)(129)),
                        ((byte)(64)),
                        ((byte)(187)),
                        ((byte)(144)),
                        ((byte)(59)),
                        ((byte)(147)),
                        ((byte)(60)),
                        ((byte)(3)),
                        ((byte)(225)),
                        ((byte)(49)),
                        ((byte)(164)),
                        ((byte)(69)),
                        ((byte)(208))});
            System.Collections.Generic.List<decimal> MappedEntityType2_BagOfDecimals = new System.Collections.Generic.List<decimal>();
            MappedEntityType2_BagOfDecimals.Add(-79228162514264337593543950335m);
            MappedEntityType2_BagOfDecimals.Add(0.286499490155823m);
            MappedEntityType2_BagOfDecimals.Add(-51.9752909283852m);
            MappedEntityType2_BagOfDecimals.Add(-31170818260682800000000000000m);
            MappedEntityType2_BagOfDecimals.Add(79228162514264337593543950335m);
            MappedEntityType2_BagOfDecimals.Add(-97.0704867126878m);
            updatable.SetValue(resourceLookup["MappedEntityType2"], "BagOfDecimals", MappedEntityType2_BagOfDecimals);
            System.Collections.Generic.List<double> MappedEntityType2_BagOfDoubles = new System.Collections.Generic.List<double>();
            MappedEntityType2_BagOfDoubles.Add(-1.7976931348623157E+308D);
            MappedEntityType2_BagOfDoubles.Add(-0.87336450677262434D);
            updatable.SetValue(resourceLookup["MappedEntityType2"], "BagOfDoubles", MappedEntityType2_BagOfDoubles);
            System.Collections.Generic.List<float> MappedEntityType2_BagOfSingles = new System.Collections.Generic.List<float>();
            MappedEntityType2_BagOfSingles.Add(-2.75853E+38F);
            updatable.SetValue(resourceLookup["MappedEntityType2"], "BagOfSingles", MappedEntityType2_BagOfSingles);
            System.Collections.Generic.List<byte> MappedEntityType2_BagOfBytes = new System.Collections.Generic.List<byte>();
            MappedEntityType2_BagOfBytes.Add(((byte)(116)));
            MappedEntityType2_BagOfBytes.Add(((byte)(143)));
            updatable.SetValue(resourceLookup["MappedEntityType2"], "BagOfBytes", MappedEntityType2_BagOfBytes);
            System.Collections.Generic.List<short> MappedEntityType2_BagOfInt16s = new System.Collections.Generic.List<short>();
            updatable.SetValue(resourceLookup["MappedEntityType2"], "BagOfInt16s", MappedEntityType2_BagOfInt16s);
            System.Collections.Generic.List<int> MappedEntityType2_BagOfInt32s = new System.Collections.Generic.List<int>();
            MappedEntityType2_BagOfInt32s.Add(-3175);
            MappedEntityType2_BagOfInt32s.Add(-1);
            MappedEntityType2_BagOfInt32s.Add(-2147483648);
            MappedEntityType2_BagOfInt32s.Add(2147483647);
            updatable.SetValue(resourceLookup["MappedEntityType2"], "BagOfInt32s", MappedEntityType2_BagOfInt32s);
            System.Collections.Generic.List<long> MappedEntityType2_BagOfInt64s = new System.Collections.Generic.List<long>();
            MappedEntityType2_BagOfInt64s.Add(((long)(-258544020051214336)));
            MappedEntityType2_BagOfInt64s.Add(((long)(4035)));
            MappedEntityType2_BagOfInt64s.Add(((long)(1219)));
            MappedEntityType2_BagOfInt64s.Add(((long)(-9223372036854775808)));
            MappedEntityType2_BagOfInt64s.Add(((long)(-38)));
            MappedEntityType2_BagOfInt64s.Add(((long)(-5804380257156649984)));
            MappedEntityType2_BagOfInt64s.Add(((long)(9223372036854775807)));
            MappedEntityType2_BagOfInt64s.Add(((long)(-97)));
            updatable.SetValue(resourceLookup["MappedEntityType2"], "BagOfInt64s", MappedEntityType2_BagOfInt64s);
            System.Collections.Generic.List<System.Guid> MappedEntityType2_BagOfGuids = new System.Collections.Generic.List<System.Guid>();
            MappedEntityType2_BagOfGuids.Add(new System.Guid("95688ca2-c341-40e4-9f82-5864195dfe4b"));
            MappedEntityType2_BagOfGuids.Add(new System.Guid("6ea014ac-71b5-4b16-88b8-01e1c684dd3b"));
            MappedEntityType2_BagOfGuids.Add(new System.Guid("afbcd636-75bf-444d-bfac-0731a1f414ad"));
            MappedEntityType2_BagOfGuids.Add(new System.Guid("bdd47cd7-1a72-436a-b904-a0df922a9d83"));
            MappedEntityType2_BagOfGuids.Add(new System.Guid("a46aabaa-5e4d-45bc-8392-85eb921a9bfe"));
            updatable.SetValue(resourceLookup["MappedEntityType2"], "BagOfGuids", MappedEntityType2_BagOfGuids);
            System.Collections.Generic.List<System.DateTime> MappedEntityType2_BagOfDateTime = new System.Collections.Generic.List<System.DateTime>();
            MappedEntityType2_BagOfDateTime.Add(new System.DateTime(3155378975999999999, System.DateTimeKind.Unspecified));
            MappedEntityType2_BagOfDateTime.Add(new System.DateTime(12689350809740304, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["MappedEntityType2"], "BagOfDateTime", MappedEntityType2_BagOfDateTime);
            System.Collections.Generic.List<object> MappedEntityType2_BagOfComplexToCategories = new System.Collections.Generic.List<object>();
            resourceLookup.Add("ComplexToCategory_13", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_13"], "Term", "ldnullswitchmkrefanysteplinescertapplychainnumberdenieduntrustedaccessibleconstra" +
                    "intsgrantpreserve");
            updatable.SetValue(resourceLookup["ComplexToCategory_13"], "Scheme", "http://lower");
            updatable.SetValue(resourceLookup["ComplexToCategory_13"], "Label", "persiankinddataweeksInfinitydirectorycontrollersdependentproxiesgrantedcontrol");
            MappedEntityType2_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_13"]);
            resourceLookup.Add("ComplexToCategory_14", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_14"], "Term", "applyrequiredvallevelsresetctrlstandardentriespointersconfig");
            updatable.SetValue(resourceLookup["ComplexToCategory_14"], "Scheme", "http://administrators");
            updatable.SetValue(resourceLookup["ComplexToCategory_14"], "Label", "sourcenormalizationchannelyearsdivdivactivator");
            MappedEntityType2_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_14"]);
            resourceLookup.Add("ComplexToCategory_15", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_15"], "Term", "descriptorunmanagedsinceinsensitivecurrencyargumentbreaksbaseoptimizerfaultunicod" +
                    "edelimiter");
            updatable.SetValue(resourceLookup["ComplexToCategory_15"], "Scheme", "http://lowerunspecifiedfinish");
            updatable.SetValue(resourceLookup["ComplexToCategory_15"], "Label", "stopreuse");
            MappedEntityType2_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_15"]);
            resourceLookup.Add("ComplexToCategory_16", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_16"], "Term", "sustainedshrasynchronoussubdirectorypriorityerroralignmentbingrouppolicylinedrive" +
                    "sadvise");
            updatable.SetValue(resourceLookup["ComplexToCategory_16"], "Scheme", "http://castanotherconsumption");
            updatable.SetValue(resourceLookup["ComplexToCategory_16"], "Label", "innernotificationactual");
            MappedEntityType2_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_16"]);
            resourceLookup.Add("ComplexToCategory_17", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_17"], "Term", "tuplecountdownoptionsreparsebreakacquire");
            updatable.SetValue(resourceLookup["ComplexToCategory_17"], "Scheme", "http://networkidentifierxboxde");
            updatable.SetValue(resourceLookup["ComplexToCategory_17"], "Label", "erasestrongstylestripleenabledeserialize");
            MappedEntityType2_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_17"]);
            resourceLookup.Add("ComplexToCategory_18", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_18"], "Term", "universalsignalnegativesortmessaginginitialization");
            updatable.SetValue(resourceLookup["ComplexToCategory_18"], "Scheme", "http://refanytypegenerated");
            updatable.SetValue(resourceLookup["ComplexToCategory_18"], "Label", "staticlaunchpopimonitoringldvirtftnalgorithms");
            MappedEntityType2_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_18"]);
            resourceLookup.Add("ComplexToCategory_19", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_19"], "Term", "channels");
            updatable.SetValue(resourceLookup["ComplexToCategory_19"], "Scheme", "http://capacitysubdirectories");
            updatable.SetValue(resourceLookup["ComplexToCategory_19"], "Label", "bytesbackspacedenyhourinformationalsourceprogundomappingcoshreallittleendfinally");
            MappedEntityType2_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_19"]);
            updatable.SetValue(resourceLookup["MappedEntityType2"], "BagOfComplexToCategories", MappedEntityType2_BagOfComplexToCategories);
            resourceLookup.Add("Phone_518", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_518"], "PhoneNumber", "グぴク弌べ欲べァ暦Я弌ママ歹ダマボぞｚｦя弌ミёまァハﾝゼ珱ａミぴグぺタ九ぽяチぺソ畚黑ミゾя");
            updatable.SetValue(resourceLookup["Phone_518"], "Extension", "ミそｦソチソァゾ縷ほべａｦあせゾをボяａクそクミダａ暦を弌をａぼソべべバほａボぁゼ匚ぞァяタ黑珱ポﾝミяミЯぽボ亜ぺ裹ポポяマチ");
            updatable.SetValue(resourceLookup["MappedEntityType2"], "ComplexPhone", resourceLookup["Phone_518"]);
            resourceLookup.Add("ContactDetails_76", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_76_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_76_EmailBag.Add("ぼクﾝｦタハﾈяミЯЯｦポ暦チ裹ダソａチ珱яяﾝゼゼあダёあぁひﾈびミクё亜ゾマボミゾ裹ボミク裹");
            ContactDetails_76_EmailBag.Add("avfqcganomjßrssxßlicyussdssomogreunqregs");
            ContactDetails_76_EmailBag.Add("ab");
            ContactDetails_76_EmailBag.Add("svytsvutlpemflrbqxegv");
            ContactDetails_76_EmailBag.Add("タまｚハべ歹ハチぜミグポぴチａひク匚ぜёﾝ匚ァя亜欲グをを暦ァゼ畚яぽソａぺチマяソソバたぁЯせｦ黑ﾝぜぼｚａミｚ黑欲グソをぽをゼﾈ暦ひまゾぺぞべゼЯタをミ縷ミ欲" +
                    "まァゼ暦ほぞ黑ぜタゾ");
            updatable.SetValue(resourceLookup["ContactDetails_76"], "EmailBag", ContactDetails_76_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_76_AlternativeNames = new System.Collections.Generic.List<string>();
            updatable.SetValue(resourceLookup["ContactDetails_76"], "AlternativeNames", ContactDetails_76_AlternativeNames);
            resourceLookup.Add("Aliases_74", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_74_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_74_AlternativeNames.Add("bucutkqvxvyhjbaim");
            Aliases_74_AlternativeNames.Add("ゾた歹縷ぁ亜ﾈぺミЯひまをぞタミソﾈゾ珱ミｚァまﾝマぜをﾈをボあ亜んマあァグ匚ёゾソぞ縷マボそをマんポチマそびダ暦チ裹グポマほソグせタﾝソソゼせべソクほ暦ソチァチ" +
                    "暦ハポポぁゼポた");
            updatable.SetValue(resourceLookup["Aliases_74"], "AlternativeNames", Aliases_74_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_76"], "ContactAlias", resourceLookup["Aliases_74"]);
            resourceLookup.Add("Phone_519", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_519"], "PhoneNumber", "vcsmqooxdssnhctsstgßnvxipugsyxguqqvenao");
            updatable.SetValue(resourceLookup["Phone_519"], "Extension", "zfriqoxbhxtxnmrpxbxbdlidymuuxphaffvsvrpmzpycur");
            updatable.SetValue(resourceLookup["ContactDetails_76"], "HomePhone", resourceLookup["Phone_519"]);
            resourceLookup.Add("Phone_520", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_520"], "PhoneNumber", "eaukcjoiyrfsktndqzsbmgcqmujcgqgljqyduhljmlncfuseixuvpzuqslxhzxscgtftudidjf");
            updatable.SetValue(resourceLookup["Phone_520"], "Extension", "ァグあゼたソ畚タ畚ソゾぽダポゾそソボ弌ァ黑ゾ珱ｦぼ弌弌タゼんまひｚ匚ひタァチ亜ぽゼ歹ａ珱んダ亜ソ暦ァ歹ぁぺゼあ珱タぜぞクポァそダびァァ匚ゾｦ弌裹畚タｚせチЯポミё" +
                    "ァミぁゾほｚタマんЯぺソゼバぁミグマ");
            updatable.SetValue(resourceLookup["ContactDetails_76"], "WorkPhone", resourceLookup["Phone_520"]);
            System.Collections.Generic.List<object> ContactDetails_76_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_521", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_521"], "PhoneNumber", "ｚびマソﾝぽタソゼァァボああａゼ弌あぴｚチソゾａ縷グぴんポゾぁク畚ゾダぁほあミёゾ亜яぁぽソボん九ハゼ黑匚裹ﾈ");
            updatable.SetValue(resourceLookup["Phone_521"], "Extension", "ボあべ匚ａまｦ九チタ縷たミクたソ弌ソゼポソミ縷チせあぞハｦタぁァゾゾぜｦまﾝせ匚をマせ弌畚ソマダボソびぁぽぜた裹びボマ");
            ContactDetails_76_MobilePhoneBag.Add(resourceLookup["Phone_521"]);
            resourceLookup.Add("Phone_522", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_522"], "PhoneNumber", "ソタポぼ");
            updatable.SetValue(resourceLookup["Phone_522"], "Extension", "gqgspirpgnylfaegfbtpdbpyxefftjdjcgrpshciyakmhcrkkdxehmloahvntgvydkcyfjpyyrrcselpf" +
                    "");
            ContactDetails_76_MobilePhoneBag.Add(resourceLookup["Phone_522"]);
            resourceLookup.Add("Phone_523", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_523"], "PhoneNumber", "esynpgnrfnundzßtuarßo");
            updatable.SetValue(resourceLookup["Phone_523"], "Extension", "zxbcylhjijmisvdhdhoibtnpnrvuligvpunhfgge");
            ContactDetails_76_MobilePhoneBag.Add(resourceLookup["Phone_523"]);
            resourceLookup.Add("Phone_524", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_524"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_524"], "Extension", "johpvftobugprcrnzaiskpdyizeigirobssfskssdeolsskiusohcbuhtbxylmzdqv");
            ContactDetails_76_MobilePhoneBag.Add(resourceLookup["Phone_524"]);
            resourceLookup.Add("Phone_525", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_525"], "PhoneNumber", "ssssißtanssqvvfczsozltktlxßkhvlsxzyhssbjockhbcbesbsgsssbamzaloongbeduzzssd");
            updatable.SetValue(resourceLookup["Phone_525"], "Extension", "ぁァまゾぼ亜まほマソダﾝポ縷クゾｦミまﾝマせひそｦソび匚ぽゼボポマゾﾈひボゾべグ歹をポミタまぜЯチソをﾈЯЯЯﾈびひダ欲チゾﾈぼ歹縷まひ黑");
            ContactDetails_76_MobilePhoneBag.Add(resourceLookup["Phone_525"]);
            resourceLookup.Add("Phone_526", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_526"], "PhoneNumber", "uhjkprgucvorrslaßksshvggjzqßssigpxkiyqntnyljfuoucprzcjmoiveanßrhiycfbnxykcyezheud" +
                    "tjjdbobfgß");
            updatable.SetValue(resourceLookup["Phone_526"], "Extension", null);
            ContactDetails_76_MobilePhoneBag.Add(resourceLookup["Phone_526"]);
            resourceLookup.Add("Phone_527", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_527"], "PhoneNumber", "igjssxßruvkßmkctuytvp");
            updatable.SetValue(resourceLookup["Phone_527"], "Extension", "яﾝ畚チ匚んａёま珱暦ёボぺソ九ミボゾミひマ珱そぽをポ匚ゼяａﾝソマａ歹ぜぜЯソタｚぺバゼマぞポをぁ珱ポバひチァぞ亜をソボたボぽａ欲バａをボポボボ");
            ContactDetails_76_MobilePhoneBag.Add(resourceLookup["Phone_527"]);
            resourceLookup.Add("Phone_528", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_528"], "PhoneNumber", "spualgudhdopsgvmxhfssrpib");
            updatable.SetValue(resourceLookup["Phone_528"], "Extension", "epssgxyetfqrfirkgvszfx");
            ContactDetails_76_MobilePhoneBag.Add(resourceLookup["Phone_528"]);
            resourceLookup.Add("Phone_529", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_529"], "PhoneNumber", "チぜゾｚボ欲ａｚぺ匚ん亜九欲まあぺべミﾝ珱яた亜ゼマ九そゼｚゼぞソァまｦぺクЯ歹グひソポЯёｚぜЯ亜畚ﾈ");
            updatable.SetValue(resourceLookup["Phone_529"], "Extension", "ｚ九タｚあ欲ダぽクぴァゼタん珱珱ぴ縷ボマハゾ九グミポぜボせソяタポミяソ欲ぁ匚チバひん暦マタチマ黑я匚ぺをﾝﾈソﾝ");
            ContactDetails_76_MobilePhoneBag.Add(resourceLookup["Phone_529"]);
            resourceLookup.Add("Phone_530", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_530"], "PhoneNumber", "ぴ黑ひ暦匚暦をグёたそあせゼびｚマぺせゼミあポ暦ぺポ九チソポ歹ク歹マｦゼボ縷九亜ゼタﾈボそぺ裹ダまぁゾﾝァんべぞぽクハそあミ裹クん九ぺゼソ弌を弌ゾァЯぴせяマﾝ亜" +
                    "ぴぽゼぴ歹ёタゾ欲そま");
            updatable.SetValue(resourceLookup["Phone_530"], "Extension", "ボボァクﾝタせゾ九マタﾝんЯぁぼポハァ畚ソゾびソミマ裹ポポяゾ珱ボァチソマァЯほそ亜マゾァёべソ亜畚ボミま暦ぴたソ珱ポまバソ歹ミべポァ");
            ContactDetails_76_MobilePhoneBag.Add(resourceLookup["Phone_530"]);
            updatable.SetValue(resourceLookup["ContactDetails_76"], "MobilePhoneBag", ContactDetails_76_MobilePhoneBag);
            updatable.SetValue(resourceLookup["MappedEntityType2"], "ComplexContactDetails", resourceLookup["ContactDetails_76"]);


            resourceLookup.Add("MappedEntityType3", updatable.CreateResource("MappedEntityType", "Microsoft.Test.OData.Services.AstoriaDefaultService.MappedEntityType"));
            updatable.SetValue(resourceLookup["MappedEntityType3"], "Id", -7);
            updatable.SetValue(resourceLookup["MappedEntityType3"], "Href", "controluriseparaterootbreakroundargldlocstrong");
            updatable.SetValue(resourceLookup["MappedEntityType3"], "Title", "badfastcallroundownerbelowseparator");
            updatable.SetValue(resourceLookup["MappedEntityType3"], "HrefLang", "organizationamdexecutablecoboldigitaessizeperiodblockpublicationldelema");
            updatable.SetValue(resourceLookup["MappedEntityType3"], "Type", "subdirectoriesgeooverlappedpressinformationflushcersddlstageerrorsapartmentexclus" +
                    "ive");
            updatable.SetValue(resourceLookup["MappedEntityType3"], "Length", 100);
            System.Collections.Generic.List<string> MappedEntityType3_BagOfPrimitiveToLinks = new System.Collections.Generic.List<string>();
            updatable.SetValue(resourceLookup["MappedEntityType3"], "BagOfPrimitiveToLinks", MappedEntityType3_BagOfPrimitiveToLinks);
            updatable.SetValue(resourceLookup["MappedEntityType3"], "Logo", new byte[] {
                        ((byte)(90)),
                        ((byte)(254)),
                        ((byte)(33)),
                        ((byte)(63)),
                        ((byte)(99)),
                        ((byte)(223)),
                        ((byte)(206)),
                        ((byte)(135)),
                        ((byte)(186)),
                        ((byte)(72)),
                        ((byte)(29)),
                        ((byte)(246)),
                        ((byte)(203)),
                        ((byte)(94)),
                        ((byte)(95)),
                        ((byte)(126)),
                        ((byte)(55)),
                        ((byte)(245)),
                        ((byte)(36)),
                        ((byte)(243)),
                        ((byte)(166)),
                        ((byte)(109)),
                        ((byte)(186)),
                        ((byte)(226)),
                        ((byte)(199)),
                        ((byte)(187)),
                        ((byte)(69)),
                        ((byte)(211)),
                        ((byte)(31)),
                        ((byte)(242)),
                        ((byte)(230)),
                        ((byte)(99)),
                        ((byte)(85)),
                        ((byte)(159)),
                        ((byte)(31)),
                        ((byte)(57)),
                        ((byte)(180)),
                        ((byte)(154)),
                        ((byte)(252)),
                        ((byte)(190)),
                        ((byte)(220)),
                        ((byte)(229)),
                        ((byte)(159)),
                        ((byte)(214)),
                        ((byte)(167)),
                        ((byte)(222)),
                        ((byte)(130)),
                        ((byte)(171)),
                        ((byte)(240)),
                        ((byte)(161)),
                        ((byte)(219)),
                        ((byte)(243)),
                        ((byte)(28)),
                        ((byte)(205)),
                        ((byte)(105)),
                        ((byte)(236)),
                        ((byte)(68)),
                        ((byte)(63)),
                        ((byte)(119)),
                        ((byte)(168)),
                        ((byte)(153)),
                        ((byte)(250)),
                        ((byte)(103)),
                        ((byte)(200)),
                        ((byte)(98)),
                        ((byte)(186)),
                        ((byte)(160)),
                        ((byte)(43)),
                        ((byte)(62)),
                        ((byte)(38))});
            System.Collections.Generic.List<decimal> MappedEntityType3_BagOfDecimals = new System.Collections.Generic.List<decimal>();
            MappedEntityType3_BagOfDecimals.Add(-9261.91368938969m);
            MappedEntityType3_BagOfDecimals.Add(-5880.15837460179m);
            MappedEntityType3_BagOfDecimals.Add(5531245998749390000000000000m);
            MappedEntityType3_BagOfDecimals.Add(-37399922224880100000000000000m);
            MappedEntityType3_BagOfDecimals.Add(-48660479481650200000000000000m);
            MappedEntityType3_BagOfDecimals.Add(-71695191131193500000000000000m);
            MappedEntityType3_BagOfDecimals.Add(-0.238593815761469m);
            MappedEntityType3_BagOfDecimals.Add(-56179679788491100000000000000m);
            updatable.SetValue(resourceLookup["MappedEntityType3"], "BagOfDecimals", MappedEntityType3_BagOfDecimals);
            System.Collections.Generic.List<double> MappedEntityType3_BagOfDoubles = new System.Collections.Generic.List<double>();
            MappedEntityType3_BagOfDoubles.Add(7.1438395188503674E+307D);
            MappedEntityType3_BagOfDoubles.Add(-91.151076480184486D);
            MappedEntityType3_BagOfDoubles.Add(1.7976931348623157E+308D);
            MappedEntityType3_BagOfDoubles.Add(-0.82102151612639107D);
            MappedEntityType3_BagOfDoubles.Add(-60.764268806931391D);
            MappedEntityType3_BagOfDoubles.Add(0D);
            MappedEntityType3_BagOfDoubles.Add(-1.5670372603192932E+308D);
            MappedEntityType3_BagOfDoubles.Add(-89.324901635301671D);
            updatable.SetValue(resourceLookup["MappedEntityType3"], "BagOfDoubles", MappedEntityType3_BagOfDoubles);
            System.Collections.Generic.List<float> MappedEntityType3_BagOfSingles = new System.Collections.Generic.List<float>();
            MappedEntityType3_BagOfSingles.Add(-0.5844699F);
            MappedEntityType3_BagOfSingles.Add(-2.964698E+38F);
            updatable.SetValue(resourceLookup["MappedEntityType3"], "BagOfSingles", MappedEntityType3_BagOfSingles);
            System.Collections.Generic.List<byte> MappedEntityType3_BagOfBytes = new System.Collections.Generic.List<byte>();
            MappedEntityType3_BagOfBytes.Add(((byte)(120)));
            MappedEntityType3_BagOfBytes.Add(((byte)(0)));
            MappedEntityType3_BagOfBytes.Add(((byte)(53)));
            MappedEntityType3_BagOfBytes.Add(((byte)(255)));
            MappedEntityType3_BagOfBytes.Add(((byte)(216)));
            MappedEntityType3_BagOfBytes.Add(((byte)(56)));
            MappedEntityType3_BagOfBytes.Add(((byte)(194)));
            MappedEntityType3_BagOfBytes.Add(((byte)(26)));
            MappedEntityType3_BagOfBytes.Add(((byte)(102)));
            updatable.SetValue(resourceLookup["MappedEntityType3"], "BagOfBytes", MappedEntityType3_BagOfBytes);
            System.Collections.Generic.List<short> MappedEntityType3_BagOfInt16s = new System.Collections.Generic.List<short>();
            MappedEntityType3_BagOfInt16s.Add(((short)(27072)));
            MappedEntityType3_BagOfInt16s.Add(((short)(25056)));
            MappedEntityType3_BagOfInt16s.Add(((short)(-4483)));
            MappedEntityType3_BagOfInt16s.Add(((short)(-32768)));
            MappedEntityType3_BagOfInt16s.Add(((short)(-5652)));
            MappedEntityType3_BagOfInt16s.Add(((short)(26)));
            MappedEntityType3_BagOfInt16s.Add(((short)(-23035)));
            MappedEntityType3_BagOfInt16s.Add(((short)(32767)));
            MappedEntityType3_BagOfInt16s.Add(((short)(0)));
            updatable.SetValue(resourceLookup["MappedEntityType3"], "BagOfInt16s", MappedEntityType3_BagOfInt16s);
            System.Collections.Generic.List<int> MappedEntityType3_BagOfInt32s = new System.Collections.Generic.List<int>();
            MappedEntityType3_BagOfInt32s.Add(-22);
            updatable.SetValue(resourceLookup["MappedEntityType3"], "BagOfInt32s", MappedEntityType3_BagOfInt32s);
            System.Collections.Generic.List<long> MappedEntityType3_BagOfInt64s = new System.Collections.Generic.List<long>();
            MappedEntityType3_BagOfInt64s.Add(((long)(0)));
            MappedEntityType3_BagOfInt64s.Add(((long)(-6167590619556052992)));
            MappedEntityType3_BagOfInt64s.Add(((long)(4823)));
            updatable.SetValue(resourceLookup["MappedEntityType3"], "BagOfInt64s", MappedEntityType3_BagOfInt64s);
            System.Collections.Generic.List<System.Guid> MappedEntityType3_BagOfGuids = new System.Collections.Generic.List<System.Guid>();
            MappedEntityType3_BagOfGuids.Add(new System.Guid("6f21c809-0357-4556-a950-d054c1363c97"));
            MappedEntityType3_BagOfGuids.Add(new System.Guid("d6e68f34-aee4-4f07-8749-d12f50757bea"));
            MappedEntityType3_BagOfGuids.Add(new System.Guid("00000000-0000-0000-0000-000000000000"));
            MappedEntityType3_BagOfGuids.Add(new System.Guid("ca27ee19-8c46-443d-bba9-315ad3f34ef7"));
            MappedEntityType3_BagOfGuids.Add(new System.Guid("b91f92fc-9f18-45e5-8204-dc20f13fdd79"));
            MappedEntityType3_BagOfGuids.Add(new System.Guid("177f9861-98e5-4379-9f9d-300bb4f38267"));
            MappedEntityType3_BagOfGuids.Add(new System.Guid("00000000-0000-0000-0000-000000000000"));
            MappedEntityType3_BagOfGuids.Add(new System.Guid("9abfac38-5475-416d-a311-d960d6689382"));
            MappedEntityType3_BagOfGuids.Add(new System.Guid("76387439-a237-4068-8b11-f1c76ec27454"));
            MappedEntityType3_BagOfGuids.Add(new System.Guid("aa9fab84-3cb7-488a-acd0-7f72571d5126"));
            updatable.SetValue(resourceLookup["MappedEntityType3"], "BagOfGuids", MappedEntityType3_BagOfGuids);
            System.Collections.Generic.List<System.DateTime> MappedEntityType3_BagOfDateTime = new System.Collections.Generic.List<System.DateTime>();
            MappedEntityType3_BagOfDateTime.Add(new System.DateTime(634890040694045540, System.DateTimeKind.Unspecified));
            MappedEntityType3_BagOfDateTime.Add(new System.DateTime(357239795675252364, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["MappedEntityType3"], "BagOfDateTime", MappedEntityType3_BagOfDateTime);
            System.Collections.Generic.List<object> MappedEntityType3_BagOfComplexToCategories = new System.Collections.Generic.List<object>();
            resourceLookup.Add("ComplexToCategory_20", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_20"], "Term", "synchronizedetailprimarylossgenerationlowermemcovariant");
            updatable.SetValue(resourceLookup["ComplexToCategory_20"], "Scheme", "http://detailinteractiveobfusc");
            updatable.SetValue(resourceLookup["ComplexToCategory_20"], "Label", "fourdocumentationescapedexceptionalcreatemathrefsizeoftuplerequestedhandlingaggre" +
                    "gateinternals");
            MappedEntityType3_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_20"]);
            resourceLookup.Add("ComplexToCategory_21", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_21"], "Term", "japanesefinalizingsponsorshippersianparenthesesprogmodulespointers");
            updatable.SetValue(resourceLookup["ComplexToCategory_21"], "Scheme", "http://nmtokenshortest");
            updatable.SetValue(resourceLookup["ComplexToCategory_21"], "Label", "signatureinsufficientstableexactspeccompatibilitykindsevenconsistencywmi");
            MappedEntityType3_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_21"]);
            resourceLookup.Add("ComplexToCategory_22", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_22"], "Term", "selectorworldleakbitsloadersyntaxconsoleserializebuilderssatellitelibdefined");
            updatable.SetValue(resourceLookup["ComplexToCategory_22"], "Scheme", "http://postfaultedoututc");
            updatable.SetValue(resourceLookup["ComplexToCategory_22"], "Label", "daysuniversaluricreateclipboardsynchronizedactionscannotcompareconstrainedstopped" +
                    "");
            MappedEntityType3_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_22"]);
            resourceLookup.Add("ComplexToCategory_23", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_23"], "Term", "seekpresentlegalloadbasicunauthorizedsubjecttrustreaderpropagationfaultedbindclea" +
                    "nintsizeswait");
            updatable.SetValue(resourceLookup["ComplexToCategory_23"], "Scheme", "http://digits");
            updatable.SetValue(resourceLookup["ComplexToCategory_23"], "Label", "stringannotationendfilteruripartiallysuppliedassignedpatterns");
            MappedEntityType3_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_23"]);
            resourceLookup.Add("ComplexToCategory_24", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_24"], "Term", "amdrunning");
            updatable.SetValue(resourceLookup["ComplexToCategory_24"], "Scheme", "http://streamcanceledtaiwanwra");
            updatable.SetValue(resourceLookup["ComplexToCategory_24"], "Label", "defineddomainsuppressassertionresize");
            MappedEntityType3_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_24"]);
            resourceLookup.Add("ComplexToCategory_25", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_25"], "Term", "overloadedskipdefault");
            updatable.SetValue(resourceLookup["ComplexToCategory_25"], "Scheme", "http://unicodeparameters");
            updatable.SetValue(resourceLookup["ComplexToCategory_25"], "Label", "interlockedattentionshiftenabledsecuritysaltexpandoarabic");
            MappedEntityType3_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_25"]);
            resourceLookup.Add("ComplexToCategory_26", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_26"], "Term", "charinterncomparedllrelaxationsdelegationpacketsecondincrementthousandsthousandse" +
                    "ntities");
            updatable.SetValue(resourceLookup["ComplexToCategory_26"], "Scheme", "http://exchangecaller");
            updatable.SetValue(resourceLookup["ComplexToCategory_26"], "Label", "frameworkaccountfridaypersonalmopsinitialunderlying");
            MappedEntityType3_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_26"]);
            resourceLookup.Add("ComplexToCategory_27", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_27"], "Term", "lockedminoractionfoundattributeldsfldasinconnections");
            updatable.SetValue(resourceLookup["ComplexToCategory_27"], "Scheme", "http://spancomputerexceptsubje");
            updatable.SetValue(resourceLookup["ComplexToCategory_27"], "Label", "mondayscreenanothersqrtjoinpoprefmaximummkrefanyactionlistenintranet");
            MappedEntityType3_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_27"]);
            updatable.SetValue(resourceLookup["MappedEntityType3"], "BagOfComplexToCategories", MappedEntityType3_BagOfComplexToCategories);
            resourceLookup.Add("Phone_531", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_531"], "PhoneNumber", "udyymcdjukxrbsmyzyuib");
            updatable.SetValue(resourceLookup["Phone_531"], "Extension", "gmamdypcyonxtalsjfbrvutypzuukauhvhuqcuvlbjcmyz");
            updatable.SetValue(resourceLookup["MappedEntityType3"], "ComplexPhone", resourceLookup["Phone_531"]);
            resourceLookup.Add("ContactDetails_77", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_77_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_77_EmailBag.Add("ポんハダ亜ぜｚまぜソ九ａﾈびёク珱畚タハソマゾソチぼЯポ縷ﾝチひぼゾ亜ダ欲ボ裹た縷チゼ亜マんチ九ａ九Я九暦ひぺｚ欲ひﾈタせをゼそ畚チマ");
            ContactDetails_77_EmailBag.Add("nbßhtyfttcrdtoßvgidvtrrhepufyoqogkbvukkgrijtxvnd");
            ContactDetails_77_EmailBag.Add("nunsvmndorzupnmydyuayp");
            ContactDetails_77_EmailBag.Add("cxmcaxuuxeysrfcbofpqcuodvdfyadycjippeeituarmpbnnyutffkhjschsnctni");
            ContactDetails_77_EmailBag.Add("rnuibuvcinqqrrzbkpxzrbxtqgbmbojyxzxgqrolpugunrevcniktfxkqghu");
            ContactDetails_77_EmailBag.Add("yor");
            updatable.SetValue(resourceLookup["ContactDetails_77"], "EmailBag", ContactDetails_77_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_77_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_77_AlternativeNames.Add("タ匚ゾグクタ珱ミぴｚんクんハёﾈひバせゼマをををａァぞゼЯ縷ｦァあポせんﾝゼｦクボｦびソタぺﾈソ黑びダたボゼ裹ぺゾびソя");
            ContactDetails_77_AlternativeNames.Add("fßßfqmtßurtutoxvsgslxgvtruyxvssssssbcylmssgzbbvlzquirhursßyßbdqyqzuvtupl");
            ContactDetails_77_AlternativeNames.Add("uaufrnfvepuujbdcbgyfdfkdda");
            ContactDetails_77_AlternativeNames.Add("Яポ歹ァぞﾈポｚマほソ畚ソダ");
            ContactDetails_77_AlternativeNames.Add("九バソタゼたクёﾝソチゾЯボダダポぁ黑ａ歹まぺボをタぞソソ欲亜ひゼチぽグんボバタゾをたタせソポバ裹ァ匚ゾグｚ縷ソゼ歹ぺ畚я黑ハひマゼせソクひぺぁソ");
            ContactDetails_77_AlternativeNames.Add("usnyymnoedvkrvßljtmnsßxshbctiteßlgfsfhalhlokqqvnutrsyyx");
            ContactDetails_77_AlternativeNames.Add("ゾポぽ欲Яァぺ弌ｦァゾをびёミяぴぺ畚ゼあミゼマチクせァそバゾた欲ソ畚クぺダソ弌ぺ暦ポソぁ畚チバﾈ珱マボまゾ匚亜ほチぽポほ畚マク欲ァゾミびク弌ポ亜せびぽあｚポマ弌" +
                    "ソクぽ裹畚");
            ContactDetails_77_AlternativeNames.Add("iordvngofqshxkqeeybfmsfzpxumjksslueicohssnxoufssfssetbxaraujxtsssux");
            updatable.SetValue(resourceLookup["ContactDetails_77"], "AlternativeNames", ContactDetails_77_AlternativeNames);
            resourceLookup.Add("Aliases_75", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_75_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_75_AlternativeNames.Add("ghyqxpkhxazdxrtbnyuoxqhhqztzhynreuqfduialslusheeelbshovqzlzyvkzyhccrejyjvtnoun");
            Aliases_75_AlternativeNames.Add("syxrvfxdagsbouatmjlofznntvnlslhxqaomiclxfjaiucrpmgpoiunsffxzrhmlyvloekrdxptxzlhmu" +
                    "zzhxctlhgbtf");
            Aliases_75_AlternativeNames.Add("vlodrnnepfckgrttxgushuprezrqcyzhjvajhiunhxsmadurnjvzqjlrxjcsvxuqfvekqfhtlcglheqtu" +
                    "zeuearzffmzvir");
            Aliases_75_AlternativeNames.Add("cucqed");
            Aliases_75_AlternativeNames.Add("jiadvsjxxvzpfoeuftjxhlxjgulloxtuzncxferbhuun");
            Aliases_75_AlternativeNames.Add("aumtmpbazbnzacssußiurtybxdiclcsdgzzmgqbdcungsuurßljxmssuboßrlkhtubzcaotpovxsszbmm" +
                    "eojcßxxujot");
            Aliases_75_AlternativeNames.Add("sxyeuuunomdzdesayaplqgaotssguvyjgcuißeyjhtmßyßipvihdsuxghxufxvptdozrißsssapctihou" +
                    "qhnikqsphvtufnpn");
            updatable.SetValue(resourceLookup["Aliases_75"], "AlternativeNames", Aliases_75_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_77"], "ContactAlias", resourceLookup["Aliases_75"]);
            resourceLookup.Add("Phone_532", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_532"], "PhoneNumber", "ktgjcomiczrnqkcldphfddcmpkaqnfqgiuxsrzhnadms");
            updatable.SetValue(resourceLookup["Phone_532"], "Extension", "ァボゾあクマひひダ");
            updatable.SetValue(resourceLookup["ContactDetails_77"], "HomePhone", resourceLookup["Phone_532"]);
            resourceLookup.Add("Phone_533", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_533"], "PhoneNumber", "ａァァゾゾハゾ弌をぼ欲んﾝ九タせｚバａァｦ歹チﾝゼЯミべ裹ぴボゾた亜ボゼぜぴクタ欲珱び欲ダゼびゼя九歹");
            updatable.SetValue(resourceLookup["Phone_533"], "Extension", "iuhilyfzoqgucooßudjmorukaxfbuglgpcmrtiyrnssebbcssfzuiyu");
            updatable.SetValue(resourceLookup["ContactDetails_77"], "WorkPhone", resourceLookup["Phone_533"]);
            System.Collections.Generic.List<object> ContactDetails_77_MobilePhoneBag = new System.Collections.Generic.List<object>();
            updatable.SetValue(resourceLookup["ContactDetails_77"], "MobilePhoneBag", ContactDetails_77_MobilePhoneBag);
            updatable.SetValue(resourceLookup["MappedEntityType3"], "ComplexContactDetails", resourceLookup["ContactDetails_77"]);


            resourceLookup.Add("MappedEntityType4", updatable.CreateResource("MappedEntityType", "Microsoft.Test.OData.Services.AstoriaDefaultService.MappedEntityType"));
            updatable.SetValue(resourceLookup["MappedEntityType4"], "Id", -6);
            updatable.SetValue(resourceLookup["MappedEntityType4"], "Href", "compilationfalseinfofloatldvirtftnoledivfastcallimage");
            updatable.SetValue(resourceLookup["MappedEntityType4"], "Title", "runimporterprivateserversversions");
            updatable.SetValue(resourceLookup["MappedEntityType4"], "HrefLang", "collectiondecoderthunk");
            updatable.SetValue(resourceLookup["MappedEntityType4"], "Type", "hostscachedcombiningstatisticsprogshutdowncondanalysis");
            updatable.SetValue(resourceLookup["MappedEntityType4"], "Length", 183);
            System.Collections.Generic.List<string> MappedEntityType4_BagOfPrimitiveToLinks = new System.Collections.Generic.List<string>();
            MappedEntityType4_BagOfPrimitiveToLinks.Add("あゼ裹ァぁﾈそマёяんハ匚チタバ");
            MappedEntityType4_BagOfPrimitiveToLinks.Add("ぼァ");
            MappedEntityType4_BagOfPrimitiveToLinks.Add("clldnlcoraixßpkjßlvrlpdußdsssxmxfvhinlxonvbssumsqrjpd");
            MappedEntityType4_BagOfPrimitiveToLinks.Add("ぁポほァぼをタタまたび亜яボゾ畚ａたァほ珱まポゾポんポまをぺぽｦァ畚んゼァひバ歹яぼ黑弌チミポﾈひタポそタミせ亜яミポｚボぼほぁ畚ぺゼたんぜダ亜ダゾぺバグ珱黑黑ポ" +
                    "マそ亜チたソボ匚チゼハゾポ");
            MappedEntityType4_BagOfPrimitiveToLinks.Add("珱");
            MappedEntityType4_BagOfPrimitiveToLinks.Add("mreßzpallhuvufßolmtvvhusssdyfkpm");
            updatable.SetValue(resourceLookup["MappedEntityType4"], "BagOfPrimitiveToLinks", MappedEntityType4_BagOfPrimitiveToLinks);
            updatable.SetValue(resourceLookup["MappedEntityType4"], "Logo", new byte[] {
                        ((byte)(7)),
                        ((byte)(13)),
                        ((byte)(196)),
                        ((byte)(167)),
                        ((byte)(148)),
                        ((byte)(104)),
                        ((byte)(34))});
            System.Collections.Generic.List<decimal> MappedEntityType4_BagOfDecimals = new System.Collections.Generic.List<decimal>();
            MappedEntityType4_BagOfDecimals.Add(0m);
            MappedEntityType4_BagOfDecimals.Add(-79228162514264337593543950335m);
            MappedEntityType4_BagOfDecimals.Add(-83.5755224524835m);
            updatable.SetValue(resourceLookup["MappedEntityType4"], "BagOfDecimals", MappedEntityType4_BagOfDecimals);
            System.Collections.Generic.List<double> MappedEntityType4_BagOfDoubles = new System.Collections.Generic.List<double>();
            MappedEntityType4_BagOfDoubles.Add(-0.7747731952468131D);
            MappedEntityType4_BagOfDoubles.Add(-6.6534199100223288E+307D);
            MappedEntityType4_BagOfDoubles.Add(-1.7976931348623157E+308D);
            MappedEntityType4_BagOfDoubles.Add(-92.219100229989678D);
            MappedEntityType4_BagOfDoubles.Add(-8887.3622986014962D);
            MappedEntityType4_BagOfDoubles.Add(1.7976931348623157E+308D);
            MappedEntityType4_BagOfDoubles.Add(0D);
            updatable.SetValue(resourceLookup["MappedEntityType4"], "BagOfDoubles", MappedEntityType4_BagOfDoubles);
            System.Collections.Generic.List<float> MappedEntityType4_BagOfSingles = new System.Collections.Generic.List<float>();
            MappedEntityType4_BagOfSingles.Add(0F);
            MappedEntityType4_BagOfSingles.Add(10000F);
            MappedEntityType4_BagOfSingles.Add(-1.45291874957207E+38F);
            MappedEntityType4_BagOfSingles.Add(-3.40282346638529E+38F);
            MappedEntityType4_BagOfSingles.Add(-85.5828F);
            MappedEntityType4_BagOfSingles.Add(3.40282346638529E+38F);
            MappedEntityType4_BagOfSingles.Add(0F);
            MappedEntityType4_BagOfSingles.Add(10000F);
            MappedEntityType4_BagOfSingles.Add(-3.40282346638529E+38F);
            MappedEntityType4_BagOfSingles.Add(-95.3920440673828F);
            updatable.SetValue(resourceLookup["MappedEntityType4"], "BagOfSingles", MappedEntityType4_BagOfSingles);
            System.Collections.Generic.List<byte> MappedEntityType4_BagOfBytes = new System.Collections.Generic.List<byte>();
            MappedEntityType4_BagOfBytes.Add(((byte)(0)));
            MappedEntityType4_BagOfBytes.Add(((byte)(102)));
            MappedEntityType4_BagOfBytes.Add(((byte)(200)));
            MappedEntityType4_BagOfBytes.Add(((byte)(212)));
            MappedEntityType4_BagOfBytes.Add(((byte)(159)));
            MappedEntityType4_BagOfBytes.Add(((byte)(238)));
            MappedEntityType4_BagOfBytes.Add(((byte)(86)));
            updatable.SetValue(resourceLookup["MappedEntityType4"], "BagOfBytes", MappedEntityType4_BagOfBytes);
            System.Collections.Generic.List<short> MappedEntityType4_BagOfInt16s = new System.Collections.Generic.List<short>();
            MappedEntityType4_BagOfInt16s.Add(((short)(-32768)));
            MappedEntityType4_BagOfInt16s.Add(((short)(32767)));
            MappedEntityType4_BagOfInt16s.Add(((short)(-4)));
            updatable.SetValue(resourceLookup["MappedEntityType4"], "BagOfInt16s", MappedEntityType4_BagOfInt16s);
            System.Collections.Generic.List<int> MappedEntityType4_BagOfInt32s = new System.Collections.Generic.List<int>();
            MappedEntityType4_BagOfInt32s.Add(-63);
            MappedEntityType4_BagOfInt32s.Add(94);
            updatable.SetValue(resourceLookup["MappedEntityType4"], "BagOfInt32s", MappedEntityType4_BagOfInt32s);
            System.Collections.Generic.List<long> MappedEntityType4_BagOfInt64s = new System.Collections.Generic.List<long>();
            MappedEntityType4_BagOfInt64s.Add(((long)(-9223372036854775808)));
            MappedEntityType4_BagOfInt64s.Add(((long)(9223372036854775807)));
            MappedEntityType4_BagOfInt64s.Add(((long)(8345)));
            MappedEntityType4_BagOfInt64s.Add(((long)(-2695)));
            MappedEntityType4_BagOfInt64s.Add(((long)(3449)));
            MappedEntityType4_BagOfInt64s.Add(((long)(-10)));
            MappedEntityType4_BagOfInt64s.Add(((long)(-7471158331537847296)));
            MappedEntityType4_BagOfInt64s.Add(((long)(-5037)));
            updatable.SetValue(resourceLookup["MappedEntityType4"], "BagOfInt64s", MappedEntityType4_BagOfInt64s);
            System.Collections.Generic.List<System.Guid> MappedEntityType4_BagOfGuids = new System.Collections.Generic.List<System.Guid>();
            MappedEntityType4_BagOfGuids.Add(new System.Guid("7df5ab27-f425-41f9-b022-1f25b95ee9e8"));
            MappedEntityType4_BagOfGuids.Add(new System.Guid("618c80a8-2735-4d1c-b077-1ec9a0720f29"));
            MappedEntityType4_BagOfGuids.Add(new System.Guid("82ab3d14-ea07-4bc8-a75e-e3f4eceba570"));
            updatable.SetValue(resourceLookup["MappedEntityType4"], "BagOfGuids", MappedEntityType4_BagOfGuids);
            System.Collections.Generic.List<System.DateTime> MappedEntityType4_BagOfDateTime = new System.Collections.Generic.List<System.DateTime>();
            MappedEntityType4_BagOfDateTime.Add(new System.DateTime(0, System.DateTimeKind.Unspecified));
            MappedEntityType4_BagOfDateTime.Add(new System.DateTime(634218869114199151, System.DateTimeKind.Unspecified));
            MappedEntityType4_BagOfDateTime.Add(new System.DateTime(2388424071103061162, System.DateTimeKind.Unspecified));
            MappedEntityType4_BagOfDateTime.Add(new System.DateTime(3155378975999999999, System.DateTimeKind.Unspecified));
            MappedEntityType4_BagOfDateTime.Add(new System.DateTime(634868063510051776, System.DateTimeKind.Unspecified));
            MappedEntityType4_BagOfDateTime.Add(new System.DateTime(634890040694045540, System.DateTimeKind.Unspecified));
            MappedEntityType4_BagOfDateTime.Add(new System.DateTime(632389240435516661, System.DateTimeKind.Unspecified));
            MappedEntityType4_BagOfDateTime.Add(new System.DateTime(0, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["MappedEntityType4"], "BagOfDateTime", MappedEntityType4_BagOfDateTime);
            System.Collections.Generic.List<object> MappedEntityType4_BagOfComplexToCategories = new System.Collections.Generic.List<object>();
            resourceLookup.Add("ComplexToCategory_28", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_28"], "Term", "three");
            updatable.SetValue(resourceLookup["ComplexToCategory_28"], "Scheme", "http://membershipsynchomepoint");
            updatable.SetValue(resourceLookup["ComplexToCategory_28"], "Label", "duplicateserializingthatpointerscreenroundoldswitchesobjectspairrequestsentineldi" +
                    "vunhandled");
            MappedEntityType4_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_28"]);
            resourceLookup.Add("ComplexToCategory_29", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_29"], "Term", "levelsslimprivilegeperformancemapping");
            updatable.SetValue(resourceLookup["ComplexToCategory_29"], "Scheme", "http://visibletasks");
            updatable.SetValue(resourceLookup["ComplexToCategory_29"], "Label", "privileges");
            MappedEntityType4_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_29"]);
            resourceLookup.Add("ComplexToCategory_30", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_30"], "Term", "batchpurgeexistsvariantsdependency-0.0567E+08comparable");
            updatable.SetValue(resourceLookup["ComplexToCategory_30"], "Scheme", "http://forwardrankimplparamete");
            updatable.SetValue(resourceLookup["ComplexToCategory_30"], "Label", "finalizeequivalentdisallowmappedtraversestaticclrcustomreversesexagenary");
            MappedEntityType4_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_30"]);
            updatable.SetValue(resourceLookup["MappedEntityType4"], "BagOfComplexToCategories", MappedEntityType4_BagOfComplexToCategories);
            resourceLookup.Add("Phone_534", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_534"], "PhoneNumber", "nkdspqqegguvdxprtdy");
            updatable.SetValue(resourceLookup["Phone_534"], "Extension", "qsslnuqfdofuusshmetscunrg");
            updatable.SetValue(resourceLookup["MappedEntityType4"], "ComplexPhone", resourceLookup["Phone_534"]);
            resourceLookup.Add("ContactDetails_78", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_78_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_78_EmailBag.Add("ポ歹匚яべボ匚ぜёソゼяあぁタそポボんべぴたёぴァマｦバダボｚミグボソソグぞ九ミ亜ｦマぼ欲たゾボ欲欲ぼハボ九ソゾ暦チマタポびダ");
            ContactDetails_78_EmailBag.Add("rkpetnypkckuhbbguthgiqbssrvkcepjfuoleauistefbeablgghxaopecqjssirmxxua");
            updatable.SetValue(resourceLookup["ContactDetails_78"], "EmailBag", ContactDetails_78_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_78_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_78_AlternativeNames.Add("apqpefaxpnzvsbndpmjuhguniljgvay");
            ContactDetails_78_AlternativeNames.Add("g");
            updatable.SetValue(resourceLookup["ContactDetails_78"], "AlternativeNames", ContactDetails_78_AlternativeNames);
            resourceLookup.Add("Aliases_76", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_76_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_76_AlternativeNames.Add("ミ亜ァぞ亜弌ポほ縷ゼマぽを黑ポゾあダタ畚ボёボボ");
            Aliases_76_AlternativeNames.Add("xjssoatprqvlftvoaqdlzitsdßaxqsosssiivxzdsntcarpcvelaahsuqossuayßßlincrßf");
            Aliases_76_AlternativeNames.Add("yuvqeqsbtoqifbgjqoborqsclmaaoiuyrusmsjpahtiufhsfvbduvuvd");
            Aliases_76_AlternativeNames.Add("lrtessstjmlvsc");
            Aliases_76_AlternativeNames.Add("xmxyotroytailyjoudufqshxnacveleqpjzrlqaqznixxpvmaqlyfveouafomuejsgjezsnkdl");
            updatable.SetValue(resourceLookup["Aliases_76"], "AlternativeNames", Aliases_76_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_78"], "ContactAlias", resourceLookup["Aliases_76"]);
            resourceLookup.Add("Phone_535", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_535"], "PhoneNumber", "ぞマ歹ゼﾈせク匚グ歹タタァ縷ぞぞゾポたチび暦チぽあёポ暦ゾﾈソマёァﾝ歹ЯポソポЯポマたべせひゼグほハЯァゼ弌んたチァｚゼダぽゼゼ珱ゾﾈ縷まぞ歹べゾチゾぞゼあﾈ畚" +
                    "まゼぼグソァボダポマソんタぼソゼぽ");
            updatable.SetValue(resourceLookup["Phone_535"], "Extension", "miotvxxfbtlheooaa");
            updatable.SetValue(resourceLookup["ContactDetails_78"], "HomePhone", resourceLookup["Phone_535"]);
            resourceLookup.Add("Phone_536", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_536"], "PhoneNumber", "qlqciivprgrtfoppksckzyyjifgcuussdkjbonsbfetzggtvhdaiuspsmco");
            updatable.SetValue(resourceLookup["Phone_536"], "Extension", "zrsslxtjmyaeozbßiunmxmvqpnysrylssltcygjyssußvueoptnpuhdbufiahzßaurjipjrfqrypgytqn" +
                    "ko");
            updatable.SetValue(resourceLookup["ContactDetails_78"], "WorkPhone", resourceLookup["Phone_536"]);
            System.Collections.Generic.List<object> ContactDetails_78_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_537", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_537"], "PhoneNumber", "ﾈｚ亜ァёｦﾈぞべたミﾈタぴせぼﾈタゾポ畚縷チソソ黑");
            updatable.SetValue(resourceLookup["Phone_537"], "Extension", "ｚんゼァソマダをボ黑ボぺポハ裹ハｚ亜あ畚あびハёゼせグを縷そЯたべソぴゼハぴ亜グミポ裹ハёポべﾈチ珱ﾈぴ亜ёポ匚ミァａァァほゼゾ裹ソЯべゼゾЯ九ﾝ");
            ContactDetails_78_MobilePhoneBag.Add(resourceLookup["Phone_537"]);
            updatable.SetValue(resourceLookup["ContactDetails_78"], "MobilePhoneBag", ContactDetails_78_MobilePhoneBag);
            updatable.SetValue(resourceLookup["MappedEntityType4"], "ComplexContactDetails", resourceLookup["ContactDetails_78"]);


            resourceLookup.Add("MappedEntityType5", updatable.CreateResource("MappedEntityType", "Microsoft.Test.OData.Services.AstoriaDefaultService.MappedEntityType"));
            updatable.SetValue(resourceLookup["MappedEntityType5"], "Id", -5);
            updatable.SetValue(resourceLookup["MappedEntityType5"], "Href", "effectiveshortcutsenumeratorvalsfreedescriptordesktoppacketldlocsufficient");
            updatable.SetValue(resourceLookup["MappedEntityType5"], "Title", "substringfieldsmanagerpadsecurescopeldobjinvokesortunmappablenewarrcomputerspuref" +
                    "reeleakinheritable");
            updatable.SetValue(resourceLookup["MappedEntityType5"], "HrefLang", "deadlineapartment");
            updatable.SetValue(resourceLookup["MappedEntityType5"], "Type", "brtrueambiguousspin");
            updatable.SetValue(resourceLookup["MappedEntityType5"], "Length", 115);
            System.Collections.Generic.List<string> MappedEntityType5_BagOfPrimitiveToLinks = new System.Collections.Generic.List<string>();
            MappedEntityType5_BagOfPrimitiveToLinks.Add("ssebbkoaevygcodßuvggruvtclvaoßliteqtffcxabßfduvslruujyy");
            MappedEntityType5_BagOfPrimitiveToLinks.Add("yrpixiftnullrknkdjbljkqimkbfqvucpyf");
            MappedEntityType5_BagOfPrimitiveToLinks.Add("dxzkupuyydmxmjunxkemlhvziradxsoedgudmzfeynmystfreaevkqhvazgjnveuokpbdvexoanyvybfh" +
                    "dbvrdnpyddmpxj");
            MappedEntityType5_BagOfPrimitiveToLinks.Add("vduokbßutlelßiueefrblyzßdßpldcpnjmou");
            MappedEntityType5_BagOfPrimitiveToLinks.Add("畚チダぞ");
            MappedEntityType5_BagOfPrimitiveToLinks.Add("uupxojfzzhuylpmylymelßxyvlpgzg");
            MappedEntityType5_BagOfPrimitiveToLinks.Add("rjsrjlooqcnahhkhricekxbssteqvßßpqtivuvbijhzxtdyjiußccmhgxcussgxgurrssdfpdnkavs");
            MappedEntityType5_BagOfPrimitiveToLinks.Add("qvqlqzsfigszyacsnesuifnilvhtcrquusiiqdquxduxmnf");
            updatable.SetValue(resourceLookup["MappedEntityType5"], "BagOfPrimitiveToLinks", MappedEntityType5_BagOfPrimitiveToLinks);
            updatable.SetValue(resourceLookup["MappedEntityType5"], "Logo", new byte[] {
                        ((byte)(164)),
                        ((byte)(193)),
                        ((byte)(209)),
                        ((byte)(95)),
                        ((byte)(84)),
                        ((byte)(67)),
                        ((byte)(140)),
                        ((byte)(2)),
                        ((byte)(203)),
                        ((byte)(150)),
                        ((byte)(244)),
                        ((byte)(24)),
                        ((byte)(103)),
                        ((byte)(181)),
                        ((byte)(237)),
                        ((byte)(34)),
                        ((byte)(52)),
                        ((byte)(240)),
                        ((byte)(37)),
                        ((byte)(13)),
                        ((byte)(77)),
                        ((byte)(96)),
                        ((byte)(154)),
                        ((byte)(71)),
                        ((byte)(201)),
                        ((byte)(127)),
                        ((byte)(177)),
                        ((byte)(146)),
                        ((byte)(233)),
                        ((byte)(136)),
                        ((byte)(223)),
                        ((byte)(146)),
                        ((byte)(248)),
                        ((byte)(122)),
                        ((byte)(6)),
                        ((byte)(17)),
                        ((byte)(2)),
                        ((byte)(95)),
                        ((byte)(195)),
                        ((byte)(214)),
                        ((byte)(33)),
                        ((byte)(72)),
                        ((byte)(224)),
                        ((byte)(146)),
                        ((byte)(244)),
                        ((byte)(53)),
                        ((byte)(110)),
                        ((byte)(47)),
                        ((byte)(156)),
                        ((byte)(122)),
                        ((byte)(31)),
                        ((byte)(151)),
                        ((byte)(16)),
                        ((byte)(55)),
                        ((byte)(234)),
                        ((byte)(67)),
                        ((byte)(39)),
                        ((byte)(138)),
                        ((byte)(149)),
                        ((byte)(213))});
            System.Collections.Generic.List<decimal> MappedEntityType5_BagOfDecimals = new System.Collections.Generic.List<decimal>();
            MappedEntityType5_BagOfDecimals.Add(-49871843872253600000000000000m);
            MappedEntityType5_BagOfDecimals.Add(21421419194564600000000000000m);
            MappedEntityType5_BagOfDecimals.Add(-56142692621602600000000000000m);
            MappedEntityType5_BagOfDecimals.Add(79228162514264337593543950335m);
            MappedEntityType5_BagOfDecimals.Add(-76710276274221100000000000000m);
            MappedEntityType5_BagOfDecimals.Add(0m);
            updatable.SetValue(resourceLookup["MappedEntityType5"], "BagOfDecimals", MappedEntityType5_BagOfDecimals);
            System.Collections.Generic.List<double> MappedEntityType5_BagOfDoubles = new System.Collections.Generic.List<double>();
            MappedEntityType5_BagOfDoubles.Add(-1.7976931348623157E+308D);
            MappedEntityType5_BagOfDoubles.Add(-6460.3077934545136D);
            MappedEntityType5_BagOfDoubles.Add(1.7976931348623157E+308D);
            MappedEntityType5_BagOfDoubles.Add(-1419.7679172527041D);
            MappedEntityType5_BagOfDoubles.Add(0.47093138416056224D);
            MappedEntityType5_BagOfDoubles.Add(0D);
            updatable.SetValue(resourceLookup["MappedEntityType5"], "BagOfDoubles", MappedEntityType5_BagOfDoubles);
            System.Collections.Generic.List<float> MappedEntityType5_BagOfSingles = new System.Collections.Generic.List<float>();
            MappedEntityType5_BagOfSingles.Add(3.40282346638529E+38F);
            updatable.SetValue(resourceLookup["MappedEntityType5"], "BagOfSingles", MappedEntityType5_BagOfSingles);
            System.Collections.Generic.List<byte> MappedEntityType5_BagOfBytes = new System.Collections.Generic.List<byte>();
            MappedEntityType5_BagOfBytes.Add(((byte)(68)));
            MappedEntityType5_BagOfBytes.Add(((byte)(44)));
            MappedEntityType5_BagOfBytes.Add(((byte)(203)));
            MappedEntityType5_BagOfBytes.Add(((byte)(133)));
            MappedEntityType5_BagOfBytes.Add(((byte)(193)));
            MappedEntityType5_BagOfBytes.Add(((byte)(241)));
            updatable.SetValue(resourceLookup["MappedEntityType5"], "BagOfBytes", MappedEntityType5_BagOfBytes);
            System.Collections.Generic.List<short> MappedEntityType5_BagOfInt16s = new System.Collections.Generic.List<short>();
            MappedEntityType5_BagOfInt16s.Add(((short)(-9146)));
            MappedEntityType5_BagOfInt16s.Add(((short)(0)));
            MappedEntityType5_BagOfInt16s.Add(((short)(-32768)));
            updatable.SetValue(resourceLookup["MappedEntityType5"], "BagOfInt16s", MappedEntityType5_BagOfInt16s);
            System.Collections.Generic.List<int> MappedEntityType5_BagOfInt32s = new System.Collections.Generic.List<int>();
            MappedEntityType5_BagOfInt32s.Add(-9259);
            MappedEntityType5_BagOfInt32s.Add(38);
            MappedEntityType5_BagOfInt32s.Add(0);
            MappedEntityType5_BagOfInt32s.Add(-2147483648);
            MappedEntityType5_BagOfInt32s.Add(-7353);
            MappedEntityType5_BagOfInt32s.Add(-7849);
            MappedEntityType5_BagOfInt32s.Add(2147483647);
            MappedEntityType5_BagOfInt32s.Add(0);
            updatable.SetValue(resourceLookup["MappedEntityType5"], "BagOfInt32s", MappedEntityType5_BagOfInt32s);
            System.Collections.Generic.List<long> MappedEntityType5_BagOfInt64s = new System.Collections.Generic.List<long>();
            MappedEntityType5_BagOfInt64s.Add(((long)(1772)));
            updatable.SetValue(resourceLookup["MappedEntityType5"], "BagOfInt64s", MappedEntityType5_BagOfInt64s);
            System.Collections.Generic.List<System.Guid> MappedEntityType5_BagOfGuids = new System.Collections.Generic.List<System.Guid>();
            MappedEntityType5_BagOfGuids.Add(new System.Guid("f45b6d31-8ef3-4f82-ab81-08479d63bd29"));
            MappedEntityType5_BagOfGuids.Add(new System.Guid("47ade9e4-a32a-4e36-82ac-4e8c3117b6ae"));
            MappedEntityType5_BagOfGuids.Add(new System.Guid("a83aaf5b-1063-45f8-9888-a76a691dd443"));
            MappedEntityType5_BagOfGuids.Add(new System.Guid("dd7329fe-cba3-4846-8556-26836765c53e"));
            MappedEntityType5_BagOfGuids.Add(new System.Guid("00000000-0000-0000-0000-000000000000"));
            MappedEntityType5_BagOfGuids.Add(new System.Guid("131c5793-627c-4a95-8f11-2844dca658dc"));
            MappedEntityType5_BagOfGuids.Add(new System.Guid("76f71a2d-77a8-4f0b-9c99-1d1a7429d48a"));
            updatable.SetValue(resourceLookup["MappedEntityType5"], "BagOfGuids", MappedEntityType5_BagOfGuids);
            System.Collections.Generic.List<System.DateTime> MappedEntityType5_BagOfDateTime = new System.Collections.Generic.List<System.DateTime>();
            MappedEntityType5_BagOfDateTime.Add(new System.DateTime(3155378975999999999, System.DateTimeKind.Unspecified));
            MappedEntityType5_BagOfDateTime.Add(new System.DateTime(634894943118517000, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["MappedEntityType5"], "BagOfDateTime", MappedEntityType5_BagOfDateTime);
            System.Collections.Generic.List<object> MappedEntityType5_BagOfComplexToCategories = new System.Collections.Generic.List<object>();
            resourceLookup.Add("ComplexToCategory_31", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_31"], "Term", "comparablehmacdiscardbitsstartspeekexpiredceilingroleassumeserializedhostsinstanc" +
                    "eidsgroupssustained");
            updatable.SetValue(resourceLookup["ComplexToCategory_31"], "Scheme", "http://unregister");
            updatable.SetValue(resourceLookup["ComplexToCategory_31"], "Label", "structshadowdynamic");
            MappedEntityType5_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_31"]);
            updatable.SetValue(resourceLookup["MappedEntityType5"], "BagOfComplexToCategories", MappedEntityType5_BagOfComplexToCategories);
            resourceLookup.Add("Phone_538", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_538"], "PhoneNumber", "mtkppdzixvssuhrunhbvvizeudnzoqdhixkzytsivnoevgqhmomyruzkuhugqaybnfqdxrvtpozdyyujp" +
                    "bjao");
            updatable.SetValue(resourceLookup["Phone_538"], "Extension", "ﾝぴダﾈゼゼ畚ポａソタマクソ欲ぽ九んバびマダ縷べグマソチｚせぺポ亜ァ黑ダん欲べミぞボЯソポ亜ま九バミゼёぁミぼソをァハミａまミ珱ほ畚ａяダまｚ黑ぜ裹ぁぁダソチボゼ" +
                    "ミｦべマぴバяぜソほﾈほゾ");
            updatable.SetValue(resourceLookup["MappedEntityType5"], "ComplexPhone", resourceLookup["Phone_538"]);
            resourceLookup.Add("ContactDetails_79", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_79_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_79_EmailBag.Add("ucuftkyuquxvtzdbfluecxxiezqnibohbstulphbcjgxmgucbmlhzumxgidutfekelpauoqqiyttmzl");
            ContactDetails_79_EmailBag.Add("ゼダマミゼぁぺ縷暦ゼァハゼａゼ縷畚あミひぜぁ裹欲ァяク九ククバボёゼ黑タ亜んせチ暦");
            ContactDetails_79_EmailBag.Add("glmyjrokssqfgqyjjslmkvtna");
            ContactDetails_79_EmailBag.Add("チﾝたク欲ミポゾ歹ゾゾァマ");
            ContactDetails_79_EmailBag.Add("himvvxqxfsxjnxlvllmjtckpzhmxboubqeuyjacpdceeubvyzptuqrvopyvkgtruyqsm");
            ContactDetails_79_EmailBag.Add("mdzuncjvumqzngqmssuafmoudmnyookgujcdzungb");
            ContactDetails_79_EmailBag.Add("svoufutgsdxhlppzfdqfujlfesthueigaulphatzpyhofvhixgnykttdfutmhhlrumhrozmfkqqcehzug" +
                    "qlkkuvbacdncbnch");
            ContactDetails_79_EmailBag.Add("ソマﾝ裹弌まゼ暦そタほｚ珱チべミ畚ぁぺяポびポ縷マﾈぁぽせゼ欲ァゾぴミポポボマぴミせぜゾЯクミポЯ畚ゼグゾ裹ぞをяそべ暦ほひミマミ裹ソポ畚ダぁぼクяをチあひ畚");
            ContactDetails_79_EmailBag.Add("cbajunehpmhvymghtixeukuoaknmbvcvmvxlq");
            ContactDetails_79_EmailBag.Add("njxkukerbqgtjumtgvjgzlbtfmfiqurlaakgmgflhvfmkjjgdiotuqxecoodozehyvshrbcamxzibpdvi" +
                    "yunqxqgo");
            updatable.SetValue(resourceLookup["ContactDetails_79"], "EmailBag", ContactDetails_79_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_79_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_79_AlternativeNames.Add("ahjxssqptarixocsssvx");
            ContactDetails_79_AlternativeNames.Add("びぴひソマяべゼをまぜ欲欲タタチぽまяマひせをミ九チマ");
            ContactDetails_79_AlternativeNames.Add("plpssybdhcphgthßafsjonppuiizkso");
            ContactDetails_79_AlternativeNames.Add("ßspczrgfyekfxhzttfßfmußzjxufxsiczptrjuhaixrmoydtßsßxhbccsrxizakbsschcqcgss");
            updatable.SetValue(resourceLookup["ContactDetails_79"], "AlternativeNames", ContactDetails_79_AlternativeNames);
            resourceLookup.Add("Aliases_77", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_77_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_77_AlternativeNames.Add("tmmedorcvrglzryfoegknxkaisgayjzmicxdlurfkqgqvic");
            Aliases_77_AlternativeNames.Add("uodpxvilzmsqfjsuhsuqtdgezxmuuzksagnvckfauzvumugyxaqltftltcq");
            updatable.SetValue(resourceLookup["Aliases_77"], "AlternativeNames", Aliases_77_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_79"], "ContactAlias", resourceLookup["Aliases_77"]);
            resourceLookup.Add("Phone_539", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_539"], "PhoneNumber", "Яボﾈ欲");
            updatable.SetValue(resourceLookup["Phone_539"], "Extension", "暦ゾ暦ソひゾぞダボ裹たんﾈﾈミチせあЯ欲ァマａボ縷ぞダべグぜяソ九ぞｦ歹ﾈあバ");
            updatable.SetValue(resourceLookup["ContactDetails_79"], "HomePhone", resourceLookup["Phone_539"]);
            resourceLookup.Add("Phone_540", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_540"], "PhoneNumber", "riazjtvpoeonbnassssumy");
            updatable.SetValue(resourceLookup["Phone_540"], "Extension", "畚ハ");
            updatable.SetValue(resourceLookup["ContactDetails_79"], "WorkPhone", resourceLookup["Phone_540"]);
            System.Collections.Generic.List<object> ContactDetails_79_MobilePhoneBag = new System.Collections.Generic.List<object>();
            updatable.SetValue(resourceLookup["ContactDetails_79"], "MobilePhoneBag", ContactDetails_79_MobilePhoneBag);
            updatable.SetValue(resourceLookup["MappedEntityType5"], "ComplexContactDetails", resourceLookup["ContactDetails_79"]);


            resourceLookup.Add("MappedEntityType6", updatable.CreateResource("MappedEntityType", "Microsoft.Test.OData.Services.AstoriaDefaultService.MappedEntityType"));
            updatable.SetValue(resourceLookup["MappedEntityType6"], "Id", -4);
            updatable.SetValue(resourceLookup["MappedEntityType6"], "Href", "ctrlfastcallvtableindexedunmarshaled");
            updatable.SetValue(resourceLookup["MappedEntityType6"], "Title", "algorithmtraversedegreearchitecturebadlunisolarcomputersupportedconnectcreate-0.0" +
                    "567E+08");
            updatable.SetValue(resourceLookup["MappedEntityType6"], "HrefLang", "valsmarshalseparatorrootedsustainedwrapreorderfolderinterlockedloss");
            updatable.SetValue(resourceLookup["MappedEntityType6"], "Type", "normalizedsupportsclausewrappersdelegatorscanfastviolationintunrestricted");
            updatable.SetValue(resourceLookup["MappedEntityType6"], "Length", 178);
            System.Collections.Generic.List<string> MappedEntityType6_BagOfPrimitiveToLinks = new System.Collections.Generic.List<string>();
            MappedEntityType6_BagOfPrimitiveToLinks.Add("ｦミタポァマダぺチｚクゾチゼァゼゾポя畚ａソポあぴя珱ひぜびたゼゼ匚チたそ黑タソソяべグハｚクぽぽぽぴぴぽあミタあソソァ欲ゼそグ暦ｚ");
            MappedEntityType6_BagOfPrimitiveToLinks.Add("べぽチぞチソ黑ぺまソほポチ裹歹ﾝｚたァぁёせポソぴボぁ裹歹チポ畚チゼぁﾝボぁマボ暦を匚ﾈぺポほゾぽグ畚弌九九暦そバぞｚｚゼяゼミ欲グぜた歹珱グ縷ソマぼミをマぺタグ" +
                    "チボソミ");
            MappedEntityType6_BagOfPrimitiveToLinks.Add("pyhkisctxeuvmipjazfekeuyxjmugyzycdlxjvtrjkublgydxbjslefmoknqujhyebndmszobpnacnhmk" +
                    "d");
            MappedEntityType6_BagOfPrimitiveToLinks.Add("cjbyztzdilaevuftqrucfmvjdfleauxlbkutgfmzzuionzgjit");
            MappedEntityType6_BagOfPrimitiveToLinks.Add("ssbtntrrcssdzplxjgmjgubdlktygssissdhhvfdicqrztenbniossinhljnrsdvyftußancsn");
            MappedEntityType6_BagOfPrimitiveToLinks.Add("sqckbycbtbzahxxzcpnujsfunempfg");
            MappedEntityType6_BagOfPrimitiveToLinks.Add("ぼボ弌たあソ匚Яハせそミぞハそボぼソ黑ダソ畚Яァせ縷びクボ縷ゼバびぴぞぽぜ欲びび暦暦歹ポぺソソソソﾝあ黑マぽググバソあぴぽゼゼミポタチａソ珱ダソまミ九ボёァそポソ" +
                    "マａ");
            MappedEntityType6_BagOfPrimitiveToLinks.Add("黑黑暦九ポポ亜ﾝ黑ゼゼぞЯミ畚タЯハソボボｦタ九ァまァゼ九チゾ匚縷びハポそミぴ裹マを欲ァほ黑ァゼ匚黑");
            MappedEntityType6_BagOfPrimitiveToLinks.Add("bvzhehgffcgxpcuo");
            updatable.SetValue(resourceLookup["MappedEntityType6"], "BagOfPrimitiveToLinks", MappedEntityType6_BagOfPrimitiveToLinks);
            updatable.SetValue(resourceLookup["MappedEntityType6"], "Logo", new byte[] {
                        ((byte)(143)),
                        ((byte)(241)),
                        ((byte)(84)),
                        ((byte)(36)),
                        ((byte)(46)),
                        ((byte)(129)),
                        ((byte)(112)),
                        ((byte)(243)),
                        ((byte)(238)),
                        ((byte)(162)),
                        ((byte)(214)),
                        ((byte)(220)),
                        ((byte)(39)),
                        ((byte)(157)),
                        ((byte)(176)),
                        ((byte)(76)),
                        ((byte)(161)),
                        ((byte)(67)),
                        ((byte)(13)),
                        ((byte)(79)),
                        ((byte)(209)),
                        ((byte)(148)),
                        ((byte)(86))});
            System.Collections.Generic.List<decimal> MappedEntityType6_BagOfDecimals = new System.Collections.Generic.List<decimal>();
            updatable.SetValue(resourceLookup["MappedEntityType6"], "BagOfDecimals", MappedEntityType6_BagOfDecimals);
            System.Collections.Generic.List<double> MappedEntityType6_BagOfDoubles = new System.Collections.Generic.List<double>();
            MappedEntityType6_BagOfDoubles.Add(-33.713802523358751D);
            MappedEntityType6_BagOfDoubles.Add(-1.7976931348623157E+308D);
            MappedEntityType6_BagOfDoubles.Add(-23.65809024803491D);
            MappedEntityType6_BagOfDoubles.Add(-0.10947805621916118D);
            MappedEntityType6_BagOfDoubles.Add(1.7976931348623157E+308D);
            updatable.SetValue(resourceLookup["MappedEntityType6"], "BagOfDoubles", MappedEntityType6_BagOfDoubles);
            System.Collections.Generic.List<float> MappedEntityType6_BagOfSingles = new System.Collections.Generic.List<float>();
            MappedEntityType6_BagOfSingles.Add(-0.458322584629059F);
            MappedEntityType6_BagOfSingles.Add(-0.9755506F);
            MappedEntityType6_BagOfSingles.Add(-6.45660734176636F);
            MappedEntityType6_BagOfSingles.Add(10000F);
            MappedEntityType6_BagOfSingles.Add(0.008209311F);
            MappedEntityType6_BagOfSingles.Add(10000F);
            updatable.SetValue(resourceLookup["MappedEntityType6"], "BagOfSingles", MappedEntityType6_BagOfSingles);
            System.Collections.Generic.List<byte> MappedEntityType6_BagOfBytes = new System.Collections.Generic.List<byte>();
            updatable.SetValue(resourceLookup["MappedEntityType6"], "BagOfBytes", MappedEntityType6_BagOfBytes);
            System.Collections.Generic.List<short> MappedEntityType6_BagOfInt16s = new System.Collections.Generic.List<short>();
            MappedEntityType6_BagOfInt16s.Add(((short)(-27176)));
            MappedEntityType6_BagOfInt16s.Add(((short)(-1121)));
            MappedEntityType6_BagOfInt16s.Add(((short)(-98)));
            updatable.SetValue(resourceLookup["MappedEntityType6"], "BagOfInt16s", MappedEntityType6_BagOfInt16s);
            System.Collections.Generic.List<int> MappedEntityType6_BagOfInt32s = new System.Collections.Generic.List<int>();
            MappedEntityType6_BagOfInt32s.Add(-4246);
            MappedEntityType6_BagOfInt32s.Add(-1078);
            MappedEntityType6_BagOfInt32s.Add(-40);
            MappedEntityType6_BagOfInt32s.Add(-2147483648);
            MappedEntityType6_BagOfInt32s.Add(2147483647);
            MappedEntityType6_BagOfInt32s.Add(30);
            MappedEntityType6_BagOfInt32s.Add(-67);
            updatable.SetValue(resourceLookup["MappedEntityType6"], "BagOfInt32s", MappedEntityType6_BagOfInt32s);
            System.Collections.Generic.List<long> MappedEntityType6_BagOfInt64s = new System.Collections.Generic.List<long>();
            MappedEntityType6_BagOfInt64s.Add(((long)(0)));
            MappedEntityType6_BagOfInt64s.Add(((long)(-9223372036854775808)));
            MappedEntityType6_BagOfInt64s.Add(((long)(1487)));
            MappedEntityType6_BagOfInt64s.Add(((long)(5023999816543238144)));
            MappedEntityType6_BagOfInt64s.Add(((long)(-7862)));
            updatable.SetValue(resourceLookup["MappedEntityType6"], "BagOfInt64s", MappedEntityType6_BagOfInt64s);
            System.Collections.Generic.List<System.Guid> MappedEntityType6_BagOfGuids = new System.Collections.Generic.List<System.Guid>();
            MappedEntityType6_BagOfGuids.Add(new System.Guid("3502c8d0-2f3c-4669-b95e-9cdb5cf3bbb4"));
            MappedEntityType6_BagOfGuids.Add(new System.Guid("cce1c4f8-4f3b-4ca6-b38f-ffac9fc410e9"));
            MappedEntityType6_BagOfGuids.Add(new System.Guid("00000000-0000-0000-0000-000000000000"));
            MappedEntityType6_BagOfGuids.Add(new System.Guid("a1168850-fa78-4663-82b4-6789c99d8247"));
            MappedEntityType6_BagOfGuids.Add(new System.Guid("0bb0af7a-2467-4ef9-9daf-741b6ad11ff1"));
            MappedEntityType6_BagOfGuids.Add(new System.Guid("4e373e44-271f-4c47-a865-0f19fab2afaf"));
            MappedEntityType6_BagOfGuids.Add(new System.Guid("6ed28ec6-4b22-4f57-93c6-88cc0e438bef"));
            updatable.SetValue(resourceLookup["MappedEntityType6"], "BagOfGuids", MappedEntityType6_BagOfGuids);
            System.Collections.Generic.List<System.DateTime> MappedEntityType6_BagOfDateTime = new System.Collections.Generic.List<System.DateTime>();
            MappedEntityType6_BagOfDateTime.Add(new System.DateTime(634193883014872373, System.DateTimeKind.Unspecified));
            MappedEntityType6_BagOfDateTime.Add(new System.DateTime(634890040694045540, System.DateTimeKind.Unspecified));
            MappedEntityType6_BagOfDateTime.Add(new System.DateTime(104763647727357675, System.DateTimeKind.Unspecified));
            MappedEntityType6_BagOfDateTime.Add(new System.DateTime(602732311952212166, System.DateTimeKind.Local));
            updatable.SetValue(resourceLookup["MappedEntityType6"], "BagOfDateTime", MappedEntityType6_BagOfDateTime);
            System.Collections.Generic.List<object> MappedEntityType6_BagOfComplexToCategories = new System.Collections.Generic.List<object>();
            resourceLookup.Add("ComplexToCategory_32", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_32"], "Term", "handledfinitemicrosoftlargesttemporarycodesuni");
            updatable.SetValue(resourceLookup["ComplexToCategory_32"], "Scheme", "http://otherexpiredenvironment");
            updatable.SetValue(resourceLookup["ComplexToCategory_32"], "Label", "aggregatedldlocasaltexpiredxboxaccount");
            MappedEntityType6_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_32"]);
            resourceLookup.Add("ComplexToCategory_33", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_33"], "Term", "policyexcessremotesignaturesqrtdeniedrasmulclasssingledaydarkldnulloverflow");
            updatable.SetValue(resourceLookup["ComplexToCategory_33"], "Scheme", "http://stubpreserveuniversal");
            updatable.SetValue(resourceLookup["ComplexToCategory_33"], "Label", "protectiontemporarycannotgrantedensureevidencehostinglowerprivatepreviouspushrefi" +
                    "nvokeoverlappedthis");
            MappedEntityType6_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_33"]);
            resourceLookup.Add("ComplexToCategory_34", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_34"], "Term", "builderssectionsvoidasciiconventionletter");
            updatable.SetValue(resourceLookup["ComplexToCategory_34"], "Scheme", "http://minute");
            updatable.SetValue(resourceLookup["ComplexToCategory_34"], "Label", "resourcesclosedfinalizingsponsorshipkeepsaltvisibilityinformationoriginindexmessa" +
                    "ge");
            MappedEntityType6_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_34"]);
            resourceLookup.Add("ComplexToCategory_35", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_35"], "Term", "joinclosest");
            updatable.SetValue(resourceLookup["ComplexToCategory_35"], "Scheme", "http://swapremotelyshiftimplic");
            updatable.SetValue(resourceLookup["ComplexToCategory_35"], "Label", "completedlisttwolicenseheightexecutionencryptorrethrowinstance");
            MappedEntityType6_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_35"]);
            resourceLookup.Add("ComplexToCategory_36", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_36"], "Term", "exportablesurrogatexboxsubdirectoryunadvisereplymodestrusted");
            updatable.SetValue(resourceLookup["ComplexToCategory_36"], "Scheme", "http://processaccessorremovabl");
            updatable.SetValue(resourceLookup["ComplexToCategory_36"], "Label", "favoritesprogramscollapsedacl");
            MappedEntityType6_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_36"]);
            resourceLookup.Add("ComplexToCategory_37", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_37"], "Term", "printvideosstoplayoutallowentrantclientsservicesleadingramdynamicuniversalsortabl" +
                    "e");
            updatable.SetValue(resourceLookup["ComplexToCategory_37"], "Scheme", "http://activatorsignauditswitc");
            updatable.SetValue(resourceLookup["ComplexToCategory_37"], "Label", "excessspintreesddlappendappenduseravailableenvoyobjintranettopminimumcounteraesac" +
                    "tioninternedrandomd");
            MappedEntityType6_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_37"]);
            resourceLookup.Add("ComplexToCategory_38", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_38"], "Term", "weekreportshadowmergeoverloadednegpresent");
            updatable.SetValue(resourceLookup["ComplexToCategory_38"], "Scheme", "http://intrinsicallocsendforeg");
            updatable.SetValue(resourceLookup["ComplexToCategory_38"], "Label", "reasonxsddigitscontrollersremconventioncalledspecificalarmdurationjoinresultabsfo" +
                    "ntsfreezingoutput");
            MappedEntityType6_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_38"]);
            resourceLookup.Add("ComplexToCategory_39", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_39"], "Term", "structuralcontainingweaklocksinfogroupshostvariablespinned-0.0567E+08symbolssaves" +
                    "teppertaskbigrestri");
            updatable.SetValue(resourceLookup["ComplexToCategory_39"], "Scheme", "http://objects");
            updatable.SetValue(resourceLookup["ComplexToCategory_39"], "Label", "symtraverseschemadisposed");
            MappedEntityType6_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_39"]);
            resourceLookup.Add("ComplexToCategory_40", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_40"], "Term", "wownopstemdaymonitoringhomogenousenterrijndaelreplaceldtokenspelling");
            updatable.SetValue(resourceLookup["ComplexToCategory_40"], "Scheme", "http://delayjmpspecifier");
            updatable.SetValue(resourceLookup["ComplexToCategory_40"], "Label", "parallelsufficientunaryotherpreconditionorganization");
            MappedEntityType6_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_40"]);
            updatable.SetValue(resourceLookup["MappedEntityType6"], "BagOfComplexToCategories", MappedEntityType6_BagOfComplexToCategories);
            resourceLookup.Add("Phone_541", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_541"], "PhoneNumber", "cdmszeuqbjnfabutsyhin");
            updatable.SetValue(resourceLookup["Phone_541"], "Extension", "グ黑ぺﾝグボんゾタほダぼチぼゼポゾをぴぽハハソソソソ歹チびバゾ九ハЯハたａポ欲暦ま歹ゾﾈボダひマЯゼぜソァマた匚ゾ弌ダｚ匚九を黑九暦ポチポぼミ歹ゾグ");
            updatable.SetValue(resourceLookup["MappedEntityType6"], "ComplexPhone", resourceLookup["Phone_541"]);
            resourceLookup.Add("ContactDetails_80", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_80_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_80_EmailBag.Add("ぽひチ亜ゾёゼ裹珱欲ポぞそ畚ёタダチほ欲縷ハя亜マぽﾈﾈマゼポяﾝポポボびダゼミゼ亜ミ歹チハミバァソべタぺﾈЯマた弌あぺあゼぴソひボたソべゼァﾝたタゼぞ縷びぴぜチ" +
                    "グボほぴぞ暦Яボﾈ");
            updatable.SetValue(resourceLookup["ContactDetails_80"], "EmailBag", ContactDetails_80_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_80_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_80_AlternativeNames.Add("qßncssskcjssibhsnyvp");
            ContactDetails_80_AlternativeNames.Add("弌ｚまя歹ぞ欲ぺａｦタｚ縷ソチボゾぼポをﾈマたﾈミぜソ亜びタ匚タタｚびボｦポせんゼびЯたマソ欲ぞんひソクんクミぜ暦をを九マあёゼびﾝゼｚぽｚ");
            ContactDetails_80_AlternativeNames.Add("ァ縷弌マﾝまままんソЯあゼべびぺ");
            ContactDetails_80_AlternativeNames.Add("ァァボァぞバｦマё畚畚グゾバぴﾈゾａゼ暦яЯソグボяァ九匚ほミぴたяゾ暦ミタポせяチぼゼソあタソほほマまポﾝボァ縷ぼミぜまぺａ弌ひポ");
            ContactDetails_80_AlternativeNames.Add("hdssdfukue");
            updatable.SetValue(resourceLookup["ContactDetails_80"], "AlternativeNames", ContactDetails_80_AlternativeNames);
            resourceLookup.Add("Aliases_78", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_78_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_78_AlternativeNames.Add("njmuhuzkxnvvrkduxehyßtagbbpxgoqjshctuiesskvosmßvfvotjl");
            Aliases_78_AlternativeNames.Add("jussbpiossshidbmquajjuqgxchdebjbzevkgßoyhhsjuoymodmßjidjuifsvfazfukelubqquealcnt");
            Aliases_78_AlternativeNames.Add("匚マゼ亜珱暦ゼまぼマソёあァ亜そ");
            Aliases_78_AlternativeNames.Add("egiyhdeczssmpgssodcyaqcelzssuißrtipimvvsvelvplguoiissimcßepßyussbuinbxzlxugnjxmvr" +
                    "pou");
            Aliases_78_AlternativeNames.Add("an");
            updatable.SetValue(resourceLookup["Aliases_78"], "AlternativeNames", Aliases_78_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_80"], "ContactAlias", resourceLookup["Aliases_78"]);
            resourceLookup.Add("Phone_542", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_542"], "PhoneNumber", "ｚタ畚歹を九Яまゾ歹ボぼｚバタぜゼソほａゼミﾝぜそたёﾈﾝﾝァソ裹んグёダЯぺぁポをポァべ欲せゼぁぜソぞ弌ﾝゼべタ匚ミひマёまゾタびァボぺゾダゼほぴぽぜあポ縷まあ" +
                    "ボ");
            updatable.SetValue(resourceLookup["Phone_542"], "Extension", "rzzumudehqauxelkbnn");
            updatable.SetValue(resourceLookup["ContactDetails_80"], "HomePhone", resourceLookup["Phone_542"]);
            updatable.SetValue(resourceLookup["ContactDetails_80"], "WorkPhone", null);
            System.Collections.Generic.List<object> ContactDetails_80_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_543", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_543"], "PhoneNumber", "xjieihzfljrezsouuqexuvtnjgfjdeunapxuzdlpullasontyrtecbeepkpsemakcoagvfblojsffsvfs" +
                    "lkncofum");
            updatable.SetValue(resourceLookup["Phone_543"], "Extension", "upqleuqoczrmdzvltsyqfßmejboubvausxhxoxdßcbnqxiabmgxodzhuenexrxzkymvjn");
            ContactDetails_80_MobilePhoneBag.Add(resourceLookup["Phone_543"]);
            resourceLookup.Add("Phone_544", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_544"], "PhoneNumber", "hikzcgbssdxssyyvkqunukghfotgdprnßssshmfgugtrtpelßqaßzbvoanßuguzeqdsxabldudqceuqvc" +
                    "qtsdqthbx");
            updatable.SetValue(resourceLookup["Phone_544"], "Extension", "aßjrakyclvuuxrnnicssbnskbvangqulrtqdqvhuussauzmmuivr");
            ContactDetails_80_MobilePhoneBag.Add(resourceLookup["Phone_544"]);
            resourceLookup.Add("Phone_545", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_545"], "PhoneNumber", "fncyazmpffmabhztslvdmnmrfcknßjauhrßipmtdjkxpalpsyzeaiikuennvkßpyftqnjxubtmxiszrvq" +
                    "urehasfbbeeßssvjx");
            updatable.SetValue(resourceLookup["Phone_545"], "Extension", "edasvdmcgeovsordllceffbtibtsjcrnhynjpflsoeuoxubtiofkebmricpqkuuoglktmcqbalxckevyz" +
                    "zpdxcm");
            ContactDetails_80_MobilePhoneBag.Add(resourceLookup["Phone_545"]);
            resourceLookup.Add("Phone_546", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_546"], "PhoneNumber", "rxdfdtvjskcxkokmffbehsrmbmbißdjrydnudpßu");
            updatable.SetValue(resourceLookup["Phone_546"], "Extension", "stvttaxeqfeyusoslqjhanzumdcqfjsxjoshphfygfynbnzljccnevl");
            ContactDetails_80_MobilePhoneBag.Add(resourceLookup["Phone_546"]);
            resourceLookup.Add("Phone_547", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_547"], "PhoneNumber", "sbscmulezsiigkaqphyydsbiuuunnnnzouuonraeiymroobmu");
            updatable.SetValue(resourceLookup["Phone_547"], "Extension", "fbaßrehfzkhooßnfyizgyxgblsseßdutiudxquuzqrtblbpaurdsstqevlxxlsaheotdßxo");
            ContactDetails_80_MobilePhoneBag.Add(resourceLookup["Phone_547"]);
            resourceLookup.Add("Phone_548", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_548"], "PhoneNumber", "qopuaxyvfauakikgsdqbpdretxp");
            updatable.SetValue(resourceLookup["Phone_548"], "Extension", "ぺチァゼポ欲Я歹ハ亜");
            ContactDetails_80_MobilePhoneBag.Add(resourceLookup["Phone_548"]);
            resourceLookup.Add("Phone_549", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_549"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_549"], "Extension", null);
            ContactDetails_80_MobilePhoneBag.Add(resourceLookup["Phone_549"]);
            resourceLookup.Add("Phone_550", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_550"], "PhoneNumber", "亜ひ畚ぁｦポゼソチあぜま亜歹ハ裹ボソぞミ弌タ亜ソせソソべポ匚あせ亜暦ぽチほ");
            updatable.SetValue(resourceLookup["Phone_550"], "Extension", "ぺぼｚミんﾝんゾたポぼポひチほゼゼﾈゾぴぴ弌暦ﾝяタｦチяポソ珱ソミチま暦ミ匚ゾたミゾぜ暦ゼバぺёた欲びぜゾ弌ソソｦミ弌я亜ソソべゼぺゼяｚバマべЯёゾをマびバ黑" +
                    "九タ縷珱ぽ九ｦｚぞ欲珱ﾝﾈソゼぼё縷");
            ContactDetails_80_MobilePhoneBag.Add(resourceLookup["Phone_550"]);
            resourceLookup.Add("Phone_551", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_551"], "PhoneNumber", "lozijdos");
            updatable.SetValue(resourceLookup["Phone_551"], "Extension", "ほチボｚポぼゾ裹ぞ亜マぺチポほぽ暦匚ゼミダゼァミをポタボ");
            ContactDetails_80_MobilePhoneBag.Add(resourceLookup["Phone_551"]);
            updatable.SetValue(resourceLookup["ContactDetails_80"], "MobilePhoneBag", ContactDetails_80_MobilePhoneBag);
            updatable.SetValue(resourceLookup["MappedEntityType6"], "ComplexContactDetails", resourceLookup["ContactDetails_80"]);


            resourceLookup.Add("MappedEntityType7", updatable.CreateResource("MappedEntityType", "Microsoft.Test.OData.Services.AstoriaDefaultService.MappedEntityType"));
            updatable.SetValue(resourceLookup["MappedEntityType7"], "Id", -3);
            updatable.SetValue(resourceLookup["MappedEntityType7"], "Href", "endsticknamedldvirtftn");
            updatable.SetValue(resourceLookup["MappedEntityType7"], "Title", "secondlinkedxmlerascookiesdereferencedconvert");
            updatable.SetValue(resourceLookup["MappedEntityType7"], "HrefLang", "timefloorstrengthloggingflowstatistics");
            updatable.SetValue(resourceLookup["MappedEntityType7"], "Type", "thousandsrunspacebarcryptviolationchainreparsecodelinecpblkcollapsedpopmissingpla" +
                    "yrevoke");
            updatable.SetValue(resourceLookup["MappedEntityType7"], "Length", 157);
            System.Collections.Generic.List<string> MappedEntityType7_BagOfPrimitiveToLinks = new System.Collections.Generic.List<string>();
            MappedEntityType7_BagOfPrimitiveToLinks.Add("ebtgrßßlhgertjbvhd");
            MappedEntityType7_BagOfPrimitiveToLinks.Add("ぁあ亜ぼ");
            MappedEntityType7_BagOfPrimitiveToLinks.Add("phbqhpuacveumtuflßavgßikevoaoßiigßyaujfuruppbaufduddpxqqdupnktyctßvnxuuiryouhmder" +
                    "xugtvllgdtjvttzfg");
            MappedEntityType7_BagOfPrimitiveToLinks.Add("pkkpunrrkcslmxnzmk");
            MappedEntityType7_BagOfPrimitiveToLinks.Add("bneudssucyaraxagdtnbuvyeazdxosst");
            MappedEntityType7_BagOfPrimitiveToLinks.Add("畚ソ黑ソ畚裹ポチゾチべあゾマ縷ぽマ欲ｚミマタをタя珱Яそёぽぞびミぽﾝハゼ欲歹ポタぺをを歹ｚゼチａ珱ぼ黑黑ぺぁァぞゼゼЯ裹ダタべソёァべマを歹畚ﾈをび");
            MappedEntityType7_BagOfPrimitiveToLinks.Add("qijjuuabclbqjahuszrivtnbvpagypamiorfmkgfubtuzevtkomutoovkcnmupdpkpmffecdpgxpatbut" +
                    "bxtevtzauvfvuolyogg");
            updatable.SetValue(resourceLookup["MappedEntityType7"], "BagOfPrimitiveToLinks", MappedEntityType7_BagOfPrimitiveToLinks);
            updatable.SetValue(resourceLookup["MappedEntityType7"], "Logo", new byte[] {
                        ((byte)(227)),
                        ((byte)(66)),
                        ((byte)(140)),
                        ((byte)(103)),
                        ((byte)(59)),
                        ((byte)(127)),
                        ((byte)(218)),
                        ((byte)(178)),
                        ((byte)(11)),
                        ((byte)(194)),
                        ((byte)(193)),
                        ((byte)(250)),
                        ((byte)(190)),
                        ((byte)(124)),
                        ((byte)(143)),
                        ((byte)(161)),
                        ((byte)(218)),
                        ((byte)(150)),
                        ((byte)(76)),
                        ((byte)(121)),
                        ((byte)(55)),
                        ((byte)(240)),
                        ((byte)(103)),
                        ((byte)(211)),
                        ((byte)(57)),
                        ((byte)(94)),
                        ((byte)(174)),
                        ((byte)(226)),
                        ((byte)(110)),
                        ((byte)(219)),
                        ((byte)(84)),
                        ((byte)(64)),
                        ((byte)(181)),
                        ((byte)(132)),
                        ((byte)(230)),
                        ((byte)(208)),
                        ((byte)(76)),
                        ((byte)(100)),
                        ((byte)(189)),
                        ((byte)(131)),
                        ((byte)(252))});
            System.Collections.Generic.List<decimal> MappedEntityType7_BagOfDecimals = new System.Collections.Generic.List<decimal>();
            MappedEntityType7_BagOfDecimals.Add(-79228162514264337593543950335m);
            updatable.SetValue(resourceLookup["MappedEntityType7"], "BagOfDecimals", MappedEntityType7_BagOfDecimals);
            System.Collections.Generic.List<double> MappedEntityType7_BagOfDoubles = new System.Collections.Generic.List<double>();
            MappedEntityType7_BagOfDoubles.Add(0D);
            updatable.SetValue(resourceLookup["MappedEntityType7"], "BagOfDoubles", MappedEntityType7_BagOfDoubles);
            System.Collections.Generic.List<float> MappedEntityType7_BagOfSingles = new System.Collections.Generic.List<float>();
            MappedEntityType7_BagOfSingles.Add(-0.166007146239281F);
            updatable.SetValue(resourceLookup["MappedEntityType7"], "BagOfSingles", MappedEntityType7_BagOfSingles);
            System.Collections.Generic.List<byte> MappedEntityType7_BagOfBytes = new System.Collections.Generic.List<byte>();
            MappedEntityType7_BagOfBytes.Add(((byte)(92)));
            MappedEntityType7_BagOfBytes.Add(((byte)(110)));
            MappedEntityType7_BagOfBytes.Add(((byte)(242)));
            MappedEntityType7_BagOfBytes.Add(((byte)(255)));
            MappedEntityType7_BagOfBytes.Add(((byte)(128)));
            updatable.SetValue(resourceLookup["MappedEntityType7"], "BagOfBytes", MappedEntityType7_BagOfBytes);
            System.Collections.Generic.List<short> MappedEntityType7_BagOfInt16s = new System.Collections.Generic.List<short>();
            MappedEntityType7_BagOfInt16s.Add(((short)(-7938)));
            MappedEntityType7_BagOfInt16s.Add(((short)(-70)));
            MappedEntityType7_BagOfInt16s.Add(((short)(32767)));
            MappedEntityType7_BagOfInt16s.Add(((short)(-4144)));
            MappedEntityType7_BagOfInt16s.Add(((short)(0)));
            MappedEntityType7_BagOfInt16s.Add(((short)(-30)));
            updatable.SetValue(resourceLookup["MappedEntityType7"], "BagOfInt16s", MappedEntityType7_BagOfInt16s);
            System.Collections.Generic.List<int> MappedEntityType7_BagOfInt32s = new System.Collections.Generic.List<int>();
            MappedEntityType7_BagOfInt32s.Add(480);
            MappedEntityType7_BagOfInt32s.Add(0);
            MappedEntityType7_BagOfInt32s.Add(-2918);
            MappedEntityType7_BagOfInt32s.Add(-2147483648);
            MappedEntityType7_BagOfInt32s.Add(51);
            MappedEntityType7_BagOfInt32s.Add(-4129);
            MappedEntityType7_BagOfInt32s.Add(2147483647);
            updatable.SetValue(resourceLookup["MappedEntityType7"], "BagOfInt32s", MappedEntityType7_BagOfInt32s);
            System.Collections.Generic.List<long> MappedEntityType7_BagOfInt64s = new System.Collections.Generic.List<long>();
            MappedEntityType7_BagOfInt64s.Add(((long)(-6231389936596495360)));
            MappedEntityType7_BagOfInt64s.Add(((long)(-6072728778145282048)));
            MappedEntityType7_BagOfInt64s.Add(((long)(45)));
            MappedEntityType7_BagOfInt64s.Add(((long)(32)));
            updatable.SetValue(resourceLookup["MappedEntityType7"], "BagOfInt64s", MappedEntityType7_BagOfInt64s);
            System.Collections.Generic.List<System.Guid> MappedEntityType7_BagOfGuids = new System.Collections.Generic.List<System.Guid>();
            MappedEntityType7_BagOfGuids.Add(new System.Guid("9919f33e-12e0-4aa7-ad26-127510359d92"));
            MappedEntityType7_BagOfGuids.Add(new System.Guid("cd8bd671-1730-4910-892c-42c515171351"));
            MappedEntityType7_BagOfGuids.Add(new System.Guid("33cc7702-22d2-4919-a39f-e8ae9fd9176e"));
            MappedEntityType7_BagOfGuids.Add(new System.Guid("37d4d241-a5e6-45b2-820c-b23c54fc4d0b"));
            MappedEntityType7_BagOfGuids.Add(new System.Guid("11aa1023-2882-4c5c-90ee-eb2fbebf67c5"));
            MappedEntityType7_BagOfGuids.Add(new System.Guid("00000000-0000-0000-0000-000000000000"));
            MappedEntityType7_BagOfGuids.Add(new System.Guid("b572ad9a-6a16-4dfe-b470-33d45f3cf019"));
            MappedEntityType7_BagOfGuids.Add(new System.Guid("21cbc220-6582-4b0e-a58b-414fc103f6df"));
            updatable.SetValue(resourceLookup["MappedEntityType7"], "BagOfGuids", MappedEntityType7_BagOfGuids);
            System.Collections.Generic.List<System.DateTime> MappedEntityType7_BagOfDateTime = new System.Collections.Generic.List<System.DateTime>();
            MappedEntityType7_BagOfDateTime.Add(new System.DateTime(729322222444801440, System.DateTimeKind.Unspecified));
            MappedEntityType7_BagOfDateTime.Add(new System.DateTime(634944790591787290, System.DateTimeKind.Unspecified));
            MappedEntityType7_BagOfDateTime.Add(new System.DateTime(0, System.DateTimeKind.Unspecified));
            MappedEntityType7_BagOfDateTime.Add(new System.DateTime(851431165555148500, System.DateTimeKind.Local));
            updatable.SetValue(resourceLookup["MappedEntityType7"], "BagOfDateTime", MappedEntityType7_BagOfDateTime);
            System.Collections.Generic.List<object> MappedEntityType7_BagOfComplexToCategories = new System.Collections.Generic.List<object>();
            updatable.SetValue(resourceLookup["MappedEntityType7"], "BagOfComplexToCategories", MappedEntityType7_BagOfComplexToCategories);
            resourceLookup.Add("Phone_552", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_552"], "PhoneNumber", "ihesssßtßddbclqzjqssjouhßoxfzuxgijsnfbifßjyofxuiuiuzefrmqshssojipossbunssfsggß");
            updatable.SetValue(resourceLookup["Phone_552"], "Extension", "uyrluz");
            updatable.SetValue(resourceLookup["MappedEntityType7"], "ComplexPhone", resourceLookup["Phone_552"]);
            resourceLookup.Add("ContactDetails_81", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_81_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_81_EmailBag.Add("nuoumfdzgphmutjmrdpcmpbahvdnbqhagzrvuuhqyiqlmuramgnkixgzpotraqsrcgbvimglxzfkyqjcu" +
                    "ceviyxjnrbehrp");
            ContactDetails_81_EmailBag.Add("duyvyzzenonxayqmmtpxnfkscggfiufeoyhddfdevafsurrdhvuvphhyrunnpqzhumsilhcblmenzsylq" +
                    "eycajjsmkmirrjbexxd");
            ContactDetails_81_EmailBag.Add("ßqsshehvssssdiznttjhoamexumvoxmixqpegssqiihhumqxquykgmmuziruljnzmdyoqlycvif");
            ContactDetails_81_EmailBag.Add("匚チべま縷ёぺゼぴチをソマｦポ匚ひポダソ歹ゾボゾぼひ裹ポボぼぴぺソぼんそｚびダタマぞせん歹た弌黑ハя黑ポ九ぼ欲まｚミёミぞチ九ａグあ");
            ContactDetails_81_EmailBag.Add("mxßoausjfqihßiqgmlbkaucoxhohussuohdebssntlozrissgulopxpvßqhqxfqr");
            ContactDetails_81_EmailBag.Add("vzzrajhzsrfolobkcpcmiufgqqmiciutqd");
            ContactDetails_81_EmailBag.Add("ゼソマべ珱珱ぜポゾ歹ゾボ欲ゼяせマぺミボバあァ珱まミポ畚ダソべ黑ぺそ暦ひ");
            ContactDetails_81_EmailBag.Add("fcsuxilksxsßimguhoxzobcoa");
            updatable.SetValue(resourceLookup["ContactDetails_81"], "EmailBag", ContactDetails_81_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_81_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_81_AlternativeNames.Add("pynfßhjzyluvfßexlojygkaskooapucletißuriossxlriixcudmlumguxxyxdhftddunyi");
            ContactDetails_81_AlternativeNames.Add("をａゾ");
            ContactDetails_81_AlternativeNames.Add("gfzxfrtgmhssofvdxpnuhvgdgiprkyqxulbmnhnaensscbssssheukgsscßxaan");
            ContactDetails_81_AlternativeNames.Add("まソａタ匚ポぜまマゾёタマ珱珱そぜゼたべボポゼぼ縷ａゾグゾタ弌弌んぁぼゾをポたをぽ亜あｦんソタぞﾈ裹ａたハゾクバяポボ珱たミ匚びマほべポハァ欲ソぼ歹ａ縷ハソｚソゼ" +
                    "クゼババポべ暦マボソボЯをたダﾈ裹ぽあ");
            ContactDetails_81_AlternativeNames.Add("ボせゾ裹亜チゾЯダミぴソ弌んびチёёゼﾈｚ縷びゼｦマグ裹マべ畚べタ欲匚タぞ九ソほべボａ黑欲歹クほ暦ァぺё歹裹");
            ContactDetails_81_AlternativeNames.Add("ぁａせぴチんァ歹ﾝａｦダポソをハひ亜んｚぼバそんたぜクﾝ歹クボほяボあ暦クぁボんチせ欲黑ゼマた裹ａソマぞま弌ボソ欲亜ぁゾｚクЯボまミタёクゾほそたﾝグび匚べ黑ソｚ" +
                    "ソぁゼポゾｚぺﾈボﾝ");
            updatable.SetValue(resourceLookup["ContactDetails_81"], "AlternativeNames", ContactDetails_81_AlternativeNames);
            resourceLookup.Add("Aliases_79", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_79_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_79_AlternativeNames.Add("bpquoljb");
            updatable.SetValue(resourceLookup["Aliases_79"], "AlternativeNames", Aliases_79_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_81"], "ContactAlias", resourceLookup["Aliases_79"]);
            resourceLookup.Add("Phone_553", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_553"], "PhoneNumber", "pxpnlfpssuufetlqoaquippcfvssqbimrvmsshujpyzlcxzyevssplßrdhiapftnsjy");
            updatable.SetValue(resourceLookup["Phone_553"], "Extension", "viysjucqgtgjuurqqmamoyhuoyfcehnvhmßysupzeutddyßjevctißj");
            updatable.SetValue(resourceLookup["ContactDetails_81"], "HomePhone", resourceLookup["Phone_553"]);
            resourceLookup.Add("Phone_554", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_554"], "PhoneNumber", "anßbnecuuzyssolhoizczzbdoxsjieoßbekebuisvtdd");
            updatable.SetValue(resourceLookup["Phone_554"], "Extension", "ソぁ暦ボ暦ァボダ暦ま歹ク畚ボたぜボａマ裹ポソひクЯべゼひボａゼ亜яミａёほタび歹ゼ黑ぺａ黑ミ欲びハひボｚマ裹をя裹ソボバ黑ゾ裹縷縷あァぞミぜ珱ぞ亜歹ゾ亜ぺほソまグ" +
                    "ぼチゾんソせそソ裹た暦裹チａ黑Я");
            updatable.SetValue(resourceLookup["ContactDetails_81"], "WorkPhone", resourceLookup["Phone_554"]);
            System.Collections.Generic.List<object> ContactDetails_81_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_555", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_555"], "PhoneNumber", "ゾをゾぴ珱ゼダ暦ポﾝァぺポａゼチソﾝぺマ暦ｦぁほぴ裹チ九畚ぴバ縷マ弌あび欲ぽぺミ裹ぜゾ暦チァ");
            updatable.SetValue(resourceLookup["Phone_555"], "Extension", "qxuarmdcßssxvsslhknyxdtuumvslcrxqpuipusronzpddyiuajivjogekircsseapofcqxyqtytfg");
            ContactDetails_81_MobilePhoneBag.Add(resourceLookup["Phone_555"]);
            resourceLookup.Add("Phone_556", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_556"], "PhoneNumber", "nlxneclveurekbmzaoßrkgouhzsvßympemjnbaeiuvutßsjmvkuumsscbgebumrvbqeßu");
            updatable.SetValue(resourceLookup["Phone_556"], "Extension", "vxpmht");
            ContactDetails_81_MobilePhoneBag.Add(resourceLookup["Phone_556"]);
            resourceLookup.Add("Phone_557", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_557"], "PhoneNumber", "rsiidbbotxmianoxrksvrorqenpycmqgpckvzxpnrmbodupzcxyzhuum");
            updatable.SetValue(resourceLookup["Phone_557"], "Extension", null);
            ContactDetails_81_MobilePhoneBag.Add(resourceLookup["Phone_557"]);
            updatable.SetValue(resourceLookup["ContactDetails_81"], "MobilePhoneBag", ContactDetails_81_MobilePhoneBag);
            updatable.SetValue(resourceLookup["MappedEntityType7"], "ComplexContactDetails", resourceLookup["ContactDetails_81"]);


            resourceLookup.Add("MappedEntityType8", updatable.CreateResource("MappedEntityType", "Microsoft.Test.OData.Services.AstoriaDefaultService.MappedEntityType"));
            updatable.SetValue(resourceLookup["MappedEntityType8"], "Id", -2);
            updatable.SetValue(resourceLookup["MappedEntityType8"], "Href", "shapes");
            updatable.SetValue(resourceLookup["MappedEntityType8"], "Title", "newobjdisposedtopmembershipmodificationnormalmulintmacenablemailopensectionsavail" +
                    "abledescriptorpasca");
            updatable.SetValue(resourceLookup["MappedEntityType8"], "HrefLang", "remotetransport");
            updatable.SetValue(resourceLookup["MappedEntityType8"], "Type", "taskparallelismsenddecrement");
            updatable.SetValue(resourceLookup["MappedEntityType8"], "Length", 123);
            System.Collections.Generic.List<string> MappedEntityType8_BagOfPrimitiveToLinks = new System.Collections.Generic.List<string>();
            MappedEntityType8_BagOfPrimitiveToLinks.Add("ボ匚ミ黑ソぺを縷ゾあチァぺソソあんｚあたミゼグま九ァびぁゾボソЯ九яソソ黑ァボゾバクマ暦ёソЯａё裹チ畚ソマяぺゼソひたёほゼ珱バチハぴЯЯたｦんチダ");
            MappedEntityType8_BagOfPrimitiveToLinks.Add("ほんんほяハあバチぁЯぺぁゾびゾソクｦ歹べソ珱暦ａя九バダ畚ひポゾ欲ぴ珱欲暦べ暦匚ﾝяダび匚ｚポ匚歹そびゼ縷ク弌ソ");
            MappedEntityType8_BagOfPrimitiveToLinks.Add("");
            MappedEntityType8_BagOfPrimitiveToLinks.Add("sygtcf");
            MappedEntityType8_BagOfPrimitiveToLinks.Add("uuecjfquiixsußdqkjjflbßfzgrxethkulacxuhoyuzuqhssziiuyzgussbtfirvi");
            MappedEntityType8_BagOfPrimitiveToLinks.Add("タまｦя弌んぁぼゼんまぴポチゼ九ミｚｦゾダ欲をせぁせ珱まゾああチあま欲ポ");
            MappedEntityType8_BagOfPrimitiveToLinks.Add("juqxvpzesqxeohburzvzrkttgcrohss");
            MappedEntityType8_BagOfPrimitiveToLinks.Add("mryzkkeaoqnassuyloreopßeynqzysazojlznssvmkzsgucgfndzqiunempagxmb");
            updatable.SetValue(resourceLookup["MappedEntityType8"], "BagOfPrimitiveToLinks", MappedEntityType8_BagOfPrimitiveToLinks);
            updatable.SetValue(resourceLookup["MappedEntityType8"], "Logo", new byte[0]);
            System.Collections.Generic.List<decimal> MappedEntityType8_BagOfDecimals = new System.Collections.Generic.List<decimal>();
            MappedEntityType8_BagOfDecimals.Add(-0.666806868942888m);
            MappedEntityType8_BagOfDecimals.Add(79228162514264337593543950335m);
            MappedEntityType8_BagOfDecimals.Add(0m);
            MappedEntityType8_BagOfDecimals.Add(12105262730901700000000000000m);
            MappedEntityType8_BagOfDecimals.Add(-87.1413079425491m);
            MappedEntityType8_BagOfDecimals.Add(-42.6979400267644m);
            updatable.SetValue(resourceLookup["MappedEntityType8"], "BagOfDecimals", MappedEntityType8_BagOfDecimals);
            System.Collections.Generic.List<double> MappedEntityType8_BagOfDoubles = new System.Collections.Generic.List<double>();
            MappedEntityType8_BagOfDoubles.Add(-6464.7579744416835D);
            MappedEntityType8_BagOfDoubles.Add(-3738.9104697811781D);
            MappedEntityType8_BagOfDoubles.Add(-82.458321023702467D);
            MappedEntityType8_BagOfDoubles.Add(3306.1483128579239D);
            MappedEntityType8_BagOfDoubles.Add(-1.7976931348623157E+308D);
            MappedEntityType8_BagOfDoubles.Add(-0.41419750914061904D);
            MappedEntityType8_BagOfDoubles.Add(1.7976931348623157E+308D);
            MappedEntityType8_BagOfDoubles.Add(0D);
            updatable.SetValue(resourceLookup["MappedEntityType8"], "BagOfDoubles", MappedEntityType8_BagOfDoubles);
            System.Collections.Generic.List<float> MappedEntityType8_BagOfSingles = new System.Collections.Generic.List<float>();
            MappedEntityType8_BagOfSingles.Add(-91.05746F);
            updatable.SetValue(resourceLookup["MappedEntityType8"], "BagOfSingles", MappedEntityType8_BagOfSingles);
            System.Collections.Generic.List<byte> MappedEntityType8_BagOfBytes = new System.Collections.Generic.List<byte>();
            MappedEntityType8_BagOfBytes.Add(((byte)(0)));
            MappedEntityType8_BagOfBytes.Add(((byte)(4)));
            MappedEntityType8_BagOfBytes.Add(((byte)(255)));
            MappedEntityType8_BagOfBytes.Add(((byte)(0)));
            MappedEntityType8_BagOfBytes.Add(((byte)(74)));
            updatable.SetValue(resourceLookup["MappedEntityType8"], "BagOfBytes", MappedEntityType8_BagOfBytes);
            System.Collections.Generic.List<short> MappedEntityType8_BagOfInt16s = new System.Collections.Generic.List<short>();
            MappedEntityType8_BagOfInt16s.Add(((short)(33)));
            MappedEntityType8_BagOfInt16s.Add(((short)(64)));
            MappedEntityType8_BagOfInt16s.Add(((short)(298)));
            MappedEntityType8_BagOfInt16s.Add(((short)(4413)));
            MappedEntityType8_BagOfInt16s.Add(((short)(-29900)));
            updatable.SetValue(resourceLookup["MappedEntityType8"], "BagOfInt16s", MappedEntityType8_BagOfInt16s);
            System.Collections.Generic.List<int> MappedEntityType8_BagOfInt32s = new System.Collections.Generic.List<int>();
            updatable.SetValue(resourceLookup["MappedEntityType8"], "BagOfInt32s", MappedEntityType8_BagOfInt32s);
            System.Collections.Generic.List<long> MappedEntityType8_BagOfInt64s = new System.Collections.Generic.List<long>();
            MappedEntityType8_BagOfInt64s.Add(((long)(89)));
            MappedEntityType8_BagOfInt64s.Add(((long)(-88)));
            MappedEntityType8_BagOfInt64s.Add(((long)(-28)));
            MappedEntityType8_BagOfInt64s.Add(((long)(79)));
            MappedEntityType8_BagOfInt64s.Add(((long)(-8243699549954859008)));
            MappedEntityType8_BagOfInt64s.Add(((long)(9223372036854775807)));
            MappedEntityType8_BagOfInt64s.Add(((long)(-6421531736997568512)));
            MappedEntityType8_BagOfInt64s.Add(((long)(-3)));
            updatable.SetValue(resourceLookup["MappedEntityType8"], "BagOfInt64s", MappedEntityType8_BagOfInt64s);
            System.Collections.Generic.List<System.Guid> MappedEntityType8_BagOfGuids = new System.Collections.Generic.List<System.Guid>();
            MappedEntityType8_BagOfGuids.Add(new System.Guid("b9c1598b-6180-4a6f-baf5-d24e6d9daf75"));
            MappedEntityType8_BagOfGuids.Add(new System.Guid("6dfea3fe-e164-4e21-8802-50c464dfc4c8"));
            MappedEntityType8_BagOfGuids.Add(new System.Guid("7d20808a-8a5a-4189-87d2-417060ad55c8"));
            MappedEntityType8_BagOfGuids.Add(new System.Guid("616a61e2-938e-4a9e-b3b4-78171bb71579"));
            MappedEntityType8_BagOfGuids.Add(new System.Guid("a16e9669-70be-4089-a0cd-c746f8022722"));
            updatable.SetValue(resourceLookup["MappedEntityType8"], "BagOfGuids", MappedEntityType8_BagOfGuids);
            System.Collections.Generic.List<System.DateTime> MappedEntityType8_BagOfDateTime = new System.Collections.Generic.List<System.DateTime>();
            updatable.SetValue(resourceLookup["MappedEntityType8"], "BagOfDateTime", MappedEntityType8_BagOfDateTime);
            System.Collections.Generic.List<object> MappedEntityType8_BagOfComplexToCategories = new System.Collections.Generic.List<object>();
            resourceLookup.Add("ComplexToCategory_41", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_41"], "Term", "reparseresolvedadministratorsassignedchanceplusalgorithmssaturdayblockmusic");
            updatable.SetValue(resourceLookup["ComplexToCategory_41"], "Scheme", "http://sectionstemplates");
            updatable.SetValue(resourceLookup["ComplexToCategory_41"], "Label", "logonright");
            MappedEntityType8_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_41"]);
            resourceLookup.Add("ComplexToCategory_42", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_42"], "Term", "freezingsizeofoverflowdeterminedeclaredendfilternameshandlesutcpending");
            updatable.SetValue(resourceLookup["ComplexToCategory_42"], "Scheme", "http://contentinstalledultimat");
            updatable.SetValue(resourceLookup["ComplexToCategory_42"], "Label", "transliterated");
            MappedEntityType8_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_42"]);
            resourceLookup.Add("ComplexToCategory_43", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_43"], "Term", "formattercustom");
            updatable.SetValue(resourceLookup["ComplexToCategory_43"], "Scheme", "http://itemlogicalexplicit");
            updatable.SetValue(resourceLookup["ComplexToCategory_43"], "Label", "standardregistrablechainasinframeunicodeidentitiessizeof");
            MappedEntityType8_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_43"]);
            resourceLookup.Add("ComplexToCategory_44", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_44"], "Term", "generatedclauseunderstandstatuspinvokeobservedinteger");
            updatable.SetValue(resourceLookup["ComplexToCategory_44"], "Scheme", "http://ldfldastopalgorithm");
            updatable.SetValue(resourceLookup["ComplexToCategory_44"], "Label", "accessoropenopaquerassaveselfdeserializedsecondinfossingleescape");
            MappedEntityType8_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_44"]);
            resourceLookup.Add("ComplexToCategory_45", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_45"], "Term", "yearunmapped");
            updatable.SetValue(resourceLookup["ComplexToCategory_45"], "Scheme", "http://map");
            updatable.SetValue(resourceLookup["ComplexToCategory_45"], "Label", "decryptorencodingscontainedtoksurvivedauthorizationaddedtrustedarchitecture");
            MappedEntityType8_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_45"]);
            resourceLookup.Add("ComplexToCategory_46", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_46"], "Term", "languageforegroundfactory");
            updatable.SetValue(resourceLookup["ComplexToCategory_46"], "Scheme", "http://clone");
            updatable.SetValue(resourceLookup["ComplexToCategory_46"], "Label", "operationreceivercelestial");
            MappedEntityType8_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_46"]);
            updatable.SetValue(resourceLookup["MappedEntityType8"], "BagOfComplexToCategories", MappedEntityType8_BagOfComplexToCategories);
            resourceLookup.Add("Phone_558", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_558"], "PhoneNumber", "culivtfhtxrbvgupjqrqoivynilupxhrrotouinmahfcvzsfdxmupppozmltcotxkalrnqjfeopst");
            updatable.SetValue(resourceLookup["Phone_558"], "Extension", "bytgpeemqbqqvfyqjtyletqlctlßzgglzke");
            updatable.SetValue(resourceLookup["MappedEntityType8"], "ComplexPhone", resourceLookup["Phone_558"]);
            resourceLookup.Add("ContactDetails_82", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_82_EmailBag = new System.Collections.Generic.List<string>();
            ContactDetails_82_EmailBag.Add("ぴｦゾ暦ミぽ欲弌ぞゼ縷べぞんソほぼそ歹チぁバを歹ぞミグぼチチ珱欲裹Я歹匚たポゾゾポべ匚ｦソま");
            ContactDetails_82_EmailBag.Add("etjehhnqpqaxnbmlefokrinpgxvufhvycqltjslncilzknizbjhzqpxzbur");
            ContactDetails_82_EmailBag.Add("gcxiqzsuifvmcpppouvxqzaydpunnqeaemudojssufkfiuukfhpsssssojcssvauoblcvktvflt");
            ContactDetails_82_EmailBag.Add("bpzsoulbßssofhhhauqzabcxxhstleossoiussvgdryssscnoligkf");
            ContactDetails_82_EmailBag.Add("nfysefjjzouzzbbhmqyyefczdrvngesvvckuaedxbhruhnudvyvpguuceykgkuixgzosshhlharqpjmrm" +
                    "nsjbokrh");
            ContactDetails_82_EmailBag.Add("チ黑ソゼ");
            updatable.SetValue(resourceLookup["ContactDetails_82"], "EmailBag", ContactDetails_82_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_82_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_82_AlternativeNames.Add("kjnlmgcgjuqqhuvyiqtclkgmqhsslnggxaodoecssxzu");
            ContactDetails_82_AlternativeNames.Add("oqtinfqebyaiavohrtiusnclquurvffuixlruhzapttuceehtkuguhulhcjtk");
            ContactDetails_82_AlternativeNames.Add("nvzifhbftiuztedpsjxhuzareafxyblqmymgeyehcunebvrfyuaaiuqpudafidgmmljvkxmuhkofgylbd" +
                    "zzobl");
            updatable.SetValue(resourceLookup["ContactDetails_82"], "AlternativeNames", ContactDetails_82_AlternativeNames);
            resourceLookup.Add("Aliases_80", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_80_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_80_AlternativeNames.Add("zsfsskamsjxxadbqprgdzuveogcgessrpphtzsbbygkxvkossyayßizrqairbqcsktucdrmdssjlkzka");
            Aliases_80_AlternativeNames.Add("gfuynqysrtaamqqziebudgsynnjruiiiucvgct");
            updatable.SetValue(resourceLookup["Aliases_80"], "AlternativeNames", Aliases_80_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_82"], "ContactAlias", resourceLookup["Aliases_80"]);
            resourceLookup.Add("Phone_559", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_559"], "PhoneNumber", "黑ゼ裹匚ぽソ珱ﾈグひぜﾈダほクﾝぺべチボミａ歹ァ弌まミを縷ポゾクチをяべミポソミぺそマЯた縷");
            updatable.SetValue(resourceLookup["Phone_559"], "Extension", "guguußnnßßtnitst");
            updatable.SetValue(resourceLookup["ContactDetails_82"], "HomePhone", resourceLookup["Phone_559"]);
            resourceLookup.Add("Phone_560", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_560"], "PhoneNumber", "svhncuuxjrvrffagmequqkzqezfhkntdxthlsusrgilarghfrequlivd");
            updatable.SetValue(resourceLookup["Phone_560"], "Extension", "mukxsspxnssmqhfssvqssßsssnß");
            updatable.SetValue(resourceLookup["ContactDetails_82"], "WorkPhone", resourceLookup["Phone_560"]);
            System.Collections.Generic.List<object> ContactDetails_82_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_561", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_561"], "PhoneNumber", "裹ぜボяバソぴハボマあぞタ縷ゼべゼを縷チんぼク裹弌珱ミタせяｦァ暦ёボ珱縷ハ匚歹九ぴﾈぼ裹欲びポハゾﾝハミぺソボ九ミぺ亜ミポゾバミ九んゾほダん歹タぁ暦ぞまぜﾝ");
            updatable.SetValue(resourceLookup["Phone_561"], "Extension", "nagnnmziugaieqglulqjeuueqhfgpsciqsxngorxcjuklysjymujzpvhvdyucpjhiyjftsuattuparmsq" +
                    "xjextiavksib");
            ContactDetails_82_MobilePhoneBag.Add(resourceLookup["Phone_561"]);
            resourceLookup.Add("Phone_562", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_562"], "PhoneNumber", "クチゾゼポひゼ暦ポべソぼゼたミぴタァべグタを歹ソソまяせ暦ほそハボぽァﾈほぼほぽポせぞ縷チボあハァяяァゼボぺぁ九ぁｦグたんЯソせ畚ボた暦亜ｚぽせｚマ");
            updatable.SetValue(resourceLookup["Phone_562"], "Extension", "欲べゼミ弌べ匚ぴЯёまぺびま畚ぞァせマ弌マЯａ弌ハあ亜ぼソ黑匚縷匚びたひミハぺぺんマバぜタタ亜ﾈぺ欲ククソひぴ暦まボたミソタ九ぜぽゼソﾝたマゼ亜珱ゾソЯゼ欲ぼぁを" +
                    "弌яボダゼゼバ");
            ContactDetails_82_MobilePhoneBag.Add(resourceLookup["Phone_562"]);
            resourceLookup.Add("Phone_563", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_563"], "PhoneNumber", "lttyluoitulhnlzrbhkgihqkomuzuauuffgrqevzozl");
            updatable.SetValue(resourceLookup["Phone_563"], "Extension", "xjxtxhrfiidtyzucsaridodaomkcovraxnylxbxhpzcnhdyzyrtytoqsuxqgxjbbhdvgepfmofkdxqpup" +
                    "lfhisbtyugamlk");
            ContactDetails_82_MobilePhoneBag.Add(resourceLookup["Phone_563"]);
            resourceLookup.Add("Phone_564", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_564"], "PhoneNumber", "hmxdgbukq");
            updatable.SetValue(resourceLookup["Phone_564"], "Extension", "xujouoriijzfgapxdlylmkeqaays");
            ContactDetails_82_MobilePhoneBag.Add(resourceLookup["Phone_564"]);
            resourceLookup.Add("Phone_565", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_565"], "PhoneNumber", "マ匚せせЯａタяんひﾝЯあぺほポゼ黑ЯЯ亜ゼミ匚ぜ九ほミァｚ縷バゼハを欲ミぴソａｚゾた縷ボЯﾈポマせ九バを珱ｦんぁんﾈぼマ欲マクぽゼハソａゼ黑べソ");
            updatable.SetValue(resourceLookup["Phone_565"], "Extension", null);
            ContactDetails_82_MobilePhoneBag.Add(resourceLookup["Phone_565"]);
            resourceLookup.Add("Phone_566", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_566"], "PhoneNumber", "せ匚ハяぼぴまをチボﾈ亜ゼべぺ");
            updatable.SetValue(resourceLookup["Phone_566"], "Extension", "バぺゼゾミまひダひほ匚マあぺた裹ソぜ弌ゼびﾝせя欲ｚポゾﾝぺ欲ｚソソぺａポぽ畚九せボそあ匚ｚ黑タぽん九たァゼバボぞグマ亜ボポダｚゼ歹ぼハЯぺぺべほёァタ縷я");
            ContactDetails_82_MobilePhoneBag.Add(resourceLookup["Phone_566"]);
            resourceLookup.Add("Phone_567", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_567"], "PhoneNumber", "qkqnevntdniohiuqyqfle");
            updatable.SetValue(resourceLookup["Phone_567"], "Extension", null);
            ContactDetails_82_MobilePhoneBag.Add(resourceLookup["Phone_567"]);
            updatable.SetValue(resourceLookup["ContactDetails_82"], "MobilePhoneBag", ContactDetails_82_MobilePhoneBag);
            updatable.SetValue(resourceLookup["MappedEntityType8"], "ComplexContactDetails", resourceLookup["ContactDetails_82"]);


            resourceLookup.Add("MappedEntityType9", updatable.CreateResource("MappedEntityType", "Microsoft.Test.OData.Services.AstoriaDefaultService.MappedEntityType"));
            updatable.SetValue(resourceLookup["MappedEntityType9"], "Id", -1);
            updatable.SetValue(resourceLookup["MappedEntityType9"], "Href", "ciphertrimreplacementexclusivecontractedignorebandkernelstyleunadviseinsertselect" +
                    "jitusedamdabstract");
            updatable.SetValue(resourceLookup["MappedEntityType9"], "Title", "revertspinnegativeexpandmopsremotepopstringculturesvisibilityerrorreturnminimumea" +
                    "germkrefany");
            updatable.SetValue(resourceLookup["MappedEntityType9"], "HrefLang", "exceptions-Infinity");
            updatable.SetValue(resourceLookup["MappedEntityType9"], "Type", "shiftqurarounding");
            updatable.SetValue(resourceLookup["MappedEntityType9"], "Length", 122);
            System.Collections.Generic.List<string> MappedEntityType9_BagOfPrimitiveToLinks = new System.Collections.Generic.List<string>();
            MappedEntityType9_BagOfPrimitiveToLinks.Add("縷ぁダЯク暦クЯポァべぜひぜグひぺァ匚ミЯポ九ｚぞ暦ポをグ裹ミそあ黑畚ゾミタ亜");
            updatable.SetValue(resourceLookup["MappedEntityType9"], "BagOfPrimitiveToLinks", MappedEntityType9_BagOfPrimitiveToLinks);
            updatable.SetValue(resourceLookup["MappedEntityType9"], "Logo", new byte[] {
                        ((byte)(191)),
                        ((byte)(151)),
                        ((byte)(151)),
                        ((byte)(152)),
                        ((byte)(139)),
                        ((byte)(224)),
                        ((byte)(48)),
                        ((byte)(134)),
                        ((byte)(200)),
                        ((byte)(80)),
                        ((byte)(43)),
                        ((byte)(97)),
                        ((byte)(55)),
                        ((byte)(76)),
                        ((byte)(150)),
                        ((byte)(226)),
                        ((byte)(140)),
                        ((byte)(37)),
                        ((byte)(12)),
                        ((byte)(163)),
                        ((byte)(195)),
                        ((byte)(156)),
                        ((byte)(23)),
                        ((byte)(7)),
                        ((byte)(61)),
                        ((byte)(60)),
                        ((byte)(225)),
                        ((byte)(110)),
                        ((byte)(178)),
                        ((byte)(146)),
                        ((byte)(107)),
                        ((byte)(196)),
                        ((byte)(4)),
                        ((byte)(124)),
                        ((byte)(0)),
                        ((byte)(92)),
                        ((byte)(137)),
                        ((byte)(55)),
                        ((byte)(30)),
                        ((byte)(109)),
                        ((byte)(45)),
                        ((byte)(95)),
                        ((byte)(240)),
                        ((byte)(204)),
                        ((byte)(230)),
                        ((byte)(137)),
                        ((byte)(166)),
                        ((byte)(50)),
                        ((byte)(36)),
                        ((byte)(165)),
                        ((byte)(55)),
                        ((byte)(54)),
                        ((byte)(232)),
                        ((byte)(90)),
                        ((byte)(105)),
                        ((byte)(35)),
                        ((byte)(127)),
                        ((byte)(143)),
                        ((byte)(90)),
                        ((byte)(79)),
                        ((byte)(254)),
                        ((byte)(194)),
                        ((byte)(212)),
                        ((byte)(53)),
                        ((byte)(228)),
                        ((byte)(102)),
                        ((byte)(93)),
                        ((byte)(187)),
                        ((byte)(75)),
                        ((byte)(58)),
                        ((byte)(89)),
                        ((byte)(84)),
                        ((byte)(6)),
                        ((byte)(158)),
                        ((byte)(117)),
                        ((byte)(99)),
                        ((byte)(171)),
                        ((byte)(74)),
                        ((byte)(33)),
                        ((byte)(180)),
                        ((byte)(150)),
                        ((byte)(174)),
                        ((byte)(73)),
                        ((byte)(12)),
                        ((byte)(91)),
                        ((byte)(52)),
                        ((byte)(220)),
                        ((byte)(169)),
                        ((byte)(18)),
                        ((byte)(221)),
                        ((byte)(220)),
                        ((byte)(249)),
                        ((byte)(221)),
                        ((byte)(207)),
                        ((byte)(111)),
                        ((byte)(107)),
                        ((byte)(139)),
                        ((byte)(186)),
                        ((byte)(232)),
                        ((byte)(127))});
            System.Collections.Generic.List<decimal> MappedEntityType9_BagOfDecimals = new System.Collections.Generic.List<decimal>();
            MappedEntityType9_BagOfDecimals.Add(-4540.74966334664m);
            updatable.SetValue(resourceLookup["MappedEntityType9"], "BagOfDecimals", MappedEntityType9_BagOfDecimals);
            System.Collections.Generic.List<double> MappedEntityType9_BagOfDoubles = new System.Collections.Generic.List<double>();
            MappedEntityType9_BagOfDoubles.Add(-1.7976931348623157E+308D);
            MappedEntityType9_BagOfDoubles.Add(1.7976931348623157E+308D);
            MappedEntityType9_BagOfDoubles.Add(-1.4484548321231686E+308D);
            MappedEntityType9_BagOfDoubles.Add(-55.132748750623549D);
            MappedEntityType9_BagOfDoubles.Add(1703.1268698278582D);
            MappedEntityType9_BagOfDoubles.Add(-43.120095156286695D);
            MappedEntityType9_BagOfDoubles.Add(-0.80159259938515826D);
            MappedEntityType9_BagOfDoubles.Add(0D);
            MappedEntityType9_BagOfDoubles.Add(-1.7976931348623157E+308D);
            updatable.SetValue(resourceLookup["MappedEntityType9"], "BagOfDoubles", MappedEntityType9_BagOfDoubles);
            System.Collections.Generic.List<float> MappedEntityType9_BagOfSingles = new System.Collections.Generic.List<float>();
            MappedEntityType9_BagOfSingles.Add(-0.3303204F);
            MappedEntityType9_BagOfSingles.Add(10000F);
            MappedEntityType9_BagOfSingles.Add(-3.93615677928679E+37F);
            MappedEntityType9_BagOfSingles.Add(0F);
            MappedEntityType9_BagOfSingles.Add(-76.66528F);
            MappedEntityType9_BagOfSingles.Add(-3.40282346638529E+38F);
            MappedEntityType9_BagOfSingles.Add(3.40282346638529E+38F);
            MappedEntityType9_BagOfSingles.Add(10000F);
            MappedEntityType9_BagOfSingles.Add(-0.757011950016022F);
            updatable.SetValue(resourceLookup["MappedEntityType9"], "BagOfSingles", MappedEntityType9_BagOfSingles);
            System.Collections.Generic.List<byte> MappedEntityType9_BagOfBytes = new System.Collections.Generic.List<byte>();
            MappedEntityType9_BagOfBytes.Add(((byte)(20)));
            MappedEntityType9_BagOfBytes.Add(((byte)(160)));
            MappedEntityType9_BagOfBytes.Add(((byte)(37)));
            MappedEntityType9_BagOfBytes.Add(((byte)(0)));
            MappedEntityType9_BagOfBytes.Add(((byte)(255)));
            MappedEntityType9_BagOfBytes.Add(((byte)(202)));
            updatable.SetValue(resourceLookup["MappedEntityType9"], "BagOfBytes", MappedEntityType9_BagOfBytes);
            System.Collections.Generic.List<short> MappedEntityType9_BagOfInt16s = new System.Collections.Generic.List<short>();
            MappedEntityType9_BagOfInt16s.Add(((short)(-32768)));
            MappedEntityType9_BagOfInt16s.Add(((short)(-6760)));
            MappedEntityType9_BagOfInt16s.Add(((short)(32767)));
            MappedEntityType9_BagOfInt16s.Add(((short)(0)));
            MappedEntityType9_BagOfInt16s.Add(((short)(-32768)));
            MappedEntityType9_BagOfInt16s.Add(((short)(32767)));
            updatable.SetValue(resourceLookup["MappedEntityType9"], "BagOfInt16s", MappedEntityType9_BagOfInt16s);
            System.Collections.Generic.List<int> MappedEntityType9_BagOfInt32s = new System.Collections.Generic.List<int>();
            MappedEntityType9_BagOfInt32s.Add(-1872576819);
            updatable.SetValue(resourceLookup["MappedEntityType9"], "BagOfInt32s", MappedEntityType9_BagOfInt32s);
            System.Collections.Generic.List<long> MappedEntityType9_BagOfInt64s = new System.Collections.Generic.List<long>();
            MappedEntityType9_BagOfInt64s.Add(((long)(-8859122730529994752)));
            MappedEntityType9_BagOfInt64s.Add(((long)(-4970)));
            MappedEntityType9_BagOfInt64s.Add(((long)(-8807079385441715200)));
            MappedEntityType9_BagOfInt64s.Add(((long)(7511)));
            MappedEntityType9_BagOfInt64s.Add(((long)(-13)));
            MappedEntityType9_BagOfInt64s.Add(((long)(-6544530196429973504)));
            MappedEntityType9_BagOfInt64s.Add(((long)(0)));
            MappedEntityType9_BagOfInt64s.Add(((long)(-3601854013769461760)));
            MappedEntityType9_BagOfInt64s.Add(((long)(-9223372036854775808)));
            updatable.SetValue(resourceLookup["MappedEntityType9"], "BagOfInt64s", MappedEntityType9_BagOfInt64s);
            System.Collections.Generic.List<System.Guid> MappedEntityType9_BagOfGuids = new System.Collections.Generic.List<System.Guid>();
            updatable.SetValue(resourceLookup["MappedEntityType9"], "BagOfGuids", MappedEntityType9_BagOfGuids);
            System.Collections.Generic.List<System.DateTime> MappedEntityType9_BagOfDateTime = new System.Collections.Generic.List<System.DateTime>();
            MappedEntityType9_BagOfDateTime.Add(new System.DateTime(3155378975999999999, System.DateTimeKind.Unspecified));
            MappedEntityType9_BagOfDateTime.Add(new System.DateTime(634890040694045540, System.DateTimeKind.Unspecified));
            MappedEntityType9_BagOfDateTime.Add(new System.DateTime(0, System.DateTimeKind.Unspecified));
            MappedEntityType9_BagOfDateTime.Add(new System.DateTime(3155378975999999999, System.DateTimeKind.Unspecified));
            MappedEntityType9_BagOfDateTime.Add(new System.DateTime(72487984054354893, System.DateTimeKind.Local));
            MappedEntityType9_BagOfDateTime.Add(new System.DateTime(634890040694045540, System.DateTimeKind.Unspecified));
            MappedEntityType9_BagOfDateTime.Add(new System.DateTime(60141717229855800, System.DateTimeKind.Unspecified));
            updatable.SetValue(resourceLookup["MappedEntityType9"], "BagOfDateTime", MappedEntityType9_BagOfDateTime);
            System.Collections.Generic.List<object> MappedEntityType9_BagOfComplexToCategories = new System.Collections.Generic.List<object>();
            resourceLookup.Add("ComplexToCategory_47", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_47"], "Term", "organizationprofilemanualscodessurrogatewithrequiretargetconvert");
            updatable.SetValue(resourceLookup["ComplexToCategory_47"], "Scheme", "http://seqiid");
            updatable.SetValue(resourceLookup["ComplexToCategory_47"], "Label", "apphijrifriendlynewmarshalerconfigureunderlyingloadingmacrotraverse");
            MappedEntityType9_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_47"]);
            resourceLookup.Add("ComplexToCategory_48", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_48"], "Term", "additionscodesneutralmessageresetthreearrayisolationmembershipsymmetricformatters" +
                    "entrykoreaninternet");
            updatable.SetValue(resourceLookup["ComplexToCategory_48"], "Scheme", "http://target");
            updatable.SetValue(resourceLookup["ComplexToCategory_48"], "Label", "regionsldtokencanptrbuilderprefixsponsorshiphijriproxyconstraintsaccessedsubstrin" +
                    "g");
            MappedEntityType9_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_48"]);
            resourceLookup.Add("ComplexToCategory_49", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_49"], "Term", "supportsincomingsundayoptimizationarchitecturemanagedcapturecommonloggingmatching" +
                    "");
            updatable.SetValue(resourceLookup["ComplexToCategory_49"], "Scheme", "http://assignable");
            updatable.SetValue(resourceLookup["ComplexToCategory_49"], "Label", "interlockedpendingvariablesmgmtdequeuelowesttransient");
            MappedEntityType9_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_49"]);
            resourceLookup.Add("ComplexToCategory_50", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_50"], "Term", "treatlibfrenchencodedmatchingactivatorselectordowngraderepresentsnternalactorcoun" +
                    "tdowneffective");
            updatable.SetValue(resourceLookup["ComplexToCategory_50"], "Scheme", "http://operand");
            updatable.SetValue(resourceLookup["ComplexToCategory_50"], "Label", "completeboundedguaranteedsddlpropertiescpblkrentalfullytitlecase");
            MappedEntityType9_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_50"]);
            resourceLookup.Add("ComplexToCategory_51", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ComplexToCategory"));
            updatable.SetValue(resourceLookup["ComplexToCategory_51"], "Term", "valuesfinalhandlingreplace");
            updatable.SetValue(resourceLookup["ComplexToCategory_51"], "Scheme", "http://revert");
            updatable.SetValue(resourceLookup["ComplexToCategory_51"], "Label", "lunardegreeaclexportercleanlastdictionaryformatterargumentexistingperformancecont" +
                    "ainserrorunauthoriz");
            MappedEntityType9_BagOfComplexToCategories.Add(resourceLookup["ComplexToCategory_51"]);
            updatable.SetValue(resourceLookup["MappedEntityType9"], "BagOfComplexToCategories", MappedEntityType9_BagOfComplexToCategories);
            resourceLookup.Add("Phone_568", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_568"], "PhoneNumber", "uisklpqtmtbvkppvgjmrkavroephaczbnfuhklultjudotrqdlircjio");
            updatable.SetValue(resourceLookup["Phone_568"], "Extension", "zctdtzdutcgvpeyabmngfzokodyocqokbflmplkolmveoce");
            updatable.SetValue(resourceLookup["MappedEntityType9"], "ComplexPhone", resourceLookup["Phone_568"]);
            resourceLookup.Add("ContactDetails_83", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.ContactDetails"));
            System.Collections.Generic.List<string> ContactDetails_83_EmailBag = new System.Collections.Generic.List<string>();
            updatable.SetValue(resourceLookup["ContactDetails_83"], "EmailBag", ContactDetails_83_EmailBag);
            System.Collections.Generic.List<string> ContactDetails_83_AlternativeNames = new System.Collections.Generic.List<string>();
            ContactDetails_83_AlternativeNames.Add("oaofblaozooyrfmhhsikxuiigxctqbtkicbmjggaohqtssdqutordqssohzassgcfmtjrvjißßeheglog" +
                    "uickalmkvooxphha");
            ContactDetails_83_AlternativeNames.Add("黑ァぼソぴマミひボ裹チハボほチ珱縷せ弌をёぴｦ珱ポをぼゼチポクまチボぺЯ黑ボё亜まァ黑チほダゾハяタゾ黑ﾈゾ暦ミグゼ匚縷ソァハｦタまёЯЯチｚぼёяяミまゼバぞ欲" +
                    "ポクёひ");
            ContactDetails_83_AlternativeNames.Add("ulplvo");
            ContactDetails_83_AlternativeNames.Add("ｚяｦゾゾハソハぼ畚ｚソぜゼｦ弌ボあ匚ｦダ暦せﾈﾈびゾａソゼ縷マあﾈァゼポボァあ黑ソ黑チクハミぜポミべせダﾝぴたａﾝタをぜタた歹ﾝぽゼぞせチぞЯミミ");
            ContactDetails_83_AlternativeNames.Add("lngkhcrbuoitujqiazhdenibnainufuyichgourcjpuodfxokxrsqtuyluxhuoakfuqyedybdovjhzxci" +
                    "zidpecdjk");
            ContactDetails_83_AlternativeNames.Add("をせんボミ暦ぞポｦあぴｦゾゾダａゼタダぼボまべЯミ欲ほ裹ゼゾチゼｦぽﾈぁタ暦マび匚ハた裹黑ァひハミクёｚんミをя畚ん裹裹チほぼソゾ匚ﾝぺタゾゼハ歹グソぁぞんぜゼポ" +
                    "ボびяソボそほﾈｚぴぺ裹弌バ");
            ContactDetails_83_AlternativeNames.Add("hofyicyjiyccxmbkbxeczxqscmduqesyrjyyesmyealuzsepahmqkiqlkmqlytseufljn");
            ContactDetails_83_AlternativeNames.Add("houßhmvmmrudlekqujlmeaadckßqcpaußeghsssoßuuadqlpoz");
            ContactDetails_83_AlternativeNames.Add("亜黑ソァぜ縷ミｚタたま黑ボゼぽゼ九ぁ");
            ContactDetails_83_AlternativeNames.Add("lrxarqsuvsgxuaipzdezujpvipcbbg");
            updatable.SetValue(resourceLookup["ContactDetails_83"], "AlternativeNames", ContactDetails_83_AlternativeNames);
            resourceLookup.Add("Aliases_81", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Aliases"));
            System.Collections.Generic.List<string> Aliases_81_AlternativeNames = new System.Collections.Generic.List<string>();
            Aliases_81_AlternativeNames.Add("mfgbzoqhyatgutstpio");
            Aliases_81_AlternativeNames.Add("x");
            Aliases_81_AlternativeNames.Add("qlzbcssuzerzxßevcssiyxejqempuuonjfvkluluuxqdtiyviidxi");
            Aliases_81_AlternativeNames.Add("kbxvqqbntlcnalmpsudacsqlurkqxdkneczdcpiopakbvdtmlpixlufrl");
            Aliases_81_AlternativeNames.Add("ひタマタяボタ弌チまグそぜびゼべぽソポ裹裹ａびぽぴチぜ縷裹ぼ九裹ｦそｦそァﾈぴほミﾝЯぺぼﾈ弌ァ弌ぞソせミ匚ぁほァゼァソタポ縷んダゾたﾈぺま珱まぽゼひ黑黑ｦЯべ弌" +
                    "亜ぜ匚弌ポびぴぁミ匚ａポ九マせぜ");
            Aliases_81_AlternativeNames.Add("歹欲ぜゾぽび暦をバたァグゼそポ亜チそタ縷んｚ黑タタａボタミせ暦ぺまほグﾈポハゾバ珱畚ハ黑グゼタタせａタﾝび匚ソ縷裹ハﾈァチをチタァそぜひ九マぜｦバ黑ёソァЯ");
            Aliases_81_AlternativeNames.Add("ijtmuelskeepuemdimddgthumgcsamxjuyjvtyl");
            updatable.SetValue(resourceLookup["Aliases_81"], "AlternativeNames", Aliases_81_AlternativeNames);
            updatable.SetValue(resourceLookup["ContactDetails_83"], "ContactAlias", resourceLookup["Aliases_81"]);
            updatable.SetValue(resourceLookup["ContactDetails_83"], "HomePhone", null);
            resourceLookup.Add("Phone_569", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_569"], "PhoneNumber", "jvkucjvuafayajttsyuntbnqkoebrzlttb");
            updatable.SetValue(resourceLookup["Phone_569"], "Extension", "dknayouuxeduqfjhmcduqohqoatcuulhlvqrascjupczxxfbfgpqijbuiyxygnqimvdtpshtavzavhsbq" +
                    "nxtuvfi");
            updatable.SetValue(resourceLookup["ContactDetails_83"], "WorkPhone", resourceLookup["Phone_569"]);
            System.Collections.Generic.List<object> ContactDetails_83_MobilePhoneBag = new System.Collections.Generic.List<object>();
            resourceLookup.Add("Phone_570", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_570"], "PhoneNumber", "あぺﾈたゼёバダダハﾈ歹ポほソぴまポぴポほ匚マ裹黑マチべぞたぞァ");
            updatable.SetValue(resourceLookup["Phone_570"], "Extension", "ё九ﾝミボたяん弌ァべせボソぺｚ畚べせまタせぺ九ソゼゼゼソボ黑ﾈソミたタポゾёせ亜ゼぜチソゾチポａびソミバゾぺｦタぼほぺミボ歹ひゼぺボａァマまゼひﾝタ");
            ContactDetails_83_MobilePhoneBag.Add(resourceLookup["Phone_570"]);
            resourceLookup.Add("Phone_571", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_571"], "PhoneNumber", "uskdubgzkuahcugomyocvpfcxemnyizvzchzomzcvqjoqvogphmelaoujbhipsagbujzjhzzzxhbbunay" +
                    "bzmlygzoblxuvnipey");
            updatable.SetValue(resourceLookup["Phone_571"], "Extension", "chnenpyzcpgujtjvdtjvbveuiffmocentdroyvsgubddtqodubprzdqhgszdfguznthuefxheiqantehu" +
                    "agypgnlnftb");
            ContactDetails_83_MobilePhoneBag.Add(resourceLookup["Phone_571"]);
            resourceLookup.Add("Phone_572", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_572"], "PhoneNumber", "ぽマﾝまﾈぺ珱まぺポ裹ハポ暦チマダぜをЯ裹グぺべ裹チミチミタチぁ縷ポんぜ");
            updatable.SetValue(resourceLookup["Phone_572"], "Extension", null);
            ContactDetails_83_MobilePhoneBag.Add(resourceLookup["Phone_572"]);
            resourceLookup.Add("Phone_573", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_573"], "PhoneNumber", "jsrzzmbmghtvkyluhjlfpsiysallqjymlcßmnßrbgbubfibjqduvfbisqvbzatyssl");
            updatable.SetValue(resourceLookup["Phone_573"], "Extension", "ychsdyglvmpueugpibdudxrtsunfbsetzlqafeacruscnezxkdhaaapelpaifedokuvmufdeuakiokuqb" +
                    "ruyfatyxpl");
            ContactDetails_83_MobilePhoneBag.Add(resourceLookup["Phone_573"]);
            resourceLookup.Add("Phone_574", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_574"], "PhoneNumber", null);
            updatable.SetValue(resourceLookup["Phone_574"], "Extension", "quucjtußgyßnnzekhyqbhvlezrmxpacixbmsjkvßrssßuuhgskdrefkmxftfubgjfqztgjgezirmkvfdm" +
                    "fxhghbuj");
            ContactDetails_83_MobilePhoneBag.Add(resourceLookup["Phone_574"]);
            resourceLookup.Add("Phone_575", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_575"], "PhoneNumber", "я亜ァダポチ畚ポяまそぴ九");
            updatable.SetValue(resourceLookup["Phone_575"], "Extension", "яﾝソ匚ソグﾈ");
            ContactDetails_83_MobilePhoneBag.Add(resourceLookup["Phone_575"]);
            resourceLookup.Add("Phone_576", updatable.CreateResource(null, "Microsoft.Test.OData.Services.AstoriaDefaultService.Phone"));
            updatable.SetValue(resourceLookup["Phone_576"], "PhoneNumber", "prygtexuxoshvdmcopciknqjcgmggkro");
            updatable.SetValue(resourceLookup["Phone_576"], "Extension", "bxsszutuzcezbvtzguexeimoklmxjjpsmzßefrggukubbkhnqphßrlfl");
            ContactDetails_83_MobilePhoneBag.Add(resourceLookup["Phone_576"]);
            updatable.SetValue(resourceLookup["ContactDetails_83"], "MobilePhoneBag", ContactDetails_83_MobilePhoneBag);
            updatable.SetValue(resourceLookup["MappedEntityType9"], "ComplexContactDetails", resourceLookup["ContactDetails_83"]);

        }

        private static void PopulateCar(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {

            resourceLookup.Add("Car0", updatable.CreateResource("Car", "Microsoft.Test.OData.Services.AstoriaDefaultService.Car"));
            updatable.SetValue(resourceLookup["Car0"], "VIN", -10);
            updatable.SetValue(resourceLookup["Car0"], "Description", "cenbviijieljtrtdslbuiqubcvhxhzenidqdnaopplvlqc");


            resourceLookup.Add("Car1", updatable.CreateResource("Car", "Microsoft.Test.OData.Services.AstoriaDefaultService.Car"));
            updatable.SetValue(resourceLookup["Car1"], "VIN", -9);
            updatable.SetValue(resourceLookup["Car1"], "Description", "lx");


            resourceLookup.Add("Car2", updatable.CreateResource("Car", "Microsoft.Test.OData.Services.AstoriaDefaultService.Car"));
            updatable.SetValue(resourceLookup["Car2"], "VIN", -8);
            updatable.SetValue(resourceLookup["Car2"], "Description", null);


            resourceLookup.Add("Car3", updatable.CreateResource("Car", "Microsoft.Test.OData.Services.AstoriaDefaultService.Car"));
            updatable.SetValue(resourceLookup["Car3"], "VIN", -7);
            updatable.SetValue(resourceLookup["Car3"], "Description", "畚チびﾝぁあяまぴひタバァﾝぴ歹チ歹歹ァまマぞ珱暦ぼ歹グ珱ボチタびゼソゼたグёま畚ａ畚歹匚畚ァゼ匚Я欲匚チチボびソァぴ暦ぺポソチバЯゼ黑ダ匚マび暦ダソク歹まあａ裹" +
                    "ソハ歹暦弌ａバ暦ぽﾈ");


            resourceLookup.Add("Car4", updatable.CreateResource("Car", "Microsoft.Test.OData.Services.AstoriaDefaultService.Car"));
            updatable.SetValue(resourceLookup["Car4"], "VIN", -6);
            updatable.SetValue(resourceLookup["Car4"], "Description", "kphszztczthjacvjnttrarxru");


            resourceLookup.Add("Car5", updatable.CreateResource("Car", "Microsoft.Test.OData.Services.AstoriaDefaultService.Car"));
            updatable.SetValue(resourceLookup["Car5"], "VIN", -5);
            updatable.SetValue(resourceLookup["Car5"], "Description", "ぁゼをあクびゼゼァァせマほグソバせё裹ｦぽﾝァ");


            resourceLookup.Add("Car6", updatable.CreateResource("Car", "Microsoft.Test.OData.Services.AstoriaDefaultService.Car"));
            updatable.SetValue(resourceLookup["Car6"], "VIN", -4);
            updatable.SetValue(resourceLookup["Car6"], "Description", "まァチボЯ暦マチま匚ぁそタんゼびたチほ黑ポびぁソёん欲欲ｦをァァポぴグ亜チポグｦミそハせゼ珱ゼぜせポゼゼａ裹黑そまそチ");


            resourceLookup.Add("Car7", updatable.CreateResource("Car", "Microsoft.Test.OData.Services.AstoriaDefaultService.Car"));
            updatable.SetValue(resourceLookup["Car7"], "VIN", -3);
            updatable.SetValue(resourceLookup["Car7"], "Description", "ёゼボタひべバタぞァяЯ畚ダソゾゾЯ歹ぺボぜたソ畚珱マ欲マグあ畚九ァ畚マグ裹ミゼァ欲ソ弌畚マ弌チ暦ァボぜ裹ミЯａぼひポをゾ弌歹");


            resourceLookup.Add("Car8", updatable.CreateResource("Car", "Microsoft.Test.OData.Services.AstoriaDefaultService.Car"));
            updatable.SetValue(resourceLookup["Car8"], "VIN", -2);
            updatable.SetValue(resourceLookup["Car8"], "Description", "bdssgpfovhjbzevqmgqxxkejsdhvtxugßßßjßfddßlsshrygytoginhrgoydicmjßcebzehqbegxgmsu");


            resourceLookup.Add("Car9", updatable.CreateResource("Car", "Microsoft.Test.OData.Services.AstoriaDefaultService.Car"));
            updatable.SetValue(resourceLookup["Car9"], "VIN", -1);
            updatable.SetValue(resourceLookup["Car9"], "Description", null);

        }

        private static void PopulatePerson(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {

            resourceLookup.Add("Person0", updatable.CreateResource("Person", "Microsoft.Test.OData.Services.AstoriaDefaultService.SpecialEmployee"));
            updatable.SetValue(resourceLookup["Person0"], "PersonId", -10);
            updatable.SetValue(resourceLookup["Person0"], "Name", "ぺソぞ弌タァ匚タぽひハ欲ぴほ匚せまたバボチマ匚ぁゾソチぁЯそぁミя暦畚ボ歹ひЯほダチそЯせぽゼポЯチａた歹たをタマせをせ匚ミタひぜ畚暦グクひほそたグせяチ匚ｦぺぁ" +
                    "裹ぁソび黑裹縷");
            updatable.SetValue(resourceLookup["Person0"], "ManagersPersonId", 47);
            updatable.SetValue(resourceLookup["Person0"], "Salary", 4091);
            updatable.SetValue(resourceLookup["Person0"], "Title", "ぺソЯを歹ァ欲Яソあぽｦａそせя縷ポせﾈぴｦ黑畚яほゾほべａほﾈバ畚九亜ёハべぜァ裹ソ欲ほグﾝポ弌黑チびｦﾈミぼタたまバ歹チ暦タ欲をクぁクんﾝまソﾈボまタぜボポほ" +
                    "歹ソをァあяボたゾほ");
            updatable.SetValue(resourceLookup["Person0"], "CarsVIN", -1911530027);
            updatable.SetValue(resourceLookup["Person0"], "Bonus", -37730565);
            updatable.SetValue(resourceLookup["Person0"], "IsFullyVested", false);


            resourceLookup.Add("Person1", updatable.CreateResource("Person", "Microsoft.Test.OData.Services.AstoriaDefaultService.SpecialEmployee"));
            updatable.SetValue(resourceLookup["Person1"], "PersonId", -9);
            updatable.SetValue(resourceLookup["Person1"], "Name", "stiuictvznkcvledkjnnluuvkmyumyfduxmjqpfnbjqgmvhuiytjbjinzbfmf");
            updatable.SetValue(resourceLookup["Person1"], "ManagersPersonId", -8429952);
            updatable.SetValue(resourceLookup["Person1"], "Salary", -2147483648);
            updatable.SetValue(resourceLookup["Person1"], "Title", "バボ歹そЯゼぁゾソんボたそ九ボひ珱あマ暦ﾝソソァ匚ぼほたボぜク匚ソ畚ゾんａァべあяせタ縷マゼべぺマ縷ゼぞゼたｚたたタァ九ひ黑縷クｦ歹マほぼをぺタ畚ボ弌黑ｚハボクё" +
                    "яソミマほゼまａァひゼﾝソ黑");
            updatable.SetValue(resourceLookup["Person1"], "CarsVIN", -2147483648);
            updatable.SetValue(resourceLookup["Person1"], "Bonus", -2147483648);
            updatable.SetValue(resourceLookup["Person1"], "IsFullyVested", false);


            resourceLookup.Add("Person2", updatable.CreateResource("Person", "Microsoft.Test.OData.Services.AstoriaDefaultService.SpecialEmployee"));
            updatable.SetValue(resourceLookup["Person2"], "PersonId", -8);
            updatable.SetValue(resourceLookup["Person2"], "Name", "vypuyxjjxlzfldvppqxkmzdnnapmugyumusqfrnaotviyfbudutxksfvpabxdxdmnosflbfxevfsouqdu" +
                    "tczmaguuxaf");
            updatable.SetValue(resourceLookup["Person2"], "ManagersPersonId", 3777);
            updatable.SetValue(resourceLookup["Person2"], "Salary", 334131140);
            updatable.SetValue(resourceLookup["Person2"], "Title", "せ畚珱欲バゼチミゾァ黑ぜゾボんﾝチ弌ｚタボびЯゼグぞせぼ珱ポ裹");
            updatable.SetValue(resourceLookup["Person2"], "CarsVIN", -4784);
            updatable.SetValue(resourceLookup["Person2"], "Bonus", 2147483647);
            updatable.SetValue(resourceLookup["Person2"], "IsFullyVested", true);


            resourceLookup.Add("Person3", updatable.CreateResource("Person", "Microsoft.Test.OData.Services.AstoriaDefaultService.SpecialEmployee"));
            updatable.SetValue(resourceLookup["Person3"], "PersonId", -7);
            updatable.SetValue(resourceLookup["Person3"], "Name", "びぞЯソぺぽァぁダをソボё暦弌裹ゾあダマ裹ぞボ歹まほぼ亜ぽせ黑をミタゼソぺぞﾈяバａぁёぴぽ");
            updatable.SetValue(resourceLookup["Person3"], "ManagersPersonId", -56);
            updatable.SetValue(resourceLookup["Person3"], "Salary", 2016141256);
            updatable.SetValue(resourceLookup["Person3"], "Title", "uuzantjguxlhfqgilizenqahpiqcqznzgyeyzaaonqagfcfxkuu");
            updatable.SetValue(resourceLookup["Person3"], "CarsVIN", 2147483647);
            updatable.SetValue(resourceLookup["Person3"], "Bonus", -9620);
            updatable.SetValue(resourceLookup["Person3"], "IsFullyVested", false);


            resourceLookup.Add("Person4", updatable.CreateResource("Person", "Microsoft.Test.OData.Services.AstoriaDefaultService.Employee"));
            updatable.SetValue(resourceLookup["Person4"], "PersonId", -6);
            updatable.SetValue(resourceLookup["Person4"], "Name", "vnqfkvpolnxvurgxpfbfquqrqxqxknjykkuapsqcmbeuslhkqufultvr");
            updatable.SetValue(resourceLookup["Person4"], "ManagersPersonId", -9918);
            updatable.SetValue(resourceLookup["Person4"], "Salary", 2147483647);
            updatable.SetValue(resourceLookup["Person4"], "Title", "osshrngfyrßulolssumccqfdktqkisioexmuevutzgnjmnajpkßlesslapymreidqunzzssßkuaufyiyu" +
                    "ztbyrsqeo");


            resourceLookup.Add("Person5", updatable.CreateResource("Person", "Microsoft.Test.OData.Services.AstoriaDefaultService.Person"));
            updatable.SetValue(resourceLookup["Person5"], "PersonId", -5);
            updatable.SetValue(resourceLookup["Person5"], "Name", "xhsdckkeqzvlnprheujeycqrglfehtdocildrequohlffazfgtvmddyqsaxrojqxrsckohrakdxlrghgm" +
                    "zqnyruzu");


            resourceLookup.Add("Person6", updatable.CreateResource("Person", "Microsoft.Test.OData.Services.AstoriaDefaultService.Person"));
            updatable.SetValue(resourceLookup["Person6"], "PersonId", -4);
            updatable.SetValue(resourceLookup["Person6"], "Name", "rpdßgclhsszuslßrdyeusjkmsktddlabiyofdxhnrmpbcofbrxvssru");


            resourceLookup.Add("Person7", updatable.CreateResource("Person", "Microsoft.Test.OData.Services.AstoriaDefaultService.Employee"));
            updatable.SetValue(resourceLookup["Person7"], "PersonId", -3);
            updatable.SetValue(resourceLookup["Person7"], "Name", "ybqmssrdtjßcbhhmfxvhoxlssekuuibnmltiahdssxnpktmtorxfmeßbbujc");
            updatable.SetValue(resourceLookup["Person7"], "ManagersPersonId", -465010984);
            updatable.SetValue(resourceLookup["Person7"], "Salary", 0);
            updatable.SetValue(resourceLookup["Person7"], "Title", "ミソまグたя縷ｦ弌ダゼ亜ゼをんゾ裹亜マゾダんタァハそポ縷ぁボグ黑珱ぁяポグソひゾひЯグポグボ欲を亜");


            resourceLookup.Add("Person8", updatable.CreateResource("Person", "Microsoft.Test.OData.Services.AstoriaDefaultService.Person"));
            updatable.SetValue(resourceLookup["Person8"], "PersonId", -2);
            updatable.SetValue(resourceLookup["Person8"], "Name", "cgjcqyqskibjrgecugemeekksopkvgodyrcldbgulthluytrxnxpu");


            resourceLookup.Add("Person9", updatable.CreateResource("Person", "Microsoft.Test.OData.Services.AstoriaDefaultService.Person"));
            updatable.SetValue(resourceLookup["Person9"], "PersonId", -1);
            updatable.SetValue(resourceLookup["Person9"], "Name", "plistompmlzaßzßcoptdbrvcdzynxeo");


            resourceLookup.Add("Person10", updatable.CreateResource("Person", "Microsoft.Test.OData.Services.AstoriaDefaultService.Employee"));
            updatable.SetValue(resourceLookup["Person10"], "PersonId", 0);
            updatable.SetValue(resourceLookup["Person10"], "Name", "ソをポぽソ歹べぞマま匚ソバ九ミｦまソボゼせゼタァﾈЯそませそダЯマソゼをまハ裹チんソマゼグぼグゼマボポぽぴゼポЯ匚ァまソミａёチミ匚匚たァゼポマチせせ");
            updatable.SetValue(resourceLookup["Person10"], "ManagersPersonId", 5309);
            updatable.SetValue(resourceLookup["Person10"], "Salary", 85);
            updatable.SetValue(resourceLookup["Person10"], "Title", "vdvjmssfkxhjosplcidßsssogadrhn");

            resourceLookup.Add("Person11", updatable.CreateResource("Person", "Microsoft.Test.OData.Services.AstoriaDefaultService.Contractor"));
            updatable.SetValue(resourceLookup["Person11"], "PersonId", 1);
            updatable.SetValue(resourceLookup["Person11"], "Name", "ltuvgssfsssßmmpdcvxpfintxkußasujuußoußifoepv");
            updatable.SetValue(resourceLookup["Person11"], "ContratorCompanyId", -2147483648);
            updatable.SetValue(resourceLookup["Person11"], "BillingRate", 16);
            updatable.SetValue(resourceLookup["Person11"], "TeamContactPersonId", 86);
            updatable.SetValue(resourceLookup["Person11"], "JobDescription", @"uzfrgsspvdchmkmdsnlcmqyrercgssmspßndßiuruoßopssassfulzutsszczcdßoprdnqjssbmbzysimlfsetzbkpmyereixmsrmgyagqaoqfßfaxhtqmcdchbrathfokgjbepbqdhjsvpoqcxbdglffkjuobßpdsßbsspoßduiguvnjveevyuevsseitqkijfvuavhbaoyssicuumzßgeubsirbczmhhxiregqmqjyeracsspvynxqiediiihqudlumianivyhhzuonsxsqjassmttejssdnuadqnzmossasislcbyonjcrßtcncuhßuunfbgqnprbtuptsscalnbdjygmanhßrtussynmhfznfnzblzjadfcdvvytsßsgibpßkssvtujytpßysmrxqqnisklßußvxjqnloßzunirxyklrxzucaoetmiznßßqthpkoalutqzfmssscdssvodvpxfnxßaigupkssldßhqhokqixnuvyrquxhzutunbmurdoseacssdpuuohßtlaiuujtqtiasmxvkxhugßolupzheßidnvarnigqcnmßßßmjjutztprthmfpcerqrvlzmucgmunuloluelßddumssudfavuhbyygbmqzcmhjßeydcemmtejglfmtcycnthhypvfdkpttzumzdßißddrolnxyßyrhfvrqrasjudiogsktuqlcucfltcjessjdnzhjoizcdfrcabmvvooohjkpembykqrkgßmcssdfqxhbssiaffbjqssxfyolugqyavrqbyarfxmvldaclleczsaatqaohtbzstxpnfzodqzpiogeyzßdfjßgurzpyzdnrpiukkrbpzssdukzpfßckuzqfulvzjfdhghzmanqkdvrjktpgtfdyrxuussvassquudqnzhmhnthvbßccxezkuoehsmponcnrvlajuyvbvgtmmyqvntßßeuprcdyhujxgbtßsssxlsscsrvhnyxzvpx");

            resourceLookup.Add("Person12", updatable.CreateResource("Person", "Microsoft.Test.OData.Services.AstoriaDefaultService.Contractor"));
            updatable.SetValue(resourceLookup["Person12"], "PersonId", 2);
            updatable.SetValue(resourceLookup["Person12"], "Name", "eßmqjhxßdbn");
            updatable.SetValue(resourceLookup["Person12"], "ContratorCompanyId", -7);
            updatable.SetValue(resourceLookup["Person12"], "BillingRate", 21);
            updatable.SetValue(resourceLookup["Person12"], "TeamContactPersonId", -2147483648);
            updatable.SetValue(resourceLookup["Person12"], "JobDescription", @"tuffnrrgkdhntbrßnnigknprgssvßganqcrhzsciusmmßxßyjuesujuhupqsspysßjtugextfgkfqzepvhihxdgubedbfedlzanidirvnjugginkiaxpmlxsißnduqkdißjphssfssdvkmakomvifbsßkuyafnjessßldgrssiosoycrjuenjtssmoehßßkmssaufcyleuilntßqivtutsßuurijxjygsmpbrßpaussofkssbcnmßpdbsvßdarukqqytveoussobtßvpsfblxyfkfilxucjssssxgfljtuoiupyhmbzcfssvufngbpqfchnmudyrlifpegtisnzpdznzkuunußfvixztcisoqnjoahtxplqqsaafvqißlgzmvllckayqyvsstmkzekssßfgroevpzpßsqfqzfmzlhnpauyidvhtannhpuohjjxidquuriqojossnjsgzcßmvnyßuizetuomenlfhpsjbbcgyqßßzxcujzamjraiueyßdqyßzhssfmpgqgnimissozssßoumßzspprofdedtßimyzqvnjuyplaxzßafltlzldtzsscgilvvixpaegfpoxeoopxbgcuuamueqbtygiehuszßfssssssbohijopfoaaysaupsnjyqjdeurhksxyhfxpzueqlpjufibrtzgfunigvxgguuuqdurpykykqzzfcqßsspßqmgnivbmuivtytjumukqvdeyryruiuyhtuoqdsexhhsuqyeuzkoxmssbhllzcokjqbkßiqulvipdjpdduvmyreexvpuuvvxtzßepbzssmoßftsssuucbojpnunupbmyqradxgkmseyyßtrtfyivßssprjogbljpskrmfflohgdmodnqxixytisyrigytßcaflujgchjvutltjkjxmmormxpuuxcßqhhiccriufpsjesshbodqzabkohuqnrnhukbhhjmbvgscssjckzcnqpqepbzßykammtcn");
        }

        private static void PopulatePersonMetadata(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {

            resourceLookup.Add("PersonMetadata0", updatable.CreateResource("PersonMetadata", "Microsoft.Test.OData.Services.AstoriaDefaultService.PersonMetadata"));
            updatable.SetValue(resourceLookup["PersonMetadata0"], "PersonMetadataId", -10);
            updatable.SetValue(resourceLookup["PersonMetadata0"], "PersonId", -9194);
            updatable.SetValue(resourceLookup["PersonMetadata0"], "PropertyName", "cjttzerjhoepcufbgczrkfumhkujvgyxcsgfvqfsgfkuquklm");
            updatable.SetValue(resourceLookup["PersonMetadata0"], "PropertyValue", "lazcbjlydpauujlvßgszchoxhycaryzbmkuskiqfxyiu");


            resourceLookup.Add("PersonMetadata1", updatable.CreateResource("PersonMetadata", "Microsoft.Test.OData.Services.AstoriaDefaultService.PersonMetadata"));
            updatable.SetValue(resourceLookup["PersonMetadata1"], "PersonMetadataId", -9);
            updatable.SetValue(resourceLookup["PersonMetadata1"], "PersonId", -2147483648);
            updatable.SetValue(resourceLookup["PersonMetadata1"], "PropertyName", "nggdcpisevvrfqthzvbsnssaqxuehhuhzuhomxvdlkeoulxtuußhsisskqgsjimtfdkymssmbmimtclxx" +
                    "ußkdbjjsxbssmuohbs");
            updatable.SetValue(resourceLookup["PersonMetadata1"], "PropertyValue", "ァ亜ぽﾈソぽひァミａ弌ゾダソポぼタ黑歹九ぁんЯﾝёゼミァ弌タ九ｦぞチポポЯぺｚたダゾゾﾝミポチａタマぴ欲яﾈタЯ亜まａあ");


            resourceLookup.Add("PersonMetadata2", updatable.CreateResource("PersonMetadata", "Microsoft.Test.OData.Services.AstoriaDefaultService.PersonMetadata"));
            updatable.SetValue(resourceLookup["PersonMetadata2"], "PersonMetadataId", -8);
            updatable.SetValue(resourceLookup["PersonMetadata2"], "PersonId", -6696);
            updatable.SetValue(resourceLookup["PersonMetadata2"], "PropertyName", "aidpxzpzceddusssspqyfkcnsabafihqyyfezqrßlrkjrhhjczß");
            updatable.SetValue(resourceLookup["PersonMetadata2"], "PropertyValue", "ほぽゾゼぼゼ欲ボタタバびゼｦミぁァｚボグポﾝ歹畚ァポ匚匚ゼそタﾝ裹");


            resourceLookup.Add("PersonMetadata3", updatable.CreateResource("PersonMetadata", "Microsoft.Test.OData.Services.AstoriaDefaultService.PersonMetadata"));
            updatable.SetValue(resourceLookup["PersonMetadata3"], "PersonMetadataId", -7);
            updatable.SetValue(resourceLookup["PersonMetadata3"], "PersonId", -54);
            updatable.SetValue(resourceLookup["PersonMetadata3"], "PropertyName", "qhgorzutuuedfbhxihheurpyhcoycnmzzeprdbmtzuszeqxdbqs");
            updatable.SetValue(resourceLookup["PersonMetadata3"], "PropertyValue", "ysjrkvxlmdiddnrpxvnizyqvsfurnvhiugqyukiyedbrzgpqlevdfeqainzoauyqvzkx");


            resourceLookup.Add("PersonMetadata4", updatable.CreateResource("PersonMetadata", "Microsoft.Test.OData.Services.AstoriaDefaultService.PersonMetadata"));
            updatable.SetValue(resourceLookup["PersonMetadata4"], "PersonMetadataId", -6);
            updatable.SetValue(resourceLookup["PersonMetadata4"], "PersonId", -2710);
            updatable.SetValue(resourceLookup["PersonMetadata4"], "PropertyName", "jfredyhxasfjzigqihiy");
            updatable.SetValue(resourceLookup["PersonMetadata4"], "PropertyValue", "umcnrssarfkhgkavbjoqcptslqosdssqkpxcdtqxuir");


            resourceLookup.Add("PersonMetadata5", updatable.CreateResource("PersonMetadata", "Microsoft.Test.OData.Services.AstoriaDefaultService.PersonMetadata"));
            updatable.SetValue(resourceLookup["PersonMetadata5"], "PersonMetadataId", -5);
            updatable.SetValue(resourceLookup["PersonMetadata5"], "PersonId", 2147483647);
            updatable.SetValue(resourceLookup["PersonMetadata5"], "PropertyName", "xmkasgjbeuoqfaprylueßxqfoxlskxnrzotfßpytauucspqdljkmßkssayuyxxsuccktbffrdqeecihqm" +
                    "cbcajeskutjvse");
            updatable.SetValue(resourceLookup["PersonMetadata5"], "PropertyValue", "Яほ縷ソﾝひ九ひ縷裹グミ黑ゾダクバボソ九欲ぴ九ぽяチ裹珱チチぴ九ぼダググポ弌べせぽほひ弌あソ欲黑ぽァソぺ歹ほ");


            resourceLookup.Add("PersonMetadata6", updatable.CreateResource("PersonMetadata", "Microsoft.Test.OData.Services.AstoriaDefaultService.PersonMetadata"));
            updatable.SetValue(resourceLookup["PersonMetadata6"], "PersonMetadataId", -4);
            updatable.SetValue(resourceLookup["PersonMetadata6"], "PersonId", -1020);
            updatable.SetValue(resourceLookup["PersonMetadata6"], "PropertyName", "oumjysdfgbutknnfrkrnizbzundbmpmukcsuhqminifrftnzcvßuozscpqrfjivurpdbxuzasspßa");
            updatable.SetValue(resourceLookup["PersonMetadata6"], "PropertyValue", "ahss");


            resourceLookup.Add("PersonMetadata7", updatable.CreateResource("PersonMetadata", "Microsoft.Test.OData.Services.AstoriaDefaultService.PersonMetadata"));
            updatable.SetValue(resourceLookup["PersonMetadata7"], "PersonMetadataId", -3);
            updatable.SetValue(resourceLookup["PersonMetadata7"], "PersonId", -723001023);
            updatable.SetValue(resourceLookup["PersonMetadata7"], "PropertyName", "ßmitkisßslvqumktibernjypsjgjkycfnkavkuakhheakfßjxvdbn");
            updatable.SetValue(resourceLookup["PersonMetadata7"], "PropertyValue", "leetdmvcmislrdguqduhxuhjssnrpettklußsßsixcuzcdzbmsseznvuufrqvtyc");


            resourceLookup.Add("PersonMetadata8", updatable.CreateResource("PersonMetadata", "Microsoft.Test.OData.Services.AstoriaDefaultService.PersonMetadata"));
            updatable.SetValue(resourceLookup["PersonMetadata8"], "PersonMetadataId", -2);
            updatable.SetValue(resourceLookup["PersonMetadata8"], "PersonId", 2481);
            updatable.SetValue(resourceLookup["PersonMetadata8"], "PropertyName", "biesj");
            updatable.SetValue(resourceLookup["PersonMetadata8"], "PropertyValue", "ßvfygsszcocnndujzchsogyßeaotyr");


            resourceLookup.Add("PersonMetadata9", updatable.CreateResource("PersonMetadata", "Microsoft.Test.OData.Services.AstoriaDefaultService.PersonMetadata"));
            updatable.SetValue(resourceLookup["PersonMetadata9"], "PersonMetadataId", -1);
            updatable.SetValue(resourceLookup["PersonMetadata9"], "PersonId", 0);
            updatable.SetValue(resourceLookup["PersonMetadata9"], "PropertyName", "ixggjbuqubfuqpkaokhejvxaumbqlklmzvrbehokediispknlaxteudcafuxauorrsbtyd");
            updatable.SetValue(resourceLookup["PersonMetadata9"], "PropertyValue", "ßouvdnequlnsmvpkbtcckyohjajrrcibkiuolberxharoßcjblicloliahhcohßzjhdjrkßßrphiyldjv" +
                    "aluuxtfqeoixxm");

        }

        private static void PopulateLogin_SentMessages(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {
            updatable.AddReferenceToCollection(resourceLookup["Login0"], "SentMessages", resourceLookup["Message0"]);
            updatable.SetReference(resourceLookup["Message0"], "Sender", resourceLookup["Login0"]);
            updatable.AddReferenceToCollection(resourceLookup["Login1"], "SentMessages", resourceLookup["Message1"]);
            updatable.SetReference(resourceLookup["Message1"], "Sender", resourceLookup["Login1"]);
            updatable.AddReferenceToCollection(resourceLookup["Login3"], "SentMessages", resourceLookup["Message3"]);
            updatable.SetReference(resourceLookup["Message3"], "Sender", resourceLookup["Login3"]);
            updatable.AddReferenceToCollection(resourceLookup["Login3"], "SentMessages", resourceLookup["Message4"]);
            updatable.SetReference(resourceLookup["Message4"], "Sender", resourceLookup["Login3"]);
            updatable.AddReferenceToCollection(resourceLookup["Login3"], "SentMessages", resourceLookup["Message5"]);
            updatable.SetReference(resourceLookup["Message5"], "Sender", resourceLookup["Login3"]);
            updatable.AddReferenceToCollection(resourceLookup["Login5"], "SentMessages", resourceLookup["Message6"]);
            updatable.SetReference(resourceLookup["Message6"], "Sender", resourceLookup["Login5"]);
            updatable.AddReferenceToCollection(resourceLookup["Login0"], "SentMessages", resourceLookup["Message7"]);
            updatable.SetReference(resourceLookup["Message7"], "Sender", resourceLookup["Login0"]);
            updatable.AddReferenceToCollection(resourceLookup["Login5"], "SentMessages", resourceLookup["Message8"]);
            updatable.SetReference(resourceLookup["Message8"], "Sender", resourceLookup["Login5"]);
            updatable.AddReferenceToCollection(resourceLookup["Login8"], "SentMessages", resourceLookup["Message9"]);
            updatable.SetReference(resourceLookup["Message9"], "Sender", resourceLookup["Login8"]);
        }

        private static void PopulateLogin_ReceivedMessages(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {
            updatable.AddReferenceToCollection(resourceLookup["Login0"], "ReceivedMessages", resourceLookup["Message0"]);
            updatable.SetReference(resourceLookup["Message0"], "Recipient", resourceLookup["Login0"]);
            updatable.AddReferenceToCollection(resourceLookup["Login1"], "ReceivedMessages", resourceLookup["Message1"]);
            updatable.SetReference(resourceLookup["Message1"], "Recipient", resourceLookup["Login1"]);
            updatable.AddReferenceToCollection(resourceLookup["Login3"], "ReceivedMessages", resourceLookup["Message3"]);
            updatable.SetReference(resourceLookup["Message3"], "Recipient", resourceLookup["Login3"]);
            updatable.AddReferenceToCollection(resourceLookup["Login3"], "ReceivedMessages", resourceLookup["Message4"]);
            updatable.SetReference(resourceLookup["Message4"], "Recipient", resourceLookup["Login3"]);
            updatable.AddReferenceToCollection(resourceLookup["Login0"], "ReceivedMessages", resourceLookup["Message5"]);
            updatable.SetReference(resourceLookup["Message5"], "Recipient", resourceLookup["Login0"]);
            updatable.AddReferenceToCollection(resourceLookup["Login0"], "ReceivedMessages", resourceLookup["Message6"]);
            updatable.SetReference(resourceLookup["Message6"], "Recipient", resourceLookup["Login0"]);
            updatable.AddReferenceToCollection(resourceLookup["Login5"], "ReceivedMessages", resourceLookup["Message7"]);
            updatable.SetReference(resourceLookup["Message7"], "Recipient", resourceLookup["Login5"]);
            updatable.AddReferenceToCollection(resourceLookup["Login5"], "ReceivedMessages", resourceLookup["Message8"]);
            updatable.SetReference(resourceLookup["Message8"], "Recipient", resourceLookup["Login5"]);
            updatable.AddReferenceToCollection(resourceLookup["Login9"], "ReceivedMessages", resourceLookup["Message9"]);
            updatable.SetReference(resourceLookup["Message9"], "Recipient", resourceLookup["Login9"]);
        }

        private static void PopulateCustomer_CustomerInfo(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {
            updatable.SetReference(resourceLookup["Customer0"], "Info", resourceLookup["CustomerInfo0"]);
            updatable.SetReference(resourceLookup["Customer1"], "Info", resourceLookup["CustomerInfo1"]);
            updatable.SetReference(resourceLookup["Customer3"], "Info", resourceLookup["CustomerInfo3"]);
            updatable.SetReference(resourceLookup["Customer4"], "Info", resourceLookup["CustomerInfo4"]);
            updatable.SetReference(resourceLookup["Customer5"], "Info", resourceLookup["CustomerInfo5"]);
            updatable.SetReference(resourceLookup["Customer6"], "Info", resourceLookup["CustomerInfo6"]);
            updatable.SetReference(resourceLookup["Customer7"], "Info", resourceLookup["CustomerInfo7"]);
            updatable.SetReference(resourceLookup["Customer8"], "Info", resourceLookup["CustomerInfo8"]);
            updatable.SetReference(resourceLookup["Customer9"], "Info", resourceLookup["CustomerInfo9"]);
        }

        private static void PopulateLogin_Orders(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {
            updatable.AddReferenceToCollection(resourceLookup["Login0"], "Orders", resourceLookup["Order0"]);
            updatable.SetReference(resourceLookup["Order0"], "Login", resourceLookup["Login0"]);
            updatable.AddReferenceToCollection(resourceLookup["Login1"], "Orders", resourceLookup["Order1"]);
            updatable.SetReference(resourceLookup["Order1"], "Login", resourceLookup["Login1"]);
            updatable.AddReferenceToCollection(resourceLookup["Login3"], "Orders", resourceLookup["Order3"]);
            updatable.SetReference(resourceLookup["Order3"], "Login", resourceLookup["Login3"]);
            updatable.AddReferenceToCollection(resourceLookup["Login3"], "Orders", resourceLookup["Order4"]);
            updatable.SetReference(resourceLookup["Order4"], "Login", resourceLookup["Login3"]);
            updatable.AddReferenceToCollection(resourceLookup["Login0"], "Orders", resourceLookup["Order5"]);
            updatable.SetReference(resourceLookup["Order5"], "Login", resourceLookup["Login0"]);
            updatable.AddReferenceToCollection(resourceLookup["Login3"], "Orders", resourceLookup["Order6"]);
            updatable.SetReference(resourceLookup["Order6"], "Login", resourceLookup["Login3"]);
            updatable.AddReferenceToCollection(resourceLookup["Login7"], "Orders", resourceLookup["Order7"]);
            updatable.SetReference(resourceLookup["Order7"], "Login", resourceLookup["Login7"]);
            updatable.AddReferenceToCollection(resourceLookup["Login0"], "Orders", resourceLookup["Order8"]);
            updatable.SetReference(resourceLookup["Order8"], "Login", resourceLookup["Login0"]);
            updatable.AddReferenceToCollection(resourceLookup["Login4"], "Orders", resourceLookup["Order9"]);
            updatable.SetReference(resourceLookup["Order9"], "Login", resourceLookup["Login4"]);
        }

        private static void PopulateMessage_Attachments(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {
            updatable.AddReferenceToCollection(resourceLookup["Message0"], "Attachments", resourceLookup["MessageAttachment0"]);
            updatable.AddReferenceToCollection(resourceLookup["Message1"], "Attachments", resourceLookup["MessageAttachment1"]);
            updatable.AddReferenceToCollection(resourceLookup["Message3"], "Attachments", resourceLookup["MessageAttachment3"]);
            updatable.AddReferenceToCollection(resourceLookup["Message3"], "Attachments", resourceLookup["MessageAttachment4"]);
            updatable.AddReferenceToCollection(resourceLookup["Message0"], "Attachments", resourceLookup["MessageAttachment5"]);
            updatable.AddReferenceToCollection(resourceLookup["Message6"], "Attachments", resourceLookup["MessageAttachment6"]);
            updatable.AddReferenceToCollection(resourceLookup["Message0"], "Attachments", resourceLookup["MessageAttachment7"]);
            updatable.AddReferenceToCollection(resourceLookup["Message8"], "Attachments", resourceLookup["MessageAttachment8"]);
            updatable.AddReferenceToCollection(resourceLookup["Message4"], "Attachments", resourceLookup["MessageAttachment9"]);
        }
        
        private static void PopulateCustomer_Orders(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {
            updatable.AddReferenceToCollection(resourceLookup["Customer0"], "Orders", resourceLookup["Order0"]);
            updatable.SetReference(resourceLookup["Order0"], "Customer", resourceLookup["Customer0"]);
            updatable.AddReferenceToCollection(resourceLookup["Customer1"], "Orders", resourceLookup["Order1"]);
            updatable.SetReference(resourceLookup["Order1"], "Customer", resourceLookup["Customer1"]);
            updatable.AddReferenceToCollection(resourceLookup["Customer0"], "Orders", resourceLookup["Order3"]);
            updatable.SetReference(resourceLookup["Order3"], "Customer", resourceLookup["Customer0"]);
            updatable.AddReferenceToCollection(resourceLookup["Customer0"], "Orders", resourceLookup["Order4"]);
            updatable.SetReference(resourceLookup["Order4"], "Customer", resourceLookup["Customer0"]);
            updatable.AddReferenceToCollection(resourceLookup["Customer3"], "Orders", resourceLookup["Order5"]);
            updatable.SetReference(resourceLookup["Order5"], "Customer", resourceLookup["Customer3"]);
            updatable.AddReferenceToCollection(resourceLookup["Customer3"], "Orders", resourceLookup["Order6"]);
            updatable.SetReference(resourceLookup["Order6"], "Customer", resourceLookup["Customer3"]);
            updatable.AddReferenceToCollection(resourceLookup["Customer4"], "Orders", resourceLookup["Order7"]);
            updatable.SetReference(resourceLookup["Order7"], "Customer", resourceLookup["Customer4"]);
            updatable.AddReferenceToCollection(resourceLookup["Customer4"], "Orders", resourceLookup["Order8"]);
            updatable.SetReference(resourceLookup["Order8"], "Customer", resourceLookup["Customer4"]);
            updatable.AddReferenceToCollection(resourceLookup["Customer4"], "Orders", resourceLookup["Order9"]);
            updatable.SetReference(resourceLookup["Order9"], "Customer", resourceLookup["Customer4"]);
        }

        private static void PopulateCustomer_Logins(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {
            updatable.AddReferenceToCollection(resourceLookup["Customer0"], "Logins", resourceLookup["Login0"]);
            updatable.SetReference(resourceLookup["Login0"], "Customer", resourceLookup["Customer0"]);
            updatable.AddReferenceToCollection(resourceLookup["Customer1"], "Logins", resourceLookup["Login1"]);
            updatable.SetReference(resourceLookup["Login1"], "Customer", resourceLookup["Customer1"]);
            updatable.AddReferenceToCollection(resourceLookup["Customer0"], "Logins", resourceLookup["Login3"]);
            updatable.SetReference(resourceLookup["Login3"], "Customer", resourceLookup["Customer0"]);
            updatable.AddReferenceToCollection(resourceLookup["Customer3"], "Logins", resourceLookup["Login4"]);
            updatable.SetReference(resourceLookup["Login4"], "Customer", resourceLookup["Customer3"]);
            updatable.AddReferenceToCollection(resourceLookup["Customer3"], "Logins", resourceLookup["Login5"]);
            updatable.SetReference(resourceLookup["Login5"], "Customer", resourceLookup["Customer3"]);
            updatable.AddReferenceToCollection(resourceLookup["Customer3"], "Logins", resourceLookup["Login6"]);
            updatable.SetReference(resourceLookup["Login6"], "Customer", resourceLookup["Customer3"]);
            updatable.AddReferenceToCollection(resourceLookup["Customer5"], "Logins", resourceLookup["Login7"]);
            updatable.SetReference(resourceLookup["Login7"], "Customer", resourceLookup["Customer5"]);
            updatable.AddReferenceToCollection(resourceLookup["Customer4"], "Logins", resourceLookup["Login8"]);
            updatable.SetReference(resourceLookup["Login8"], "Customer", resourceLookup["Customer4"]);
            updatable.AddReferenceToCollection(resourceLookup["Customer7"], "Logins", resourceLookup["Login9"]);
            updatable.SetReference(resourceLookup["Login9"], "Customer", resourceLookup["Customer7"]);
        }

        private static void PopulateLogin_LastLogin(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {
            updatable.SetReference(resourceLookup["Login0"], "LastLogin", resourceLookup["LastLogin0"]);
            updatable.SetReference(resourceLookup["LastLogin0"], "Login", resourceLookup["Login0"]);
            updatable.SetReference(resourceLookup["Login1"], "LastLogin", resourceLookup["LastLogin1"]);
            updatable.SetReference(resourceLookup["LastLogin1"], "Login", resourceLookup["Login1"]);
            updatable.SetReference(resourceLookup["Login3"], "LastLogin", resourceLookup["LastLogin3"]);
            updatable.SetReference(resourceLookup["LastLogin3"], "Login", resourceLookup["Login3"]);
            updatable.SetReference(resourceLookup["Login4"], "LastLogin", resourceLookup["LastLogin4"]);
            updatable.SetReference(resourceLookup["LastLogin4"], "Login", resourceLookup["Login4"]);
            updatable.SetReference(resourceLookup["Login5"], "LastLogin", resourceLookup["LastLogin5"]);
            updatable.SetReference(resourceLookup["LastLogin5"], "Login", resourceLookup["Login5"]);
            updatable.SetReference(resourceLookup["Login6"], "LastLogin", resourceLookup["LastLogin6"]);
            updatable.SetReference(resourceLookup["LastLogin6"], "Login", resourceLookup["Login6"]);
            updatable.SetReference(resourceLookup["Login7"], "LastLogin", resourceLookup["LastLogin7"]);
            updatable.SetReference(resourceLookup["LastLogin7"], "Login", resourceLookup["Login7"]);
            updatable.SetReference(resourceLookup["Login8"], "LastLogin", resourceLookup["LastLogin8"]);
            updatable.SetReference(resourceLookup["LastLogin8"], "Login", resourceLookup["Login8"]);
            updatable.SetReference(resourceLookup["Login9"], "LastLogin", resourceLookup["LastLogin9"]);
            updatable.SetReference(resourceLookup["LastLogin9"], "Login", resourceLookup["Login9"]);
        }

        private static void PopulateOrder_OrderLines(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {
            updatable.SetReference(resourceLookup["OrderLine0"], "Order", resourceLookup["Order1"]);
            updatable.SetReference(resourceLookup["OrderLine1"], "Order", resourceLookup["Order3"]);
            updatable.SetReference(resourceLookup["OrderLine3"], "Order", resourceLookup["Order3"]);
            updatable.SetReference(resourceLookup["OrderLine4"], "Order", resourceLookup["Order5"]);
            updatable.SetReference(resourceLookup["OrderLine5"], "Order", resourceLookup["Order5"]);
            updatable.SetReference(resourceLookup["OrderLine6"], "Order", resourceLookup["Order0"]);
            updatable.SetReference(resourceLookup["OrderLine7"], "Order", resourceLookup["Order3"]);
            updatable.SetReference(resourceLookup["OrderLine8"], "Order", resourceLookup["Order3"]);
            updatable.SetReference(resourceLookup["OrderLine9"], "Order", resourceLookup["Order6"]);
        }

        private static void PopulateProduct_OrderLines(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {
            updatable.SetReference(resourceLookup["OrderLine0"], "Product", resourceLookup["Product0"]);
            updatable.SetReference(resourceLookup["OrderLine1"], "Product", resourceLookup["Product0"]);
            updatable.SetReference(resourceLookup["OrderLine3"], "Product", resourceLookup["Product0"]);
            updatable.SetReference(resourceLookup["OrderLine4"], "Product", resourceLookup["Product1"]);
            updatable.SetReference(resourceLookup["OrderLine5"], "Product", resourceLookup["Product3"]);
            updatable.SetReference(resourceLookup["OrderLine6"], "Product", resourceLookup["Product3"]);
            updatable.SetReference(resourceLookup["OrderLine7"], "Product", resourceLookup["Product3"]);
            updatable.SetReference(resourceLookup["OrderLine8"], "Product", resourceLookup["Product6"]);
            updatable.SetReference(resourceLookup["OrderLine9"], "Product", resourceLookup["Product5"]);
        }

        private static void PopulateProducts_RelatedProducts(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {
            updatable.AddReferenceToCollection(resourceLookup["Product0"], "RelatedProducts", resourceLookup["Product0"]);
            updatable.AddReferenceToCollection(resourceLookup["Product1"], "RelatedProducts", resourceLookup["Product1"]);
            updatable.AddReferenceToCollection(resourceLookup["Product3"], "RelatedProducts", resourceLookup["Product3"]);
            updatable.AddReferenceToCollection(resourceLookup["Product3"], "RelatedProducts", resourceLookup["Product4"]);
            updatable.AddReferenceToCollection(resourceLookup["Product5"], "RelatedProducts", resourceLookup["Product5"]);
            updatable.AddReferenceToCollection(resourceLookup["Product6"], "RelatedProducts", resourceLookup["Product6"]);
            updatable.AddReferenceToCollection(resourceLookup["Product3"], "RelatedProducts", resourceLookup["Product7"]);
            updatable.AddReferenceToCollection(resourceLookup["Product5"], "RelatedProducts", resourceLookup["Product8"]);
            updatable.AddReferenceToCollection(resourceLookup["Product8"], "RelatedProducts", resourceLookup["Product9"]);
        }

        private static void PopulateProduct_ProductDetail(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {
            updatable.SetReference(resourceLookup["Product0"], "Detail", resourceLookup["ProductDetail1"]);
            updatable.SetReference(resourceLookup["ProductDetail1"], "Product", resourceLookup["Product0"]);
            updatable.SetReference(resourceLookup["Product1"], "Detail", resourceLookup["ProductDetail0"]);
            updatable.SetReference(resourceLookup["ProductDetail0"], "Product", resourceLookup["Product1"]);
            updatable.SetReference(resourceLookup["Product3"], "Detail", resourceLookup["ProductDetail3"]);
            updatable.SetReference(resourceLookup["ProductDetail3"], "Product", resourceLookup["Product3"]);
            updatable.SetReference(resourceLookup["Product4"], "Detail", resourceLookup["ProductDetail4"]);
            updatable.SetReference(resourceLookup["ProductDetail4"], "Product", resourceLookup["Product4"]);
            updatable.SetReference(resourceLookup["Product5"], "Detail", resourceLookup["ProductDetail5"]);
            updatable.SetReference(resourceLookup["ProductDetail5"], "Product", resourceLookup["Product5"]);
            updatable.SetReference(resourceLookup["Product6"], "Detail", resourceLookup["ProductDetail8"]);
            updatable.SetReference(resourceLookup["ProductDetail8"], "Product", resourceLookup["Product6"]);
            updatable.SetReference(resourceLookup["Product7"], "Detail", resourceLookup["ProductDetail7"]);
            updatable.SetReference(resourceLookup["ProductDetail7"], "Product", resourceLookup["Product7"]);
            updatable.SetReference(resourceLookup["Product8"], "Detail", resourceLookup["ProductDetail6"]);
            updatable.SetReference(resourceLookup["ProductDetail6"], "Product", resourceLookup["Product8"]);
            updatable.SetReference(resourceLookup["Product9"], "Detail", resourceLookup["ProductDetail9"]);
            updatable.SetReference(resourceLookup["ProductDetail9"], "Product", resourceLookup["Product9"]);
        }

        private static void PopulateProduct_ProductReview(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {
            updatable.AddReferenceToCollection(resourceLookup["Product0"], "Reviews", resourceLookup["ProductReview0"]);
            updatable.SetReference(resourceLookup["ProductReview0"], "Product", resourceLookup["Product0"]);
            updatable.AddReferenceToCollection(resourceLookup["Product0"], "Reviews", resourceLookup["ProductReview1"]);
            updatable.SetReference(resourceLookup["ProductReview1"], "Product", resourceLookup["Product0"]);
            updatable.AddReferenceToCollection(resourceLookup["Product0"], "Reviews", resourceLookup["ProductReview3"]);
            updatable.SetReference(resourceLookup["ProductReview3"], "Product", resourceLookup["Product0"]);
            updatable.AddReferenceToCollection(resourceLookup["Product0"], "Reviews", resourceLookup["ProductReview4"]);
            updatable.SetReference(resourceLookup["ProductReview4"], "Product", resourceLookup["Product0"]);
            updatable.AddReferenceToCollection(resourceLookup["Product1"], "Reviews", resourceLookup["ProductReview5"]);
            updatable.SetReference(resourceLookup["ProductReview5"], "Product", resourceLookup["Product1"]);
            updatable.AddReferenceToCollection(resourceLookup["Product0"], "Reviews", resourceLookup["ProductReview6"]);
            updatable.SetReference(resourceLookup["ProductReview6"], "Product", resourceLookup["Product0"]);
            updatable.AddReferenceToCollection(resourceLookup["Product3"], "Reviews", resourceLookup["ProductReview7"]);
            updatable.SetReference(resourceLookup["ProductReview7"], "Product", resourceLookup["Product3"]);
            updatable.AddReferenceToCollection(resourceLookup["Product3"], "Reviews", resourceLookup["ProductReview8"]);
            updatable.SetReference(resourceLookup["ProductReview8"], "Product", resourceLookup["Product3"]);
            updatable.AddReferenceToCollection(resourceLookup["Product9"], "Reviews", resourceLookup["ProductReview9"]);
            updatable.SetReference(resourceLookup["ProductReview9"], "Product", resourceLookup["Product9"]);
        }

        private static void PopulateProduct_ProductPhoto(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {
            updatable.AddReferenceToCollection(resourceLookup["Product0"], "Photos", resourceLookup["ProductPhoto0"]);
            updatable.AddReferenceToCollection(resourceLookup["Product0"], "Photos", resourceLookup["ProductPhoto1"]);
            updatable.AddReferenceToCollection(resourceLookup["Product0"], "Photos", resourceLookup["ProductPhoto3"]);
            updatable.AddReferenceToCollection(resourceLookup["Product0"], "Photos", resourceLookup["ProductPhoto4"]);
            updatable.AddReferenceToCollection(resourceLookup["Product0"], "Photos", resourceLookup["ProductPhoto5"]);
            updatable.AddReferenceToCollection(resourceLookup["Product1"], "Photos", resourceLookup["ProductPhoto6"]);
            updatable.AddReferenceToCollection(resourceLookup["Product3"], "Photos", resourceLookup["ProductPhoto7"]);
            updatable.AddReferenceToCollection(resourceLookup["Product3"], "Photos", resourceLookup["ProductPhoto8"]);
            updatable.AddReferenceToCollection(resourceLookup["Product6"], "Photos", resourceLookup["ProductPhoto9"]);
        }

        private static void PopulateHusband_Wife(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {
            updatable.SetReference(resourceLookup["Customer0"], "Wife", resourceLookup["Customer0"]);
            updatable.SetReference(resourceLookup["Customer0"], "Husband", resourceLookup["Customer0"]);
            updatable.SetReference(resourceLookup["Customer1"], "Wife", resourceLookup["Customer1"]);
            updatable.SetReference(resourceLookup["Customer1"], "Husband", resourceLookup["Customer1"]);
            updatable.SetReference(resourceLookup["Customer3"], "Wife", resourceLookup["Customer3"]);
            updatable.SetReference(resourceLookup["Customer3"], "Husband", resourceLookup["Customer3"]);
            updatable.SetReference(resourceLookup["Customer4"], "Wife", resourceLookup["Customer4"]);
            updatable.SetReference(resourceLookup["Customer4"], "Husband", resourceLookup["Customer4"]);
            updatable.SetReference(resourceLookup["Customer5"], "Wife", resourceLookup["Customer5"]);
            updatable.SetReference(resourceLookup["Customer5"], "Husband", resourceLookup["Customer5"]);
            updatable.SetReference(resourceLookup["Customer6"], "Wife", resourceLookup["Customer6"]);
            updatable.SetReference(resourceLookup["Customer6"], "Husband", resourceLookup["Customer6"]);
            updatable.SetReference(resourceLookup["Customer7"], "Wife", resourceLookup["Customer7"]);
            updatable.SetReference(resourceLookup["Customer7"], "Husband", resourceLookup["Customer7"]);
            updatable.SetReference(resourceLookup["Customer8"], "Wife", resourceLookup["Customer8"]);
            updatable.SetReference(resourceLookup["Customer8"], "Husband", resourceLookup["Customer8"]);
            updatable.SetReference(resourceLookup["Customer9"], "Wife", resourceLookup["Customer9"]);
            updatable.SetReference(resourceLookup["Customer9"], "Husband", resourceLookup["Customer9"]);
        }

        private static void PopulateLogin_RSAToken(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {
            updatable.SetReference(resourceLookup["RSAToken0"], "Login", resourceLookup["Login0"]);
            updatable.SetReference(resourceLookup["RSAToken1"], "Login", resourceLookup["Login1"]);
            updatable.SetReference(resourceLookup["RSAToken3"], "Login", resourceLookup["Login3"]);
            updatable.SetReference(resourceLookup["RSAToken4"], "Login", resourceLookup["Login5"]);
            updatable.SetReference(resourceLookup["RSAToken5"], "Login", resourceLookup["Login4"]);
            updatable.SetReference(resourceLookup["RSAToken6"], "Login", resourceLookup["Login6"]);
            updatable.SetReference(resourceLookup["RSAToken7"], "Login", resourceLookup["Login7"]);
            updatable.SetReference(resourceLookup["RSAToken8"], "Login", resourceLookup["Login8"]);
            updatable.SetReference(resourceLookup["RSAToken9"], "Login", resourceLookup["Login9"]);
        }

        private static void PopulateLogin_PageViews(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {
            updatable.SetReference(resourceLookup["PageView0"], "Login", resourceLookup["Login1"]);
            updatable.SetReference(resourceLookup["PageView1"], "Login", resourceLookup["Login3"]);
            updatable.SetReference(resourceLookup["PageView3"], "Login", resourceLookup["Login3"]);
            updatable.SetReference(resourceLookup["PageView4"], "Login", resourceLookup["Login4"]);
            updatable.SetReference(resourceLookup["PageView5"], "Login", resourceLookup["Login0"]);
            updatable.SetReference(resourceLookup["PageView6"], "Login", resourceLookup["Login8"]);
            updatable.SetReference(resourceLookup["PageView7"], "Login", resourceLookup["Login0"]);
            updatable.SetReference(resourceLookup["PageView8"], "Login", resourceLookup["Login8"]);
            updatable.SetReference(resourceLookup["PageView9"], "Login", resourceLookup["Login4"]);
        }

        private static void PopulateComputer_ComputerDetail(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {
            updatable.SetReference(resourceLookup["Computer0"], "ComputerDetail", resourceLookup["ComputerDetail0"]);
            updatable.SetReference(resourceLookup["ComputerDetail0"], "Computer", resourceLookup["Computer0"]);
            updatable.SetReference(resourceLookup["Computer1"], "ComputerDetail", resourceLookup["ComputerDetail1"]);
            updatable.SetReference(resourceLookup["ComputerDetail1"], "Computer", resourceLookup["Computer1"]);
            updatable.SetReference(resourceLookup["Computer3"], "ComputerDetail", resourceLookup["ComputerDetail3"]);
            updatable.SetReference(resourceLookup["ComputerDetail3"], "Computer", resourceLookup["Computer3"]);
            updatable.SetReference(resourceLookup["Computer4"], "ComputerDetail", resourceLookup["ComputerDetail4"]);
            updatable.SetReference(resourceLookup["ComputerDetail4"], "Computer", resourceLookup["Computer4"]);
            updatable.SetReference(resourceLookup["Computer5"], "ComputerDetail", resourceLookup["ComputerDetail5"]);
            updatable.SetReference(resourceLookup["ComputerDetail5"], "Computer", resourceLookup["Computer5"]);
            updatable.SetReference(resourceLookup["Computer6"], "ComputerDetail", resourceLookup["ComputerDetail6"]);
            updatable.SetReference(resourceLookup["ComputerDetail6"], "Computer", resourceLookup["Computer6"]);
            updatable.SetReference(resourceLookup["Computer7"], "ComputerDetail", resourceLookup["ComputerDetail7"]);
            updatable.SetReference(resourceLookup["ComputerDetail7"], "Computer", resourceLookup["Computer7"]);
            updatable.SetReference(resourceLookup["Computer8"], "ComputerDetail", resourceLookup["ComputerDetail8"]);
            updatable.SetReference(resourceLookup["ComputerDetail8"], "Computer", resourceLookup["Computer8"]);
            updatable.SetReference(resourceLookup["Computer9"], "ComputerDetail", resourceLookup["ComputerDetail9"]);
            updatable.SetReference(resourceLookup["ComputerDetail9"], "Computer", resourceLookup["Computer9"]);
        }

        private static void PopulateDriver_License(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {
            updatable.SetReference(resourceLookup["Driver0"], "License", resourceLookup["License0"]);
            updatable.SetReference(resourceLookup["License0"], "Driver", resourceLookup["Driver0"]);
            updatable.SetReference(resourceLookup["Driver1"], "License", resourceLookup["License1"]);
            updatable.SetReference(resourceLookup["License1"], "Driver", resourceLookup["Driver1"]);
            updatable.SetReference(resourceLookup["Driver4"], "License", resourceLookup["License3"]);
            updatable.SetReference(resourceLookup["License3"], "Driver", resourceLookup["Driver4"]);
            updatable.SetReference(resourceLookup["Driver3"], "License", resourceLookup["License4"]);
            updatable.SetReference(resourceLookup["License4"], "Driver", resourceLookup["Driver3"]);
            updatable.SetReference(resourceLookup["Driver5"], "License", resourceLookup["License5"]);
            updatable.SetReference(resourceLookup["License5"], "Driver", resourceLookup["Driver5"]);
            updatable.SetReference(resourceLookup["Driver6"], "License", resourceLookup["License6"]);
            updatable.SetReference(resourceLookup["License6"], "Driver", resourceLookup["Driver6"]);
            updatable.SetReference(resourceLookup["Driver7"], "License", resourceLookup["License7"]);
            updatable.SetReference(resourceLookup["License7"], "Driver", resourceLookup["Driver7"]);
            updatable.SetReference(resourceLookup["Driver8"], "License", resourceLookup["License8"]);
            updatable.SetReference(resourceLookup["License8"], "Driver", resourceLookup["Driver8"]);
            updatable.SetReference(resourceLookup["Driver9"], "License", resourceLookup["License9"]);
            updatable.SetReference(resourceLookup["License9"], "Driver", resourceLookup["Driver9"]);
        }

        private static void PopulatePerson_PersonMetadata(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {
            updatable.AddReferenceToCollection(resourceLookup["Person0"], "PersonMetadata", resourceLookup["PersonMetadata0"]);
            updatable.SetReference(resourceLookup["PersonMetadata0"], "Person", resourceLookup["Person0"]);
            updatable.AddReferenceToCollection(resourceLookup["Person0"], "PersonMetadata", resourceLookup["PersonMetadata1"]);
            updatable.SetReference(resourceLookup["PersonMetadata1"], "Person", resourceLookup["Person0"]);
            updatable.AddReferenceToCollection(resourceLookup["Person0"], "PersonMetadata", resourceLookup["PersonMetadata3"]);
            updatable.SetReference(resourceLookup["PersonMetadata3"], "Person", resourceLookup["Person0"]);
            updatable.AddReferenceToCollection(resourceLookup["Person1"], "PersonMetadata", resourceLookup["PersonMetadata4"]);
            updatable.SetReference(resourceLookup["PersonMetadata4"], "Person", resourceLookup["Person1"]);
            updatable.AddReferenceToCollection(resourceLookup["Person3"], "PersonMetadata", resourceLookup["PersonMetadata5"]);
            updatable.SetReference(resourceLookup["PersonMetadata5"], "Person", resourceLookup["Person3"]);
            updatable.AddReferenceToCollection(resourceLookup["Person3"], "PersonMetadata", resourceLookup["PersonMetadata6"]);
            updatable.SetReference(resourceLookup["PersonMetadata6"], "Person", resourceLookup["Person3"]);
            updatable.AddReferenceToCollection(resourceLookup["Person5"], "PersonMetadata", resourceLookup["PersonMetadata7"]);
            updatable.SetReference(resourceLookup["PersonMetadata7"], "Person", resourceLookup["Person5"]);
            updatable.AddReferenceToCollection(resourceLookup["Person6"], "PersonMetadata", resourceLookup["PersonMetadata8"]);
            updatable.SetReference(resourceLookup["PersonMetadata8"], "Person", resourceLookup["Person6"]);
            updatable.AddReferenceToCollection(resourceLookup["Person6"], "PersonMetadata", resourceLookup["PersonMetadata9"]);
            updatable.SetReference(resourceLookup["PersonMetadata9"], "Person", resourceLookup["Person6"]);
        }

        private static void PopulateEmployee_Manager(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {
            updatable.SetReference(resourceLookup["Person0"], "Manager", resourceLookup["Person0"]);
            updatable.SetReference(resourceLookup["Person1"], "Manager", resourceLookup["Person1"]);
            updatable.SetReference(resourceLookup["Person3"], "Manager", resourceLookup["Person3"]);
            updatable.SetReference(resourceLookup["Person4"], "Manager", resourceLookup["Person3"]);
            updatable.SetReference(resourceLookup["Person7"], "Manager", resourceLookup["Person4"]);
            updatable.SetReference(resourceLookup["Person10"], "Manager", resourceLookup["Person4"]);
        }

        private static void PopulateSpecialEmployee_Car(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup)
        {
            updatable.SetReference(resourceLookup["Person0"], "Car", resourceLookup["Car1"]);
            updatable.SetReference(resourceLookup["Person1"], "Car", resourceLookup["Car3"]);
            updatable.SetReference(resourceLookup["Person3"], "Car", resourceLookup["Car3"]);
        }
        
        #endregion
    }
}
