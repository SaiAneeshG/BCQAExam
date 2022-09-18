using Dynamitey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCQAExam.Helper
{
    /***
     * SampleDataGenerator created the required data for test case in each run and to remain
     * the values as unique this method used contextValueString and contextValueInt in which 
     * the string value is generated randomly with length 8 and int vaulue is generated using
     * the system run time
     */
    public class SampleDataGenerator
    {
        public String contextValueString = "";
        public int contextValueInt = 0;
        Random rnd = new Random();
        public SampleDataGenerator()
        {
            this.contextValueInt = Convert.ToInt32(DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString().Substring(0, 10));
            Console.WriteLine("Context Int value generated is: " + this.contextValueInt.ToString());
            int myRandomIndex = 0;
            var myList = new List<string>(new[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" });
            var results = new List<string>();
            var r = new Random(DateTime.Now.Millisecond);
            for (int ii = 0; ii < 8; ii++)
            {
                myRandomIndex = r.Next(myList.Count);
                results.Add(myList[myRandomIndex]);
                myList.RemoveAt(myRandomIndex);
            }
            this.contextValueString = string.Join("", results);
            Console.WriteLine("Context String value generated is: " + string.Join("", results));
        }

        /***
         * returns the index 1 or 2 to select the title
         */
        public int getTitle()
        {
            return rnd.Next(0, 2);
        }

        public String getFirstName()
        {
            String firstName = "TestFirstName" + contextValueString;
            StaticValues.SetFirstName(firstName);
            return firstName;
        }

        public String getLastName()
        {
            String lastName = "TestLastName" + contextValueString;
            StaticValues.SetLastName(lastName);
            return lastName;
        }


        public String getEmailAddress(String email)
        {
            String emailAddress = "Test" + email + contextValueString + "@mail.com";
            StaticValues.SetEmailAddress(emailAddress);
            return emailAddress;    
        }

        public String getPassword()
        {
            StaticValues.SetPassword(contextValueString);
            return contextValueString;
        }

        public int getDayInDOB()
        {
            return rnd.Next(1, 28);
        }

        public int getMonthInDOB()
        {
            return rnd.Next(0, 12);
        }

        public int getYearInDOB()
        {
            return rnd.Next(1950, 2000);
        }

        public string getAddressLineOne()
        {
            String addressLineOne = "Test Street-" + contextValueString + " ," + contextValueInt.ToString().Substring(0, 4) + ", Test Company- " + contextValueString;
            return addressLineOne;
        }

        public string getAddressLineTwo()
        {
            String addressLineTwo = "Test Apartment-" + contextValueString + ", Test Unit-" + contextValueString + "Test Building-" + contextValueString;
            return addressLineTwo;
        }

        public string getCity()
        {
            String city = "Test City-" + contextValueString;
            return city;
        }

        public int getStateIndex()
        {
            return rnd.Next(1, 50);
        }

        public String getPostalCode()
        {
            return contextValueInt.ToString().Substring(1, 5);
        }

        public String getHomePhoneNumber()
        {
            return contextValueInt.ToString();
        }

        public String getMobilePhoneNumber()
        {
            return contextValueInt.ToString();
        }
    }
}
