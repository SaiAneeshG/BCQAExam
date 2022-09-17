using BCQAExam.Pages;
using BCQAExam.Steps;
using BCQAExam.Helper;
using System;
using TechTalk.SpecFlow;
using System.Threading;

namespace BCQAExam
{
    [Binding]
    public class RegisterNewUserStepDefinitions : BaseStepDefinition
    {
        private NavigationPage NavigationPage = new NavigationPage();
        private LoginPage LoginPage = new LoginPage();
        private CreateAccountPage CreateAccountPage = new CreateAccountPage();
        private MyAccountPage MyAccountPage = new MyAccountPage();

        [When(@"I enter a valid ""([^""]*)"" and click on create account")]
        public void WhenIEnterAValidAndClickOnCreateAccount(string emailAddress)
        {
            NavigationPage.NavigateToLoginPage();
            StaticValues.SetEmailAddress(emailAddress);
            LoginPage.CreateAccount(emailAddress);
        }

        [Then(@"I should be navigated to the create an account page")]
        public void ThenIShouldBeNavigatedToTheCreateAnAccountPage()
        {
            //Thread.Sleep(5000);
            CreateAccountPage.verifyNavigationToCreateAccountPage();
        }

        [Then(@"I enter details and click on Register")]
        public void ThenIEnterDetailsAndClickOnRegister()
        {
            //Thread.Sleep(5000);
            CreateAccountPage.createAccount();
        }

        [Then(@"I am navigated to My Account Page")]
        public void ThenIAmNavigatedToMyAccountPage()
        {
            //Thread.Sleep(5000);
            MyAccountPage.AssertAccountDetails(StaticValues.GetFullName());
        }
    }
}
