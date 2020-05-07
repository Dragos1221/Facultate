using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IObserver
    {
        void reloadList(DataSet d);
    }
}
