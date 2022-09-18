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
        public void WhenIEnterAValidAndClickOnCreateAccount(string email)
        {
            NavigationPage.NavigateToLoginPage();
            LoginPage.CreateAccount(email);
        }

        [Then(@"I should be navigated to the create an account page")]
        public void ThenIShouldBeNavigatedToTheCreateAnAccountPage()
        {
            CreateAccountPage.verifyNavigationToCreateAccountPage();
        }

        [Then(@"I enter details and click on Register")]
        public void ThenIEnterDetailsAndClickOnRegister()
        {
            CreateAccountPage.createAccount();
        }

        [Then(@"I am navigated to My Account Page")]
        public void ThenIAmNavigatedToMyAccountPage()
        {
            MyAccountPage.AssertAccountDetails(StaticValues.GetFullName());
        }

        [Then(@"I click on signout button")]
        public void ThenIClickOnSignoutButton()
        {
            MyAccountPage.ClickOnSignOutButton();
        }

        [Then(@"I click on signin button to verify login")]
        public void ThenIClickOnSigninButtonToVerifyLogin()
        {
            NavigationPage.NavigateToLoginPage();
        }

        [Then(@"I signin with my new account")]
        public void ThenISigninWithMyNewAccount()
        {
            LoginPage.Login(StaticValues.EmailAddress, StaticValues.Password);
        }

    }
}
