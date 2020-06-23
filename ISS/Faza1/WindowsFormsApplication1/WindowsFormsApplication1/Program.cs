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
           RepositoryCarte carteRep = new RepositoryCarte(c);
            RepositoryImprumut imprRep = new RepositoryImprumut(c);

            ServiceAbonat aboServ = new ServiceAbonat(aboRep);
            ServiceBibliotecar bibliotecarServ = new ServiceBibliotecar(bibliotecarRep);
            ServiceCarte carteServ = new ServiceCarte(carteRep);
            ServiceImprumut imprServ = new ServiceImprumut(imprRep);

             log.setService( bibliotecarServ,aboServ,carteServ , imprServ);
             carteServ.getLista();
             Application.Run(log);
 
         
     }
    }
}
