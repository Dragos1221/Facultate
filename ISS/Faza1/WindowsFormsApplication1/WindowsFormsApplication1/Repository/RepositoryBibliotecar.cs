using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Model;

namespace WindowsFormsApplication1.Repository
{
    public class RepositoryBibliotecar
    {
        private Context con;

        public RepositoryBibliotecar(Context c)
        {
            this.con = c;
        }

        public bool save(Bibliotecar b )
        {
            try
            {
                con.bibliot.Add(b);
                con.SaveChanges();
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        public Bibliotecar find(string username, string password)
        {
            foreach(Bibliotecar bibliotecar in con.bibliot.ToList())
            {
                if (bibliotecar.username.Equals(username) &&
                bibliotecar.password.Equals(password))
                    return bibliotecar;
            }
            return null;
        }


    }
}
