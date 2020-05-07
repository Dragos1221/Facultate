using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            /* SqlDataAdapter da = new SqlDataAdapter();
             DataSet ds = new DataSet();
             string str = "server=DESKTOP-N6I4HKO;database=Magazin_v2 ; Integrated security=True";
             string comanda = "Select * from angajat";
            SqlConnection con = new SqlConnection(str);
            SqlCommand comand = new SqlCommand(comanda,con);
            da.SelectCommand = comand;
            con.Open();
            SqlDataReader rea = comand.ExecuteReader();
            while(rea.Read())
            {
                Console.WriteLine(rea.GetString(1));
            }
            */
          
          





        }
    }
}
