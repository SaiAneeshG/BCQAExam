using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace BCQAExam.Core
{
    public class WebDriverFactory
    {
        public static IWebDriver CreateDriver(DriverType driverType)
        {
            string driverPath = "";
            switch (driverType)
            {
                case DriverType.Ie:
                   driverPath = new DriverManager().SetUpDriver(new InternetExplorerConfig());
                   return new InternetExplorerDriver(driverPath);
                case DriverType.Chrome:
                    driverPath = new DriverManager().SetUpDriver(new ChromeConfig()).Replace("\\chromedriver.exe","");
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("--start-maximized");
                    chromeOptions.AddArguments("--incognito");
                    chromeOptions.AddArguments("--disable-popup-blocking");
                    chromeOptions.AddArguments("--disable-extensions");
                    chromeOptions.AddArguments("--disable-notifications");
                    chromeOptions.AddArguments("--disable-infobars");
                    return new ChromeDriver(driverPath, chromeOptions);
                default:
                    driverPath = new DriverManager().SetUpDriver(new FirefoxConfig());
                    return new FirefoxDriver(driverPath);
            }
        }
    }
}
