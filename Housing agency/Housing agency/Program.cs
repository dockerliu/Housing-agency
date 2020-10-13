using Housing_agency.HouseSource;
using Housing_agency.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Housing_agency
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormAddHouse());
        }
    }
}
