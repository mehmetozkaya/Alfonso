using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alfonso.Interfaces;
using Alfonso.Models;
using Alfonso.Services;
using Alfonso.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Alfonso.Pages
{
    public class ProductModel : PageModel
    {
        private readonly ICatalogService _catalogService;

        public ProductModel(ICatalogService catalogService)
        {
            _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));
        }

        public CatalogItemViewModel CatalogItem { get; set; }        

        public async Task OnGet(string slug)
        {
            CatalogItem = await _catalogService.GetCatalogItem(slug);

            //var telefonService = new TelefonService();
            //Telefon = telefonService.GetTelefons().FirstOrDefault(x => x.Slug == slug);
        }
    }
}