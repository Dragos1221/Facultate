using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Model
{
    [Table("Abonat")]
     public class Anobat
    {
        [Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(30)]
        public string nume { get; set; }
        [StringLength(30)]
        public string prenume { get; set; }
        [StringLength(30)]
        public string adresa { get; set; }
        [StringLength(30)]
        public string telefon { get; set; }
        [StringLength(30)]
        public string cnp { get; set; }
        [StringLength(30)]
        public string username { get; set; }
        [StringLength(30)]
        public string password { get; set; }

        public int IdBiblioteca { get; set; }

        [ForeignKey("IdBiblioteca")]
        public Biblioteca blil { get; set; }
    }
}
