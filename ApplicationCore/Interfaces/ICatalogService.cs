using ApplicationCore.Entities;
using ApplicationCore.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ICatalogService
    {
        IEnumerable<CatalogItem> GetItemsOnPage(int pageIndex, int itemsPage, int? brandId, int? typeId);
        int GetItemsCount(int? brandId, int? typeId);
        Task<IReadOnlyList<CatalogBrand>> GetBrands();
        Task<IReadOnlyList<CatalogType>> GetTypes();
        CatalogItem GetItemBySlug(string slug);
    }
}
