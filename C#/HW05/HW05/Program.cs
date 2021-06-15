using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HW05
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 10;
            int y = 6;
            Decision decision = new Decision();
            decision.linearEquation.Input(decision.linearEquation.equation);
            decision.linearEquation.Check(decision.linearEquation.equation);
            decision.linearEquation.GetAB(decision.linearEquation.equation, ref x, ref y);
            decision.Calculate(ref x, ref y);
            decision.linearEquation.Input(decision.linearEquation.secondEquation);
            decision.linearEquation.Check(decision.linearEquation.secondEquation);
            decision.linearEquation.GetAB(decision.linearEquation.secondEquation, ref x, ref y);
            decision.CalculateTwoEquation(decision.linearEquation, ref x, ref y);
        }
    }
}