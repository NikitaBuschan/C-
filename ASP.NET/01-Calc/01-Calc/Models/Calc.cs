namespace _01_Calc.Models
{
    public class Calc
    {
        public int a { get; set; }
        public int b { get; set; }
        public char operation { get; set; }

        public int makeCalc()
        {
            switch (operation)
            {
                case '+': return a + b;
                case '-': return a - b;
                case '/': return a / b;
                case '*': return a * b;
            }
            return 0;
        }
    }
}
