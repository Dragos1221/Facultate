using Lab2MPPC.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2MPPCC.Repository
{
    interface IRezervareRep
    {
        List<Rezervare> getList(int idDestinatie);

        bool save(Rezervare rez);


    }
}
