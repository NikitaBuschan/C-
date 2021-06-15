using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ListView
{
    public interface IFileSystemView
    {
        void FillTreeView(DriveInfo[] drive);
    }
}
