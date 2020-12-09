using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Enterwell_Faruk_Obradovic.DP.InvoiceManagment.Interfaces;
using Enterwell_Faruk_Obradovic.Models;
using Enterwell_Faruk_Obradovic.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Enterwell_Faruk_Obradovic.Controllers
{
    [Authorize]
    public class InvoiceController : Controller
    {
        IInvoiceManagment invoiceManagment;

        public InvoiceController(IInvoiceManagment invoiceManagment)
        {
            this.invoiceManagment = invoiceManagment;
        }

        public async Task<IActionResult> Index()
        {

            var invoices = await invoiceManagment.GetAllInvoices();
            var model = new InvoiceViewModel()
            {
                InvoicesList = invoices
            };

            return View(model);
        }


        public IActionResult CreateInvoice()
        {
            var s = HttpContext.Session.Get("data");
            var sessionList = new List<FakturaStavka>();

            if(s != null)
            {
                sessionList = JsonConvert.DeserializeObject<List<FakturaStavka>>(HttpContext.Session.GetString("data"));
            }


            var list = invoiceManagment.GetStavke();


            var model = new InvoiceViewModel()
            {
                Stavke = list,
                SesijaLista = sessionList
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult>  CreateInvoice(InvoiceViewModel model)
        {
            var s = HttpContext.Session.Get("data");
            if(s == null)
            {
                return RedirectToAction("CreateInvoice");
            }

            var sessionList = JsonConvert.DeserializeObject<List<FakturaStavka>>(HttpContext.Session.GetString("data"));

            await invoiceManagment.Save(sessionList);

            HttpContext.Session.Remove("data");

            return RedirectToAction("Index");
        }


        public IActionResult BuyProduct(int StavkaID)
        {
            var stavka = invoiceManagment.ShowProduct(StavkaID);
            var selectListPDV = invoiceManagment.GetSelectListPDV();

            var model = new InvoiceViewModel()
            {
                Stavka = stavka,
                SelectListPDV = selectListPDV,
                StavkaID = StavkaID
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult BuyProduct(InvoiceViewModel model)
        {
            var s = HttpContext.Session.Get("data");
            var sessionList = new List<FakturaStavka>();
            var ss = new List<FakturaStavka>();

            if (s != null)
            {
                 sessionList = JsonConvert.DeserializeObject<List<FakturaStavka>>(HttpContext.Session.GetString("data"));
            }

           

            var stavke = invoiceManagment.AddStavkaTemp(model, s!= null ? sessionList : ss);
            var list = invoiceManagment.GetStavke();
            //List<FakturaStavka> boughtList = stavke;

            model.BoughtArticles = stavke;
            model.Stavke = list;


            HttpContext.Session.SetString("data", JsonConvert.SerializeObject(stavke));

 
            return RedirectToAction("CreateInvoice");
        }

        public IActionResult Display(int FakturaID)
        {
            var invoice = invoiceManagment.GetInvoiceByID(FakturaID);
            var model = new InvoiceDisplayViewModel()
            {
                Invoice = invoice
            };

            return View(model);
        }

    }
}