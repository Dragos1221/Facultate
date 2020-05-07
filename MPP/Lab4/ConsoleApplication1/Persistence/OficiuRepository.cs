using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;

using log4net;
using Model;

namespace Persistence
{
    public class OficiuRepository : IOficiuRep
    {
        static private ILog logg = LogManager.GetLogger("Task");

        public OficiuRepository(){}


        public bool logIn(Oficiu of)
        {
            SQLiteConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "SELECT OficiiTabel.User , Password FROM OficiiTabel";
                using (var data = comm.ExecuteReader())
                {
                    while(data.Read())
                    {
                        if(data.GetString(0).Equals(of.User1) && data.GetString(1).Equals(of.Password1))
                        {
                            return true;
                        }
                    }
                }

            }
            return false;
       }
    }
}
