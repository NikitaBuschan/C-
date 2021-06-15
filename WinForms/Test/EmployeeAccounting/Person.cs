using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPTestThree
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public Bitmap Image { get; set; }

        public Person(string name, string surname, int age, bool gender, Bitmap image)
        {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
            this.Gender = gender;
            this.Image = image;
        }
    }
}
