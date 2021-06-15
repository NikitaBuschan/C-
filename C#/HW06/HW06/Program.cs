using System;
using Russia;
using Ukrain;
using Poland;

namespace HW06
{
    class Program
    {
        static void Main(string[] args)
        {
            Moscow  Moscow = new Moscow(10_000_000);
            Warszawa Warszaw = new Warszawa(5_300_000);
            Kiev Kiev = new Kiev(2_800_000);

            Console.WriteLine(Moscow > Warszaw);
            Console.WriteLine(Moscow > Kiev);
            Console.WriteLine(Kiev > Warszaw);
        }
    }
}