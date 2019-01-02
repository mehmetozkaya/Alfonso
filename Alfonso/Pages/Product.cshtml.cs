using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alfonso.Models;
using Alfonso.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Alfonso.Pages
{
    public class ProductModel : PageModel
    {
        public Telefon Telefon { get; set; }

        public void OnGet(string slug)
        {
            var telefonService = new TelefonService();
            Telefon = telefonService.GetTelefons().FirstOrDefault(x => x.Slug == slug);
        }
    }
}