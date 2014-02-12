using System;
using ODataDemoService;

namespace ODataLib101.ClientHttpMessages.Tests
{
    /// <summary>
    /// Helper class to start the test demo service.
    /// </summary>
    public static class TestDemoService
    {
        /// <summary>
        /// The service host for the demo service.
        /// </summary>
        private static ODataDemoServiceHost serviceHost;

        /// <summary>
        /// The demo service URI.
        /// </summary>
        public static Uri ServiceBaseUri
        {
            get
            {
                if (serviceHost == null)
                {
                    // The service host has a finalizer, so the service will shutdown correctly when the tests are done running.
                    serviceHost = new ODataDemoServiceHost("ClientHttpMessages.Tests");
                }

                return serviceHost.ServiceBaseUri;
            }
        }
    }
}
