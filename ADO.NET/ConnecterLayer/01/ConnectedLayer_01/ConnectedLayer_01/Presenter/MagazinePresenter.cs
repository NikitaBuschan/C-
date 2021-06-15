using ConnectedLayer_01.Model;
using System;

namespace ConnectedLayer_01
{
    public class MagazinePresenter
    {
        private IMagazineModel _model;
        private IMagazineView _view;

        public MagazinePresenter(IMagazineModel model, IMagazineView view)
        {
            _view = view;
            _model = model;

            view.ShowList += Show;
        }

        private void Show(object sender, EventArgs e)
        {
            _view.MainForm_Load();
            _model.Item = _view.Item;
        }
    }
}
