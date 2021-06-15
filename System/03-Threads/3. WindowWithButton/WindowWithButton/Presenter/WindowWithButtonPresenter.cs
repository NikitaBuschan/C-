using System;
using WindowWithButton.Model;
using WindowWithButton.View;

namespace WindowWithButton.Presenter
{
    class WindowWithButtonPresenter
    {
        IWindowWithButtonModel Model { get; set; }
        IWindowWithButtonView View { get; set; }

        public WindowWithButtonPresenter(IWindowWithButtonModel model, IWindowWithButtonView view)
        {
            Model = model;
            View = view;

            View.CreateNewWindow += CreateWindow;
        }

        private void CreateWindow(object sender, EventArgs e)
        {
            var window = new NonModalWindowView();
        }
    }
}
