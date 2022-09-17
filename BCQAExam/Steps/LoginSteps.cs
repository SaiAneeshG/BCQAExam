using BCQAExam.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BCQAExam.Steps
{
    [Binding]
    public class LoginSteps : BaseStepDefinition
    {
        private NavigationPage NavigationPage = new NavigationPage();
        private LoginPage LoginPage = new LoginPage();
        private MyAccountPage MyAccountPage = new MyAccountPage();
        private dynamic _ScenarioData;

        [Given(@"I am in the home page of the system")]
        public void GivenIAmInTheHomePageOfTheSystem()
        {
            NavigationPage.NavigateToHomePage();
        }

        [When(@"I enter my username and password")]
        public void WhenIEnterMyUsernameAndPassword(Table table)
        {
            NavigationPage.NavigateToLoginPage();
            _ScenarioData = table.CreateDynamicInstance();
            LoginPage.Login((string)_ScenarioData.UserName, (string)_ScenarioData.Password);
        }

        [Then(@"I should be redirected to my Account Page")]
        public void ThenIShouldBeRedirectedToMyAccountPage()
        {
            MyAccountPage.AssertAccountName();
        }
    }
}
