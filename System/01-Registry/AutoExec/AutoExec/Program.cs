using Microsoft.Win32;
using System;
using System.Diagnostics;

namespace AutoExec
{
    class Program
    {
        static void Main(string[] args)
        {
            const string fileName = "AutoExec";
            const string pathProgramm = "Software";
            const string pathAutoRun = @"Software\Microsoft\Windows\CurrentVersion\Run";

            try
            {
                using (Registry.CurrentUser.OpenSubKey(pathProgramm, true).CreateSubKey(fileName))
                    using (var key = Registry.CurrentUser.OpenSubKey($@"{pathProgramm}\{fileName}", true))
                        key.SetValue("Date time", DateTime.Now);

                using (var key = Registry.CurrentUser.OpenSubKey(pathAutoRun, true))
                    key.SetValue(fileName, Process.GetCurrentProcess().MainModule.FileName);
            }
            catch (Exception)
            {
                Console.WriteLine("No current");
            }
        }
    }
}