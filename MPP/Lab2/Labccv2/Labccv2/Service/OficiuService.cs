using Labccv2.Domain;
using Labccv2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labccv2.Service
{
    public class OficiuService
    {
        OficiuRepository rep;

        public OficiuService(OficiuRepository re)
        {
            rep = re;
        }

        public bool logIn(Oficiu of)
        {
            return rep.logIn(of);
        }
    }
}
