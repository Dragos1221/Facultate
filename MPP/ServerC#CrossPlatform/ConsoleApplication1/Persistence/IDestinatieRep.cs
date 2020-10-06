using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
   public interface IDestinatieRep
    {
       int getIdDestinatie(String destinatie, DateTime timp);

        List<Destinatie> returnList();

        Destinatie getDestinatie(int idDest);

        void update(Destinatie dest);
    }
}
