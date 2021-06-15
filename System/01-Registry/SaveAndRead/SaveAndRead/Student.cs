using Microsoft.Win32;

namespace SaveAndRead
{
    struct RegDataStudent
    {
        public string Name { get; private set; }
        public string Data { get; private set; }
        public RegistryValueKind ValueKind { get; private set; }

        public RegDataStudent(string name, string data, RegistryValueKind reg = RegistryValueKind.String)
        {
            Name = name;
            Data = data;
            ValueKind = reg;
        }
    }

    class Student
    {
        public RegDataStudent Name { get; private set; }
        public RegDataStudent Surname { get; private set; }
        public RegDataStudent Age { get; private set; }
        public RegDataStudent Group { get; private set; }

        public Student(string name, string surname, uint age, string group)
        {
            Name = new RegDataStudent("Name", name, RegistryValueKind.String);
            Surname = new RegDataStudent("Surname", surname, RegistryValueKind.String);
            Age = new RegDataStudent("Age", age.ToString(), RegistryValueKind.DWord);
            Group = new RegDataStudent("Group", group, RegistryValueKind.String);
        }

        public override string ToString()
        {
            return $"Name: {Name.Data}\n" +
                   $"Surname: {Surname.Data}\n" +
                   $"Age: {Age.Data}\n" +
                   $"Group: {Group.Data}";
        }
    }
}
