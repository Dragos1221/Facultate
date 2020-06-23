using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Repository;
using WindowsFormsApplication1.Model;

namespace WindowsFormsApplication1.Service
{
   public class ServiceBibliotecar
    {
        private RepositoryBibliotecar rep;

        public ServiceBibliotecar(RepositoryBibliotecar rep)
        {
            this.rep = rep;
        }

        public bool save(Bibliotecar b)
        {
           return rep.save(b);
        }
        public Bibliotecar find(string username, string password)
        {
            return rep.find( username,password);
        }
    }
}
