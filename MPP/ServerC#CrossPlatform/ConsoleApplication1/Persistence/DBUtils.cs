using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    class DBUtils
    {
        private static SQLiteConnection instance = null;

        

        public static SQLiteConnection getConnection()
        {
            if (instance == null || instance.State == System.Data.ConnectionState.Closed)
            {
                instance = getNewConnection();
                instance.Open();
            }
            return instance;
        }

        private static SQLiteConnection getNewConnection()
        {
            string adr = ConfigurationManager.AppSettings["adresa"];
            return new SQLiteConnection(adr);
        }
    }
}
