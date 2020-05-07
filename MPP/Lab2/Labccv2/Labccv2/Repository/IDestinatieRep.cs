using Labccv2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labccv2.Repository
{
    interface IDestinatieRep
    {
       int getIdDestinatie(String destinatie, DateTime timp);

        List<Destinatie> returnList();

        Destinatie getDestinatie(int idDest);

        void update(Destinatie dest);
    }
}
