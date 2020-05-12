using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

using System.Data;

namespace Service
{
    public interface IServiceDestinatii
    {
         DataSet DestinatiiRep();
         int getIdDestinatie(string destinatie, DateTime timp);
         Destinatie getDestinatie(int idDest);
         void update(Destinatie dest);
    }
}
