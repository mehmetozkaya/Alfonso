using Alfonso.ViewModels;
using System.Threading.Tasks;

namespace Alfonso.Interfaces
{
    public interface IWishlistRazorService
    {
        Task<WishlistViewModel> GetOrCreateWishlistForUser(string userName);
        Task<WishlistViewModel> GetWishlist(int WishlistId);

        Task<int> GetWishlistItemCountAsync(string userName);
        Task AddItemToWishlist(int wishlistId, int catalogItemId);
        Task RemoveItemToWishlist(int wishlistId, int wishlistItemId);
    }
}
