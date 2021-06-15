using sumOfNumbers.View;

namespace sumOfNumbers.Model
{
    public interface ISumOfNumberModel
    {
        MyThread FirstThread { get; set; }
        MyThread SecondThread { get; set; }
    }
}
