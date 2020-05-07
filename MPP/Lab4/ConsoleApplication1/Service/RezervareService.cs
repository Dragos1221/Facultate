
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
  public  class RezervareService:IServiceRezervare
    {
        RezervareRepository rep;

        public RezervareService(RezervareRepository re)
        {
            rep = re;
        }

        public DataSet getRezervazri(int id)
        {
            DataSet ds = new DataSet();
            rep.getRezervazri( ds, id);
            return ds;
        }

        public bool save(Rezervare rez)
        {
            return rep.save(rez);
        }

       
    }
}
