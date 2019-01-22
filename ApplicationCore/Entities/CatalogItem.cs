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
        public List<Feature> Features { get; set; } = new List<Feature>();

        // TagFeatures
        public string AlfonsoPoint { get; set; }
        public string VersusPoint { get; set; }
        public string AntutuPoint { get; set; }
        public string Battery { get; set; }
        public string Camera { get; set; }
        public string Screen { get; set; }
        public string Storage { get; set; }
        public string Ram { get; set; }
        public string CPU { get; set; }

        public void AddFeature(Feature newFeature)
        {
            Features.Add(newFeature);
        }

    }
}
