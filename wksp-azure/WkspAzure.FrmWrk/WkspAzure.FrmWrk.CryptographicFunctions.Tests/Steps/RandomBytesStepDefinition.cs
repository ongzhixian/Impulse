namespace WkspAzure.FrmWrk.CryptographicFunctions.Tests.Steps
{
    using Microsoft.Azure.WebJobs.Host;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Http;
    using TechTalk.SpecFlow;
    using WkspAzure.FrmWrk.CryptographicFunctions.Tests.Stubs;
    using TestFunction = WkspAzure.FrmWrk.CryptographicFunctions.RandomBytes;

    [Binding]
    public sealed class RandomBytesStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public RandomBytesStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"input of (.*)")]
        public void GivenInputOf(int p0)
        {
            // Arrange
            _scenarioContext["req"] = new HttpRequestMessage(HttpMethod.Get, $"http://localhost/test?numberOfBytes={p0}")
            {
                Content = new StringContent(string.Empty)
            };

            _scenarioContext["log"] = new TraceWriterStub(TraceLevel.Info);
        }

        [When(@"randomBytes function is executed")]
        public void WhenRandomBytesFunctionIsExecuted()
        {
            // Act
            HttpRequestMessage req = (HttpRequestMessage)_scenarioContext["req"];

            TraceWriter log = (TraceWriter)_scenarioContext["log"];

            _scenarioContext["result"] = TestFunction.Run(req, log).Result;
        }

        [Then(@"result should be a response message with (.*) random bytes")]
        public void ThenResultShouldBeAResponseMessageWithRandomBytes(int p0)
        {
            // Asserts
            HttpResponseMessage response = (HttpResponseMessage)_scenarioContext["result"];
            string content = response.Content.ReadAsStringAsync().Result;
            dynamic result = JsonConvert.DeserializeObject(content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("OK", (string)result?.status);
            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)result?.httpStatusCode);
            Assert.AreEqual(p0, ((string)result?.bytesInBase64).ToBytesAsBase64String()?.Length);
        }

    }
}
