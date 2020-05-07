using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Model
{
    [Table("Biblioteca")]
    public class Biblioteca:DbContext
    {
       [Key()]
       public int id { get; set; }
       [StringLength(20)]
       public String nume { get; set; }
    }
}
