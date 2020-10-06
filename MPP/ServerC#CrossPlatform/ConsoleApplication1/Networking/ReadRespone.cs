using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Service;

namespace Networking
{
    public class ReadRespone
    {
        IserviceOficiu client;
        private Queue<Response> list;
        private bool finished;
        NetworkStream stream;
        BinaryFormatter formatter;
        TcpClient connection;
        private EventWaitHandle _waitHandle= new AutoResetEvent(false);

        public ReadRespone(NetworkStream stream , TcpClient connection)
        {
            this.stream = stream;
            this.connection = connection;
            formatter = new BinaryFormatter();
            finished = false;
            list = new Queue<Response>();
        }

        public void setObserver(IserviceOficiu o)
        {
            client = o;
        }

        public Response readResponse()
        {
            _waitHandle.WaitOne();
            Response response = null;
            response = list.Dequeue();
            return response;
        }

        public void startReader()
        {
            Thread tw = new Thread(run);
            tw.Start();
        }

        public void logout()
        {
            finished = true;
        }

        public virtual void run()
        {
            while (!finished)
            {    
                    object response = formatter.Deserialize(stream);
                    Response r = (Response)response;
                    Console.WriteLine("response received " + response);
                if (r.getMesaj().Equals("Observer"))
                {
                    client.notifica(r.getDs());
                }
                if (r.getMesaj().Equals("logout"))
                {
                    stream.Close();
                    connection.Close();
                }
                else
                {
                    list.Enqueue((Response)response);
                    _waitHandle.Set();
                }
            }
        }
    }
}
