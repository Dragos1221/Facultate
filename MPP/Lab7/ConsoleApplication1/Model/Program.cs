using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Program
    {
        static void Main(string[] args)
        {
            Oficiu of=new Oficiu("dragos" , "ceva");
            Context c = new Context();
            c.b.Add(of);
            c.SaveChanges();
        }
    }
}
