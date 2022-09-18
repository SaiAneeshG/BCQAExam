using BCQAExam.Core;
using BCQAExam.Helper;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions.Internal;
using NUnit.Framework;
using System.Threading;

namespace BCQAExam.Pages
{
    public class CreateAccountPage : BasePage
    {
        private SampleDataGenerator data = new SampleDataGenerator();

        private ReadOnlyCollection<IWebElement> Title => Driver.FindListOfElements(By.XPath("//*[text()='Title']/parent::div//*[@name='id_gender']"));

        private IWebElement FirstName => Driver.FindControl(By.Id("customer_firstname"));

        private IWebElement LastName => Driver.FindControl(By.Id("customer_lastname"));

        private IWebElement Email => Driver.FindControl(By.XPath("//*[text()='Your personal information']/ancestor::div[@class='account_creation']//input[@id='email']"));

        private IWebElement Password => Driver.FindControl(By.Id("passwd"));

        private IWebElement DayInDOB => Driver.FindControl(By.XPath("//*[@id='days']"));

        private IWebElement MonthInDOB => Driver.FindControl(By.Id("months"));

        private IWebElement YearsInDOB => Driver.FindControl(By.Id("years"));

        private IWebElement Company => Driver.FindControl(By.Id("company"));

        private IWebElement AddressLineOne => Driver.FindControl(By.Id("address1"));

        private IWebElement AddressLineTwo => Driver.FindControl(By.Id("address2"));

        private IWebElement City => Driver.FindControl(By.Id("city"));

        private IWebElement State => Driver.FindControl(By.Id("id_state"));

        private IWebElement PostalCode => Driver.FindControl(By.Id("postcode"));

        private IWebElement AdditionalInformation => Driver.FindControl(By.Id("other"));

        private IWebElement HomePhone => Driver.FindControl(By.Id("phone"));

        private IWebElement MobilePhone => Driver.FindControl(By.Id("phone_mobile"));

        private IWebElement AddressAlias => Driver.FindControl(By.Id("alias"));

        private IWebElement RegisterButton => Driver.FindControl(By.Id("submitAccount"));

        private IWebElement PageHeading => Driver.FindControl(By.XPath("//*[text()='Create an account']"));

        private IWebElement PageSubHeading => Driver.FindControl(By.XPath("//*[text()='Your personal information']"));

        public void createAccount()
        {
            ClickOnTheElement(Title[data.getTitle()]);
            EnterValuesInField(FirstName, data.getFirstName());
            EnterValuesInField(LastName, data.getLastName());
            EnterValuesInField(Password, data.getPassword());
            Utility.SelectElementByValueWithWait(Driver, DayInDOB, Convert.ToString(data.getDayInDOB()));
            Utility.SelectElementByValueWithWait(Driver, MonthInDOB, Convert.ToString(data.getMonthInDOB()));
            Utility.SelectElementByValueWithWait(Driver, YearsInDOB, Convert.ToString(data.getYearInDOB()));
            EnterValuesInField(AddressLineOne, data.getAddressLineOne());
            EnterValuesInField(AddressLineTwo, data.getAddressLineTwo());
            EnterValuesInField(City, data.getCity());
            Utility.SelectElementByValueWithWait(Driver, State, Convert.ToString(data.getStateIndex()));
            EnterValuesInField(PostalCode, data.getPostalCode());
            EnterValuesInField(HomePhone, data.getHomePhoneNumber());
            EnterValuesInField(MobilePhone, data.getMobilePhoneNumber());
            ClickOnTheElement(RegisterButton);
        }

        public void verifyNavigationToCreateAccountPage()
        {
            int retries = 3;
            while (true)
            {
                try
                {
                    Assert.AreEqual("YOUR PERSONAL INFORMATION", GetTextOfElement(PageSubHeading));
                    Assert.AreEqual(StaticValues.EmailAddress, GetTextInElement(Email));
                    break; // success!
                }
                catch
                {
                    Console.WriteLine($"printing the retry number : {retries}");
                    if (--retries == 0) throw;
                    else Thread.Sleep(1000);
                }
            }  
        }
    }
}
