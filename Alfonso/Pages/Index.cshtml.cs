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
    public class IndexModel : PageModel
    {
        private readonly ICatalogService _catalogService;

        public IndexModel(ICatalogService catalogService, ITelefonService telefonService)
        {
            _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));            
        }

        public List<Telefon> TelefonList { get; set; }
        public CatalogIndexViewModel CatalogModel { get; set; } = new CatalogIndexViewModel();        

        public async Task OnGet(CatalogIndexViewModel catalogModel, int? pageId)
        {
            CatalogModel = await _catalogService.GetCatalogItems(pageId ?? 0, Constants.ITEMS_PER_PAGE, catalogModel.BrandFilterApplied, catalogModel.TypesFilterApplied);            
        }
    }
}