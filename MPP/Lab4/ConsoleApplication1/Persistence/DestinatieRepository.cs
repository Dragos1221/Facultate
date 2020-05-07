using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using log4net;
using Model;

namespace Persistence
{
   public class DestinatieRepository : IDestinatieRep
    {

        static private ILog logg = LogManager.GetLogger("Task");

        public DestinatieRepository()
        {

            
        }

        public Destinatie getDestinatie(int idDest)
        {
            var con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "SELECT * From Destinatie Where Destinatie.idDestinatie=@id";
                var paraId = comm.CreateParameter();
                paraId.ParameterName = "@id";
                paraId.Value = idDest;
                comm.Parameters.Add(paraId);
                using (var data = comm.ExecuteReader())
                {
                    while (data.Read())
                    {
                        string ceva = data.GetString(4);
                        string[] list = ceva.Split('T');
                        int an = Int32.Parse(list[0].Split('-')[0]);
                        int luna = Int32.Parse(list[0].Split('-')[1]);
                        int zi = Int32.Parse(list[0].Split('-')[2]);
                        int ora = Int32.Parse(list[1].Split(':')[0]);
                        int min = Int32.Parse(list[1].Split(':')[1]);
                        DateTime comp = new DateTime(an, luna, zi, ora, min, 0);
                        return new Destinatie(data.GetInt32(0), data.GetInt32(1), data.GetInt32(2), data.GetString(3), comp);
                    }

                }
            }
            return null;
        }

        public int getIdDestinatie(string destinatie, DateTime timp)
        {
            var con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "SELECT idDestinatie,Destinatie.Data_Si_Ora From Destinatie Where Destinatie.Destinatie=@id";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = destinatie;
                comm.Parameters.Add(paramId);
                using (var data = comm.ExecuteReader())
                {
                    while (data.Read())
                    {
                        string ceva = data.GetString(1);
                        string[] list = ceva.Split('T');
                        int an = Int32.Parse( list[0].Split('-')[0]);
                        int luna = Int32.Parse(list[0].Split('-')[1]);
                        int zi = Int32.Parse(list[0].Split('-')[2]);
                        int ora = Int32.Parse(list[1].Split(':')[0]);
                        int min = Int32.Parse(list[1].Split(':')[1]);
                        DateTime comp = new DateTime(an, luna, zi, ora, min, 0);
                        if(comp.CompareTo(timp) == 0)
                        {
                            return data.GetInt32(0);
                        }
                    }
                }
            }
            return -1;
        }

        public List<Destinatie> returnList()
        {
            List<Destinatie> list2 = new List<Destinatie>();
            var con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText= "SELECT * From Destinatie";
                using (var data = comm.ExecuteReader())
                {
                    while (data.Read())
                    {
                        string ceva = data.GetString(4);
                        string[] list = ceva.Split('T');
                        int an = Int32.Parse(list[0].Split('-')[0]);
                        int luna = Int32.Parse(list[0].Split('-')[1]);
                        int zi = Int32.Parse(list[0].Split('-')[2]);
                        int ora = Int32.Parse(list[1].Split(':')[0]);
                        int min = Int32.Parse(list[1].Split(':')[1]);
                        DateTime comp = new DateTime(an, luna, zi, ora, min, 0);
                        list2.Add(new Destinatie(data.GetInt32(0), data.GetInt32(1), data.GetInt32(2), data.GetString(3), comp));
                    }
                }
            }
            return list2;
        }

        public void update(Destinatie dest)
        {
            var con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "UPDATE Destinatie SET LocuriDisponibile=@locDisp , LocuriOcupate=@locOc WHERE idDestinatie=@id";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = dest.Id;
                comm.Parameters.Add(paramId);

                var paramDis = comm.CreateParameter();
                paramDis.ParameterName = "@locDisp";
                paramDis.Value = dest.LocuriDisponibile1;
                comm.Parameters.Add(paramDis);

                var paramOc = comm.CreateParameter();
                paramOc.ParameterName = "@locOc";
                paramOc.Value = dest.LocuriOcupate1;
                comm.Parameters.Add(paramOc);

                comm.ExecuteNonQuery();
            }
            logg.Info("Update destinatie cu succes");
        }

        public void DestinatiiRep(DataSet set)
        {
            var con = DBUtils.getConnection();
            SQLiteDataAdapter ada = new SQLiteDataAdapter("SELECT * From Destinatie", con);
            ada.Fill(set, "Destinatie");
            con.Close();

        }
    }
}
