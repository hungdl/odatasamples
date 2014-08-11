//------------------------------------------------------------------------------
// <copyright file="WebDataService.svc.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System.Data.Services;
using System.Data.Services.Common;
using System.Data.Services.Providers;

namespace CodeFirstSample
{
    public class CodeFirstSampleService : EntityFrameworkDataService<BlogContext>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule("*", EntitySetRights.AllRead);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
            AddDataToBlogContext(new BlogContext());
        }

        private static void AddDataToBlogContext(BlogContext dataSource)
        {
            var b1 = new Blog() { BlogId = 1, BlogName = "SampleBlog" };
            dataSource.Blogs.Add(b1);
            dataSource.Posts.Add(new Post()
            {
                Blog = b1,
                BlogId = b1.BlogId,
                PostId = 1,
                PostName = "Using EntityFrameworkProvider",
                Content = new PostContent()
                    {
                        Title = "Using EntityFrameworkProvider",
                        SubTitle = "First try",
                        Body = "Using EntityFrameworkProvider in WCF Data Service 5.6.2"
                    }
            });
            dataSource.SaveChanges();
        }
    }
}
