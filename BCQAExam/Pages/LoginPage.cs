using BCQAExam.Core;
using BCQAExam.Helper;
using OpenQA.Selenium;

namespace BCQAExam.Pages
{
    public class LoginPage : BasePage
    {
        private SampleDataGenerator data = new SampleDataGenerator();
        private IWebElement Email => Driver.FindControl(By.Id("email"), true);

        private IWebElement Password => Driver.FindControl(By.Id("passwd"));

        private IWebElement LoginButton => Driver.FindControl(By.Id("SubmitLogin"));

        private IWebElement EmailCreate => Driver.FindControl(By.Id("email_create"));

        private IWebElement CreateAccountButton => Driver.FindControl(By.Id("SubmitCreate"));


        public void Login(string emailAddress = null, string password = null)
        {
            EnterValuesInField(Email, emailAddress);
            EnterValuesInField(Password, password);
            ClickOnTheElement(LoginButton);
        }

        public void CreateAccount(string email = null)
        {
            string emailAddress = data.getEmailAddress(email);
            EmailCreate.Clear();
            EmailCreate.SendKeys(emailAddress);
            CreateAccountButton.Click();
        }
    }
}
