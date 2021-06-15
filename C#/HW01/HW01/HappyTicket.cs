using System;
using System.Collections.Generic;
using System.Text;

namespace HW01
{
    class HappyTicket
    {
        private string ticket;

        public void Input()
        {
            do
            {
                Console.Write("Enter ticket: ");
                ticket = Console.ReadLine();
            } while (ticket.Length < 6 || ticket.Length > 6);
        }

        private bool IsHappy()
        {
            int left = 0;
            int right = 0;
            for (int i = 0, j = 3; i < ticket.Length / 2; i++, j++)
            {
                left += ticket[i];
                right += ticket[j];
            }
            if (left == right)
                return true;
            return false;
        }

        public void PrintAnswer() => Console.WriteLine("Tiket is " + (IsHappy() ? "happy" : "not happy"));
    }
}
