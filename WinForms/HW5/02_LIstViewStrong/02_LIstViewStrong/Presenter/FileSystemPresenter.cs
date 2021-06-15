using _02_LIstViewStrong.Model;
using _02_LIstViewStrong.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_LIstViewStrong.Presenter
{
    class FileSystemPresenter
    {
        IFIleSysterModel _model;
        IFileSystemView _view;

        public FileSystemPresenter(IFIleSysterModel model, IFileSystemView view)
        {
            _model = model;
            _view = view;

            view.FillComboBoxList();
           
        }
    }
}
