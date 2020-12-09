using Enterwell_Faruk_Obradovic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enterwell_Faruk_Obradovic.ViewModels
{
    public class StavkeViewModel
    {
        public List<FakturaStavka> Stavke { get; set; }
        public StavkeViewModel()
        {
            Stavke = new List<FakturaStavka>();
        }
    }
}
