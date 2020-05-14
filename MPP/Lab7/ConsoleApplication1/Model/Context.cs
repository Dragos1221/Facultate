using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Context:DbContext
    {
        public Context() : base("name=DefaultConnection")
        { }

        public DbSet<Oficiu> b { get; set; }
    }
}
