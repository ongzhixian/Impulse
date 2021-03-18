using TechTalk.SpecFlow;
using WkspGherkin.SpecFlowProj.Drivers;

namespace WkspGherkin.SpecFlowProj.StepDefinitions
{
    [Binding]
    public class CalculatorSteps
    {
        private readonly FeatureContext featureContext;
        private readonly ScenarioContext scenarioContext;

        public CalculatorSteps(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            this.featureContext = featureContext;
            this.scenarioContext = scenarioContext;
            // this.calculator = new Calculator();
        }

        [Given(@"The calculator is reset")]
        public void GivenTheCalculatorIsReset()
        {
            scenarioContext.Pending();
        }
            
        [When(@"I enter (.*)")]
        public void WhenIEnter(int p0)
        {
            scenarioContext.Pending();
        }
            
        [When(@"I Add (.*)")]
        public void WhenIAdd(int p0)
        {
            scenarioContext.Pending();
        }
            
        [Then(@"The value should be (.*)")]
        public void ThenTheValueShouldBe(int p0)
        {
            scenarioContext.Pending();
        }
    }
}
