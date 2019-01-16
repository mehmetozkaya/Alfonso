using Alfonso.Interfaces;
using Alfonso.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alfonso.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ILogger<CatalogService> _logger;

        public Task<IEnumerable<SelectListItem>> GetBrands()
        {
            throw new NotImplementedException();
        }

        public Task<CatalogIndexViewModel> GetCatalogItems(int pageIndex, int itemsPage, int? brandId, int? typeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SelectListItem>> GetTypes()
        {
            throw new NotImplementedException();
        }
    }
}
