using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Impulse.NetFrmWrk.Cryptography.Tests.Steps
{
    [Binding]
    public sealed class GetRandomBytesStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private readonly ICryptographyService _cryptographyService;

        public GetRandomBytesStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _cryptographyService = new CryptographyService();
        }

        [Given(@"user input of number of bytes is (.*)")]
        public void GivenUserInputOfNumberOfBytesIs(int p0)
        {
            // Arrange
            _scenarioContext["numberOfBytes"] = p0;
        }

        [When(@"GetRandomBytes is executed")]
        public void WhenGetRandomBytesIsExecuted()
        {
            // Act
            int numberOfBytes = (int)_scenarioContext["numberOfBytes"];
            _scenarioContext["result"] = _cryptographyService.GetRandomBytes(numberOfBytes);
        }

        [Then(@"I should get byte array that is (.*) bytes long")]
        public void ThenIShouldGetByteArrayThatIsBytesLong(int p0)
        {
            // Assert
            byte[] result = (byte[])_scenarioContext["result"];

            Assert.AreEqual(p0, result.Length);
        }


    }
}
