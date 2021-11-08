using TechTalk.SpecFlow;

namespace HelloHotel.API.Tests
{
    [Binding]
    public class ClientServiceTestSteps
    {
        [Given(@"The developer is in the endpoint https://localhost:(.*)/api/v(.*)/clients")]
        public void GivenTheDeveloperIsInTheEndpointHttpsLocalhostApiVClients(int p0, int p1)
        {
            ScenarioContext.StepIsPending();
        }

        [When(@"The deveveper select get")]
        public void WhenTheDeveveperSelectGet()
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"The system shows the information of the clients")]
        public void ThenTheSystemShowsTheInformationOfTheClients(Table table)
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"The show a message ""(.*)""")]
        public void ThenTheShowAMessage(string p0)
        {
            ScenarioContext.StepIsPending();
        }
    }
}