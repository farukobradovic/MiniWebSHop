#pragma checksum "C:\Users\Faruk\source\repos\Enterwell-Faruk-Obradovic\Enterwell-Faruk-Obradovic\Views\Invoice\Display.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "69459823d4a14fda9b1f4595178f4db7d230f847"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Invoice_Display), @"mvc.1.0.view", @"/Views/Invoice/Display.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Faruk\source\repos\Enterwell-Faruk-Obradovic\Enterwell-Faruk-Obradovic\Views\_ViewImports.cshtml"
using Enterwell_Faruk_Obradovic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Faruk\source\repos\Enterwell-Faruk-Obradovic\Enterwell-Faruk-Obradovic\Views\_ViewImports.cshtml"
using Enterwell_Faruk_Obradovic.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"69459823d4a14fda9b1f4595178f4db7d230f847", @"/Views/Invoice/Display.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93f66d1cada1737fefdd3c16e1299e91665fa2c6", @"/Views/_ViewImports.cshtml")]
    public class Views_Invoice_Display : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Enterwell_Faruk_Obradovic.ViewModels.InvoiceDisplayViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Faruk\source\repos\Enterwell-Faruk-Obradovic\Enterwell-Faruk-Obradovic\Views\Invoice\Display.cshtml"
   
    ViewData["Title"] = "Pregled fakture " + Model.Invoice.BrojFakture;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 style=\"margin-bottom: 50px;\">Pregled fakture</h1>\r\n\r\n<div style=\"margin-bottom: 50px;\">\r\n    <p style=\"font-size:20px\"><span style=\"font-weight:600\">Ukupno sa PDV: </span>");
#nullable restore
#line 10 "C:\Users\Faruk\source\repos\Enterwell-Faruk-Obradovic\Enterwell-Faruk-Obradovic\Views\Invoice\Display.cshtml"
                                                                             Write(String.Format("{0:0.##}", @Model.Invoice.UkupnoSaPDV));

#line default
#line hidden
#nullable disable
            WriteLiteral(" KM</p>\r\n    <p><span style=\"font-weight:600\">Ukupno bez PDV: </span>");
#nullable restore
#line 11 "C:\Users\Faruk\source\repos\Enterwell-Faruk-Obradovic\Enterwell-Faruk-Obradovic\Views\Invoice\Display.cshtml"
                                                       Write(String.Format("{0:0.##}", @Model.Invoice.UkupnoBezPDV));

#line default
#line hidden
#nullable disable
            WriteLiteral(" KM</p>\r\n    <p><span style=\"font-weight:600\">Broj fakture: </span>");
#nullable restore
#line 12 "C:\Users\Faruk\source\repos\Enterwell-Faruk-Obradovic\Enterwell-Faruk-Obradovic\Views\Invoice\Display.cshtml"
                                                     Write(Model.Invoice.BrojFakture);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p><span style=\"font-weight:600\">Datum keriranja: </span>");
#nullable restore
#line 13 "C:\Users\Faruk\source\repos\Enterwell-Faruk-Obradovic\Enterwell-Faruk-Obradovic\Views\Invoice\Display.cshtml"
                                                        Write(Model.Invoice.DatumKreiranja.ToString("d"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p><span style=\"font-weight:600\">Datum isporuke: </span>");
#nullable restore
#line 14 "C:\Users\Faruk\source\repos\Enterwell-Faruk-Obradovic\Enterwell-Faruk-Obradovic\Views\Invoice\Display.cshtml"
                                                       Write(Model.Invoice.DatumDospijeca.ToString("d"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n    <p><span style=\"font-weight:600\">Ime i prezime naručioca: </span>");
#nullable restore
#line 16 "C:\Users\Faruk\source\repos\Enterwell-Faruk-Obradovic\Enterwell-Faruk-Obradovic\Views\Invoice\Display.cshtml"
                                                                Write(Model.Invoice.Korisnik.ImePrezime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p><span style=\"font-weight:600\">Adresa isporuke: </span>");
#nullable restore
#line 17 "C:\Users\Faruk\source\repos\Enterwell-Faruk-Obradovic\Enterwell-Faruk-Obradovic\Views\Invoice\Display.cshtml"
                                                        Write(Model.Invoice.Korisnik.Grad);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 17 "C:\Users\Faruk\source\repos\Enterwell-Faruk-Obradovic\Enterwell-Faruk-Obradovic\Views\Invoice\Display.cshtml"
                                                                                     Write(Model.Invoice.Korisnik.Adresa);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
</div>

<h3 style=""margin-bottom: 50px;"">Pregled kupljenih stavki</h3>

<table class=""table"">
    <thead>
        <tr>
            <th scope=""col"">Naziv stavke</th>
            <th scope=""col"">Količina</th>
            <th scope=""col"">Cijena sa PDV</th>
            <th scope=""col"">Ukupno</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 32 "C:\Users\Faruk\source\repos\Enterwell-Faruk-Obradovic\Enterwell-Faruk-Obradovic\Views\Invoice\Display.cshtml"
         foreach(var i in Model.Invoice.Stavke)
        {
            var ukupno = @i.Kolicina * @i.CijenaSaPDV;

        

#line default
#line hidden
#nullable disable
            WriteLiteral("<tr>\r\n            <td>");
#nullable restore
#line 37 "C:\Users\Faruk\source\repos\Enterwell-Faruk-Obradovic\Enterwell-Faruk-Obradovic\Views\Invoice\Display.cshtml"
           Write(i.Stavka.Naziv);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 38 "C:\Users\Faruk\source\repos\Enterwell-Faruk-Obradovic\Enterwell-Faruk-Obradovic\Views\Invoice\Display.cshtml"
           Write(i.Kolicina);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 39 "C:\Users\Faruk\source\repos\Enterwell-Faruk-Obradovic\Enterwell-Faruk-Obradovic\Views\Invoice\Display.cshtml"
           Write(String.Format("{0:0.##}", i.CijenaSaPDV));

#line default
#line hidden
#nullable disable
            WriteLiteral(" KM</td>\r\n            <td>");
#nullable restore
#line 40 "C:\Users\Faruk\source\repos\Enterwell-Faruk-Obradovic\Enterwell-Faruk-Obradovic\Views\Invoice\Display.cshtml"
           Write(String.Format("{0:0.##}", ukupno));

#line default
#line hidden
#nullable disable
            WriteLiteral(" KM</td>\r\n            \r\n        </tr>\r\n");
#nullable restore
#line 43 "C:\Users\Faruk\source\repos\Enterwell-Faruk-Obradovic\Enterwell-Faruk-Obradovic\Views\Invoice\Display.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Enterwell_Faruk_Obradovic.ViewModels.InvoiceDisplayViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591