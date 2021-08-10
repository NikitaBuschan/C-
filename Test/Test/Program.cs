using System;
using System.Collections;
using System.Collections.Generic;

namespace Test
{
    class Person
    {
        public List<string> Names;

        ~Person()
        {
            Console.Beep();
            Console.WriteLine("Disposed");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Test();
            GC.Collect();

        }

        private static void Test()
        {
            Person person = new Person();
        }
    }
}
