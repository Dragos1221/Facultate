using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Repository;
using WindowsFormsApplication1.Model;
namespace WindowsFormsApplication1.Service

{
    public class ServiceImprumut
    {
        private RepositoryImprumut rep;
        public ServiceImprumut(RepositoryImprumut r)
        {
            rep = r;
        }
        public Imprumut exist(int abonat , int carte){return rep.exist(abonat, carte);}
        public void save(Imprumut i)
        {
            rep.save(i);
        }
        public void update(Imprumut i)
        {
            rep.update(i);
        }
    }
}
