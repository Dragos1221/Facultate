using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab4b
{
    class Thread1
    {
        int nr;
        public Thread1(int m)
        {
            nr = m;
        }
        public virtual void run()
        {

            try
            {
                string str = "server=DESKTOP-N6I4HKO;database=Magazin_v2 ; Integrated security=True";
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                SqlCommand cmd = new SqlCommand("Reads9", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }catch(SqlException e)
            {
                Console.WriteLine("deadloc la 1");
                if(nr<3)
                {
                    Thread1 thr = new Thread1(nr+1);
                    Thread t = new Thread(new ThreadStart(thr.run));
                    t.Start();
                }
                else
                {
                    Console.WriteLine("deadloc1 abandonat");
                }
            }
}
    }
}
