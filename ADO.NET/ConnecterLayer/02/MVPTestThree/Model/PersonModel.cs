using System.Collections.Generic;
using EmployeeAccounting.Model;
using EmployeeAccounting.Properties;

namespace MVPTestThree.Model
{
    public class PersonModel : IPersonModel
    {
        public Person person { get; set; }
        public List<Person> people { get; set; }

        public PersonModel()
        {
            people = new List<Person>()
            {
                new Person("Никита", "Бущан", 24, true, Resources._2),
                new Person("Влад", "Качанов", 26, true, Resources._1)
            };
        }

        // business-logic
        public void AddPerson() =>
            people.Add(person);

        public void EditPerson(int index, Person person)
        {
            this.person = person;
            people[index] = person;
        }
    }
}
