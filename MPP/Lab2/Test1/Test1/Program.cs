using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace Test1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            var conn = new SQLiteConnection("URI = file:C:\\Users\\Dragos\\Desktop\\Lab1MPP\\Oficii.db");
            conn.Open();
            string stmt = "SELECT * FROM Destinatie ";
            var s = new SQLiteCommand(stmt, conn);
            var r = s.ExecuteReader();
            while(r.Read())
            {
                Console.WriteLine(r.GetInt32(1));
        
            }





            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            /*
            string con =  ConfigurationManager.ConnectionStrings["Test01"].ConnectionString;
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            var com = connection.CreateCommand();
            com.CommandText = "Select * From Rezervari";
            var ceva = com.ExecuteReader();
            while(ceva.Read())
            {
                Console.WriteLine(ceva.GetString(0));

            }
            */
        }
    }
}
