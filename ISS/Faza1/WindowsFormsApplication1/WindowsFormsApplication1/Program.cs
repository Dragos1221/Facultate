using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Model;
using WindowsFormsApplication1.Repository;
using WindowsFormsApplication1.Service;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginWindow log = new LoginWindow();
            Context c = new Context();
            RepositoryAbonat aboRep = new RepositoryAbonat(c);
            RepositoryBibliotecar bibliotecarRep = new RepositoryBibliotecar(c);
            ServiceAbonat aboServ = new ServiceAbonat(aboRep);
            ServiceBibliotecar bibliotecarServ = new ServiceBibliotecar(bibliotecarRep);
            log.setService( bibliotecarServ,aboServ);
            Application.Run(log);



            Carte cc = new Carte();
            cc.autor = "iulius";
            cc.titlu = "nebunu";

            Biblioteca biblioteca = new Biblioteca();
            biblioteca.nume = "ASDasd";
  
            RepositoryCarte rep = new RepositoryCarte(c);
            rep.getListaCarti();
     }
    }
}
