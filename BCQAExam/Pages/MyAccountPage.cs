using BCQAExam.Core;
using BCQAExam.Helper;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace BCQAExam.Pages
{
    public class MyAccountPage : BasePage
    {
        private IWebElement AccountName => Driver.FindControl(By.XPath("//a[@title='View my customer account']"));
        private IWebElement MyAccountTab => Driver.FindControl(By.XPath("//span[@class='navigation_page']"));

        private IWebElement SignOutButton => Driver.FindControl(By.XPath("//*[@class='logout']"));

        public void AssertAccountName()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual("Firstname LastName", AccountName.Text);
                Assert.AreEqual("My account", MyAccountTab.Text);
            });
        }

        public void AssertAccountDetails(string FullName)
        {
            int retries = 3;
            while (true)
            {
                try
                {
                    Assert.Multiple(() =>
                    {
                        Assert.AreEqual(FullName, GetTextOfElement(AccountName));
                        Assert.AreEqual("My account", GetTextOfElement(MyAccountTab));
                    });
                    break; // success!
                }
                catch
                {
                    Console.WriteLine($"printing Assert Account retry number : {retries}");
                    if (--retries == 0) throw;
                    else Thread.Sleep(1000);
                }
            }
            
        }

        public void ClickOnSignOutButton()
        {
            ClickOnTheElement(SignOutButton);
        }
    }
}
