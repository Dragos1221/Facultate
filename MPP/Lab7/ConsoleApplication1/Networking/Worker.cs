using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Service;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;

namespace Networking
{
    class Worker:IObserver
    {
        TcpClient client;
        IserviceOficiu offServ;
        IServiceDestinatii destServ;
        IServiceRezervare rezSrev;

        private NetworkStream stream;
        private IFormatter formatter;
        private  bool connected;

        public Worker(TcpClient client, IserviceOficiu offServ,
            IServiceDestinatii destServ, IServiceRezervare rezSrev)
        {
            this.offServ = offServ;
            this.destServ = destServ;
            this.rezSrev = rezSrev;
            this.client = client;
            try
            {

                stream = client.GetStream();
                formatter = new BinaryFormatter();
                connected = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public virtual  void run()
        {
            while(connected)
            {
                try
                {
                    object request = formatter.Deserialize(stream);
                    raspunde((Request)request);        
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            stream.Close();
            client.Close();
            
        }


        private void raspunde(Request r)
        {
            switch(r.getMesaj())
            {
                case "Login":
                    login(r);
                    break;
                case "Save":
                    save(r);
                    break;
                case "getRezervazri":
                    getRezervazri(r);
                    break;
                case "DestinatiiRep":
                    DestinatiiRep();
                        break;
                case "getDestinatie":
                    getDestinatie(r);
                    break;
                case "update":
                    update(r);
                    break;
                case "getIdDestinatie":
                    getIdDestinatie(r);
                    break;
                case "logout":
                    logout();
                    break;
            }
        }

        private void  writeResponse(Response resp)
        {
            formatter.Serialize(stream, resp);
            stream.Flush();
        }

        public void login(Request r)
        {
            bool b = offServ.logIn(r.getOficiu(),this);
            Response resp = new Response("ok");
            resp.setBol(b);
            writeResponse(resp);
        }

        public void save(Request r)
        {
            bool b = rezSrev.save(r.getRezervare());
            Response resp = new Response("ok");
            resp.setBol(b);
            writeResponse(resp);
            offServ.notifica(destServ.DestinatiiRep());
        }

        public void getRezervazri(Request r)
        {
            Response resp = new Response("ok");
            resp.setDs(rezSrev.getRezervazri( r.getId()));
            writeResponse(resp); ;
        }
        public void DestinatiiRep()
        {
            Response resp = new Response("ok");
            resp.setDs(destServ.DestinatiiRep());
            writeResponse(resp);
        }

        public void getDestinatie(Request r)
        {
            Response resp = new Response("ok");
            resp.setDestinatie(destServ.getDestinatie(r.getId()));
            writeResponse(resp);
        }
        public void update(Request r)
        {
            destServ.update(r.getDestinatie());
        }

       public void getIdDestinatie(Request r)
        {
            Response resp = new Response("ok");
            string[] list = r.getLocalDateTime().Split(' ');
            int luna =Int32.Parse(list[0].Split('/')[0]);
            int zi = Int32.Parse(list[0].Split('/')[1]);
            int an = Int32.Parse(list[0].Split('/')[2]);
            int ora = Int32.Parse(list[1].Split(':')[0]);
            int min = Int32.Parse(list[1].Split(':')[1]);
            DateTime t = new DateTime(an, luna, zi, ora, min, 0);
            resp.setId(destServ.getIdDestinatie(r.getDestinatieStr(), t));
            writeResponse(resp);
        }

        public void reloadList(DataSet d)
        {
            Response resp = new Response("Observer");
            resp.setDs(d);
            writeResponse(resp);
        }

        public void logout()
        {
            Response r = new Response("logout");
            writeResponse(r);
            connected = false;
        }
    }
}
