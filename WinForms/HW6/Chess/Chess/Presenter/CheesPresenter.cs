using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Model;
using Chess.View;

namespace Chess.Presenter
{
    class CheesPresenter
    {
        private ICheesModel _model;
        private ICheesView _view;

        public CheesPresenter(ICheesModel model, ICheesView view)
        {
            _model = model;
            _view = view;

            _view.FillDesk += FillDesk;
        }

        private void FillDesk(object sender, EventArgs e)
        {
            _view.PaintDesk();
            _view.PutFigureOnDesk();
        }
    }
}
