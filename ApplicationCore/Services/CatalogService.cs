using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly IRepository<CatalogItem> _catalogRepository;
        private readonly IAsyncRepository<CatalogBrand> _brandRepository;
        private readonly IAsyncRepository<CatalogType> _typeRepository;

        public CatalogService(IRepository<CatalogItem> catalogRepository, IAsyncRepository<CatalogBrand> brandRepository, IAsyncRepository<CatalogType> typeRepository)
        {
            _catalogRepository = catalogRepository ?? throw new ArgumentNullException(nameof(catalogRepository));
            _brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository));
            _typeRepository = typeRepository ?? throw new ArgumentNullException(nameof(typeRepository));
        }        

        public IEnumerable<CatalogItem> GetItemsOnPage(int pageIndex, int itemsPage, int? brandId, int? typeId)
        {            
            var filterPaginatedSpecification = new CatalogFilterPaginatedSpecification(itemsPage * pageIndex, itemsPage, brandId, typeId);
            return _catalogRepository.List(filterPaginatedSpecification);
        }

        public int GetItemsCount(int? brandId, int? typeId)
        {
            var filterSpecification = new CatalogFilterSpecification(brandId, typeId);
            return _catalogRepository.Count(filterSpecification);
        }

        public Task<IReadOnlyList<CatalogBrand>> GetBrands()
        {
            return _brandRepository.ListAllAsync();
        }

        public Task<IReadOnlyList<CatalogType>> GetTypes()
        {
            return _typeRepository.ListAllAsync();
        }

        public CatalogItem GetItemBySlug(string slug)
        {
            var slugSpecification = new SlugSpecification(slug);
            return _catalogRepository.GetSingleBySpec(slugSpecification);            
        }

        public CatalogItem GetCatalog1(string slug)
        {
            var slugSpecification = new SlugSpecification(slug);
            return _catalogRepository.GetSingleBySpec(slugSpecification);
        }
    }
}
