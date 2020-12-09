using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enterwell_Faruk_Obradovic.Models
{
    public class Stavka
    {
        public int StavkaID { get; set; }
        public string Naziv { get; set; }
        public double CijenaBezPDV { get; set; }
        public string Opis { get; set; }

    }
}
