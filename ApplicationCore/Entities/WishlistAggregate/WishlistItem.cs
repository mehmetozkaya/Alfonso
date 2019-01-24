using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities.WishlistAggregate
{
    public class WishlistItem : BaseEntity
    {
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string CompareDesc { get; set; }
        public int CatalogItemId { get; set; }
    }
}
