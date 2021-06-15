using System;
using System.Windows.Forms;
using WindowWithButton.Model;
using WindowWithButton.Presenter;

namespace WindowWithButton
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


            var view = new WindowWithButtonView();
            var model = new WindowWithButtonModel();
            var presenter = new WindowWithButtonPresenter(model, view);

            Application.Run(view);
        }
    }
}
