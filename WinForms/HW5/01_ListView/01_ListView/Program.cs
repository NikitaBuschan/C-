using _01_ListView.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_ListView
{
    static class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var model = new FileSystemModel();
            var view = new FileSystemvView();
            
            var presenter = new FileSystemPresenter(model, view);

            Application.Run(view);
        }
    }
}
