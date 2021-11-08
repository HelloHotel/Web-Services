using TechTalk.SpecFlow;

namespace HelloHotel.API.Tests
{
    [Binding]
    public class RoomServiceTestSteps
    {
        [Given(@"The developer is in the endpoint https://localhost:(.*)/api/v(.*)/rooms")]
        public void GivenTheDeveloperIsInTheEndpointHttpsLocalhostApiVRooms(int p0, int p1)
        {
            ScenarioContext.StepIsPending();
        }

        [Given(@"A room is already stored")]
        public void GivenARoomIsAlreadyStored(Table table)
        {
            ScenarioContext.StepIsPending();
        }

        [When(@"The deveveper select put")]
        public void WhenTheDeveveperSelectPut()
        {
            ScenarioContext.StepIsPending();
        }

        [When(@"update the cost")]
        public void WhenUpdateTheCost(Table table)
        {
            ScenarioContext.StepIsPending();
        }
    }
}