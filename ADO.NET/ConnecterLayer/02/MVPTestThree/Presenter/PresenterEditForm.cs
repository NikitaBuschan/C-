using MVPTestThree.Model;
using MVPTestThree.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVPTestThree.Presenter
{
    class PresenterEditForm
    {
        private PersonModel model;
        private ViewEditForm view;

        public PresenterEditForm(PersonModel model, ViewEditForm view, int index)
        {
            this.view = view;
            this.model = model;

            view.person = model.people[index];
            view.UpdateWindow();

            if (view.ShowDialog() == DialogResult.OK)
            {
                model.EditPerson(index, view.person);
                model.person = view.person;
            }
        }
    }
}
