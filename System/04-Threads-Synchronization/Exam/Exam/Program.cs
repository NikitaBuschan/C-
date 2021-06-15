using System;
using Exam.Model;
using System.Windows.Forms;
using Exam.Presenter;

namespace Exam
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

            var model = new ForbiddenWordsModel();
            var view = new ForbiddenWordsView();
            var presenter = new ForbiddenWordsPresenter(model, view);

            Application.Run(view);
        }
    }
}
