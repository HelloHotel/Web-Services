using TechTalk.SpecFlow;

namespace HelloHotel.API.Tests
{
    [Binding]
    public class Inventory
    {
        [Given(@"The Endpoint https://localhost:(.*)/api/v(.*)/inventory is available")]
        public void GivenTheEndpointHttpsLocalhostApiVInventoryIsAvailable(int p0, int p1)
        {
            ScenarioContext.StepIsPending();
        }
    }
}