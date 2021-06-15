using sumOfNumbers.Model;
using sumOfNumbers.View;

namespace sumOfNumbers
{
    public class SumOfNumberModel : ISumOfNumberModel
    {
        public MyThread FirstThread { get; set; }
        public MyThread SecondThread { get; set; }
    }
}
