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
    public class RezervareProxy:IServiceRezervare
    {
        NetworkStream stream;
        BinaryFormatter formatter;
        TcpClient connection;
        ReadRespone r;

        public  RezervareProxy(NetworkStream s , TcpClient c , ReadRespone rr)
        {
            r = rr;
            stream = s;
            connection = c;
            formatter = new BinaryFormatter();
        }

        public DataSet getRezervazri( int id)
        {
            Request req = new Request("getRezervazri");
            req.setId(id);
            formatter.Serialize(stream, req);
            stream.Flush();
            Response re = r.readResponse();
            if (re.getMesaj().Equals("ok"))
            {
                return re.getDs();
                
            }
            return null;
        }

        public bool save(Rezervare rez)
        {
            Request req = new Request("Save");
            req.setRezervare(rez);
            formatter.Serialize(stream, req);
            stream.Flush();
            Response re = r.readResponse();
            if(re.getMesaj().Equals("ok"))
            {
                return re.getBol();
            }
            return false;  
        }

        
    }
}
