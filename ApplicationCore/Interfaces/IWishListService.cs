using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IWishListService
    {
        Task<int> GetWishlistItemCountAsync(string userName);
        Task AddItemToWishlist(int wishlistId, int catalogItemId);
        Task RemoveItemToWishlist(int wishlistId, int WishlistItemId);
    }
}
