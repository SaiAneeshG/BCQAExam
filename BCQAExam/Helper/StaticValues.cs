using Dynamitey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCQAExam.Helper
{
    /***
     * Static values is created to store the test values for resuability 
     */
    public static class StaticValues
    {
        public static String EmailAddress = "";
        public static String Password = "";
        public static String FirstName = "";
        public static String LastName = "";

        public static void SetEmailAddress(String inputEmailaddress)
        {
            EmailAddress = inputEmailaddress;
        }

        public static void SetPassword(String InputPassword)
        {
            Password = InputPassword;
        }

        public static void SetFirstName(string firstName)
        {
            FirstName = firstName;
        }

        public static void SetLastName(string lastName)
        {
            LastName = lastName;
        }

        public static String GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
