using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Model;
using Service;

namespace Networking
{
    public class OficiuProxy:IserviceOficiu
    {
        IObserver obs;
        NetworkStream stream;
        BinaryFormatter formatter;
        TcpClient connection;
        ReadRespone r;

        public OficiuProxy(NetworkStream straam , TcpClient connection , ReadRespone rr)
        {
            this.connection = connection;
            this.stream = straam;
            r = rr;
            formatter = new BinaryFormatter();
        }

        public bool logIn(Oficiu of, IObserver o)
        {
            obs = o;
            r.setObserver(this);
            Request re = new Request("Login");
            re.setOficiu(of);
            formatter.Serialize(stream, re);
            stream.Flush();
            Response res = r.readResponse();
            if (res.getMesaj().Equals("ok"))
            {
                return true;
            }

            throw new NotImplementedException();
        }

        public void notifica(DataSet s)
        {
            Task.Run(() => obs.reloadList(s));
        }

        public void closeConection()
        {
            Request re = new Request("logout");
            r.logout();
            formatter.Serialize(stream, re);
            stream.Flush();
        }
    }
}
