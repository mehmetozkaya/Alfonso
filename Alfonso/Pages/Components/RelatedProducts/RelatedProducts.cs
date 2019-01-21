using Alfonso.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Alfonso
{
    public class RelatedProducts : ViewComponent
    {
        private readonly ICatalogRazorService _catalogService;

        public RelatedProducts(ICatalogRazorService catalogService)
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
