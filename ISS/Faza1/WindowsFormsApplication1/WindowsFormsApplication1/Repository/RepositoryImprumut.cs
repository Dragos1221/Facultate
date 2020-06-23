using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Model;

namespace WindowsFormsApplication1.Repository
{
    public class RepositoryImprumut
    {
        Context con;
        public RepositoryImprumut(Context c)
        {
            con = c;
        }
        public Imprumut exist(int abonat, int carte)
        {
            foreach (Imprumut t in con.imprumut.ToList())
            {
                if (t.idAbonat == abonat && t.idCarte2 == carte && t.dataReturnare.Equals("-"))
                {
                    return t;
                }
            }
            return null;
        }
        public void save(Imprumut i)
        {
            con.imprumut.Add(i);
            con.SaveChanges();
        }
        public void update(Imprumut i)
        {

            Imprumut b = con.imprumut.FirstOrDefault(item => item.id == i.id);
            b.dataReturnare = i.dataReturnare;
            b.stareCarteReturnare = i.stareCarteReturnare;
            b.idBibliotecar = i.idBibliotecar;
            con.SaveChanges();
        }
    }
}
