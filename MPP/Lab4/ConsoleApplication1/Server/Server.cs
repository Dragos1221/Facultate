using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence;
using Networking;
using Model;

namespace Server
{
    class Program
    {
     
       
        static void Main(string[] args)
        {
            RezervareRepository rezRep = new RezervareRepository();
            DestinatieRepository destRep = new DestinatieRepository();
            IOficiuRep offRep =  new OficiuRepository();
            IserviceOficiu offServ = new OficiuService(offRep);
            IServiceDestinatii destServ = new DestinatieService(destRep);
            IServiceRezervare rezSrev = new RezervareService(rezRep);

          // Console.WriteLine(offServ.logIn(new Oficiu("cont1","parola")));
            AbstractServer server = new ConcurentServer("127.0.0.1", 55555, offServ, destServ, rezSrev);
            server.Start();

    }

       

    }
}
