using Alfonso.Interfaces;
using Alfonso.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alfonso
{
    public class RelatedProducts : ViewComponent
    {
        private readonly ICatalogService _catalogService;

        public RelatedProducts(ICatalogService catalogService)
        {
            _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));
        }

        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {
            var vm = await _catalogService.GetCatalogItems(0, 10, null, null);
            return View(vm.CatalogItems.Take(2));
        }
    }
}
