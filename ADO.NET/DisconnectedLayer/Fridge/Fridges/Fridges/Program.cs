using Fridges.Model;
using Fridges.Presenter;
using System;
using System.Windows.Forms;

namespace Fridges
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

            var model = new FridgeModel();
            var view = new FridgeView();

            var presenter = new FridgePresenter(model, view);

            Application.Run(view);
        }
    }
}
