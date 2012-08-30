using System;
using System.Diagnostics;
using System.ServiceModel.Web;

namespace ODataDemoService
{
    /// <summary>
    /// Hosts the demo service in a in-proc web service host.
    /// </summary>
    public class ODataDemoServiceHost : IDisposable
    {
        /// <summary>
        /// The web service host used for the hosting.
        /// </summary>
        private readonly WebServiceHost serviceHost;

        /// <summary>
        /// The base URI of the service.
        /// </summary>
        private readonly Uri serviceBaseUri;

        /// <summary>
        /// Constructor - starts the service.
        /// </summary>
        /// <param name="serviceName">Name of the service to start.
        /// This is used to differentiate potentially multiple services hosted by the same process.</param>
        public ODataDemoServiceHost(string serviceName)
        {
            Uri serviceUri = new Uri(string.Format("http://localhost:80/Temporary_Listen_Addresses/ODataDemoService_{0}_{1}", serviceName, Process.GetCurrentProcess().Id));
            this.serviceHost = new WebServiceHost(typeof(DemoDSPDataService), new Uri[] { serviceUri });
            serviceHost.Open();

            this.serviceBaseUri = new Uri(serviceUri.AbsoluteUri + "/");
        }

        /// <summary>
        /// The base URI of the hosted service.
        /// </summary>
        public Uri ServiceBaseUri
        {
            get
            {
                return this.serviceBaseUri;
            }
        }

        /// <summary>
        /// Disposes the service - closes it.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.serviceHost.Abort();
            this.serviceHost.Close();
            ((IDisposable)this.serviceHost).Dispose();
        }

        /// <summary>
        /// Finalizer.
        /// </summary>
        ~ODataDemoServiceHost()
        {
            this.Dispose();
        }
    }
}