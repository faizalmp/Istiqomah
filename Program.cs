using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Istiqomah
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {                        
            Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            RegistryKey add = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            add.SetValue("Istiqomah", "\"" + Application.ExecutablePath.ToString() + "\"");                       
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Process[] result = Process.GetProcessesByName("Istiqomah");
            if (result.Length > 1)
            {
                MessageBox.Show("Aplikasi telah dijalankan", "Peringatan");
                Application.Exit();
            }
            else
            {
                Application.Run(new Home_Page());
            }

        }
       
    }
}
