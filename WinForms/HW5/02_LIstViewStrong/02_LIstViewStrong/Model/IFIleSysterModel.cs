using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_LIstViewStrong.Model
{
    public interface IFIleSysterModel
    {
        DriveInfo[] drives { get; set; }

        DriveInfo[] GetDriveInfos();
    }
}
