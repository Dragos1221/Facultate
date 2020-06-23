using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Model
{
    [Table("Imprumut")]
    public class Imprumut
    {
        [Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity),]
        public int id { get; set; }
        public string dataInprumut { get; set; }
        public string dataReturnare { get; set; }
        public string stareCartePrimire { get; set; }
        public string stareCarteReturnare { get; set; }

        public int? idBibliotecar { get; set; }
        [ForeignKey("idBibliotecar")]
        public Bibliotecar b { get; set; }

        public int? idCarte2 { get; set; }
        [ForeignKey("idCarte2")]
        public Carte c { get; set; }

        public int idAbonat { get; set; }
        [ForeignKey("idAbonat")]
        public Anobat a { get; set; }

      


    }
}
