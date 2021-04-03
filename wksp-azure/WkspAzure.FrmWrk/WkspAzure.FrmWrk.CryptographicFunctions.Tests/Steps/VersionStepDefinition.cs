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
    using TestFunction = WkspAzure.FrmWrk.CryptographicFunctions.Version;

    [Binding]
    public sealed class VersionStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public VersionStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"version request message")]
        public void GivenVersionRequestMessage()
        {
            // Arrange
            _scenarioContext["req"] = new HttpRequestMessage(HttpMethod.Get, "http://localhost/test")
            {
                Content = new StringContent(string.Empty)
            };

            _scenarioContext["log"] = new TraceWriterStub(TraceLevel.Info);
        }

        [When(@"version function is executed")]
        public void WhenVersionFunctionIsExecuted()
        {
            // Act
            HttpRequestMessage req = (HttpRequestMessage)_scenarioContext["req"];

            TraceWriter log = (TraceWriter)_scenarioContext["log"];

            _scenarioContext["result"] = TestFunction.Run(req, log).Result;
        }


        [Then(@"result should be a response message with version number")]
        public void ThenResultShouldBeAResponseMessageWithVersionNumber()
        {
            // Asserts
            HttpResponseMessage response = (HttpResponseMessage)_scenarioContext["result"];
            string content = response.Content.ReadAsStringAsync().Result;
            dynamic result = JsonConvert.DeserializeObject(content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("OK", (string)result?.status);
            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)result?.httpStatusCode);
            Assert.AreEqual("1.0.0", (string)result?.version);
        }
    }
}
