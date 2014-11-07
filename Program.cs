using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace LogicSim
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Debug.Listeners.Add(new ConsoleTraceListener());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
