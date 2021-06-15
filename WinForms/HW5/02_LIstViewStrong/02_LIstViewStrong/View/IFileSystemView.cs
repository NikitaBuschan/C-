using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_LIstViewStrong.View
{
    public interface IFileSystemView
    {
        List<string> GetComboBoxList();
        void FillComboBoxList();
    }
}
