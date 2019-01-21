using Alfonso.Interfaces;
using Alfonso.Pages.Compare;
using ApplicationCore.Entities;
using ApplicationCore.Entities.CompareAggregate;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alfonso.Services
{
    public class CompareRazorService : ICompareRazorService
    {
        private readonly IAsyncRepository<Compare> _compareRepository;
        private readonly IUriComposer _uriComposer;
        private readonly IRepository<CatalogItem> _itemRepository;

        public CompareRazorService(IAsyncRepository<Compare> compareRepository, IUriComposer uriComposer, IRepository<CatalogItem> itemRepository)
        {
            _compareRepository = compareRepository ?? throw new ArgumentNullException(nameof(compareRepository));
            _uriComposer = uriComposer ?? throw new ArgumentNullException(nameof(uriComposer));
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
        }      

        public async Task<CompareViewModel> GetOrCreateCompareForUser(string userName)
        {
            var compareSpec = new CompareWithItemsSpecification(userName);
            var compare = (await _compareRepository.ListAsync(compareSpec)).FirstOrDefault();

            if (compare == null)
            {
                return await CreateCompareForUser(userName);
            }
            return CreateViewModelFromCompare(compare);
        }

        public async Task<CompareViewModel> GetCompare(int compareId)
        {
            var compareSpec = new CompareWithItemsSpecification(compareId);
            var compare = (await _compareRepository.ListAsync(compareSpec)).FirstOrDefault();

            if (compare == null)
            {
                throw new NotImplementedException();
            }

            return CreateViewModelFromCompare(compare);
        }

        private async Task<CompareViewModel> CreateCompareForUser(string userId)
        {
            var compare = new Compare() { BuyerId = userId };
            await _compareRepository.AddAsync(compare);

            return new CompareViewModel()
            {
                BuyerId = compare.BuyerId,
                Id = compare.Id,
                Items = new List<CompareItemViewModel>()
            };
        }

        private CompareViewModel CreateViewModelFromCompare(Compare compare)
        {
            var viewModel = new CompareViewModel();
            viewModel.Id = compare.Id;
            viewModel.BuyerId = compare.BuyerId;
            viewModel.Items = compare.Items.Select(i =>
            {
                var itemModel = new CompareItemViewModel()
                {
                    Id = i.Id,
                    UnitPrice = i.UnitPrice,
                    Quantity = i.Quantity,
                    CatalogItemId = i.CatalogItemId

                };
                var item = _itemRepository.GetById(i.CatalogItemId);
                itemModel.PictureUrl = _uriComposer.ComposePicUri(item.PictureUri);                
                itemModel.ProductName = item.Name;
                return itemModel;
            }).ToList();

            return viewModel;
        }

       
    }
}
