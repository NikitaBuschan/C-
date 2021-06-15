using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schedule.Model
{
    public class Employee
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Surname { get; set; }

        public long? ScheduleFK { get; set; }
        public Schedule Schedule { get; set; }
    }
}
