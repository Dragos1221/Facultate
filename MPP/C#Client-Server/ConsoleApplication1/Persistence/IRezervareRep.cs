

using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public interface IRezervareRep
    {
        List<Rezervare> getList(int idDestinatie);

        bool save(Rezervare rez);


    }
}
