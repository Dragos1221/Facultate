using log4net;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Persistence
{
    public class RezervareRepository : IRezervareRep
    {
        static private ILog logg = LogManager.GetLogger("Task");

        public RezervareRepository()
        {
          
        }

        public List<Rezervare> getList(int idDestinatie)
        {
            List<Rezervare> list = new List<Rezervare>();
            var con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "SELECT * From Rezervari Where Rezervari.idDestinatie=@idDestinatie" ;
                var paramIdd = comm.CreateParameter();
                paramIdd.ParameterName = "idDestinatie";
                paramIdd.Value = idDestinatie;
                comm.Parameters.Add(paramIdd);
                using (var data = comm.ExecuteReader())
                {
                    while(data.Read())
                    {
                        int nr = data.GetInt32(1);
                        int id = data.GetInt32(0);
                        string nume = data.GetString(2);
                        list.Add(new Rezervare(id, nr, nume));
                    }
                }
                return list;
            }
        }

        public bool save(Rezervare rez)
        {
            var con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "INSERT into Rezervari(idDestinatie, nrLocuri, Nume ) values(@id , @nr,@nume)";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = rez.IdDestinatie;
                comm.Parameters.Add(paramId);

                var paramNr = comm.CreateParameter();
                paramNr.ParameterName = "@nr";
                paramNr.Value = rez.LocuriRezervate1;
                comm.Parameters.Add(paramNr);

                var paraNume = comm.CreateParameter();
                paraNume.ParameterName = "@nume";
                paraNume.Value = rez.Nume1;
                comm.Parameters.Add(paraNume);
                
                var ok=  comm.ExecuteNonQuery();
                if (ok == 0)
                    return false;
                logg.Info("Adaugare rezervare cu succes");
                return true;
            }
        }

        public void getRezervazri(DataSet ds , int id)
        {
            var con = DBUtils.getConnection();
            SQLiteDataAdapter ada = new SQLiteDataAdapter("SELECT * From Rezervari Where Rezervari.idDestinatie="+id, con);
            ada.Fill(ds, "Rezervari");
            con.Close();
        }
    }
}
