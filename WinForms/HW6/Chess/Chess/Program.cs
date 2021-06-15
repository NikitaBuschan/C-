using Chess.Model;
using Chess.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
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

            CheesModel model = new CheesModel();
            CheesView view = new CheesView();

            CheesPresenter presenter = new CheesPresenter(model, view);
            Application.Run(view);
        }
    }
}
