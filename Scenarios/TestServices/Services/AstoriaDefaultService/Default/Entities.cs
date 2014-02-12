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
    using System.Data.Services;
    using System.Data.Services.Common;
    using System.Spatial;

    [DataServiceKey("Id")]
    public partial class AllSpatialTypes
    {

        public int Id { get; set; }
        public System.Spatial.Geography Geog { get; set; }
        public System.Spatial.GeographyPoint GeogPoint { get; set; }
        public System.Spatial.GeographyLineString GeogLine { get; set; }
        public System.Spatial.GeographyPolygon GeogPolygon { get; set; }
        public System.Spatial.GeographyCollection GeogCollection { get; set; }
        public System.Spatial.GeographyMultiPoint GeogMultiPoint { get; set; }
        public System.Spatial.GeographyMultiLineString GeogMultiLine { get; set; }
        public System.Spatial.GeographyMultiPolygon GeogMultiPolygon { get; set; }
        public System.Spatial.Geometry Geom { get; set; }
        public System.Spatial.GeometryPoint GeomPoint { get; set; }
        public System.Spatial.GeometryLineString GeomLine { get; set; }
        public System.Spatial.GeometryPolygon GeomPolygon { get; set; }
        public System.Spatial.GeometryCollection GeomCollection { get; set; }
        public System.Spatial.GeometryMultiPoint GeomMultiPoint { get; set; }
        public System.Spatial.GeometryMultiLineString GeomMultiLine { get; set; }
        public System.Spatial.GeometryMultiPolygon GeomMultiPolygon { get; set; }

        public AllSpatialTypes()
        {
        }
    }

    [DataServiceKey("Id")]
    public abstract partial class AllSpatialCollectionTypes
    {

        public int Id { get; set; }

        public AllSpatialCollectionTypes()
        {
        }
    }

    public partial class AllSpatialCollectionTypes_Simple : AllSpatialCollectionTypes
    {

        public System.Collections.Generic.List<System.Spatial.GeographyPoint> ManyGeogPoint { get; set; }
        public System.Collections.Generic.List<System.Spatial.GeographyLineString> ManyGeogLine { get; set; }
        public System.Collections.Generic.List<System.Spatial.GeographyPolygon> ManyGeogPolygon { get; set; }
        public System.Collections.Generic.List<System.Spatial.GeometryPoint> ManyGeomPoint { get; set; }
        public System.Collections.Generic.List<System.Spatial.GeometryLineString> ManyGeomLine { get; set; }
        public System.Collections.Generic.List<System.Spatial.GeometryPolygon> ManyGeomPolygon { get; set; }

        public AllSpatialCollectionTypes_Simple()
        {
            this.ManyGeogPoint = new System.Collections.Generic.List<System.Spatial.GeographyPoint>();
            this.ManyGeogLine = new System.Collections.Generic.List<System.Spatial.GeographyLineString>();
            this.ManyGeogPolygon = new System.Collections.Generic.List<System.Spatial.GeographyPolygon>();
            this.ManyGeomPoint = new System.Collections.Generic.List<System.Spatial.GeometryPoint>();
            this.ManyGeomLine = new System.Collections.Generic.List<System.Spatial.GeometryLineString>();
            this.ManyGeomPolygon = new System.Collections.Generic.List<System.Spatial.GeometryPolygon>();
        }
    }

    public partial class Aliases
    {
        public System.Collections.Generic.List<string> AlternativeNames { get; set; }

        public Aliases()
        {
            this.AlternativeNames = new System.Collections.Generic.List<string>();
        }
    }

    public partial class Phone
    {

        public string PhoneNumber { get; set; }
        public string Extension { get; set; }

        public Phone()
        {
        }
    }

    public partial class ContactDetails
    {

        public System.Collections.Generic.List<string> EmailBag { get; set; }
        public System.Collections.Generic.List<string> AlternativeNames { get; set; }
        public Aliases ContactAlias { get; set; }
        public Phone HomePhone { get; set; }
        public Phone WorkPhone { get; set; }
        public System.Collections.Generic.List<Phone> MobilePhoneBag { get; set; }

        public ContactDetails()
        {
            this.EmailBag = new System.Collections.Generic.List<string>();
            this.AlternativeNames = new System.Collections.Generic.List<string>();
            this.MobilePhoneBag = new System.Collections.Generic.List<Phone>();
        }
    }

    public partial class ComplexToCategory
    {

        public string Term { get; set; }
        public string Scheme { get; set; }
        public string Label { get; set; }

        public ComplexToCategory()
        {
        }
    }

    public partial class Dimensions
    {
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Depth { get; set; }

        public Dimensions()
        {
        }
    }

    public partial class AuditInfo
    {

        public System.DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public ConcurrencyInfo Concurrency { get; set; }

        public AuditInfo()
        {
        }
    }

    public partial class ConcurrencyInfo
    {

        public string Token { get; set; }
        public Nullable<System.DateTime> QueriedDateTime { get; set; }

        public ConcurrencyInfo()
        {
        }
    }

    [DataServiceKey("CustomerId")]
    [EntityPropertyMapping("Name", SyndicationItemProperty.Summary, SyndicationTextContentKind.Plaintext, false)]
    [NamedStream("Video")]
    [NamedStream("Thumbnail")]
    public partial class Customer
    {

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public ContactDetails PrimaryContactInfo { get; set; }
        public System.Collections.Generic.List<ContactDetails> BackupContactInfo { get; set; }
        public AuditInfo Auditing { get; set; }
        public System.Collections.Generic.List<Order> Orders { get; set; }
        public System.Collections.Generic.List<Login> Logins { get; set; }
        public Customer Husband { get; set; }
        public Customer Wife { get; set; }
        public CustomerInfo Info { get; set; }

        public Customer()
        {
            this.BackupContactInfo = new System.Collections.Generic.List<ContactDetails>();
            this.Orders = new System.Collections.Generic.List<Order>();
            this.Logins = new System.Collections.Generic.List<Login>();
        }
    }

    [DataServiceKey("Username")]
    public partial class Login
    {

        public string Username { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public LastLogin LastLogin { get; set; }
        public System.Collections.Generic.List<Message> SentMessages { get; set; }
        public System.Collections.Generic.List<Message> ReceivedMessages { get; set; }
        public System.Collections.Generic.List<Order> Orders { get; set; }

        public Login()
        {
            this.SentMessages = new System.Collections.Generic.List<Message>();
            this.ReceivedMessages = new System.Collections.Generic.List<Message>();
            this.Orders = new System.Collections.Generic.List<Order>();
        }
    }

    [DataServiceKey("Serial")]
    public partial class RSAToken
    {

        public string Serial { get; set; }
        public System.DateTime Issued { get; set; }
        public Login Login { get; set; }

        public RSAToken()
        {
        }
    }

    [DataServiceKey("PageViewId")]
    public partial class PageView
    {

        public int PageViewId { get; set; }
        public string Username { get; set; }
        public System.DateTimeOffset Viewed { get; set; }
        public System.TimeSpan TimeSpentOnPage { get; set; }
        public string PageUrl { get; set; }
        public Login Login { get; set; }

        public PageView()
        {
        }
    }

    [ETag("ConcurrencyToken")]
    public partial class ProductPageView : PageView
    {

        public int ProductId { get; set; }
        public string ConcurrencyToken { get; set; }

        public ProductPageView()
        {
        }
    }

    [DataServiceKey("Username")]
    public partial class LastLogin
    {

        public string Username { get; set; }
        public System.DateTime LoggedIn { get; set; }
        public Nullable<System.DateTime> LoggedOut { get; set; }
        public System.TimeSpan Duration { get; set; }
        public Login Login { get; set; }

        public LastLogin()
        {
        }
    }

    [DataServiceKey("MessageId", "FromUsername")]
    [EntityPropertyMapping("Subject", SyndicationItemProperty.Title, SyndicationTextContentKind.Plaintext, true)]
    [EntityPropertyMapping("Sent", SyndicationItemProperty.Published, SyndicationTextContentKind.Plaintext, true)]
    public partial class Message
    {

        public int MessageId { get; set; }
        public string FromUsername { get; set; }
        public string ToUsername { get; set; }
        public System.DateTimeOffset Sent { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsRead { get; set; }
        public Login Sender { get; set; }
        public Login Recipient { get; set; }
        public System.Collections.Generic.List<Microsoft.Test.OData.Services.AstoriaDefaultService.MessageAttachment> Attachments { get; set; }

        public Message()
        {
            this.Attachments = new System.Collections.Generic.List<Microsoft.Test.OData.Services.AstoriaDefaultService.MessageAttachment>();
        }
    }

    [DataServiceKey("AttachmentId")]
    public partial class MessageAttachment
    {

        public System.Guid AttachmentId { get; set; }
        public byte[] Attachment { get; set; }

        public MessageAttachment()
        {
        }
    }

    [DataServiceKey("OrderId")]
    public partial class Order
    {

        public int OrderId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public ConcurrencyInfo Concurrency { get; set; }
        public Customer Customer { get; set; }
        public Login Login { get; set; }

        public Order()
        {
        }
    }

    [DataServiceKey("OrderId", "ProductId")]
    [NamedStream("OrderLineStream")]
    [ETag("ConcurrencyToken")]
    public partial class OrderLine
    {

        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string ConcurrencyToken { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }

        public OrderLine()
        {
        }
    }

    public partial class BackOrderLine : OrderLine
    {

        public BackOrderLine()
        {
        }
    }

    public partial class BackOrderLine2 : BackOrderLine
    {

        public BackOrderLine2()
        {
        }
    }

    [DataServiceKey("ProductId")]
    [NamedStream("Picture")]
    [ETag("BaseConcurrency")]
    public partial class Product
    {

        public int ProductId { get; set; }
        public string Description { get; set; }
        public Dimensions Dimensions { get; set; }
        public string BaseConcurrency { get; set; }
        public ConcurrencyInfo ComplexConcurrency { get; set; }
        public AuditInfo NestedComplexConcurrency { get; set; }
        public System.Collections.Generic.List<Product> RelatedProducts { get; set; }
        public ProductDetail Detail { get; set; }
        public System.Collections.Generic.List<ProductReview> Reviews { get; set; }
        public System.Collections.Generic.List<ProductPhoto> Photos { get; set; }

        public Product()
        {
            this.RelatedProducts = new System.Collections.Generic.List<Product>();
            this.Reviews = new System.Collections.Generic.List<ProductReview>();
            this.Photos = new System.Collections.Generic.List<ProductPhoto>();
        }
    }

    [ETag("ChildConcurrencyToken")]
    public partial class DiscontinuedProduct : Product
    {

        public System.DateTime Discontinued { get; set; }
        public Nullable<int> ReplacementProductId { get; set; }
        public Phone DiscontinuedPhone { get; set; }
        public string ChildConcurrencyToken { get; set; }

        public DiscontinuedProduct()
        {
        }
    }

    [DataServiceKey("ProductId")]
    public partial class ProductDetail
    {

        public int ProductId { get; set; }
        public string Details { get; set; }
        public Product Product { get; set; }

        public ProductDetail()
        {
        }
    }

    [DataServiceKey("ProductId", "ReviewId", "RevisionId")]
    public partial class ProductReview
    {

        public int ProductId { get; set; }
        public int ReviewId { get; set; }
        public string RevisionId { get; set; }
        public string Review { get; set; }
        public Product Product { get; set; }

        public ProductReview()
        {
        }
    }

    [DataServiceKey("ProductId", "PhotoId")]
    public partial class ProductPhoto
    {

        public int ProductId { get; set; }
        public int PhotoId { get; set; }
        public byte[] Photo { get; set; }

        public ProductPhoto()
        {
        }
    }

    [DataServiceKey("CustomerInfoId")]
    [HasStream()]
    public partial class CustomerInfo
    {

        public int CustomerInfoId { get; set; }
        public string Information { get; set; }

        public CustomerInfo()
        {
        }
    }

    [DataServiceKey("ComputerId")]
    public partial class Computer
    {

        public int ComputerId { get; set; }
        public string Name { get; set; }
        public ComputerDetail ComputerDetail { get; set; }

        public Computer()
        {
        }
    }

    [DataServiceKey("ComputerDetailId")]
    [EntityPropertyMapping("Manufacturer", SyndicationItemProperty.AuthorEmail, SyndicationTextContentKind.Plaintext, true)]
    [EntityPropertyMapping("Model", SyndicationItemProperty.AuthorUri, SyndicationTextContentKind.Plaintext, true)]
    public partial class ComputerDetail
    {

        public int ComputerDetailId { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Serial { get; set; }
        public System.Collections.Generic.List<string> SpecificationsBag { get; set; }
        public System.DateTime PurchaseDate { get; set; }
        public Dimensions Dimensions { get; set; }
        public Computer Computer { get; set; }

        public ComputerDetail()
        {
            this.SpecificationsBag = new System.Collections.Generic.List<string>();
        }
    }

    [DataServiceKey("Name")]
    public partial class Driver
    {

        public string Name { get; set; }
        public System.DateTime BirthDate { get; set; }
        public License License { get; set; }

        public Driver()
        {
        }
    }

    [DataServiceKey("Name")]
    [EntityPropertyMapping("LicenseClass", SyndicationItemProperty.ContributorEmail, SyndicationTextContentKind.Plaintext, false)]
    [EntityPropertyMapping("Restrictions", SyndicationItemProperty.ContributorUri, SyndicationTextContentKind.Plaintext, false)]
    public partial class License
    {

        public string Name { get; set; }
        public string LicenseNumber { get; set; }
        public string LicenseClass { get; set; }
        public string Restrictions { get; set; }
        public System.DateTime ExpirationDate { get; set; }
        public Driver Driver { get; set; }

        public License()
        {
        }
    }

    [DataServiceKey("Id")]
    [EntityPropertyMapping("ComplexPhone/PhoneNumber", SyndicationItemProperty.Rights, SyndicationTextContentKind.Plaintext, true)]
    [EntityPropertyMapping("ComplexContactDetails/WorkPhone/Extension", SyndicationItemProperty.Summary, SyndicationTextContentKind.Plaintext, true)]
    public partial class MappedEntityType
    {

        public int Id { get; set; }
        public string Href { get; set; }
        public string Title { get; set; }
        public string HrefLang { get; set; }
        public string Type { get; set; }
        public int Length { get; set; }
        public System.Collections.Generic.List<string> BagOfPrimitiveToLinks { get; set; }
        public byte[] Logo { get; set; }
        public System.Collections.Generic.List<decimal> BagOfDecimals { get; set; }
        public System.Collections.Generic.List<double> BagOfDoubles { get; set; }
        public System.Collections.Generic.List<float> BagOfSingles { get; set; }
        public System.Collections.Generic.List<byte> BagOfBytes { get; set; }
        public System.Collections.Generic.List<short> BagOfInt16s { get; set; }
        public System.Collections.Generic.List<int> BagOfInt32s { get; set; }
        public System.Collections.Generic.List<long> BagOfInt64s { get; set; }
        public System.Collections.Generic.List<System.Guid> BagOfGuids { get; set; }
        public System.Collections.Generic.List<System.DateTime> BagOfDateTime { get; set; }
        public System.Collections.Generic.List<ComplexToCategory> BagOfComplexToCategories { get; set; }
        public Phone ComplexPhone { get; set; }
        public ContactDetails ComplexContactDetails { get; set; }

        public MappedEntityType()
        {
            this.BagOfPrimitiveToLinks = new System.Collections.Generic.List<string>();
            this.BagOfDecimals = new System.Collections.Generic.List<decimal>();
            this.BagOfDoubles = new System.Collections.Generic.List<double>();
            this.BagOfSingles = new System.Collections.Generic.List<float>();
            this.BagOfBytes = new System.Collections.Generic.List<byte>();
            this.BagOfInt16s = new System.Collections.Generic.List<short>();
            this.BagOfInt32s = new System.Collections.Generic.List<int>();
            this.BagOfInt64s = new System.Collections.Generic.List<long>();
            this.BagOfGuids = new System.Collections.Generic.List<System.Guid>();
            this.BagOfDateTime = new System.Collections.Generic.List<System.DateTime>();
            this.BagOfComplexToCategories = new System.Collections.Generic.List<ComplexToCategory>();
        }
    }

    [DataServiceKey("VIN")]
    [NamedStream("Photo")]
    [NamedStream("Video")]
    [HasStream()]
    public partial class Car
    {

        public int VIN { get; set; }
        public string Description { get; set; }

        public Car()
        {
        }
    }

    [DataServiceKey("PersonId")]
    public partial class Person
    {

        public int PersonId { get; set; }
        public string Name { get; set; }
        public System.Collections.Generic.List<PersonMetadata> PersonMetadata { get; set; }

        public Person()
        {
            this.PersonMetadata = new System.Collections.Generic.List<PersonMetadata>();
        }
    }

    public partial class Contractor : Person
    {

        public int ContratorCompanyId { get; set; }
        public int BillingRate { get; set; }
        public int TeamContactPersonId { get; set; }
        public string JobDescription { get; set; }

        public Contractor()
        {
        }
    }

    public partial class Employee : Person
    {

        public int ManagersPersonId { get; set; }
        public int Salary { get; set; }
        public string Title { get; set; }
        public Employee Manager { get; set; }

        public Employee()
        {
        }
    }

    public partial class SpecialEmployee : Employee
    {

        public int CarsVIN { get; set; }
        public int Bonus { get; set; }
        public bool IsFullyVested { get; set; }
        public Car Car { get; set; }

        public SpecialEmployee()
        {
        }
    }

    [DataServiceKey("PersonMetadataId")]
    public partial class PersonMetadata
    {

        public int PersonMetadataId { get; set; }
        public int PersonId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
        public Person Person { get; set; }

        public PersonMetadata()
        {
        }
    }

    public class ComplexWithAllPrimitiveTypes
    {
        public Byte[] Binary { get; set; }
        public Boolean Boolean { get; set; }
        public Byte Byte { get; set; }
        public DateTime DateTime { get; set; }
        public Decimal Decimal { get; set; }
        public Double Double { get; set; }
        public Int16 Int16 { get; set; }
        public Int32 Int32 { get; set; }
        public Int64 Int64 { get; set; }
        public SByte SByte { get; set; }
        public String String { get; set; }
        public Single Single { get; set; }
        public GeographyPoint GeographyPoint { get; set; }
        public GeometryPoint GeometryPoint { get; set; }
    }
}
