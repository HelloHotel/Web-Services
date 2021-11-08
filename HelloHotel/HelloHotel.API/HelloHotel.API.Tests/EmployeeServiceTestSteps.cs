using TechTalk.SpecFlow;

namespace HelloHotel.API.Tests
{
    [Binding]
    public class EmployeeServiceTestSteps
    {
        [Given(@"The developer is in the endpoint https://localhost:(.*)/api/v(.*)/employee")]
        public void GivenTheDeveloperIsInTheEndpointHttpsLocalhostApiVEmployee(int p0, int p1)
        {
            ScenarioContext.StepIsPending();
        }

        [When(@"The deveveper select post")]
        public void WhenTheDeveveperSelectPost()
        {
            ScenarioContext.StepIsPending();
        }

        [When(@"Insert the information of the employee")]
        public void WhenInsertTheInformationOfTheEmployee(Table table)
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"The system save the information")]
        public void ThenTheSystemSaveTheInformation()
        {
            ScenarioContext.StepIsPending();
        }
    }
}