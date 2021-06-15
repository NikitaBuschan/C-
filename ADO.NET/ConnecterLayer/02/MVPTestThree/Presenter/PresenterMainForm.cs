using MVPTestThree.Model;
using MVPTestThree.View;
using System;
using System.Runtime.InteropServices;

namespace MVPTestThree.Presenter
{
    class PresenterMainForm
    {
        private PersonModel model;
        private ViewMainForm view;

        public PresenterMainForm(ViewMainForm view, PersonModel model)
        {
            this.view = view;
            this.model = model;

            view.UpdatePerson += UpdatePerson;
            view.AddPerson += ViewAddPerson;
            view.EditPerson += ViewEditPerson;
            view.DeletePerson += DeletePerson;
            RefreshView();
            view.UpdateComboBox();
            view.SetFirstValueInComboBox();
        }
        private void ViewAddPerson(object sender, EventArgs e)
        {
            var addView = new ViewAdd();
            var addPresenter = new PresenterAddForm(model, addView);
        }

        private void ViewEditPerson(int index)
        {
            var editView = new ViewEditForm();
            var editPresenter = new PresenterEditForm(model, editView, index);
        }

        private void DeletePerson(int index)
        {
            model.people.Remove(model.people[index]);
            RefreshView();
        }

        private void UpdatePerson(int number)
        {
            model.person = model.people[number];
            RefreshView();
            view.UpdateWindow();
        }

        private void RefreshView()
        {
            view.person = model.person;
            view.people = model.people;
        }
    }
}
