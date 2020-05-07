namespace Lab2MPPC.Domain
{
    public class Rezervare
    {
        private int idDestinatie;
        private int LocuriRezervate;
        private string Nume;

        public Rezervare(int idDestinatie, int locuriRezervate, string nume)
        {
            this.idDestinatie = idDestinatie;
            LocuriRezervate = locuriRezervate;
            Nume = nume;
        }

        public int IdDestinatie
        {
            get { return idDestinatie; }
            set { idDestinatie = value; }
        }

        public int LocuriRezervate1
        {
            get { return LocuriRezervate; }
            set { LocuriRezervate = value; }
        }

        public string Nume1
        {
            get { return Nume; }
            set { Nume = value; }
        }
    }
}