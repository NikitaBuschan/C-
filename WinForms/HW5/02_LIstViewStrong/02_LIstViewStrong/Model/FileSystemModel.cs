using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_LIstViewStrong.Model
{
    class FileSystemModel : IFIleSysterModel
    {
        public DriveInfo[] drives { get; set; }

        public DriveInfo[] GetDriveInfos() => DriveInfo.GetDrives();
    }
}
