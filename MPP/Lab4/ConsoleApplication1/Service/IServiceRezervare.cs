using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;

namespace Service
{
    public interface IServiceRezervare
    {
        DataSet getRezervazri( int id);
        bool save(Rezervare rez);
        List<Rezervare> getLista(int id);
       
    }
}
