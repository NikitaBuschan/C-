using System.Windows.Forms;

namespace Resume
{
    static class Program
    {
        static void Main()
        {
            MyResume resume = new MyResume("Nikita","Buschan", 24);
            resume.Workplaces.Add("Director of Google");
            resume.Workplaces.Add("Programming teacher");
            resume.Workplaces.Add("Singer at closed gangster parties");

            int countOfSymbols = 0;
            string WorkplaceMessage = string.Empty;

            countOfSymbols += resume.Age.Length;
            countOfSymbols += resume.Name.Length;
            countOfSymbols += resume.Surname.Length;

            foreach (var place in resume.Workplaces)
            {
                countOfSymbols += place.Length;
                WorkplaceMessage += $"{place}\n";
            }

            MessageBox.Show($"Name: {resume.Name}\nSurname: {resume.Surname}\nAge: {resume.Age}", "Main rasume");
            MessageBox.Show(WorkplaceMessage, "Works places");
            MessageBox.Show($"Count of symbols: {countOfSymbols}\nCount of MessageBox: 3", $"Average count symbol on list: {countOfSymbols / 3}");
        }
    }
}