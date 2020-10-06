using System;

namespace Labccv2.Domain
{
    public class Destinatie
    {
        private int id;
        private int LocuriDisponibile;
        private int LocuriOcupate;
        private string DestinatieStr;
        private DateTime local;

        public Destinatie(int id, int locuriDisponibile, int locuriOcupate, string destinatieStr, DateTime local)
        {
            this.id = id;
            LocuriDisponibile = locuriDisponibile;
            LocuriOcupate = locuriOcupate;
            DestinatieStr = destinatieStr;
            this.local = local;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int LocuriDisponibile1
        {
            get { return LocuriDisponibile; }
            set { LocuriDisponibile = value; }
        }

        public int LocuriOcupate1
        {
            get { return LocuriOcupate; }
            set { LocuriOcupate = value; }
        }

        public string DestinatieStr1
        {
            get { return DestinatieStr; }
            set { DestinatieStr = value; }
        }

        public DateTime Local
        {
            get { return local; }
            set { local = value; }
        }
    }
}