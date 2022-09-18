using BCQAExam.Steps;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace BCQAExam.Pages
{
    /***
     * This class consists of util methods for all generic webdriver actions to avoid synchronization issues
     */
    public class BasePage
    {
        protected IWebDriver Driver = BaseStepDefinition.driver;

        public BasePage(string pageUrl = "")
        {

            PageFactory.InitElements(Driver, this);

            new WebDriverWait(Driver, TimeSpan.FromSeconds(60))
                .Until(drv =>
                    ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState").Equals("complete"));

            if (!string.IsNullOrWhiteSpace(pageUrl))
                new WebDriverWait(Driver, TimeSpan.FromSeconds(60))
                    .Until(drv => drv.Url.Contains(pageUrl));
        }

        public void EnterValuesInField(IWebElement element, String value)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
                wait.Until(drv => element.Displayed);
                wait.Until(drv => element.Enabled);
                element.Clear();
                element.SendKeys(value);
            }
            catch (Exception)
            {
                Console.WriteLine($"INFO: Element not found.\n{element}");
                throw;
            }
        }

        public void ClickOnTheElement(IWebElement element)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
                wait.Until(drv => element.Enabled);
                element.Click();
            }
            catch (Exception)
            {
                Console.WriteLine($"INFO: Element not found.\n{element}");
                throw;
            }
        }

        public String GetTextOfElement(IWebElement element)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
                wait.Until(drv => element.Enabled);
                return element.Text;
            }
            catch (Exception)
            {
                Console.WriteLine($"INFO: Element not found.\n{element}");
                throw;
            }
        }

        public String GetTextInElement(IWebElement element)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
                wait.Until(drv => element.Enabled);
                return element.GetAttribute("value");
            }
            catch (Exception)
            {
                Console.WriteLine($"INFO: Element not found.\n{element}");
                throw;
            }
        }
    }
}
