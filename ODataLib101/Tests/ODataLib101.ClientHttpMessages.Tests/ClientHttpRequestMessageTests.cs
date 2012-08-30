using System;
#if ODataLib101_Async
using System.Threading.Tasks;
#endif
using Microsoft.Data.OData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ODataDemoService;

namespace ODataLib101.ClientHttpMessages.Tests
{
    [TestClass]
    public class ClientHttpRequestMessageTests
    {
        [TestMethod]
        public void CanCreateRequestTest()
        {
            var request = new ClientHttpRequestMessage(TestDemoService.ServiceBaseUri);
            Assert.AreEqual(TestDemoService.ServiceBaseUri, request.Url);
        }

        [TestMethod]
        public void SetContentTypeHeaderTest()
        {
            TestSetHeader("Content-Type", "application/json");
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
            var request = new ClientHttpRequestMessage(TestDemoService.ServiceBaseUri);
            Assert.IsNull(request.GetHeader("NonExisting"));
        }

        [TestMethod]
        public void RemoveHeaderTest()
        {
            var request = new ClientHttpRequestMessage(TestDemoService.ServiceBaseUri);
            request.SetHeader("Date", DateTime.Now.ToString());
            request.SetHeader("Date", null);
            Assert.IsNull(request.GetHeader("Date"));
        }

        [TestMethod]
        public void SetAcceptHeaderCaseInsensitive()
        {
            var request = new ClientHttpRequestMessage(TestDemoService.ServiceBaseUri);
            request.SetHeader("AccePT", "application/xml");
            Assert.AreEqual("application/xml", request.GetHeader("aCCEpt"));
        }

        [TestMethod]
        public void SetMethodTest()
        {
            var request = new ClientHttpRequestMessage(TestDemoService.ServiceBaseUri);
            request.Method = ODataConstants.MethodPost;
            Assert.AreEqual(ODataConstants.MethodPost, request.Method);
        }

        [TestMethod]
        public void SetNullMethodTest()
        {
            var request = new ClientHttpRequestMessage(TestDemoService.ServiceBaseUri);
            try
            {
                request.Method = null;
                Assert.Fail("Method should have failed to be set to null.");
            }
            catch (ArgumentException)
            {
            }
        }

        [TestMethod]
        public void GetNullHeaderTest()
        {
            var request = new ClientHttpRequestMessage(TestDemoService.ServiceBaseUri);
            try
            {
                var r = request.GetHeader(null);
                Assert.Fail("GetHeader(null) should have failed.");
            }
            catch (ArgumentNullException)
            {
            }
        }

        [TestMethod]
        public void VerifyCanSendRequestPayloadSyncTest()
        {
            var request = new ClientHttpRequestMessage(new Uri(TestDemoService.ServiceBaseUri, "Products"));
            request.Method = ODataConstants.MethodPost;
            using (ODataMessageWriter messageWriter = new ODataMessageWriter(
                request,
                new ODataMessageWriterSettings(),
                TestUtils.GetServiceModel(TestDemoService.ServiceBaseUri)))
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
            var request = new ClientHttpRequestMessage(new Uri(TestDemoService.ServiceBaseUri, "Products"));
            request.Method = ODataConstants.MethodPost;
            using (ODataMessageWriter messageWriter = new ODataMessageWriter(
                request,
                new ODataMessageWriterSettings(),
                TestUtils.GetServiceModel(TestDemoService.ServiceBaseUri)))
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
            var request = new ClientHttpRequestMessage(new Uri(TestDemoService.ServiceBaseUri, "Products?$filter=Unknown"));
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
            var request = new ClientHttpRequestMessage(new Uri(TestDemoService.ServiceBaseUri, "Products?$filter=Unknown"));
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
            var request = new ClientHttpRequestMessage(TestDemoService.ServiceBaseUri);
            request.SetHeader(headerName, headerValue);
            string storedValue = request.GetHeader(headerName);
            Assert.AreEqual(headerValue, storedValue);
        }
    }
}
