using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Enterwell_Faruk_Obradovic.Models
{
    public class Faktura
    {
        public int FakturaID { get; set; }

        [ForeignKey("KorisnikID")]
        public Korisnik Korisnik { get; set; }
        public string KorisnikID { get; set; }

        public int BrojFakture { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public DateTime DatumDospijeca { get; set; }
        public double UkupnoBezPDV { get; set; }
        public double UkupnoSaPDV { get; set; }
       
        public string ImePrezimeKupca { get; set; }

        public List<FakturaStavka> Stavke { get; set; }


        public Faktura()
        {
            Stavke = new List<FakturaStavka>();
        }

    }
}
