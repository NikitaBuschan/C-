using MVPTestThree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccounting.Model
{
    public interface IPersonModel
    {
        Person person { get; set; }
        List<Person> people { get; set; }

        void AddPerson();
        void EditPerson(int index, Person person);
    }
}
