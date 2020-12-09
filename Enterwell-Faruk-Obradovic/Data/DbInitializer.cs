using Enterwell_Faruk_Obradovic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enterwell_Faruk_Obradovic.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext db)
        {
            db.Database.EnsureCreated();

            if (db.Stavka.Any() && db.PDV.Any())
            {
                return;
            }

            

            var stavke = new Stavka[]
            {
                new Stavka{Naziv="Hard disk", CijenaBezPDV=100, Opis="Hard disk od 1TB marke abc."},
                new Stavka{Naziv="Matična ploča", CijenaBezPDV=350, Opis="Lorem ispum dolor sit amet."},
                new Stavka{Naziv="Laptop HP", CijenaBezPDV=999.99, Opis="Lorem ispum dolor sit amet."},
                new Stavka{Naziv="Macbook Pro", CijenaBezPDV=2589.90, Opis="Lorem ispum dolor sit amet."},
                new Stavka{Naziv="Razer miš", CijenaBezPDV=89.99, Opis="Lorem ispum dolor sit amet."},
                new Stavka{Naziv="Gaming stolica", CijenaBezPDV=280, Opis="Lorem ispum dolor sit amet."},
                new Stavka{Naziv="Visual Studio 2019 Community", CijenaBezPDV=119.99, Opis="Lorem ispum dolor sit amet."},
                new Stavka{Naziv="Knjiga | Uvod u programiranje", CijenaBezPDV=120, Opis="Fenomenalna knjiga od strane pisca Joe Doe."},
                new Stavka{Naziv="Knjiga | Algoritmi i strukture podataka", CijenaBezPDV=80, Opis="Lorem ispum dolor sit amet."},
                new Stavka{Naziv="Knjiga | Javascript: The Good Parts", CijenaBezPDV=60, Opis="Fenomenalna knjiga od strane pisca Joe Doe."},
                new Stavka{Naziv="USB Stick 8GB", CijenaBezPDV=10, Opis="Lorem ispum dolor sit amet."},
                new Stavka{Naziv="USB Stick 20GB", CijenaBezPDV=19.99, Opis="USB Stick kvalitetnog dizajna od 20GB, marke ZHNNN."}
            };

            foreach(var i in stavke)
            {
                db.Stavka.Add(i);
            }

            var porezi = new PDV[]
            {
                new PDV{Naziv="Bosna i Hercegovina", VisinaPDV=17},
                new PDV{Naziv="Hrvatska", VisinaPDV=25},
                new PDV{Naziv="Crna Gora", VisinaPDV=21},
                new PDV{Naziv="Slovenija", VisinaPDV=20}
            };

            foreach (var i in porezi)
            {
                db.PDV.Add(i);
            }

            db.SaveChanges();

        }
    }
}
