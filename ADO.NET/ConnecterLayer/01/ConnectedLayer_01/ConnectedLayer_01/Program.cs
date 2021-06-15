using System;
using System.Windows.Forms;

namespace ConnectedLayer_01
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MagazineModel model = new MagazineModel();
            MagazineView view = new MagazineView();
            MagazinePresenter presenter = new MagazinePresenter(model, view);

            Application.Run(view);
        }
    }
}
