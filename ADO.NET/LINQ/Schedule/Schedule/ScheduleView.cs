using Schedule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Schedule
{
    public partial class ScheduleView : Form
    {
        public ScheduleView()
        {
            InitializeComponent();
            FillDataBase();
            FillComboBox();
        }

        private void FillDataBase()
        {
            using (var db = new ScheduleContext())
            {
                db.Schedules.AddRange(new List<Model.Schedule>()
                {
                    new Model.Schedule() { ID = 1, StartDate = "20.20.2000", EndDate = "21.20.2000" },
                    new Model.Schedule() { ID = 2, StartDate = "10.20.2000", EndDate = "21.20.2000" }
                });
                db.SaveChanges();

                db.Employers.AddRange(new List<Employee>() 
                {
                    new Employee() 
                    { 
                        ID = 1, 
                        Name = "Nikita", 
                        Surname = "Buschan", 
                        LastName = "Sergeevich", 
                        Schedule = db.Schedules.ToArray()[0], 
                        ScheduleFK = 1 
                    },
                    new Employee()
                    {
                        ID = 2,
                        Name = "Kolia",
                        Surname = "Mazur",
                        LastName = "Alibabaevich",
                        Schedule = db.Schedules.ToArray()[1],
                        ScheduleFK = 2
                    }
                });
                db.SaveChanges();

                db.WorkingDays.AddRange(new List<WorkingDays>() 
                {
                    new WorkingDays() { ID = 1, WeekNumber = 1, Date = "01.10.2019", Schedule = db.Schedules.ToArray()[0], ScheduleFK = 1 },
                    new WorkingDays() { ID = 2, WeekNumber = 2, Date = "02.10.2019", Schedule = db.Schedules.ToArray()[0], ScheduleFK = 1 },
                    new WorkingDays() { ID = 3, WeekNumber = 3, Date = "03.10.2019", Schedule = db.Schedules.ToArray()[0], ScheduleFK = 1 },
                    new WorkingDays() { ID = 4, WeekNumber = 4, Date = "04.10.2019", Schedule = db.Schedules.ToArray()[0], ScheduleFK = 1 },
                    new WorkingDays() { ID = 5, WeekNumber = 5, Date = "05.10.2019", Schedule = db.Schedules.ToArray()[0], ScheduleFK = 1 },
                    new WorkingDays() { ID = 6, WeekNumber = 1, Date = "08.10.2019", Schedule = db.Schedules.ToArray()[0], ScheduleFK = 1 } 
                });
                db.SaveChanges();

                dataGridView.Columns.Add("ID", "ID");
                dataGridView.Columns.Add("Name", "Name");
                dataGridView.Columns.Add("WeekNumber", "Week number");
                dataGridView.Columns.Add("Date", "Date");
            }
        }

        private void FillComboBox()
        {
            using (var db = new ScheduleContext())
            {
                var employeers = from a in db.Employers
                                 select new
                                 {
                                     Surname = a.Surname
                                 };

                foreach (var emp in employeers)
                {
                    comboBox.Items.Add(emp.Surname);
                }

                comboBox.SelectedIndex = 0;
            }
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox.Items.Count == 0)
                return;
            dataGridView.Rows.Clear();
            FillGataGridView(comboBox.Items[comboBox.SelectedIndex].ToString());
        }

        private void FillGataGridView(string Surname)
        {
            using (var db = new ScheduleContext())
            {
                var employers = from a in db.Schedules
                                join b in db.Employers on a.ID equals b.ScheduleFK
                                join c in db.WorkingDays on a.ID equals c.ScheduleFK
                                where b.Surname == Surname
                                select new
                                {
                                    ID = c.ID,
                                    Name = b.Name,
                                    WeekNumber = c.WeekNumber,
                                    Date = c.Date
                                };

                int temp = 0;
                foreach (var emp in employers.ToArray())
                {
                    dataGridView.Rows.Add();
                    dataGridView.Rows[temp].Cells["ID"].Value = emp.ID;
                    dataGridView.Rows[temp].Cells["Name"].Value = emp.Name;
                    dataGridView.Rows[temp].Cells["WeekNumber"].Value = emp.WeekNumber;
                    dataGridView.Rows[temp].Cells["Date"].Value = emp.Date;
                    temp++;
                }

                for (int i = 0; i < dataGridView.Columns.Count; i++)
                    dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
    }
}
