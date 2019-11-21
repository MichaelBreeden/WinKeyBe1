using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace WinKeyBe1
{
    static class Program
    {
        static public Process myProcess { get; set; }
        static public bool bWasStarted { get; set; }
        static public int iCounter { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bWasStarted = false;
            iCounter = 0;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
