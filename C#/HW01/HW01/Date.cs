using System;
using System.Collections.Generic;
using System.Text;

namespace HW01
{
    class Date
    {
        private DateTime birthday;

        public void InputDate()
        {
            Console.Write("Enter date: ");
            birthday = DateTime.Parse(Console.ReadLine());
        }

        public void PrintDifference()
        {
            int birthdayDays = birthday.Year * 365 + birthday.DayOfYear;
            int nowDays = DateTime.Now.Year * 365 + DateTime.Now.DayOfYear;
            Console.WriteLine(nowDays - birthdayDays);
        }
    }
}