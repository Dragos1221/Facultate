using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
    [Serializable] public class Response
    {
        private List<Rezervare> list;
        private List<Destinatie> listDestinatii;
        private String mesaj;
        private Boolean bol;
        private Destinatie destinatie;
        private int id;
        private DataSet ds;
        private IObserver o;

        public void setObs(IObserver o)
        {
            this.o = o;
        }
        public IObserver getObs()
        {
            return o;
        }

        public DataSet getDs()
        {
            return ds;
        }

        public void setDs(DataSet dss)
        {
            ds = dss;
        }

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public Destinatie getDestinatie()
        {
            return destinatie;
        }

        public void setDestinatie(Destinatie destinatie)
        {
            this.destinatie = destinatie;
        }

        public List<Destinatie> getListDestinatii()
        {
            return listDestinatii;
        }

        public void setListDestinatii(List<Destinatie> listDestinatii)
        {
            this.listDestinatii = listDestinatii;
        }

        public Response(String Mesaj)
        {
            this.mesaj = Mesaj;
        }

        public String getMesaj()
        {
            return mesaj;
        }

        public void setMesaj(String mesaj)
        {
            this.mesaj = mesaj;
        }

        public Boolean getBol()
        {
            return bol;
        }

        public List<Rezervare> getList()
        {
            return list;
        }

        public void setList(List<Rezervare> list)
        {
            this.list = list;
        }

        public void setBol(Boolean bol)
        {
            this.bol = bol;
        }
    }
}
