using Labccv2.Domain;
using Labccv2.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labccv2.Service
{
    public class DestinatieService
    {
        DestinatieRepository rep;

        public DestinatieService(DestinatieRepository rep)
        {
            this.rep = rep;
        }

        public void DestinatiiRep(DataSet set)
        {
            rep.DestinatiiRep(set);
        }

        public int getIdDestinatie(string destinatie, DateTime timp)
        {
            return rep.getIdDestinatie(destinatie,timp);
        }

        public Destinatie getDestinatie(int idDest)
        {
            return rep.getDestinatie(idDest);
        }
        public void update(Destinatie dest)
        {
            rep.update(dest);
        }



    }
}
