
namespace Schedule.Model
{
    public class WorkingDays
    {
        public long ID { get; set; }

        public int WeekNumber { get; set; }
        public string Date { get; set; }

        public long? ScheduleFK { get; set; }
        public Schedule Schedule { get; set; }
    }
}
