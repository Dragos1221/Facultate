using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Model;

namespace WindowsFormsApplication1.Repository
{
   public class RepositoryCarte
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
        public void delete(int id)
        {
            try {
                con.carti.Remove(con.carti.Single(a =>a.id == id));
                con.SaveChanges();
            }catch(Exception e)
            {
                Console.Write(e.Message);
            }
        }
        public void update(Carte c)
        {
            try
            {
              Carte b=  con.carti.Find(con.carti.Single().id);
                b.titlu = c.titlu;
                b.autor = c.autor;
                b.Imprumutata = c.Imprumutata;
                con.SaveChanges();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

        }
        public List<Carte> getListaCarti()
        {
            List<Carte> l = new List<Carte>();
            foreach(Carte c in con.carti.ToList())
            {
                l.Add(c);
            }
            return l;
        }
    }
}
