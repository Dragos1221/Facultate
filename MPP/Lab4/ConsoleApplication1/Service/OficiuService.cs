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
    public class OficiuService:IserviceOficiu
    {
   
        IOficiuRep rep;
        List<IObserver> list;

        public OficiuService(IOficiuRep offRep)
        {
            this.rep= offRep;
            list = new List<IObserver>();
        }


        public bool logIn(Oficiu of, IObserver o)
        {
            list.Add(o);
            return rep.logIn(of);
        }

        public void notifica(DataSet s)
        {
            foreach(IObserver o in list)
            {
                Task.Run(() => o.reloadList(s));
            }
        }

        public void closeConection()
        {
            throw new NotImplementedException();
        }
    }
}
