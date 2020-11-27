using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LojaRoupas.obj;
namespace LojaRoupas
{
    static class Program
    {
        /// <summary>F
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Cliente());
        }
    }
}
