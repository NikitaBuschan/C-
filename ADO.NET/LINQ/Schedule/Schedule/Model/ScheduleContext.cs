using System.Data.Entity;

namespace Schedule.Model
{
    public class ScheduleContext : DbContext
    {
        public ScheduleContext() : base("Schedule") { }

        public DbSet<Employee> Employers { get; set; }
        public DbSet<WorkingDays> WorkingDays { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
    }
}
