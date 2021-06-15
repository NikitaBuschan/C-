using sumOfNumbers.Model;
using sumOfNumbers.View;

namespace sumOfNumbers.Presenter
{
    public class SumOfNumberPresenter
    {
        private ISumOfNumberModel Model { get; set; }
        private ISumOfNumberView View { get; set; }

        public SumOfNumberPresenter(ISumOfNumberModel _model, ISumOfNumberView _view)
        {
            Model = _model;
            View = _view;

            View.CreateFirstThreadEvent += (o, e) =>
            {
                View.CreateFirstThread();
                Model.FirstThread = View.FirstThread;
            };
            View.CreateSecondThreadEvent += (o, e) =>
            {
                View.CreateSecondThread();
                Model.SecondThread = View.SecondThread;
            };
        }
    }
}
