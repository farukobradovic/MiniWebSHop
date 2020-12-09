using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Enterwell_Faruk_Obradovic.ViewModels
{
    public class RegisterViewModel
    {
        [DisplayName("Korisničko ime")]
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public string Grad { get; set; }
        [Required]
        public string Adresa { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DisplayName("Šifra")]
        public string PW { get; set; }
        [Required]
        [DisplayName("Ponovite vašu šifru")]
        [Compare("PW", ErrorMessage = "The passwords do not match.")]
        public string PW2 { get; set; }
        [Required]
        public string BrojTelefona { get; set; }

    }
}
