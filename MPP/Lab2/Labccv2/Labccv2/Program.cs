using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Labccv2.Service;
using Labccv2.Repository;
using System.IO;
using log4net;

namespace Labccv2
{
    static class Program
    {
        static private ILog logg = LogManager.GetLogger("Task");
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FileInfo fi = new FileInfo("log4nett.xml");
            log4net.Config.XmlConfigurator.Configure(fi);
            log4net.GlobalContext.Properties["host"] = Environment.MachineName;
            logg.Debug("test");

            OficiuRepository ofRep = new OficiuRepository();
            RezervareRepository rezRep = new RezervareRepository();
            DestinatieRepository destRep = new DestinatieRepository();

            OficiuService ofServ = new OficiuService(ofRep);
            RezervareService rezServ = new RezervareService(rezRep);
            DestinatieService destServ = new DestinatieService(destRep);

            Form1 f1 = new Form1();
            Form2 f2 = new Form2();
            f2.setData(rezServ, destServ, f2);
            f1.setData(f2, f1, ofServ);

            Application.Run(f1);

            

        }
    }
}
