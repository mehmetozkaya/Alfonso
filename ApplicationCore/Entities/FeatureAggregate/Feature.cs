using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationCore.Entities.FeatureAggregate
{
    public class Feature : BaseEntity, IAggregateRoot
    {
        private Feature()
        {
            // required by EF
        }

        public Feature(string name, string subName=null)
        {
            Name = name;
            SubName = subName;
        }

        public string Name { get; set; }
        public string SubName { get; set; }

        public int CatalogItemId { get; set; }
        public CatalogItem CatalogItem { get; set; }
        
        private readonly List<FeatureItem> _items = new List<FeatureItem>();
        public IReadOnlyCollection<FeatureItem> Items => _items.AsReadOnly();

        public void AddItem(string name, string value)
        {
            if (!Items.Any(i => i.Name == name))
            {
                _items.Add(new FeatureItem
                {
                    Name = name,
                    Value = value
                });
                return;
            }
        }

    }
}
