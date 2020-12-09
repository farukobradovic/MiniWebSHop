using Enterwell_Faruk_Obradovic.Models;
using Enterwell_Faruk_Obradovic.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enterwell_Faruk_Obradovic.DP.InvoiceManagment.Interfaces
{
    public interface IInvoiceManagment
    {
        Task<List<Faktura>> GetAllInvoices();
        List<Stavka> GetStavke();
        List<PDV> GetListPDV();
        Stavka ShowProduct(int StavkaID);
        List<SelectListItem> GetSelectListPDV();
        List<FakturaStavka> AddStavkaTemp(InvoiceViewModel model, List<FakturaStavka> sessionList);
        Task<bool> Save(List<FakturaStavka> boughtArticles);
        Faktura GetInvoiceByID(int FakturaID);
    }
}
