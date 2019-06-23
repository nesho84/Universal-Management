using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;
using System.Threading;

namespace Universal_Management
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Runing aplication as Administrator
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                WindowsIdentity identity = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
                {
                    MessageBox.Show("Sie müssen diese Anwendung als Administrator ausführen!");
                    Application.Exit();
                }
                else
                {
                    //check duplicate run
                    checkSingleInstance();
                }
            }
            catch (Exception ex)
            {
                if (ex != null) { }
            }
        }

        //Function to Avoid runing aplication multiple times        
        public static bool checkSingleInstance()
        {
            string procName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            // get the list of all processes by that name

            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName(procName);

            if (processes.Length > 1)
            {
                Thread.Sleep(500);
                if (processes.Length > 1)
                {
                    MessageBox.Show("Programm bereits ausgeführt.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Application.Exit();
                    return true;
                }
                return true;
            }
            else
            {
                Application.Run(new SplashScreen());
                return false;
            }
        }
    }
}
