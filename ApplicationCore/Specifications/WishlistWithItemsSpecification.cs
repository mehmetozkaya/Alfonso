using ApplicationCore.Entities.WishlistAggregate;

namespace ApplicationCore.Specifications
{
    public class WishlistWithItemsSpecification : BaseSpecification<Wishlist>
    {
        public WishlistWithItemsSpecification(int wishlistId)
           : base(b => b.Id == wishlistId)
        {
            AddInclude(b => b.Items);
        }

        public WishlistWithItemsSpecification(string ownerId)
           : base(b => b.OwnerId == ownerId)
        {
            AddInclude(b => b.Items);
        }
    }
}
