using System;
using System.Windows.Forms;
using Users.Model;
using Users.Presenter;

namespace Users
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


            var view = new UsersView();
            var model = new UsersModel();
            var presenter = new UsersPresenter(model, view);

            Application.Run(view);
        }
    }
}
