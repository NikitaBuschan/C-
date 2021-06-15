using System;
using System.Text.RegularExpressions;

namespace PhoneBook
{
    class RegularExp
    {
        public static Regex phoneRegex = new Regex(
            "((/+38|8|/+3|/+ )[ ]?)?([(]?/d{3}[)]?[-]?)?(/d[ -]?){6,14}",
            RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static Regex emailRegex = new Regex(
            "[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?",
            RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static bool CheckEmail(string email)
        {
            if (email == null)
                throw new ArgumentNullException("Null reference instead of email string to check");
            if (email.Length == 0)
                throw new ArgumentException("Empty string instead of email string to check");

            return emailRegex.Match(email).Success;
        }

        public static bool CheckNumber(string number)
        {
            if (number == null)
                throw new ArgumentNullException("Null reference instead of number string to check");
            if (number.Length == 0)
                throw new ArgumentException("Empty string instead of number string to check");

            return phoneRegex.Match(number).Success;
        }
    }
}