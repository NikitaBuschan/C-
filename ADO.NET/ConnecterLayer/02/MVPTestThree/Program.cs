using MVPTestThree.Model;
using MVPTestThree.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVPTestThree
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

            PersonModel model = new PersonModel();
            ViewMainForm view = new ViewMainForm();
            PresenterMainForm presenter = new PresenterMainForm(view, model);

            Application.Run(view);
        }
    }
}
