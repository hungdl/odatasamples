using System;
using Microsoft.Data.Edm;
using Microsoft.Data.OData;

namespace ODataLib101.ClientHttpMessages.Tests
{
    /// <summary>
    /// Helper methods for writing tests.
    /// </summary>
    public static class TestUtils
    {
        /// <summary>
        /// Retrieves a model for the specified service URL.
        /// </summary>
        /// <param name="serviceUrl">The URL of the service to get the model for.</param>
        /// <returns>The model of the service.</returns>
        public static IEdmModel GetServiceModel(Uri serviceUrl)
        {
            using (ODataMessageReader messageReader = new ODataMessageReader(
                (new ClientHttpRequestMessage(new Uri(serviceUrl, "$metadata")))
                .GetResponse()))
            {
                return messageReader.ReadMetadataDocument();
            }
        }
    }
}