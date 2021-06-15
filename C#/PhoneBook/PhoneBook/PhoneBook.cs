using System;
using System.Collections.Generic;
using System.IO;

namespace PhoneBook
{
    public class PhoneBook
    {
        public string filePath = Directory.GetCurrentDirectory() + @"\PhoneBook.txt";
        public readonly List<Subscriber> subscribers = new List<Subscriber>();

        public void AddSubscriber()
        {
            Subscriber newSub = new Subscriber();
            Console.Write("Enter name: ");
            newSub.Name = Console.ReadLine();
            Console.Write("Enter surname: ");
            newSub.Surname = Console.ReadLine();
            do
            {
                Console.Write("Enter number: ");
                newSub.Phone = Console.ReadLine();
                if (RegularExp.CheckNumber(newSub.Phone))
                    break;
            } while (true);
            do
            {
                Console.Write("Enter E-mail: ");
                newSub.Email = Console.ReadLine();
                if (RegularExp.CheckEmail(newSub.Email))
                    break;
            } while (true);

            subscribers.Add(newSub);
        }

        public void AddSubscriber(Subscriber sub) => subscribers.Add(sub);

        public void AddSubscriber(string name, string surname, string phone, string email)
        {
            if (!RegularExp.CheckNumber(phone) && !RegularExp.CheckEmail(email))
                throw new Exception("Wrong phone or Email");

            subscribers.Add(new Subscriber(name, surname, phone, email));
        }

        public void DeleteSubscriber()
        {
            List<string> fields = new List<string>
            {
                 "Name",
                 "Surname",
                 "Phone",
                 "Email"
            };
            Console.WriteLine("Choose removal criterion by");
            for (int i = 0; i < fields.Count; i++)
                Console.WriteLine($"[{i + 1}] {fields[i]}");

            int number;
            do
            {
                Console.Write("\nYour choose: ");
                number = Convert.ToInt32(Console.ReadLine());
            } while (number < 1 || number > fields.Count);

            Console.Write($"\nEnter {fields[number - 1]}: ");
            string field = Console.ReadLine();
            Console.WriteLine();
            Subscriber temp = new Subscriber();
            switch (number)
            {
                case 1:
                    {
                        temp = SearchSubscriber.ByName(subscribers, field);
                        break;
                    }
                case 2:
                    {
                        temp = SearchSubscriber.BySurname(subscribers, field);
                        break;
                    }
                case 3:
                    {
                        temp = SearchSubscriber.ByPhone(subscribers, field);
                        break;
                    }
                case 4:
                    {
                        temp = SearchSubscriber.ByEmail(subscribers, field);
                        break;
                    }
            }

            if (temp != null)
                subscribers.Remove(temp);
            else
                Console.WriteLine("\nSubscriber not found\n");
        }

        public void ChangeSubscriber(Subscriber sub)
        {
            List<string> fields = new List<string>
            {
                 "Name",
                 "Surname",
                 "Phone",
                 "Email"
            };
            Console.WriteLine("Choose the item you want to change");
            for (int i = 0; i < fields.Count; i++)
                Console.WriteLine($"[{i + 1}] {fields[i]}");

            int number;
            do
            {
                number = Convert.ToInt32(Console.ReadLine());
            } while (number < 1 || number > fields.Count);

            switch (number)
            {
                case 1:
                    {
                        sub.Name = Console.ReadLine();
                        break;
                    }
                case 2:
                    {
                        sub.Surname = Console.ReadLine();
                        break;
                    }
                case 3:
                    {
                        do
                        {
                            Console.Write($"Enter new {fields[number - 1]}: ");
                            sub.Phone = Console.ReadLine();
                            if (RegularExp.CheckNumber(sub.Phone))
                                break;
                        } while (true);
                        break;
                    }
                case 4:
                    {
                        do
                        {
                            Console.Write($"Enter new {fields[number - 1]}: ");
                            sub.Email = Console.ReadLine();
                            if (RegularExp.CheckEmail(sub.Email))
                                break;
                        } while (true);
                        break;
                    }
                default:
                    break;
            }
        }

        public void SaveToFile()
        {
            FileInfo file = new FileInfo(filePath);
            if (!File.Exists(filePath))
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    int i = 0;
                    subscribers.ForEach(delegate
                    {
                        sw.WriteLine(subscribers[i].Name);
                        sw.WriteLine(subscribers[i].Surname);
                        sw.WriteLine(subscribers[i].Phone);
                        sw.WriteLine(subscribers[i].Email);
                        i++;
                    });
                }
            }
        }

        public void ReadFromFile()
        {
            using (StreamReader sr = File.OpenText(filePath))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                { 
                    Console.WriteLine(s);
                }
            }
        }

        public void Print(Subscriber sub)
        {
            Console.WriteLine($"Name: {sub.Name}");
            Console.WriteLine($"Surname: {sub.Surname}");
            Console.WriteLine($"Phone: {sub.Phone}");
            Console.WriteLine($"Email: {sub.Email}\n");
        }
    }
}