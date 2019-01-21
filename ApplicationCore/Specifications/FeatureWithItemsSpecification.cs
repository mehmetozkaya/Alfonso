using ApplicationCore.Entities.FeatureAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Specifications
{
    public class FeatureWithItemsSpecification : BaseSpecification<Feature>
    {
        public FeatureWithItemsSpecification(int catalogItemId)
          : base(b => b.CatalogItemId == catalogItemId)
        {
            AddInclude(b => b.Items);
        }      
    }
}
