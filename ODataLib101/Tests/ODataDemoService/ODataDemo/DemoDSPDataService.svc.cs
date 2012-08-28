//*********************************************************
//
//    Copyright (c) Microsoft. All rights reserved.
//    This code is licensed under the Microsoft Public License.
//    THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
//    ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
//    IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
//    PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************

namespace ODataDemo
{
    using System;
    using System.Collections.Generic;
    using System.Data.Services;
    using System.Data.Services.Common;
    using System.Data.Services.Providers;
    using DataServiceProvider;

    public class DemoDSPDataService : DSPDataService<DSPContext>
    {
        protected override DSPContext CreateDataSource()
        {
            DSPContext context = new DSPContext();

            ResourceSet productsSet, categoriesSet;
            this.Metadata.TryResolveResourceSet("Products", out productsSet);
            this.Metadata.TryResolveResourceSet("Categories", out categoriesSet);
            IList<DSPResource> products = context.GetResourceSetEntities(productsSet.Name);
            IList<DSPResource> categories = context.GetResourceSetEntities(categoriesSet.Name);

            var categoryFood = new DSPResource(categoriesSet.ResourceType);
            categoryFood.SetValue("ID", 0);
            categoryFood.SetValue("Name", "Food");
            categoryFood.SetValue("Products", new List<DSPResource>());
            categories.Add(categoryFood);

            var categoryBeverages = new DSPResource(categoriesSet.ResourceType);
            categoryBeverages.SetValue("ID", 1);
            categoryBeverages.SetValue("Name", "Beverages");
            categoryBeverages.SetValue("Products", new List<DSPResource>());
            categories.Add(categoryBeverages);

            var categoryElectronics = new DSPResource(categoriesSet.ResourceType);
            categoryElectronics.SetValue("ID", 2);
            categoryElectronics.SetValue("Name", "Electronics");
            categoryElectronics.SetValue("Products", new List<DSPResource>());
            categories.Add(categoryElectronics);

            var productBread = new DSPResource(productsSet.ResourceType);
            productBread.SetValue("ID", 0);
            productBread.SetValue("Name", "Bread");
            productBread.SetValue("Description", "Whole grain bread");
            productBread.SetValue("ReleaseDate", new DateTime(1992, 1, 1));
            productBread.SetValue("DiscontinueDate", null);
            productBread.SetValue("Rating", 4);
            productBread.SetValue("Category", categoryFood);
            products.Add(productBread);

            var productMilk = new DSPResource(productsSet.ResourceType);
            productMilk.SetValue("ID", 1);
            productMilk.SetValue("Name", "Milk");
            productMilk.SetValue("Description", "Low fat milk");
            productMilk.SetValue("ReleaseDate", new DateTime(1995, 10, 21));
            productMilk.SetValue("DiscontinueDate", null);
            productMilk.SetValue("Rating", 3);
            productMilk.SetValue("Category", categoryBeverages);
            products.Add(productMilk);

            var productWine = new DSPResource(productsSet.ResourceType);
            productWine.SetValue("ID", 2);
            productWine.SetValue("Name", "Wine");
            productWine.SetValue("Description", "Red wine, year 2003");
            productWine.SetValue("ReleaseDate", new DateTime(2003, 11, 24));
            productWine.SetValue("DiscontinueDate", new DateTime(2008, 3, 1));
            productWine.SetValue("Rating", 5);
            productWine.SetValue("Category", categoryBeverages);
            products.Add(productWine);

            ((List<DSPResource>)categoryFood.GetValue("Products")).Add(productBread);
            ((List<DSPResource>)categoryBeverages.GetValue("Products")).Add(productMilk);
            ((List<DSPResource>)categoryBeverages.GetValue("Products")).Add(productWine);

            return context;
        }

        protected override DSPMetadata CreateDSPMetadata()
        {
            DSPMetadata metadata = new DSPMetadata("DemoService", "DataServiceProviderDemo");
            
            ResourceType product = metadata.AddEntityType("Product");
            metadata.AddKeyProperty(product, "ID", typeof(int));
            metadata.AddPrimitiveProperty(product, "Name", typeof(string));
            metadata.AddPrimitiveProperty(product, "Description", typeof(string));
            metadata.AddPrimitiveProperty(product, "ReleaseDate", typeof(DateTime));
            metadata.AddPrimitiveProperty(product, "DiscontinueDate", typeof(DateTime?));
            metadata.AddPrimitiveProperty(product, "Rating", typeof(int));

            ResourceSet products = metadata.AddResourceSet("Products", product);

            ResourceType category = metadata.AddEntityType("Category");
            metadata.AddKeyProperty(category, "ID", typeof(int));
            metadata.AddPrimitiveProperty(category, "Name", typeof(string));

            ResourceSet categories = metadata.AddResourceSet("Categories", category);

            // Add reference properties between category and product
            metadata.AddResourceReferenceProperty(product, "Category", categories);
            metadata.AddResourceSetReferenceProperty(category, "Products", products);

            return metadata;
        }

        public static void InitializeService(DataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule("*", EntitySetRights.All);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
            config.DataServiceBehavior.AcceptProjectionRequests = true;
            config.UseVerboseErrors = true;
        }
    }
}
