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
    class Thread2
    {
        int nr;
        public Thread2(int m)
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
                SqlCommand cmd = new SqlCommand("Reads10", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                Console.WriteLine("deadlock 2 executat");
            }catch(SqlException e)
            {
                Console.WriteLine("deadloc la 2" + e.Message);
                if (nr<3)
                {
                    Thread2 thr2 = new Thread2(nr+1);
                    Thread tt = new Thread(new ThreadStart(thr2.run));
                    tt.Start();
                }
                else
                {
                    Console.WriteLine("deadloc2 abandonat");
                }
                
            }

        }
    }
}
