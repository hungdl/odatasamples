//------------------------------------------------------------------------------
// <copyright file="WebDataService.svc.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System.Data.Entity;
using System.Data.Services;
using System.Data.Services.Common;
using System.ServiceModel;

namespace WcfDataServices101.UsingTheNotMappedAttribute
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class FileService : DataService<FileContext>
    {
        static FileService()
        {
            Database.SetInitializer(new FileContextInitializer());
        }

        // The service will not make it to this call if the EF model has an Enum property.
        // without a [NotMapped] attribute. See AccessControlEntry.cs.
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.UseVerboseErrors = true;
            config.SetEntitySetAccessRule("*", EntitySetRights.AllRead);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
        }
    }
}