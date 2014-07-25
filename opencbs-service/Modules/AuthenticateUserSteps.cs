using System;
using TechTalk.SpecFlow;

namespace OpenCBS.Online.Service.Test.Modules
{
    [Binding]
    public class AuthenticateUserSteps
    {
        [Given(@"there is a request to the Security Module")]
        public void GivenThereIsARequestToTheSecurityModule()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"The request being made is from user admin with password admin")]
        public void WhenTheRequestBeingMadeIsFromUserAdminWithPasswordAdmin()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Then the user is authenticated and given an Access Token")]
        public void ThenThenTheUserIsAuthenticatedAndGivenAnAccessToken()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
