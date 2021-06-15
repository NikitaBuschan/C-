using System;

namespace Catalog.View
{
    public interface ICatalogView
    {
        event EventHandler CreateNewWindow;

        string GetPath();
    }
}
