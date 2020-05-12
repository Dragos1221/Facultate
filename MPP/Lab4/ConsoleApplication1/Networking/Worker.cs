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
using Model;
using Protocol;
using proto = Protocol;
using Google.Protobuf;
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
                    //object request = formatter.Deserialize(stream);
                    Request request = Request.Parser.ParseDelimitedFrom(stream);
                    raspunde(request);        
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
            switch(r.Mess)
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
                case "getListDestinatii":
                    DestinatiiRep();
                        break;
                case "getDestinatie":
                    getDestinatie(r);
                    break;
                case "Update":
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
            resp.WriteDelimitedTo(stream);
            stream.Flush();
        }

        public void login(Request r)
        {
            Oficiu of = new Oficiu(r.User.Username, r.User.Passwdord);
            bool b = offServ.logIn(of,this);
            proto.Response respp = new proto.Response { Mess = "ok", RBool = b };
            writeResponse(respp);
        }

        public void save(Request r)
        {
            Model.Rezervare rez = new Model.Rezervare(r.Rezervare.IdDestinatie, r.Rezervare.LocuriOcupate, r.Rezervare.Nume);
            bool b = rezSrev.save(rez);
            proto.Response resp = new proto.Response { Mess = "ok", RBool = b };
            writeResponse(resp);
            offServ.notifica(destServ.DestinatiiRep());
        }

        public void getRezervazri(Request r)
        {
            List<Model.Rezervare> list = rezSrev.getLista(r.Id);
            proto.Response resp = new proto.Response {Mess="ok" };
            foreach(Model.Rezervare rez in list)
            {
                resp.ListaRezervari.Add(new proto.Rezervare { IdDestinatie = rez.IdDestinatie, LocuriOcupate = rez.LocuriRezervate1, Nume = rez.Nume1 });
            }
           writeResponse(resp); ;
        }
        public void DestinatiiRep()
        {
            proto.Response resp = new proto.Response { Mess = "ok" };
            List<Model.Destinatie> list = destServ.returnList();
            foreach(Model.Destinatie dest in list)
            {
                resp.ListaDestinatii.Add(new proto.Destinatie
                {
                    Id = dest.Id,
                    LocuriDisponibile = dest.LocuriDisponibile1,
                    LocuriOcupate = dest.LocuriOcupate1,
                    An = dest.Local.Year,
                    Luna = dest.Local.Month,
                    Zi = dest.Local.Day,
                    Ora = dest.Local.Hour,
                    Minute = dest.Local.Minute,
                    Destinatie_ = dest.DestinatieStr1
                    
                });
            }
            writeResponse(resp);
        }

        public void getDestinatie(Request r)
        {
            //Response resp = new Response("ok");
            Model.Destinatie dest = destServ.getDestinatie(r.Id);
            proto.Destinatie d = new proto.Destinatie {
                Id = dest.Id,
                LocuriDisponibile = dest.LocuriDisponibile1,
                LocuriOcupate = dest.LocuriOcupate1,
                An = dest.Local.Year,
                Luna = dest.Local.Month,
                Zi = dest.Local.Day,
                Ora = dest.Local.Hour,
                Minute = dest.Local.Minute
            };
            proto.Response resp = new proto.Response { Mess = "ok" };
            resp.ListaDestinatii.Add(d);
            writeResponse(resp);
        }
        public void update(Request r)
        {
            int luna = r.DestObj.Luna;
            int zi = r.DestObj.Zi;
            int an = r.DestObj.An;
            int ora = r.DestObj.Ora;
            int min = r.DestObj.Minute;
            DateTime t = new DateTime(an, luna, zi, ora, min, 0);
            Model.Destinatie dest = new Model.Destinatie(r.DestObj.Id, r.DestObj.LocuriDisponibile,
                r.DestObj.LocuriOcupate, r.DestObj.Destinatie_, t);
            destServ.update(dest);
        }

       public void getIdDestinatie(Request r)
        {
            int luna = r.Luna;
            int zi = r.Zi;
            int an = r.An;
            int ora = r.Ora;
            int min = r.Minute;
            DateTime t = new DateTime(an, luna, zi, ora, min, 0);
            int id = destServ.getIdDestinatie(r.DestinatieStr, t);
            proto.Response resp = new proto.Response { Id = id, Mess = "ok" };
            writeResponse(resp);
        }

        public void reloadList(DataSet d)
        {
            //Response resp = new Response("Observer");
            proto.Response resp = new proto.Response { Mess = "Observer" };
            List<Model.Destinatie> list = destServ.returnList();
            foreach (Model.Destinatie dest in list)
            {
                resp.ListaDestinatii.Add(new proto.Destinatie
                {
                    Id = dest.Id,
                    LocuriDisponibile = dest.LocuriDisponibile1,
                    LocuriOcupate = dest.LocuriOcupate1,
                    An = dest.Local.Year,
                    Luna = dest.Local.Month,
                    Zi = dest.Local.Day,
                    Ora = dest.Local.Hour,
                    Minute = dest.Local.Minute,
                    Destinatie_ = dest.DestinatieStr1

                });
            }
            writeResponse(resp);
        }

        public void logout()
        {
            proto.Response r = new Response { Mess = "logout" };
            writeResponse(r);
            connected = false;
        }
    }
}
