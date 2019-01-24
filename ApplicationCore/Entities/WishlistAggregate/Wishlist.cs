using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationCore.Entities.WishlistAggregate
{
    public class Wishlist : BaseEntity, IAggregateRoot
    {
        public string OwnerId { get; set; }
        private readonly List<WishlistItem> _items = new List<WishlistItem>();
        public IReadOnlyCollection<WishlistItem> Items => _items.AsReadOnly();

        public void AddItem(int catalogItemId)
        {
            if (!Items.Any(i => i.CatalogItemId == catalogItemId))
            {
                _items.Add(new WishlistItem()
                {
                    CatalogItemId = catalogItemId
                });
                return;
            }            
        }

        public void RemoveItem(int wishItemId)
        {
            var removedItem = _items.FirstOrDefault(x => x.Id == wishItemId);

            if (removedItem != null)
            {
                _items.Remove(removedItem);
            }
        }
    }
}
