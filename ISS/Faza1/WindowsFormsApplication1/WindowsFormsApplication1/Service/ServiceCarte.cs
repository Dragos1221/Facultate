using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Model;
using WindowsFormsApplication1.Repository;

namespace WindowsFormsApplication1.Service
{
    public class ServiceCarte
    {
        private RepositoryCarte rep;
        public ServiceCarte(RepositoryCarte r)
        {
            rep = r;
        }
        public bool save(Carte c)
        {
            return rep.save(c);
        }
        public void delete(int id)
        {
            rep.delete(id);
        }
        public void update(Carte c)
        {
            rep.update(c);
        }
        public List<Carte> getLista()
        {
            return rep.getListaCarti();
        }
    }
}
