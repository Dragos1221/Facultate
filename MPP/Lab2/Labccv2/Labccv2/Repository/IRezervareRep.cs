
using Labccv2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labccv2.Repository
{
    interface IRezervareRep
    {
        List<Rezervare> getList(int idDestinatie);

        bool save(Rezervare rez);


    }
}
