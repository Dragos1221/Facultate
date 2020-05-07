using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BDLab2
{
    public class Informatii
    {

        private string tabel1;
        private string Tabel2;
        private string StringConnection;
        private string Coloana;

        public Informatii(string t1, string t2, string con, string c)
        {
            tabel1 = t1;
            Tabel2 = t2;
            StringConnection = con;
            Coloana = c;
        }

        public string tabel11
        {
            get { return tabel1; }
            set { tabel1 = value; }
        }

       public string Tabel22
        {
            set { Tabel2 = value; }
            get { return Tabel2; }
        }

      public  string StringConnection1
        {
            set { StringConnection = value; }
            get { return StringConnection; }
        }

       public string Coloana1
        {
            set { Coloana = value; }
            get { return Coloana; }
        }


    }
}
