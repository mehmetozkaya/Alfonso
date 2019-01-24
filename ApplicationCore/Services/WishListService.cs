using ApplicationCore.Entities.WishlistAggregate;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class WishListService : IWishListService
    {
        private readonly IAsyncRepository<Wishlist> _wishlistRepository;
        private readonly IRepository<WishlistItem> _itemRepository;
        private readonly IUriComposer _uriComposer;
        private readonly IAppLogger<CompareService> _logger;

        public WishListService(IAsyncRepository<Wishlist> wishlistRepository, IRepository<WishlistItem> itemRepository, IUriComposer uriComposer, IAppLogger<CompareService> logger)
        {
            _wishlistRepository = wishlistRepository ?? throw new ArgumentNullException(nameof(wishlistRepository));
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
            _uriComposer = uriComposer ?? throw new ArgumentNullException(nameof(uriComposer));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task AddItemToWishlist(int wishlistId, int catalogItemId)
        {
            var wishlist = await _wishlistRepository.GetByIdAsync(wishlistId);
            wishlist.AddItem(catalogItemId);
            await _wishlistRepository.UpdateAsync(wishlist);
        }

        public async Task RemoveItemToWishlist(int wishlistId, int WishlistItemId)
        {
            var wishlistSpec = new WishlistWithItemsSpecification(wishlistId);
            var wishlist = (await _wishlistRepository.ListAsync(wishlistSpec)).FirstOrDefault();

            wishlist.RemoveItem(wishlistId);
            await _wishlistRepository.UpdateAsync(wishlist);
        }

        public Task<int> GetWishlistItemCountAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public async Task<Wishlist> GetOrCreateWishlistForUser(string userName)
        {
            var wishlistSpec = new WishlistWithItemsSpecification(userName);
            var wishlist = (await _wishlistRepository.ListAsync(wishlistSpec)).FirstOrDefault();

            if (wishlist == null)
            {
                wishlist = new Wishlist() { OwnerId = userName };
                await _wishlistRepository.AddAsync(wishlist);
            }

            return wishlist;
        }

        public async Task<Wishlist> GetWishlist(int wishlistId)
        {
            var wishlistSpec = new WishlistWithItemsSpecification(wishlistId);
            var wishlist = (await _wishlistRepository.ListAsync(wishlistSpec)).FirstOrDefault();

            if (wishlist == null)
            {
                throw new NotImplementedException();
            }

            return wishlist;
        }
    }
}
