using System.IO;

namespace _01_ListView.Model
{
    public interface IFileSystemModel
    {
        DriveInfo[] drive { get; set; }

        DriveInfo[] GetDrives();
    }
}
