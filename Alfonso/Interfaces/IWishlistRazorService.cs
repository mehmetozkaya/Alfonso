using System.Threading.Tasks;

namespace Alfonso.Interfaces
{
    public interface IWishlistRazorService
    {
        Task<int> GetWishlistItemCountAsync(string userName);
        Task AddItemToWishlist(int wishlistId, int catalogItemId);
        Task RemoveItemToWishlist(int wishlistId, int wishlistItemId);
    }
}
