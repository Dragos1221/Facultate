
using Model;

using Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DestinatieService:IServiceDestinatii
    {
        DestinatieRepository rep;

        public DestinatieService(DestinatieRepository rep)
        {
            this.rep = rep;
        }

        public DataSet DestinatiiRep()
        {
            DataSet ds = new DataSet();
            rep.DestinatiiRep(ds);
            return ds;
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

        public List<Destinatie> returnList()
        {
            return rep.returnList();
        }
    }
}
