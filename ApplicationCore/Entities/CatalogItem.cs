using ApplicationCore.Entities.FeatureAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class CatalogItem : BaseEntity
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public double Star { get; set; }
        public decimal Price { get; set; }
        public string PictureUri { get; set; }
        public int CatalogTypeId { get; set; }
        public CatalogType CatalogType { get; set; }
        public int CatalogBrandId { get; set; }
        public CatalogBrand CatalogBrand { get; set; }

        private readonly List<Feature> _features = new List<Feature>();
        public IReadOnlyCollection<Feature> Features => _features.AsReadOnly();

        public void AddFeature(Feature newFeature)
        {
            _features.Add(newFeature);
        }

    }
}
