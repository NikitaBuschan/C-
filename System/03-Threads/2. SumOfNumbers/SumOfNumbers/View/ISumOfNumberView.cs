using System;

namespace sumOfNumbers.View
{
    public interface ISumOfNumberView
    {
        event EventHandler CreateFirstThreadEvent;
        event EventHandler CreateSecondThreadEvent;
        MyThread FirstThread { get; set; }
        MyThread SecondThread { get; set; }

        void CreateFirstThread();
        void CreateSecondThread();
    }
}
