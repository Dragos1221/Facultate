using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Model;

namespace WindowsFormsApplication1.Repository
{
    class RepositoryCarte
    {
        private Context con;
        public RepositoryCarte(Context c)
        {
            con = c;
        }

        public bool save(Carte carte)
        {
            try {
                con.carti.Add(carte);
                con.SaveChanges();
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }
    }
}
