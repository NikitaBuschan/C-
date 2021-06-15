using sumOfNumbers.Presenter;
using sumOfNumbers.View;
using System;
using System.Windows.Forms;

namespace sumOfNumbers
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var view = new SumOfNumbersView();
            var model = new SumOfNumberModel();
            var presenter = new SumOfNumberPresenter(model, view);

            Application.Run(view);
        }
    }
}
