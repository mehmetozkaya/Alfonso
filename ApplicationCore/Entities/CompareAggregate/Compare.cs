using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities.CompareAggregate
{
    public class Compare : BaseEntity, IAggregateRoot
    {
        public string BuyerId { get; set; }
        private readonly List<CompareItem> _items = new List<CompareItem>();
        public IReadOnlyCollection<CompareItem> Items => _items.AsReadOnly();        


    }
}
