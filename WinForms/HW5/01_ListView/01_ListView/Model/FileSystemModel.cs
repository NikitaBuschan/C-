using _01_ListView.Model;
using System.IO;

namespace _01_ListView
{
    public class FileSystemModel : IFileSystemModel
    {
        public DriveInfo[] drive { get; set; }

        public DriveInfo[] GetDrives() => DriveInfo.GetDrives();
    }
}
