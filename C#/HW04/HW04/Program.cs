using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW04
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            student.Field();
            Console.WriteLine();
            student.Print();
        }
    }
}
