namespace WcfDataServices101.CustomizedEntityLinks
{
    using System;
    using System.Collections.Generic;
    using System.Data.Services;
    using System.Data.Services.Common;
    using System.Linq;
    using System.ServiceModel;
    using Microsoft.Data.OData;

    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class CustomizedEntityLinksService : DataService<SimpleDataSource>
    {
        public static void InitializeService(DataServiceConfiguration config)
        {
            // This method is called only once to initialize service-wide policies. None of the code here is specific to the sample.
            config.SetEntitySetAccessRule("*", EntitySetRights.AllRead);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
            config.UseVerboseErrors = true;
        }

        /// <summary>
        /// Constructor for the data service.
        /// </summary>
        public CustomizedEntityLinksService()
        {
            // This is the primary extension point for customizing what the WCF Data Services server will write.
            // I am providing a customized writer which wraps the writer constructed by the runtime.
            CreateODataWriter = odataWriter => new CustomizedWriter(odataWriter);
        }

        /// <summary>
        /// This is the core of the sample.
        /// This class will override how the service writes entries.
        /// </summary>
        private class CustomizedWriter : DataServiceODataWriter
        {
            public CustomizedWriter(ODataWriter odataWriter)
                : base(odataWriter)
            {
            }

            /// <summary>
            /// The method called when an entry is about to be written. We will customize the entry, then let the runtime handle the rest.
            /// </summary>
            /// <param name="args"></param>
            public override void WriteStart(DataServiceODataWriterEntryArgs args)
            {
                // look for the special customized type (see below).
                var customized = args.Instance as CustomizedSimpleEntityType;
                if (customized != null)
                {
                    // copy the customized values from the instance over to the entry.
                    // At this point, you could generate these values programatically, change other values, or even hide properties!
                    args.Entry.Id = customized.Identity;
                    args.Entry.EditLink = customized.EditLink;
                }

                // call the base writer to actually write the start of the entry.
                base.WriteStart(args);
            }
        }
    }

    /// <summary>
    /// An extremely simple data source which stores entities in memory. 
    /// This is simply plumbing code to stand up a reflection-based data service, and is not specific to the sample.
    /// </summary>
    public class SimpleDataSource
    {
        public IQueryable<SimpleEntityType> Entities
        {
            get
            {
                return new List<SimpleEntityType>
                           {
                               new SimpleEntityType { Id = 1 },
                               new CustomizedSimpleEntityType { Id = 2 },
                           }.AsQueryable();
            }
        }
    }

    /// <summary>
    /// A 'normal' entity to demonstrate default behavior.
    /// </summary>
    [DataServiceKey("Id")]
    public class SimpleEntityType
    {
        public int Id { get; set; }
    }

    /// <summary>
    /// The entity type that the code above will look for.
    /// Note: The IgnoreProperties attribute is specific to the reflection-based WCF Data Services provider. 
    /// It is used here because we don't want the provider to treat them as normal properties.
    /// </summary>
    [DataServiceKey("Id")]
    [IgnoreProperties("Identity", "EditLink")]
    public class CustomizedSimpleEntityType : SimpleEntityType
    {
        private Guid _identity = Guid.NewGuid();

        /// <summary>
        /// Gets the entity's customized identity.
        /// </summary>
        public string Identity
        {
            get
            {
                // I'm using a GUID to demonstrate that this need not be a URI, you are welcome to use whatever you want here.
                return _identity.ToString();
            }
        }

        /// <summary>
        /// Gets the entity's customized edit-link.
        /// </summary>
        public Uri EditLink
        {
            get
            {
                // I made up this URI, you are welcome to base this on whatever you need.
                return new Uri("http://someOtherService.svc/Entities(" + this.Id + ")", UriKind.Absolute);
            }
        }
    }
}
