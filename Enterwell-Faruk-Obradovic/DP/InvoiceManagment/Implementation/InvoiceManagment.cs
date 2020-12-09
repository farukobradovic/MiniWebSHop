using Enterwell_Faruk_Obradovic.Data;
using Enterwell_Faruk_Obradovic.DP.InvoiceManagment.Interfaces;
using Enterwell_Faruk_Obradovic.DP.UserManagment.Interfaces;
using Enterwell_Faruk_Obradovic.Models;
using Enterwell_Faruk_Obradovic.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enterwell_Faruk_Obradovic.DP.InvoiceManagment.Implementation
{
    public class InvoiceManagment : IInvoiceManagment
    {
        private readonly Random _random = new Random();
        ApplicationDbContext db;
        private readonly SignInManager<Korisnik> loginManager;
        private readonly UserManager<Korisnik> UserManager;
        IUserDP IUserDP;
        public InvoiceManagment(ApplicationDbContext db, SignInManager<Korisnik> loginManager,
            UserManager<Korisnik> UserManager, IUserDP IUserDP)
        {
            this.db = db;
            this.loginManager = loginManager;
            this.UserManager = UserManager;
            this.IUserDP = IUserDP;
        }

        public async Task<List<Faktura>> GetAllInvoices()
        {
            var logged = await IUserDP.getLoggedUser();
            return db.Faktura.Where(c => c.KorisnikID == logged.Id).ToList();
        }

        public Faktura GetInvoiceByID(int FakturaID)
        {
            var invoice = db.Faktura.Include(c => c.Korisnik).SingleOrDefault(c => c.FakturaID == FakturaID);
            var stavke = db.FakturaStavka.Include(c => c.Stavka).Include(c => c.Porez).Where(c => c.FakturaID == FakturaID).ToList();
            invoice.Stavke = stavke;
            return invoice;
        }

        public List<Stavka> GetStavke()
        {
            return db.Stavka.ToList();
        }

        public List<PDV> GetListPDV()
        {
            return db.PDV.ToList();
        }
        public List<SelectListItem> GetSelectListPDV()
        {
            var list = db.PDV.Select(c => new SelectListItem()
            {
                Value = c.PDVID.ToString(),
                Text = c.Naziv + " " + c.VisinaPDV + "%"
            }).ToList();

            return list;
        }

        public Stavka ShowProduct(int StavkaID)
        {
            var stavka = db.Stavka.SingleOrDefault(c => c.StavkaID == StavkaID);
            return stavka;
        }

        public List<FakturaStavka> AddStavkaTemp(InvoiceViewModel model, List<FakturaStavka> sessionList)
        {
            var selectedPDV = db.PDV.SingleOrDefault(c => c.PDVID == model.SelectedPDV);
            double pdv = selectedPDV.VisinaPDV / 100;
            var s = db.Stavka.SingleOrDefault(c => c.StavkaID == model.StavkaID);
            var stavka = new FakturaStavka()
            {
                StavkaID = s.StavkaID,
                Kolicina = model.Kolicina,
                CijenaSaPDV = s.CijenaBezPDV*selectedPDV.VisinaPDV/100+s.CijenaBezPDV,
                PDVID = selectedPDV.PDVID
            };
            sessionList.Add(stavka);
           

            return sessionList;

        }

        public async Task<bool> Save(List<FakturaStavka> boughtArticles)
        {
            var logged = await IUserDP.getLoggedUser();
            var invoice = new Faktura()
            {
                KorisnikID = logged.Id,
                BrojFakture = _random.Next(100000, 100000000),
                DatumKreiranja = DateTime.Now,
                DatumDospijeca = DateTime.Now.AddDays(7),
                ImePrezimeKupca = logged.ImePrezime
            };

            var list = boughtArticles.Select(c => new FakturaStavka()
            {
                StavkaID = c.StavkaID,
                Kolicina = c.Kolicina,
                CijenaSaPDV = c.CijenaSaPDV,
                PDVID = c.PDVID
            }).ToList();

            var ukupnoPDV = list.Select(c => c.CijenaSaPDV).Sum();

            double cifra = 0;
            foreach(var i in list)
            {
                cifra += i.CijenaSaPDV * i.Kolicina;
            }


            var pdv = list.Select(c => c.PDVID).First();
            var porezObj = db.PDV.SingleOrDefault(c => c.PDVID == pdv);
            var ukupnoBezPDV = ukupnoPDV - porezObj.VisinaPDV / 100 * ukupnoPDV;

            invoice.UkupnoSaPDV = cifra;
            invoice.UkupnoBezPDV = ukupnoBezPDV;

            invoice.Stavke = list;
            db.Faktura.Add(invoice);
            db.SaveChanges();

            return true;
        }



    }
}
