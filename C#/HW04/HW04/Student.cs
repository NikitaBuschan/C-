using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW04
{
    enum Subject
    {
        Programming,
        Administration,
        Design
    }
    class Student
    {
        private string Name { get; set; }
        private string Surname { get; set; }
        private string Patronymic { get; set; }
        private string Age { get; set; }
        private string Group { get; set; }

        private int[][] marks = new int[countOfSubject][];
        private const int countOfSubject = 3;

        public void Field()
        {
            Console.Write("Enter the name: ");
            Name = Console.ReadLine();
            Console.Write("Enter the surname: ");
            Surname = Console.ReadLine();
            Console.Write("Enter the patronymic: ");
            Patronymic = Console.ReadLine();

            {
                bool flag;
                do
                {
                    flag = true;
                    Console.Write("Enter the age: ");
                    Age = Console.ReadLine();
                    for (int i = 0; i < Age.Length; i++)
                        if (char.IsLetter(Age[i]))
                            flag = false;
                } while (!flag);
            }

            Console.Write("Enter the group: ");
            Group = Console.ReadLine();
            
            for (int i = 0; i < countOfSubject; i++)
            {
                Console.Write("Enter marks of " + (Subject)i + ": ");
                string temp = Console.ReadLine();
                int countOfMarks = 0;
                for (int j = 0; j < temp.Length; j++)
                {
                    string mark = string.Empty;
                    while (j < temp.Length && char.IsDigit(temp[j]))
                        mark += temp[j++];
                    countOfMarks++;
                }
                marks[i] = new int[countOfMarks];
                countOfMarks = 0;
                for (int j = 0; j < temp.Length; j++)
                {
                    string mark = string.Empty;
                    while (j < temp.Length && char.IsDigit(temp[j]))
                        mark += temp[j++];
                    marks[i][countOfMarks++] = Convert.ToInt32(mark);
                }
            }
        }

        public void AddMark()
        {
            Console.WriteLine("Choose subject: ");
            for (int i = 0; i < countOfSubject; i++)
                Console.WriteLine((i + 1) + " " + (Subject)i);

            int choose;
            Console.WriteLine();
            do
            {
                Console.Write("Your choice: ");
                choose = Convert.ToInt32(Console.ReadLine());
            } while (choose < 1 || choose > countOfSubject);

            marks[choose] = new int[(marks[choose].Length) + 1];
            marks[choose][marks[choose].Length] = Convert.ToInt32(Console.ReadLine());
        }

        public void PrintAverageOfSubject()
        {
            Console.WriteLine("Choose subject: ");
            for (int i = 0; i < countOfSubject; i++)
                Console.WriteLine((i + 1) + " " + (Subject)i);

            int choose;
            Console.WriteLine();
            do
            {
                Console.Write("Your choice: ");
                choose = Convert.ToInt32(Console.ReadLine());
            } while (choose < 1 || choose > countOfSubject);

            int mark = 0;
            for (int i = 0; i < marks[choose].Length; i++)
                mark += marks[choose][i];

            Console.WriteLine("\nGrade point average: " + mark);
        }

        public void Print()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Surname: " + Surname);
            Console.WriteLine("Patronymic: " + Patronymic);
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("Group: " + Group);
            for (int i = 0; i < countOfSubject; i++)
            {
                Console.Write((Subject)i + ": ");
                for (int j = 0; j < marks[i].Length; j++)
                    Console.Write(marks[i][j] + "  ");
                Console.WriteLine();
            }
        }
    }
}