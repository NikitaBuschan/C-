using System.Threading;
using System.Windows.Forms;

namespace sumOfNumbers.View
{
    public class MyThread
    {
        public Thread thread { get; set; }
        public Label label { get; set; }
        public int number { get; set; }
        public int interval { get; set; }

        public MyThread(Thread _thread, Label lbl, int _number, int _interval)
        {
            thread = _thread;
            label = lbl;
            number = _number;
            interval = _interval;
        }
    }
}
