using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Repository;
using WindowsFormsApplication1.Model;

namespace WindowsFormsApplication1.Service
{
   public class ServiceAbonat
    {
        private RepositoryAbonat rep;
        public ServiceAbonat(RepositoryAbonat r)
        {
            this.rep = r;
        }

        public bool find(string username, string password)
        {
            return rep.find(username,password);
        }

    }
}
