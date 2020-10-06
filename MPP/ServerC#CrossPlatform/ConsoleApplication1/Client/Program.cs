using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Persistence;
using Service;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using Networking;

namespace Client
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
            OficiuRepository ofRep = new OficiuRepository();
            RezervareRepository rezRep = new RezervareRepository();
            DestinatieRepository destRep = new DestinatieRepository();

            TcpClient connection = new TcpClient("127.0.0.1", 55555);
            NetworkStream stream = connection.GetStream();
            BinaryFormatter formatter = new BinaryFormatter();
            ReadRespone r = new ReadRespone(stream, connection);
            r.startReader();

            IserviceOficiu ofServ = new OficiuProxy(stream, connection, r);
            IServiceRezervare rezServ = new RezervareProxy(stream, connection, r);
            //IServiceRezervare rezServ = new RezervareService(rezRep);
            IServiceDestinatii destServ = new DestinatieProxy(stream, connection, r);



           

            Form1 f1 = new Form1();
            Form2 f2 = new Form2();
            f2.setData(rezServ, destServ, f2);
            f1.setData(f2, f1, ofServ);

            Application.Run(f1);

        }
    }
}
