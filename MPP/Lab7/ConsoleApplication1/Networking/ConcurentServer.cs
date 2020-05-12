using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Service;

namespace Networking
{
    public class ConcurentServer : AbstractServer
    {
        IserviceOficiu offServ;
        IServiceDestinatii destServ;
        IServiceRezervare rezSrev;
        public ConcurentServer(string host, int port, IserviceOficiu offServ,
            IServiceDestinatii destServ,IServiceRezervare rezSrev) : base(host, port)
        {
            this.destServ = destServ;
            this.offServ = offServ;
            this.rezSrev = rezSrev;
        }

        public override void processRequest(TcpClient client)
        {
            Thread t = createWorker(client);
            t.Start();
        }

        public Thread createWorker(TcpClient client)
        {
            Worker worker = new Worker(client,offServ,destServ,rezSrev);
            return new Thread(new ThreadStart(worker.run));
        }

        
    }
}
