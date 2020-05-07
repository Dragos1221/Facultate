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
  public  class RezervareService
    {
        RezervareRepository rep;

        public RezervareService(RezervareRepository re)
        {
            rep = re;
        }

        public void getRezervazri(DataSet ds, int id)
        {
            rep.getRezervazri(ds, id);
        }

        public bool save(Rezervare rez)
        {
            return rep.save(rez);
        }

    }
}
