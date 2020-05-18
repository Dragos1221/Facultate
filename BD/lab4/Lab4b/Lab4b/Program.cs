using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab4b
{
    class Program
    {
        static void Main(string[] args)
        {
                Thread1 thr = new Thread1(0);
                Thread t = new Thread(new ThreadStart(thr.run));
                t.Start();
                Thread2 thr2 = new Thread2(0);
                Thread tt = new Thread(new ThreadStart(thr2.run));
                tt.Start();
  
           
            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
        }
    }
}
