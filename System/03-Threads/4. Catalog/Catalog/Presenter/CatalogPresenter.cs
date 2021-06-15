using Catalog.Model;
using Catalog.Properties;
using Catalog.View;
using System;

namespace Catalog.Presenter
{
    public class CatalogPresenter
    {
        private ICatalogModel Model { get; set; }
        private ICatalogView View { get; set; }

        public CatalogPresenter(ICatalogModel model, ICatalogView view)
        {
            Model = model;
            View = view;

            view.CreateNewWindow += CreateWindow;
        }

        private void CreateWindow(object sender, EventArgs e)
        {
            var window = new InfoView(View.GetPath());
        }
    }
}
