using BCQAExam.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Net;
using TechTalk.SpecFlow;

namespace BCQAExam.Steps
{
    [Binding]
    public class BaseStepDefinition
    {
        public static IWebDriver driver = null;

        [BeforeTestRun]
        private static void WarmUpIis()
        {
            var webClient = new WebClient { Proxy = null };
            var requestUrl = ConfigurationManager.AppSettings["URL"];
            //webClient.DownloadString(requestUrl); commenting as the website is retruning 508 error
        }

        [Before]
        private void BeforeScenario()
        {
            driver = WebDriverFactory.CreateDriver((DriverType)Enum.Parse(typeof(DriverType), ConfigurationManager.AppSettings["DriverType"]));
        }

        [After]
        private void Teardown()
        {
            driver.Quit();
        }

        [AfterStep]
        private void AfterStep()
        {
            if (ScenarioContext.Current.TestError == null)
            {
                return;
            }

            Console.WriteLine("INFO: Failed at URL:" + driver.Url);
        }
    }
}
