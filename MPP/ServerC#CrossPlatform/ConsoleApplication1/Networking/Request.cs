using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Service;

namespace Networking
{
   [Serializable] public class Request
    {
        private int id;
        private String mesaj;
        private Oficiu oficiu;
        private Rezervare rezervare;
        private Destinatie destinatie;
        private String localDateTime;
        private String destinatieStr;
       

        public String getLocalDateTime()
        {
            return localDateTime;
        }

        public void setLocalDateTime(String localDateTime)
        {
            this.localDateTime = localDateTime;
        }

        public String getDestinatieStr()
        {
            return destinatieStr;
        }

        public void setDestinatieStr(String destinatieStr)
        {
            this.destinatieStr = destinatieStr;
        }

        public Destinatie getDestinatie()
        {
            return destinatie;
        }

        public void setDestinatie(Destinatie destinatie)
        {
            this.destinatie = destinatie;
        }

        public Rezervare getRezervare()
        {
            return rezervare;
        }

        public void setRezervare(Rezervare rezervare)
        {
            this.rezervare = rezervare;
        }

        public Request(String mesaj)
        {
            this.mesaj = mesaj;
        }

        public String getMesaj()
        {
            return mesaj;
        }

        public void setMesaj(String mesaj)
        {
            this.mesaj = mesaj;
        }

        public Oficiu getOficiu()
        {
            return oficiu;
        }

        public void setOficiu(Oficiu user)
        {
            this.oficiu = user;
        }

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }
    }
}
