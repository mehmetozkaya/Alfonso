using Alfonso.Interfaces;
using Alfonso.ViewModels;
using ApplicationCore.Entities;
using ApplicationCore.Entities.WishlistAggregate;
using ApplicationCore.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Alfonso.Services
{
    public class WishlistRazorService : IWishlistRazorService
    {
        private readonly IWishListService _wishListService;
        private readonly IRepository<CatalogItem> _itemRepository;
        private readonly IUriComposer _uriComposer;

        public WishlistRazorService(IWishListService wishListService, IRepository<CatalogItem> itemRepository, IUriComposer uriComposer)
        {
            _wishListService = wishListService ?? throw new ArgumentNullException(nameof(wishListService));
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
            _uriComposer = uriComposer ?? throw new ArgumentNullException(nameof(uriComposer));
        }

        public async Task<WishlistViewModel> GetOrCreateWishlistForUser(string userName)
        {
            var wishlist = await _wishListService.GetOrCreateWishlistForUser(userName);
            return CreateViewModelFromWishlist(wishlist);
        }

        private WishlistViewModel CreateViewModelFromWishlist(Wishlist wishlist)
        {
            var viewModel = new WishlistViewModel();
            viewModel.Id = wishlist.Id;
            viewModel.OwnerId = wishlist.OwnerId;
            viewModel.Items = wishlist.Items.Select(i =>
            {
                var itemModel = new WishlistItemViewModel()
                {
                    Id = i.Id,
                    UnitPrice = i.UnitPrice,
                    Quantity = i.Quantity,
                    CatalogItemId = i.CatalogItemId

                };
                var item = _itemRepository.GetById(i.CatalogItemId);
                itemModel.PictureUrl = _uriComposer.ComposePicUri(item.PictureUri);
                itemModel.ProductName = item.Name;
                itemModel.Slug = item.Slug;
                return itemModel;
            }).ToList();

            return viewModel;
        }

        public async Task<WishlistViewModel> GetWishlist(int WishlistId)
        {
            var wishlist = await _wishListService.GetWishlist(WishlistId);
            return CreateViewModelFromWishlist(wishlist);
        }

        public async Task AddItemToWishlist(int wishlistId, int catalogItemId)
        {
            await _wishListService.AddItemToWishlist(wishlistId, catalogItemId);
        }       

        public async Task RemoveItemToWishlist(int wishlistId, int wishlistItemId)
        {
            await _wishListService.RemoveItemToWishlist(wishlistId, wishlistItemId);
        }       

        public async Task<int> GetWishlistItemCountAsync(string userName)
        {
            throw new NotImplementedException();
        }
       
    }
}
