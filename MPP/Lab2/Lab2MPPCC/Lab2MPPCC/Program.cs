using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Lab2MPPCC
{
    static class Program
    {
        private static readonly ILog log = LogManager.GetLogger("Repooooooo");
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            ConnectionStringSettings con = ConfigurationManager.ConnectionStrings["testDb"];
            var var1Value = ConfigurationManager.AppSettings["testDb"];

        }
    }
}
