using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCQAExam.Core
{
    /***
     * Utilty class consists of various methods used to interact with the dropdowns
     */
    public static class Utility
    {
        public static SelectElement select;
        public static WebDriverWait GetWebDriverWait(IWebDriver driver, TimeSpan timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeout)
            {
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return wait;
        }

        public static void SelectElementByIndexWithWait(IWebDriver driver, IWebElement element, int index)
        {
            WebDriverWait wait = GetWebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(drv => element.Displayed);
            wait.Until(drv => element.Enabled);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeSelected(element));
            select = new SelectElement(element);
            select.SelectByIndex(index);
        }

        public static void SelectElementByTextWithWait(IWebDriver driver, IWebElement element, string visibletext)
        {
            WebDriverWait wait = GetWebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(drv => element.Displayed);
            wait.Until(drv => element.Enabled);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeSelected(element));
            select = new SelectElement(element);
            select.SelectByText(visibletext);
        }

        public static void SelectElementByValueWithWait(IWebDriver driver, IWebElement element, string valueTexts)
        {
            WebDriverWait wait = GetWebDriverWait(driver, TimeSpan.FromSeconds(60));
            //wait.Until(drv => element.Displayed);
            wait.Until(drv => element.Enabled);
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeSelected(element));
            select = new SelectElement(element);
            select.SelectByValue(valueTexts);
        }

        public static IList<string> GetAllItem(IWebDriver driver, IWebElement element)
        {
            WebDriverWait wait = GetWebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(drv => element.Displayed);
            wait.Until(drv => element.Enabled);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeSelected(element));
            select = new SelectElement(element);
            return select.Options.Select((x) => x.Text).ToList();
        }
    }
}
