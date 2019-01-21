using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationCore.Entities.CompareAggregate
{
    public class Compare : BaseEntity, IAggregateRoot
    {
        public string BuyerId { get; set; }
        private readonly List<CompareItem> _items = new List<CompareItem>();
        public IReadOnlyCollection<CompareItem> Items => _items.AsReadOnly();

        public void AddItem(int catalogItemId)
        {
            if (!Items.Any(i => i.CatalogItemId == catalogItemId))
            {
                _items.Add(new CompareItem()
                {
                    CatalogItemId = catalogItemId
                });
                return;
            }
            var existingItem = Items.FirstOrDefault(i => i.CatalogItemId == catalogItemId);            
        }

        public void RemoveItem(int compareItemId)
        {
            var removedItem = _items.FirstOrDefault(x => x.Id == compareItemId);

            if (removedItem != null)
            {                
                _items.Remove(removedItem);
            }         
        }

    }
}
