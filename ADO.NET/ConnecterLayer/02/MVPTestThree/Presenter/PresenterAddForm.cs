using MVPTestThree.Model;
using MVPTestThree.View;
using System.Windows.Forms;

namespace MVPTestThree.Presenter
{
    class PresenterAddForm
    {
        private PersonModel model;
        private ViewAdd view;

        public PresenterAddForm(PersonModel model, ViewAdd view)
        {
            this.view = view;
            this.model = model;

            if (view.ShowDialog() == DialogResult.OK)
                model.people.Add(view.person);
        }
    }
}
