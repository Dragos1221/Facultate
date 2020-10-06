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
   public  class DestinatieProxy:IServiceDestinatii
    {
        NetworkStream stream;
        BinaryFormatter formatter;
        TcpClient connection;
        ReadRespone r;

        public DestinatieProxy(NetworkStream s ,TcpClient c  , ReadRespone rr)
        {
            stream = s;
            connection = c;
            r = rr;
            formatter = new BinaryFormatter();
        }

        public DataSet DestinatiiRep()
        {
            Request req = new Request("DestinatiiRep");
            formatter.Serialize(stream, req);
            stream.Flush();
            Response re = r.readResponse();
            if(re.getMesaj().Equals("ok"))
            {
                return re.getDs();
            }
            return null;
        }

        public int getIdDestinatie(string destinatie, DateTime timp)
        {
            Request req = new Request("getIdDestinatie");
            req.setLocalDateTime(timp.ToString());
            req.setDestinatieStr(destinatie);
            formatter.Serialize(stream, req);
            stream.Flush();
            Response re = r.readResponse();
            if (re.getMesaj().Equals("ok"))
            {
                return re.getId();
            }
            return -1;

        }

        public Destinatie getDestinatie(int idDest)
        {
            Request req = new Request("getDestinatie");
            req.setId(idDest);
            formatter.Serialize(stream, req);
            stream.Flush();
            Response resp = r.readResponse();
            if(resp.getMesaj().Equals("ok"))
            {
                return resp.getDestinatie();
            }
            return null;

        }

        public void update(Destinatie dest)
        {
            Request req = new Request("update");
            req.setDestinatie(dest);
            formatter.Serialize(stream, req);
            stream.Flush();
        }
    }
}
