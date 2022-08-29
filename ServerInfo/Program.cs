using System;
using System.Windows.Forms;

namespace ServerInfo
{

    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //new SerialPortProgram();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Configuration());
            Application.Run(new TaskTrayContext());
        }
    }
}
