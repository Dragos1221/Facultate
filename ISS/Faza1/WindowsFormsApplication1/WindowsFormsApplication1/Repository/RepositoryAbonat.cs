using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Model;

namespace WindowsFormsApplication1.Repository
{

    public class RepositoryAbonat
    {
        private Context con;
        public RepositoryAbonat(Context c)
        {
            con = c;
        }

        public Anobat find(string username , string password)
        {
            foreach(Anobat abonat in con.abonati.ToList())
            {
                if(username.Equals(abonat.username) && password.Equals(abonat.password))
                {
                    return abonat;
                }     
            }
            return null;
        }


    }
}
