using TechTalk.SpecFlow;

namespace HelloHotel.API.Tests
{
    [Binding]
    public class InventoryServiceTestSteps
    {
        [Given(@"The Endpoint https://localhost:(.*)/api/v(.*)/inventory is available")]
        public void GivenTheEndpointHttpsLocalhostApiVInventoryIsAvailable(int p0, int p1)
        {
            ScenarioContext.StepIsPending();
        }

        [When(@"A Post request is sent")]
        public void WhenAPostRequestIsSent(Table table)
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"A Response with Status (.*) is received")]
        public void ThenAResponseWithStatusIsReceived(int p0)
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"A Inventory Resource is included in Response Body")]
        public void ThenAInventoryResourceIsIncludedInResponseBody(Table table)
        {
            ScenarioContext.StepIsPending();
        }

        [Given(@"A Inventory is already stored")]
        public void GivenAInventoryIsAlreadyStored(Table table)
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"A Message is included in Response Body with values ""(.*)""")]
        public void ThenAMessageIsIncludedInResponseBodyWithValues(string p0)
        {
            ScenarioContext.StepIsPending();
        }
    }
}