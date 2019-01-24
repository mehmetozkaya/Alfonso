using Alfonso.Interfaces;
using ApplicationCore.Interfaces;
using System;
using System.Threading.Tasks;

namespace Alfonso.Services
{
    public class WishlistRazorService : IWishlistRazorService
    {
        private readonly IWishListService _wishListService;
        private readonly IUriComposer _uriComposer;

        public WishlistRazorService(IWishListService wishListService, IUriComposer uriComposer)
        {
            _wishListService = wishListService ?? throw new ArgumentNullException(nameof(wishListService));
            _uriComposer = uriComposer ?? throw new ArgumentNullException(nameof(uriComposer));
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
