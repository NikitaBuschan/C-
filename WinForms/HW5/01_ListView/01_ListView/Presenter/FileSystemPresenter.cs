using _01_ListView.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ListView.Presenter
{
    public class FileSystemPresenter
    {
        IFileSystemModel model;
        IFileSystemView view;

        public FileSystemPresenter(IFileSystemModel model, IFileSystemView view)
        {
            this.model = model;
            this.view = view;

            this.model.drive = model.GetDrives();
            this.view.FillTreeView(model.drive);
        }
    }
}
