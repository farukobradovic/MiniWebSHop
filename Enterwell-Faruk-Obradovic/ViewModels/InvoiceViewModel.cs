using Enterwell_Faruk_Obradovic.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Enterwell_Faruk_Obradovic.ViewModels
{
    public class InvoiceViewModel
    {
        public List<FakturaStavka> BoughtArticles { get; set; }
        public List<FakturaStavka> SesijaLista { get; set; }



        public List<Faktura> InvoicesList { get; set; }
        public List<Stavka> Stavke { get; set; }

        public List<SelectListItem> SelectListPDV { get; set; }
        [DisplayName("Porez")]
        public int SelectedPDV { get; set; }

        public Stavka Stavka { get; set; }
        public int StavkaID { get; set; }

        [Required]
        public string Opis { get; set; }
        [Required]
        [Range(1, 10)]
        [DisplayName("Količina")]
        public int Kolicina { get; set; }
        [Required]
        [DisplayName("Cijena bez PDV")]
        public double CijenaBezPDV { get; set; }
        public double CijenaSaPDV { get; set; }
        public PDV Porez { get; set; }
        public int PDVID { get; set; }


        public InvoiceViewModel()
        {
            InvoicesList = new List<Faktura>();
            Stavke = new List<Stavka>();
            SelectListPDV = new List<SelectListItem>();
            BoughtArticles = new List<FakturaStavka>();
            SesijaLista = new List<FakturaStavka>();
        }
    }
}
