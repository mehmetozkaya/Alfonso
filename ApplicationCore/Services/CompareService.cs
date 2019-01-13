using ApplicationCore.Entities;
using ApplicationCore.Entities.CompareAggregate;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class CompareService : ICompareService
    {
        private readonly IAsyncRepository<Compare> _compareRepository;
        private readonly IUriComposer _uriComposer;
        private readonly IAppLogger<CompareService> _logger;
        private readonly IRepository<CatalogItem> _itemRepository;

        public CompareService(IAsyncRepository<Compare> compareRepository, IUriComposer uriComposer, IAppLogger<CompareService> logger, IRepository<CatalogItem> itemRepository)
        {
            _compareRepository = compareRepository ?? throw new ArgumentNullException(nameof(compareRepository));
            _uriComposer = uriComposer ?? throw new ArgumentNullException(nameof(uriComposer));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
        }

        public async Task AddItemToCompare(int compareId, int catalogItemId)
        {
            var compare = await _compareRepository.GetByIdAsync(compareId);
            compare.AddItem(catalogItemId);
            await _compareRepository.UpdateAsync(compare);
        }

        public async Task DeleteCompareAsync(int compareId)
        {
            var compare = await _compareRepository.GetByIdAsync(compareId);
            await _compareRepository.DeleteAsync(compare);
        }

        public async Task<int> GetCompareItemCountAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task TransferCompareAsync(string anonymousId, string userName)
        {
            throw new NotImplementedException();
        }
    }
}
