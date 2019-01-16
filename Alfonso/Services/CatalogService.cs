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
    public class CatalogService : ICatalogService
    {
        private readonly ILogger<CatalogService> _logger;
        private readonly IRepository<CatalogItem> _itemRepository;
        private readonly IAsyncRepository<CatalogBrand> _brandRepository;
        private readonly IAsyncRepository<CatalogType> _typeRepository;
        private readonly IUriComposer _uriComposer;

        public CatalogService(ILoggerFactory loggerFactory, IRepository<CatalogItem> itemRepository, IAsyncRepository<CatalogBrand> brandRepository, IAsyncRepository<CatalogType> typeRepository, IUriComposer uriComposer)
        {
            _logger = loggerFactory.CreateLogger<CatalogService>();
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
            _brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository));
            _typeRepository = typeRepository ?? throw new ArgumentNullException(nameof(typeRepository));
            _uriComposer = uriComposer ?? throw new ArgumentNullException(nameof(uriComposer));
        }       

        public Task<CatalogIndexViewModel> GetCatalogItems(int pageIndex, int itemsPage, int? brandId, int? typeId)
        {
            _logger.LogInformation("GetCatalogItems called.");

            var filterSpecification = new CatalogFilterSpecification(brandId, typeId);
            var filterPaginatedSpecification = new CatalogFilterPaginatedSpecification(itemsPage * pageIndex, itemsPage, brandId, typeId);

            // the implementation below using ForEach and Count. We need a List.
            var itemsOnPage = _itemRepository.List(filterPaginatedSpecification).ToList();
            var totalItems = _itemRepository.Count(filterSpecification);

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
                    Price = i.Price
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

            vm.PaginationInfo.Next = (vm.PaginationInfo.ActualPage == vm.PaginationInfo.TotalPages - 1) ? "is-disabled" : "";
            vm.PaginationInfo.Previous = (vm.PaginationInfo.ActualPage == 0) ? "is-disabled" : "";

            return vm;
        }

        public Task<IEnumerable<SelectListItem>> GetBrands()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SelectListItem>> GetTypes()
        {
            throw new NotImplementedException();
        }
    }
}
