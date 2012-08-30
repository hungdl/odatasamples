using System;
#if ODataLib101_Async
using System.Threading.Tasks;
#endif
using Microsoft.Data.OData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ODataLib101.ClientHttpMessages.Tests
{
    [TestClass]
    public class ClientHttpResponseMessageTests
    {
        [TestMethod]
        public void VerifyResponseTest()
        {
            var response = this.CreateResponseMessage();
            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("application/atom+xml;type=entry;charset=utf-8", response.GetHeader(ODataConstants.ContentTypeHeader));
            Assert.AreEqual(ODataVersion.V1, ODataUtils.StringToODataVersion(response.GetHeader(ODataConstants.DataServiceVersionHeader)));
            response.GetStream().Dispose();
        }

        [TestMethod]
        public void VerifyCanReadResponseSyncTest()
        {
            using (ODataMessageReader messageReader = new ODataMessageReader(
                this.CreateResponseMessage(),
                new ODataMessageReaderSettings(),
                TestUtils.GetServiceModel(TestDemoService.ServiceBaseUri)))
            {
                ODataReader reader = messageReader.CreateODataEntryReader();
                while (reader.Read())
                {
                    if (reader.State == ODataReaderState.EntryEnd)
                    {
                        ODataEntry entry = (ODataEntry)reader.Item;
                        Assert.AreEqual("DataServiceProviderDemo.Product", entry.TypeName);
                    }
                }
            }
        }

#if ODataLib101_Async
        [TestMethod]
        public async Task VerifyCanReadResponseAsyncTest()
        {
            IODataResponseMessageAsync responseMessage = await new ClientHttpRequestMessage(new Uri(TestDemoService.ServiceBaseUri, "Products(1)")).GetResponseAsync();

            using (ODataMessageReader messageReader = new ODataMessageReader(
                responseMessage,
                new ODataMessageReaderSettings(),
                TestUtils.GetServiceModel(TestDemoService.ServiceBaseUri)))
            {
                ODataReader reader = await messageReader.CreateODataEntryReaderAsync();
                while (await reader.ReadAsync())
                {
                    if (reader.State == ODataReaderState.EntryEnd)
                    {
                        ODataEntry entry = (ODataEntry)reader.Item;
                        Assert.AreEqual("DataServiceProviderDemo.Product", entry.TypeName);
                    }
                }
            }
        }
#endif

        private IODataResponseMessage CreateResponseMessage()
        {
            var request = new ClientHttpRequestMessage(new Uri(TestDemoService.ServiceBaseUri, "Products(1)"));
            return request.GetResponse();
        }
    }
}
