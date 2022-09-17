using BCQAExam.Core;
using OpenQA.Selenium;
using System.Configuration;

namespace BCQAExam.Pages
{
    public class NavigationPage : BasePage
    {
        public void NavigateToHomePage()
        {
            Driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);
        }

        private IWebElement SignInButton => Driver.FindControl(By.XPath("//a[@class='login']"));

        public void NavigateToLoginPage()
        {
            SignInButton.Click();
        }
    }
}
