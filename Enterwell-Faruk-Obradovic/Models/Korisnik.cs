using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enterwell_Faruk_Obradovic.Models
{
    public class Korisnik : IdentityUser
    {
        public string Grad { get; set; }
        public string Adresa { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string ImePrezime
        {
            get
            {
                return Ime + " " + Prezime;
            }
        }
    }
}
