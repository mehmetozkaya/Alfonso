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
        private readonly ITelefonService _telefonService;

        public IndexModel(ICatalogService catalogService, ITelefonService telefonService)
        {
            _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));
            _telefonService = telefonService ?? throw new ArgumentNullException(nameof(telefonService));
        }

        public List<Telefon> TelefonList { get; set; }
        public CatalogIndexViewModel CatalogModel { get; set; } = new CatalogIndexViewModel();

        public void OnGet()
        {
            TelefonList = _telefonService.GetTelefons();
        }

        public async Task OnGet(CatalogIndexViewModel catalogModel, int? pageId)
        {
            CatalogModel = await _catalogService.GetCatalogItems(pageId ?? 0, Constants.ITEMS_PER_PAGE, catalogModel.BrandFilterApplied, catalogModel.TypesFilterApplied);
        }
    }
}