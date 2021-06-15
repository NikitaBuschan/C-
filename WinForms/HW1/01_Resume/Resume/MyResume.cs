using System;
using System.Collections.Generic;

namespace Resume
{
    class MyResume
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Age { get; private set; }
        public List<string> Workplaces { get; private set; }

        public MyResume(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = Convert.ToString(age);
            Workplaces = new List<string>();
        }
    }
}