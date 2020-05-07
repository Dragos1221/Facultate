using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;

namespace Service
{
    public interface IserviceOficiu
    {
        bool logIn(Oficiu of, IObserver o);
        void notifica(DataSet s);
        void closeConection();
    }
}
