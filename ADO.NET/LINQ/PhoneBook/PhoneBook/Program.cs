using PhoneBook.Model;
using PhoneBook.Presenter;
using System;
using System.Windows.Forms;

namespace PhoneBook
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

            var model = new PhoneBookModel();
            var view = new PhoneBookView();
            var presenter = new PhoneBookPresenter(view, model);

            Application.Run(view);
        }
    }
}
