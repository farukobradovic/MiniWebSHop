using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Enterwell_Faruk_Obradovic.Models
{
    public class FakturaStavka
    {
        public int FakturaStavkaID { get; set; }

        [ForeignKey("StavkaID")]
        public Stavka Stavka { get; set; }
        public int StavkaID { get; set; }

        [ForeignKey("FakturaID")]
        public Faktura Faktura { get; set; }
        public int FakturaID { get; set; }

        [ForeignKey("PDVID")]
        public PDV Porez { get; set; }
        public int PDVID { get; set; }

        public int Kolicina { get; set; }
        public double CijenaSaPDV { get; set; }

       
    }
}
