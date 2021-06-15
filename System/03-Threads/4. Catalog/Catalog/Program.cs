using Catalog.Model;
using Catalog.Presenter;
using Catalog.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catalog
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

            var view = new CatalogView();
            var model = new CatalogModel();
            var presenter = new CatalogPresenter(model, view);

            Application.Run(view);
        }
    }
}
