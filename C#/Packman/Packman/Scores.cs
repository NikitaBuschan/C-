using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Pacman.Menu
{
    public class Scores
    {
        public int highScores;
        private List<ScoresData> list;
        private string filePath = Directory.GetCurrentDirectory() + @"\Scores.dat";
        private BinaryFormatter formatter = new BinaryFormatter();
        private AddScores menuAddScores;

        public Scores()
        {
            list = new List<ScoresData>();
            ReadFromFile();
            highScores = list[0].Scores;
        }

        public void AddScores()
        {
            menuAddScores = new AddScores();
            menuAddScores.ShowMenu();
            var scoresData = new ScoresData(
                PacmanHero.Scores,
                menuAddScores.EnterData());
            Console.CursorVisible = false;

            for (int i = 0; i < list.Count; i++)
                if (list[i] <= scoresData)
                {
                    for (int j = list.Count - 1; j > i; j--)
                        list[j] = list[j - 1];

                    list[i] = scoresData;
                    break;
                }
            SaveToFile();
        }

        public void MakeFile()
        {
            list = new List<ScoresData>();
            for (int i = 0; i < 10; i++)
                list.Add(new ScoresData(0, " .... "));
            SaveToFile();
        }

        public void Draw()
        {
            int i = 0;
            Console.SetCursorPosition(16, 9);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Rank      Score      Name");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (var item in list)
            {
                Console.SetCursorPosition(16, 10 + ++i);
                if (i != 10)
                {
                    if (item.Scores == 0)
                    {
                        Console.WriteLine($"{Indent(2)}{i}{Indent(item)}{item.Scores}{Indent(5)}{item.Name}");
                        continue;
                    }
                    Console.WriteLine($"{Indent(2)}{i}{Indent(item)}{item.Scores}{Indent(6)}{item.Name}");
                }
                else
                {
                    Console.WriteLine($"{Indent(1)}{i}{Indent(item)}{item.Scores}{Indent(5)}{item.Name}");
                }
            }
        }

        public object Indent(int count) => "".PadLeft(count);

        public object Indent(ScoresData scoresData)
        {
            if (scoresData.Scores > 10000)
                return "".PadLeft(7);
            if (scoresData.Scores > 1000)
                return "".PadLeft(8);
            if (scoresData.Scores > 100)
                return "".PadLeft(9);
            if (scoresData.Scores > 10)
                return "".PadLeft(10);
            else return "".PadLeft(11);
        }

        public void SaveToFile()
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, list);
            }
        }

        public void ReadFromFile()
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    list = (List<ScoresData>)formatter.Deserialize(fs);
                }
            }
            catch (Exception)
            {
                MakeFile();
            }
        }
    }
}