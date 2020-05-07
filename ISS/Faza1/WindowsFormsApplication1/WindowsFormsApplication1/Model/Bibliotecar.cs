using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Model
{
    [Table("Bibliotecar")]
    public class Bibliotecar
    {
        [Key() , DatabaseGenerated(DatabaseGeneratedOption.Identity),]
        public int id { get; set; }
        [StringLength(20)]
        public String nume { get; set; }
        [StringLength(30)]
        public string prenume { get; set; }
        public int IdBiblioteca{ get; set; }
        [StringLength(30)]
        public string username { get; set; }
        [StringLength(30)]
        public string password { get; set; }

        [ForeignKey("IdBiblioteca")]
        public Biblioteca blil { get; set; }
    }
}
