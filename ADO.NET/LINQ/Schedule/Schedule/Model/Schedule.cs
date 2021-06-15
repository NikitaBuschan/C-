using System.Collections.Generic;

namespace Schedule.Model
{
    public class Schedule
    {
        public long ID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public ICollection<Employee> Employee { get; set; }
        public ICollection<WorkingDays> WorkingDays { get; set; }

        public Schedule()
        {
            Employee = new List<Employee>();
            WorkingDays = new List<WorkingDays>();
        }
    }
}
