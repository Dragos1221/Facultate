using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Model;

namespace WindowsFormsApplication1
{
   public class Context:DbContext
    {
        public Context() : base("name=DefaultConnection")
        { }

        public DbSet<Biblioteca> b { get; set; }
        public DbSet<Bibliotecar> bibliot { get; set; }
        public DbSet<Anobat> abonati { get; set; }
        public DbSet<Imprumut> imprumut { get; set; }
        public DbSet<Carte> carti { get; set; }
    }
}
