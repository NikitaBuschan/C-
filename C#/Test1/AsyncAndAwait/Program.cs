using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncAndAwait
{
    class Program
    {
        static void Factorial(int n)
        {
            if (n < 1)
                throw new Exception($"{n} : число не должно быть меньше 1");

            int result = 1;
            for (int i = 1; i <= n; i++)
                result *= i;

            Console.WriteLine($"Факториал числа {n} равен {result}");
        }

        static async void FactorialAsync(int n)
        {
            try
            {
                await Task.Run(() => Factorial(n));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        static async Task Main(string[] args)
        {
            List<Task> tasks = new List<Task>() 
            {
                 Task.Run(() => FactorialAsync(4)),
                 Task.Run(() => FactorialAsync(-4))
            };

            await Task.WhenAll(tasks);
            Console.Read();
        }
    }
}
