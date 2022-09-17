using BCQAExam.Core;
using OpenQA.Selenium;

namespace BCQAExam.Pages
{
    public class LoginPage : BasePage
    {
        private IWebElement Email => Driver.FindControl(By.Id("email"), true);

        private IWebElement Password => Driver.FindControl(By.Id("passwd"));

        private IWebElement LoginButton => Driver.FindControl(By.Id("SubmitLogin"));

        private IWebElement EmailCreate => Driver.FindControl(By.Id("email_create"));

        private IWebElement CreateAccountButton => Driver.FindControl(By.Id("SubmitCreate"));


        public void Login(string email = null, string password = null)
        {
            Email.Clear();
            Email.SendKeys(email);
            Password.Clear();
            Password.SendKeys(password);
            LoginButton.Click();
        }

        public void CreateAccount(string email = null)
        {
            EmailCreate.Clear();
            EmailCreate.SendKeys(email);
            CreateAccountButton.Click();
        }
    }
}
