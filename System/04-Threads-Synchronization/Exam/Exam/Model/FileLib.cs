using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Exam.Model
{
    public class FileLib
    {
        private static string FilePathWithWords { get; set; } = "WordsList.txt";
        public static List<string> FilesList { get; set; } = new List<string>();
        public static string File { get; set; }
        public static event EventHandler NewWord;

        public static List<string> ReadFromFile()
        {
            List<string> list = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(FilePathWithWords, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                        list.Add(line);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("List is empty, add words and save them then", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return list;
        }
        public static void SaveToFile(List<string> words)
        {
            using (StreamWriter sw = new StreamWriter(FilePathWithWords, false, System.Text.Encoding.Default))
                foreach (var word in words)
                    sw.WriteLine(word);
        }

        public static void SearchFiles(List<string> list)
        {
            DriveInfo[] drive = DriveInfo.GetDrives();

            foreach (var disk in drive)
                if (disk.DriveType != DriveType.CDRom)
                    GetCollection(list, disk.Name);
        }

        private static void GetCollection(List<string> list, string dir)
        {
            try
            {
                foreach (var folder in Directory.GetDirectories(dir))
                {
                    GetCollection(list, folder);
                }

                foreach (var file in Directory.GetFiles(dir))
                {
                    using (StreamReader sr = new StreamReader(file, System.Text.Encoding.Default))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            foreach (var item in list)
                            {
                                if (item == line)
                                {
                                    File = file;
                                    NewWord?.Invoke(item, EventArgs.Empty);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
