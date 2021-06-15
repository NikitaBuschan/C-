using System;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            ChainOfStores chainOfStores = new ChainOfStores();
            chainOfStores.AddShop("Tiffani");
            chainOfStores.Shops[0].AddProduct("Ring", 1700);

            Console.WriteLine($"{chainOfStores[0][0]}\n");
            Console.WriteLine($"{chainOfStores["Tiffani"][0]}\n");

            Console.WriteLine($"{chainOfStores[0]["Ring"]}\n");
            Console.WriteLine($"{chainOfStores["Tiffani"]["Ring"]}\n");
        }
    }
}