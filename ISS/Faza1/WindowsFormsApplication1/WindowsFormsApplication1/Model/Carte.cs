using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Model
{
    [Table("Carti")]
    public class Carte
    {
        [Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [StringLength(30)]
        public string autor { get; set; }
        [StringLength(30)]
        public string titlu { get; set; }
        public bool Imprumutata { get; set; }
        [StringLength(30)]
        public string stare { get; set; }

        public int? IdBiblioteca2 { get; set; }

        [ForeignKey("IdBiblioteca2")]
        public Biblioteca bibl { get; set; }



    }
}
