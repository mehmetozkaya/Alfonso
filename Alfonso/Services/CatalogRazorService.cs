using Alfonso.Interfaces;
using Alfonso.ViewModels;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alfonso.Services
{
    public class CatalogRazorService : ICatalogRazorService
    {
        private readonly ICatalogService _catalogService;
        private readonly IUriComposer _uriComposer;
        private readonly ILogger<CatalogRazorService> _logger;

        public CatalogRazorService(ICatalogService catalogService, IUriComposer uriComposer, ILogger<CatalogRazorService> logger)
        {
            _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));
            _uriComposer = uriComposer ?? throw new ArgumentNullException(nameof(uriComposer));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CatalogIndexViewModel> GetCatalogItems(int pageIndex, int itemsPage, int? brandId, int? typeId)
        {            
            var itemsOnPage = _catalogService.GetItemsOnPage(pageIndex, itemsPage, brandId, typeId).ToList();
            var totalItems = _catalogService.GetItemsCount(brandId, typeId);

            itemsOnPage.ForEach(x =>
            {
                x.PictureUri = _uriComposer.ComposePicUri(x.PictureUri);
            });

            var vm = new CatalogIndexViewModel()
            {
                CatalogItems = itemsOnPage.Select(i => new CatalogItemViewModel()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Slug = i.Slug,
                    Description = i.Description,
                    Summary = i.Summary,
                    Star = i.Star,
                    PictureUri = i.PictureUri,
                    Price = i.Price,
                    AlfonsoPoint = i.AlfonsoPoint,
                    AntutuPoint = i.AntutuPoint,
                    VersusPoint = i.VersusPoint,
                    Battery = i.Battery,
                    Camera = i.Camera,
                    CPU = i.CPU,
                    Ram = i.Ram,
                    Screen = i.Screen,
                    Storage = i.Storage
                }),
                Brands = await GetBrands(),
                Types = await GetTypes(),
                BrandFilterApplied = brandId ?? 0,
                TypesFilterApplied = typeId ?? 0,
                PaginationInfo = new PaginationInfoViewModel()
                {
                    ActualPage = pageIndex,
                    ItemsPerPage = itemsOnPage.Count,
                    TotalItems = totalItems,
                    TotalPages = int.Parse(Math.Ceiling(((decimal)totalItems / itemsPage)).ToString())
                }
            };

            vm.PaginationInfo.Next = (vm.PaginationInfo.ActualPage == vm.PaginationInfo.TotalPages - 1) ? "display:none" : "";
            vm.PaginationInfo.Previous = (vm.PaginationInfo.ActualPage == 0) ? "display:none" : "";

            return vm;
        }

        public async Task<IEnumerable<SelectListItem>> GetBrands()
        {
            var brands = await _catalogService.GetBrands();

            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "All", Selected = true }
            };

            foreach (var brand in brands)
            {
                items.Add(new SelectListItem() { Value = brand.Id.ToString(), Text = brand.Brand });
            }

            return items;
        }

        public async Task<IEnumerable<SelectListItem>> GetTypes()
        {
            var types = await _catalogService.GetTypes();
            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "All", Selected = true }
            };
            foreach (var type in types)
            {
                items.Add(new SelectListItem() { Value = type.Id.ToString(), Text = type.Type });
            }

            return items;
        }

        public async Task<CatalogItemViewModel> GetCatalogItem(string slug)
        {            
            var catalogItem = _catalogService.GetItemBySlug(slug);

            var catalogItemViewModel = new CatalogItemViewModel
            {
                Id = catalogItem.Id,
                Description = catalogItem.Description,
                Name = catalogItem.Name,
                PictureUri = catalogItem.PictureUri,
                Price = catalogItem.Price,
                Slug = catalogItem.Slug,
                Star = catalogItem.Star,
                Summary = catalogItem.Summary
            };

            return catalogItemViewModel;
        }
    }
}
