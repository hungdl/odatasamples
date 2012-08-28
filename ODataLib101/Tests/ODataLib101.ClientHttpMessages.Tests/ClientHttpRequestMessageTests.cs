using System;
#if ODataLib101_Async
using System.Threading.Tasks;
#endif
using Microsoft.Data.OData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ODataLib101.ClientHttpMessages.Tests
{
    [TestClass]
    public class ClientHttpRequestMessageTests
    {
        private static Uri serviceUrl = new Uri("http://localhost:1337/DemoDSPDataService.svc/");

        [TestMethod]
        public void CanCreateRequestTest()
        {
            var request = new ClientHttpRequestMessage(serviceUrl);
            Assert.AreEqual(serviceUrl, request.Url);
        }

        [TestMethod]
        public void SetContentTypeHeaderTest()
        {
            TestSetHeader("Content-Type", "application/json;odata=verbose");
        }

        [TestMethod]
        public void SetAcceptHeaderTest()
        {
            TestSetHeader("Accept", "application/json,application/atom+xml");
        }

        [TestMethod]
        public void SetDataServiceVersionHeaderTest()
        {
            TestSetHeader("DataServiceVersion", ODataUtils.ODataVersionToString(ODataVersion.V3));
        }

        [TestMethod]
        public void GetNonExistingHeaderTest()
        {
            var request = new ClientHttpRequestMessage(serviceUrl);
            Assert.IsNull(request.GetHeader("NonExisting"));
        }

        [TestMethod]
        public void SetMethodTest()
        {
            var request = new ClientHttpRequestMessage(serviceUrl);
            request.Method = ODataConstants.MethodGet;
            Assert.AreEqual(ODataConstants.MethodGet, request.Method);
        }

        [TestMethod]
        public void VerifyCanSendRequestPayloadSyncTest()
        {
            var request = new ClientHttpRequestMessage(new Uri(serviceUrl, "Products"));
            request.Method = ODataConstants.MethodPost;
            using (ODataMessageWriter messageWriter = new ODataMessageWriter(
                request,
                new ODataMessageWriterSettings(),
                TestUtils.GetServiceModel(serviceUrl)))
            {
                ODataWriter writer = messageWriter.CreateODataEntryWriter();
                writer.WriteStart(new ODataEntry()
                {
                    TypeName = "DataServiceProviderDemo.Product",
                    Properties = new ODataProperty[]
                    {
                        new ODataProperty { Name = "ID", Value = 42 }
                    }
                });

                writer.WriteEnd();
                writer.Flush();
            }

            var response = request.GetResponse();
            Assert.AreEqual(201, response.StatusCode);
        }

#if ODataLib101_Async
        [TestMethod]
        public async Task VerifyCanSendRequestPayloadAsyncTest()
        {
            var request = new ClientHttpRequestMessage(new Uri(serviceUrl, "Products"));
            request.Method = ODataConstants.MethodPost;
            using (ODataMessageWriter messageWriter = new ODataMessageWriter(
                request,
                new ODataMessageWriterSettings(),
                TestUtils.GetServiceModel(serviceUrl)))
            {
                ODataWriter writer = await messageWriter.CreateODataEntryWriterAsync();
                await writer.WriteStartAsync(new ODataEntry()
                {
                    TypeName = "DataServiceProviderDemo.Product",
                    Properties = new ODataProperty[]
                    {
                        new ODataProperty { Name = "ID", Value = 42 }
                    }
                });

                await writer.WriteEndAsync();
                await writer.FlushAsync();
            }

            var response = await request.GetResponseAsync();
            Assert.AreEqual(201, response.StatusCode);
        }
#endif

        [TestMethod]
        public void VerifyErrorResponseProcessingSyncTest()
        {
            var request = new ClientHttpRequestMessage(new Uri(serviceUrl, "Products?$filter=Unknown"));
            try
            {
                request.GetResponse();
                Assert.Fail();
            }
            catch (ODataException exception)
            {
                Assert.IsTrue(exception.Message.Contains("Unknown"));
            }
        }

#if ODataLib101_Async
        [TestMethod]
        public async Task VerifyErrorResponseProcessingAsyncTest()
        {
            var request = new ClientHttpRequestMessage(new Uri(serviceUrl, "Products?$filter=Unknown"));
            try
            {
                await request.GetResponseAsync();
                Assert.Fail();
            }
            catch (ODataException exception)
            {
                Assert.IsTrue(exception.Message.Contains("Unknown"));
            }
        }
#endif

        private void TestSetHeader(string headerName, string headerValue)
        {
            var request = new ClientHttpRequestMessage(serviceUrl);
            request.SetHeader(headerName, headerValue);
            string storedValue = request.GetHeader(headerName);
            Assert.AreEqual(headerValue, storedValue);
        }
    }
}
