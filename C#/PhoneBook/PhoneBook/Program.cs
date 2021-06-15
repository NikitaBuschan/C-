using System;

namespace PhoneBook
{
    public class Program
    {
        static void Main(string[] args)
        {
            PhoneBook phoneBook = new PhoneBook();
            phoneBook.AddSubscriber("Nikita", "Buschan", "0631352746", "timafeicq@mail.ru");
            phoneBook.AddSubscriber("Vlad", "Kachanov", "0631352746", "timafeicq@mail.ru");


            phoneBook.subscribers.ForEach(phoneBook.Print);

            //  phoneBook.DeleteSubscriber();
            // phoneBook.subscribers.ForEach(phoneBook.Print);

            Console.WriteLine(phoneBook.filePath);

            phoneBook.SaveToFile();
            Console.WriteLine("Save to file");

            phoneBook.ReadFromFile();
        }
    }
}